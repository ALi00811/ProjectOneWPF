using DataAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace WPFProjectOne
{
    /// <summary>
    /// Interaction logic for AddEditCustomer.xaml
    /// </summary>
    public partial class AddEditCustomer : Window
    {
        private CustomerDataAccess customerDataAccess;
        private Customer Customer;
        bool IsEdit = false;
        public AddEditCustomer(CustomerDataAccess customerdataccess)
        {
            InitializeComponent();
            customerDataAccess = customerdataccess;
        }
        public AddEditCustomer(CustomerDataAccess customerdataccess, Customer customer)
        {
            InitializeComponent();
            customerDataAccess = customerdataccess;
            IsEdit = true;
            this.Customer = customer;
            tbFirstName.Text = customer.FirstName;
            tbLastName.Text = customer.LastName;
            tbAddress.Text = customer.Address;
            tbPhoneNumber.Text = customer.PhoneNumber.ToString();

        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (CheckValid())
            {
                try
                {
                    if (!IsEdit)
                    {
                        Customer cus = new Customer()
                        {
                            Id = customerDataAccess.GetNextId(),
                            FirstName = tbFirstName.Text,
                            LastName = tbLastName.Text,
                            PhoneNumber = Convert.ToUInt64(tbPhoneNumber.Text),
                            Address = tbAddress.Text
                            
                        };
                        customerDataAccess.AddCustomer(cus);
                    }
                    else
                    {
                        Customer cus = new Customer()
                        {
                            Id = Customer.Id,
                            FirstName = tbFirstName.Text,
                            LastName = tbLastName.Text,
                            PhoneNumber = Convert.ToUInt64(tbPhoneNumber.Text),
                            Address = tbAddress.Text
                            
                        };
                        customerDataAccess.EditCustomer(cus);
                    }
                    MessageBox.Show("Submit", "OK");
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Error", "Error");
                }
            }
        }

        private void btnCancell_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private bool CheckValid()
        {
            bool Valid = true;

            string firstname = tbFirstName.Text;
            string lastname = tbLastName.Text;
            string address = tbAddress.Text;
            string phonenumber = tbPhoneNumber.Text;

            if (string.IsNullOrEmpty(firstname))
            {
                lblError.Content = "FirstName is Valide";
                Valid = false;
            }
            else if (string.IsNullOrEmpty(lastname))
            {
                lblError.Content = "lastname is Valide";
                Valid = false;

            }
            else if (string.IsNullOrEmpty(address))
            {
                lblError.Content = "Address is Valide";
                Valid = false;

            }
            else if (!UInt64.TryParse(phonenumber, out ulong p))
            {
                lblError.Content = "phonenumber is Valide";
                Valid = false;
            }
            
            else
            {
                lblError.Content = "";
            }

            return Valid;
        }
    }
}
