

namespace Infarstuructre.BL
{
    public interface IIExchangeRate
    {
        List<TBViewExchangeRate> GetAll();
        TBExchangeRate GetById(int IdExchangeRate);
        bool saveData(TBExchangeRate savee);
        bool UpdateData(TBExchangeRate updatss);
        bool deleteData(int IdExchangeRate);
        List<TBViewExchangeRate> GetAllv(int IdExchangeRate);
        public class CLSTBExchangeRate : IIExchangeRate
        {
            MasterDbcontext dbcontext;
            public CLSTBExchangeRate(MasterDbcontext dbcontext1)
            {
                dbcontext = dbcontext1;
            }
            public List<TBViewExchangeRate> GetAll()
            {
                List<TBViewExchangeRate> MySlider = dbcontext.ViewExchangeRate.OrderByDescending(n => n.IdExchangeRate).Where(a => a.CurrentState == true).ToList();
                return MySlider;
            }
            public TBExchangeRate GetById(int IdExchangeRate)
            {
                TBExchangeRate sslid = dbcontext.TBExchangeRates.FirstOrDefault(a => a.IdExchangeRate == IdExchangeRate);
                return sslid;
            }
            public bool saveData(TBExchangeRate savee)
            {
                try
                {
                    dbcontext.Add<TBExchangeRate>(savee);
                    dbcontext.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            public bool UpdateData(TBExchangeRate updatss)
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
            public bool deleteData(int IdExchangeRate)
            {
                try
                {
                    var catr = GetById(IdExchangeRate);
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
            public List<TBViewExchangeRate> GetAllv(int IdExchangeRate)
            {
                List<TBViewExchangeRate> MySlider = dbcontext.ViewExchangeRate.OrderByDescending(n => n.IdExchangeRate == IdExchangeRate).Where(a => a.IdExchangeRate == IdExchangeRate).Where(a => a.CurrentState == true).ToList();
                return MySlider;
            }

        }
    }
}
