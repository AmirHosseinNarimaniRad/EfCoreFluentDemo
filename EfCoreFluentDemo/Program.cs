using System; 

using EfCoreFluentDemo.Data;

Console.WriteLine("EF Core demo");

using var context = new AppDbContext();
Console.WriteLine("DbContext created successfully.");