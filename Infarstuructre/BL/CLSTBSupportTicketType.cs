

using Microsoft.EntityFrameworkCore;

namespace Infarstuructre.BL
{
    public interface IISupportTicketType
    {
        List<TBSupportTicketType> GetAll();
        TBSupportTicketType GetById(int IdSupportTicketType);
        bool saveData(TBSupportTicketType savee);
        bool UpdateData(TBSupportTicketType updatss);
        bool deleteData(int IdSupportTicketType);
        List<TBSupportTicketType> GetAllv(int IdSupportTicketType);

        ////////////////////////////API/////////////////////////////////////////////
        ///
        Task<List<TBSupportTicketType>> GetAllAsync(int pageNumber, int pageSize);
        Task<List<TBSupportTicketType>> GetAllvAsync(int Id);
        Task<TBSupportTicketType> GetByIdAsync(int Id);
        Task<bool> DeleteAsync(int Id);
        Task<bool> AddAsync(TBSupportTicketType savee);
        Task<bool> UpdateAsync(TBSupportTicketType updatss);
    }
    public class CLSTBSupportTicketType: IISupportTicketType
    {
        MasterDbcontext dbcontext;
        public CLSTBSupportTicketType(MasterDbcontext dbcontext1)
        {
            dbcontext = dbcontext1;
        }
        public List<TBSupportTicketType> GetAll()
        {
            List<TBSupportTicketType> MySlider = dbcontext.TBSupportTicketTypes.OrderByDescending(n => n.IdSupportTicketType).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
        public TBSupportTicketType GetById(int IdSupportTicketType)
        {
            TBSupportTicketType sslid = dbcontext.TBSupportTicketTypes.FirstOrDefault(a => a.IdSupportTicketType == IdSupportTicketType);
            return sslid;
        }
        public bool saveData(TBSupportTicketType savee)
        {
            try
            {
                dbcontext.Add<TBSupportTicketType>(savee);
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateData(TBSupportTicketType updatss)
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
        public bool deleteData(int IdSupportTicketType)
        {
            try
            {
                var catr = GetById(IdSupportTicketType);
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
        public List<TBSupportTicketType> GetAllv(int IdSupportTicketType)
        {
            List<TBSupportTicketType> MySlider = dbcontext.TBSupportTicketTypes.OrderByDescending(n => n.IdSupportTicketType == IdSupportTicketType).Where(a => a.IdSupportTicketType == IdSupportTicketType).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }

        // //////////////////////////////////////////////////////API/////////////////////////////////////////////////////

        public async Task<List<TBSupportTicketType>> GetAllAsync(int pageNumber, int pageSize)
        {
            List<TBSupportTicketType> MySlIder = await dbcontext.TBSupportTicketTypes.OrderByDescending(n => n.IdSupportTicketType)
                .Where(a => a.CurrentState == true).Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return MySlIder;
        }

        public async Task<List<TBSupportTicketType>> GetAllvAsync(int Id)
        {
            List<TBSupportTicketType> MySlIder = await dbcontext.TBSupportTicketTypes.OrderByDescending(n => n.IdSupportTicketType == Id).Where(a => a.IdSupportTicketType == Id).ToListAsync();
            return MySlIder;
        }

        public async Task<TBSupportTicketType> GetByIdAsync(int Id)
        {
            TBSupportTicketType sslId = await dbcontext.TBSupportTicketTypes.FirstOrDefaultAsync(a => a.IdSupportTicketType == Id && a.CurrentState == true);
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

        public async Task<bool> AddAsync(TBSupportTicketType savee)
        {
            try
            {
                await dbcontext.AddAsync<TBSupportTicketType>(savee);
                await dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(TBSupportTicketType updatss)
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
