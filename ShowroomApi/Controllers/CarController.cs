using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using ShowroomApi.Models.DTOs;
using ShowroomApi.Models;
using ShowroomApi.Data;
using Microsoft.EntityFrameworkCore;

namespace ShowroomApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ShowroomContext db;

        public CarController(ShowroomContext _db)
        {
            db = _db;
        }

        // For Cars CRUD


        [HttpGet]

        public IActionResult GetCars()
        {
            return Ok(db.Cars.ToList());
        }

        [HttpPost]
        public IActionResult AddCars(CarsDTO data)
        {
            Car Cars = new Car()
            {
                Name = data.Name,
                ManufactureId = data.ManufactureId,
                Color = data.Color,
                Power = data.Power,
                Price = data.Price,
            };

            var addCar = db.Cars.Add(Cars);
            db.SaveChanges();
            return Ok(addCar);
        }

        [HttpPut]
        public IActionResult EditCar(int id, CarsDTO data)
        {

            var CarstoUpdate = db.Cars.Find(id);

            CarstoUpdate.Name = data.Name;
            CarstoUpdate.Color = data.Color;
            CarstoUpdate.Power = data.Power;
            CarstoUpdate.Price = data.Price;



            var updatetoCar = db.Cars.Update(CarstoUpdate);
            db.SaveChanges();
            return Ok(updatetoCar.Entity);
        }

        [HttpDelete]
        public IActionResult DeleteCar(int id)
        {

            var CarstoDelete = db.Cars.Find(id);

            var DeletetoCars = db.Cars.Remove(CarstoDelete);
            db.SaveChanges();
            return Ok(DeletetoCars.Entity);
        }
        //Filter

        [HttpGet("{Id}")]
        public IActionResult GetManufacturerbyCar(int Id)
        {
            var manufacture = db.Cars.Where(o => o.ManufactureId == Id).ToList();
            return Ok(manufacture);

        }
    }
}
