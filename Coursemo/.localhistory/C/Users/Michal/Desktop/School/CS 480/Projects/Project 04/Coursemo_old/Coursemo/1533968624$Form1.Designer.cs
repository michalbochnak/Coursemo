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
      this.SuspendLayout();
      // 
      // StudentsListBox
      // 
      this.StudentsListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.StudentsListBox.FormattingEnabled = true;
      this.StudentsListBox.ItemHeight = 16;
      this.StudentsListBox.Location = new System.Drawing.Point(13, 41);
      this.StudentsListBox.Name = "StudentsListBox";
      this.StudentsListBox.Size = new System.Drawing.Size(250, 276);
      this.StudentsListBox.TabIndex = 0;
      this.StudentsListBox.SelectedIndexChanged += new System.EventHandler(this.StudentsListBox_SelectedIndexChanged);
      // 
      // CoursesListBox
      // 
      this.CoursesListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.CoursesListBox.FormattingEnabled = true;
      this.CoursesListBox.ItemHeight = 16;
      this.CoursesListBox.Location = new System.Drawing.Point(288, 41);
      this.CoursesListBox.Name = "CoursesListBox";
      this.CoursesListBox.Size = new System.Drawing.Size(254, 276);
      this.CoursesListBox.TabIndex = 1;
      this.CoursesListBox.SelectedIndexChanged += new System.EventHandler(this.CoursesListBox_SelectedIndexChanged);
      // 
      // EnrolledInListBox
      // 
      this.EnrolledInListBox.FormattingEnabled = true;
      this.EnrolledInListBox.Location = new System.Drawing.Point(13, 381);
      this.EnrolledInListBox.Name = "EnrolledInListBox";
      this.EnrolledInListBox.Size = new System.Drawing.Size(250, 264);
      this.EnrolledInListBox.TabIndex = 2;
      // 
      // EnrollButton
      // 
      this.EnrollButton.Location = new System.Drawing.Point(559, 41);
      this.EnrollButton.Name = "EnrollButton";
      this.EnrollButton.Size = new System.Drawing.Size(75, 23);
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
      this.InfoLabel.Location = new System.Drawing.Point(194, 701);
      this.InfoLabel.Name = "InfoLabel";
      this.InfoLabel.Size = new System.Drawing.Size(57, 20);
      this.InfoLabel.TabIndex = 4;
      this.InfoLabel.Text = "label1";
      // 
      // EnrolledInLlabel
      // 
      this.EnrolledInLlabel.AutoSize = true;
      this.EnrolledInLlabel.Location = new System.Drawing.Point(86, 362);
      this.EnrolledInLlabel.Name = "EnrolledInLlabel";
      this.EnrolledInLlabel.Size = new System.Drawing.Size(56, 13);
      this.EnrolledInLlabel.TabIndex = 5;
      this.EnrolledInLlabel.Text = "Enrolled in";
      // 
      // WaitlistListBox
      // 
      this.WaitlistListBox.FormattingEnabled = true;
      this.WaitlistListBox.Location = new System.Drawing.Point(317, 381);
      this.WaitlistListBox.Name = "WaitlistListBox";
      this.WaitlistListBox.Size = new System.Drawing.Size(225, 264);
      this.WaitlistListBox.TabIndex = 6;
      // 
      // WaitlistLabel
      // 
      this.WaitlistLabel.AutoSize = true;
      this.WaitlistLabel.Location = new System.Drawing.Point(391, 362);
      this.WaitlistLabel.Name = "WaitlistLabel";
      this.WaitlistLabel.Size = new System.Drawing.Size(64, 13);
      this.WaitlistLabel.TabIndex = 7;
      this.WaitlistLabel.Text = "Waitlisted in";
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 777);
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
  }
}

