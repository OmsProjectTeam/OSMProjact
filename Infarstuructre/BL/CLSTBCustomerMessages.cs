
using Microsoft.EntityFrameworkCore;

namespace Infarstuructre.BL
{
    public interface IICustomerMessages
    {
        List<TBViewCustomerMessages> GetAll();
        TBCustomerMessages GetById(int IdCustomerMessages);
        bool saveData(TBCustomerMessages savee);
        bool UpdateData(TBCustomerMessages update);
        bool deleteData(int IdCustomerMessages);
        List<TBViewCustomerMessages> GetAllv(int IdCustomerMessages);
        List<TBViewCustomerMessages> GetAllDataentry(string dataEntry);
        ///////////////////////////////API/////////////////////////////////////////////////
        ///
        Task<List<TBViewCustomerMessages>> GetAllAsync(int pageNumber, int pageSize);
        Task<List<TBViewCustomerMessages>> GetAllvAsync(int Id);
        Task<List<TBViewCustomerMessages>> GetAllDataentryAsync(string dataEntry);
        Task<TBCustomerMessages> GetByIdAsync(int Id);
        Task<bool> DeleteAsync(int Id);
        Task<bool> AddAsync(TBCustomerMessages savee);
        Task<bool> UpdateAsync(TBCustomerMessages updatss);
    }
    public class CLSTBCustomerMessages: IICustomerMessages
    {
        MasterDbcontext dbcontext;
        public CLSTBCustomerMessages(MasterDbcontext dbcontext1)
        {
            dbcontext = dbcontext1;
        }
        public List<TBViewCustomerMessages> GetAll()
        {
            List<TBViewCustomerMessages> MySlider = dbcontext.ViewCustomerMessages.OrderByDescending(n => n.IdCustomerMessages).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
        public TBCustomerMessages GetById(int IdCustomerMessages)
        {
            TBCustomerMessages sslid = dbcontext.TBCustomerMessagess.FirstOrDefault(a => a.IdCustomerMessages == IdCustomerMessages);
            return sslid;
        }
        public bool saveData(TBCustomerMessages savee)
        {
            try
            {
                dbcontext.Add<TBCustomerMessages>(savee);
                dbcontext.SaveChanges();           
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateData(TBCustomerMessages update)
        {
            try
            {
                dbcontext.Entry(update).State = EntityState.Modified;
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool deleteData(int IdCustomerMessages)
        {
            try
            {
                var paid = GetById(IdCustomerMessages);
                paid.CurrentState = false;
                dbcontext.Entry(paid).State = EntityState.Modified;
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public List<TBViewCustomerMessages> GetAllv(int IdCustomerMessages)
        {
            List<TBViewCustomerMessages> MySlider = dbcontext.ViewCustomerMessages.OrderByDescending(n => n.IdCustomerMessages).Where(a => a.IdCustomerMessages == IdCustomerMessages).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
        public List<TBViewCustomerMessages> GetAllDataentry(string dataEntry)
        {
            List<TBViewCustomerMessages> MySlider = dbcontext.ViewCustomerMessages.Where(a => a.DataEntry == dataEntry && a.CurrentState == true).ToList();
            return MySlider;
        }
        // //////////////////////////////////////////////////////API/////////////////////////////////////////////////////

        public async Task<List<TBViewCustomerMessages>> GetAllAsync(int pageNumber, int pageSize)
        {
            List<TBViewCustomerMessages> MySlIder = await dbcontext.ViewCustomerMessages.OrderByDescending(n => n.IdCustomerMessages).Where(a => a.CurrentState == true)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize).ToListAsync();
            return MySlIder;
        }

        public async Task<List<TBViewCustomerMessages>> GetAllvAsync(int Id)
        {
            List<TBViewCustomerMessages> MySlIder = await dbcontext.ViewCustomerMessages.OrderByDescending(n => n.IdCustomerMessages == Id).Where(a => a.IdCustomerMessages == Id).ToListAsync();
            return MySlIder;
        }

        public async Task<List<TBViewCustomerMessages>> GetAllDataentryAsync(string dataEntry)
        {
            List<TBViewCustomerMessages> MySlider = await dbcontext.ViewCustomerMessages.Where(a => a.DataEntry == dataEntry && a.CurrentState == true).ToListAsync();
            return MySlider;
        }

        public async Task<TBCustomerMessages> GetByIdAsync(int Id)
        {
            TBCustomerMessages sslId = await dbcontext.TBCustomerMessagess.FirstOrDefaultAsync(a => a.IdCustomerMessages == Id && a.CurrentState == true);
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

        public async Task<bool> AddAsync(TBCustomerMessages savee)
        {
            try
            {
                await dbcontext.AddAsync<TBCustomerMessages>(savee);
                await dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(TBCustomerMessages updatss)
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