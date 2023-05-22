
namespace MySqlUsersElo2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.tbxID = new System.Windows.Forms.TextBox();
            this.tbxNev = new System.Windows.Forms.TextBox();
            this.tbxJelszo = new System.Windows.Forms.TextBox();
            this.cbxAdmin = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnConn = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnRead = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbxID
            // 
            this.tbxID.Location = new System.Drawing.Point(48, 35);
            this.tbxID.Name = "tbxID";
            this.tbxID.Size = new System.Drawing.Size(100, 20);
            this.tbxID.TabIndex = 0;
            // 
            // tbxNev
            // 
            this.tbxNev.Location = new System.Drawing.Point(48, 103);
            this.tbxNev.Name = "tbxNev";
            this.tbxNev.Size = new System.Drawing.Size(100, 20);
            this.tbxNev.TabIndex = 0;
            // 
            // tbxJelszo
            // 
            this.tbxJelszo.Location = new System.Drawing.Point(48, 171);
            this.tbxJelszo.Name = "tbxJelszo";
            this.tbxJelszo.Size = new System.Drawing.Size(100, 20);
            this.tbxJelszo.TabIndex = 0;
            // 
            // cbxAdmin
            // 
            this.cbxAdmin.AutoSize = true;
            this.cbxAdmin.Location = new System.Drawing.Point(48, 231);
            this.cbxAdmin.Name = "cbxAdmin";
            this.cbxAdmin.Size = new System.Drawing.Size(61, 17);
            this.cbxAdmin.TabIndex = 1;
            this.cbxAdmin.Text = "Admin?";
            this.cbxAdmin.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Azonosító";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Név";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Jelszó";
            // 
            // btnConn
            // 
            this.btnConn.Location = new System.Drawing.Point(209, 31);
            this.btnConn.Name = "btnConn";
            this.btnConn.Size = new System.Drawing.Size(115, 23);
            this.btnConn.TabIndex = 5;
            this.btnConn.Text = "Kapcsolódás";
            this.btnConn.UseVisualStyleBackColor = true;
            this.btnConn.Click += new System.EventHandler(this.btnConn_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(209, 88);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(115, 23);
            this.btnOpen.TabIndex = 5;
            this.btnOpen.Text = "Megnyitás olvasásra";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(209, 145);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(115, 23);
            this.btnRead.TabIndex = 5;
            this.btnRead.Text = "Olvas";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(209, 202);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(115, 23);
            this.btnInsert.TabIndex = 5;
            this.btnInsert.Text = "Beszúrás";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(209, 259);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(115, 23);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "Módosítás kezdés";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(209, 316);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(115, 23);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Törlés";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(51, 316);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(115, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Kapcsolat bontása";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 450);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnConn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxAdmin);
            this.Controls.Add(this.tbxJelszo);
            this.Controls.Add(this.tbxNev);
            this.Controls.Add(this.tbxID);
            this.Name = "Form1";
            this.Text = "MySQL élő kapcsolat demó";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxID;
        private System.Windows.Forms.TextBox tbxNev;
        private System.Windows.Forms.TextBox tbxJelszo;
        private System.Windows.Forms.CheckBox cbxAdmin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnConn;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClose;
    }
}

