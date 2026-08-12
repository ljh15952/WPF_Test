using System.Windows;
using System.Windows.Controls;
using WpfApp1;

namespace WpfBeginner
{
    public partial class MainWindow : Window
    {

        private List<Employee> employees;

        public MainWindow()
        {
            InitializeComponent();

            LoadEmployees();
        }

        private void LoadEmployees()
        {
            employees = new List<Employee>
            {
                new Employee { Id = 1, Name = "John Doe", Age = 30, Department = "HR" },
                new Employee { Id = 2, Name = "Jane Smith", Age = 25, Department = "IT" },
                new Employee { Id = 3, Name = "Mike Johnson", Age = 35, Department = "Finance" },
                new Employee { Id = 4, Name = "Emily Davis", Age = 28, Department = "Marketing" }
            };
            dgEmployees.ItemsSource = employees;
        }

        private void EmployeeDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgEmployees.SelectedItem is Employee selectedEmployee)
            {
                txtSelectedEmployee.Text = $"Selected Employee: {selectedEmployee.Name}, Age: {selectedEmployee.Age}, Department: {selectedEmployee.Department}";
            }
        }


        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchName = txtSearchName.Text.ToLower();
            List<Employee> filteredEmployees = employees.Where(emp => emp.Name.ToLower().Contains(searchName)).ToList();
            dgEmployees.ItemsSource = filteredEmployees;
        }

        private void ShowAllButton_Click(object sender, RoutedEventArgs e)
        {
            txtSearchName.Clear();
            dgEmployees.ItemsSource = employees;
        }
    }
}
