

using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Infarstuructre.BL
{
    public interface IIOrderNew
    {
        List<TBViewOrderNew> GetAll();
        TBOrderNew GetById(int IdOrderNew);
        bool saveData(TBOrderNew savee);
        bool UpdateData(TBOrderNew updatss);
        bool deleteData(int IdOrderNew);
        List<TBViewOrderNew> GetAllv(int IdOrderNew);

        //////////////////// API /////////////////////////////////////
        Task<IEnumerable<TBViewOrderNew>> GetAllOrdersNewAsync(int pageNumber, int pageSize);
		Task<TBOrderNew> GetOrderNewByIdAsync(int Id);
        Task<IEnumerable<TBViewOrderNew>> GetAllOrdersNewWithConditionAsync(Expression<Func<TBViewOrderNew, bool>> condition);
        Task AddOrderNewAsync(TBOrderNew orderNew);
        Task UpdateOrderNewAsync(TBOrderNew orderNew);
    }
    public class CLSTBOrderNew: IIOrderNew
    {
        MasterDbcontext dbcontext;
        public CLSTBOrderNew(MasterDbcontext dbcontext1)
        {
            dbcontext = dbcontext1;
        }
        public List<TBViewOrderNew> GetAll()
        {
            List<TBViewOrderNew> MySlider = dbcontext.ViewOrderNew.OrderByDescending(n => n.IdOrderNew).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
        public TBOrderNew GetById(int IdOrderNew)
        {
            TBOrderNew sslid = dbcontext.TBOrderNews.FirstOrDefault(a => a.IdOrderNew == IdOrderNew);
            return sslid;
        }
        public bool saveData(TBOrderNew savee)
        {
            try
            {
                dbcontext.Add<TBOrderNew>(savee);
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateData(TBOrderNew updatss)
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
        public bool deleteData(int IdOrderNew)
        {
            try
            {
                var catr = GetById(IdOrderNew);
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
        public List<TBViewOrderNew> GetAllv(int IdOrderNew)
        {
            List<TBViewOrderNew> MySlider = dbcontext.ViewOrderNew.OrderByDescending(n => n.IdOrderNew == IdOrderNew).Where(a => a.IdOrderNew == IdOrderNew).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }

        // /////////////////// APIs /////////////////////////////////////////
		public async Task<IEnumerable<TBViewOrderNew>> GetAllOrdersNewAsync(int pageNumber, int pageSize)
		{
			IEnumerable<TBViewOrderNew> ordersNew = await dbcontext.ViewOrderNew.OrderByDescending(n => n.IdOrderNew)
                .Where(a => a.CurrentState == true)
				.Skip((pageNumber - 1) * pageSize)
				.Take(pageSize)
				.ToListAsync();
			return ordersNew;
		}

		public async Task<TBOrderNew> GetOrderNewByIdAsync(int Id)
		{
            var orderNew = await dbcontext.TBOrderNews.FindAsync(Id);
            return orderNew;
		}

		public async Task<IEnumerable<TBViewOrderNew>> GetAllOrdersNewWithConditionAsync(Expression<Func<TBViewOrderNew, bool>> condition)
		{
			IEnumerable<TBViewOrderNew> ordersNew = await dbcontext.ViewOrderNew.OrderByDescending(n => n.IdOrderNew).Where(condition).ToListAsync();
			return ordersNew;
		}

		public async Task AddOrderNewAsync(TBOrderNew orderNew)
		{
			await dbcontext.AddAsync(orderNew);
			await dbcontext.SaveChangesAsync();
		}

		public async Task UpdateOrderNewAsync(TBOrderNew orderNew)
		{
		    dbcontext.Entry(orderNew).State = EntityState.Modified;
			await dbcontext.SaveChangesAsync();
		}
	}
}
