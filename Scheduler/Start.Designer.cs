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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(Start));
            lbl_MenuTitle = new Label();
            btn_GPA = new Button();
            label1 = new Label();
            label2 = new Label();
            btnGithub = new Button();
            btnLinkedin = new Button();
            SuspendLayout();
            // 
            // lbl_MenuTitle
            // 
            lbl_MenuTitle.AutoSize = true;
            lbl_MenuTitle.BackColor = Color.Transparent;
            lbl_MenuTitle.Font = new Font("Verdana", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_MenuTitle.ForeColor = Color.WhiteSmoke;
            lbl_MenuTitle.Location = new Point(12, 9);
            lbl_MenuTitle.Name = "lbl_MenuTitle";
            lbl_MenuTitle.Size = new Size(743, 59);
            lbl_MenuTitle.TabIndex = 0;
            lbl_MenuTitle.Text = "Scheduler and GPA Calculator";
            lbl_MenuTitle.Click += label1_Click;
            // 
            // btn_GPA
            // 
            btn_GPA.BackColor = Color.FromArgb(192, 255, 192);
            btn_GPA.FlatStyle = FlatStyle.Popup;
            btn_GPA.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_GPA.Location = new Point(311, 96);
            btn_GPA.Name = "btn_GPA";
            btn_GPA.Size = new Size(144, 35);
            btn_GPA.TabIndex = 2;
            btn_GPA.Text = "GPA Calculator";
            btn_GPA.UseVisualStyleBackColor = false;
            btn_GPA.Click += button2_Click;
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Verdana", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DarkTurquoise;
            label1.Location = new Point(49, 167);
            label1.Name = "label1";
            label1.Size = new Size(674, 205);
            label1.TabIndex = 3;
            label1.Text = resources.GetString("label1.Text");
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Verdana", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Red;
            label2.Location = new Point(12, 133);
            label2.Name = "label2";
            label2.Size = new Size(188, 25);
            label2.TabIndex = 4;
            label2.Text = "Developer Notes";
            // 
            // btnGithub
            // 
            btnGithub.BackColor = Color.MidnightBlue;
            btnGithub.FlatStyle = FlatStyle.Popup;
            btnGithub.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnGithub.ForeColor = Color.White;
            btnGithub.Location = new Point(25, 386);
            btnGithub.Name = "btnGithub";
            btnGithub.Size = new Size(144, 35);
            btnGithub.TabIndex = 5;
            btnGithub.Text = "GitHub";
            btnGithub.UseVisualStyleBackColor = false;
            btnGithub.Click += btnGithub_Click;
            // 
            // btnLinkedin
            // 
            btnLinkedin.BackColor = Color.White;
            btnLinkedin.FlatStyle = FlatStyle.Popup;
            btnLinkedin.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLinkedin.Location = new Point(611, 386);
            btnLinkedin.Name = "btnLinkedin";
            btnLinkedin.Size = new Size(144, 35);
            btnLinkedin.TabIndex = 6;
            btnLinkedin.Text = "LinkedIn";
            btnLinkedin.UseVisualStyleBackColor = false;
            btnLinkedin.Click += btnLinkedin_Click;
            // 
            // Start
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(50, 48, 49);
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(784, 468);
            Controls.Add(btnLinkedin);
            Controls.Add(btnGithub);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btn_GPA);
            Controls.Add(lbl_MenuTitle);
            Name = "Start";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Menu";
            Load += Start_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Label1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private Label lbl_MenuTitle;
        private Button btn_GPA;
        private Label label1;
        private Label label2;
        private Button btnGithub;
        private Button btnLinkedin;
    }
}
