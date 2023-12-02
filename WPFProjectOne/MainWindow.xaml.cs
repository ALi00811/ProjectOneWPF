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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DataAccess;
using DataAccess.Models;
using System.Collections.ObjectModel;
using WPFProjectOne;

namespace WPFProjectOne
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EmployeeDataAccess employeeDataAccess = new EmployeeDataAccess();
        CustomerDataAccess customerDataAccess = new CustomerDataAccess();
        ProductDataAccess productDataAccess = new ProductDataAccess();

        ObservableCollection<Employee> employees = new ObservableCollection<Employee>();
        ObservableCollection<Customer> customers = new ObservableCollection<Customer>();
        ObservableCollection<Product> products = new ObservableCollection<Product>();

        public Employee currentEmployee { get; set; } = new Employee();
        public Product currentProduct { get; set; } = new Product();
        public Customer currentCustomer { get; set; } = new Customer();
        public MainWindow()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            FillData();
            EmployeeGrid.ItemsSource = employees;
            CustomerGrid.ItemsSource = customers;
            ProductGrid.ItemsSource = products;
        }

        private void FillData()
        {
            employees = employeeDataAccess.Employees;
            products = productDataAccess.Products;
            customers = customerDataAccess.Customers;
        }

        private void btnProducts_Click(object sender, RoutedEventArgs e)
        {
            HomePanel.Visibility = Visibility.Collapsed;
            ProductsPanel.Visibility = Visibility.Visible;
            CustomersPanel.Visibility = Visibility.Collapsed;
            EmploesePanel.Visibility = Visibility.Collapsed;
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            HomePanel.Visibility = Visibility.Visible;
            CustomersPanel.Visibility = Visibility.Collapsed;
            ProductsPanel.Visibility = Visibility.Collapsed;
            EmploesePanel.Visibility = Visibility.Collapsed;
        }

        private void btnEmploees_Click(object sender, RoutedEventArgs e)
        {
            HomePanel.Visibility = Visibility.Collapsed;
            CustomersPanel.Visibility = Visibility.Collapsed;
            ProductsPanel.Visibility = Visibility.Collapsed;
            EmploesePanel.Visibility = Visibility.Visible;
        }

        private void btnCustomers_Click(object sender, RoutedEventArgs e)
        {
            HomePanel.Visibility = Visibility.Collapsed;
            ProductsPanel.Visibility = Visibility.Collapsed;
            CustomersPanel.Visibility = Visibility.Visible;
            EmploesePanel.Visibility = Visibility.Collapsed;
        }

        private void EmployeeGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if(EmployeeGrid.SelectedIndex >= 0)
            {
                currentEmployee = EmployeeGrid.SelectedItem as Employee;
                EmployeeLable.Content = currentEmployee.GetBasicInfo();
            }
        }

        private void btnAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            new AddEditEmployee(employeeDataAccess).ShowDialog();
        }

        private void btnEditEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeeGrid.SelectedIndex >= 0)
            {
                currentEmployee = EmployeeGrid.SelectedItem as Employee;
                new AddEditEmployee(employeeDataAccess, currentEmployee).ShowDialog();
            }
        }

        private void btnDeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            if(EmployeeGrid.SelectedIndex >= 0)
            {
                currentEmployee = EmployeeGrid.SelectedItem as Employee;
                employeeDataAccess.Removeemployee(currentEmployee.Id);
                EmployeeLable.Content = "---";
            }
        }

        private void CustomerGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if(CustomerGrid.SelectedIndex >= 0)
            {
                currentCustomer = CustomerGrid.SelectedItem as Customer;
                CustomerLable.Content = currentCustomer.GetBasicInfo();
            }
        }

        private void btnAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            new AddEditCustomer(customerDataAccess).ShowDialog();
        }

        private void btnEditCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (CustomerGrid.SelectedIndex > 0)
            {
                currentCustomer = CustomerGrid.SelectedItem as Customer;
                new AddEditCustomer(customerDataAccess,currentCustomer).ShowDialog();
            }
        }

        private void btnDeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            if(CustomerGrid.SelectedIndex > 0)
            {
                currentCustomer = CustomerGrid.SelectedItem as Customer;
                customerDataAccess.RemoveCustomer(currentCustomer.Id);
            }
        }

        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            new AddEditProduct(productDataAccess).ShowDialog();
        }

        private void btnEditProduct_Click(object sender, RoutedEventArgs e)
        {
            if (ProductGrid.SelectedIndex >= 0)
            {
                currentProduct = ProductGrid.SelectedItem as Product;
                new AddEditProduct(productDataAccess, currentProduct).ShowDialog();
            }
        }

        private void btnDeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            if (ProductGrid.SelectedIndex >= 0)
            {
                currentProduct = ProductGrid.SelectedItem as Product;
                productDataAccess.RemoveProduct(currentProduct.Id);
                ProductLable.Content = "---";
            }
        }

        private void ProductGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (ProductGrid.SelectedIndex >= 0)
            {
                currentProduct = ProductGrid.SelectedItem as Product;
                ProductLable.Content = currentProduct.GetBasicInfo();
            }
        }
    }
}
