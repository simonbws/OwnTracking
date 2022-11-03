using BusinessLogicLayer;
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
    public partial class FrmPositionList : Form
    {
        public FrmPositionList()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Do you want to delete a position?", "Warning", MessageBoxButtons.YesNo);
            if (DialogResult.Yes == res)
            {
                PositionBusinessLL.DeletePosition(properties.ID);
                MessageBox.Show("Position has been deleted");
                FillGrid();
                
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (properties.ID == 0)
            {
                MessageBox.Show("Please provide a position");
            }
            else
            {
                //create instance
                FrmPosition frm= new FrmPosition();
                //set update and dto
                frm.isUpdate = true;
                frm.properties = properties;
                this.Hide();
                frm.ShowDialog();
                this.Visible = true;
                //after close we refresh form
                FillGrid();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmPosition frm = new FrmPosition();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
            FillGrid();
        }
        List<PositionDTO> posList = new List<PositionDTO>();
        void FillGrid()
        {
            posList = PositionBusinessLL.GetPositions();
            dataGridView1.DataSource = posList;
        }
        PositionDTO properties = new PositionDTO();
        private void FrmPositionList_Load(object sender, EventArgs e)
        {
            FillGrid();
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[0].HeaderText = "Department Name";
            dataGridView1.Columns[3].HeaderText = "Position Name";
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            properties.PositionName = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            properties.ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
            properties.DepartmentID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
            properties.DepartmentToChangeID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
            
        }
    }
}
