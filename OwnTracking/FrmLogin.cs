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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void txtUserNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = General.isNumber(e);
            }
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (txtUserNo.Text.Trim() == "" || txtPassword.Text.Trim() == "")
            {
                MessageBox.Show("Please provide User Number or password");
            }
            else
            {
                List<EMPLOYEE> employeeList = EmployeeBLL.GetEmployee(Convert.ToInt32(txtUserNo.Text), txtPassword.Text);
                if (employeeList.Count == 0)
                {
                    MessageBox.Show("User or password is incorrect.");
                }
                else
                {
                    EMPLOYEE employee = new EMPLOYEE();
                    employee = employeeList.First();
                    //we need to fill properties from static class with list
                    UserStaticClass.EmployeeID = employee.ID;
                    UserStaticClass.UserNumber = employee.UserNumber;
                    UserStaticClass.isAdmin = employee.isAdmin;
                    //we redirect program to main form
                    FrmMain frmMain = new FrmMain();
                    frmMain.Hide();
                    frmMain.ShowDialog();
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
