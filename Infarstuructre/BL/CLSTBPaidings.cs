

using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Infarstuructre.BL
{
    public interface IIPaidings
    {
        List<TBViewPaings> GetAll();
        TBPaing GetById(int IdPaidings);
        bool saveData(TBPaing savee);
        bool UpdateData(TBPaing updatss);
        bool deleteData(int IdOrderNew);
        List<TBViewPaings> GetAllv(int IdPaidings);
        public List<TBViewPaings> GetAllDataentry(string IdPaidings);

        //////////////////// API /////////////////////////////////////
        ///
        Task<IEnumerable<TBViewPaings>> GetAllPaidingsAsync(int pageNumber, int pageSize);
        Task<TBPaing> GetPaidingByIdAsync(int Id);
        Task<IEnumerable<TBViewPaings>> GetAllPaidingsWithConditionAsync(Expression<Func<TBViewPaings, bool>> condition);
        Task AddPaidingsAsync(TBPaing IdPaidings);
        Task UpdatePaidingAsync(TBPaing IdPaidings);
        bool DELETPHOTOWethError(string PhotoNAme);
        bool DELETPHOTO(int IdPaidings);
    }

    public class CLSTBPaidings : IIPaidings
    {
        MasterDbcontext dbcontext;
        public CLSTBPaidings(MasterDbcontext dbcontext1)
        {
            dbcontext = dbcontext1;
        }
        public List<TBViewPaings> GetAll()
        {
            List<TBViewPaings> MySlider = dbcontext.ViewPaings.OrderByDescending(n => n.IdPaings).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
        public TBPaing GetById(int IdPaidings)
        {
            TBPaing sslid = dbcontext.TBPaings.FirstOrDefault(a => a.IdPaings == IdPaidings);
            return sslid;
        }
       

        public bool saveData(TBPaing savee)
        {
            try
            {
                dbcontext.Add<TBPaing>(savee);
                dbcontext.SaveChanges();
                TBOrderNew sslid = dbcontext.TBOrderNews.FirstOrDefault(a => a.IdOrderNew == savee.IdOrderNew);



                sslid.IsPaid = true;
                sslid.IdorderStatus = 2037;
                dbcontext.Entry(sslid).State = EntityState.Modified;
                dbcontext.SaveChanges();
               

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateData(TBPaing update)
        {
            try
            {
                dbcontext.Entry(update).State = EntityState.Modified;
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool deleteData(int IdPaidings)
        {
            try
            {
                var paid = GetById(IdPaidings);
                paid.CurrentState = false;
                dbcontext.Entry(paid).State = EntityState.Modified;
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public List<TBViewPaings> GetAllv(int IdPaidings)
        {
            List<TBViewPaings> MySlider = dbcontext.ViewPaings.OrderByDescending(n => n.IdPaings).Where(a => a.IdPaings == IdPaidings).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }

        public List<TBViewPaings> GetAllDataentry(string dataEntry)
        {
            List<TBViewPaings> MySlider = dbcontext.ViewPaings.Where(a => a.DataEntry == dataEntry && a.CurrentState == true).ToList();
            return MySlider;
        }


        ////////////////////////////////////////////////////////////////

        public bool DELETPHOTO(int IdPaings)
        {
            try
            {
                var catr = GetById(IdPaings);
                //using (FileStream fs = new FileStream(catr.Photo, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                //{
                if (!string.IsNullOrEmpty(catr.Photo))
                {
                    // إذا كان هناك صورة قديمة، قم بمسحها من الملف
                    var oldFilePath = Path.Combine(@"wwwroot/Images/Home", catr.Photo);
                    if (System.IO.File.Exists(oldFilePath))
                    {


                        // استخدم FileShare.None للسماح بحذف الملف أثناء استخدامه
                        using (FileStream fs = new FileStream(oldFilePath, FileMode.Open, FileAccess.Read, FileShare.None))
                        {
                            System.Threading.Thread.Sleep(200);
                            GC.Collect();
                            GC.WaitForPendingFinalizers();
                        }

                        System.IO.File.Delete(oldFilePath);
                    }
                }
                //}


                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public bool DELETPHOTOWethError(string PhotoNAme)
        {
            try
            {
                if (!string.IsNullOrEmpty(PhotoNAme))
                {
                    // إذا كان هناك صورة قديمة، قم بمسحها من الملف
                    var oldFilePath = Path.Combine(@"wwwroot/Images/Home", PhotoNAme);
                    if (System.IO.File.Exists(oldFilePath))
                    {


                        // استخدم FileShare.None للسماح بحذف الملف أثناء استخدامه
                        using (FileStream fs = new FileStream(oldFilePath, FileMode.Open, FileAccess.Read, FileShare.None))
                        {
                            System.Threading.Thread.Sleep(200);
                            GC.Collect();
                            GC.WaitForPendingFinalizers();
                        }

                        System.IO.File.Delete(oldFilePath);
                    }
                }

                return true;
            }
            catch (Exception)
            {
                // يفضل ألا تترك البرنامج يتجاوز الأخطاء بصمت، يفضل تسجيل الخطأ أو إعادة رميه
                return false;
            }
        }


        ///////////////// APIs /////////////////////////////////////////
        public async Task<IEnumerable<TBViewPaings>> GetAllPaidingsAsync(int pageNumber, int pageSize)
        {
            IEnumerable<TBViewPaings> paids = await dbcontext.ViewPaings.OrderByDescending(n => n.IdOrderNew)
                .Where(a => a.CurrentState == true)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return paids;
        }

        public async Task<TBPaing> GetPaidingByIdAsync(int Id)
        {
            var paid = await dbcontext.TBPaings.FindAsync(Id);
            return paid;
        }

        public async Task<IEnumerable<TBViewPaings>> GetAllPaidingsWithConditionAsync(Expression<Func<TBViewPaings, bool>> condition)
        {
            IEnumerable<TBViewPaings> paids = await dbcontext.ViewPaings.OrderByDescending(n => n.IdPaings).Where(condition).ToListAsync();
            return paids;
        }

        public async Task AddPaidingsAsync(TBPaing Id)
        {
            await dbcontext.AddAsync(Id);
            await dbcontext.SaveChangesAsync();
        }

        public async Task UpdatePaidingAsync(TBPaing paid)
        {
            dbcontext.Entry(paid).State = EntityState.Modified;
            await dbcontext.SaveChangesAsync();
        }
    }
}
