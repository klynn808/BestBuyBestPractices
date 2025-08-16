using Dapper;
using Microsoft.Extensions.Configuration.Json;
using MySql.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BestBuyBestPractices
{
    public class DapperDepartmentRepository : IDepartmentRepository
    {
        private readonly IDbConnection _conn;

        //constructor
        public DapperDepartmentRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public void CreateDepartment(string name)
        {
            _conn.Execute("INSERT INTO departments (Name) VALUES (@name)",
                new { name = name });
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            return _conn.Query<Department>("SELECT * FROM departments");
        }

        public void InsertDepartment(string name)
        {
            _conn.Execute("INSERT INTO departments (Name) VALUES (@name)", 
                new { name = name });
        }
        public void UpdateDepartment(int id, string newName)
        {
            _conn.Execute("UPDATE departments SET Name = @newName WHERE DepartmentID = @id;", new { newName = newName, id = id });
        }
    }
}
