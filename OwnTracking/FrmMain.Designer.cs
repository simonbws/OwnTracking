namespace OwnTracking
{
    partial class FrmMain
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
            this.btnPosition = new System.Windows.Forms.Button();
            this.btnDepartment = new System.Windows.Forms.Button();
            this.btnPermission = new System.Windows.Forms.Button();
            this.btnSalary = new System.Windows.Forms.Button();
            this.btnTask = new System.Windows.Forms.Button();
            this.btnEmployee = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPosition
            // 
            this.btnPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnPosition.Image = global::OwnTracking.Properties.Resources.position;
            this.btnPosition.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPosition.Location = new System.Drawing.Point(503, 297);
            this.btnPosition.Name = "btnPosition";
            this.btnPosition.Size = new System.Drawing.Size(232, 216);
            this.btnPosition.TabIndex = 4;
            this.btnPosition.Text = "Position";
            this.btnPosition.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPosition.UseVisualStyleBackColor = true;
            this.btnPosition.Click += new System.EventHandler(this.btnPosition_Click);
            // 
            // btnDepartment
            // 
            this.btnDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDepartment.Image = global::OwnTracking.Properties.Resources.organization2;
            this.btnDepartment.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDepartment.Location = new System.Drawing.Point(94, 223);
            this.btnDepartment.Name = "btnDepartment";
            this.btnDepartment.Size = new System.Drawing.Size(229, 290);
            this.btnDepartment.TabIndex = 3;
            this.btnDepartment.Text = "Department";
            this.btnDepartment.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDepartment.UseVisualStyleBackColor = true;
            this.btnDepartment.Click += new System.EventHandler(this.btnDepartment_Click);
            // 
            // btnPermission
            // 
            this.btnPermission.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnPermission.Image = global::OwnTracking.Properties.Resources.permission;
            this.btnPermission.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPermission.Location = new System.Drawing.Point(941, 297);
            this.btnPermission.Name = "btnPermission";
            this.btnPermission.Size = new System.Drawing.Size(240, 216);
            this.btnPermission.TabIndex = 5;
            this.btnPermission.Text = "Permission";
            this.btnPermission.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPermission.UseVisualStyleBackColor = true;
            this.btnPermission.Click += new System.EventHandler(this.btnPermission_Click);
            // 
            // btnSalary
            // 
            this.btnSalary.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSalary.Image = global::OwnTracking.Properties.Resources.givemoney;
            this.btnSalary.Location = new System.Drawing.Point(934, 3);
            this.btnSalary.Name = "btnSalary";
            this.btnSalary.Size = new System.Drawing.Size(247, 242);
            this.btnSalary.TabIndex = 2;
            this.btnSalary.Text = "Salary";
            this.btnSalary.UseVisualStyleBackColor = true;
            this.btnSalary.Click += new System.EventHandler(this.btnSalary_Click);
            // 
            // btnTask
            // 
            this.btnTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnTask.Image = global::OwnTracking.Properties.Resources.homeoffice1;
            this.btnTask.Location = new System.Drawing.Point(503, 3);
            this.btnTask.Name = "btnTask";
            this.btnTask.Size = new System.Drawing.Size(232, 242);
            this.btnTask.TabIndex = 1;
            this.btnTask.Text = "Tasks";
            this.btnTask.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnTask.UseVisualStyleBackColor = true;
            this.btnTask.Click += new System.EventHandler(this.btnTask_Click);
            // 
            // btnEmployee
            // 
            this.btnEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnEmployee.Image = global::OwnTracking.Properties.Resources.mngmt;
            this.btnEmployee.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEmployee.Location = new System.Drawing.Point(94, 3);
            this.btnEmployee.Name = "btnEmployee";
            this.btnEmployee.Size = new System.Drawing.Size(229, 214);
            this.btnEmployee.TabIndex = 0;
            this.btnEmployee.Text = "Employee";
            this.btnEmployee.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEmployee.UseVisualStyleBackColor = true;
            this.btnEmployee.Click += new System.EventHandler(this.btnEmployee_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnLogOut.Image = global::OwnTracking.Properties.Resources.logout;
            this.btnLogOut.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLogOut.Location = new System.Drawing.Point(94, 519);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(230, 227);
            this.btnLogOut.TabIndex = 6;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnExit.Image = global::OwnTracking.Properties.Resources.exit;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExit.Location = new System.Drawing.Point(941, 519);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(240, 228);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Exit";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1215, 781);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.btnPosition);
            this.Controls.Add(this.btnDepartment);
            this.Controls.Add(this.btnPermission);
            this.Controls.Add(this.btnSalary);
            this.Controls.Add(this.btnTask);
            this.Controls.Add(this.btnEmployee);
            this.Name = "FrmMain";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEmployee;
        private System.Windows.Forms.Button btnTask;
        private System.Windows.Forms.Button btnSalary;
        private System.Windows.Forms.Button btnPermission;
        private System.Windows.Forms.Button btnDepartment;
        private System.Windows.Forms.Button btnPosition;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button btnExit;
    }
}