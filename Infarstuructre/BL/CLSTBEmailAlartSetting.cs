

using Microsoft.EntityFrameworkCore;

namespace Infarstuructre.BL
{
	public interface IIEmailAlartSetting
	{
		List<TBEmailAlartSetting> GetAll();
		TBEmailAlartSetting GetById(int IdEmailAlartSetting);
		bool saveData(TBEmailAlartSetting savee);
		bool UpdateData(TBEmailAlartSetting updatss);
		bool deleteData(int IdEmailAlartSetting);
		List<TBEmailAlartSetting> GetAllv(int IdEmailAlartSetting);

		////////////////////////API////////////////////////////////////
		///
		Task<List<TBEmailAlartSetting>> GetAllAsync(int pageNumber, int pageSize);
		Task<List<TBEmailAlartSetting>> GetAllvAsync(int Id);
		Task<TBEmailAlartSetting> GetByIdAsync(int Id);
		Task<bool> DeleteAsync(int Id);
		Task<bool> AddAsync(TBEmailAlartSetting savee);
		Task<bool> UpdateAsync(TBEmailAlartSetting updatss);


    }
	public class CLSTBEmailAlartSetting: IIEmailAlartSetting
	{
		MasterDbcontext dbcontext;
		public CLSTBEmailAlartSetting(MasterDbcontext dbcontext1)
        {
			dbcontext=dbcontext1;

		}
		public List<TBEmailAlartSetting> GetAll()
		{
			List<TBEmailAlartSetting> MySlider = dbcontext.TBEmailAlartSettings.OrderByDescending(n => n.IdEmailAlartSetting).Where(a => a.CurrentState == true).ToList();
			return MySlider;
		}
		public TBEmailAlartSetting GetById(int IdEmailAlartSetting)
		{
			TBEmailAlartSetting sslid = dbcontext.TBEmailAlartSettings.FirstOrDefault(a => a.IdEmailAlartSetting == IdEmailAlartSetting);
			return sslid;
		}
		public bool saveData(TBEmailAlartSetting savee)
		{
			try
			{
				dbcontext.Add<TBEmailAlartSetting>(savee);
				dbcontext.SaveChanges();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
		public bool UpdateData(TBEmailAlartSetting updatss)
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
		public bool deleteData(int IdEmailAlartSetting)
		{
			try
			{
				var catr = GetById(IdEmailAlartSetting);
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
		public List<TBEmailAlartSetting> GetAllv(int IdEmailAlartSetting)
		{
			List<TBEmailAlartSetting> MySlider = dbcontext.TBEmailAlartSettings.OrderByDescending(n => n.IdEmailAlartSetting == IdEmailAlartSetting).Where(a => a.IdEmailAlartSetting == IdEmailAlartSetting).Where(a => a.CurrentState == true).ToList();
			return MySlider;
		}

        // //////////////////////////////////////////////////////API/////////////////////////////////////////////////////

        public async Task<List<TBEmailAlartSetting>> GetAllAsync(int pageNumber, int pageSize)
        {
            List<TBEmailAlartSetting> MySlIder = await dbcontext.TBEmailAlartSettings.OrderByDescending(n => n.IdEmailAlartSetting).Where(a => a.CurrentState == true)
				.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize).ToListAsync();
            return MySlIder;
        }

        public async Task<List<TBEmailAlartSetting>> GetAllvAsync(int Id)
        {
            List<TBEmailAlartSetting> MySlIder = await dbcontext.TBEmailAlartSettings.OrderByDescending(n => n.IdEmailAlartSetting == Id).Where(a => a.IdEmailAlartSetting == Id).ToListAsync();
            return MySlIder;
        }

        public async Task<TBEmailAlartSetting> GetByIdAsync(int Id)
        {
            TBEmailAlartSetting sslId = await dbcontext.TBEmailAlartSettings.FirstOrDefaultAsync(a => a.IdEmailAlartSetting == Id && a.CurrentState == true);
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

        public async Task<bool> AddAsync(TBEmailAlartSetting savee)
        {
            try
            {
                await dbcontext.AddAsync<TBEmailAlartSetting>(savee);
                await dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(TBEmailAlartSetting updatss)
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
