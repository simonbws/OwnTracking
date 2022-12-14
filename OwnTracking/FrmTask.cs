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
using BusinessLogicLayer;
using DataAccessLayer;

namespace OwnTracking
{
    public partial class FrmTask : Form
    {
        public FrmTask()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        TaskDTO dto = new TaskDTO();
        private bool comfobull= false;
        public bool isUpdate = false;
        public TaskPropertiesDTO properties = new TaskPropertiesDTO();

        private void FrmTask_Load(object sender, EventArgs e)
        {
            label9.Visible = false;
            cmbTaskState.Visible = false;
            dto = TaskBLL.GetAll();
            dataGridView1.DataSource = dto.Employees;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "User Number";
            dataGridView1.Columns[2].HeaderText = "Name";
            dataGridView1.Columns[3].HeaderText = "Surname";
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[13].Visible = false;

            comfobull = false;
            cmbDepartment.DataSource = dto.Departments;
            cmbDepartment.DisplayMember = "DepartmentName";
            cmbDepartment.ValueMember = "ID";
            cmbPosition.DataSource = dto.Positions;
            cmbPosition.DisplayMember = "PositionName";
            cmbPosition.ValueMember = "ID";
            cmbDepartment.SelectedIndex = -1;
            cmbPosition.SelectedIndex = -1;
            comfobull = true;
            

            if (isUpdate)
            {
                label9.Visible = true;
                cmbTaskState.Visible = true;
                txtName.Text = properties.Name;
                txtUserNo.Text = properties.UserNumber.ToString();
                txtSurname.Text = properties.Surname;
                txtTitle.Text = properties.Title;
                txtContent.Text = properties.Content;
                cmbTaskState.DataSource = dto.TaskStates;
                cmbTaskState.DisplayMember = "StateName";
                cmbTaskState.ValueMember = "ID";
                cmbTaskState.SelectedValue = properties.taskStateID;


            }
        }

        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comfobull)
            {
                cmbPosition.DataSource = dto.Positions.Where(x => x.DepartmentID ==
                    Convert.ToInt32(cmbDepartment.SelectedValue)).ToList();
                //filter
                List<EmployeePropertiesDTO> list = dto.Employees;
                dataGridView1.DataSource = list.Where(x => x.DepartmentID ==
                Convert.ToInt32(cmbDepartment.SelectedValue)).ToList();
            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtUserNo.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtSurname.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            //we will enter employee id from the table to our class - task below
            task.EmployeeID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
        }

        private void cmbPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comfobull)
            {
              
                //filter
                List<EmployeePropertiesDTO> list = dto.Employees;
                dataGridView1.DataSource = list.Where(x => x.PositionID ==
                Convert.ToInt32(cmbPosition.SelectedValue)).ToList();
            }
        }
        //for add task we need task instance so we will ad task with employee id
        TASK task = new TASK();
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (task.EmployeeID == 0)
            {
                MessageBox.Show("Please provide an employee on table");
            }
            else if (txtTitle.Text.Trim() == "")
            {
                MessageBox.Show("Please provide a task title");
            }
            else if (txtContent.Text.Trim() == "")
            {
                MessageBox.Show("Content is empty");

            }
            //set the value to our class
            else
            {
                if (!isUpdate)
                {
                    task.TaskTitle = txtTitle.Text;
                    task.TaskContent = txtContent.Text;
                    task.TaskStartDate = DateTime.Today;
                    task.TaskState = 1;
                    TaskBLL.AddTask(task);
                    //after save task to db give a message
                    MessageBox.Show("Task has been added");
                    //now clear the data
                    txtTitle.Clear();
                    txtContent.Clear();
                    task = new TASK();
                }
                else if (isUpdate)
                {
                    DialogResult res = MessageBox.Show("Do you want to update?", "Warning", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                    {
                        TASK update = new TASK();
                        update.ID = properties.TaskID;
                        if (Convert.ToInt32(txtUserNo.Text) != properties.UserNumber)
                        {
                            update.EmployeeID = task.EmployeeID;
                        }
                        else
                        {
                            update.EmployeeID = properties.EmployeeID;
                            update.TaskContent = txtContent.Text;
                            update.TaskTitle = txtTitle.Text;
                            update.TaskState = Convert.ToInt32(cmbTaskState.SelectedValue);
                            TaskBLL.UpdateTask(update);
                            MessageBox.Show("Update has been done successfully");
                            this.Close();

                        }
                    }
                }


            }
            


        }
    }
}
