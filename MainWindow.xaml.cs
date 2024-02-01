using System.Windows;
using WareHouse.Model;
using WareHouse.View;
using WareHouse.ViewModel;

namespace WareHouse
{
    public partial class MainWindow : Window
    {
        WarehouseViewModel warehouseViewModel = new WarehouseViewModel();
        public MainWindow()
        {
            InitializeComponent();

            WarehousetList.ItemsSource = warehouseViewModel.WarehousetList;
        }

        private void btnOpenProducts_Click(object sender, RoutedEventArgs e)
        {
            Warehouse selectedWarehouse = WarehousetList.SelectedItem as Warehouse;

            if (selectedWarehouse != null)
            {
                string title = "Товары склада #" + selectedWarehouse.Id;
                ProductView productWindow = new ProductView(selectedWarehouse.Id)
                {
                    Title = title,
                    Owner = this
                };
                ProductViewModel productViewModel = new ProductViewModel();
                productWindow.ProductList.ItemsSource = productViewModel.getListItemsById(selectedWarehouse.Id);

                if (productWindow.ShowDialog() == true)
                { }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать склад", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void btnOpenEmployee_Click(object sender, RoutedEventArgs e)
        {
            Warehouse selectedWarehouse = WarehousetList.SelectedItem as Warehouse;

            if (selectedWarehouse != null)
            {
                string title = "Сотрудники склада #" + selectedWarehouse.Id;
                EmployeeView employeeWindow = new EmployeeView(selectedWarehouse.Id)
                {
                    Title = title,
                    Owner = this,
                };
                EmployeeViewModel employeeViewModel = new EmployeeViewModel();
                employeeWindow.EmployeeList.ItemsSource = employeeViewModel.getListItemsById(selectedWarehouse.Id);

                if (employeeWindow.ShowDialog() == true)
                { 
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать склад", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NewWarehouse winNewWarehouse = new NewWarehouse
            {
                Title = "Новый склад",
                Owner = this
            };

            int lastIdIndex = warehouseViewModel.MaxId() + 1;
            Warehouse warehouse = new Warehouse
            {
                Id = lastIdIndex,
            };

            winNewWarehouse.DataContext = warehouse;
            if (winNewWarehouse.ShowDialog() == true)
            {
                warehouseViewModel.WarehousetList.Add(warehouse);
            }

            warehouseViewModel.saveToJson();
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            NewWarehouse winNewAccountPlan = new NewWarehouse
            {
                Title = "Редактирование склада",
                Owner = this
            };

            Warehouse warehouse = WarehousetList.SelectedItem as Warehouse;

            if (warehouse != null)
            {
                Warehouse tempWarehouse= new Warehouse
                {
                    Id = warehouse.Id,
                    Location = warehouse.Location,
                    Capacity = warehouse.Capacity,
                    PhoneNumber = warehouse.PhoneNumber,
                };

                winNewAccountPlan.DataContext = tempWarehouse;
                if (winNewAccountPlan.ShowDialog() == true)
                {
                    warehouse.Id = tempWarehouse.Id;
                    warehouse.Location = tempWarehouse.Location;
                    warehouse.Capacity = tempWarehouse.Capacity;
                    warehouse.PhoneNumber = tempWarehouse.PhoneNumber;

                    WarehousetList.ItemsSource = null;
                    WarehousetList.ItemsSource = warehouseViewModel.WarehousetList;
                }

            }
            else
            {
                MessageBox.Show("Необходимо выбрать план счетов для редактирования",
                    "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            warehouseViewModel.saveToJson();
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Warehouse warehouse = (Warehouse)WarehousetList.SelectedItem;

            if (warehouse != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить склад: [ "
                    + warehouse.Id + " ]", "Предупреждение", MessageBoxButton.OKCancel, MessageBoxImage.Warning);

                if (result == MessageBoxResult.OK) warehouseViewModel.WarehousetList.Remove(warehouse);
                else MessageBox.Show("Необходимо выбрать склад", "Предупреждение",
                    MessageBoxButton.OK, MessageBoxImage.Warning);

            }
            warehouseViewModel.saveToJson();
        }
    }
}
