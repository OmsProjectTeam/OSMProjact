
namespace Infarstuructre.BL
{
    public interface IIAreaDeliveryTariffs
    {
        List<TBViewAreaDeliveryTariffs> GetAll();
        TBAreaDeliveryTariffs GetById(int IdAreaDeliveryTariffs);
        bool saveData(TBAreaDeliveryTariffs savee);
        bool UpdateData(TBAreaDeliveryTariffs updatss);
        bool deleteData(int IdAreaDeliveryTariffs);
        List<TBViewAreaDeliveryTariffs> GetAllv(int IdAreaDeliveryTariffs);
    }
    public class CLSTBAreaDeliveryTariffs: IIAreaDeliveryTariffs
    {
        MasterDbcontext dbcontext;
        public CLSTBAreaDeliveryTariffs(MasterDbcontext dbcontext1)
        {
            dbcontext=dbcontext1;
        }
        public List<TBViewAreaDeliveryTariffs> GetAll()
        {
            List<TBViewAreaDeliveryTariffs> MySlider = dbcontext.ViewAreaDeliveryTariffs.OrderByDescending(n => n.IdAreaDeliveryTariffs).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
        public TBAreaDeliveryTariffs GetById(int IdAreaDeliveryTariffs)
        {
            TBAreaDeliveryTariffs sslid = dbcontext.TBAreaDeliveryTariffss.FirstOrDefault(a => a.IdAreaDeliveryTariffs == IdAreaDeliveryTariffs);
            return sslid;
        }
        public bool saveData(TBAreaDeliveryTariffs savee)
        {
            try
            {
                dbcontext.Add<TBAreaDeliveryTariffs>(savee);
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateData(TBAreaDeliveryTariffs updatss)
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
        public bool deleteData(int IdAreaDeliveryTariffs)
        {
            try
            {
                var catr = GetById(IdAreaDeliveryTariffs);
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
        public List<TBViewAreaDeliveryTariffs> GetAllv(int IdAreaDeliveryTariffs)
        {
            List<TBViewAreaDeliveryTariffs> MySlider = dbcontext.ViewAreaDeliveryTariffs.OrderByDescending(n => n.IdAreaDeliveryTariffs == IdAreaDeliveryTariffs).Where(a => a.IdAreaDeliveryTariffs == IdAreaDeliveryTariffs).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
    }
}
