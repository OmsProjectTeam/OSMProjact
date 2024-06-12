
namespace Infarstuructre.BL
{
    public interface IIShippingPrice
    {
        List<TBViewShippingPrices> GetAll();
        TBShippingPrice GetById(int IdShipping);
        bool saveData(TBShippingPrice savee);
        bool UpdateData(TBShippingPrice updatss);
        bool deleteData(int IdShipping);
        List<TBViewShippingPrices> GetAllv(int IdShipping);
    }

    public class CLSTBShippingPrice: IIShippingPrice
    {
        MasterDbcontext dbcontext;
        public CLSTBShippingPrice(MasterDbcontext dbcontext1)
        {
            dbcontext=dbcontext1;
        }
        public List<TBViewShippingPrices> GetAll()
        {
            List<TBViewShippingPrices> MySlider = dbcontext.ViewShippingPrices.OrderByDescending(n => n.IdShipping).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
        public TBShippingPrice GetById(int IdShipping)
        {
            TBShippingPrice sslid = dbcontext.TBShippingPrices.FirstOrDefault(a => a.IdShipping == IdShipping);
            return sslid;
        }
        public bool saveData(TBShippingPrice savee)
        {
            try
            {
                dbcontext.Add<TBShippingPrice>(savee);
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateData(TBShippingPrice updatss)
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
        public bool deleteData(int IdShipping)
        {
            try
            {
                var catr = GetById(IdShipping);
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
        public List<TBViewShippingPrices> GetAllv(int IdShipping)
        {
            List<TBViewShippingPrices> MySlider = dbcontext.ViewShippingPrices.OrderByDescending(n => n.IdShipping == IdShipping).Where(a => a.IdShipping == IdShipping).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
    }
}
