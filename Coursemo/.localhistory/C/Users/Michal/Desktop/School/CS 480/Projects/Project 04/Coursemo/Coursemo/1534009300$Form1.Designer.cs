﻿using System;
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
      this.NetidTextBox = new System.Windows.Forms.TextBox();
      this.CrnTextBox = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.ResetDatabaseButton = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // StudentsListBox
      // 
      this.StudentsListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.StudentsListBox.FormattingEnabled = true;
      this.StudentsListBox.ItemHeight = 20;
      this.StudentsListBox.Location = new System.Drawing.Point(16, 15);
      this.StudentsListBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.StudentsListBox.Name = "StudentsListBox";
      this.StudentsListBox.Size = new System.Drawing.Size(332, 204);
      this.StudentsListBox.TabIndex = 0;
      this.StudentsListBox.SelectedIndexChanged += new System.EventHandler(this.StudentsListBox_SelectedIndexChanged);
      // 
      // CoursesListBox
      // 
      this.CoursesListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.CoursesListBox.FormattingEnabled = true;
      this.CoursesListBox.ItemHeight = 20;
      this.CoursesListBox.Location = new System.Drawing.Point(383, 15);
      this.CoursesListBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.CoursesListBox.Name = "CoursesListBox";
      this.CoursesListBox.Size = new System.Drawing.Size(199, 204);
      this.CoursesListBox.TabIndex = 1;
      this.CoursesListBox.SelectedIndexChanged += new System.EventHandler(this.CoursesListBox_SelectedIndexChanged);
      // 
      // EnrolledInListBox
      // 
      this.EnrolledInListBox.FormattingEnabled = true;
      this.EnrolledInListBox.ItemHeight = 16;
      this.EnrolledInListBox.Location = new System.Drawing.Point(16, 286);
      this.EnrolledInListBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.EnrolledInListBox.Name = "EnrolledInListBox";
      this.EnrolledInListBox.Size = new System.Drawing.Size(159, 116);
      this.EnrolledInListBox.TabIndex = 2;
      // 
      // EnrollButton
      // 
      this.EnrollButton.Location = new System.Drawing.Point(760, 15);
      this.EnrollButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.EnrollButton.Name = "EnrollButton";
      this.EnrollButton.Size = new System.Drawing.Size(200, 28);
      this.EnrollButton.TabIndex = 3;
      this.EnrollButton.Text = "Enroll";
      this.EnrollButton.UseVisualStyleBackColor = true;
      this.EnrollButton.Click += new System.EventHandler(this.EnrollButton_Click);
      // 
      // InfoLabel
      // 
      this.InfoLabel.AutoSize = true;
      this.InfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.InfoLabel.ForeColor = System.Drawing.Color.LightSeaGreen;
      this.InfoLabel.Location = new System.Drawing.Point(639, 286);
      this.InfoLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.InfoLabel.Name = "InfoLabel";
      this.InfoLabel.Size = new System.Drawing.Size(36, 18);
      this.InfoLabel.TabIndex = 4;
      this.InfoLabel.Text = "Info";
      // 
      // EnrolledInLlabel
      // 
      this.EnrolledInLlabel.AutoSize = true;
      this.EnrolledInLlabel.Location = new System.Drawing.Point(15, 266);
      this.EnrolledInLlabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.EnrolledInLlabel.Name = "EnrolledInLlabel";
      this.EnrolledInLlabel.Size = new System.Drawing.Size(128, 17);
      this.EnrolledInLlabel.TabIndex = 5;
      this.EnrolledInLlabel.Text = "Student Enrolled in";
      // 
      // WaitlistListBox
      // 
      this.WaitlistListBox.FormattingEnabled = true;
      this.WaitlistListBox.ItemHeight = 16;
      this.WaitlistListBox.Location = new System.Drawing.Point(189, 286);
      this.WaitlistListBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.WaitlistListBox.Name = "WaitlistListBox";
      this.WaitlistListBox.Size = new System.Drawing.Size(159, 116);
      this.WaitlistListBox.TabIndex = 6;
      // 
      // WaitlistLabel
      // 
      this.WaitlistLabel.AutoSize = true;
      this.WaitlistLabel.Location = new System.Drawing.Point(195, 266);
      this.WaitlistLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.WaitlistLabel.Name = "WaitlistLabel";
      this.WaitlistLabel.Size = new System.Drawing.Size(137, 17);
      this.WaitlistLabel.TabIndex = 7;
      this.WaitlistLabel.Text = "Student Waitlisted in";
      // 
      // CourseDetailLabel
      // 
      this.CourseDetailLabel.AutoSize = true;
      this.CourseDetailLabel.Location = new System.Drawing.Point(591, 15);
      this.CourseDetailLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.CourseDetailLabel.Name = "CourseDetailLabel";
      this.CourseDetailLabel.Size = new System.Drawing.Size(96, 17);
      this.CourseDetailLabel.TabIndex = 8;
      this.CourseDetailLabel.Text = "CourseDetails";
      // 
      // CourseWaitlistListBox
      // 
      this.CourseWaitlistListBox.FormattingEnabled = true;
      this.CourseWaitlistListBox.ItemHeight = 16;
      this.CourseWaitlistListBox.Location = new System.Drawing.Point(484, 286);
      this.CourseWaitlistListBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.CourseWaitlistListBox.Name = "CourseWaitlistListBox";
      this.CourseWaitlistListBox.Size = new System.Drawing.Size(92, 116);
      this.CourseWaitlistListBox.TabIndex = 9;
      // 
      // CourseWaitlistLabel
      // 
      this.CourseWaitlistLabel.AutoSize = true;
      this.CourseWaitlistLabel.Location = new System.Drawing.Point(480, 266);
      this.CourseWaitlistLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.CourseWaitlistLabel.Name = "CourseWaitlistLabel";
      this.CourseWaitlistLabel.Size = new System.Drawing.Size(53, 17);
      this.CourseWaitlistLabel.TabIndex = 10;
      this.CourseWaitlistLabel.Text = "Waitlist";
      // 
      // CourseEnrollmentListBox
      // 
      this.CourseEnrollmentListBox.FormattingEnabled = true;
      this.CourseEnrollmentListBox.ItemHeight = 16;
      this.CourseEnrollmentListBox.Location = new System.Drawing.Point(383, 286);
      this.CourseEnrollmentListBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.CourseEnrollmentListBox.Name = "CourseEnrollmentListBox";
      this.CourseEnrollmentListBox.Size = new System.Drawing.Size(92, 116);
      this.CourseEnrollmentListBox.TabIndex = 11;
      // 
      // CourseEnrollmentLabel
      // 
      this.CourseEnrollmentLabel.AutoSize = true;
      this.CourseEnrollmentLabel.Location = new System.Drawing.Point(379, 266);
      this.CourseEnrollmentLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.CourseEnrollmentLabel.Name = "CourseEnrollmentLabel";
      this.CourseEnrollmentLabel.Size = new System.Drawing.Size(75, 17);
      this.CourseEnrollmentLabel.TabIndex = 12;
      this.CourseEnrollmentLabel.Text = "Enrollment";
      // 
      // DropButton
      // 
      this.DropButton.Location = new System.Drawing.Point(760, 50);
      this.DropButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.DropButton.Name = "DropButton";
      this.DropButton.Size = new System.Drawing.Size(200, 28);
      this.DropButton.TabIndex = 13;
      this.DropButton.Text = "Drop";
      this.DropButton.UseVisualStyleBackColor = true;
      this.DropButton.Click += new System.EventHandler(this.DropButton_Click);
      // 
      // SwapButton
      // 
      this.SwapButton.Location = new System.Drawing.Point(760, 208);
      this.SwapButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.SwapButton.Name = "SwapButton";
      this.SwapButton.Size = new System.Drawing.Size(200, 28);
      this.SwapButton.TabIndex = 14;
      this.SwapButton.Text = "Swap";
      this.SwapButton.UseVisualStyleBackColor = true;
      this.SwapButton.Click += new System.EventHandler(this.SwapButton_Click);
      // 
      // NetidTextBox
      // 
      this.NetidTextBox.Location = new System.Drawing.Point(760, 176);
      this.NetidTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.NetidTextBox.Name = "NetidTextBox";
      this.NetidTextBox.Size = new System.Drawing.Size(92, 22);
      this.NetidTextBox.TabIndex = 15;
      // 
      // CrnTextBox
      // 
      this.CrnTextBox.Location = new System.Drawing.Point(867, 176);
      this.CrnTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.CrnTextBox.Name = "CrnTextBox";
      this.CrnTextBox.Size = new System.Drawing.Size(92, 22);
      this.CrnTextBox.TabIndex = 16;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(756, 156);
      this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(41, 17);
      this.label1.TabIndex = 17;
      this.label1.Text = "Netid";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(863, 156);
      this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(37, 17);
      this.label2.TabIndex = 18;
      this.label2.Text = "CRN";
      // 
      // ResetDatabaseButton
      // 
      this.ResetDatabaseButton.Location = new System.Drawing.Point(19, 450);
      this.ResetDatabaseButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.ResetDatabaseButton.Name = "ResetDatabaseButton";
      this.ResetDatabaseButton.Size = new System.Drawing.Size(139, 28);
      this.ResetDatabaseButton.TabIndex = 19;
      this.ResetDatabaseButton.Text = "Reset Database";
      this.ResetDatabaseButton.UseVisualStyleBackColor = true;
      this.ResetDatabaseButton.Click += new System.EventHandler(this.ResetDatabaseButton_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(976, 494);
      this.Controls.Add(this.ResetDatabaseButton);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.CrnTextBox);
      this.Controls.Add(this.NetidTextBox);
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
      this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
    private TextBox NetidTextBox;
    private TextBox CrnTextBox;
    private Label label1;
    private Label label2;
    private Button ResetDatabaseButton;
  }
}

