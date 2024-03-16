namespace OtusHW8.Models
{
    internal class User : IDbItem
    {
        public User() { }
        public User(int id, string first_name, string last_name, int age)
        {
            Id = id;
            FirstName = first_name;
            LastName = last_name;
            Age = age;
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public override string ToString() => $"Id: {Id}, FirstName: {FirstName}, LastName: {LastName}, Age: {Age}";

        public static string TableName { get => "users"; }
    }
}
