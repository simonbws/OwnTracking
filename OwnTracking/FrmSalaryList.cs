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
    public partial class FrmSalaryList : Form
    {
        public FrmSalaryList()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmSalary frm = new FrmSalary();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
            SelectAllData();
            CleanButtonFilter();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (properties.SalaryID == 0)
            {
                MessageBox.Show("Please select a salary from table");
            }
            else
            {
                FrmSalary frm = new FrmSalary();
                frm.isUpdated = true;
                frm.properties = properties;
                this.Hide();
                //and refresh page
                this.Visible = true;
                SelectAllData();
                CleanButtonFilter();

            }
        }
        SalaryDTO dto = new SalaryDTO();
        private bool comfobull;
        void SelectAllData()
        {
            dto = SalaryBLL.GetAll();
            //now we can take all salary, lets show these list in necessery area
            dataGridView1.DataSource = dto.Salaries;
            comfobull = false;
            cmbDepartment.DataSource = dto.Departments;
            cmbDepartment.DisplayMember = "DepartmentName";
            cmbDepartment.ValueMember = "ID";
            if (dto.Departments.Count > 0)
            {
                comfobull = true;
            }
            cmbPosition.DataSource = dto.Positions;
            cmbPosition.DisplayMember = "PositionName";
            cmbPosition.ValueMember = "ID";
            cmbDepartment.SelectedIndex = -1;
            cmbPosition.SelectedIndex = -1;
            cmbMonth.DataSource = dto.Months;
            cmbMonth.DisplayMember = "MonthName";
            cmbMonth.ValueMember = "ID";
            cmbMonth.SelectedIndex = -1;
        }
        SalaryPropertiesDTO properties = new SalaryPropertiesDTO();
        private void FrmSalaryList_Load(object sender, EventArgs e)
        {
            SelectAllData();
            //copy from page employee list columns
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "User Number";
            dataGridView1.Columns[2].HeaderText = "Name";
            dataGridView1.Columns[3].HeaderText = "Surname";   
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].HeaderText = "Month";
            dataGridView1.Columns[9].HeaderText = "Year";
            dataGridView1.Columns[11].HeaderText = "Salary";
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[13].Visible = false;
            
        }

        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comfobull)
            {
                cmbPosition.DataSource = dto.Positions.Where(x => x.DepartmentID ==
                    Convert.ToInt32(cmbDepartment.SelectedValue)).ToList();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<SalaryPropertiesDTO> list = dto.Salaries;
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
            if (txtYear.Text.Trim() != "")
            {
                list = list.Where(x => x.SalaryYear == Convert.ToInt32(cmbPosition.SelectedValue)).ToList();

            }
            if (cmbMonth.SelectedIndex != -1)
            {
                list = list.Where(x=>x.MonthID == Convert.ToInt32(cmbMonth.SelectedValue)).ToList();    
            }
            if (txtSalary.Text.Trim() != "")
            {
                if (rbMore.Checked)
                {
                    list = list.Where(x => x.SalaryAmount > Convert.ToInt32(txtSalary.Text)).ToList();
                }
                else if (rbLess.Checked)
                {
                    list = list.Where(x => x.SalaryAmount < Convert.ToInt32(txtSalary.Text)).ToList();
                }
                else
                {
                    list = list.Where(x => x.SalaryAmount == Convert.ToInt32(txtSalary.Text)).ToList();
                }

            }
            //now we have to give this list to the data grid
            dataGridView1.DataSource = list;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            CleanButtonFilter();
        }

        private void CleanButtonFilter()
        {
            txtUserNo.Clear();
            txtName.Clear();
            txtSurname.Clear();
            comfobull = false;
            cmbDepartment.SelectedIndex = -1;
            cmbPosition.DataSource = dto.Positions;
            cmbPosition.SelectedIndex = -1;
            comfobull = true;
            cmbMonth.SelectedIndex = -1;
            rbMore.Checked = false;
            rbLess.Checked = false;
            rbEquals.Checked = false;
            txtYear.Clear();
            txtSalary.Clear();
            dataGridView1.DataSource = dto.Salaries;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            properties.Name = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            properties.Surname = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            properties.UserNumber = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
            properties.SalaryID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[12].Value);
            properties.EmployeeID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            properties.SalaryYear = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[9].Value);
            properties.MonthID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[10].Value);
            properties.OldSalaryForUpdate = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[11].Value);
            properties.SalaryAmount = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[11].Value); 

        }
    }
}
