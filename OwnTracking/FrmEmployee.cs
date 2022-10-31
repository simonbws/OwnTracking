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
using System.IO;

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
            cmbDepartment.ValueMember = "ID";
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
        string fileName = "";

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Load(openFileDialog1.FileName);
                txtImagePath.Text=openFileDialog1.FileName;
                string UniquePath = Guid.NewGuid().ToString();
                fileName += UniquePath + openFileDialog1.SafeFileName;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtUserNo.Text.Trim() == "")
            {
                MessageBox.Show("Please provide User Number");
            }
            else if (!EmployeeBLL.isUnique(Convert.ToInt32(txtUserNo.Text)))
            {
                MessageBox.Show("This user is no unique");
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
            else if (cmbDepartment.SelectedIndex == -1)
            {
                MessageBox.Show("Please provide a department");
            }
            else if (cmbPosition.SelectedIndex == -1)
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
                employee.Address = txtAddress.Text;
                employee.Birthday = dateTimePicker1.Value;
                employee.ImagePath = fileName;
                EmployeeBLL.AddEmployee(employee);
                File.Copy(txtImagePath.Text, @"images\\" + fileName);
                MessageBox.Show("Employee has been added");

                txtUserNo.Clear();
                txtPassword.Clear();
                chAdmin.Checked = false;
                txtName.Clear();
                txtSurname.Clear();
                txtSalary.Clear();
                txtAddress.Clear();
                cmbDepartment.SelectedIndex = -1;
                cmbPosition.DataSource = dto.Positions;
                cmbPosition.SelectedIndex = -1;
                comfobull = false;
                txtImagePath.Clear();
                pictureBox1.Image = null;
                comfobull = true;
                dateTimePicker1.Value = DateTime.Today;
                
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        bool isUnique = false;
        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (txtUserNo.Text.Trim() == "")
            {
                MessageBox.Show("Please provide User Number");
            }
            else
            {
                isUnique = EmployeeBLL.isUnique(Convert.ToInt32(txtUserNo.Text));
                if (!isUnique)
                {
                    MessageBox.Show("This user is no unique");
                }
                else
                {
                    MessageBox.Show("This user number is ok!");
                }
            }

        }
    }
}
