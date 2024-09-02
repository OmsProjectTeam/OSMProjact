
using Microsoft.EntityFrameworkCore;

namespace Infarstuructre.BL
{
    public interface IIShippingPrice
    {
        List<TBViewShippingPrices> GetAll();
        TBShippingPrice GetById(int IdShipping);
        bool saveData(TBShippingPrice savee);
        bool UpdateData(TBShippingPrice updatss);
        bool deleteData(int IdShipping);
        List<TBViewShippingPrices> GetAllv(int IdShipping);
        ///////////////////////////API///////////////////////////////
        ///
        Task<List<TBViewShippingPrices>> GetAllAsync(int pageNumber, int pageSize);
        Task<List<TBViewShippingPrices>> GetAllvAsync(int Id);
        Task<TBShippingPrice> GetByIdAsync(int Id);
        Task<bool> DeleteAsync(int Id);
        Task<bool> AddAsync(TBShippingPrice savee);
        Task<bool> UpdateAsync(TBShippingPrice updatss);
    }

    public class CLSTBShippingPrice: IIShippingPrice
    {
        MasterDbcontext dbcontext;
        public CLSTBShippingPrice(MasterDbcontext dbcontext1)
        {
            dbcontext=dbcontext1;
        }
        public List<TBViewShippingPrices> GetAll()
        {
            List<TBViewShippingPrices> MySlider = dbcontext.ViewShippingPrices.OrderByDescending(n => n.IdShipping).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
        public TBShippingPrice GetById(int IdShipping)
        {
            TBShippingPrice sslid = dbcontext.TBShippingPrices.FirstOrDefault(a => a.IdShipping == IdShipping);
            return sslid;
        }
        public bool saveData(TBShippingPrice savee)
        {
            try
            {
                dbcontext.Add<TBShippingPrice>(savee);
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateData(TBShippingPrice updatss)
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
        public bool deleteData(int IdShipping)
        {
            try
            {
                var catr = GetById(IdShipping);
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
        public List<TBViewShippingPrices> GetAllv(int IdShipping)
        {
            List<TBViewShippingPrices> MySlider = dbcontext.ViewShippingPrices.OrderByDescending(n => n.IdShipping == IdShipping).Where(a => a.IdShipping == IdShipping).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }

        // //////////////////////////////////////////////////////API/////////////////////////////////////////////////////

        public async Task<List<TBViewShippingPrices>> GetAllAsync(int pageNumber, int pageSize)
        {
            List<TBViewShippingPrices> MySlIder = await dbcontext.ViewShippingPrices.OrderByDescending(n => n.IdShipping).Where(a => a.CurrentState == true)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize).ToListAsync();
            return MySlIder;
        }

        public async Task<List<TBViewShippingPrices>> GetAllvAsync(int Id)
        {
            List<TBViewShippingPrices> MySlIder = await dbcontext.ViewShippingPrices.OrderByDescending(n => n.IdShipping == Id).Where(a => a.IdShipping == Id).ToListAsync();
            return MySlIder;
        }

        public async Task<TBShippingPrice> GetByIdAsync(int Id)
        {
            TBShippingPrice sslId = await dbcontext.TBShippingPrices.FirstOrDefaultAsync(a => a.IdShipping == Id && a.CurrentState == true);
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

        public async Task<bool> AddAsync(TBShippingPrice savee)
        {
            try
            {
                await dbcontext.AddAsync<TBShippingPrice>(savee);
                await dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(TBShippingPrice updatss)
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
