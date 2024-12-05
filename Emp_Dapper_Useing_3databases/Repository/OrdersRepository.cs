using Dapper;
using Emp_Dapper_Useing_3databases.Entites;
using Emp_Dapper_Useing_3databases.Interface;
using Emp_Dapper_Useing_3databases.utils;
using System.Data;

namespace Emp_Dapper_Useing_3databases.Repository
{
    public class OrdersRepository : IOrdersRepository
    {
        IEmpConnectionFactory _connectionFactory;
        public OrdersRepository(IEmpConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;  
        }
        public async Task<int> AddOrder(Orders orderdetail)
        {
            using (IDbConnection con = _connectionFactory.MidLandSqlConnectionString())
            {
                var p=new DynamicParameters();
                p.Add("@ordername", orderdetail.ordername);
                p.Add("@orderlocation", orderdetail.orderlocation);
                p.Add("@insertvalue", DbType.Int32, direction: ParameterDirection.Output);
                await con.ExecuteScalarAsync(StoredProcedureNames.AddOrder, p, commandType: CommandType.StoredProcedure);
                int insertedid = p.Get<int>("@insertvalue");
                return insertedid;

            }
        }

        public async Task<bool> DeleteOrderById(int orderid)
        {
           using(IDbConnection con=_connectionFactory.MidLandSqlConnectionString())
            {
                var p=new DynamicParameters();
                p.Add("@orderid",orderid);
                await con.ExecuteScalarAsync(StoredProcedureNames.DeleteOrder,p, commandType: CommandType.StoredProcedure);
                return true;
            }
        }

        public async Task<Orders> GetOrderById(int orderid)
        {
            Orders order;
            using (IDbConnection con = _connectionFactory.MidLandSqlConnectionString())
            {
                var p = new DynamicParameters();
                p.Add("@orderid", orderid);
                var result = await con.QueryAsync<Orders>(StoredProcedureNames.GetOrderById, p, commandType: CommandType.StoredProcedure);
                order = result.FirstOrDefault();
                return order;
            }
        }

        public async Task<List<Orders>> GetOrders()
        {
            List<Orders> res;
            using (IDbConnection conn = _connectionFactory.MidLandSqlConnectionString())
            {
                var queryresult = await conn.QueryAsync<Orders>(StoredProcedureNames.GetOrder, CommandType.StoredProcedure);
                res = queryresult.ToList();
                return res;
            }
        }

        public async Task<bool> UpdateOrder(Orders orderdetail)
        {
            using (IDbConnection con = _connectionFactory.MidLandSqlConnectionString())
            {
                var p = new DynamicParameters();
                p.Add("@orderid", orderdetail.orderid);
                p.Add("@ordername", orderdetail.ordername);
                p.Add("@orderlocation ", orderdetail.orderlocation);
                await con.ExecuteReaderAsync(StoredProcedureNames.UpdateOrder, p, commandType: CommandType.StoredProcedure);
                return true;
            }
        }
    }
}
