using LinhThongMinh.BAL.CongNo;
using LinhThongMinh.DTO.CongNo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinhThongMinh.GUI
{
    public partial class Form1 : Form
    {
        CongNoBAL congNoBAL = new CongNoBAL();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<CongNoDTO> congNos = congNoBAL.ReadCongNo();
            foreach (CongNoDTO congNo in congNos)
            {
                dgvCongNo.Rows.Add(congNo.ID, congNo.Name, congNo.PhoneNumber, congNo.AmountOwed);
            }
        }

        private void dgvCongNo_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            DataGridViewRow row = dgvCongNo.Rows[idx];
            if (row.Cells[0].Value != null)
            {
                tbId.Text = dgvCongNo.Rows[idx].Cells[0].Value.ToString();
                tbName.Text = dgvCongNo.Rows[idx].Cells[1].Value.ToString();
                tbPhone.Text = dgvCongNo.Rows[idx].Cells[2].Value.ToString();
                tbAmount.Text = dgvCongNo.Rows[idx].Cells[3].Value.ToString();
            }
        }

        private void btNew_Click(object sender, EventArgs e)
        {
            tbId.Text = "";
            tbName.Text = "";
            tbPhone.Text = "";
            tbAmount.Text = "";
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            if (tbId.Text == "")
            {
                MessageBox.Show("Please enter the code!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataGridViewRow row = dgvCongNo.CurrentRow;
                if (row != null)
                {
                    CongNoDTO cong = new CongNoDTO();
                    cong.ID = int.Parse(tbId.Text);
                    cong.Name = tbName.Text;
                    cong.PhoneNumber = tbPhone.Text;
                    cong.AmountOwed = decimal.Parse(tbAmount.Text);

                    congNoBAL.Edit(cong);

                    row.Cells[0].Value = cong.ID;
                    row.Cells[1].Value = cong.Name;
                    row.Cells[2].Value = cong.PhoneNumber;
                    row.Cells[3].Value = cong.AmountOwed;
                }
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            CongNoDTO cong = new CongNoDTO();
            cong.ID = int.Parse(tbId.Text);
            cong.Name = tbName.Text;

            congNoBAL.Delete(cong);

            int idx = dgvCongNo.CurrentCell.RowIndex;
            dgvCongNo.Rows.RemoveAt(idx);
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (tbId.Text == "")
            {
                MessageBox.Show("Please enter the code!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                CongNoDTO cong = new CongNoDTO();
                cong.ID = int.Parse(tbId.Text);
                cong.Name = tbName.Text;
                cong.PhoneNumber = tbPhone.Text;
                cong.AmountOwed = decimal.Parse(tbAmount.Text);
                congNoBAL.New(cong);

                dgvCongNo.Rows.Add(cong.ID, cong.Name, cong.PhoneNumber, cong.AmountOwed);
            }
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Are you sure to exit?", "Nofication", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
