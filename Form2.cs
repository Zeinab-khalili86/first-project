using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shop
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                string username = txtcuser.Text;
            }
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            if(txtcuser.TextLength>0 && txtcpass.TextLength>0)
            {
                customerTableAdapter.customerFillBy(shoop1DataSet.customer, int.Parse(txtcpass.Text));
                if(shoop1DataSet.customer.Rows.Count>0)
                {
                    Form1 frm1 = new Form1();
                    frm1.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("نام کاربری و رمز عبور درست نمیباشد ، لطفا دوباره وارد کنید!");
                    txtcuser.Text = "";
                    txtcpass.Text = "";
                }
            }
            else
            {
                customerTableAdapter.Fill(shoop1DataSet.customer);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'shoop1DataSet.customer' table. You can move, or remove it, as needed.
            this.customerTableAdapter.Fill(this.shoop1DataSet.customer);

        }

        private void Form2_Load_1(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'shoop1DataSet1.customer' table. You can move, or remove it, as needed.
            this.customerTableAdapter1.Fill(this.shoop1DataSet1.customer);

        }

        private void btnlog_Click(object sender, EventArgs e)
        {
            if (txtusername.TextLength > 0 && txtpassword.TextLength > 0)
            {
                customerTableAdapter1.customerFillBy(shoop1DataSet1.customer, int.Parse(txtpassword.Text));
                if (shoop1DataSet1.customer.Rows.Count > 0)
                {
                    Form1 frm1 = new Form1();
                    frm1.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("نام کاربری و رمز عبور درست نمیباشد ، لطفا دوباره وارد کنید!");
                    txtpassword.Clear();
                    txtusername.Clear();
                }
            }
            else
            {
                MessageBox.Show("برخی فیلد ها پر نشده است");
                customerTableAdapter1.Fill(shoop1DataSet1.customer);
            }
        }

        private void btnext_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("آیا از خروج مطمئن هستید ؟!", "خروج",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
