using Dapper;
using Npgsql;
using OtusHW8.Models;
using System.Text;

Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
Console.OutputEncoding = Console.InputEncoding = Encoding.Unicode;

var con = new NpgsqlConnection(
    connectionString: "Server=localhost;Port=54329;User Id=postgres;Password=postgres123;Database=testdb;");
con.Open();
using var cmd = new NpgsqlCommand();
cmd.Connection = con;

await CreateTablesIfNotExist(cmd);

WriteDbItemsToConsole(await GetAllUsers(con));
WriteDbItemsToConsole(await GetAllCategories(con));
WriteDbItemsToConsole(await GetAllAdvertisments(con));

Console.WriteLine("Добавление пользователя");

Console.WriteLine("Введите имя:");
var firstName = Console.ReadLine();

Console.WriteLine("Введите фамилию:");
var lastName = Console.ReadLine();

var age = 0;

while (age <= 0)
{
    Console.WriteLine("Введите возраст:");
    var ageString = Console.ReadLine();

    if (!int.TryParse(ageString, out age) || age <= 0)
    {
        Console.WriteLine("Неверный ввод!");
        continue;
    }
}

await InsertUser(con, new User
{
    Id = -1,
    FirstName = firstName,
    LastName = lastName,
    Age = age
});

Console.WriteLine("Пользователь добавлен");
WriteDbItemsToConsole(await GetAllUsers(con));

Console.ReadKey();

static async Task CreateTablesIfNotExist(NpgsqlCommand cmd)
{
    cmd.CommandText = $"CREATE TABLE IF NOT EXISTS {User.TableName} (id SERIAL PRIMARY KEY," +
        "first_name VARCHAR(255)," +
        "last_name VARCHAR(255)," +
        "age INT)";
    await cmd.ExecuteNonQueryAsync();

    cmd.CommandText = $"CREATE TABLE IF NOT EXISTS {Category.TableName} (id SERIAL PRIMARY KEY," +
        "name VARCHAR(255))";
    await cmd.ExecuteNonQueryAsync();

    cmd.CommandText = $"CREATE TABLE IF NOT EXISTS {Advertisment.TableName} (id SERIAL PRIMARY KEY," +
        "name VARCHAR(255)," +
        "description VARCHAR(255)," +
        "creatorId INT references users(id)," +
        "categoryId INT references categories(id)," +
        "price MONEY)";
    await cmd.ExecuteNonQueryAsync();
}

static async Task InsertUser(NpgsqlConnection con, User user)
{
    string sqlCommand = $"INSERT INTO {User.TableName} (first_name, last_name, age) VALUES (@firstName, @lastName, @age)";

    var queryArguments = new
    {
        firstName = user.FirstName,
        lastName = user.LastName,
        age = user.Age,
    };

    await con.ExecuteAsync(sqlCommand, queryArguments);
}

static async Task<IEnumerable<User>> GetAllUsers(NpgsqlConnection con)
{
    return await con.QueryAsync<User>(
        $"SELECT * FROM {User.TableName}");
}

static async Task<IEnumerable<Category>> GetAllCategories(NpgsqlConnection con)
{
    return await con.QueryAsync<Category>(
        $"SELECT * FROM {Category.TableName}");
}

static async Task<IEnumerable<Advertisment>> GetAllAdvertisments(NpgsqlConnection con)
{
    return await con.QueryAsync<Advertisment>(
        $"SELECT * FROM {Advertisment.TableName}");
}

static void WriteDbItemsToConsole(IEnumerable<IDbItem> items)
{
    foreach(var item in items)
    {
        Console.WriteLine(item.ToString());
    }
}

