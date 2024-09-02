using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infarstuructre.BL
{
    public interface IICurrenciesExchangeRates
    {
        List<TBCurrenciesExchangeRates> GetAll();
        TBCurrenciesExchangeRates GetById(int IdCurrenciesExchangeRates);
        bool saveData(TBCurrenciesExchangeRates savee);
        bool UpdateData(TBCurrenciesExchangeRates updatss);
        bool deleteData(int IdCurrenciesExchangeRates);
        List<TBCurrenciesExchangeRates> GetAllv(int IdCurrenciesExchangeRates);
        ///////////////////////////////API/////////////////////////////////////////////////
        ///
        Task<List<TBCurrenciesExchangeRates>> GetAllAsync(int pageNumber, int pageSize);
        Task<List<TBCurrenciesExchangeRates>> GetAlWithConditionAsync(Expression<Func<TBCurrenciesExchangeRates, bool>> condition);
        Task<List<TBCurrenciesExchangeRates>> GetAllvAsync(int Id);
        Task<TBCurrenciesExchangeRates> GetByIdAsync(int Id);
        Task<bool> DeleteAsync(int Id);
        Task<bool> AddAsync(TBCurrenciesExchangeRates savee);
        Task<bool> UpdateAsync(TBCurrenciesExchangeRates updatss);

    }
    public class CLSTBCurrenciesExchangeRates: IICurrenciesExchangeRates
    {
        MasterDbcontext dbcontext;
        public CLSTBCurrenciesExchangeRates(MasterDbcontext dbcontext1)
        {
            dbcontext = dbcontext1;
        }
        public List<TBCurrenciesExchangeRates> GetAll()
        {
            List<TBCurrenciesExchangeRates> MySlider = dbcontext.TBCurrenciesExchangeRatess.OrderByDescending(n => n.IdCurrenciesExchangeRates).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
        public TBCurrenciesExchangeRates GetById(int IdCurrenciesExchangeRates)
        {
            TBCurrenciesExchangeRates sslid = dbcontext.TBCurrenciesExchangeRatess.FirstOrDefault(a => a.IdCurrenciesExchangeRates == IdCurrenciesExchangeRates);
            return sslid;
        }
        public bool saveData(TBCurrenciesExchangeRates savee)
        {
            try
            {
                dbcontext.Add<TBCurrenciesExchangeRates>(savee);
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateData(TBCurrenciesExchangeRates updatss)
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
        public bool deleteData(int IdCurrenciesExchangeRates)
        {
            try
            {
                var catr = GetById(IdCurrenciesExchangeRates);
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
        public List<TBCurrenciesExchangeRates> GetAllv(int IdCurrenciesExchangeRates)
        {
            List<TBCurrenciesExchangeRates> MySlider = dbcontext.TBCurrenciesExchangeRatess.OrderByDescending(n => n.IdCurrenciesExchangeRates == IdCurrenciesExchangeRates).Where(a => a.IdCurrenciesExchangeRates == IdCurrenciesExchangeRates).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }





        // //////////////////////////////////////////////////////API/////////////////////////////////////////////////////

        public async Task<List<TBCurrenciesExchangeRates>> GetAllAsync(int pageNumber, int pageSize)
        {
            List<TBCurrenciesExchangeRates> MySlIder = await dbcontext.TBCurrenciesExchangeRatess.OrderByDescending(n => n.IdCurrenciesExchangeRates).Where(a => a.CurrentState == true)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize).ToListAsync();
            return MySlIder;
        }

        public async Task<List<TBCurrenciesExchangeRates>> GetAlWithConditionAsync(Expression<Func<TBCurrenciesExchangeRates, bool>> condition)
        {
            List<TBCurrenciesExchangeRates> data = await dbcontext.TBCurrenciesExchangeRatess.Where(condition).ToListAsync();
            return data;
        }

        public async Task<List<TBCurrenciesExchangeRates>> GetAllvAsync(int Id)
        {
            List<TBCurrenciesExchangeRates> MySlIder = await dbcontext.TBCurrenciesExchangeRatess.OrderByDescending(n => n.IdCurrenciesExchangeRates == Id).Where(a => a.IdCurrenciesExchangeRates == Id).ToListAsync();
            return MySlIder;
        }

        public async Task<TBCurrenciesExchangeRates> GetByIdAsync(int Id)
        {
            TBCurrenciesExchangeRates sslId = await dbcontext.TBCurrenciesExchangeRatess.FirstOrDefaultAsync(a => a.IdCurrenciesExchangeRates == Id && a.CurrentState == true);
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

        public async Task<bool> AddAsync(TBCurrenciesExchangeRates savee)
        {
            try
            {
                await dbcontext.AddAsync<TBCurrenciesExchangeRates>(savee);
                await dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(TBCurrenciesExchangeRates updatss)
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
