
namespace Infarstuructre.BL
{
    public interface IIClintWitheDeliveryTariffs
    {
        List<TBViewClintWitheDeliveryTariffs> GetAll();
        TBClintWitheDeliveryTariffs GetById(int IdClintWitheDeliveryTariffs);
        bool saveData(TBClintWitheDeliveryTariffs savee);
        bool UpdateData(TBClintWitheDeliveryTariffs updatss);
        bool deleteData(int IdClintWitheDeliveryTariffs);
        List<TBViewClintWitheDeliveryTariffs> GetAllv(int IdClintWitheDeliveryTariffs);
    }
    public class CLSTBClintWitheDeliveryTariffs: IIClintWitheDeliveryTariffs
    {
        MasterDbcontext dbcontext;
        public CLSTBClintWitheDeliveryTariffs(MasterDbcontext dbcontext1)
        {
            dbcontext  = dbcontext1;
        }
        public List<TBViewClintWitheDeliveryTariffs> GetAll()
        {
            List<TBViewClintWitheDeliveryTariffs> MySlider = dbcontext.ViewClintWitheDeliveryTariffs.OrderByDescending(n => n.IdClintWitheDeliveryTariffs).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
        public TBClintWitheDeliveryTariffs GetById(int IdClintWitheDeliveryTariffs)
        {
            TBClintWitheDeliveryTariffs sslid = dbcontext.TBClintWitheDeliveryTariffss.FirstOrDefault(a => a.IdClintWitheDeliveryTariffs == IdClintWitheDeliveryTariffs);
            return sslid;
        }
        public bool saveData(TBClintWitheDeliveryTariffs savee)
        {
            try
            {
                dbcontext.Add<TBClintWitheDeliveryTariffs>(savee);
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateData(TBClintWitheDeliveryTariffs updatss)
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
        public bool deleteData(int IdClintWitheDeliveryTariffs)
        {
            try
            {
                var catr = GetById(IdClintWitheDeliveryTariffs);
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
        public List<TBViewClintWitheDeliveryTariffs> GetAllv(int IdClintWitheDeliveryTariffs)
        {
            List<TBViewClintWitheDeliveryTariffs> MySlider = dbcontext.ViewClintWitheDeliveryTariffs.OrderByDescending(n => n.IdClintWitheDeliveryTariffs == IdClintWitheDeliveryTariffs).Where(a => a.IdClintWitheDeliveryTariffs == IdClintWitheDeliveryTariffs).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
    }
}
