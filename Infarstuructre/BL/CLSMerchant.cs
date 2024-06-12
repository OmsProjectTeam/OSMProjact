
namespace Infarstuructre.BL
{
    public  interface IIMerchant
    {
        List<TBViewMerchant> GetAll();
        Merchant GetById(int id);
        bool saveData(Merchant savee);
        bool UpdateData(Merchant updatss);
        bool deleteData(int id);
        List<TBViewMerchant> GetAllv(int id);
    }
    public class CLSMerchant: IIMerchant
    {
        MasterDbcontext dbcontext;
        public CLSMerchant(MasterDbcontext dbcontext1)
        {
            dbcontext=dbcontext1;
        }
        public List<TBViewMerchant> GetAll()
        {
            List<TBViewMerchant> MySlider = dbcontext.ViewMerchant.OrderByDescending(n => n.id).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
     
        public Merchant GetById(int id)
        {
            Merchant sslid = dbcontext.Merchants.FirstOrDefault(a => a.Id == id);
            return sslid;
        }
        public bool saveData(Merchant savee)
        {
            try
            {
                dbcontext.Add<Merchant>(savee);
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateData(Merchant updatss)
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
        public bool deleteData(int id)
        {
            try
            {
                var catr = GetById(id);
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
        public List<TBViewMerchant> GetAllv(int id)
        {
            List<TBViewMerchant> MySlider = dbcontext.ViewMerchant.OrderByDescending(n => n.id == id).Where(a => a.id == id).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }

    }
}
