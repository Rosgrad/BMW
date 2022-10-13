using BMW.Domain.ViewModel.Cars;
using BMW.Servise.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BMW.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public IActionResult GetCars()
        {
            var response = _carService.GetCars();
            if(response.StatusCode== BMW.Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }
            return RedirectToAction("Error");
        }
        [HttpGet]
        public async Task<IActionResult> Save(int id)
        {
            if (id == 0)
                return PartialView();
            var response = await _carService.GetCar(id);
            if(response.StatusCode== BMW.Domain.Enum.StatusCode.OK)
            {
                return PartialView(response.Data);
            }
            ModelState.AddModelError("", response.Descriprion);
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> Save(CarsViewModel model)
        {
            ModelState.Remove("DateCreate");
            if (ModelState.IsValid)
            {
                if(model.Id==0)
                {
                    await _carService.CreateCar(model);
                }
                else
                {
                    await _carService.EditCars(model.Id, model);
                }
                return RedirectToAction("GetCars");
            }
            return View();
        }

    }
}
