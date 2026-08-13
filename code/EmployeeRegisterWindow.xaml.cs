using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// EmployeeRegisterWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class EmployeeRegisterWindow : Window
    {

        public Employee NewEmployee { get; private set; }

        public EmployeeRegisterWindow()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("名前を入力してください。", "エラー", MessageBoxButton.OK, MessageBoxImage.Error);
                txtName.Focus();
                return;
            }

            string department = "";
            if (cmbDepartment.SelectedItem is ComboBoxItem item)
            {
                department = item.Content.ToString() ?? "";
            }

            string status = chkActive.IsChecked == true ? "Active" : "Inactive";

            NewEmployee = new Employee
            {
                Name = txtName.Text.Trim(),
                Department = department,
            };
            DialogResult = true;
        }



        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
