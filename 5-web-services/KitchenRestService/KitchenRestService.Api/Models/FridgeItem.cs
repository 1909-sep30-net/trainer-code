using System;

namespace KitchenRestService.Api.Models
{
    public class FridgeItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Expiration { get; set; }
    }
}
