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
            Department = c.Department,
            CourseNumber = c.CourseNumber,
            CRN = c.CRN
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
        var query = from c in db.Courses
                    join r in db.Registrations
                    on c.CID equals r.CID
                    where r.SID == _students[index].SID
                    orderby c.CourseType, c.CourseNumber, c.CRN
                    select c;


        this.EnrolledInListBox.Items.Clear();

        foreach (Course c in query)
        {
          this.EnrolledInListBox.Items.Add(c);
        }
      }
      catch (Exception exc)
      { 
        MessageBox.Show("StudentsListBox_SelectedIndexChanged(): " + exc.Message);
      }
    }


    private void CoursesListBox_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void EnrollButton_Click(object sender, EventArgs e)
    {
      try
      {
        int sid = this.StudentsListBox.SelectedIndex;
        int cid = this.CoursesListBox.SelectedIndex;

        if (sid < 0)
        {
          this.InfoLabel.Text = "Please select student.";
          return;
        }
        else if (cid < 0)
        {
          this.InfoLabel.Text = "Please sele\nct course.";
          return;
        }
        // enroll
        else
        {
          this.InfoLabel.Text = Enroll(sid, cid) == true ? 
            this.InfoLabel.Text = "Student enrolled"
            : this.InfoLabel.Text = "Student NOT enrolled";
        }
        
      }
      catch (Exception exc)
      {
        MessageBox.Show("EnrollButton_Click(): " + exc.Message);
      }
    }


    private bool Enroll(int sid, int cid)
    {
      // make sure parameters are valid
      if (sid < 0 || cid < 0) return false;


      using (var transaction = new TransactionScope(TransactionScopeOption.Required,))
      {

      }


        return false;
    }
  }
}
