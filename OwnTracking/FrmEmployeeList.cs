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
    public partial class FrmEmployeeList : Form
    {
        public FrmEmployeeList()
        {
            InitializeComponent();
        }

        private void txtUserNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.isNumber(e);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmEmployee frm = new FrmEmployee();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
            SelectAllData();
            ClearAllFilters();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (properties.EmployeeID == 0)
            {
                MessageBox.Show("Please provide an employee");
            }
            else
            {
                FrmEmployee frm = new FrmEmployee();
                frm.isUpdate = true;
                frm.properties = properties;
                this.Hide();
                frm.ShowDialog();
                this.Visible = true;
                SelectAllData();
                ClearAllFilters();

            }
            
            
        }
        EmployeeDTO dto = new EmployeeDTO();
        private bool comfobull = false;
        EmployeePropertiesDTO properties = new EmployeePropertiesDTO();
        void SelectAllData()
        {
            
            dto = EmployeeBLL.GetAll();
            dataGridView1.DataSource = dto.Employees;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "User Number";
            dataGridView1.Columns[2].HeaderText = "Name";
            dataGridView1.Columns[3].HeaderText = "Surname";
            dataGridView1.Columns[4].HeaderText = "Department";
            dataGridView1.Columns[5].HeaderText = "Position";
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].HeaderText = "Salary";
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
            cmbPosition.ValueMember = "id";
            cmbDepartment.SelectedIndex = -1;
            cmbPosition.SelectedIndex = -1;
            comfobull = true;
        }
        private void FrmEmployeeList_Load(object sender, EventArgs e)
        {
            SelectAllData();
        }

        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comfobull)
            {
                cmbPosition.DataSource = dto.Positions.Where(x => x.DepartmentID ==
                    Convert.ToInt32(cmbDepartment.SelectedValue)).ToList();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAllFilters();
        }

        private void ClearAllFilters()
        {
            txtUserNo.Clear();
            txtName.Clear();
            txtSurname.Clear();
            comfobull = false;
            cmbDepartment.SelectedIndex = -1;
            cmbPosition.DataSource = dto.Positions;
            cmbPosition.SelectedIndex = -1;
            comfobull = true;
            dataGridView1.DataSource = dto.Employees;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<EmployeePropertiesDTO> list = dto.Employees;
            if (txtUserNo.Text.Trim() != "")
            {
                list = list.Where(x=>x.UserNumber==Convert.ToInt32(txtUserNo.Text)).ToList();
            }
            if (txtName.Text.Trim() != "")
            {
                list = list.Where(x=>x.Name.Contains(txtName.Text)).ToList();
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
            
                list = list.Where(x => x.PositionID == Convert.ToInt32(cmbPosition.SelectedValue)).ToList();  
            //now we have to give this list to the data grid
            dataGridView1.DataSource = list;
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //here we are setting values to dto
            properties.Name = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            properties.Surname = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            properties.Password = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
            properties.ImagePath = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
            properties.Address = dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString();
            properties.isAdmin = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[9].Value);
            properties.BirthDay = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[13].Value);
            properties.UserNumber = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
            properties.DepartmentID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[6].Value);
            properties.PositionID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[7].Value);
            properties.EmployeeID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            properties.Salary = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[8].Value);
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Do you want to delete an employee?", "Warning", MessageBoxButtons.YesNo); 
            if (res == DialogResult.Yes)
            {
                EmployeeBLL.DeleteEmployee(properties.EmployeeID);
                MessageBox.Show("Employee has been removed");
                SelectAllData();
                ClearAllFilters();
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
