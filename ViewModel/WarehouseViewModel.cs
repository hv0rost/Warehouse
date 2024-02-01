using System.Collections.ObjectModel;
using WareHouse.Helper;
using WareHouse.Model;

namespace WareHouse.ViewModel
{
    class WarehouseViewModel
    {
        string path = "../../warehouses.json";
        public ObservableCollection<Warehouse> WarehousetList { get; set; } = new ObservableCollection<Warehouse>();

        public WarehouseViewModel()
        {
            ObservableCollection<Warehouse> item = JsonFileReader.Read<ObservableCollection<Warehouse>>(path);
            this.WarehousetList = item;
        }
        public int MaxId()
        {
            int max = 0;
            foreach (var item in this.WarehousetList)
            {
                if (max < item.Id) max = item.Id;
            }
            return max;
        }

        public void saveToJson()
        {
            JsonFileReader.Write(path, this.WarehousetList);
        }
    }
}
