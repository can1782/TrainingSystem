using System.Collections.Generic;
using System.Threading.Tasks;
using TrainingSystem.Shared.Dtos;

namespace TrainingSystem.Services.Training.Services
{
    public interface ITrainingService
    {
        Task<Response<List<Models.Training>>>GetAll();

        Task<Response<Models.Training>> GetTrainingById(int id);

        Task<Response<NoContent>>Save(Models.Training training);

        Task<Response<NoContent>> Update(Models.Training training);

        Task<Response<NoContent>> Delete(int id);

    }
}
