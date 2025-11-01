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
  
    public partial class Form1 : Form
    { int gkoll = 0; 
        string count="";
        public Form1()
        {
           
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'shoop1DataSet.sabt' table. You can move, or remove it, as needed.
            this.sabtTableAdapter.Fill(this.shoop1DataSet.sabt);
            // TODO: This line of code loads data into the 'shoop1DataSet.factoritems' table. You can move, or remove it, as needed.
            this.factoritemsTableAdapter.Fill(this.shoop1DataSet.factoritems);
            // TODO: This line of code loads data into the 'shoop1DataSet.factor' table. You can move, or remove it, as needed.
            this.factorTableAdapter.Fill(this.shoop1DataSet.factor);
            // TODO: This line of code loads data into the 'shoop1DataSet.sabad' table. You can move, or remove it, as needed.
            this.sabadTableAdapter.Fill(this.shoop1DataSet.sabad);
            // TODO: This line of code loads data into the 'shoop1DataSet.detail' table. You can move, or remove it, as needed.
            this.detailTableAdapter.Fill(this.shoop1DataSet.detail);
            // TODO: This line of code loads data into the 'shoop1DataSet1.customer' table. You can move, or remove it, as needed.
            this.customerTableAdapter.Fill(this.shoop1DataSet1.customer);
            // TODO: This line of code loads data into the 'shoop1DataSet.goods' table. You can move, or remove it, as needed.
            this.goodsTableAdapter.Fill(this.shoop1DataSet.goods);
            // TODO: This line of code loads data into the 'shoop1DataSet1.customer' table. You can move, or remove it, as needed.

            this.goodsTableAdapter.Fill(this.shoop1DataSet.goods);
            // TODO: This line of code loads data into the 'shpp1DataSet.sabt' table. You can move, or remove it, as needed.

            lblfcode.Text = dataGridView2.Rows.Count.ToString();


        }

        private void btnlast_Click(object sender, EventArgs e)
        {
            goodsBindingSource.MoveLast();
        }

        private void btnnext_Click(object sender, EventArgs e)
        {
            goodsBindingSource.MoveNext();
        }

        private void btnprev_Click(object sender, EventArgs e)
        {
            goodsBindingSource.MovePrevious();
        }

        private void btnfirst_Click(object sender, EventArgs e)
        {
            goodsBindingSource.MoveFirst();
        }

        private void btninsert_Click(object sender, EventArgs e)
        {
            if(txtgcode.TextLength>0 && txtgname.TextLength>0 && txtgcount.TextLength>0 && txtgprice.TextLength>0 )
            {
                goodsTableAdapter.goodInsertQuery(int.Parse(txtgcode.Text), txtgname.Text, int.Parse(txtgcount.Text), int.Parse(txtgprice.Text));
                goodsTableAdapter.Fill(shoop1DataSet.goods);

            }
            else
            {
                MessageBox.Show("برخی فیلد ها مقداردهی نشده است، لطفا آنهارا مقداردهی کنید");
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (txtgcode.TextLength > 0 && txtgname.TextLength > 0 && txtgcount.TextLength > 0 && txtgprice.TextLength > 0)
            {
                goodsTableAdapter.goodUpdateQuery(int.Parse(txtgcount.Text), int.Parse(txtgcode.Text), int.Parse(txtgprice.Text), txtgname.Text);
                goodsTableAdapter.Fill(shoop1DataSet.goods);

            }
            else
            {
                MessageBox.Show("برخی فیلد ها مقداردهی نشده است، لطفا آنهارا مقداردهی کنید");
            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            txtgcode.Text = "";
            txtgcount.Text = "";
            txtgname.Text = "";
            txtgprice.Text = "";
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (txtgcode.TextLength > 0 && txtgname.TextLength > 0 && txtgcount.TextLength > 0 && txtgprice.TextLength > 0)
            {
                goodsTableAdapter.goodDeleteQuery(txtgname.Text);
                goodsTableAdapter.Fill(shoop1DataSet.goods);

            }
            else
            {
                MessageBox.Show("برخی فیلد ها مقداردهی نشده است، لطفا آنهارا مقداردهی کنید");
            }
        }

        private void btndarg_Click(object sender, EventArgs e)
        {
            string txtsgcode = txtgcode.Text, txtsgname = txtgname.Text, txtsgvahed = txtgprice.Text;
        }

        private void btnselect_Click(object sender, EventArgs e)
        {
            string name = txtcname.Text,
                family = txtcfamily.Text,
                username = txtcuser.Text,
                code = txtccode.Text,
                mobile = txtcmobile.Text,
                address = txtcaddress.Text;
            lblccode.Text = code;
            lblcaddress.Text = address;
            lblcmobile.Text = mobile;
            lblcname.Text = name;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            lblgcode.Text = "";
            lblgcount.Text = "";
            lblgname.Text = "";
            lblgprice.Text = "";
            txtgtedad.Text = "";
        }

        private void btninsertsabad_Click(object sender, EventArgs e)
        {
            if (txtdae.TextLength > 0)
            {
            try { 
            lblfcode.Text = (dataGridView2.Rows.Count+1).ToString();
            count+=(dataGridView2.Rows.Count+1).ToString()+"0";
        int gkol = int.Parse(txtgtedad.Text) * int.Parse(lblgprice.Text);
            gkoll += gkol;
            lblgkol.Text = gkoll.ToString();
            sabadTableAdapter.sabadInsertQuery(int.Parse(lblgcode.Text), lblgname.Text, int.Parse(txtgtedad.Text), int.Parse(lblgprice.Text), gkol, int.Parse(lblccode.Text));
            sabadTableAdapter.Fill(shoop1DataSet.sabad);
            
            factorTableAdapter.factorInsertQuery(int.Parse(lblfcode.Text),int.Parse(lblccode.Text), txtdae.Text);
            factorTableAdapter.Fill(shoop1DataSet.factor);

            factoritemsTableAdapter.factoritemsInsertQuery(int.Parse(lblfcode.Text), int.Parse(lblgcode.Text), int.Parse(txtgtedad.Text));
            factoritemsTableAdapter.Fill(shoop1DataSet.factoritems);}
            catch
            {
                MessageBox.Show("خطا در اضافه کالا در سبد کالا !!");
            }
            }
            else
            {
                MessageBox.Show("برخی فیلد ها مقداردهی نشده است لطفا دقت کنید !!!");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(string.Format(" کد فاکتور : {0} \r\n قیمت کل: {1} \r\n تاریخ : {2} \r\r آیا از ثبت سفارش اطمینان دارید؟ ",count,lblgkol.Text,txtdae.Text), "ثبت سفارش", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                sabtTableAdapter.sabtInsertQuery(int.Parse(count), int.Parse(lblgkol.Text), txtdae.Text);
                MessageBox.Show("خرید شما با موفقیت ثبت شد :)");
            }

        }

        private void btndetail_Click(object sender, EventArgs e)
        {
            if (txtcusername.TextLength > 0 && txtgnamee.TextLength > 0 && txtdetail.TextLength > 0 )
            {
                detailTableAdapter.detailInsertQuery(txtcusername.Text, txtgnamee.Text, txtdetail.Text);
                detailTableAdapter.Fill(shoop1DataSet.detail);
                MessageBox.Show("با موفقیت انجام شد");

            }
            else
            {
                MessageBox.Show("برخی فیلد ها مقداردهی نشده است، لطفا آنهارا مقداردهی کنید");
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        public class classa
        {
           
            public string date;


        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            if(txtsearchname.TextLength>0 && txtsearchcode.TextLength>0)
            {
                goodsTableAdapter.searchhFillBy(shoop1DataSet.goods,txtsearchname.Text, int.Parse(txtsearchcode.Text) );

                if(shoop1DataSet.goods.Rows.Count > 0)
                {
                    MessageBox.Show(string.Format("کالای مورد نظر موجود میباشد   \r\n   قیمت کالا: {0} \r\n   موجودی کالا : {1}",txtgprice.Text,txtgcount.Text));
                }
                else
                {
                    MessageBox.Show("کالای مورد نظر موجود نمیباشد");
                }
                goodsTableAdapter.Fill(shoop1DataSet.goods);
                txtsearchcode.Clear();
                txtsearchname.Clear();
            }
            else
            {
                MessageBox.Show("برخی فیلد ها مقداردهی نشده است، لطفا آنهارا مقداردهی کنید");  
            }
        }
    }
}
