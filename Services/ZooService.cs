using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using ZooApp.Models;

namespace ZooApp.Services
{
    public class ZooService
    {
        private readonly SqlConnection _connection;
        public ZooService(SqlConnection connection)
        {
            _connection = connection;
        }
        public List<AnimalModel> GetAll()
        {
            List<AnimalModel> _animals = new List<AnimalModel>();

            string sql = "SELECT * FROM dbo.Zoo;";
            _animals = _connection.Query<AnimalModel>(sql).ToList();

            return _animals;
        }

        internal void AddAnimal(AnimalModel animal)
        {
            string sql = $"INSERT INTO dbo.Zoo (Name, Description, Gender, Age) VALUES ('{animal.Name}', '{animal.Description}', '{animal.Gender}', {animal.Age});";
            _connection.Query(sql);
        }

        internal void EditAnimal(AnimalModel animal)
        {
            string sql = $"UPDATE dbo.Zoo SET Name='{animal.Name}', Description='{animal.Description}', Gender='{animal.Gender}', Age={animal.Age} WHERE Id={animal.Id};";
            _connection.Query(sql);
        }

        internal void DeleteAnimal(int id)
        {
            string sql = $"DELETE FROM dbo.Zoo WHERE Id = {id};";
            _connection.Query(sql);
        }

        internal AnimalModel GetSingle(int id)
        {
            string sql = $"SELECT * FROM dbo.Zoo WHERE Id = {id};";

            return _connection.QuerySingle<AnimalModel>(sql);
        }
    }
}
