using Microsoft.AspNetCore.Mvc;
using TrainingSystem.Shared.Dtos;

namespace TrainingSystem.Shared.ControllerBases
{
    public class CustomBaseController : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        public IActionResult CreateActionResultInstance<T>(Response<T> response)
        {
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }
    }
}
