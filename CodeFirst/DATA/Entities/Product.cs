using System.Collections.Generic;

namespace DATA.Entities
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}