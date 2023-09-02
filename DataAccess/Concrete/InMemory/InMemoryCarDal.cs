using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;//Global değişken Olarak Tanımlama.

        public InMemoryCarDal()
        {
            _cars =new List<Car>()
            { 
            new Car{CarId=1,BrandId=1,DailyPrice=500000,Description="Mersedes C200",ColorId=1,ModelYear=2019 },
            new Car{CarId=2,BrandId=1,DailyPrice=2565000,Description="Mersedes E300",ColorId=2,ModelYear=2018 },
            new Car{CarId=3,BrandId=2,DailyPrice=1550000,Description="Audio A5",ColorId=3,ModelYear=2017},
            new Car{CarId=4,BrandId=2,DailyPrice=1250000,Description="Audio A4",ColorId=3,ModelYear=2020},
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
          Car carDelete=  _cars.FirstOrDefault(c=>c.CarId==car.CarId);

            _cars.Remove(carDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int CarId)
        {
           return _cars.Where(c=>c.CarId==CarId).ToList();
        }

        public void Update(Car car)
        {
            var carUpdate = _cars.SingleOrDefault(c=>c.CarId==car.CarId);
            
            carUpdate.BrandId=car.BrandId;
            carUpdate.ColorId=car.ColorId;
            carUpdate.DailyPrice=car.DailyPrice;
            carUpdate.Description=car.Description;

        }
    }
}
