using System.Collections.Generic;

namespace ClientsTable.Entities
{
    public class CityEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ClientEntity> Clients { get; set; }
    }
}
