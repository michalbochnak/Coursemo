using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Transactions;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace Coursemo
{
  public partial class Form1 : Form
  {
    private List<Student> _students;
    private List<Course> _courses;
    private int _delay;


    public Form1()
    {
      InitializeComponent();
      InitialSetup();
    }


    private void InitialSetup()
    {
      //
      // Create LINQ to SQL object
      //
      InitializeDataStructures();
      LoadStudents();
      LoadCourses();
    }


    private void InitializeDataStructures()
    {
      //db = new CoursemoDataContext();
      _students = new List<Student>();
      _courses = new List<Course>();
      _delay = 0;
    }


    private void LoadStudents()
    {
      using (var db = new CoursemoDataContext())
      {

        try
        {
          var query = from s in db.Students
                      orderby s.LastName, s.FirstName
                      select s;

          foreach (Student s in query)
          {
            Student temp = new Student
            {
              SID = s.SID,
              LastName = s.LastName,
              FirstName = s.FirstName,
              Email = s.Email
            };

            _students.Add(temp);
            this.StudentsListBox.Items.Add(temp);
          }
        }
        catch (Exception e)
        {
          MessageBox.Show("LoadStudents(): " + e.Message);
        }
      }
    }


    private void LoadCourses()
    {
      using (var db = new CoursemoDataContext())
      {
        try
        {
          var query = from c in db.Courses
                      orderby c.Department, c.CourseNumber, c.CRN
                      select c;

          foreach (Course c in query)
          {
            Course temp = new Course
            {
              CID = c.CID,
              Department = c.Department,
              CourseNumber = c.CourseNumber,
              Semester = c.Semester,
              AcademicYear = c.AcademicYear,
              CRN = c.CRN,
              CourseType = c.CourseType,
              CourseDay = c.CourseDay,
              CourseTime = c.CourseTime,
              ClassSize = c.ClassSize
            };

            _courses.Add(temp);
            this.CoursesListBox.Items.Add(temp);
          }
        }
        catch (Exception e)
        {
          MessageBox.Show("LoadCourses(): " + e.Message);
        }
      }
    }


    private void StudentsListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      UpdateStudentUi();
    }


    private void FillEnrolledCourses(int sid)
    {
      using (var db = new CoursemoDataContext())
      {

        var query = from c in db.Courses
                    join r in db.Registrations
                    on c.CID equals r.CID
                    where r.SID == sid
                    orderby c.CourseType, c.CourseNumber, c.CRN
                    select c;


        this.EnrolledInListBox.Items.Clear();

        foreach (Course c in query)
        {
          this.EnrolledInListBox.Items.Add(c);
        }
      }
    }


    private void FillWaitlistedCourses(int sid)
    {
      using (var db = new CoursemoDataContext())
      {

        var query = from c in db.Courses
                    join w in db.Waitlists
                    on c.CID equals w.CID
                    where w.SID == sid
                    orderby c.CourseType, c.CourseNumber, c.CRN
                    select c;


        this.WaitlistListBox.Items.Clear();

        foreach (Course c in query)
        {
          this.WaitlistListBox.Items.Add(c);
        }
      }
    }


    private void CoursesListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      UpdateCourseUi();
    }


    private void FillCourseEnrollmentList(int cid)
    {
      using (var db = new CoursemoDataContext())
      {

        var query = from r in db.Registrations
                    where r.CID == cid
                    select r;

        this.CourseEnrollmentListBox.Items.Clear();

        foreach (Registration r in query)
        {
          // insert student netid
          this.CourseEnrollmentListBox.Items.Add(GetStudentEmail(r.SID));
        }
      }
    }


    private void FillCourseWaitList(int cid)
    {
      using (var db = new CoursemoDataContext())
      {

        var query = from w in db.Waitlists
                    where w.CID == cid
                    select w;

        this.CourseWaitlistListBox.Items.Clear();

        foreach (Waitlist w in query)
        {
          // insert student netid
          this.CourseWaitlistListBox.Items.Add(GetStudentEmail(w.SID));
        }
      }
    }


    private void EnrollButton_Click(object sender, EventArgs e)
    {
      try
      {
        int sIdx = this.StudentsListBox.SelectedIndex;
        int cIdx = this.CoursesListBox.SelectedIndex;

        if (sIdx < 0)
        {
          this.InfoLabel.Text = "Please select student.";
          return;
        }
        else if (cIdx < 0)
        {
          this.InfoLabel.Text = "Please select course.";
          return;
        }
        // enroll
        else
        {
          int result = Enroll(_students[sIdx].SID, _courses[cIdx].CID);
          if (result == -1)
            this.InfoLabel.Text = "Error occured.";
          else if (result == 0)
            this.InfoLabel.Text = "Student already enrolled.";
          else if (result == 1)
            this.InfoLabel.Text = "Student enrolled.";
          else if (result == 2)
            this.InfoLabel.Text = "Student already waitlisted.";
          else
            this.InfoLabel.Text = "Student waitlisted.";

          UpdateUi();
        }
        
      }
      catch (Exception exc)
      {
        MessageBox.Show("EnrollButton_Click(): " + exc.Message);
      }
    }


    private void UpdateUi()
    {
      UpdateStudentUi();
      UpdateCourseUi();
    }


    private void UpdateStudentUi()
    {
      int index = this.StudentsListBox.SelectedIndex;
      // sometimes this event fires, but nothing is selected...
      if (index < 0)   // so return now in this case:
        return;

      try
      {
        FillEnrolledCourses(_students[index].SID);
        FillWaitlistedCourses(_students[index].SID);
      }
      catch (Exception exc)
      {
        MessageBox.Show("UpdateStudentUi(): " + exc.Message);
      }
    }


    private void UpdateCourseUi()
    {
      int index = CoursesListBox.SelectedIndex;
      if (index < 0) return;

      Course c = _courses[index];

      FillCourseEnrollmentList(c.CID);
      FillCourseWaitList(c.CID);

      this.CourseDetailLabel.Text = string.Format(@"Semester: {0}
Year: {1}
Type: {2}
Days: {3}
Time: {4}
Size: {5}
Enrolled: {6}
Available Seats: {7}
# on waitlist: {8}",
        c.Semester, c.AcademicYear, c.CourseType, c.CourseDay, c.CourseTime, c.ClassSize,
        GetCurrentEnrollment(c.CID), c.ClassSize - GetCurrentEnrollment(c.CID),
        this.CourseWaitlistListBox.Items.Count
        );
    }


    //
    // Enroll():
    //
    // -1 - error
    // 0 - Student already enrolled
    // 1 - Student enrolled
    // 2 - Student already waitlisted
    // 3 - Student waitlisted
    //
    private int Enroll(int sid, int cid)
    {
      int retries = 0;

      // make sure parameters are valid
      if (sid < 0 || cid < 0) return -1;

      using (var db = new CoursemoDataContext())
      {

        while (retries < 3)
        {
          try
          {
            var txOptions = new TransactionOptions();
            txOptions.IsolationLevel = System.Transactions.IsolationLevel.Serializable;

            using (var transaction = new TransactionScope(TransactionScopeOption.Required,
              txOptions))
            {
              // check if student is already enrolled
              if (StudentEnrolled(sid, cid)) return 0;

              // class is full, add to waitlist
              if (GetCourseCapacity(cid) - GetCurrentEnrollment(cid) < 1)
              {
                // check if student is not on waitlist alread
                if (StudentWaitlisted(sid, cid)) return 2;

                db.WaitlistStudent(sid, cid);
                db.SubmitChanges();
                transaction.Complete();
                return 3;
              }
              // enroll
              else
              {
                System.Threading.Thread.Sleep(_delay);

                db.RegisterStudent(sid, cid);
                db.SubmitChanges();
                transaction.Complete();
                return 1;
              }
            }
          }
          catch (SqlException exc)
          {
            // deadlock
            if (exc.Number == 1205)
              retries++;
          }
          catch (Exception e)
          {
            MessageBox.Show("Enroll(): " + e.Message);
            return -1;
          }
        } // while
      }

      return -1;
    }


    private int GetCurrentEnrollment(int cid)
    {
      using (var db = new CoursemoDataContext())
      {
        return Convert.ToInt32((from r in db.Registrations
                                where r.CID == cid
                                select r).Count());
      }
    }


    private int GetCourseCapacity(int cid)
    {
      return Convert.ToInt32((from c in db.Courses
                              where c.CID == cid
                              select c.ClassSize).Single());
    }


    private bool StudentEnrolled(int sid, int cid)
    {
      using (var db = new CoursemoDataContext())
      {
        int enrolled = (from reg in db.Registrations
                        where reg.SID == sid
                        && reg.CID == cid
                        select reg).Count();

        return enrolled > 0;
      }
    }


    private bool StudentWaitlisted(int sid, int cid)
    {
      int waitlisted = (from wait in db.Waitlists
                        where wait.SID == sid
                        && wait.CID == cid
                        select wait).Count();

      return waitlisted > 0;
    }


    private string GetStudentEmail(int sid)
    {
      return (from s in db.Students
              where s.SID == sid
              select s.Email).Single();
    }


    private void DropButton_Click(object sender, EventArgs e)
    {
      try
      {
        int sIdx = this.StudentsListBox.SelectedIndex;
        int cIdx = this.CoursesListBox.SelectedIndex;

        if (sIdx < 0)
        {
          this.InfoLabel.Text = "Please select student.";
          return;
        }
        else if (cIdx < 0)
        {
          this.InfoLabel.Text = "Please select course.";
          return;
        }
        // drop
        else
        {
          int result = Drop(_students[sIdx].SID, _courses[cIdx].CID);
          if (result == -1)
            InfoLabel.Text = "Error occured.";
          else if (result == 0)
            InfoLabel.Text = "Dropped,\nwaitlist empty.";
          else if (result == 1)
            InfoLabel.Text = "Dropped,\nstudent from waitlist enrolled.";
          else if (result == 2)
            InfoLabel.Text = "Student dropped from waitlist.";
          else
            InfoLabel.Text = "Student was not enrolled\nor waitlisted";

          UpdateUi();
        }
      }
      catch (Exception exc)
      {
        MessageBox.Show("DropButton_Click(): " + exc.Message);
      }
    }


    //
    // Drop():
    //
    // -1 - error
    // 0 - dropped, no waitlist
    // 1 - dropped, enrolled student from waitlist
    // 2 - not enrolled, dropped from waitlist
    // 3 - student was not either enrolled or waitlisted
    //
    private int Drop(int sid, int cid)
    {
      int retries = 0;

      // make sure parameters are valid
      if (sid < 0 || cid < 0) return -1;

      while (retries < 3)
      {
        try
        {
          var txOptions = new TransactionOptions();
          txOptions.IsolationLevel = System.Transactions.IsolationLevel.Serializable;

          using (var transaction = new TransactionScope(TransactionScopeOption.Required,
            txOptions))
          {
            // student enrolled, drop course and enroll first student on waitlist
            if (StudentEnrolled(sid, cid))
            {
              db.UnregisterStudent(sid, cid);
              // candidate on waitlist exists
              int sidFromWaitList = GetFirstStudentFromWaitlist(cid);

              System.Threading.Thread.Sleep(_delay);

              if (sidFromWaitList != 0)
              {
                db.RegisterStudent(sidFromWaitList, cid);
                db.UnwaitlistStudent(sidFromWaitList, cid);
                db.SubmitChanges();
                transaction.Complete();
                return 1;
              }
              db.SubmitChanges();
              transaction.Complete();
              return 0;
            }
            // student not enrolled, but waitlisted, remove from waitlist
            else if (StudentWaitlisted(sid, cid))
            {
              db.UnwaitlistStudent(sid, cid);
              db.SubmitChanges();
              transaction.Complete();
              return 2;
            }
            else
              return 3;
          }
        }
        catch (SqlException exc)
        {
          // deadlock
          if (exc.Number == 1205)
            retries++;
        }
        catch (Exception e)
        {
          MessageBox.Show("Drop(): " + e.Message);
          return -1;
        }
      } // while

      return -1;
    }


    private int GetFirstStudentFromWaitlist(int cid)
    {
      return (from w in db.Waitlists
                where w.CID == cid
                select w.SID).FirstOrDefault();
    }


    private void SwapButton_Click(object sender, EventArgs e)
    {
      string info = "SWAP: Select student and course\n" +
                              "from list boxes. For second student\n" +
                              "enter netid (email) and CRN into\n" +
                              "text fields above. Input is assumed\n" +
                              "to be valid.";

      int s1 = this.StudentsListBox.SelectedIndex;
      int c1 = this.CoursesListBox.SelectedIndex;

      if (string.IsNullOrEmpty(this.NetidTextBox.Text) 
        || string.IsNullOrEmpty(this.CrnTextBox.Text)
        || s1 < 0 || c1 < 0 ) {

        this.InfoLabel.Text = info;
        return;
      }

      int s2 = GetStudentSid(this.NetidTextBox.Text);
      int c2 = GetCourseCid(Convert.ToInt32(this.CrnTextBox.Text));

      if (_students[s1].SID == s2)
      {
        InfoLabel.Text = "Specify two different students.";
        return;
      }
      else if (_courses[c1].CID == c2)
      {
        InfoLabel.Text = "Specify two different courses.";
        return;
      }

      // swap

      int result = Swap(_students[s1].SID, s2, _courses[c1].CID, c2);
      if (result == 1)
        InfoLabel.Text = "Swap succesfull.";
      else
        InfoLabel.Text = "Swap failed.";

      UpdateUi();
    }


    //
    // Swap():
    //
    // 0 - failure
    // 1 - success
    //
    private int Swap(int s1, int s2, int c1, int c2)
    {
      int retries = 0;

      while (retries < 3)
      {
        try
        {
          var txOptions = new TransactionOptions();
          txOptions.IsolationLevel = System.Transactions.IsolationLevel.Serializable;

          using (var transaction = new TransactionScope(TransactionScopeOption.Required,
            txOptions))
          {
            // both students must be enrolled
            if (StudentEnrolled(s1, c1) && StudentEnrolled(s2, c2))
            {
              db.UnregisterStudent(s1, c1);
              db.RegisterStudent(s2, c1);

              System.Threading.Thread.Sleep(_delay);

              db.UnregisterStudent(s2, c2);
              db.RegisterStudent(s1, c2);
              db.SubmitChanges();
              transaction.Complete();
              return 1;
            }
            else
            {
              return 0;
            }
          }
        }
        catch (SqlException exc)
        {
          // deadlock
          if (exc.Number == 1205)
            retries++;
        }
        catch (Exception e)
        {
          MessageBox.Show("Swap(): " + e.Message);
          return 0;
        }
      } // while

      return 0;
    }


    private int GetStudentSid(string email)
    {
      foreach (Student s in _students)
        if (s.Email == email)
          return s.SID;

      return -1;
    }


    private int GetCourseCid(int crn)
    {
      foreach (Course c in _courses)
        if (c.CRN == crn)
          return c.CID;

      return -1;
    }


    private void ResetDatabaseButton_Click(object sender, EventArgs e)
    {
      ResetDatabase();
    }


    private void ResetDatabase()
    {
      try
      {
        var query1 = from r in db.Registrations select r;
        db.Registrations.DeleteAllOnSubmit(query1);
        var query2 = from w in db.Waitlists select w;
        db.Waitlists.DeleteAllOnSubmit(query2);
        db.SubmitChanges();
        UpdateUi();
      }
      catch (Exception exc)
      {
        MessageBox.Show("ResetDatabase(): " + exc.Message);
      }
    }


    private void DelayTextBox_TextChanged(object sender, EventArgs e)
    {
      UpdateDelay();
    }


    private void UpdateDelay()
    {
      if (DelayTextBox.Text != "" &&
          new Regex("^[0-9]*$").IsMatch(DelayTextBox.Text))
        _delay = Convert.ToInt32(DelayTextBox.Text);
      else
        _delay = 0;
    }

  } // Form1 class
} // Coursemo namespace
