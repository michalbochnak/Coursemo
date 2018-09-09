using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursemo
{
  //
  // Student:
  //
  partial class Student
  {
    public override string ToString()
    {
      return string.Format("{0}, {1}, {2}",
        this.LastName, this.FirstName, this.Email);
    }
  }


  //
  // Course:
  //
  partial class Course
  {
    public override string ToString()
    {
      return string.Format("{0}{1}   CRN: {2}",
        this.Department, this.CourseNumber, this.CRN);
    }
  }


  //
  // Registration:
  //

}
