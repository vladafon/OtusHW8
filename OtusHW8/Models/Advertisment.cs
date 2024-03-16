namespace OtusHW8.Models
{
    internal class Advertisment : IDbItem
    {
        public Advertisment() { }
        public Advertisment(int id, string name, string description, int creator_id, int category_id, decimal price)
        {
            Id = id;
            Name = name;
            Description = description;
            CreatorId = creator_id;
            CategoryId = category_id;
            Price = price;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int CreatorId { get; set; }

        public int CategoryId { get; set; }

        public decimal Price { get; set; }

        public override string ToString() => $"Id: {Id}, Name: {Name}, Description: {Description}, CreatorId: {CreatorId}, CategoryId: {CategoryId}, Price: {Price}";

        public static string TableName { get => "advertisments"; }
    }
}
