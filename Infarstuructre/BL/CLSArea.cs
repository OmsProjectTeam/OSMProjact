
using Microsoft.EntityFrameworkCore;

namespace Infarstuructre.BL
{
    public interface IIArea
    {
        List<TBViewAreas> GetAll();
        Area GetById(int Id);
        bool saveData(Area savee);
        bool UpdateData(Area updatss);
        bool deleteData(int Id);
        List<TBViewAreas> GetAllv(int Id);


        //////////////////////////////Api//////////////////////////////////
        
        Task<List<TBViewAreas>> GetAllAsync();
        Task<List<TBViewAreas>> GetAllvAsync(int Id);
        Task<Area> GetByIdAsync(int Id);
        Task<bool> DeleteAsync(int Id);
        Task<bool> AddAsync(Area savee);
        Task<bool> UpdateAsync(Area updatss);
        List<TBViewAreas> GetAllByCityId(int cityId);
    }
    public class CLSArea: IIArea
    {
        MasterDbcontext dbcontext;
        public CLSArea(MasterDbcontext dbcontext1)
        {
            dbcontext=dbcontext1;
        }
        public List<TBViewAreas> GetAll()
        {
            List<TBViewAreas> MySlIder = dbcontext.ViewAreas.OrderByDescending(n => n.id).Where(a => a.CurrentState == true).ToList();
            return MySlIder;
        }
        public Area GetById(int Id)
        {
            Area sslId = dbcontext.areas.FirstOrDefault(a => a.Id == Id);
            return sslId;
        }
        public bool saveData(Area savee)
        {
            try
            {
                dbcontext.Add<Area>(savee);
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateData(Area updatss)
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
        public bool deleteData(int Id)
        {
            try
            {
                var catr = GetById(Id);
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
        public List<TBViewAreas> GetAllv(int Id)
        {
            List<TBViewAreas> MySlIder = dbcontext.ViewAreas.OrderByDescending(n => n.id == Id).Where(a => a.id == Id).ToList();
            return MySlIder;
        }

        public List<TBViewAreas> GetAllByCityId(int cityId)
        {
            return dbcontext.ViewAreas
                .Where(a => a.city_id == cityId && a.CurrentState == true)
                .OrderByDescending(n => n.id)
                .ToList();
        }


        // //////////////////////////////////////////////////////API/////////////////////////////////////////////////////

        public async Task<List<TBViewAreas>> GetAllAsync()
        {
            List<TBViewAreas> MySlIder = await dbcontext.ViewAreas.OrderByDescending(n => n.id).Where(a => a.CurrentState == true).ToListAsync();
            return MySlIder;
        }

        public async Task<List<TBViewAreas>> GetAllvAsync(int Id)
        {
            List<TBViewAreas> MySlIder = await dbcontext.ViewAreas.OrderByDescending(n => n.id == Id).Where(a => a.id == Id).ToListAsync();
            return MySlIder;
        }

        public async Task<Area> GetByIdAsync(int Id)
        {
            Area sslId = await dbcontext.areas.FirstOrDefaultAsync(a => a.Id == Id && a.CurrentState == true);
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

        public async Task<bool> AddAsync(Area savee)
        {
            try
            {
                await dbcontext.AddAsync<Area>(savee);
                await dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(Area updatss)
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
