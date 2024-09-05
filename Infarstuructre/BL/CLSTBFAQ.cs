using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infarstuructre.BL
{

	public interface IIFAQ
	{
		List<TBFAQ> GetAll();
		TBFAQ GetById(int IdFAQ);
		bool saveData(TBFAQ savee);
		bool UpdateData(TBFAQ updatss);
		bool deleteData(int IdFAQ);
		List<TBFAQ> GetAllv(int IdFAQ);
		List<TBFAQ> GetAllActive();
		/////////////////API///////////////////////////
		///
		Task<List<TBFAQ>> GetAllAsync(int pageNumber, int pageSize);
        Task<List<TBFAQ>> GetAllActiveAsync();
        Task<List<TBFAQ>> GetAllvAsync(int Id);
		Task<TBFAQ> GetByIdAsync(int Id);
		Task<bool> DeleteAsync(int Id);
		Task<bool> AddDataAsync(TBFAQ savee);
		Task<bool> UpdateAsync(TBFAQ updatss);

    }

	public class CLSTBFAQ : IIFAQ
	{
		MasterDbcontext dbcontext;
		public CLSTBFAQ(MasterDbcontext dbcontext1)
        {
			dbcontext	= dbcontext1;

		}
		public List<TBFAQ> GetAll()
		{
			List<TBFAQ> MySlider = dbcontext.TBFAQs.Where(a => a.CurrentState == true).ToList();
			return MySlider;
		}
		public List<TBFAQ> GetAllActive()
		{
			List<TBFAQ> MySlider = dbcontext.TBFAQs.OrderByDescending(n => n.IdFAQ).Where(a => a.CurrentState == true).Where(a => a.Active == true).ToList();
			return MySlider;
		}
		public TBFAQ GetById(int IdFAQ)
		{
			TBFAQ sslid = dbcontext.TBFAQs.FirstOrDefault(a => a.IdFAQ == IdFAQ);
			return sslid;
		}
		public bool saveData(TBFAQ savee)
		{
			try
			{
				dbcontext.Add<TBFAQ>(savee);
				dbcontext.SaveChanges();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
		public bool UpdateData(TBFAQ updatss)
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
		public bool deleteData(int IdFAQ)
		{
			try
			{
				var catr = GetById(IdFAQ);
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
		public List<TBFAQ> GetAllv(int IdFAQ)
		{
			List<TBFAQ> MySlider = dbcontext.TBFAQs.OrderByDescending(n => n.IdFAQ == IdFAQ).Where(a => a.IdFAQ == IdFAQ).Where(a => a.CurrentState == true).ToList();
			return MySlider;
		}
        // //////////////////////////////////////////////////////API/////////////////////////////////////////////////////

        public async Task<List<TBFAQ>> GetAllAsync(int pageNumber, int pageSize)
        {
            List<TBFAQ> MySlIder = await dbcontext.TBFAQs.OrderByDescending(n => n.IdFAQ).Where(a => a.CurrentState == true).Skip((pageNumber - 1) * pageSize)
                .Take(pageSize).ToListAsync();
            return MySlIder;
        }

        public async Task<List<TBFAQ>> GetAllvAsync(int Id)
        {
            List<TBFAQ> MySlIder = await dbcontext.TBFAQs.OrderByDescending(n => n.IdFAQ == Id).Where(a => a.IdFAQ == Id).ToListAsync();
            return MySlIder;
        }

        public async Task<TBFAQ> GetByIdAsync(int Id)
        {
            TBFAQ sslId = await dbcontext.TBFAQs.FirstOrDefaultAsync(a => a.IdFAQ == Id && a.CurrentState == true);
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

        public async Task<bool> AddAsync(TBFAQ savee)
        {
            try
            {
                await dbcontext.AddAsync<TBFAQ>(savee);
                await dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(TBFAQ updatss)
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

        public async Task<List<TBFAQ>> GetAllActiveAsync()
        {
            List<TBFAQ> MySlider = await dbcontext.TBFAQs.OrderByDescending(n => n.IdFAQ).Where(a => a.CurrentState == true).Where(a => a.Active == true).ToListAsync();
            return MySlider;
        }

        public async Task<bool> AddDataAsync(TBFAQ savee)
        {
            try
            {
                await dbcontext.AddAsync<TBFAQ>(savee);
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
