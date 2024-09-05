using Microsoft.EntityFrameworkCore;

namespace Infarstuructre.BL
{
    public interface IIExchangeRate
    {
        List<TBViewExchangeRate> GetAll();
        TBExchangeRate GetById(int IdExchangeRate);
        bool saveData(TBExchangeRate savee);
        bool UpdateData(TBExchangeRate updatss);
        bool deleteData(int IdExchangeRate);
        List<TBViewExchangeRate> GetAllv(int IdExchangeRate);

        /// ///////////////////////////////////////API///////////////////////////////////

        Task<List<TBViewExchangeRate>> GetAllAsync(int pageNumber, int pageSize);
        Task<List<TBViewExchangeRate>> GetAllvAsync(int Id);
        Task<TBExchangeRate> GetByIdAsync(int Id);
        Task<bool> DeleteAsync(int Id);
        Task<bool> AddAsync(TBExchangeRate savee);
        Task<bool> UpdateAsync(TBExchangeRate updatss);


        public class CLSTBExchangeRate : IIExchangeRate
        {
            MasterDbcontext dbcontext;
            public CLSTBExchangeRate(MasterDbcontext dbcontext1)
            {
                dbcontext = dbcontext1;
            }
            public List<TBViewExchangeRate> GetAll()
            {
                List<TBViewExchangeRate> MySlider = dbcontext.ViewExchangeRate.OrderByDescending(n => n.IdExchangeRate).Where(a => a.CurrentState == true).ToList();
                return MySlider;
            }
            public TBExchangeRate GetById(int IdExchangeRate)
            {
                TBExchangeRate sslid = dbcontext.TBExchangeRates.FirstOrDefault(a => a.IdExchangeRate == IdExchangeRate);
                return sslid;
            }
            public bool saveData(TBExchangeRate savee)
            {
                try
                {
                    dbcontext.Add<TBExchangeRate>(savee);
                    dbcontext.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            public bool UpdateData(TBExchangeRate updatss)
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
            public bool deleteData(int IdExchangeRate)
            {
                try
                {
                    var catr = GetById(IdExchangeRate);
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
            public List<TBViewExchangeRate> GetAllv(int IdExchangeRate)
            {
                List<TBViewExchangeRate> MySlider = dbcontext.ViewExchangeRate.OrderByDescending(n => n.IdExchangeRate == IdExchangeRate).Where(a => a.IdExchangeRate == IdExchangeRate).Where(a => a.CurrentState == true).ToList();
                return MySlider;
            }
            // //////////////////////////////////////////////////////API/////////////////////////////////////////////////////

            public async Task<List<TBViewExchangeRate>> GetAllAsync(int pageNumber, int pageSize)
            {
                List<TBViewExchangeRate> MySlIder = await dbcontext.ViewExchangeRate.OrderByDescending(n => n.IdExchangeRate)
                    .Where(a => a.CurrentState == true).Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize).ToListAsync();
                return MySlIder;
            }

            public async Task<List<TBViewExchangeRate>> GetAllvAsync(int Id)
            {
                List<TBViewExchangeRate> MySlIder = await dbcontext.ViewExchangeRate.OrderByDescending(n => n.IdExchangeRate == Id).Where(a => a.IdExchangeRate == Id).ToListAsync();
                return MySlIder;
            }

            public async Task<TBExchangeRate> GetByIdAsync(int Id)
            {
                TBExchangeRate sslId = await dbcontext.TBExchangeRates.FirstOrDefaultAsync(a => a.IdExchangeRate == Id && a.CurrentState == true);
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

            public async Task<bool> AddAsync(TBExchangeRate savee)
            {
                try
                {
                    await dbcontext.AddAsync<TBExchangeRate>(savee);
                    await dbcontext.SaveChangesAsync();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

            public async Task<bool> UpdateAsync(TBExchangeRate updatss)
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
}
