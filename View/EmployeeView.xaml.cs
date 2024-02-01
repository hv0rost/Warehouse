using System;
using System.Windows;
using WareHouse.Model;
using WareHouse.ViewModel;


namespace WareHouse.View
{
    public partial class EmployeeView : Window
    {
        EmployeeViewModel employeeViewModel = new EmployeeViewModel();
        int warehouseId;
        public EmployeeView(int propsId)
        {
            InitializeComponent();
            this.warehouseId = propsId;
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            EmployeeList.ItemsSource = employeeViewModel.getListItemsById(warehouseId);
            NewEmployee winNewEmployee = new NewEmployee
            {
                Title = "Новый сотрудник",
                Owner = this
            };

            int lastIdIndex = employeeViewModel.MaxId() + 1;
            Employee employee = new Employee
            {
                Id = lastIdIndex,
                WarehouseId = warehouseId
            };

            winNewEmployee.DataContext = employee;
            if (winNewEmployee.ShowDialog() == true)
            {
                employeeViewModel.EmployeeList.Add(employee);
            }
            EmployeeList.ItemsSource = employeeViewModel.getListItemsById(warehouseId);
            employeeViewModel.saveToJson();
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            EmployeeList.ItemsSource = employeeViewModel.getListItemsById(warehouseId);
            NewEmployee winNewEmployee = new NewEmployee
            {
                Title = "Редактирование сотрудника",
                Owner = this
            };

            Employee employee = EmployeeList.SelectedItem as Employee;

            if (employee != null)
            {
                Employee tempEmployee = new Employee
                {
                    Id = employee.Id,
                    WarehouseId = employee.WarehouseId,
                    Fio = employee.Fio,
                    Position = employee.Position,
                    PhoneNumber = employee.PhoneNumber, 
                };

                winNewEmployee.DataContext = tempEmployee;
                if (winNewEmployee.ShowDialog() == true)
                {
                    employee.Id = tempEmployee.Id;
                    employee.WarehouseId = tempEmployee.WarehouseId;
                    employee.Fio = tempEmployee.Fio;
                    employee.Position = tempEmployee.Position;
                    employee.PhoneNumber = tempEmployee.PhoneNumber;

                    EmployeeList.ItemsSource = null;
                    EmployeeList.ItemsSource = employeeViewModel.EmployeeList;
                }

            }
            else
            {
                MessageBox.Show("Необходимо выбрать сотрудника для редактирования",
                    "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            EmployeeList.ItemsSource = employeeViewModel.getListItemsById(warehouseId);
            employeeViewModel.saveToJson();
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            EmployeeList.ItemsSource = employeeViewModel.getListItemsById(warehouseId);
            Employee employee = (Employee)EmployeeList.SelectedItem;

            if (employee != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить сотрудника: [ "
                    + employee.Id + " ]", "Предупреждение", MessageBoxButton.OKCancel, MessageBoxImage.Warning);

                if (result == MessageBoxResult.OK) employeeViewModel.EmployeeList.Remove(employee);
                else MessageBox.Show("Необходимо выбрать сотрудника", "Предупреждение",
                    MessageBoxButton.OK, MessageBoxImage.Warning);

            }
            employeeViewModel.saveToJson();
            EmployeeList.ItemsSource = employeeViewModel.getListItemsById(warehouseId);
        }
    }
}
