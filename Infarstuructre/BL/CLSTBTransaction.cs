
using Microsoft.EntityFrameworkCore;

namespace Infarstuructre.BL
{
    public interface IITransaction
    {
        List<TBViewTransaction> GetAll();
        TBTransaction GetById(int IdTransaction);
        bool saveData(TBTransaction savee);
        bool UpdateData(TBTransaction updatss);
        bool deleteData(int IdTransaction);
        List<TBViewTransaction> GetAllv(int IdTransaction);

        /////////////////////////////////////API////////////////////////////////////////
        ///
        Task<List<TBViewTransaction>> GetAllAsync(int pageNumber, int pageSize);
        Task<List<TBViewTransaction>> GetAllvAsync(int Id);
        Task<TBTransaction> GetByIdAsync(int Id);
        Task<bool> DeleteAsync(int Id);
        Task<bool> AddAsync(TBTransaction savee);
        Task<bool> UpdateAsync(TBTransaction updatss);
    }

    public class CLSTBTransaction: IITransaction
    {
        MasterDbcontext dbcontext;
        public CLSTBTransaction(MasterDbcontext dbcontext1)
        {
            dbcontext=dbcontext1;
        }
        public List<TBViewTransaction> GetAll()
        {
            List<TBViewTransaction> MySlider = dbcontext.ViewTransaction.OrderByDescending(n => n.IdTransaction).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
        public TBTransaction GetById(int IdTransaction)
        {
            TBTransaction sslid = dbcontext.TBTransactions.FirstOrDefault(a => a.IdTransaction == IdTransaction);
            return sslid;
        }
        public bool saveData(TBTransaction savee)
        {
            try
            {
                dbcontext.Add<TBTransaction>(savee);
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateData(TBTransaction updatss)
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
        public bool deleteData(int IdTransaction)
        {
            try
            {
                var catr = GetById(IdTransaction);
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
        public List<TBViewTransaction> GetAllv(int IdTransaction)
        {
            List<TBViewTransaction> MySlider = dbcontext.ViewTransaction.OrderByDescending(n => n.IdTransaction == IdTransaction).Where(a => a.IdTransaction == IdTransaction).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }

        // //////////////////////////////////////////////////////API/////////////////////////////////////////////////////

        public async Task<List<TBViewTransaction>> GetAllAsync(int pageNumber, int pageSize)
        {
            List<TBViewTransaction> MySlIder = await dbcontext.ViewTransaction.OrderByDescending(n => n.IdTransaction).Where(a => a.CurrentState == true)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize).ToListAsync();
            return MySlIder;
        }

        public async Task<List<TBViewTransaction>> GetAllvAsync(int Id)
        {
            List<TBViewTransaction> MySlIder = await dbcontext.ViewTransaction.OrderByDescending(n => n.IdTransaction == Id).Where(a => a.IdTransaction == Id).ToListAsync();
            return MySlIder;
        }

        public async Task<TBTransaction> GetByIdAsync(int Id)
        {
            TBTransaction sslId = await dbcontext.TBTransactions.FirstOrDefaultAsync(a => a.IdTransaction == Id && a.CurrentState == true);
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

        public async Task<bool> AddAsync(TBTransaction savee)
        {
            try
            {
                await dbcontext.AddAsync<TBTransaction>(savee);
                await dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(TBTransaction updatss)
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
