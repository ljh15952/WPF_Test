using System.Windows;
using System.Windows.Controls;

namespace WpfBeginner
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(
            object sender,
            RoutedEventArgs e)
        {
            cmbDepartment.SelectedIndex = 0;
            chkActive.IsChecked = true;

            UpdateStatus();
        }

        private void NameTextBox_TextChanged(
            object sender,
            TextChangedEventArgs e)
        {
            if (txtNameLength == null)
            {
                return;
            }

            txtNameLength.Text =
                $"입력 글자: {txtName.Text.Length} / 10";

            UpdateStatus();
        }

        private void DepartmentComboBox_SelectionChanged(
            object sender,
            SelectionChangedEventArgs e)
        {
            UpdateStatus();
        }

        private void ActiveCheckBox_Checked(
            object sender,
            RoutedEventArgs e)
        {
            UpdateStatus();
        }

        private void ActiveCheckBox_Unchecked(
            object sender,
            RoutedEventArgs e)
        {
            UpdateStatus();
        }

        private void ActionButton_Click(
            object sender,
            RoutedEventArgs e)
        {
            if (sender is not Button button)
            {
                return;
            }

            string action =
                button.Tag?.ToString() ?? "";

            if (action == "REGISTER")
            {
                RegisterEmployee();
            }
            else if (action == "CLEAR")
            {
                ClearForm();
            }
        }

        private void RegisterEmployee()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show(
                    "이름을 입력하세요.");

                txtName.Focus();

                return;
            }

            string department =
                GetSelectedDepartment();

            bool isActive =
                chkActive.IsChecked == true;

            string activeText =
                isActive ? "재직 중" : "퇴직";

            MessageBox.Show(
                $"이름: {txtName.Text}\n" +
                $"부서: {department}\n" +
                $"상태: {activeText}",
                "등록 정보");
        }

        private void ClearForm()
        {
            txtName.Clear();

            cmbDepartment.SelectedIndex = 0;

            chkActive.IsChecked = true;

            txtName.Focus();

            UpdateStatus();
        }

        private void UpdateStatus()
        {
            if (txtStatus == null ||
                txtName == null ||
                cmbDepartment == null ||
                chkActive == null)
            {
                return;
            }

            string name =
                string.IsNullOrWhiteSpace(txtName.Text)
                    ? "(미입력)"
                    : txtName.Text;

            string department =
                GetSelectedDepartment();

            string activeText =
                chkActive.IsChecked == true
                    ? "재직 중"
                    : "퇴직";

            txtStatus.Text =
                $"이름: {name}\n" +
                $"부서: {department}\n" +
                $"상태: {activeText}";
        }

        private string GetSelectedDepartment()
        {
            if (cmbDepartment.SelectedItem
                is ComboBoxItem item)
            {
                return item.Content?.ToString() ?? "";
            }

            return "";
        }
    }
}
