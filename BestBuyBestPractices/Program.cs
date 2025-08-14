
using System; 
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
using BestBuyBestPractices;
using Dapper;

internal class Program
{
    public static void Main(string[] args)
    {
        var config = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json")
                        .Build();

        string connString = config.GetConnectionString("DefaultConnection");

        IDbConnection conn = new MySqlConnection(connString);

        var departmentRepo = new DapperDepartmentRepository(conn);

        var departments = departmentRepo.GetAllDepartments();

        foreach (var dep in departments)
        {
            Console.WriteLine(dep.DepartmentID);
            Console.WriteLine(dep.Name);
        }
    }
}