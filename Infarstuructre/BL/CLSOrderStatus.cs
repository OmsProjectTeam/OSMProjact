

using Microsoft.EntityFrameworkCore;

namespace Infarstuructre.BL
{
    public interface IIOrderStatus
    {
        List<TBViewOrderStatus> GetAll();
        OrderStatus GetById(int id);
        bool saveData(OrderStatus savee);
        bool UpdateData(OrderStatus updatss);
        bool deleteData(int id);
        List<TBViewOrderStatus> GetAllv(int id);
    }
    public class CLSOrderStatus: IIOrderStatus
    {
        MasterDbcontext dbcontext;
        public CLSOrderStatus(MasterDbcontext dbcontex1)
        {
            dbcontext = dbcontex1;
        }
        public List<TBViewOrderStatus> GetAll()
        {
            List<TBViewOrderStatus> MySlider = dbcontext.ViewOrderStatus.OrderByDescending(n => n.id).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }

        public OrderStatus GetById(int id)
        {
            OrderStatus sslid = dbcontext.order_status.FirstOrDefault(a => a.Id == id);
            return sslid;
        }
        public bool saveData(OrderStatus savee)
        {
            try
            {
                dbcontext.Add<OrderStatus>(savee);
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateData(OrderStatus updatss)
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
        public List<TBViewOrderStatus> GetAllv(int id)
        {
            List<TBViewOrderStatus> MySlider = dbcontext.ViewOrderStatus.OrderByDescending(n => n.id == id).Where(a => a.id == id).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
    }
}
