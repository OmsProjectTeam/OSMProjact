
using Microsoft.EntityFrameworkCore;

namespace Infarstuructre.BL
{
    public interface IICityDeliveryTariffs
    {
        List<TBViewCityDeliveryTariffs> GetAll();
        TBCityDeliveryTariffs GetById(int IdCityDeliveryTariffs);
        bool saveData(TBCityDeliveryTariffs savee);
        bool UpdateData(TBCityDeliveryTariffs updatss);
        bool deleteData(int IdCityDeliveryTariffs);
        List<TBViewCityDeliveryTariffs> GetAllv(int IdCityDeliveryTariffs);
        //////////////////////////////////API///////////////////////////////////////
        ///

        Task<List<TBViewCityDeliveryTariffs>> GetAllAsync(int pageNumber, int pageSize);
        Task<List<TBViewCityDeliveryTariffs>> GetAllvAsync(int Id);
        Task<TBCityDeliveryTariffs> GetByIdAsync(int Id);
        Task<bool> DeleteAsync(int Id);
        Task<bool> AddAsync(TBCityDeliveryTariffs savee);
        Task<bool> UpdateAsync(TBCityDeliveryTariffs updatss);
    }
    public class CLSTBCityDeliveryTariffs: IICityDeliveryTariffs
    {
        MasterDbcontext dbcontext;
        public CLSTBCityDeliveryTariffs(MasterDbcontext dbcontext1)
        {
            dbcontext= dbcontext1;
        }
        public List<TBViewCityDeliveryTariffs> GetAll()
        {
            List<TBViewCityDeliveryTariffs> MySlider = dbcontext.ViewCityDeliveryTariffs.OrderByDescending(n => n.IdCityDeliveryTariffs).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
        public TBCityDeliveryTariffs GetById(int IdCityDeliveryTariffs)
        {
            TBCityDeliveryTariffs sslid = dbcontext.TBCityDeliveryTariffss.FirstOrDefault(a => a.IdCityDeliveryTariffs == IdCityDeliveryTariffs);
            return sslid;
        }
        public bool saveData(TBCityDeliveryTariffs savee)
        {
            try
            {
                dbcontext.Add<TBCityDeliveryTariffs>(savee);
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateData(TBCityDeliveryTariffs updatss)
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
        public bool deleteData(int IdCityDeliveryTariffs)
        {
            try
            {
                var catr = GetById(IdCityDeliveryTariffs);
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
        public List<TBViewCityDeliveryTariffs> GetAllv(int IdCityDeliveryTariffs)
        {
            List<TBViewCityDeliveryTariffs> MySlider = dbcontext.ViewCityDeliveryTariffs.OrderByDescending(n => n.IdCityDeliveryTariffs == IdCityDeliveryTariffs).Where(a => a.IdCityDeliveryTariffs == IdCityDeliveryTariffs).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }

         // //////////////////////////////////////////////////////API/////////////////////////////////////////////////////

        public async Task<List<TBViewCityDeliveryTariffs>> GetAllAsync(int pageNumber, int pageSize)
        {
            List<TBViewCityDeliveryTariffs> MySlIder = await dbcontext.ViewCityDeliveryTariffs.OrderByDescending(n => n.IdInformationCompanies).Where(a => a.CurrentState == true).Skip((pageNumber - 1) * pageSize)
                .Take(pageSize).ToListAsync();
            return MySlIder;
        }

        public async Task<List<TBViewCityDeliveryTariffs>> GetAllvAsync(int Id)
        {
            List<TBViewCityDeliveryTariffs> MySlIder = await dbcontext.ViewCityDeliveryTariffs.OrderByDescending(n => n.IdInformationCompanies == Id).Where(a => a.IdInformationCompanies == Id).ToListAsync();
            return MySlIder;
        }

        public async Task<TBCityDeliveryTariffs> GetByIdAsync(int Id)
        {
            TBCityDeliveryTariffs sslId = await dbcontext.TBCityDeliveryTariffss.FirstOrDefaultAsync(a => a.IdCityDeliveryTariffs == Id && a.CurrentState == true);
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

        public async Task<bool> AddAsync(TBCityDeliveryTariffs savee)
        {
            try
            {
                await dbcontext.AddAsync<TBCityDeliveryTariffs>(savee);
                await dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(TBCityDeliveryTariffs updatss)
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
