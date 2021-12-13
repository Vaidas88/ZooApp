using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using ZooApp.Models;

namespace ZooApp.Services
{
    public class SponsorService
    {
        private readonly SqlConnection _connection;
        private readonly ZooService _zooService;
        public SponsorService(SqlConnection connection, ZooService zooService)
        {
            _connection = connection;
            _zooService = zooService;
        }
        public List<SponsorModel> GetAll()
        {
            List<SponsorModel> _sponsors = new List<SponsorModel>();

            _connection.Open();
            string sql = "SELECT Id, FirstName, LastName, Amount, AnimalId as SponsoredAnimalId FROM dbo.Sponsors;";
            var command = new SqlCommand(sql, _connection);
            var result = command.ExecuteReader();
            while (result.Read())
            {
                _sponsors.Add(new SponsorModel()
                {
                    Id = result.GetInt32(0),
                    FirstName = result.GetString(1),
                    LastName = result.GetString(2),
                    Amount = result.GetInt32(3),
                    SponsoredAnimalId = result.GetInt32(4),
                    SponsoredAnimal = _zooService.GetSingle(result.GetInt32(4))
                });
            }

            _connection.Close();

            return _sponsors;
        }

        internal void AddSponsor(SponsorModel sponsor)
        {
            string sql = $"INSERT INTO dbo.Sponsors (FirstName, LastName, Amount, AnimalId) VALUES ('{sponsor.FirstName}', '{sponsor.LastName}', '{sponsor.Amount}', {sponsor.SponsoredAnimalId});";
            _connection.Query(sql);
        }
        internal void EditSponsor(SponsorModel sponsor)
        {
            string sql = $"UPDATE dbo.Sponsors SET FirstName='{sponsor.FirstName}', LastName='{sponsor.LastName}', Amount='{sponsor.Amount}', AnimalId={sponsor.SponsoredAnimalId} WHERE Id={sponsor.Id};";
            _connection.Query(sql);
        }

        internal void DeleteSponsor(int id)
        {
            string sql = $"DELETE FROM dbo.Sponsors WHERE Id = {id};";
            _connection.Query(sql);
        }

        internal SponsorFormModel GetSingle(int id)
        {
            string sql = $"SELECT Id, FirstName, LastName, Amount, AnimalId as SponsoredAnimalId FROM dbo.Sponsors WHERE Id = {id};";

            return _connection.QuerySingle<SponsorFormModel>(sql);
        }
    }
}
