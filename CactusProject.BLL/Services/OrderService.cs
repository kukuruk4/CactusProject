using System;
using CactusProject.BLL.DTO;
using CactusProject.DAL.Entities;
using CactusProject.BLL.BusinessModels;
using CactusProject.DAL.Interfaces;
using CactusProject.BLL.Infrastructure;
using CactusProject.BLL.Interfaces;
using System.Collections.Generic;
using AutoMapper;

namespace CactusProject.BLL.Services
{
    public class OrderService : IOrderService
    {
        IUnitOfWork Database { get; set; }

        public OrderService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public void MakeOrder(OrderDTO orderDto)
        {
            Cactus cactus = Database.Cactuses.Get(orderDto.PhoneId);

            // валидация
            if (cactus == null)
                throw new ValidationException("Телефон не найден", "");
            // применяем скидку
            decimal sum = new Discount(0.1m).GetDiscountedPrice(cactus.Price);
            Order order = new Order
            {
                Date = DateTime.Now,
                Address = orderDto.Address,
                CactusID = cactus.Id,
                Sum = sum,
                PhoneNumber = orderDto.PhoneNumber
            };
            Database.Orders.Create(order);
            Database.Save();
        }

        public IEnumerable<CactusDTO> GetPhones()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Cactus, CactusDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Cactus>, List<CactusDTO>>(Database.Cactuses.GetAll());
        }

        public CactusDTO GetPhone(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id телефона", "");
            var cactus = Database.Cactuses.Get(id.Value);
            if (cactus == null)
                throw new ValidationException("Телефон не найден", "");

            return new CactusDTO { Country = cactus.Country, Id = cactus.Id, Name = cactus.Name, Price = cactus.Price };
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}