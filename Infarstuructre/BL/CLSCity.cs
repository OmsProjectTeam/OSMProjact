

using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infarstuructre.BL
{
    public interface IICity
    {
        List<City> GetAll();
        City GetById(int Id);
        bool saveData(City savee);
        bool UpdateData(City updatss);
        bool deleteData(int Id);
        List<City> GetAllv(int Id);
        // //////////////////////////////API//////////////////////////////////////
        Task<List<City>> GetAllAsync(int pageNumber, int pageSize);
        Task<List<City>> GetAllvAsync(int Id);
        Task<City> GetByIdAsync(int Id);
        Task<bool> DeleteAsync(int Id);
        Task<bool> AddAsync(City savee);
        Task<bool> UpdateAsync(City updatss);
        Task<List<City>> GetAlWithConditionAsync(Expression<Func<City, bool>> condition);
    }
    public class CLSCity: IICity
    {
        MasterDbcontext dbcontext;
        public CLSCity(MasterDbcontext dbcontext1)
        {
            dbcontext = dbcontext1;
        }
        public List<City> GetAll()
        {
            List<City> MySlider = dbcontext.cities.OrderByDescending(n => n.Id).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
        public City GetById(int Id)
        {
            City sslid = dbcontext.cities.FirstOrDefault(a => a.Id == Id);
            return sslid;
        }
        public bool saveData(City savee)
        {
            try
            {
                dbcontext.Add<City>(savee);
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateData(City updatss)
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
                //var catr = GetById(Id);
                //catr.CurrentState = false;
                ////TbSubCateegoory dele = dbcontex.TbSubCateegoorys.Where(a => a.IdBrand == IdBrand).FirstOrDefault();
                ////dbcontex.TbSubCateegoorys.Remove(dele);
                //dbcontext.Entry(catr).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                //dbcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public List<City> GetAllv(int Id)
        {
            List<City> MySlider = dbcontext.cities.OrderByDescending(n => n.Id == Id).Where(a => a.Id == Id).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }

        // //////////////////////////////////////////////////////API/////////////////////////////////////////////////////

        public async Task<List<City>> GetAllAsync(int pageNumber, int pageSize)
        {
            List<City> MySlIder = await dbcontext.cities.OrderByDescending(n => n.Id).Where(a => a.CurrentState == true).Skip((pageNumber - 1) * pageSize)
                .Take(pageSize).ToListAsync();
            return MySlIder;
        }

        public async Task<List<City>> GetAlWithConditionAsync(Expression<Func<City, bool>> condition)
        {
            List<City> data = await dbcontext.cities.Where(condition).ToListAsync();
            return data;
        }

        public async Task<List<City>> GetAllvAsync(int Id)
        {
            List<City> MySlIder = await dbcontext.cities.OrderByDescending(n => n.Id == Id).Where(a => a.Id == Id).ToListAsync();
            return MySlIder;
        }

        public async Task<City> GetByIdAsync(int Id)
        {
            City sslId = await dbcontext.cities.FirstOrDefaultAsync(a => a.Id == Id && a.CurrentState == true);
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

        public async Task<bool> AddAsync(City savee)
        {
            try
            {
                await dbcontext.AddAsync<City>(savee);
                await dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(City updatss)
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
