namespace DATA.Entities
{
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Product Product { get; set; }
    }
}