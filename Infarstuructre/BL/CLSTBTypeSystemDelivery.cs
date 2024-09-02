

using Domin.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infarstuructre.BL
{
    public interface IITypeSystemDelivery
    {
        List<TBTypeSystemDelivery> GetAll();
        TBTypeSystemDelivery GetById(int IdTypeSystemDelivery);
        bool saveData(TBTypeSystemDelivery savee);
        bool UpdateData(TBTypeSystemDelivery updatss);
        bool deleteData(int IdTypeSystemDelivery);
        List<TBTypeSystemDelivery> GetAllv(int IdTypeSystemDelivery);

        //////////////////////////////Api//////////////////////////////////
        Task<List<TBTypeSystemDelivery>> GetAllAsync(int pageNumber, int pageSize);
        Task<List<TBTypeSystemDelivery>> GetAllvAsync(int Id);
        Task<TBTypeSystemDelivery> GetByIdAsync(int Id);
        Task<bool> DeleteAsync(int Id);
        Task<bool> AddAsync(TBTypeSystemDelivery savee);
        Task<bool> UpdateAsync(TBTypeSystemDelivery updatss);
    }
    public class CLSTBTypeSystemDelivery: IITypeSystemDelivery
    {
        MasterDbcontext dbcontext;

        public CLSTBTypeSystemDelivery(MasterDbcontext dbcontex1)
        {
            dbcontext= dbcontex1;
        }

        public List<TBTypeSystemDelivery> GetAll()
        {
            List<TBTypeSystemDelivery> MySlider = dbcontext.TBTypeSystemDeliverys.OrderByDescending(n => n.IdTypeSystemDelivery).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
        public TBTypeSystemDelivery GetById(int IdTypeSystemDelivery)
        {
            TBTypeSystemDelivery sslid = dbcontext.TBTypeSystemDeliverys.FirstOrDefault(a => a.IdTypeSystemDelivery == IdTypeSystemDelivery);
            return sslid;
        }
        public bool saveData(TBTypeSystemDelivery savee)
        {
            try
            {
                dbcontext.Add<TBTypeSystemDelivery>(savee);
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateData(TBTypeSystemDelivery updatss)
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
        public bool deleteData(int IdTypeSystemDelivery)
        {
            try
            {
                var catr = GetById(IdTypeSystemDelivery);
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
        public List<TBTypeSystemDelivery> GetAllv(int IdTypeSystemDelivery)
        {
            List<TBTypeSystemDelivery> MySlider = dbcontext.TBTypeSystemDeliverys.OrderByDescending(n => n.IdTypeSystemDelivery == IdTypeSystemDelivery).Where(a => a.IdTypeSystemDelivery == IdTypeSystemDelivery).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }


        // //////////////////////////////////////////////////////API/////////////////////////////////////////////////////

        public async Task<List<TBTypeSystemDelivery>> GetAllAsync(int pageNumber, int pageSize)
        {
            List<TBTypeSystemDelivery> MySlIder = await dbcontext.TBTypeSystemDeliverys.OrderByDescending(n => n.IdTypeSystemDelivery).Where(a => a.CurrentState == true).Skip((pageNumber - 1) * pageSize)
                .Take(pageSize).ToListAsync();
            return MySlIder;
        }

        public async Task<List<TBTypeSystemDelivery>> GetAllvAsync(int Id)
        {
            List<TBTypeSystemDelivery> MySlIder = await dbcontext.TBTypeSystemDeliverys.OrderByDescending(n => n.IdTypeSystemDelivery == Id).Where(a => a.IdTypeSystemDelivery == Id).ToListAsync();
            return MySlIder;
        }

        public async Task<TBTypeSystemDelivery> GetByIdAsync(int Id)
        {
            TBTypeSystemDelivery sslId = await dbcontext.TBTypeSystemDeliverys.FirstOrDefaultAsync(a => a.IdTypeSystemDelivery == Id && a.CurrentState == true);
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

        public async Task<bool> AddAsync(TBTypeSystemDelivery savee)
        {
            try
            {
                await dbcontext.AddAsync<TBTypeSystemDelivery>(savee);
                await dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(TBTypeSystemDelivery updatss)
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
