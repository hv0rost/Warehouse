

namespace WareHouse.Model
{
    public class Employee
    {

        public int Id { get; set; }
        public int WarehouseId { get; set; }
        public string Fio { get; set; }
        public string Position{ get; set; }
        public string PhoneNumber { get; set; }

        public Employee() { }

        public Employee(int Id, int WarehouseId, string Fio, string Position, string PhoneNumber)
        {
            this.Id = Id;
            this.WarehouseId = WarehouseId;
            this.Fio = Fio;
            this.Position = Position;
            this.PhoneNumber = PhoneNumber;
        }
    }
}
