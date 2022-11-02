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
    public partial class FrmDepartment : Form
    {
        public FrmDepartment()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtDepartment.Text.Trim() == "")
            {
                MessageBox.Show("Please write the name");
            }
            else
            {
                DEPARTMENT department = new DEPARTMENT();
                if (!isUpdate)
                {
                    department.DepartmentName = txtDepartment.Text;
                    BusinessLogicLayer.DepartmentBLL.AddDepartment(department);
                    MessageBox.Show("Department has been added");
                    txtDepartment.Clear();
                }
                //update condition
                else
                {
                    DialogResult res = MessageBox.Show("Do you want to update?", "Warning", MessageBoxButtons.YesNo);
                    //now set textbox to dto
                    if (DialogResult.Yes == res)
                    {
                        department.ID = properties.ID;
                        department.DepartmentName = txtDepartment.Text;
                        DepartmentBLL.UpdateDepartment(department);
                        MessageBox.Show("Department has been updated");
                        this.Close();
                    }
                }
            }

        }
        public bool isUpdate = false;
        public DEPARTMENT properties = new DEPARTMENT();
        private void FrmDepartment_Load(object sender, EventArgs e)
        {
            //now in form load we have to set the departmnet name to textbox
            if (isUpdate)
            {
                txtDepartment.Text = properties.DepartmentName;
            }
        }
    }
}
