
using System;
using System.Collections.ObjectModel;
using WareHouse.Helper;
using WareHouse.Model;

namespace WareHouse.ViewModel
{
    class ProductViewModel
    {
        string path = "../../products.json";
        public ObservableCollection<Product> ProductList { get; set; } = new ObservableCollection<Product>();

        public ProductViewModel()
        {
            ObservableCollection<Product> item = JsonFileReader.Read<ObservableCollection<Product>>("../../products.json");
            this.ProductList = item;
        }

        public ObservableCollection<Product> getListItemsById(int id)
        {
            ObservableCollection<Product> list = new ObservableCollection<Product>();
            foreach (Product item in this.ProductList)
            {
                if (item.WarehouseId == id)
                {
                    Console.WriteLine(item);
                    list.Add(item);
                }
            }
            return list;
        }
        public int MaxId()
        {
            int max = 0;
            foreach (var item in this.ProductList)
            {
                if (max < item.Id) max = item.Id;
            }
            return max;
        }

        public void saveToJson()
        {
            JsonFileReader.Write(path, this.ProductList);
        }
    }
}
