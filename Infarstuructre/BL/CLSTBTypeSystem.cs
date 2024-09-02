
using Microsoft.EntityFrameworkCore;

namespace Infarstuructre.BL
{
    public interface IITypeSystem
    {
        List<TBTypeSystem> GetAll();
        TBTypeSystem GetById(int IdTypeSystem);
        bool saveData(TBTypeSystem savee);
        bool UpdateData(TBTypeSystem updatss);
        bool deleteData(int IdTypeSystem);
        public List<TBTypeSystem> GetAllv(int IdTypeSystem);

        //////////////////////////////Api//////////////////////////////////

        Task<List<TBTypeSystem>> GetAllAsync(int pageNumber, int pageSize);
        Task<List<TBTypeSystem>> GetAllvAsync(int Id);
        Task<TBTypeSystem> GetByIdAsync(int Id);
        Task<bool> DeleteAsync(int Id);
        Task<bool> AddAsync(TBTypeSystem savee);
        Task<bool> UpdateAsync(TBTypeSystem updatss);

    }
    public class CLSTBTypeSystem: IITypeSystem
    {
        MasterDbcontext dbcontext;
        public CLSTBTypeSystem(MasterDbcontext dbcontext1)
        {
            dbcontext=dbcontext1;
        }
        public List<TBTypeSystem> GetAll()
        {
            List<TBTypeSystem> MySlider = dbcontext.TBTypeSystems.OrderByDescending(n => n.IdTypeSystem).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
        public TBTypeSystem GetById(int IdTypeSystem)
        {
            TBTypeSystem sslid = dbcontext.TBTypeSystems.FirstOrDefault(a => a.IdTypeSystem == IdTypeSystem);
            return sslid;
        }
        public bool saveData(TBTypeSystem savee)
        {
            try
            {
                dbcontext.Add<TBTypeSystem>(savee);
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateData(TBTypeSystem updatss)
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
        public bool deleteData(int IdTypeSystem)
        {
            try
            {
                var catr = GetById(IdTypeSystem);
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
        public List<TBTypeSystem> GetAllv(int IdTypeSystem)
        {
            List<TBTypeSystem> MySlider = dbcontext.TBTypeSystems.OrderByDescending(n => n.IdTypeSystem == IdTypeSystem).Where(a => a.IdTypeSystem == IdTypeSystem).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }

        // //////////////////////////////////////////////////////API/////////////////////////////////////////////////////

        public async Task<List<TBTypeSystem>> GetAllAsync(int pageNumber, int pageSize)
        {
            List<TBTypeSystem> MySlIder = await dbcontext.TBTypeSystems.OrderByDescending(n => n.IdTypeSystem).Where(a => a.CurrentState == true).Skip((pageNumber - 1) * pageSize)
                .Take(pageSize).ToListAsync();
            return MySlIder;
        }

        public async Task<List<TBTypeSystem>> GetAllvAsync(int Id)
        {
            List<TBTypeSystem> MySlIder = await dbcontext.TBTypeSystems.OrderByDescending(n => n.IdTypeSystem == Id).Where(a => a.IdTypeSystem == Id).ToListAsync();
            return MySlIder;
        }

        public async Task<TBTypeSystem> GetByIdAsync(int Id)
        {
            TBTypeSystem sslId = await dbcontext.TBTypeSystems.FirstOrDefaultAsync(a => a.IdTypeSystem == Id && a.CurrentState == true);
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

        public async Task<bool> AddAsync(TBTypeSystem savee)
        {
            try
            {
                await dbcontext.AddAsync<TBTypeSystem>(savee);
                await dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(TBTypeSystem updatss)
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
