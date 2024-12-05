using Emp_Dapper_Useing_3databases.Entites;

namespace Emp_Dapper_Useing_3databases.Interface
{
    public interface IOrdersRepository
    {
        Task<List<Orders>> GetOrders();
        Task<Orders> GetOrderById(int orderid);
        Task<int> AddOrder(Orders orderdetail);
        Task<bool> DeleteOrderById(int orderid);
        Task<bool> UpdateOrder(Orders orderdetail);
    }
}
