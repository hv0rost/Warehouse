using System.Windows;
using WareHouse.Model;
using WareHouse.ViewModel;

namespace WareHouse.View
{
    public partial class ProductView : Window
    {
        ProductViewModel productViewModel = new ProductViewModel();
        int warehouseId;
        public ProductView(int propsId)
        {
            InitializeComponent();
            this.warehouseId = propsId;
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            ProductList.ItemsSource = productViewModel.getListItemsById(warehouseId);
            NewProduct winNewProduct = new NewProduct
            {
                Title = "Новый продукт",
                Owner = this
            };

            int lastIdIndex = productViewModel.MaxId() + 1;
            Product product = new Product
            {
                Id = lastIdIndex,
                WarehouseId = warehouseId
            };

            winNewProduct.DataContext = product;
            if (winNewProduct.ShowDialog() == true)
            {
                productViewModel.ProductList.Add(product);
            }
            ProductList.ItemsSource = productViewModel.getListItemsById(warehouseId);
            productViewModel.saveToJson();
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            ProductList.ItemsSource = productViewModel.getListItemsById(warehouseId);
            NewProduct winNewProduct = new NewProduct
            {
                Title = "Редактирование сотрудника",
                Owner = this
            };

            Product product = ProductList.SelectedItem as Product;

            if (product != null)
            {
                Product tempProduct= new Product
                {
                    Id = product.Id,
                    WarehouseId = product.WarehouseId,
                    Name = product.Name,
                    Price = product.Price,
                    Category = product.Category,
                    Quantity = product.Quantity,
                };

                winNewProduct.DataContext = tempProduct;
                if (winNewProduct.ShowDialog() == true)
                {
                    product.Id = tempProduct.Id;
                    product.WarehouseId = tempProduct.WarehouseId;
                    product.Name = tempProduct.Name;
                    product.Price = tempProduct.Price;
                    product.Category = tempProduct.Category;

                    ProductList.ItemsSource = null;
                    ProductList.ItemsSource = productViewModel.ProductList;
                }

            }
            else
            {
                MessageBox.Show("Необходимо выбрать продукт для редактирования",
                    "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            ProductList.ItemsSource = productViewModel.getListItemsById(warehouseId);
            productViewModel.saveToJson();
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            ProductList.ItemsSource = productViewModel.getListItemsById(warehouseId);
            Product product = (Product)ProductList.SelectedItem;

            if (product != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить продукт: [ "
                    + product.Id + " ]", "Предупреждение", MessageBoxButton.OKCancel, MessageBoxImage.Warning);

                if (result == MessageBoxResult.OK) productViewModel.ProductList.Remove(product);
                else MessageBox.Show("Необходимо выбрать продукт", "Предупреждение",
                    MessageBoxButton.OK, MessageBoxImage.Warning);

            }
            productViewModel.saveToJson();
            ProductList.ItemsSource = productViewModel.getListItemsById(warehouseId);
        }

    }
}
