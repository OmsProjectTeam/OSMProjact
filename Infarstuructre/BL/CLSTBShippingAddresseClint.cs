

using Microsoft.EntityFrameworkCore;

namespace Infarstuructre.BL
{
    public  interface IIShippingAddresseClint
    {
        List<TBViewShippingAddresseClint> GetAll();
        List<TBViewShippingAddresseClint> GetAllDataentry(string user);
        List<TBViewShippingAddresseClint> GetAllv(int IdShippingAddresseClint);
        TBShippingAddresseClint GetById(int IdShippingAddresseClint);
        bool saveData(TBShippingAddresseClint save);
        bool UpdateData(TBShippingAddresseClint updats);
        bool deleteData(int IdShippingAddresseClint);
    }
    public class CLSTBShippingAddresseClint: IIShippingAddresseClint
    {
        MasterDbcontext dbcontext;
        public CLSTBShippingAddresseClint(MasterDbcontext dbcontext1)
        {
            dbcontext= dbcontext1;
        }
        public List<TBViewShippingAddresseClint> GetAll()
        {
            List<TBViewShippingAddresseClint> MySlider = dbcontext.ViewShippingAddresseClint.OrderByDescending(n => n.IdShippingAddresseClint).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
        public List<TBViewShippingAddresseClint> GetAllDataentry(string user)
        {
            List<TBViewShippingAddresseClint> MySlider = dbcontext.ViewShippingAddresseClint.Where(a => a.DataEntry == user && a.CurrentState == true).ToList();
            return MySlider;
        }
        public List<TBViewShippingAddresseClint> GetAllv(int IdShippingAddresseClint)
        {
            List<TBViewShippingAddresseClint> MySlider = dbcontext.ViewShippingAddresseClint.OrderByDescending(n => n.IdShippingAddresseClint).Where(a => a.IdShippingAddresseClint == IdShippingAddresseClint).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
        public TBShippingAddresseClint GetById(int IdShippingAddresseClint)
        {
            TBShippingAddresseClint sslid = dbcontext.TBShippingAddresseClints.FirstOrDefault(p => p.IdShippingAddresseClint == IdShippingAddresseClint);
            return sslid;
        }
        public bool saveData(TBShippingAddresseClint save)
        {
            try
            {
                dbcontext.Add<TBShippingAddresseClint>(save);
                dbcontext.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateData(TBShippingAddresseClint updats)
        {
            try
            {
                dbcontext.Entry(updats).State = EntityState.Modified;
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool deleteData(int IdShippingAddresseClint)
        {
            try
            {
                var profit = GetById(IdShippingAddresseClint);
                profit.CurrentState = false;
                dbcontext.Entry(profit).State = EntityState.Modified;
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
