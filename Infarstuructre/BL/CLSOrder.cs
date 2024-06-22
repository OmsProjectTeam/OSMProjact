

using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace Infarstuructre.BL
{
	public interface IIOrder
	{
		List<TBViewOrder> GetAll();
		Order GetById(int id);
		bool saveData(Order order);
		bool UpdateData(Order order);
		bool deleteData(int id);
		List<TBViewOrder> GetAllv(int id);
		///////////////////////////////////////////
		///Api 
		Task<IEnumerable<TBViewOrder>> GetAllOrdersAsync(int pageNumber, int pageSize);
		Task<IEnumerable<TBViewOrder>> GetAllOrdersWithConditionAsync(Expression<Func<TBViewOrder, bool>> condition);
		Task<Order> GetOrderAsync(int id);
		Task AddOrderAsync(Order merchant);
		Task UpdateOrderAsync(Order merchant);
	}
	public class CLSOrder: IIOrder
	{
		MasterDbcontext dbcontext;
		public CLSOrder(MasterDbcontext dbcontext1)
        {
			dbcontext = dbcontext1;

		}
		public List<TBViewOrder> GetAll()
		{
			List<TBViewOrder> MySlider = dbcontext.ViewOrder.OrderByDescending(n => n.id).Where(a => a.CurrentState == true).ToList();
			return MySlider;
		}
		public Order GetById(int id)
		{
			Order sslid = dbcontext.orders.FirstOrDefault(a => a.Id == id);
			return sslid;
		}
		public bool saveData(Order savee)
		{
			try
			{
				dbcontext.Add<Order>(savee);
				dbcontext.SaveChanges();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
		public bool UpdateData(Order updatss)
		{
			try
			{
				dbcontext.Entry(updatss).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
				dbcontext.SaveChanges();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
		public bool deleteData(int id)
		{
			try
			{
				var catr = GetById(id);
				catr.CurrentState = false;
				//TbSubCateegoory dele = dbcontex.TbSubCateegoorys.Where(a => a.IdBrand == IdBrand).FirstOrDefault();
				//dbcontex.TbSubCateegoorys.Remove(dele);
				dbcontext.Entry(catr).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
				dbcontext.SaveChanges();
				return true;
			}
			catch (Exception)
			{
				return false;
			}

		}
		public List<TBViewOrder> GetAllv(int id)
		{
			List<TBViewOrder> MySlider = dbcontext.ViewOrder.OrderByDescending(n => n.id == id).Where(a => a.id == id).Where(a => a.CurrentState == true).ToList();
			return MySlider;
		}

		/////////////////// Api
		public async Task<IEnumerable<TBViewOrder>> GetAllOrdersAsync(int pageNumber, int pageSize)
		{
			IEnumerable<TBViewOrder> orders = await dbcontext.ViewOrder.OrderByDescending(n => n.id)
				.Where(a => a.CurrentState == true)
				.Skip((pageNumber - 1) * pageSize)
				.Take(pageSize)
				.ToListAsync();
			return orders;
		}

		public async Task<IEnumerable<TBViewOrder>> GetAllOrdersWithConditionAsync(Expression<Func<TBViewOrder, bool>> condition)
		{
			IEnumerable<TBViewOrder> orders = await dbcontext.ViewOrder.Where(condition).ToListAsync();
			return orders;
		}

		public async Task<Order> GetOrderAsync(int id)
		{
			Order order = await dbcontext.orders.FindAsync(id);
			return order;
		}

		public async Task AddOrderAsync(Order order)
		{
			await dbcontext.AddAsync(order);
			await dbcontext.SaveChangesAsync();
		}

		public async Task UpdateOrderAsync(Order order)
		{
			dbcontext.Entry(order).State = EntityState.Modified;
			await dbcontext.SaveChangesAsync();
		}
	}	
}
