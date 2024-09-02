using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infarstuructre.BL
{
    public interface IIEmailNewsletter
    {
        List<TBEmailNewsletter> GetAll();
        TBEmailNewsletter GetById(int IdEmailNewsletter);
        bool saveData(TBEmailNewsletter save);
        bool UpdateData(TBEmailNewsletter update);
        bool DeleteData(int IdEmailNewsletter);
        List<TBEmailNewsletter> GetAllSubscribed();

        /////////////////////////////API///////////////////////////////////////
        ///
        Task<List<TBEmailNewsletter>> GetAllAsync(int pageNumber, int pageSize);
        Task<List<TBEmailNewsletter>> GetAllSubscribedAsync(int Id);
        Task<TBEmailNewsletter> GetByIdAsync(int Id);
        Task<bool> DeleteAsync(int Id);
        Task<bool> AddAsync(TBEmailNewsletter savee);
        Task<bool> UpdateAsync(TBEmailNewsletter updatss);
    }

    public class CLSTBEmailNewsletter : IIEmailNewsletter
    {
        MasterDbcontext dbcontext;
        public CLSTBEmailNewsletter(MasterDbcontext dbcontext1)
        {
            dbcontext = dbcontext1;
        }

        public List<TBEmailNewsletter> GetAll()
        {
            return dbcontext.TBEmailNewsletters
                             .OrderByDescending(n => n.IdEmailNewsletter)
                             .Where(n => n.CurrentState)
                             .ToList();
        }

        public TBEmailNewsletter GetById(int IdEmailNewsletter)
        {
            return dbcontext.TBEmailNewsletters
                             .FirstOrDefault(n => n.IdEmailNewsletter == IdEmailNewsletter);
        }

        public bool saveData(TBEmailNewsletter savee)
        {
            try
            {
                dbcontext.TBEmailNewsletters.Add(savee);
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateData(TBEmailNewsletter updatee)
        {
            try
            {
                dbcontext.Entry(updatee).State = EntityState.Modified;
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteData(int IdEmailNewsletter)
        {
            try
            {
                var entity = GetById(IdEmailNewsletter);
                if (entity != null)
                {
                    entity.CurrentState = false;
                    dbcontext.Entry(entity).State = EntityState.Modified;
                    dbcontext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<TBEmailNewsletter> GetAllSubscribed()
        {
            return dbcontext.TBEmailNewsletters
                             .Where(n => n.IsSubscribed && n.CurrentState)
                             .ToList();
        }

        // //////////////////////////////////////////////////////API/////////////////////////////////////////////////////

        public async Task<List<TBEmailNewsletter>> GetAllAsync(int pageNumber, int pageSize)
        {
            List<TBEmailNewsletter> MySlIder = await dbcontext.TBEmailNewsletters.OrderByDescending(n => n.IdEmailNewsletter)
                                                                             .Where(n => n.CurrentState)
                                                                             .Skip((pageNumber - 1) * pageSize)
                                                                             .Take(pageSize).ToListAsync();
            return MySlIder;
        }

        public async Task<List<TBEmailNewsletter>> GetAllSubscribedAsync(int Id)
        {
            List<TBEmailNewsletter> MySlIder = await dbcontext.TBEmailNewsletters.Where(n => n.IsSubscribed && n.CurrentState).ToListAsync();
            return MySlIder;
        }

        public async Task<TBEmailNewsletter> GetByIdAsync(int Id)
        {
            TBEmailNewsletter sslId = await dbcontext.TBEmailNewsletters.FirstOrDefaultAsync(a => a.IdEmailNewsletter == Id && a.CurrentState);
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

        public async Task<bool> AddAsync(TBEmailNewsletter savee)
        {
            try
            {
                await dbcontext.AddAsync<TBEmailNewsletter>(savee);
                await dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(TBEmailNewsletter updatss)
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
