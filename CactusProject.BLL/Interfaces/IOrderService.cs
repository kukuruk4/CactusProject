using CactusProject.BLL.DTO;
using System.Collections.Generic;
namespace CactusProject.BLL.Interfaces
{
    public interface IOrderService
    {
        void MakeOrder(OrderDTO orderDto);
         CactusDTO GetPhone(int? id);
        IEnumerable<CactusDTO> GetPhones();
        void Dispose();
    }
}