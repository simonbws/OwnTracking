using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessLayer.DTO;
using DataAccessLayer;
using BusinessLogicLayer;
using System.Security.Permissions;

namespace OwnTracking
{
    public partial class FrmPermissionList : Form
    {
        public FrmPermissionList()
        {
            InitializeComponent();
        }

        private void txtUserNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.isNumber(e);
        }

        private void txtDayAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.isNumber(e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmPermission frm = new FrmPermission();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
            SelectAllData();
            CleanFilters();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (properties.PermissionID == 0)
            {
                MessageBox.Show("Please choose a permission from table");

            }
            else
            {
                FrmPermission frm = new FrmPermission();
                frm.isUpdated = true;
                frm.property = properties;
                this.Hide();
                frm.ShowDialog();
                this.Visible = true;
                SelectAllData();
                CleanFilters();
            }
            
        }
        PermissionDTO dto = new PermissionDTO();
        private bool comfobull;
        void SelectAllData()
        {
            dto = PermissionBLL.GetAll();
            //lets show list
            dataGridView1.DataSource = dto.Permissions;
            comfobull = false;
            cmbState.DataSource = dto.Departments;
            cmbState.DisplayMember = "DepartmentName";
            cmbState.ValueMember = "ID";
            cmbPosition.DataSource = dto.Positions;
            cmbPosition.DisplayMember = "PositionName";
            cmbPosition.ValueMember = "id";
            cmbState.SelectedIndex = -1;
            cmbPosition.SelectedIndex = -1;
            comfobull = true;
            cmbState.DataSource = dto.States;
            cmbState.DisplayMember = "StateName";
            cmbState.ValueMember = "ID";
            cmbState.SelectedIndex = -1;
        }


        private void FrmPermissionList_Load(object sender, EventArgs e)
        {
            SelectAllData();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "User Number";
            dataGridView1.Columns[2].HeaderText = "Name";
            dataGridView1.Columns[3].HeaderText = "Surname";
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].HeaderText = "Start Date";
            dataGridView1.Columns[9].HeaderText = "End Date";
            dataGridView1.Columns[10].HeaderText = "Day Amount";
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[11].HeaderText = "State";
            dataGridView1.Columns[13].Visible = false;
            dataGridView1.Columns[14].Visible = false;

            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<PermissionDetailDTO> list = dto.Permissions;
            if (txtUserNo.Text.Trim() != "")
            {
                list = list.Where(x => x.UserNumber == Convert.ToInt32(txtUserNo.Text)).ToList();
            }
            if (txtName.Text.Trim() != "")
            {
                list = list.Where(x => x.Name.Contains(txtName.Text)).ToList();
            }
            if (txtSurname.Text.Trim() != "")
            {
                list = list.Where(x => x.Surname.Contains(txtSurname.Text)).ToList();
            }
            if (cmbDepartment.SelectedIndex == -1)
            {
                list = list.Where(x => x.DepartmentID == Convert.ToInt32(cmbDepartment.SelectedValue)).ToList();
            }
            if (cmbPosition.SelectedIndex == -1)
            {
                list = list.Where(x => x.PositionID == Convert.ToInt32(cmbPosition.SelectedValue)).ToList();
            }
            if (rbStartDate.Checked)
            {
                list=list.Where(x=>x.StartDate < Convert.ToDateTime(dpEnd.Value) &&
                x.StartDate > Convert.ToDateTime(dpStart.Value)).ToList();
            }
            else if (rbEndDate.Checked)
            {
                list = list.Where(x => x.EndDate < Convert.ToDateTime(dpEnd.Value) &&
                x.EndDate > Convert.ToDateTime(dpStart.Value)).ToList();
            }
            if (cmbState.SelectedIndex == -1)
            {
                list = list.Where(x => x.State == Convert.ToInt32(cmbState.SelectedValue)).ToList();
            }
            if (txtDayAmount.Text.Trim() != "")
            {
                list = list.Where(x => x.PermissionDayAmount == Convert.ToInt32(txtDayAmount.Text)).ToList();
            }

            dataGridView1.DataSource = list;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            CleanFilters();
        }

        private void CleanFilters()
        {
            txtUserNo.Clear();
            txtName.Clear();
            txtSurname.Clear();
            comfobull = false;
            cmbDepartment.SelectedIndex = -1;
            cmbPosition.DataSource = dto.Positions;
            cmbPosition.SelectedIndex = -1;
            comfobull = true;
            rbEndDate.Checked = false;
            rbStartDate.Checked = false;
            cmbState.SelectedIndex = -1;
            txtDayAmount.Clear();
            dataGridView1.DataSource = dto.Permissions;
        }
        PermissionDetailDTO properties = new PermissionDetailDTO();
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            properties.PermissionID =
                Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[14].Value);
            properties.StartDate = 
                Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[8].Value);
            properties.EndDate =
               Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[8].Value);
            properties.Explanation = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            properties.UserNumber = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[10].Value);
            properties.State = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[12].Value);
            properties.PermissionDayAmount = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[10].Value);
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            PermissionBLL.UpdatePermission(properties.PermissionID, PermissionAdminStateStatic.Accepted);
            MessageBox.Show("It has been accepted!");
            SelectAllData();
            CleanFilters();
        }

        private void btnUnAccept_Click(object sender, EventArgs e)
        {
            PermissionBLL.UpdatePermission(properties.PermissionID, PermissionAdminStateStatic.Unaccepted);
            MessageBox.Show("It has been rejected!");
            SelectAllData();
            CleanFilters();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Do you want to delete this permission?", "Warning", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                if (properties.State == PermissionAdminStateStatic.Accepted || properties.State == PermissionAdminStateStatic.Unaccepted)
                {
                    MessageBox.Show("You cannot delete accepted or unaccepted permissions");
                }
                else
                {
                    PermissionBLL.DeletePermission(properties.PermissionID);
                    //message after delete
                    MessageBox.Show("Permission was deleted");
                    //we have to refresh
                    SelectAllData();
                    CleanFilters();
                }
            }
        }
    }
}
