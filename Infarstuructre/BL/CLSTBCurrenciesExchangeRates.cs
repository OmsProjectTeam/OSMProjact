using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infarstuructre.BL
{
    public interface IICurrenciesExchangeRates
    {
        List<TBCurrenciesExchangeRates> GetAll();
        TBCurrenciesExchangeRates GetById(int IdCurrenciesExchangeRates);
        bool saveData(TBCurrenciesExchangeRates savee);
        bool UpdateData(TBCurrenciesExchangeRates updatss);
        bool deleteData(int IdCurrenciesExchangeRates);
        List<TBCurrenciesExchangeRates> GetAllv(int IdCurrenciesExchangeRates);
    }
    public class CLSTBCurrenciesExchangeRates: IICurrenciesExchangeRates
    {
        MasterDbcontext dbcontext;
        public CLSTBCurrenciesExchangeRates(MasterDbcontext dbcontext1)
        {
            dbcontext = dbcontext1;
        }
        public List<TBCurrenciesExchangeRates> GetAll()
        {
            List<TBCurrenciesExchangeRates> MySlider = dbcontext.TBCurrenciesExchangeRatess.OrderByDescending(n => n.IdCurrenciesExchangeRates).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
        public TBCurrenciesExchangeRates GetById(int IdCurrenciesExchangeRates)
        {
            TBCurrenciesExchangeRates sslid = dbcontext.TBCurrenciesExchangeRatess.FirstOrDefault(a => a.IdCurrenciesExchangeRates == IdCurrenciesExchangeRates);
            return sslid;
        }
        public bool saveData(TBCurrenciesExchangeRates savee)
        {
            try
            {
                dbcontext.Add<TBCurrenciesExchangeRates>(savee);
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateData(TBCurrenciesExchangeRates updatss)
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
        public bool deleteData(int IdCurrenciesExchangeRates)
        {
            try
            {
                var catr = GetById(IdCurrenciesExchangeRates);
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
        public List<TBCurrenciesExchangeRates> GetAllv(int IdCurrenciesExchangeRates)
        {
            List<TBCurrenciesExchangeRates> MySlider = dbcontext.TBCurrenciesExchangeRatess.OrderByDescending(n => n.IdCurrenciesExchangeRates == IdCurrenciesExchangeRates).Where(a => a.IdCurrenciesExchangeRates == IdCurrenciesExchangeRates).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }

    }
}
