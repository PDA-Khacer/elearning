using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Winform.Model;

namespace Winform
{
    public partial class Quanlytaikhoan : Form
    {
        AdminServiceReference.Admin_ServiceSoapClient soapClient = new AdminServiceReference.Admin_ServiceSoapClient();
        AccountServiceReference.Account_servicesSoapClient soapClient1 = new AccountServiceReference.Account_servicesSoapClient();
        public Quanlytaikhoan()
        {
            InitializeComponent();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btn_Themtkvaolophp_Click(object sender, EventArgs e)
        {
         
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void lv_dstk_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Quanlytaikhoan_Load(object sender, EventArgs e)
        {
            
            ListAccount acc= JsonConvert.DeserializeObject<ListAccount>(soapClient1.getAllAccountSystem());
            
            foreach(Account accItem in acc.accounts)
            {
                ListViewItem item = new ListViewItem();
                item.SubItems.Add(accItem.Username);
                item.SubItems.Add(accItem.Password);
                item.SubItems.Add(accItem.FullName);
                item.SubItems.Add(accItem.Email);
                item.SubItems.Add(accItem.Role);
                lv_dstk.Items.Add(item);
            }    
           
        }
        public void LoadLaiDanhSach()
        {
            ListAccount acc = JsonConvert.DeserializeObject<ListAccount>(soapClient1.getAllAccountSystem());

            foreach (Account accItem in acc.accounts)
            {
                ListViewItem item = new ListViewItem();
                item.SubItems.Add(accItem.Username);
                item.SubItems.Add(accItem.Password);
                item.SubItems.Add(accItem.FullName);
                item.SubItems.Add(accItem.Email);
                item.SubItems.Add(accItem.Role);
                lv_dstk.Items.Add(item);
            }
        }

        private void onItemSelected(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                txb_tendn.Text= lv_dstk.Items[e.ItemIndex].SubItems[1].Text;
                txb_tendn.Enabled = false;
                txb_matkhau.Text = lv_dstk.Items[e.ItemIndex].SubItems[2].Text;
                txb_matkhau.PasswordChar = '*';
                txb_hoten.Text = lv_dstk.Items[e.ItemIndex].SubItems[3].Text;
                txb_lop.Text = lv_dstk.Items[e.ItemIndex].SubItems[4].Text;
                txb_quyen.Text = lv_dstk.Items[e.ItemIndex].SubItems[5].Text;
            }
            else
            {

            }



            //ListViewItem item = sender as ListViewItem;
            //txb_tendn.Text =  item.SubItems[0].Text;
            //txb_matkhau.Text = item.SubItems[1].Text;
            //txb_hoten.Text = item.SubItems[2].Text;
            //txb_lop.Text = item.SubItems[3].Text;
            //txb_quyen.Text = item.SubItems[4].Text;


        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            string username = txb_tendn.Text;
            string password = txb_matkhau.Text;
            string hoten = txb_hoten.Text;
            string email = txb_lop.Text;
            string quyen = txb_quyen.Text;
            soapClient1.AddAccount(username, password, hoten, email, quyen);
            LoadLaiDanhSach();
        }

        private void btn_on_Click(object sender, EventArgs e)
        {
            txb_matkhau.PasswordChar = '\0';
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            string username = txb_tendn.Text;
            string password = txb_matkhau.Text;
            string hoten = txb_hoten.Text;
            string email = txb_lop.Text;
            string quyen = txb_quyen.Text;
            soapClient1.updateAccount(username, password, hoten, email, quyen);
            LoadLaiDanhSach();
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            string username = txb_tendn.Text;
            soapClient1.deleteAccount(username);
            LoadLaiDanhSach();
        }

        private void txb_Timkiem_TextChanged(object sender, EventArgs e)
        {
            string key = txb_Timkiem.Text;
            lv_dstk.Items.Clear();

            ListAccount acc = JsonConvert.DeserializeObject<ListAccount>(soapClient.FindStudentInSystem(key));
            foreach (Account accItem in acc.accounts)
            {
                ListViewItem item = new ListViewItem();
                item.SubItems.Add(accItem.Username);
                item.SubItems.Add(accItem.Password);
                item.SubItems.Add(accItem.FullName);
                item.SubItems.Add(accItem.Email);
                item.SubItems.Add(accItem.Role);
                lv_dstk.Items.Add(item);
            }
        }
    }
}
