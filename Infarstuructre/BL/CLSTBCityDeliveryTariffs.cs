
namespace Infarstuructre.BL
{
    public interface IICityDeliveryTariffs
    {
        List<TBViewCityDeliveryTariffs> GetAll();
        TBCityDeliveryTariffs GetById(int IdCityDeliveryTariffs);
        bool saveData(TBCityDeliveryTariffs savee);
        bool UpdateData(TBCityDeliveryTariffs updatss);
        bool deleteData(int IdCityDeliveryTariffs);
        List<TBViewCityDeliveryTariffs> GetAllv(int IdCityDeliveryTariffs);
    }
    public class CLSTBCityDeliveryTariffs: IICityDeliveryTariffs
    {
        MasterDbcontext dbcontext;
        public CLSTBCityDeliveryTariffs(MasterDbcontext dbcontext1)
        {
            dbcontext= dbcontext1;
        }
        public List<TBViewCityDeliveryTariffs> GetAll()
        {
            List<TBViewCityDeliveryTariffs> MySlider = dbcontext.ViewCityDeliveryTariffs.OrderByDescending(n => n.IdCityDeliveryTariffs).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
        public TBCityDeliveryTariffs GetById(int IdCityDeliveryTariffs)
        {
            TBCityDeliveryTariffs sslid = dbcontext.TBCityDeliveryTariffss.FirstOrDefault(a => a.IdCityDeliveryTariffs == IdCityDeliveryTariffs);
            return sslid;
        }
        public bool saveData(TBCityDeliveryTariffs savee)
        {
            try
            {
                dbcontext.Add<TBCityDeliveryTariffs>(savee);
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateData(TBCityDeliveryTariffs updatss)
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
        public bool deleteData(int IdCityDeliveryTariffs)
        {
            try
            {
                var catr = GetById(IdCityDeliveryTariffs);
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
        public List<TBViewCityDeliveryTariffs> GetAllv(int IdCityDeliveryTariffs)
        {
            List<TBViewCityDeliveryTariffs> MySlider = dbcontext.ViewCityDeliveryTariffs.OrderByDescending(n => n.IdCityDeliveryTariffs == IdCityDeliveryTariffs).Where(a => a.IdCityDeliveryTariffs == IdCityDeliveryTariffs).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }

    }
}
