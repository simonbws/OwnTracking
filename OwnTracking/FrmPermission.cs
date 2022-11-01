using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessLayer;
using BusinessLogicLayer;
using DataAccessLayer.DTO;

namespace OwnTracking
{
    public partial class FrmPermission : Form
    {
        public FrmPermission()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        TimeSpan PermissionDay;
        public bool isUpdated = false;
        public PermissionDetailDTO property = new PermissionDetailDTO();
        private void FrmPermission_Load(object sender, EventArgs e)
        {
            //show user number in text .
            txtUserNo.Text = UserStaticClass.UserNumber.ToString();
            if (isUpdated)
            {
                dpStart.Value = property.StartDate;
                dpEnd.Value = property.EndDate;
                txtDayAmount.Text = property.PermissionDayAmount.ToString();
                txtUserNo.Text = property.UserNumber.ToString();
                txtExplanation.Text = property.Explanation;

            }
        }

        private void dpStart_ValueChanged(object sender, EventArgs e)
        {
            PermissionDay = dpEnd.Value.Date - dpStart.Value.Date;
            txtDayAmount.Text = PermissionDay.TotalDays.ToString();
        }

        private void dpEnd_ValueChanged(object sender, EventArgs e)
        {
            PermissionDay = dpEnd.Value.Date - dpStart.Value.Date;
            txtDayAmount.Text = PermissionDay.TotalDays.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtDayAmount.Text.Trim() == "")
            {
                MessageBox.Show("Please change End or Start Date");
            }
            else if (Convert.ToInt32(txtDayAmount.Text) <= 0)
            {
                MessageBox.Show("Permission day must be greater than 0");
            }
            else if (txtExplanation.Text.Trim() == "")
            {
                MessageBox.Show("Explanation is empty");
            }
            else
            {
                PERMISSION permission = new PERMISSION();
                if (!isUpdated)
                {
                    permission.EmployeeID = UserStaticClass.EmployeeID;
                    permission.PermissionState = 1;
                    permission.PermissionStartDate = dpStart.Value.Date;
                    permission.PermissionEndDate = dpEnd.Value.Date;
                    permission.PermissionDay = Convert.ToInt32(txtDayAmount.Text);
                    permission.PermissionExplanation = txtExplanation.Text;
                    PermissionBLL.AddPermission(permission);
                    MessageBox.Show("Permission has been implemented");
                    permission = new PERMISSION();
                    dpStart.Value = DateTime.Today;
                    dpEnd.Value = DateTime.Today;
                    txtDayAmount.Clear();
                    txtExplanation.Clear();
                }
                else if (isUpdated)
                {
                    //we have to ask the user if they are sure about updating
                    DialogResult result = MessageBox.Show("Do you want to update?", "Warning",
                        MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        permission.ID = property.PermissionID;
                        permission.PermissionExplanation = txtExplanation.Text;
                        permission.PermissionStartDate = dpStart.Value;
                        permission.PermissionEndDate = dpEnd.Value;
                        permission.PermissionDay = Convert.ToInt32(txtDayAmount.Text);
                        PermissionBLL.UpdatePermission(permission);
                        //after update we need to give message
                        MessageBox.Show("Perimssion updated");
                        //and after that, close the page
                        this.Close();
                    }
                }


            }

        }
    }
}
