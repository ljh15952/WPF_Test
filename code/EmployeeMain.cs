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
                new Employee { Id = 1, Name = "John Doe", Age = 30, Department = "Manager" },
                new Employee { Id = 2, Name = "Jane Smith", Age = 25, Department = "Developer" },
                new Employee { Id = 3, Name = "Sam Brown", Age = 28, Department = "Designer" }
            };
            dgEmployees.ItemsSource = employees;
        }

        private void RegisterEmployee_Click(object sender, RoutedEventArgs e)
        {
            EmployeeRegisterWindow registerWindow = new EmployeeRegisterWindow();
            registerWindow.Owner = this;
            bool? result = registerWindow.ShowDialog();

            if (result == true)
            {
                Employee employee = registerWindow.NewEmployee;
                employee.Id = employees.Count + 1; // Assign a new ID
                employees.Add(employee);
                dgEmployees.ItemsSource = null;
                dgEmployees.ItemsSource = employees;
            }
        }

    }
}
