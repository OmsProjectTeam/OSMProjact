

using Microsoft.EntityFrameworkCore;

namespace Infarstuructre.BL
{
    public interface IISupportTicketStatus
    {
        List<TBSupportTicketStatus> GetAll();
        TBSupportTicketStatus GetById(int IdSupportTicketStatus);
        bool saveData(TBSupportTicketStatus savee);
        bool UpdateData(TBSupportTicketStatus updatss);
        bool deleteData(int IdSupportTicketStatus);
        List<TBSupportTicketStatus> GetAllv(int IdSupportTicketStatus);

        ////////////////////////////API///////////////////////////////////////
        ///
        Task<List<TBSupportTicketStatus>> GetAllAsync(int pageNumber, int pageSize);
        Task<List<TBSupportTicketStatus>> GetAllvAsync(int Id);
        Task<TBSupportTicketStatus> GetByIdAsync(int Id);
        Task<bool> DeleteAsync(int Id);
        Task<bool> AddAsync(TBSupportTicketStatus savee);
        Task<bool> UpdateAsync(TBSupportTicketStatus updatss);
    }
    public class CLSTBSupportTicketStatus: IISupportTicketStatus
    {
        MasterDbcontext dbcontext;
        public CLSTBSupportTicketStatus(MasterDbcontext dbcontext1)
        {
            dbcontext=dbcontext1;
        }

        public List<TBSupportTicketStatus> GetAll()
        {
            List<TBSupportTicketStatus> MySlider = dbcontext.TBSupportTicketStatuss.OrderByDescending(n => n.IdSupportTicketStatus).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
        public TBSupportTicketStatus GetById(int IdSupportTicketStatus)
        {
            TBSupportTicketStatus sslid = dbcontext.TBSupportTicketStatuss.FirstOrDefault(a => a.IdSupportTicketStatus == IdSupportTicketStatus);
            return sslid;
        }
        public bool saveData(TBSupportTicketStatus savee)
        {
            try
            {
                dbcontext.Add<TBSupportTicketStatus>(savee);
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateData(TBSupportTicketStatus updatss)
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
        public bool deleteData(int IdSupportTicketStatus)
        {
            try
            {
                var catr = GetById(IdSupportTicketStatus);
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
        public List<TBSupportTicketStatus> GetAllv(int IdSupportTicketStatus)
        {
            List<TBSupportTicketStatus> MySlider = dbcontext.TBSupportTicketStatuss.OrderByDescending(n => n.IdSupportTicketStatus == IdSupportTicketStatus).Where(a => a.IdSupportTicketStatus == IdSupportTicketStatus).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }

        // //////////////////////////////////////////////////////API/////////////////////////////////////////////////////

        public async Task<List<TBSupportTicketStatus>> GetAllAsync(int pageNumber, int pageSize)
        {
            List<TBSupportTicketStatus> MySlIder = await dbcontext.TBSupportTicketStatuss.OrderByDescending(n => n.IdSupportTicketStatus)
                .Where(a => a.CurrentState == true).Skip((pageNumber - 1) * pageSize)
                .Take(pageSize).ToListAsync();
            return MySlIder;
        }

        public async Task<List<TBSupportTicketStatus>> GetAllvAsync(int Id)
        {
            List<TBSupportTicketStatus> MySlIder = await dbcontext.TBSupportTicketStatuss.OrderByDescending(n => n.IdSupportTicketStatus == Id).Where(a => a.IdSupportTicketStatus == Id).ToListAsync();
            return MySlIder;
        }

        public async Task<TBSupportTicketStatus> GetByIdAsync(int Id)
        {
            TBSupportTicketStatus sslId = await dbcontext.TBSupportTicketStatuss.FirstOrDefaultAsync(a => a.IdSupportTicketStatus == Id && a.CurrentState == true);
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

        public async Task<bool> AddAsync(TBSupportTicketStatus savee)
        {
            try
            {
                await dbcontext.AddAsync<TBSupportTicketStatus>(savee);
                await dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(TBSupportTicketStatus updatss)
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
