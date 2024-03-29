﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Coursemo
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Coursemo")]
	public partial class CoursemoDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertCourse(Course instance);
    partial void UpdateCourse(Course instance);
    partial void DeleteCourse(Course instance);
    partial void InsertWaitlist(Waitlist instance);
    partial void UpdateWaitlist(Waitlist instance);
    partial void DeleteWaitlist(Waitlist instance);
    partial void InsertRegistration(Registration instance);
    partial void UpdateRegistration(Registration instance);
    partial void DeleteRegistration(Registration instance);
    partial void InsertStudent(Student instance);
    partial void UpdateStudent(Student instance);
    partial void DeleteStudent(Student instance);
    #endregion
		
		public CoursemoDataContext() : 
				base(global::Coursemo.Properties.Settings.Default.CoursemoConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public CoursemoDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public CoursemoDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public CoursemoDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public CoursemoDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Course> Courses
		{
			get
			{
				return this.GetTable<Course>();
			}
		}
		
		public System.Data.Linq.Table<Waitlist> Waitlists
		{
			get
			{
				return this.GetTable<Waitlist>();
			}
		}
		
		public System.Data.Linq.Table<Registration> Registrations
		{
			get
			{
				return this.GetTable<Registration>();
			}
		}
		
		public System.Data.Linq.Table<Student> Students
		{
			get
			{
				return this.GetTable<Student>();
			}
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.WaitlistStudent")]
		public int WaitlistStudent([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> studentId, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> courseId)
		{
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), studentId, courseId);
            return ((int)(result.ReturnValue));
        }
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.RegisterStudent")]
		public void RegisterStudent([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> studentId, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> courseId)
		{
			this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), studentId, courseId);
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.UnregisterStudent")]
		public int UnregisterStudent([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> studentId, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> courseId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), studentId, courseId);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.UnwaitlistStudent")]
		public int UnwaitlistStudent([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> studentId, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> courseId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), studentId, courseId);
			return ((int)(result.ReturnValue));
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Course")]
	public partial class Course : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _CID;
		
		private string _Department;
		
		private short _CourseNumber;
		
		private string _Semester;
		
		private short _AcademicYear;
		
		private int _CRN;
		
		private string _CourseType;
		
		private string _CourseDay;
		
		private string _CourseTime;
		
		private short _ClassSize;
		
		private EntitySet<Waitlist> _Waitlists;
		
		private EntitySet<Registration> _Registrations;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnCIDChanging(int value);
    partial void OnCIDChanged();
    partial void OnDepartmentChanging(string value);
    partial void OnDepartmentChanged();
    partial void OnCourseNumberChanging(short value);
    partial void OnCourseNumberChanged();
    partial void OnSemesterChanging(string value);
    partial void OnSemesterChanged();
    partial void OnAcademicYearChanging(short value);
    partial void OnAcademicYearChanged();
    partial void OnCRNChanging(int value);
    partial void OnCRNChanged();
    partial void OnCourseTypeChanging(string value);
    partial void OnCourseTypeChanged();
    partial void OnCourseDayChanging(string value);
    partial void OnCourseDayChanged();
    partial void OnCourseTimeChanging(string value);
    partial void OnCourseTimeChanged();
    partial void OnClassSizeChanging(short value);
    partial void OnClassSizeChanged();
    #endregion
		
		public Course()
		{
			this._Waitlists = new EntitySet<Waitlist>(new Action<Waitlist>(this.attach_Waitlists), new Action<Waitlist>(this.detach_Waitlists));
			this._Registrations = new EntitySet<Registration>(new Action<Registration>(this.attach_Registrations), new Action<Registration>(this.detach_Registrations));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int CID
		{
			get
			{
				return this._CID;
			}
			set
			{
				if ((this._CID != value))
				{
					this.OnCIDChanging(value);
					this.SendPropertyChanging();
					this._CID = value;
					this.SendPropertyChanged("CID");
					this.OnCIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Department", DbType="NVarChar(64) NOT NULL", CanBeNull=false)]
		public string Department
		{
			get
			{
				return this._Department;
			}
			set
			{
				if ((this._Department != value))
				{
					this.OnDepartmentChanging(value);
					this.SendPropertyChanging();
					this._Department = value;
					this.SendPropertyChanged("Department");
					this.OnDepartmentChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CourseNumber", DbType="SmallInt NOT NULL")]
		public short CourseNumber
		{
			get
			{
				return this._CourseNumber;
			}
			set
			{
				if ((this._CourseNumber != value))
				{
					this.OnCourseNumberChanging(value);
					this.SendPropertyChanging();
					this._CourseNumber = value;
					this.SendPropertyChanged("CourseNumber");
					this.OnCourseNumberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Semester", DbType="NVarChar(10) NOT NULL", CanBeNull=false)]
		public string Semester
		{
			get
			{
				return this._Semester;
			}
			set
			{
				if ((this._Semester != value))
				{
					this.OnSemesterChanging(value);
					this.SendPropertyChanging();
					this._Semester = value;
					this.SendPropertyChanged("Semester");
					this.OnSemesterChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AcademicYear", DbType="SmallInt NOT NULL")]
		public short AcademicYear
		{
			get
			{
				return this._AcademicYear;
			}
			set
			{
				if ((this._AcademicYear != value))
				{
					this.OnAcademicYearChanging(value);
					this.SendPropertyChanging();
					this._AcademicYear = value;
					this.SendPropertyChanged("AcademicYear");
					this.OnAcademicYearChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CRN", DbType="Int NOT NULL")]
		public int CRN
		{
			get
			{
				return this._CRN;
			}
			set
			{
				if ((this._CRN != value))
				{
					this.OnCRNChanging(value);
					this.SendPropertyChanging();
					this._CRN = value;
					this.SendPropertyChanged("CRN");
					this.OnCRNChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CourseType", DbType="NVarChar(10) NOT NULL", CanBeNull=false)]
		public string CourseType
		{
			get
			{
				return this._CourseType;
			}
			set
			{
				if ((this._CourseType != value))
				{
					this.OnCourseTypeChanging(value);
					this.SendPropertyChanging();
					this._CourseType = value;
					this.SendPropertyChanged("CourseType");
					this.OnCourseTypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CourseDay", DbType="NVarChar(10) NOT NULL", CanBeNull=false)]
		public string CourseDay
		{
			get
			{
				return this._CourseDay;
			}
			set
			{
				if ((this._CourseDay != value))
				{
					this.OnCourseDayChanging(value);
					this.SendPropertyChanging();
					this._CourseDay = value;
					this.SendPropertyChanged("CourseDay");
					this.OnCourseDayChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CourseTime", DbType="NVarChar(20) NOT NULL", CanBeNull=false)]
		public string CourseTime
		{
			get
			{
				return this._CourseTime;
			}
			set
			{
				if ((this._CourseTime != value))
				{
					this.OnCourseTimeChanging(value);
					this.SendPropertyChanging();
					this._CourseTime = value;
					this.SendPropertyChanged("CourseTime");
					this.OnCourseTimeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ClassSize", DbType="SmallInt NOT NULL")]
		public short ClassSize
		{
			get
			{
				return this._ClassSize;
			}
			set
			{
				if ((this._ClassSize != value))
				{
					this.OnClassSizeChanging(value);
					this.SendPropertyChanging();
					this._ClassSize = value;
					this.SendPropertyChanged("ClassSize");
					this.OnClassSizeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Course_Waitlist", Storage="_Waitlists", ThisKey="CID", OtherKey="CID")]
		public EntitySet<Waitlist> Waitlists
		{
			get
			{
				return this._Waitlists;
			}
			set
			{
				this._Waitlists.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Course_Registration", Storage="_Registrations", ThisKey="CID", OtherKey="CID")]
		public EntitySet<Registration> Registrations
		{
			get
			{
				return this._Registrations;
			}
			set
			{
				this._Registrations.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Waitlists(Waitlist entity)
		{
			this.SendPropertyChanging();
			entity.Course = this;
		}
		
		private void detach_Waitlists(Waitlist entity)
		{
			this.SendPropertyChanging();
			entity.Course = null;
		}
		
		private void attach_Registrations(Registration entity)
		{
			this.SendPropertyChanging();
			entity.Course = this;
		}
		
		private void detach_Registrations(Registration entity)
		{
			this.SendPropertyChanging();
			entity.Course = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Waitlist")]
	public partial class Waitlist : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _SID;
		
		private int _CID;
		
		private EntityRef<Course> _Course;
		
		private EntityRef<Student> _Student;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnSIDChanging(int value);
    partial void OnSIDChanged();
    partial void OnCIDChanging(int value);
    partial void OnCIDChanged();
    #endregion
		
		public Waitlist()
		{
			this._Course = default(EntityRef<Course>);
			this._Student = default(EntityRef<Student>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int SID
		{
			get
			{
				return this._SID;
			}
			set
			{
				if ((this._SID != value))
				{
					if (this._Student.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnSIDChanging(value);
					this.SendPropertyChanging();
					this._SID = value;
					this.SendPropertyChanged("SID");
					this.OnSIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int CID
		{
			get
			{
				return this._CID;
			}
			set
			{
				if ((this._CID != value))
				{
					if (this._Course.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnCIDChanging(value);
					this.SendPropertyChanging();
					this._CID = value;
					this.SendPropertyChanged("CID");
					this.OnCIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Course_Waitlist", Storage="_Course", ThisKey="CID", OtherKey="CID", IsForeignKey=true)]
		public Course Course
		{
			get
			{
				return this._Course.Entity;
			}
			set
			{
				Course previousValue = this._Course.Entity;
				if (((previousValue != value) 
							|| (this._Course.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Course.Entity = null;
						previousValue.Waitlists.Remove(this);
					}
					this._Course.Entity = value;
					if ((value != null))
					{
						value.Waitlists.Add(this);
						this._CID = value.CID;
					}
					else
					{
						this._CID = default(int);
					}
					this.SendPropertyChanged("Course");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Student_Waitlist", Storage="_Student", ThisKey="SID", OtherKey="SID", IsForeignKey=true)]
		public Student Student
		{
			get
			{
				return this._Student.Entity;
			}
			set
			{
				Student previousValue = this._Student.Entity;
				if (((previousValue != value) 
							|| (this._Student.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Student.Entity = null;
						previousValue.Waitlists.Remove(this);
					}
					this._Student.Entity = value;
					if ((value != null))
					{
						value.Waitlists.Add(this);
						this._SID = value.SID;
					}
					else
					{
						this._SID = default(int);
					}
					this.SendPropertyChanged("Student");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Registration")]
	public partial class Registration : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _SID;
		
		private int _CID;
		
		private EntityRef<Course> _Course;
		
		private EntityRef<Student> _Student;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnSIDChanging(int value);
    partial void OnSIDChanged();
    partial void OnCIDChanging(int value);
    partial void OnCIDChanged();
    #endregion
		
		public Registration()
		{
			this._Course = default(EntityRef<Course>);
			this._Student = default(EntityRef<Student>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int SID
		{
			get
			{
				return this._SID;
			}
			set
			{
				if ((this._SID != value))
				{
					if (this._Student.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnSIDChanging(value);
					this.SendPropertyChanging();
					this._SID = value;
					this.SendPropertyChanged("SID");
					this.OnSIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int CID
		{
			get
			{
				return this._CID;
			}
			set
			{
				if ((this._CID != value))
				{
					if (this._Course.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnCIDChanging(value);
					this.SendPropertyChanging();
					this._CID = value;
					this.SendPropertyChanged("CID");
					this.OnCIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Course_Registration", Storage="_Course", ThisKey="CID", OtherKey="CID", IsForeignKey=true)]
		public Course Course
		{
			get
			{
				return this._Course.Entity;
			}
			set
			{
				Course previousValue = this._Course.Entity;
				if (((previousValue != value) 
							|| (this._Course.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Course.Entity = null;
						previousValue.Registrations.Remove(this);
					}
					this._Course.Entity = value;
					if ((value != null))
					{
						value.Registrations.Add(this);
						this._CID = value.CID;
					}
					else
					{
						this._CID = default(int);
					}
					this.SendPropertyChanged("Course");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Student_Registration", Storage="_Student", ThisKey="SID", OtherKey="SID", IsForeignKey=true)]
		public Student Student
		{
			get
			{
				return this._Student.Entity;
			}
			set
			{
				Student previousValue = this._Student.Entity;
				if (((previousValue != value) 
							|| (this._Student.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Student.Entity = null;
						previousValue.Registrations.Remove(this);
					}
					this._Student.Entity = value;
					if ((value != null))
					{
						value.Registrations.Add(this);
						this._SID = value.SID;
					}
					else
					{
						this._SID = default(int);
					}
					this.SendPropertyChanged("Student");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Student")]
	public partial class Student : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _SID;
		
		private string _LastName;
		
		private string _FirstName;
		
		private string _Email;
		
		private EntitySet<Waitlist> _Waitlists;
		
		private EntitySet<Registration> _Registrations;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnSIDChanging(int value);
    partial void OnSIDChanged();
    partial void OnLastNameChanging(string value);
    partial void OnLastNameChanged();
    partial void OnFirstNameChanging(string value);
    partial void OnFirstNameChanged();
    partial void OnEmailChanging(string value);
    partial void OnEmailChanged();
    #endregion
		
		public Student()
		{
			this._Waitlists = new EntitySet<Waitlist>(new Action<Waitlist>(this.attach_Waitlists), new Action<Waitlist>(this.detach_Waitlists));
			this._Registrations = new EntitySet<Registration>(new Action<Registration>(this.attach_Registrations), new Action<Registration>(this.detach_Registrations));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int SID
		{
			get
			{
				return this._SID;
			}
			set
			{
				if ((this._SID != value))
				{
					this.OnSIDChanging(value);
					this.SendPropertyChanging();
					this._SID = value;
					this.SendPropertyChanged("SID");
					this.OnSIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastName", DbType="NVarChar(64) NOT NULL", CanBeNull=false)]
		public string LastName
		{
			get
			{
				return this._LastName;
			}
			set
			{
				if ((this._LastName != value))
				{
					this.OnLastNameChanging(value);
					this.SendPropertyChanging();
					this._LastName = value;
					this.SendPropertyChanged("LastName");
					this.OnLastNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FirstName", DbType="NVarChar(64) NOT NULL", CanBeNull=false)]
		public string FirstName
		{
			get
			{
				return this._FirstName;
			}
			set
			{
				if ((this._FirstName != value))
				{
					this.OnFirstNameChanging(value);
					this.SendPropertyChanging();
					this._FirstName = value;
					this.SendPropertyChanged("FirstName");
					this.OnFirstNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Email", DbType="NVarChar(64) NOT NULL", CanBeNull=false)]
		public string Email
		{
			get
			{
				return this._Email;
			}
			set
			{
				if ((this._Email != value))
				{
					this.OnEmailChanging(value);
					this.SendPropertyChanging();
					this._Email = value;
					this.SendPropertyChanged("Email");
					this.OnEmailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Student_Waitlist", Storage="_Waitlists", ThisKey="SID", OtherKey="SID")]
		public EntitySet<Waitlist> Waitlists
		{
			get
			{
				return this._Waitlists;
			}
			set
			{
				this._Waitlists.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Student_Registration", Storage="_Registrations", ThisKey="SID", OtherKey="SID")]
		public EntitySet<Registration> Registrations
		{
			get
			{
				return this._Registrations;
			}
			set
			{
				this._Registrations.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Waitlists(Waitlist entity)
		{
			this.SendPropertyChanging();
			entity.Student = this;
		}
		
		private void detach_Waitlists(Waitlist entity)
		{
			this.SendPropertyChanging();
			entity.Student = null;
		}
		
		private void attach_Registrations(Registration entity)
		{
			this.SendPropertyChanging();
			entity.Student = this;
		}
		
		private void detach_Registrations(Registration entity)
		{
			this.SendPropertyChanging();
			entity.Student = null;
		}
	}
}
#pragma warning restore 1591
