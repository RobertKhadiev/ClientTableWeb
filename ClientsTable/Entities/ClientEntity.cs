using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientsTable.Entities
{
    public class ClientEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? CityId { get; set; }
        public CityEntity City { get; set; }
        public int PurchaseAmount { get; set; }
    }
}
