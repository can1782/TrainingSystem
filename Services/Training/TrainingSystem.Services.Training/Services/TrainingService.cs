using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using TrainingSystem.Shared.Dtos;

namespace TrainingSystem.Services.Training.Services
{

    public class TrainingService : ITrainingService
    {
        private readonly IConfiguration _configuration;
        private readonly IDbConnection _dbConnection;

        public TrainingService(IConfiguration configuration)
        {
            _configuration = configuration;

            _dbConnection = new NpgsqlConnection(_configuration.GetConnectionString("PostgreSql"));
        }
        public Task<Response<NoContent>> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Response<List<Models.Training>>> GetAll()
        {
            var trainings = await _dbConnection.QueryAsync<Models.Training>("Select * from training");

            return Response<List<Models.Training>>.Success(trainings.ToList(),200);
        }

        public async Task<Response<Models.Training>> GetTrainingById(int id)
        {
            var training = (await _dbConnection.QueryAsync<Models.Training>("Select * from training where id=@Id",new {Id = id})).SingleOrDefault();

            if (training == null)
            {
                return Response<Models.Training>.Fail("Training not found", 404);
            }

            return Response<Models.Training>.Success(training, 200);
        }

        public async Task<Response<NoContent>> Save(Models.Training training)
        {
            var status = await _dbConnection.ExecuteAsync("INSERT INTO training(name,begindate,enddate,status)VALUES(@Name,@BeginDate,@EndDate,@Status)", training);

            if (status > 0)
            {
                return Response<NoContent>.Success(204);
            }

            return Response<NoContent>.Fail("An error occured while saving",500);
        }

        public async Task<Response<NoContent>> Update(Models.Training training)
        {
            var status = await _dbConnection.ExecuteAsync("UPDATE training set name=@Name,begindate=@BeginDate,enddate=@EndDate,status=@Status", training);

            if (status > 0)
            {
                return Response<NoContent>.Success(204);
            }

            return Response<NoContent>.Fail("An error occured while updating", 500);
        }
    }
}
