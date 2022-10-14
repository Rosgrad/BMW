using BMW.Dal.Interfaces;
using BMW.Domain.BaseResponse;
using BMW.Domain.Entity;
using BMW.Domain.Enum;
using BMW.Domain.Extensions;
using BMW.Domain.ViewModel.Cars;
using BMW.Servise.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IBaseResponse<Cars>> CreateCar(CarsViewModel model)
        {
            try
            {
                var car = new Cars()
                {
                    Name = model.Name,
                    Description = model.Description,
                    DataCreate=DateTime.Now,
                    TypeCar = (TypeCar)Convert.ToInt32(model.TypeCar),
                    Price = model.Price
                };
                await _carRepository.Create(car);
                return new BaseResponse<Cars>()
                {
                    StatusCode = StatusCode.OK,
                    Data = car
                };
            }
            catch(Exception ex)
            {
                return new BaseResponse<Cars>()
                {
                    Descriprion = $"[Create] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public Task<IBaseResponse<bool>> DeleteCar(int id)
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

        public async Task<IBaseResponse<Cars>> EditCars(int id, CarsViewModel model)
        {
            var baseResponse = new BaseResponse<Cars>();
            try
            {
                var car = await _carRepository.GetAll().FirstOrDefaultAsync(x=> x.Id == id);    
                if (car== null)
                {
                    return new BaseResponse<Cars>()
                    {
                        Descriprion = "Cars not found",
                        StatusCode = StatusCode.CarNotFound
                    };
                }
                car.Description = car.Description;
                car.Price= car.Price;
                car.DataCreate =DateTime.Now;
                car.Name = car.Name;

                await _carRepository.Update(car);
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Cars>()
                {
                    Descriprion = $"[Edit]:{ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public BaseResponse<Dictionary<int, string>> GetTypes()
        {
            try
            {
                var types = ((TypeCar[])Enum.GetValues(typeof(TypeCar)))
                    .ToDictionary(k => (int)k, t => t.GetDisplayName());

                return new BaseResponse<Dictionary<int, string>>()
                {
                    Data = types,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Dictionary<int, string>>()
                {
                    Descriprion = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}
