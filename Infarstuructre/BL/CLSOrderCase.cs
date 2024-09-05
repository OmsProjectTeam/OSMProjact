

using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infarstuructre.BL
{
	public interface IIOrderCase
	{
		List<OrderCase> GetAll();
		OrderCase GetById(int Id);
		bool saveData(OrderCase savee);
		bool UpdateData(OrderCase updatss);
		bool deleteData(int Id);
        /////////////////////////////////////////////////////API/////////////////////////////////////////////////////
        ///
        Task<List<OrderCase>> GetAllAsync(int pageNumber, int pageSize);
        Task<List<OrderCase>> GetAllvAsync(int Id);
        Task<OrderCase> GetByIdAsync(int Id);
        Task<bool> DeleteAsync(int Id);
        Task<bool> AddAsync(OrderCase savee);
        Task<bool> UpdateAsync(OrderCase updatss);
        Task<List<OrderCase>> GetAlWithConditionAsync(Expression<Func<OrderCase, bool>> condition);

    }
    public class CLSOrderCase: IIOrderCase
	{
		MasterDbcontext dbcontext;
		public CLSOrderCase(MasterDbcontext dbcontext1)
        {
			dbcontext = dbcontext1;

		}
		public List<OrderCase> GetAll()
		{
			List<OrderCase> MySlider = dbcontext.order_cases.OrderByDescending(n => n.Id).ToList();
			return MySlider;
		}
		public OrderCase GetById(int Id)
		{
			OrderCase sslid = dbcontext.order_cases.FirstOrDefault(a => a.Id == Id);
			return sslid;
		}
		public bool saveData(OrderCase savee)
		{
			try
			{
				dbcontext.Add<OrderCase>(savee);
				dbcontext.SaveChanges();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
		public bool UpdateData(OrderCase updatss)
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
		public bool deleteData(int Id)
		{
			try
			{
				//var catr = GetById(Id);
				//catr.CurrentState = false;
				////TbSubCateegoory dele = dbcontex.TbSubCateegoorys.Where(a => a.IdBrand == IdBrand).FirstOrDefault();
				////dbcontex.TbSubCateegoorys.Remove(dele);
				//dbcontext.Entry(catr).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
				//dbcontext.SaveChanges();
				return true;
			}
			catch (Exception)
			{
				return false;
			}

		}

        // //////////////////////////////////////////////////////API/////////////////////////////////////////////////////

        public async Task<List<OrderCase>> GetAllAsync(int pageNumber, int pageSize)
        {
            List<OrderCase> MySlIder = await dbcontext.order_cases.OrderByDescending(n => n.Id).Where(a => a.CurrentState == true).Skip((pageNumber - 1) * pageSize)
                .Take(pageSize).ToListAsync();
            return MySlIder;
        }

        public async Task<List<OrderCase>> GetAllvAsync(int Id)
        {
            List<OrderCase> MySlIder = await dbcontext.order_cases.OrderByDescending(n => n.Id == Id).Where(a => a.Id == Id).ToListAsync();
            return MySlIder;
        }

        public async Task<List<OrderCase>> GetAlWithConditionAsync(Expression<Func<OrderCase, bool>> condition)
        {
            List<OrderCase> merchants = await dbcontext.order_cases.Where(condition).ToListAsync();
            return merchants;
        }

        public async Task<OrderCase> GetByIdAsync(int Id)
        {
            OrderCase sslId = await dbcontext.order_cases.FirstOrDefaultAsync(a => a.Id == Id && a.CurrentState == true);
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

        public async Task<bool> AddAsync(OrderCase savee)
        {
            try
            {
                await dbcontext.AddAsync<OrderCase>(savee);
                await dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(OrderCase updatss)
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
