using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogicLayer;
using DataAccessLayer;
using DataAccessLayer.DTO;

namespace OwnTracking
{
    public partial class FrmEmployee : Form
    {
        public FrmEmployee()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.isNumber(e);
        }

        private void txtSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.isNumber(e);
        }
        EmployeeDTO dto = new EmployeeDTO();
        private void FrmEmployee_Load(object sender, EventArgs e)
        {
            dto = EmployeeBLL.GetAll();
            cmbDepartment.DataSource = dto.Departments;
            cmbDepartment.DisplayMember = "Department Name";
            cmbDepartment.ValueMember = "id";
            cmbPosition.DataSource = dto.Positions;
            cmbPosition.DisplayMember = "Position Name";
            cmbPosition.ValueMember = "id";
            cmbDepartment.SelectedIndex = -1;
            cmbPosition.SelectedIndex = -1;
            comfobull = true;
        }
        bool comfobull = false;
        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comfobull)
            {
                int depId = Convert.ToInt32(cmbDepartment.SelectedValue);
                cmbPosition.DataSource = dto.Positions.Where(x => x.DepartmentID == depId).ToList();
            } 
            
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtUserNo.Text.Trim() == "")
            {
                MessageBox.Show("Please provide User Number");
            }
            else if (txtPassword.Text.Trim() == "")
            {
                MessageBox.Show("Please provide a password");
            }
            else if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("Please provide a name");
            }
            else if (txtSurname.Text.Trim() == "")
            {
                MessageBox.Show("Please provide a surname");
            }
            else if (txtSalary.Text.Trim() == "")
            {
                MessageBox.Show("Please provide a salary");
            }
            else if (cmbDepartment.Text.Trim() == "")
            {
                MessageBox.Show("Please provide a department");
            }
            else if (cmbPosition.Text.Trim() == "")
            {
                MessageBox.Show("Please provide a position");
            }
            else
            {
                EMPLOYEE employee = new EMPLOYEE();
                employee.UserNumber = Convert.ToInt32(txtUserNo.Text);
                employee.Password = txtPassword.Text;
                employee.Name = txtName.Text;
                employee.isAdmin = chAdmin.Checked;
                employee.Surname = txtSurname.Text;
                employee.Salary = Convert.ToInt32(txtSalary.Text);
                employee.DepartmentID = Convert.ToInt32(cmbDepartment.SelectedValue);
                employee.PositionID = Convert.ToInt32(cmbPosition.SelectedValue);
                
            }

        }
    }
}
