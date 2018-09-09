
//
// Console app to create a database, e.g. Coursemo.
//
// Michal Bochnak
// U. of Illinois, Chicago
// CS480, Summer 2018
// Project #4, Part I
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateDBApp
{
  class Program
  {
    private static CoursemoDataContext db = new CoursemoDataContext();

    static void Main(string[] args)
    {
      Console.WriteLine();
      Console.WriteLine("** Create Database Console App **");
      Console.WriteLine();

      string baseDatabaseName = "Coursemo";
      string sql;

      try
      {
        //
        // 1. Make a copy of empty MDF file to get us started:
        //
        Console.WriteLine("Copying empty database to {0}.mdf and {0}_log.ldf...", baseDatabaseName);

        CopyEmptyFile("__EmptyDB", baseDatabaseName);

        Console.WriteLine();

        //
        // 2. Now let's make sure we can connect to SQL Server on local machine:
        //
        DataAccessTier.Data data = new DataAccessTier.Data(baseDatabaseName + ".mdf");

        Console.Write("Testing access to database:  ");

        if (data.TestConnection())
          Console.WriteLine("success");
        else
          Console.WriteLine("failure?!");

        Console.WriteLine();

        //
        // 3. Create tables by reading from .sql file and executing DDL queries:
        //
        Console.WriteLine("Creating tables by executing {0}.sql file...", baseDatabaseName);

        string[] lines = System.IO.File.ReadAllLines(baseDatabaseName + ".sql");

        sql = "";

        for (int i = 0; i < lines.Length; ++i)
        {
          string next = lines[i];

          if (next.Trim() == "")  // empty line, ignore...
          {
          }
          else if (next.Contains(";"))  // we have found the end of the query:
          {
            sql = sql + next + System.Environment.NewLine;

            Console.WriteLine("** Executing '{0}'...", sql);

            data.ExecuteActionQuery(sql);

            sql = "";  // reset:
          }
          else  // add to existing query:
          {
              sql = sql + next + System.Environment.NewLine;
          }
        }

        Console.WriteLine();

        //
        // 4. Insert data by parsing data from .csv files:
        //
        Console.WriteLine("Inserting data...");

        InsertStudents();
        InsertCourses();

        Console.WriteLine();

        //
        // Done
        //
      }
      catch (Exception ex)
      {
        Console.WriteLine("**Exception: '{0}'", ex.Message);
      }

      Console.WriteLine();
      Console.WriteLine("** Done **");
      Console.WriteLine();
    }//Main


    // 
    // InsertStudents():
    // 
    private static void InsertStudents()
    {
      using (var file = new System.IO.StreamReader("students.csv"))
      {
        while (!file.EndOfStream)
        {
          //
          // insert students from .csv file
          //
          string line = file.ReadLine();
          string[] values = line.Split(',');

          Student s = new Student
          {
            LastName = values[0],
            FirstName = values[1],
            Email = values[2]
          };

          db.Students.InsertOnSubmit(s);

          try
          {
            db.SubmitChanges();
          }
          catch (Exception e)
          {
            Console.WriteLine(e);
            // retry
            db.SubmitChanges();
          }
        }//while
      }//using
    }

    // 
    // insertBikes():
    // 
    private static void InsertCourses()
    {
      using (var file = new System.IO.StreamReader("courses.csv"))
      {
        while (!file.EndOfStream)
        {
          //
          // insert courses from .csv file
          //
          string line = file.ReadLine();
          string[] values = line.Split(',');

          Course c = new Course
          {
            Department = values[0],
            CourseNumber = Convert.ToInt16(values[1]),
            Semester = values[2],
            AcademicYear = Convert.ToInt16(values[3]),
            CRN = Convert.ToInt32(values[4]),
            CourseType = values[5],
            CourseDay = values[6],
            CourseTime = values[7],
            ClassSize = Convert.ToInt16(values[8])
          };

          db.Courses.InsertOnSubmit(c);

          try
          {
            db.SubmitChanges();
            Console.WriteLine("Added: " + c);
          }
          catch (Exception e)
          {
            Console.WriteLine(e);
            // retry
            db.SubmitChanges();
          }


        }//while
      }//using
    }

    /// <summary>
    /// Makes a copy of an existing Microsoft SQL Server database file 
    /// and log file.  Throws an exception if an error occurs, otherwise
    /// returns normally upon successful copying.  Assumes files are in
    /// sub-folder bin\Debug or bin\Release --- i.e. same folder as .exe.
    /// </summary>
    /// <param name="basenameFrom">base file name to copy from</param>
    /// <param name="basenameTo">base file name to copy to</param>
    static void CopyEmptyFile(string basenameFrom, string basenameTo)
    {
      string from_file, to_file;

      //
      // copy .mdf:
      //
      from_file = basenameFrom + ".mdf";
      to_file = basenameTo + ".mdf";

      if (System.IO.File.Exists(to_file))
      {
        System.IO.File.Delete(to_file);
      }

      System.IO.File.Copy(from_file, to_file);

      // 
      // now copy .ldf:
      //
      from_file = basenameFrom + "_log.ldf";
      to_file = basenameTo + "_log.ldf";

      if (System.IO.File.Exists(to_file))
      {
        System.IO.File.Delete(to_file);
      }

      System.IO.File.Copy(from_file, to_file);
    }

  }//class
}//namespace

