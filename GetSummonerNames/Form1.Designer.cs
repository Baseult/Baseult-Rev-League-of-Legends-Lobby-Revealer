using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using GetSummonerNames.Properties;

namespace GetSummonerNames
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.linkLabel4 = new System.Windows.Forms.LinkLabel();
            this.linkLabel5 = new System.Windows.Forms.LinkLabel();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.statbox = new System.Windows.Forms.ComboBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.button2.Enabled = false;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Cyan;
            this.button2.Location = new System.Drawing.Point(23, 82);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(116, 28);
            this.button2.TabIndex = 2;
            this.button2.Text = "MULTI SEARCH";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.button3.Enabled = false;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.Red;
            this.button3.Location = new System.Drawing.Point(292, 82);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(118, 28);
            this.button3.TabIndex = 3;
            this.button3.Text = "DODGE";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.ForeColor = System.Drawing.Color.Lime;
            this.label1.Location = new System.Drawing.Point(23, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(386, 27);
            this.label1.TabIndex = 4;
            this.label1.Text = "Waiting...";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // linkLabel1
            // 
            this.linkLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.linkLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.linkLabel1.DisabledLinkColor = System.Drawing.Color.DarkGray;
            this.linkLabel1.Enabled = false;
            this.linkLabel1.ForeColor = System.Drawing.Color.Cyan;
            this.linkLabel1.LinkColor = System.Drawing.Color.Aqua;
            this.linkLabel1.Location = new System.Drawing.Point(29, 171);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(375, 21);
            this.linkLabel1.TabIndex = 5;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "PLAYER 1";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.linkLabel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.linkLabel2.DisabledLinkColor = System.Drawing.Color.DarkGray;
            this.linkLabel2.Enabled = false;
            this.linkLabel2.ForeColor = System.Drawing.Color.Cyan;
            this.linkLabel2.LinkColor = System.Drawing.Color.Aqua;
            this.linkLabel2.Location = new System.Drawing.Point(29, 203);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(375, 21);
            this.linkLabel2.TabIndex = 6;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "PLAYER 2";
            this.linkLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // linkLabel3
            // 
            this.linkLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.linkLabel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.linkLabel3.DisabledLinkColor = System.Drawing.Color.DarkGray;
            this.linkLabel3.Enabled = false;
            this.linkLabel3.ForeColor = System.Drawing.Color.Cyan;
            this.linkLabel3.LinkColor = System.Drawing.Color.Aqua;
            this.linkLabel3.Location = new System.Drawing.Point(29, 235);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(375, 21);
            this.linkLabel3.TabIndex = 7;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "PLAYER 3";
            this.linkLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // linkLabel4
            // 
            this.linkLabel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.linkLabel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.linkLabel4.DisabledLinkColor = System.Drawing.Color.DarkGray;
            this.linkLabel4.Enabled = false;
            this.linkLabel4.ForeColor = System.Drawing.Color.Cyan;
            this.linkLabel4.LinkColor = System.Drawing.Color.Aqua;
            this.linkLabel4.Location = new System.Drawing.Point(29, 267);
            this.linkLabel4.Name = "linkLabel4";
            this.linkLabel4.Size = new System.Drawing.Size(375, 21);
            this.linkLabel4.TabIndex = 8;
            this.linkLabel4.TabStop = true;
            this.linkLabel4.Text = "PLAYER 4";
            this.linkLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkLabel4.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel4_LinkClicked);
            // 
            // linkLabel5
            // 
            this.linkLabel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.linkLabel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.linkLabel5.DisabledLinkColor = System.Drawing.Color.DarkGray;
            this.linkLabel5.Enabled = false;
            this.linkLabel5.ForeColor = System.Drawing.Color.Cyan;
            this.linkLabel5.LinkColor = System.Drawing.Color.Aqua;
            this.linkLabel5.Location = new System.Drawing.Point(29, 299);
            this.linkLabel5.Name = "linkLabel5";
            this.linkLabel5.Size = new System.Drawing.Size(375, 21);
            this.linkLabel5.TabIndex = 9;
            this.linkLabel5.TabStop = true;
            this.linkLabel5.Text = "PLAYER 5";
            this.linkLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkLabel5.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel5_LinkClicked);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button4.Location = new System.Drawing.Point(23, 344);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(180, 26);
            this.button4.TabIndex = 10;
            this.button4.Text = "MINIMIZE";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.ForeColor = System.Drawing.Color.Red;
            this.button5.Location = new System.Drawing.Point(229, 344);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(181, 26);
            this.button5.TabIndex = 11;
            this.button5.Text = "CLOSE";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // statbox
            // 
            this.statbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));


            this.statbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.statbox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.statbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statbox.ForeColor = System.Drawing.Color.Cyan;
            this.statbox.FormattingEnabled = true;
            this.statbox.Items.AddRange(new object[] {
            "DEEPLOL",
            "TRACKER",
            "U.GG",
            "OP.GG",
            "PORO.GG"});
            this.statbox.Location = new System.Drawing.Point(157, 82);
            this.statbox.Name = "statbox";
            this.statbox.Size = new System.Drawing.Size(117, 28);
            this.statbox.TabIndex = 12;

            this.statbox.Text = "OP.GG";


            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));

            this.BackgroundImage = global::GetSummonerNames.Properties.Resources.offx;
            //this.BackgroundImage = global::GetSummonerNames.Properties.Resources.off3;

            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(430, 385);
            this.Controls.Add(this.statbox);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.linkLabel5);
            this.Controls.Add(this.linkLabel4);
            this.Controls.Add(this.linkLabel3);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lobby Names - Baseult";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.ResumeLayout(false);

        }

        #endregion
        private Button button2;
        private Button button3;
        private Label label1;
        private LinkLabel linkLabel1;
        private LinkLabel linkLabel2;
        private LinkLabel linkLabel3;
        private LinkLabel linkLabel4;
        private LinkLabel linkLabel5;
        private Button button4;
        private Button button5;
        private ComboBox statbox;
        private BackgroundWorker backgroundWorker1;
    }
}

