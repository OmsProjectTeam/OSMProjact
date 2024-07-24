
namespace Infarstuructre.BL
{
	public interface IITypesOfRequest
	{
		List<TBTypesOfRequest> GetAll();
		TBTypesOfRequest GetById(int IdTypesOfRequest);
		bool saveData(TBTypesOfRequest savee);
		bool UpdateData(TBTypesOfRequest updatss);
		bool deleteData(int IdTypesOfRequest);
		List<TBTypesOfRequest> GetAllv(int IdTypesOfRequest);
	}
	public class CLSTBTypesOfRequest: IITypesOfRequest
	{
		MasterDbcontext dbcontext;
		public CLSTBTypesOfRequest(MasterDbcontext dbcontext1)
        {
			dbcontext = dbcontext1;
		}
		public List<TBTypesOfRequest> GetAll()
		{
			List<TBTypesOfRequest> MySlider = dbcontext.TBTypesOfRequests.OrderByDescending(n => n.IdTypesOfRequest).Where(a => a.CurrentState == true).ToList();
			return MySlider;
		}
		public TBTypesOfRequest GetById(int IdTypesOfRequest)
		{
			TBTypesOfRequest sslid = dbcontext.TBTypesOfRequests.FirstOrDefault(a => a.IdTypesOfRequest == IdTypesOfRequest);
			return sslid;
		}
		public bool saveData(TBTypesOfRequest savee)
		{
			try
			{
				dbcontext.Add<TBTypesOfRequest>(savee);
				dbcontext.SaveChanges();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
		public bool UpdateData(TBTypesOfRequest updatss)
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
		public bool deleteData(int IdTypesOfRequest)
		{
			try
			{
				var catr = GetById(IdTypesOfRequest);
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
		public List<TBTypesOfRequest> GetAllv(int IdTypesOfRequest)
		{
			List<TBTypesOfRequest> MySlider = dbcontext.TBTypesOfRequests.OrderByDescending(n => n.IdTypesOfRequest == IdTypesOfRequest).Where(a => a.IdTypesOfRequest == IdTypesOfRequest).Where(a => a.CurrentState == true).ToList();
			return MySlider;
		}
	}
}
