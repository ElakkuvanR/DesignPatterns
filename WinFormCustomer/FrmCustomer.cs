using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FactoryCustomer;
using FactoryDal;
using InterfaceCustomer;
using InterfaceDal;

namespace WinFormCustomer
{
    public partial class FrmCustomer : Form
    {
        private ICustomer customerBase = null;
        public FrmCustomer()
        {
            InitializeComponent();
            txtBillDate.Text = "1/1/2021";
            txtBillAmount.Text = "0";
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            try
            {
                SetCustomer();
                customerBase.Validate();
            }
            catch (Exception ex)
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
            customerBase = Factory<ICustomer>.Create(cbxCustomerType.Text);
        }

        private void LoadGrid()
        {
            IDal<ICustomer> iDal = FactoryDal<IDal<ICustomer>>.Create("AdoDal");
            List<ICustomer> list = iDal.Search();
            dataCustomerGrid.DataSource = list;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SetCustomer();
            IDal<ICustomer> iDal = Factory<IDal<ICustomer>>.Create("AdoDal");
            iDal.Add(customerBase); // In Memory
            iDal.Save(); // DB Save
        }

        private void FrmCustomer_Load(object sender, EventArgs e)
        {
            cbDalLayer.Items.Add("AdoDal");
            cbDalLayer.Items.Add("EntityFrame Work");
            LoadGrid();
        }
    }
}
