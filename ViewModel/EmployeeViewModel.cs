using System.Collections.ObjectModel;
using WareHouse.Helper;
using WareHouse.Model;

namespace WareHouse.ViewModel
{
    class EmployeeViewModel
    {
        string path = "../../employees.json";
        public ObservableCollection<Employee> EmployeeList { get; set; } = new ObservableCollection<Employee>();

        public EmployeeViewModel()
        {
            ObservableCollection<Employee> item = JsonFileReader.Read<ObservableCollection<Employee>>("../../employees.json");
            this.EmployeeList = item;
        }

        public ObservableCollection<Employee> getListItemsById(int id)
        {
            ObservableCollection<Employee> list = new ObservableCollection<Employee>();
            foreach (Employee item in this.EmployeeList)
            {
                if (item.WarehouseId == id)
                {
                    list.Add(item);
                }
            }
            return list;
        }
        public int MaxId()
        {
            int max = 0;
            foreach (var item in this.EmployeeList)
            {
                if (max < item.Id) max = item.Id;
            }
            return max;
        }

        public void saveToJson()
        {
            JsonFileReader.Write(path, this.EmployeeList);
        }
    }
}
