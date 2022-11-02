using BusinessLogicLayer;
using DataAccessLayer;
using DataAccessLayer.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OwnTracking
{
    public partial class FrmSalary : Form
    {
        public FrmSalary()
        {
            InitializeComponent();
        }
        
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        SalaryDTO dto = new SalaryDTO();
        private bool comfobull;
        public SalaryPropertiesDTO properties = new SalaryPropertiesDTO();
        public bool isUpdated = false;

        private void FrmSalary_Load(object sender, EventArgs e)
        {
            dto = SalaryBLL.GetAll();
           if (!isUpdated)
            {
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
                if (dto.Departments.Count > 0)
                    comfobull = true;
            }
            cmbMonth.DataSource = dto.Months;
            cmbMonth.DisplayMember = "MonthName";
            cmbMonth.ValueMember = "ID";
            cmbMonth.SelectedIndex = -1;
            //for update we have to hide this panel
            if (isUpdated)
            {
                panel1.Hide();
                //setting values to element
                txtName.Text = properties.Name;
                txtSalary.Text = properties.SalaryAmount.ToString();
                txtSurname.Text = properties.Surname;
                txtYear.Text = properties.SalaryYear.ToString();
                cmbMonth.SelectedValue = properties.MonthID;


            }

        }
        SALARY2 salary = new SALARY2();
        int previousSalary = 0;
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtUserNo.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtSurname.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtYear.Text = DateTime.Today.Year.ToString();
            txtSalary.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            previousSalary = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[8].Value);
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtYear.Text.Trim() == "")
            {
                MessageBox.Show("Please provide the year");
            }
                
            else if (cmbMonth.SelectedIndex == -1)
            {
                MessageBox.Show("Please provide a month");
            }
            else if (txtSalary.Text.Trim() == "")
            {
                MessageBox.Show("Please provide a salary");
            }
            
            else
            {
                bool isSalaryBiggerThanOld = false;
                if (!isUpdated)
                {
                    if (salary.EmployeeID == 0)
                    {
                        MessageBox.Show("Please provide correct employee");
                    }
                    else
                    {
                        salary.Year = Convert.ToInt32(txtYear.Text);
                        salary.MonthID = Convert.ToInt32(cmbMonth.SelectedValue);
                        salary.Amount = Convert.ToInt32(txtSalary.Text);
                        if (salary.Amount > previousSalary)
                        {
                            isSalaryBiggerThanOld = true;
                        }
                        SalaryBLL.AddSalary(salary, isSalaryBiggerThanOld);
                        MessageBox.Show("Salary was added");
                        cmbMonth.SelectedIndex = -1;
                        salary = new SALARY2();
                    }
                    
                }
                else
                {
                    DialogResult res = MessageBox.Show("Do you want to update?", "title", MessageBoxButtons.YesNo);
                    if (DialogResult.Yes == res)
                    {
                        SALARY2 salary = new SALARY2();
                        salary.EmployeeID = properties.EmployeeID;
                        salary.ID = properties.SalaryID;
                        salary.Year = Convert.ToInt32(txtYear.Text);
                        salary.MonthID = Convert.ToInt32(cmbMonth.SelectedValue);
                        salary.Amount = Convert.ToInt32(txtSalary.Text);
                        
                        if (salary.Amount > properties.OldSalaryForUpdate)
                        
                            isSalaryBiggerThanOld = true;
                        SalaryBLL.UpdateSalary(salary, isSalaryBiggerThanOld);
                        MessageBox.Show("Salary has been updated succesfully");
                        this.Close();
                    }
                }
            }
        }

        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
