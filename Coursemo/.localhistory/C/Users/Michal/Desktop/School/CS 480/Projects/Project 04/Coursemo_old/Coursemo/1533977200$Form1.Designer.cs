using System;
using System.Windows.Forms;
using System.Linq;

namespace Coursemo
{
  partial class Form1
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;
    private CoursemoDataContext db;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.StudentsListBox = new System.Windows.Forms.ListBox();
      this.CoursesListBox = new System.Windows.Forms.ListBox();
      this.EnrolledInListBox = new System.Windows.Forms.ListBox();
      this.EnrollButton = new System.Windows.Forms.Button();
      this.InfoLabel = new System.Windows.Forms.Label();
      this.EnrolledInLlabel = new System.Windows.Forms.Label();
      this.WaitlistListBox = new System.Windows.Forms.ListBox();
      this.WaitlistLabel = new System.Windows.Forms.Label();
      this.CourseDetailLabel = new System.Windows.Forms.Label();
      this.CourseWaitlistListBox = new System.Windows.Forms.ListBox();
      this.CourseWaitlistLabel = new System.Windows.Forms.Label();
      this.CourseEnrollmentListBox = new System.Windows.Forms.ListBox();
      this.CourseEnrollmentLabel = new System.Windows.Forms.Label();
      this.DropButton = new System.Windows.Forms.Button();
      this.SwapButton = new System.Windows.Forms.Button();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.textBox2 = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // StudentsListBox
      // 
      this.StudentsListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.StudentsListBox.FormattingEnabled = true;
      this.StudentsListBox.ItemHeight = 16;
      this.StudentsListBox.Location = new System.Drawing.Point(12, 12);
      this.StudentsListBox.Name = "StudentsListBox";
      this.StudentsListBox.Size = new System.Drawing.Size(250, 180);
      this.StudentsListBox.TabIndex = 0;
      this.StudentsListBox.SelectedIndexChanged += new System.EventHandler(this.StudentsListBox_SelectedIndexChanged);
      // 
      // CoursesListBox
      // 
      this.CoursesListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.CoursesListBox.FormattingEnabled = true;
      this.CoursesListBox.ItemHeight = 16;
      this.CoursesListBox.Location = new System.Drawing.Point(287, 12);
      this.CoursesListBox.Name = "CoursesListBox";
      this.CoursesListBox.Size = new System.Drawing.Size(150, 180);
      this.CoursesListBox.TabIndex = 1;
      this.CoursesListBox.SelectedIndexChanged += new System.EventHandler(this.CoursesListBox_SelectedIndexChanged);
      // 
      // EnrolledInListBox
      // 
      this.EnrolledInListBox.FormattingEnabled = true;
      this.EnrolledInListBox.Location = new System.Drawing.Point(12, 232);
      this.EnrolledInListBox.Name = "EnrolledInListBox";
      this.EnrolledInListBox.Size = new System.Drawing.Size(120, 95);
      this.EnrolledInListBox.TabIndex = 2;
      // 
      // EnrollButton
      // 
      this.EnrollButton.Location = new System.Drawing.Point(570, 12);
      this.EnrollButton.Name = "EnrollButton";
      this.EnrollButton.Size = new System.Drawing.Size(150, 23);
      this.EnrollButton.TabIndex = 3;
      this.EnrollButton.Text = "Enroll";
      this.EnrollButton.UseVisualStyleBackColor = true;
      this.EnrollButton.Click += new System.EventHandler(this.EnrollButton_Click);
      // 
      // InfoLabel
      // 
      this.InfoLabel.AutoSize = true;
      this.InfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.InfoLabel.ForeColor = System.Drawing.Color.Crimson;
      this.InfoLabel.Location = new System.Drawing.Point(663, 307);
      this.InfoLabel.Name = "InfoLabel";
      this.InfoLabel.Size = new System.Drawing.Size(57, 20);
      this.InfoLabel.TabIndex = 4;
      this.InfoLabel.Text = "label1";
      // 
      // EnrolledInLlabel
      // 
      this.EnrolledInLlabel.AutoSize = true;
      this.EnrolledInLlabel.Location = new System.Drawing.Point(11, 216);
      this.EnrolledInLlabel.Name = "EnrolledInLlabel";
      this.EnrolledInLlabel.Size = new System.Drawing.Size(96, 13);
      this.EnrolledInLlabel.TabIndex = 5;
      this.EnrolledInLlabel.Text = "Student Enrolled in";
      // 
      // WaitlistListBox
      // 
      this.WaitlistListBox.FormattingEnabled = true;
      this.WaitlistListBox.Location = new System.Drawing.Point(142, 232);
      this.WaitlistListBox.Name = "WaitlistListBox";
      this.WaitlistListBox.Size = new System.Drawing.Size(120, 95);
      this.WaitlistListBox.TabIndex = 6;
      // 
      // WaitlistLabel
      // 
      this.WaitlistLabel.AutoSize = true;
      this.WaitlistLabel.Location = new System.Drawing.Point(146, 216);
      this.WaitlistLabel.Name = "WaitlistLabel";
      this.WaitlistLabel.Size = new System.Drawing.Size(104, 13);
      this.WaitlistLabel.TabIndex = 7;
      this.WaitlistLabel.Text = "Student Waitlisted in";
      // 
      // CourseDetailLabel
      // 
      this.CourseDetailLabel.AutoSize = true;
      this.CourseDetailLabel.Location = new System.Drawing.Point(443, 12);
      this.CourseDetailLabel.Name = "CourseDetailLabel";
      this.CourseDetailLabel.Size = new System.Drawing.Size(93, 13);
      this.CourseDetailLabel.TabIndex = 8;
      this.CourseDetailLabel.Text = "CourseDetailLabel";
      // 
      // CourseWaitlistListBox
      // 
      this.CourseWaitlistListBox.FormattingEnabled = true;
      this.CourseWaitlistListBox.Location = new System.Drawing.Point(363, 232);
      this.CourseWaitlistListBox.Name = "CourseWaitlistListBox";
      this.CourseWaitlistListBox.Size = new System.Drawing.Size(70, 95);
      this.CourseWaitlistListBox.TabIndex = 9;
      // 
      // CourseWaitlistLabel
      // 
      this.CourseWaitlistLabel.AutoSize = true;
      this.CourseWaitlistLabel.Location = new System.Drawing.Point(360, 216);
      this.CourseWaitlistLabel.Name = "CourseWaitlistLabel";
      this.CourseWaitlistLabel.Size = new System.Drawing.Size(41, 13);
      this.CourseWaitlistLabel.TabIndex = 10;
      this.CourseWaitlistLabel.Text = "Waitlist";
      // 
      // CourseEnrollmentListBox
      // 
      this.CourseEnrollmentListBox.FormattingEnabled = true;
      this.CourseEnrollmentListBox.Location = new System.Drawing.Point(287, 232);
      this.CourseEnrollmentListBox.Name = "CourseEnrollmentListBox";
      this.CourseEnrollmentListBox.Size = new System.Drawing.Size(70, 95);
      this.CourseEnrollmentListBox.TabIndex = 11;
      // 
      // CourseEnrollmentLabel
      // 
      this.CourseEnrollmentLabel.AutoSize = true;
      this.CourseEnrollmentLabel.Location = new System.Drawing.Point(284, 216);
      this.CourseEnrollmentLabel.Name = "CourseEnrollmentLabel";
      this.CourseEnrollmentLabel.Size = new System.Drawing.Size(56, 13);
      this.CourseEnrollmentLabel.TabIndex = 12;
      this.CourseEnrollmentLabel.Text = "Enrollment";
      // 
      // DropButton
      // 
      this.DropButton.Location = new System.Drawing.Point(570, 41);
      this.DropButton.Name = "DropButton";
      this.DropButton.Size = new System.Drawing.Size(150, 23);
      this.DropButton.TabIndex = 13;
      this.DropButton.Text = "Drop";
      this.DropButton.UseVisualStyleBackColor = true;
      this.DropButton.Click += new System.EventHandler(this.DropButton_Click);
      // 
      // SwapButton
      // 
      this.SwapButton.Location = new System.Drawing.Point(570, 169);
      this.SwapButton.Name = "SwapButton";
      this.SwapButton.Size = new System.Drawing.Size(150, 23);
      this.SwapButton.TabIndex = 14;
      this.SwapButton.Text = "Swap";
      this.SwapButton.UseVisualStyleBackColor = true;
      this.SwapButton.Click += new System.EventHandler(this.SwapButton_Click);
      // 
      // textBox1
      // 
      this.textBox1.Location = new System.Drawing.Point(570, 143);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(70, 20);
      this.textBox1.TabIndex = 15;
      // 
      // textBox2
      // 
      this.textBox2.Location = new System.Drawing.Point(650, 143);
      this.textBox2.Name = "textBox2";
      this.textBox2.Size = new System.Drawing.Size(70, 20);
      this.textBox2.TabIndex = 16;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(567, 127);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(32, 13);
      this.label1.TabIndex = 17;
      this.label1.Text = "Netid";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(647, 127);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(30, 13);
      this.label2.TabIndex = 18;
      this.label2.Text = "CRN";
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 777);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.textBox2);
      this.Controls.Add(this.textBox1);
      this.Controls.Add(this.SwapButton);
      this.Controls.Add(this.DropButton);
      this.Controls.Add(this.CourseEnrollmentLabel);
      this.Controls.Add(this.CourseEnrollmentListBox);
      this.Controls.Add(this.CourseWaitlistLabel);
      this.Controls.Add(this.CourseWaitlistListBox);
      this.Controls.Add(this.CourseDetailLabel);
      this.Controls.Add(this.WaitlistLabel);
      this.Controls.Add(this.WaitlistListBox);
      this.Controls.Add(this.EnrolledInLlabel);
      this.Controls.Add(this.InfoLabel);
      this.Controls.Add(this.EnrollButton);
      this.Controls.Add(this.EnrolledInListBox);
      this.Controls.Add(this.CoursesListBox);
      this.Controls.Add(this.StudentsListBox);
      this.Name = "Form1";
      this.Text = "Form1";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ListBox StudentsListBox;
    private ListBox CoursesListBox;
    private ListBox EnrolledInListBox;
    private Button EnrollButton;
    private Label InfoLabel;
    private Label EnrolledInLlabel;
    private ListBox WaitlistListBox;
    private Label WaitlistLabel;
    private Label CourseDetailLabel;
    private ListBox CourseWaitlistListBox;
    private Label CourseWaitlistLabel;
    private ListBox CourseEnrollmentListBox;
    private Label CourseEnrollmentLabel;
    private Button DropButton;
    private Button SwapButton;
    private TextBox textBox1;
    private TextBox textBox2;
    private Label label1;
    private Label label2;
  }
}

