namespace OtusHW8.Models
{
    internal class Category : IDbItem
    {
        public Category() { }
        public Category(int id, string name) 
        { 
            Id = id;
            Name = name;
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public override string ToString() => $"Id: {Id}, Name: {Name}";

        public static string TableName { get => "categories"; }
    }
}
