

namespace Infarstuructre.BL
{
	public interface IIOrder
	{
		List<TBViewOrder> GetAll();
		Order GetById(int id);
		bool saveData(Order savee);
		bool UpdateData(Order updatss);
		bool deleteData(int id);
		List<TBViewOrder> GetAllv(int id);
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
	}
}
