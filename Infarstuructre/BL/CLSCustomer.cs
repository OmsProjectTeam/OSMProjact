
namespace Infarstuructre.BL
{
    public interface IICustomer
    {
        List<TBViewCustomers> GetAll();
        Customer GetById(int id);
        bool saveData(Customer savee);
        bool UpdateData(Customer updatss);
        bool deleteData(int id);
        List<TBViewCustomers> GetAllv(int id);
    }
    public class CLSCustomer: IICustomer
    {
        MasterDbcontext dbcontext;
        public CLSCustomer(MasterDbcontext dbcontext1)
        {
            dbcontext=dbcontext1;
        }
        public List<TBViewCustomers> GetAll()
        {
            List<TBViewCustomers> MySlider = dbcontext.ViewCustomers.OrderByDescending(n => n.id).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
        public Customer GetById(int id)
        {
            Customer sslid = dbcontext.customers.FirstOrDefault(a => a.Id == id);
            return sslid;
        }
        public bool saveData(Customer savee)
        {
            try
            {
                dbcontext.Add<Customer>(savee);
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateData(Customer updatss)
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
        public List<TBViewCustomers> GetAllv(int id)
        {
            List<TBViewCustomers> MySlider = dbcontext.ViewCustomers.OrderByDescending(n => n.id == id).Where(a => a.id == id).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }

    }
}
