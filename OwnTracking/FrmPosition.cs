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
using DataAccessLayer.DAO;
using DataAccessLayer.DTO;

namespace OwnTracking
{
    public partial class FrmPosition : Form
    {
        public FrmPosition()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        List<DEPARTMENT> depList=new List<DEPARTMENT>();
        public PositionDTO properties = new PositionDTO();
        public bool isUpdate = false;
        private void FrmPosition_Load(object sender, EventArgs e)
        {
            depList = DepartmentBLL.GetDepartments();
            cmbDepartment.DataSource = depList;
            cmbDepartment.DisplayMember = "Department Name";
            cmbDepartment.ValueMember = "ID";
            cmbDepartment.SelectedIndex = -1;
            if (isUpdate)
            {
                txtPosition.Text = properties.PositionName;
                cmbDepartment.SelectedValue = properties.DepartmentID;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPosition.Text.Trim() == "")
            {
                MessageBox.Show("Please enter the name");
            }
            else if (cmbDepartment.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a department");
            }
            else
            {
                if (!isUpdate)
                {
                    POSITION position = new POSITION();
                    position.PositionName = txtPosition.Text;
                    position.DepartmentID = Convert.ToInt32(cmbDepartment.SelectedValue);
                    BusinessLogicLayer.PositionBusinessLL.AddPosition(position);
                    MessageBox.Show("Position has been added");
                    txtPosition.Clear();
                    cmbDepartment.SelectedIndex = -1;
                }
                else
                {
                    POSITION position = new POSITION();
                    position.ID = properties.ID;
                    position.PositionName = txtPosition.Text;
                    position.DepartmentID = Convert.ToInt32(cmbDepartment.SelectedValue);
                    //we have to control if department is changed or not
                    bool isChangeOrNot = false;
                    if (Convert.ToInt32(cmbDepartment.SelectedValue) != properties.DepartmentToChangeID)
                    {
                        isChangeOrNot = true;
                        PositionBusinessLL.UpdatePosition(position, isChangeOrNot);
                        MessageBox.Show("Position has been updated");
                        this.Close();
;                    }
                }

            }

        }
    }
}
