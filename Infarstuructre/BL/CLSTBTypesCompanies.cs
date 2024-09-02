


using Microsoft.EntityFrameworkCore;

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

		///////////////////////////////API/////////////////////////////////////////
		///
		Task<List<TBTypesCompanies>> GetAllAsync(int pageNumber, int pageSize);
		Task<List<TBTypesCompanies>> GetAllvAsync(int Id);
		Task<TBTypesCompanies> GetByIdAsync(int Id);
		Task<bool> DeleteAsync(int Id);
		Task<bool> AddAsync(TBTypesCompanies savee);
		Task<bool> UpdateAsync(TBTypesCompanies updatss);

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

        // //////////////////////////////////////////////////////API/////////////////////////////////////////////////////

        public async Task<List<TBTypesCompanies>> GetAllAsync(int pageNumber, int pageSize)
        {
            List<TBTypesCompanies> MySlIder = await dbcontext.TBTypesCompaniess.OrderByDescending(n => n.IdTypesCompanies).Where(a => a.CurrentState == true).Skip((pageNumber - 1) * pageSize)
                .Take(pageSize).ToListAsync();
            return MySlIder;
        }

        public async Task<List<TBTypesCompanies>> GetAllvAsync(int Id)
        {
            List<TBTypesCompanies> MySlIder = await dbcontext.TBTypesCompaniess.OrderByDescending(n => n.IdTypesCompanies == Id).Where(a => a.IdTypesCompanies == Id).ToListAsync();
            return MySlIder;
        }

        public async Task<TBTypesCompanies> GetByIdAsync(int Id)
        {
            TBTypesCompanies sslId = await dbcontext.TBTypesCompaniess.FirstOrDefaultAsync(a => a.IdTypesCompanies == Id && a.CurrentState == true);
            return sslId;
        }

        public async Task<bool> DeleteAsync(int Id)
        {
            try
            {
                var catr = await GetByIdAsync(Id);
                catr.CurrentState = false;
                //TbSubCateegoory dele = dbcontex.TbSubCateegoorys.Where(a => a.IdBrand == IdBrand).FirstOrDefault();
                //dbcontex.TbSubCateegoorys.Remove(dele);
                dbcontext.Entry(catr).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> AddAsync(TBTypesCompanies savee)
        {
            try
            {
                await dbcontext.AddAsync<TBTypesCompanies>(savee);
                await dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(TBTypesCompanies updatss)
        {
            try
            {
                dbcontext.Entry(updatss).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
