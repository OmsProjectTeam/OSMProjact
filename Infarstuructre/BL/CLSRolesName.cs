

using Microsoft.EntityFrameworkCore;

namespace Infarstuructre.BL
{
    public interface IIRolesName
    {
        List<RolesName> GetAll();
        RolesName GetById(int Id);
        bool saveData(RolesName savee);
        bool UpdateData(RolesName updatss);
        bool deleteData(int Id);
        /////////////////////////////API////////////////////////////////////////////////
        ///
        Task<List<RolesName>> GetAllAsync(int pageNumber, int pageSize);
        Task<RolesName> GetByIdAsync(int Id);
        Task<bool> DeleteAsync(int Id);
        Task<bool> AddAsync(RolesName savee);
        Task<bool> UpdateAsync(RolesName updatss);

    }

    public class CLSRolesName: IIRolesName
    {
        MasterDbcontext dbcontext;
        public CLSRolesName(MasterDbcontext dbcontext1)
        {
            dbcontext=dbcontext1;
        }
        public List<RolesName> GetAll()
        {
            List<RolesName> MySlider = dbcontext.RolesNames.OrderByDescending(n => n.Id).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
        public RolesName GetById(int Id)
        {
            RolesName sslid = dbcontext.RolesNames.FirstOrDefault(a => a.Id == Id);
            return sslid;
        }
        public bool saveData(RolesName savee)
        {
            try
            {
                dbcontext.Add<RolesName>(savee);
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateData(RolesName updatss)
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

        // //////////////////////////////////////////////////////API/////////////////////////////////////////////////////

        public async Task<List<RolesName>> GetAllAsync(int pageNumber, int pageSize)
        {
            List<RolesName> MySlIder = await dbcontext.RolesNames.OrderByDescending(n => n.Id).Where(a => a.CurrentState == true).Skip((pageNumber - 1) * pageSize)
                .Take(pageSize).ToListAsync();
            return MySlIder;
        }

        public async Task<RolesName> GetByIdAsync(int Id)
        {
            RolesName sslId = await dbcontext.RolesNames.FirstOrDefaultAsync(a => a.Id == Id && a.CurrentState == true);
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

        public async Task<bool> AddAsync(RolesName savee)
        {
            try
            {
                await dbcontext.AddAsync<RolesName>(savee);
                await dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(RolesName updatss)
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
