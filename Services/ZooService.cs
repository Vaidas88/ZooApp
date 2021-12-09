using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            _connection.Open();

            var command = new SqlCommand("SELECT * FROM dbo.Zoo;", _connection);
            var data = command.ExecuteReader();

            while (data.Read())
            {
                _animals.Add(new AnimalModel()
                {
                    Id = data.GetInt32(0),
                    Name = data.GetString(1),
                    Description = data.GetString(2),
                    Gender = data.GetString(3),
                    Age = data.GetInt32(4)
                });
            }

            _connection.Close();

            return _animals;
        }

        internal void AddAnimal(AnimalModel animal)
        {
            _connection.Open();

            var sql = $"INSERT INTO dbo.Zoo (Name, Description, Gender, Age) VALUES ('{animal.Name}', '{animal.Description}', '{animal.Gender}', {animal.Age});";
            var command = new SqlCommand(sql, _connection);
            command.ExecuteNonQuery();

            _connection.Close();
        }

        internal void EditAnimal(AnimalModel animal)
        {
            _connection.Open();

            var sql = $"UPDATE dbo.Zoo SET Name='{animal.Name}', Description='{animal.Description}', Gender='{animal.Gender}', Age={animal.Age} WHERE Id={animal.Id};";
            var command = new SqlCommand(sql, _connection);
            command.ExecuteNonQuery();

            _connection.Close();
        }

        internal void DeleteAnimal(int id)
        {
            _connection.Open();

            var sql = $"DELETE FROM dbo.Zoo WHERE Id = {id};";
            var command = new SqlCommand(sql, _connection);
            command.ExecuteNonQuery();

            _connection.Close();
        }

        internal AnimalModel GetSingle(int id)
        {
            _connection.Open();

            var sql = $"SELECT * FROM dbo.Zoo WHERE Id = {id};";
            var command = new SqlCommand(sql, _connection);
            var data = command.ExecuteReader();
            data.Read();

            var animal = new AnimalModel()
            {
                Id = data.GetInt32(0),
                Name = data.GetString(1),
                Description = data.GetString(2),
                Gender = data.GetString(3),
                Age = data.GetInt32(4)
            };

            _connection.Close();

            return animal;
        }
    }
}
