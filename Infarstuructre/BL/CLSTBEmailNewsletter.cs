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
    }
}
