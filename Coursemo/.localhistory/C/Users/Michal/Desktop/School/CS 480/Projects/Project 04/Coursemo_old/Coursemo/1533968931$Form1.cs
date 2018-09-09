﻿using System;
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

      Course course = _courses[index];
      this.CourseDetailLabel.Text = string.Format(@"Semester: {0}", );
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
          int enrolled = (from reg in db.Registrations
                         where reg.SID == sid
                         && reg.CID == cid
                         select reg).Count();

          if (enrolled > 0) return 0;

          // check for available spot
          int capacity = Convert.ToInt32((from c in db.Courses
                                          where c.CID == cid
                                          select c.ClassSize).Single());

          // get max enrollment in the course
          int currEnrollment = Convert.ToInt32((from r in db.Registrations
                                                where r.CID == cid
                                                select r).Count());

          // class is full, add to waitlist
          if (capacity - currEnrollment < 1)
          {
            // check if student is not on waitlist already
            int waitlisted = (from wait in db.Waitlists
                             where wait.SID == sid
                             && wait.CID == cid
                             select wait).Count();

            if (waitlisted > 0) return 2;

            db.WaitlistStudent(sid, cid);
            db.SubmitChanges();
            transaction.Complete();
            MessageBox.Show("Added to waitlist s: " + sid + "c: " + cid);
            return 1;
          }
          // enroll
          else
          {
            db.RegisterStudent(sid, cid);
            db.SubmitChanges();
            transaction.Complete();
            return 3;
          }
        }
      }
      catch (Exception e)
      {
        MessageBox.Show("Enroll(): " + e.Message);
        return -1;
      }
    }

  }
}
