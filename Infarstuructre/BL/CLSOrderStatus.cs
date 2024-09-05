

using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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
        ///////////////////APIs////////////////////////////////
        ///
        Task<List<TBViewOrderStatus>> GetAllAsync(int pageNumber, int pageSize);
        Task<List<TBViewOrderStatus>> GetAlWithConditionAsync(Expression<Func<TBViewOrderStatus, bool>> condition);
        Task<List<TBViewOrderStatus>> GetAllvAsync(int Id);
        Task<OrderStatus> GetByIdAsync(int Id);
        Task<bool> DeleteAsync(int Id);
        Task<bool> AddAsync(OrderStatus savee);
        Task<bool> UpdateAsync(OrderStatus updatss);
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

        // //////////////////////////////////////////////////////API/////////////////////////////////////////////////////

        public async Task<List<TBViewOrderStatus>> GetAllAsync(int pageNumber, int pageSize)
        {
            List<TBViewOrderStatus> MySlIder = await dbcontext.ViewOrderStatus.OrderByDescending(n => n.id).Where(a => a.CurrentState == true).Skip((pageNumber - 1) * pageSize)
                .Take(pageSize).ToListAsync();
            return MySlIder;
        }

        public async Task<List<TBViewOrderStatus>> GetAlWithConditionAsync(Expression<Func<TBViewOrderStatus, bool>> condition)
        {
            List<TBViewOrderStatus> data = await dbcontext.ViewOrderStatus.Where(condition).ToListAsync();
            return data;
        }

        public async Task<List<TBViewOrderStatus>> GetAllvAsync(int Id)
        {
            List<TBViewOrderStatus> MySlIder = await dbcontext.ViewOrderStatus.OrderByDescending(n => n.id == Id).Where(a => a.id == Id).ToListAsync();
            return MySlIder;
        }

        public async Task<OrderStatus> GetByIdAsync(int Id)
        {
            OrderStatus sslId = await dbcontext.order_status.FirstOrDefaultAsync(a => a.Id == Id && a.CurrentState == true);
            return sslId;
        }

        public async Task<bool> DeleteAsync(int Id)
        {
            try
            {
                var catr = await GetByIdAsync(Id);
                catr.CurrentState = false;
                //TbSubCateegoory dele = dbcontex.TbSubCateegoorys.Where(a => a.IdBrand == IdBrand).FirstOrDefault();
                //dbcontex.TbSubCateegoorys.Remove(dele);
                dbcontext.Entry(catr).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> AddAsync(OrderStatus savee)
        {
            try
            {
                await dbcontext.AddAsync<OrderStatus>(savee);
                await dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(OrderStatus updatss)
        {
            try
            {
                dbcontext.Entry(updatss).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
