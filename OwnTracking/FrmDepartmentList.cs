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

namespace OwnTracking
{
    public partial class FrmDepartmentList : Form
    {
        public FrmDepartmentList()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmDepartment frm = new FrmDepartment();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
            lists = DepartmentBLL.GetDepartments();
            dataGridView1.DataSource = lists;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (properties.ID == 0)
            {
                MessageBox.Show("Please provide a department");
            }
            else
            {
                //first create form instance
                FrmDepartment form = new FrmDepartment();
                form.isUpdate = true;
                form.properties = properties;
                this.Hide();
                form.ShowDialog();
                this.Visible = true;
                //and show refresh page
                lists = DepartmentBLL.GetDepartments();
                dataGridView1.DataSource = lists;

            }
        }
        List<DEPARTMENT> lists = new List<DEPARTMENT>();
        public DEPARTMENT properties = new DEPARTMENT();
        private void FrmDepartmentList_Load(object sender, EventArgs e)
        {
            
            lists = DepartmentBLL.GetDepartments();
            dataGridView1.DataSource = lists;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Department Name";
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            properties.ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            properties.DepartmentName = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Do you want to delete a department?", "Warning", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                DepartmentBLL.DeleteDepartment(properties.ID);
                MessageBox.Show("Department has been removed");
                lists = DepartmentBLL.GetDepartments();
                dataGridView1.DataSource = lists;
            }
        }
    }
}
 