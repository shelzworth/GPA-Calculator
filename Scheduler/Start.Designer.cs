using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Scheduler
{
    partial class Start
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lbl_MenuTitle = new Label();
            btn_Scheduler = new Button();
            btn_GPA = new Button();
            SuspendLayout();
            // 
            // lbl_MenuTitle
            // 
            lbl_MenuTitle.AutoSize = true;
            lbl_MenuTitle.BackColor = Color.Transparent;
            lbl_MenuTitle.Font = new Font("Verdana", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_MenuTitle.ForeColor = Color.WhiteSmoke;
            lbl_MenuTitle.Location = new Point(45, 144);
            lbl_MenuTitle.Name = "lbl_MenuTitle";
            lbl_MenuTitle.Size = new Size(743, 59);
            lbl_MenuTitle.TabIndex = 0;
            lbl_MenuTitle.Text = "Scheduler and GPA Calculator";
            lbl_MenuTitle.Click += label1_Click;
            // 
            // btn_Scheduler
            // 
            btn_Scheduler.BackColor = Color.WhiteSmoke;
            btn_Scheduler.FlatStyle = FlatStyle.Popup;
            btn_Scheduler.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_Scheduler.Location = new Point(148, 266);
            btn_Scheduler.Name = "btn_Scheduler";
            btn_Scheduler.Size = new Size(120, 35);
            btn_Scheduler.TabIndex = 1;
            btn_Scheduler.Text = "Scheduler";
            btn_Scheduler.UseVisualStyleBackColor = false;
            btn_Scheduler.Click += button1_Click;
            // 
            // btn_GPA
            // 
            btn_GPA.BackColor = Color.WhiteSmoke;
            btn_GPA.FlatStyle = FlatStyle.Popup;
            btn_GPA.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_GPA.Location = new Point(539, 266);
            btn_GPA.Name = "btn_GPA";
            btn_GPA.Size = new Size(144, 35);
            btn_GPA.TabIndex = 2;
            btn_GPA.Text = "GPA Calculator";
            btn_GPA.UseVisualStyleBackColor = false;
            btn_GPA.Click += button2_Click;
            // 
            // Start
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveCaption;
            BackgroundImage = Properties.Resources.bg;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(865, 446);
            Controls.Add(btn_GPA);
            Controls.Add(btn_Scheduler);
            Controls.Add(lbl_MenuTitle);
            Name = "Start";
            Text = "Menu";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_MenuTitle;
        private Button btn_Scheduler;
        private Button btn_GPA;
    }
}
