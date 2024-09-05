
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infarstuructre.BL
{
    public interface IIClintWitheDeliveryTariffs
    {
        List<TBViewClintWitheDeliveryTariffs> GetAll();
        TBClintWitheDeliveryTariffs GetById(int IdClintWitheDeliveryTariffs);
        bool saveData(TBClintWitheDeliveryTariffs savee);
        bool UpdateData(TBClintWitheDeliveryTariffs updatss);
        bool deleteData(int IdClintWitheDeliveryTariffs);
        List<TBViewClintWitheDeliveryTariffs> GetAllv(int IdClintWitheDeliveryTariffs);

        //////////////////////////////////////////API/////////////////////////////////////////////////
        ///
        Task<List<TBViewClintWitheDeliveryTariffs>> GetAllAsync(int pageNumber, int pageSize);
        Task<List<TBViewClintWitheDeliveryTariffs>> GetAlWithConditionAsync(Expression<Func<TBViewClintWitheDeliveryTariffs, bool>> condition);
        Task<List<TBViewClintWitheDeliveryTariffs>> GetAllvAsync(int Id);
        Task<TBClintWitheDeliveryTariffs> GetByIdAsync(int Id);
        Task<bool> DeleteAsync(int Id);
        Task<bool> AddAsync(TBClintWitheDeliveryTariffs savee);
        Task<bool> UpdateAsync(TBClintWitheDeliveryTariffs updatss);

    }
    public class CLSTBClintWitheDeliveryTariffs: IIClintWitheDeliveryTariffs
    {
        MasterDbcontext dbcontext;
        public CLSTBClintWitheDeliveryTariffs(MasterDbcontext dbcontext1)
        {
            dbcontext  = dbcontext1;
        }
        public List<TBViewClintWitheDeliveryTariffs> GetAll()
        {
            List<TBViewClintWitheDeliveryTariffs> MySlider = dbcontext.ViewClintWitheDeliveryTariffs.OrderByDescending(n => n.IdClintWitheDeliveryTariffs).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
        public TBClintWitheDeliveryTariffs GetById(int IdClintWitheDeliveryTariffs)
        {
            TBClintWitheDeliveryTariffs sslid = dbcontext.TBClintWitheDeliveryTariffss.FirstOrDefault(a => a.IdClintWitheDeliveryTariffs == IdClintWitheDeliveryTariffs);
            return sslid;
        }
        public bool saveData(TBClintWitheDeliveryTariffs savee)
        {
            try
            {
                dbcontext.Add<TBClintWitheDeliveryTariffs>(savee);
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateData(TBClintWitheDeliveryTariffs updatss)
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
        public bool deleteData(int IdClintWitheDeliveryTariffs)
        {
            try
            {
                var catr = GetById(IdClintWitheDeliveryTariffs);
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
        public List<TBViewClintWitheDeliveryTariffs> GetAllv(int IdClintWitheDeliveryTariffs)
        {
            List<TBViewClintWitheDeliveryTariffs> MySlider = dbcontext.ViewClintWitheDeliveryTariffs.OrderByDescending(n => n.IdClintWitheDeliveryTariffs == IdClintWitheDeliveryTariffs).Where(a => a.IdClintWitheDeliveryTariffs == IdClintWitheDeliveryTariffs).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
        // //////////////////////////////////////////////////////API/////////////////////////////////////////////////////

        public async Task<List<TBViewClintWitheDeliveryTariffs>> GetAllAsync(int pageNumber, int pageSize)
        {
            List<TBViewClintWitheDeliveryTariffs> MySlIder = await dbcontext.ViewClintWitheDeliveryTariffs.OrderByDescending(n => n.IdClintWitheDeliveryTariffs)
                .Where(a => a.CurrentState == true).Skip((pageNumber - 1) * pageSize)
                .Take(pageSize).ToListAsync();
            return MySlIder;
        }

        public async Task<List<TBViewClintWitheDeliveryTariffs>> GetAlWithConditionAsync(Expression<Func<TBViewClintWitheDeliveryTariffs, bool>> condition)
        {
            List<TBViewClintWitheDeliveryTariffs> data = await dbcontext.ViewClintWitheDeliveryTariffs.Where(condition).ToListAsync();
            return data;
        }

        public async Task<List<TBViewClintWitheDeliveryTariffs>> GetAllvAsync(int Id)
        {
            List<TBViewClintWitheDeliveryTariffs> MySlIder = await dbcontext.ViewClintWitheDeliveryTariffs.OrderByDescending(n => n.IdClintWitheDeliveryTariffs == Id).Where(a => a.IdClintWitheDeliveryTariffs == Id).ToListAsync();
            return MySlIder;
        }

        public async Task<TBClintWitheDeliveryTariffs> GetByIdAsync(int Id)
        {
            TBClintWitheDeliveryTariffs sslId = await dbcontext.TBClintWitheDeliveryTariffss.FirstOrDefaultAsync(a => a.IdClintWitheDeliveryTariffs == Id && a.CurrentState == true);
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

        public async Task<bool> AddAsync(TBClintWitheDeliveryTariffs savee)
        {
            try
            {
                await dbcontext.AddAsync<TBClintWitheDeliveryTariffs>(savee);
                await dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(TBClintWitheDeliveryTariffs updatss)
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
