using BMW.Dal.Interfaces;
using BMW.Domain.BaseResponse;
using BMW.Domain.Entity;
using BMW.Domain.Enum;
using BMW.Domain.ViewModel.Cars;
using BMW.Servise.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMW.Servise.Implementatios
{
    public class CarsService : ICarService
    {
        private readonly IBaseRepository<Cars> _carRepository;

        public CarsService(IBaseRepository<Cars> carRepository)
        {
            _carRepository = carRepository;
        }

        public Task<IBaseResponse<Cars>> CreateCar(CarsViewModel car)
        {
            throw new NotImplementedException();
        }

        public Task<IBaseResponse<bool>> DeleteCar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IBaseResponse<Cars>> EditMedicines(int id, CarsViewModel model)
        {
            throw new NotImplementedException();
        }

        public IBaseResponse<List<Cars>> GetCars()
        {
            try
            {
                var cars = _carRepository.GetAll().ToList();
                if (!cars.Any())
                {
                    return new BaseResponse<List<Cars>>()
                    {
                        Descriprion = "Найдено 0 элементов",
                        StatusCode = StatusCode.OK
                    };
                }
                return new BaseResponse<List<Cars>>()
                {
                     Data = cars,
                     StatusCode = StatusCode.OK
                };
            }
            catch(Exception ex)
            {
                return new BaseResponse<List<Cars>>()
                {
                    Descriprion = $"[GetCars] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public Task<IBaseResponse<List<CarsViewModel>>> GetCar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IBaseResponse<Cars>> GetCarsName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
