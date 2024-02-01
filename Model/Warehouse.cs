using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHouse.Model
{
    public class Warehouse
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }
        public string PhoneNumber { get; set; }

        public Warehouse() { }

        public Warehouse(int Id, string Location, int Capacity, string PhoneNumber)
        {
            this.Id = Id;
            this.Location = Location;
            this.Capacity = Capacity;
            this.PhoneNumber = PhoneNumber;
        }
    }

    
}
