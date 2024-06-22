using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
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

        // Methods for APIs
        Task<IEnumerable<TBViewMerchant>> GetAllMerchantsAsync(int pageNumber, int pageSize);
        Task<IEnumerable<TBViewMerchant>> GetAllMerchantsWithConditionAsync(Expression<Func<TBViewMerchant, bool>> condition);
        Task<Merchant> GetMerchantAsync(int id);
        Task AddMerchantAsync(Merchant merchant);
        Task UpdateMerchantAsync(Merchant merchant);
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



        // Methods for APIs
        public async Task<IEnumerable<TBViewMerchant>>? GetAllMerchantsAsync(int pageNumber, int pageSize)
        {
            IEnumerable<TBViewMerchant> merchants = await dbcontext.ViewMerchant.OrderByDescending(n => n.id)
                .Where(a => a.CurrentState == true)
				.Skip((pageNumber - 1) * pageSize)
				.Take(pageSize)
				.ToListAsync();
            return merchants;
        }

        public async Task<IEnumerable<TBViewMerchant>> GetAllMerchantsWithConditionAsync(Expression<Func<TBViewMerchant, bool>> condition)
        {
            IEnumerable<TBViewMerchant> merchants = await dbcontext.ViewMerchant.Where(condition).ToListAsync();
            return merchants;
        }

        public async Task<Merchant>? GetMerchantAsync(int id)
        {
            Merchant merchant = await dbcontext.Merchants.FindAsync(id);
            return merchant;
        }

        public async Task AddMerchantAsync(Merchant merchant)
        {
            await dbcontext.AddAsync(merchant);
            await dbcontext.SaveChangesAsync();
        }

        public async Task UpdateMerchantAsync(Merchant merchant)
        {
            dbcontext.Entry(merchant).State = EntityState.Modified;
            await dbcontext.SaveChangesAsync();
        }
    }
}
