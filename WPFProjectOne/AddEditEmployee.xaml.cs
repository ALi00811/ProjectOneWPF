using DataAccess;
using System.Windows;
using DataAccess.Models;
using System;
using System.Net;

namespace WPFProjectOne
{
    /// <summary>
    /// Interaction logic for AddEditEmployee.xaml
    /// </summary>
    public partial class AddEditEmployee : Window
    {
        private EmployeeDataAccess employeeDataAccess;
        private Employee EditEmployee;

        bool IsEdit = false;
        public AddEditEmployee(EmployeeDataAccess employeeDataAccess)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
            this.employeeDataAccess = employeeDataAccess;
        }
        public AddEditEmployee(EmployeeDataAccess employeeDataAccess, Employee employee)
        {
            InitializeComponent();
            this.employeeDataAccess = employeeDataAccess;
            EditEmployee = employee;
            IsEdit = true;
            tbFirstName.Text = EditEmployee.FirstName;
            tbLastName.Text = EditEmployee.LastName;
            tbPhoneNumber.Text = EditEmployee.PhoneNumber.ToString();
            tbAddress.Text = EditEmployee.Address;
            tbSalery.Text = EditEmployee.BaseSalary.ToString();
            comboDepartement.SelectedIndex = (int)EditEmployee.Department;
        }
        private void btnCancell_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            
            if (CheckIsValide())
            {
                try
                {
                    if (IsEdit)
                    {
                        Employee emp = new Employee()
                        {
                            Id = EditEmployee.Id,
                            FirstName = tbFirstName.Text,
                            LastName = tbLastName.Text,
                            Address = tbAddress.Text,
                            BaseSalary = Convert.ToUInt64(tbSalery.Text),
                            PhoneNumber = Convert.ToUInt64(tbPhoneNumber.Text),
                            Department = (Department)comboDepartement.SelectedIndex,
                        };
                        employeeDataAccess.Editemployee(emp);
                        MessageBox.Show("Success", "Done");
                    }
                    else
                    {
                        Employee emp = new Employee()
                        {
                            Id = employeeDataAccess.GetNextId(),
                            FirstName = tbFirstName.Text,
                            LastName = tbLastName.Text,
                            Address = tbAddress.Text,
                            BaseSalary = Convert.ToUInt64(tbSalery.Text),
                            PhoneNumber = Convert.ToUInt64(tbPhoneNumber.Text),
                            Department = (Department)comboDepartement.SelectedIndex,
                        };
                        employeeDataAccess.AddEmployee(emp);
                        MessageBox.Show("Success", "Done");
                    }

                    this.Close();

                }
                catch (System.Exception)
                {
                    MessageBox.Show("Error", "Loss");

                }
            }
        }

        private bool CheckIsValide()
        {
            bool IsValid = true;
            string firstName = tbFirstName.Text.Trim().ToLower();
            string lastName = tbLastName.Text.Trim().ToLower();
            string address = tbAddress.Text.Trim().ToLower();
            string phoneNumber = tbPhoneNumber.Text.Trim().ToLower();
            int department = comboDepartement.SelectedIndex;
            string baseSalary = tbSalery.Text.Trim();

            if (string.IsNullOrEmpty(firstName))
            {
                LblError.Content = "FirstName is Valide";
                IsValid = false;
            }
            else if (string.IsNullOrEmpty(lastName))
            {
                LblError.Content = "LastName is Valide";
                IsValid = false;

            }
            else if (string.IsNullOrEmpty(address))
            {
                LblError.Content = "Address is Valide";
                IsValid = false;
            }
            else if (!UInt64.TryParse(phoneNumber,out ulong p))
            {
                LblError.Content = "PhoneNumber is Valide";
                IsValid = false;
            }
            else if (comboDepartement.SelectedIndex < 0)
            {
                LblError.Content = "Departement is Valide";
                IsValid = false;
            }
            else if (!UInt64.TryParse(baseSalary, out ulong b))
            {
                LblError.Content = "Salary is Valide";
                IsValid = false;
            }
            else
            {
                LblError.Content = "";
            }
            return IsValid;
        }
    }
}
