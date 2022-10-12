using BMW.Domain.BaseResponse;
using BMW.Domain.Entity;
using BMW.Domain.ViewModel.Cars;

namespace BMW.Servise.Interfaces
{
    public interface ICarService
    {
        IBaseResponse<List<Cars>> GetCars();

        Task<IBaseResponse<List<CarsViewModel>>> GetCar(int id);

        Task<IBaseResponse<Cars>> CreateCar(CarsViewModel car);

        Task<IBaseResponse<bool>> DeleteCar(int id);

        Task<IBaseResponse<Cars>> GetCarsName(string name);

        Task<IBaseResponse<Cars>> EditCars(int id, CarsViewModel model);

    }
}
