

using Domin.Entity;

namespace Infarstuructre.BL
{
    public interface IITypeSystemDelivery
    {
        List<TBTypeSystemDelivery> GetAll();
        TBTypeSystemDelivery GetById(int IdTypeSystemDelivery);
        bool saveData(TBTypeSystemDelivery savee);
        bool UpdateData(TBTypeSystemDelivery updatss);
        bool deleteData(int IdTypeSystemDelivery);
        List<TBTypeSystemDelivery> GetAllv(int IdTypeSystemDelivery);
    }
    public class CLSTBTypeSystemDelivery: IITypeSystemDelivery
    {
        MasterDbcontext dbcontext;

        public CLSTBTypeSystemDelivery(MasterDbcontext dbcontex1)
        {
            dbcontext= dbcontex1;
        }

        public List<TBTypeSystemDelivery> GetAll()
        {
            List<TBTypeSystemDelivery> MySlider = dbcontext.TBTypeSystemDeliverys.OrderByDescending(n => n.IdTypeSystemDelivery).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
        public TBTypeSystemDelivery GetById(int IdTypeSystemDelivery)
        {
            TBTypeSystemDelivery sslid = dbcontext.TBTypeSystemDeliverys.FirstOrDefault(a => a.IdTypeSystemDelivery == IdTypeSystemDelivery);
            return sslid;
        }
        public bool saveData(TBTypeSystemDelivery savee)
        {
            try
            {
                dbcontext.Add<TBTypeSystemDelivery>(savee);
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateData(TBTypeSystemDelivery updatss)
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
        public bool deleteData(int IdTypeSystemDelivery)
        {
            try
            {
                var catr = GetById(IdTypeSystemDelivery);
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
        public List<TBTypeSystemDelivery> GetAllv(int IdTypeSystemDelivery)
        {
            List<TBTypeSystemDelivery> MySlider = dbcontext.TBTypeSystemDeliverys.OrderByDescending(n => n.IdTypeSystemDelivery == IdTypeSystemDelivery).Where(a => a.IdTypeSystemDelivery == IdTypeSystemDelivery).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
    }
}
