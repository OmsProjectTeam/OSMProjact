using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infarstuructre.BL
{

	public interface IIFAQDescreption
	{
		List<TBViewFAQDescription> GetAll();
		TBFAQDescreption GetByIdFAQDescreption(int IdFAQDescreption);
		bool saveData(TBFAQDescreption savee);
		bool deleteData(int IdFAQDescreption);
		List<TBViewFAQDescription> GetAllv(int IdFAQDescreption);
		bool UpdateData(TBFAQDescreption updatss);
		////////////////////////////API//////////////////////////////////
		///

		Task<List<TBViewFAQDescription>> GetAllAsync(int pageNumber, int pageSize);
		Task<List<TBViewFAQDescription>> GetAllvAsync(int Id);
		Task<TBFAQDescreption> GetByIdAsync(int Id);
		Task<bool> DeleteAsync(int Id);
		Task<bool> AddAsync(TBFAQDescreption savee);
		Task<bool> UpdateAsync(TBFAQDescreption updatss);
    }

	public class CLSTBFAQDescreption : IIFAQDescreption
	{
		MasterDbcontext dbcontext;
		public CLSTBFAQDescreption(MasterDbcontext dbcontext1)
        {
			dbcontext = dbcontext1;

		}

		public List<TBViewFAQDescription> GetAll()
		{
			List<TBViewFAQDescription> MySlIdFAQDescreptioner = dbcontext.ViewFAQDescription.OrderByDescending(n => n.IdFAQDescreption).Where(a => a.CurrentState == true).Where(a => a.Active == true).ToList();
			return MySlIdFAQDescreptioner;
		}
		public TBFAQDescreption GetByIdFAQDescreption(int IdFAQDescreption)
		{
			TBFAQDescreption sslIdFAQDescreption = dbcontext.TBFAQDescreptions.FirstOrDefault(a => a.IdFAQDescreption == IdFAQDescreption);
			return sslIdFAQDescreption;
		}
		public bool saveData(TBFAQDescreption savee)
		{
			try
			{
				dbcontext.Add<TBFAQDescreption>(savee);
				dbcontext.SaveChanges();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
		public bool UpdateData(TBFAQDescreption updatss)
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
		public bool deleteData(int IdFAQDescreption)
		{
			try
			{
				var catr = GetByIdFAQDescreption(IdFAQDescreption);
				catr.CurrentState = false;
				//TbSubCateegoory dele = dbcontex.TbSubCateegoorys.Where(a => a.IdFAQDescreptionBrand == IdFAQDescreptionBrand).FirstOrDefault();
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
		public List<TBViewFAQDescription> GetAllv(int IdFAQDescreption)
		{
			List<TBViewFAQDescription> MySlIdFAQDescreptioner = dbcontext.ViewFAQDescription.OrderByDescending(n => n.IdFAQ == IdFAQDescreption).Where(a => a.IdFAQ == IdFAQDescreption).Where(a => a.CurrentState == true).ToList();
			return MySlIdFAQDescreptioner;
		}
        // //////////////////////////////////////////////////////API/////////////////////////////////////////////////////

        public async Task<List<TBViewFAQDescription>> GetAllAsync(int pageNumber, int pageSize)
        {
            List<TBViewFAQDescription> MySlIder = await dbcontext.ViewFAQDescription.OrderByDescending(n => n.IdFAQDescreption).Where(a => a.CurrentState == true)
				.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize).ToListAsync();
            return MySlIder;
        }

        public async Task<List<TBViewFAQDescription>> GetAllvAsync(int Id)
        {
            List<TBViewFAQDescription> MySlIder = await dbcontext.ViewFAQDescription.OrderByDescending(n => n.IdFAQ == Id).Where(a => a.IdFAQ == Id).ToListAsync();
            return MySlIder;
        }

        public async Task<TBFAQDescreption> GetByIdAsync(int Id)
        {
            TBFAQDescreption sslId = await dbcontext.TBFAQDescreptions.FirstOrDefaultAsync(a => a.IdFAQDescreption == Id && a.CurrentState == true);
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

        public async Task<bool> AddAsync(TBFAQDescreption savee)
        {
            try
            {
                await dbcontext.AddAsync<TBFAQDescreption>(savee);
                await dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(TBFAQDescreption updatss)
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
