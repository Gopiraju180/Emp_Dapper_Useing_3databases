using Emp_Dapper_Useing_3databases.Dtos;
using Emp_Dapper_Useing_3databases.Entites;
using Emp_Dapper_Useing_3databases.Interface;

namespace Emp_Dapper_Useing_3databases.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IOrdersRepository _ordersRepository;
        public OrdersService(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;       
        }
        public async Task<int> AddOrder(OrdersDto orderdetail)
        {
            Orders order = new Orders();
            order.orderid = orderdetail.orderid;
            if (orderdetail?.Flag == "Hyderabad")//Here Flag is used to apply the conditions.
            {
                order.ordername = orderdetail.ordername + '-' + orderdetail.orderlocation;
            }
            else
            {
                order.ordername = orderdetail.ordername;
            }

            order.orderlocation = orderdetail.orderlocation;

            var res = await _ordersRepository.AddOrder(order);
            return res;

        }

        public async Task<bool> DeleteOrderById(int orderid)
        {
            await _ordersRepository.DeleteOrderById(orderid);
            return true;
        }

        public async Task<OrdersDto> GetOrderById(int orderid)
        {
            var res = await _ordersRepository.GetOrderById(orderid);
            OrdersDto orderdto = new OrdersDto();
            orderdto.orderid = res.orderid;
            orderdto.ordername = res.ordername;
            orderdto.orderlocation = res.orderlocation;
            return orderdto;
        }

        public async Task<List<OrdersDto>> GetOrders()
        {
            List<OrdersDto> lstorderdto = new List<OrdersDto>();
            var res = await _ordersRepository.GetOrders();
            foreach (Orders order in res)
            {
                OrdersDto ordersDto = new OrdersDto();
                ordersDto.orderid = order.orderid;
                ordersDto.ordername = order.ordername;
                ordersDto.orderlocation = order.orderlocation;
                lstorderdto.Add(ordersDto);//Add the orders to list here

            }
            return lstorderdto;
        }

        public async Task<bool> UpdateOrder(OrdersDto orderdetail)
        {
            Orders obj = new Orders();
            obj.orderid = orderdetail.orderid;
            obj.ordername = orderdetail.ordername;
            obj.orderlocation = orderdetail.orderlocation;
            await _ordersRepository.UpdateOrder(obj);
            return true;
        }
    }
}
