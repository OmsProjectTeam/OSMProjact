


namespace Infarstuructre.BL
{
	public interface IITypesCompanies
	{
		List<TBTypesCompanies> GetAll();
		TBTypesCompanies GetById(int IdTypesCompanies);
		bool saveData(TBTypesCompanies savee);
		bool UpdateData(TBTypesCompanies updatss);
		bool deleteData(int IdTypesCompanies);
		List<TBTypesCompanies> GetAllv(int IdTypesCompanies);


	}
	public class CLSTBTypesCompanies: IITypesCompanies
	{
		MasterDbcontext dbcontext;
		public CLSTBTypesCompanies(MasterDbcontext dbcontext1)
        {
			dbcontext=dbcontext1;
		}

		public List<TBTypesCompanies> GetAll()
		{
			List<TBTypesCompanies> MySlider = dbcontext.TBTypesCompaniess.OrderByDescending(n => n.IdTypesCompanies).Where(a => a.CurrentState == true).ToList();
			return MySlider;
		}
		public TBTypesCompanies GetById(int IdTypesCompanies)
		{
			TBTypesCompanies sslid = dbcontext.TBTypesCompaniess.FirstOrDefault(a => a.IdTypesCompanies == IdTypesCompanies);
			return sslid;
		}
		public bool saveData(TBTypesCompanies savee)
		{
			try
			{
				dbcontext.Add<TBTypesCompanies>(savee);
				dbcontext.SaveChanges();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
		public bool UpdateData(TBTypesCompanies updatss)
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
		public bool deleteData(int IdTypesCompanies)
		{
			try
			{
				var catr = GetById(IdTypesCompanies);
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
		public List<TBTypesCompanies> GetAllv(int IdTypesCompanies)
		{
			List<TBTypesCompanies> MySlider = dbcontext.TBTypesCompaniess.OrderByDescending(n => n.IdTypesCompanies == IdTypesCompanies).Where(a => a.IdTypesCompanies == IdTypesCompanies).Where(a => a.CurrentState == true).ToList();
			return MySlider;
		}
	}
}
