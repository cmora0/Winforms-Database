namespace BWUsers
{
    partial class form_UserDelete
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnDeleteUserSubmit = new System.Windows.Forms.Button();
            this.btnDeleteUserCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.AllowDrop = true;
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBox1.Location = new System.Drawing.Point(12, 49);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(351, 88);
            this.textBox1.TabIndex = 0;
            this.textBox1.TabStop = false;
            this.textBox1.Text = "This will delete the selected user, this cannot be undone.\r\n\r\nAre you sure you wa" +
    "nt to delete this user?";
            // 
            // textBox2
            // 
            this.textBox2.AllowDrop = true;
            this.textBox2.BackColor = System.Drawing.SystemColors.Control;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBox2.Location = new System.Drawing.Point(12, 12);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(351, 31);
            this.textBox2.TabIndex = 1;
            this.textBox2.TabStop = false;
            this.textBox2.Text = "Warning!";
            // 
            // btnDeleteUserSubmit
            // 
            this.btnDeleteUserSubmit.Location = new System.Drawing.Point(21, 143);
            this.btnDeleteUserSubmit.Name = "btnDeleteUserSubmit";
            this.btnDeleteUserSubmit.Size = new System.Drawing.Size(165, 29);
            this.btnDeleteUserSubmit.TabIndex = 1;
            this.btnDeleteUserSubmit.Text = "Delete User";
            this.btnDeleteUserSubmit.UseVisualStyleBackColor = true;
            this.btnDeleteUserSubmit.Click += new System.EventHandler(this.btnDeleteUserSubmit_Click);
            // 
            // btnDeleteUserCancel
            // 
            this.btnDeleteUserCancel.Location = new System.Drawing.Point(192, 143);
            this.btnDeleteUserCancel.Name = "btnDeleteUserCancel";
            this.btnDeleteUserCancel.Size = new System.Drawing.Size(165, 29);
            this.btnDeleteUserCancel.TabIndex = 2;
            this.btnDeleteUserCancel.Text = "Cancel";
            this.btnDeleteUserCancel.UseVisualStyleBackColor = true;
            this.btnDeleteUserCancel.Click += new System.EventHandler(this.btnDeleteUserCancel_Click);
            // 
            // form_UserDelete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(372, 184);
            this.Controls.Add(this.btnDeleteUserCancel);
            this.Controls.Add(this.btnDeleteUserSubmit);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "form_UserDelete";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Delete User";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnDeleteUserSubmit;
        private System.Windows.Forms.Button btnDeleteUserCancel;
    }
}