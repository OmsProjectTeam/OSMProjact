
namespace Infarstuructre.BL
{
    public interface IITransaction
    {
        List<TBViewTransaction> GetAll();
        TBTransaction GetById(int IdTransaction);
        bool saveData(TBTransaction savee);
        bool UpdateData(TBTransaction updatss);
        bool deleteData(int IdTransaction);
        List<TBViewTransaction> GetAllv(int IdTransaction);
    }

    public class CLSTBTransaction: IITransaction
    {
        MasterDbcontext dbcontext;
        public CLSTBTransaction(MasterDbcontext dbcontext1)
        {
            dbcontext=dbcontext1;
        }
        public List<TBViewTransaction> GetAll()
        {
            List<TBViewTransaction> MySlider = dbcontext.ViewTransaction.OrderByDescending(n => n.IdTransaction).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
        public TBTransaction GetById(int IdTransaction)
        {
            TBTransaction sslid = dbcontext.TBTransactions.FirstOrDefault(a => a.IdTransaction == IdTransaction);
            return sslid;
        }
        public bool saveData(TBTransaction savee)
        {
            try
            {
                dbcontext.Add<TBTransaction>(savee);
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateData(TBTransaction updatss)
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
        public bool deleteData(int IdTransaction)
        {
            try
            {
                var catr = GetById(IdTransaction);
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
        public List<TBViewTransaction> GetAllv(int IdTransaction)
        {
            List<TBViewTransaction> MySlider = dbcontext.ViewTransaction.OrderByDescending(n => n.IdTransaction == IdTransaction).Where(a => a.IdTransaction == IdTransaction).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
    }
}
