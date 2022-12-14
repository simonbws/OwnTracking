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
using DataAccessLayer.DAO;
using BusinessLogicLayer;
using DataAccessLayer.DTO;
using System.Xml.Linq;

namespace OwnTracking
{
    public partial class FrmTaskList : Form
    {
        public FrmTaskList()
        {
            InitializeComponent();
        }

        private void txtUserNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.isNumber(e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        TaskDTO dto = new TaskDTO();
        private bool comfobull = false;
        void FillFieldByAllData()
        {
            dto = TaskBLL.GetAll();
           
            dataGridView1.DataSource = dto.Tasks;
            comfobull = false;
            cmbDepartment.DataSource = dto.Departments;
            cmbDepartment.DisplayMember = "DepartmentName";
            cmbDepartment.ValueMember = "ID";
            cmbPosition.DataSource = dto.Positions;
            cmbPosition.DisplayMember = "PositionName";
            cmbPosition.ValueMember = "id";
            cmbDepartment.SelectedIndex = -1;
            cmbPosition.SelectedIndex = -1;
            comfobull = true;
            cmbTaskState.DataSource = dto.TaskStates;
            cmbTaskState.DisplayMember = "StateName";
            cmbTaskState.ValueMember = "ID";
            cmbTaskState.SelectedIndex = -1;
        }
        TaskPropertiesDTO properties = new TaskPropertiesDTO();
        private void FrmTaskList_Load(object sender, EventArgs e)
        {
            FillFieldByAllData();

            dataGridView1.Columns[0].HeaderText = "Task Title";
            dataGridView1.Columns[1].HeaderText = "User Number";
            dataGridView1.Columns[2].HeaderText = "Name";
            dataGridView1.Columns[3].HeaderText = "Surname";
            dataGridView1.Columns[4].HeaderText = "Start Date";
            dataGridView1.Columns[5].HeaderText = "Delivery Date";
            dataGridView1.Columns[6].HeaderText = "Task State";
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[13].Visible = false;
            dataGridView1.Columns[14].Visible = false;
        }

        private void cmbTaskState_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmTask frm = new FrmTask();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
            FillFieldByAllData(); 
            CleanFilters();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (properties.TaskID == 0)
            {
                MessageBox.Show("Please provide a task");
            }
            else
            {
                FrmTask frm = new FrmTask();
                frm.isUpdate = true;
                frm.properties = properties;
                this.Hide();
                frm.ShowDialog();
                this.Visible = true;
                FillFieldByAllData();
                CleanFilters();
                
            }
            
        }

        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comfobull)
            {
                cmbPosition.DataSource = dto.Positions.Where(x => x.DepartmentID ==
                    Convert.ToInt32(cmbDepartment.SelectedValue)).ToList();
                //filter
                
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<TaskPropertiesDTO> list = dto.Tasks;
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
            //now we have to give this list to the data grid
            if (rbStartDate.Checked)
            {
                list=list.Where(x=>x.TaskStartDate==Convert.ToDateTime(dpStart.Value) && x.TaskStartDate
                ==Convert.ToDateTime(dpEnd.Value)).ToList();
            }
            if (rbDeliverDate.Checked)
            {
                list = list.Where(x => x.TaskDeliveryDate == Convert.ToDateTime(dpStart.Value) && x.TaskDeliveryDate
                == Convert.ToDateTime(dpEnd.Value)).ToList();
            }
            if (cmbTaskState.SelectedIndex != -1)
            {
                list=list.Where(x=>x.taskStateID==Convert.ToInt32(cmbTaskState.SelectedValue)).ToList();
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
            rbDeliverDate.Checked = false;
            rbStartDate.Checked = false;
            cmbTaskState.SelectedIndex = -1;
            dataGridView1.DataSource = dto.Tasks;
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //we have to take neccesary values
            properties.Name = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            properties.Surname = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            properties.Title = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            properties.Content = dataGridView1.Rows[e.RowIndex].Cells[13].Value.ToString();
            properties.UserNumber = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
            properties.taskStateID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[14].Value);
            properties.TaskID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[11].Value);
            properties.EmployeeID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[12].Value);
            properties.TaskStartDate = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
            properties.TaskDeliveryDate = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[5].Value);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Do you want to delete this task?", "Warning", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                TaskBLL.DeleteTask(properties.TaskID);
                MessageBox.Show("Task has been removed");
                FillFieldByAllData();
                CleanFilters();
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {     

        }
    }
}
