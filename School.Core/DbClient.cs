using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using School.Core.Models;

namespace School.Core
{
    public class DbClient : IDbClient
    {
        private readonly IMongoCollection<Student> _students;
        public DbClient(IOptions<SchoolDbConfig> options)
        {
            var client = new MongoClient(options.Value.Connection_String);
            var database = client.GetDatabase(options.Value.Database_Name);
            _students = database.GetCollection<Student>(options.Value.Students_Collection_Name);
        }

        public IMongoCollection<Student> GetStudentCollection() => _students;
    }
}
