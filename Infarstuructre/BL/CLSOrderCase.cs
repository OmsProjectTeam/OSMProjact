

namespace Infarstuructre.BL
{
	public interface IIOrderCase
	{
		List<OrderCase> GetAll();
		OrderCase GetById(int Id);
		bool saveData(OrderCase savee);
		bool UpdateData(OrderCase updatss);
		bool deleteData(int Id);
	}
	public class CLSOrderCase: IIOrderCase
	{
		MasterDbcontext dbcontext;
		public CLSOrderCase(MasterDbcontext dbcontext1)
        {
			dbcontext = dbcontext1;

		}
		public List<OrderCase> GetAll()
		{
			List<OrderCase> MySlider = dbcontext.order_cases.OrderByDescending(n => n.Id).ToList();
			return MySlider;
		}
		public OrderCase GetById(int Id)
		{
			OrderCase sslid = dbcontext.order_cases.FirstOrDefault(a => a.Id == Id);
			return sslid;
		}
		public bool saveData(OrderCase savee)
		{
			try
			{
				dbcontext.Add<OrderCase>(savee);
				dbcontext.SaveChanges();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
		public bool UpdateData(OrderCase updatss)
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
		public bool deleteData(int Id)
		{
			try
			{
				//var catr = GetById(Id);
				//catr.CurrentState = false;
				////TbSubCateegoory dele = dbcontex.TbSubCateegoorys.Where(a => a.IdBrand == IdBrand).FirstOrDefault();
				////dbcontex.TbSubCateegoorys.Remove(dele);
				//dbcontext.Entry(catr).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
				//dbcontext.SaveChanges();
				return true;
			}
			catch (Exception)
			{
				return false;
			}

		}
	}
}
