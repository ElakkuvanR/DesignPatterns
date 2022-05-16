using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiddleLayer;
using FactoryCustomer;

namespace WinFormCustomer
{
    public partial class FrmCustomer : Form
    {
        private CustomerBase customerBase = null;
        public FrmCustomer()
        {
            InitializeComponent();
            txtBillDate.Text = "1/1/2021";
            txtBillAmount.Text = "0";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            try
            {
                SetCustomer();
                customerBase.Validate();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SetCustomer()
        {
            customerBase.CustomerName = txtCustomerName.Text;
            customerBase.PhoneNumber = txtPhoneNumber.Text;
            customerBase.BillDate = Convert.ToDateTime(txtBillDate.Text);
            customerBase.BillAmount = Convert.ToDecimal(txtBillAmount.Text);
            customerBase.Address = txtAddress.Text;
        }

        private void cbxCustomerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            customerBase = Factory.Create(cbxCustomerType.Text);
        }
    }
}
