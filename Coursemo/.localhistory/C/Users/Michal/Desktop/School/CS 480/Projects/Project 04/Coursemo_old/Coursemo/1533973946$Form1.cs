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

namespace Coursemo
{
  public partial class Form1 : Form
  {
    private List<Student> _students;
    private List<Course> _courses;


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
      db = new CoursemoDataContext();
      _students = new List<Student>();
      _courses = new List<Course>();
    }


    private void LoadStudents()
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


    private void LoadCourses()
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


    private void StudentsListBox_SelectedIndexChanged(object sender, EventArgs e)
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
        MessageBox.Show("StudentsListBox_SelectedIndexChanged(): " + exc.Message);
      }
    }


    private void FillEnrolledCourses(int sid)
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


    private void FillWaitlistedCourses(int sid)
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


    private void CoursesListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      int index = CoursesListBox.SelectedIndex;
      if (index < 0) return;

      Course c = _courses[index];
      this.CourseDetailLabel.Text = string.Format(@"
        Semester: {0}
        Year: {1}
        Type: {2}
        Days: {3}
        Time: {4}
        Size: {5}
        Available Seats: {6}",
        c.Semester, c.AcademicYear, c.CourseType, c.CourseDay, c.CourseTime, c.ClassSize,
        c.ClassSize - GetCurrentEnrollment(c.CID)
        );

      FillCourseEnrollmentList(c.CID);
      FillCourseWaitList(c.CID);

    }


    private void FillCourseEnrollmentList(int cid)
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

    private void FillCourseWaitList(int cid)
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
            this.InfoLabel.Text = "Error occured";
          else if (result == 0)
            this.InfoLabel.Text = "Student already enrolled";
          else if (result == 1)
            this.InfoLabel.Text = "Student enrolled";
          else if (result == 2)
            this.InfoLabel.Text = "Student already waitlisted";
          else
            this.InfoLabel.Text = "Student waitlisted";
        }
        
      }
      catch (Exception exc)
      {
        MessageBox.Show("EnrollButton_Click(): " + exc.Message);
      }
    }


    private int Enroll(int sid, int cid)
    {
      // make sure parameters are valid
      if (sid < 0 || cid < 0) return -1;

      try
      {
        var txOptions = new TransactionOptions();
        txOptions.IsolationLevel = System.Transactions.IsolationLevel.Serializable;

        using (var transaction = new TransactionScope(TransactionScopeOption.Required,
          txOptions))
        {
          // check if student is already enrolled
          bool enrolled = StudentEnrolled(sid, cid);

          if (enrolled) return 0;

          // class is full, add to waitlist
          if (GetCourseCapacity(cid) - GetCurrentEnrollment(cid) < 1)
          {
            // check if student is not on waitlist already
            bool waitlisted = StudentWaitlisted(sid, cid);

            if (waitlisted) return 2;

            db.WaitlistStudent(sid, cid);
            db.SubmitChanges();
            transaction.Complete();
            return 3;
          }
          // enroll
          else
          {
            db.RegisterStudent(sid, cid);
            db.SubmitChanges();
            transaction.Complete();
            return 1;
          }
        }
      }
      catch (Exception e)
      {
        MessageBox.Show("Enroll(): " + e.Message);
        return -1;
      }
    }


    private int GetCurrentEnrollment(int cid)
    {
      return Convert.ToInt32((from r in db.Registrations
                              where r.CID == cid
                              select r).Count());
    }


    private int GetCourseCapacity(int cid)
    {
      return Convert.ToInt32((from c in db.Courses
                              where c.CID == cid
                              select c.ClassSize).Single());
    }

    private bool StudentEnrolled(int sid, int cid)
    {
      int enrolled = (from reg in db.Registrations
                      where reg.SID == sid
                      && reg.CID == cid
                      select reg).Count();

      return enrolled > 0;
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

        }

      }
      catch (Exception exc)
      {

      }
    }


    //
    // Drop():
    //
    // 0 - dropped, no waitlist
    // 1 - dropped, enrolled student from waitlist
    // 2 - not enrolled, dropped from waitlist
    // 3 - student was not either enrolled or waitlisted
    //
    private int Drop(int sid, int cid)
    {
      // make sure parameters are valid
      if (sid < 0 || cid < 0) return -1;

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
            db.UnwaitlistStudent(sid, cid)
          }

          // class is full, add to waitlist
          if (GetCourseCapacity(cid) - GetCurrentEnrollment(cid) < 1)
          {
            // check if student is not on waitlist already
            bool waitlisted = StudentWaitlisted(sid, cid);

            if (waitlisted) return 2;

            db.WaitlistStudent(sid, cid);
            db.SubmitChanges();
            transaction.Complete();
            return 3;
          }
          // enroll
          else
          {
            db.RegisterStudent(sid, cid);
            db.SubmitChanges();
            transaction.Complete();
            return 1;
          }
        }
      }
      catch (Exception e)
      {
        MessageBox.Show("Enroll(): " + e.Message);
        return -1;
      }
    }


    private int GetFirstStudentFromWaitlist(int cid)
    {
      return (from w in db.Waitlists
                where w.CID == cid
                select w.SID).FirstOrDefault();
    }
  }
}
