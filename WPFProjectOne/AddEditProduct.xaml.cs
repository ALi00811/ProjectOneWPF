using DataAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net;
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

namespace WPFProjectOne
{
    /// <summary>
    /// Interaction logic for AddEditProduct.xaml
    /// </summary>
    public partial class AddEditProduct : Window
    {
        private ProductDataAccess productDataAccess;
        private Product EditProduct;
        bool IsEdit = false;
        public AddEditProduct(ProductDataAccess productdataaccess)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
            productDataAccess = productdataaccess;
        }
        public AddEditProduct(ProductDataAccess productdataaccess, Product product)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            productDataAccess = productdataaccess;
            this.EditProduct = product;
            IsEdit = true;
            tbName.Text = product.Name;
            tbAuthor.Text = product.Author;
            tbAvailableCount.Text = product.AvailableCount.ToString();
            tbPrice.Text = product.Price.ToString();
        }

        private void btnCancell_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (CheckValid())
            {
                try
                {
                    if (!IsEdit)
                    {
                        Product product = new Product()
                        {
                            Id = productDataAccess.GetNextId(),
                            Name = tbName.Text,
                            Author = tbAuthor.Text,
                            AvailableCount = Convert.ToInt16(tbAvailableCount.Text),
                            Price = Convert.ToDecimal(tbPrice.Text)
                        };
                        productDataAccess.AddProduct(product);
                    }
                    else
                    {
                        Product product = new Product()
                        {
                            Id = EditProduct.Id,
                            Name = tbName.Text,
                            Author = tbAuthor.Text,
                            AvailableCount = Convert.ToInt16(tbAvailableCount.Text),
                            Price = Convert.ToDecimal(tbPrice.Text)
                        };
                        productDataAccess.EditProduct(product);
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

        private bool CheckValid()
        {
            bool Valid = true;
            
            string Name = tbName.Text;
            string Author = tbAuthor.Text;
            string AvailableCount = tbAvailableCount.Text;
            string Price = tbPrice.Text;

            if (string.IsNullOrEmpty(Name))
            {
                lblError.Content = "FirstName is Valide";
                Valid = false;
            }
            else if (string.IsNullOrEmpty(Author))
            {
                lblError.Content = "Author is Valide";
                Valid = false;

            }
            else if (!UInt64.TryParse(AvailableCount, out ulong p))
            {
                lblError.Content = "AvailableCount is Valide";
                Valid = false;
            }
            else if (!UInt64.TryParse(Price, out ulong b))
            {
                lblError.Content = "Price is Valide";
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
