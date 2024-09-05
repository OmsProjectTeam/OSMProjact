
using Domin.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infarstuructre.BL
{
    public interface IIInformationCompanies
    {
        List<TBViewInformationCompanies> GetAll();
        TBInformationCompanies GetById(int IdInformationCompanies);
        bool saveData(TBInformationCompanies savee);
        bool UpdateData(TBInformationCompanies updatss);
        bool deleteData(int IdInformationCompanies);
        List<TBInformationCompanies> GetAllv(int IdInformationCompanies);
        bool DELETPHOTO(int IdInformationCompanies);
        bool DELETPHOTOWethError(string PhotoNAme);

        /////////////////////////////API////////////////////////////////////
        ///
        Task<List<TBViewInformationCompanies>> GetAllAsync(int pageNumber, int pageSize);
        Task<List<TBViewInformationCompanies>> GetAllvAsync(int Id);
        Task<TBInformationCompanies> GetByIdAsync(int Id);
        Task<bool> DeleteAsync(int Id);
        Task<bool> AddAsync(TBInformationCompanies savee);
        Task<bool> UpdateAsync(TBInformationCompanies updatss);
        Task<bool> DELETPHOTOAsync(int IdInformationCompanies);
        Task<bool> DELETPHOTOWethErrorAsync(string PhotoNAme);


    }
    public class CLSTBInformationCompanies: IIInformationCompanies
    {
        MasterDbcontext dbcontext;
        public CLSTBInformationCompanies(MasterDbcontext dbcontext1)
        {
            dbcontext= dbcontext1;
        }

        public List<TBViewInformationCompanies> GetAll()
        {
            List<TBViewInformationCompanies> MySlider = dbcontext.ViewInformationCompanies.OrderByDescending(n => n.IdInformationCompanies).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
        public TBInformationCompanies GetById(int IdInformationCompanies)
        {
            TBInformationCompanies sslid = dbcontext.TBInformationCompaniess.FirstOrDefault(a => a.IdInformationCompanies == IdInformationCompanies);
            return sslid;
        }
        public bool saveData(TBInformationCompanies savee)
        {
            try
            {
                dbcontext.Add<TBInformationCompanies>(savee);
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateData(TBInformationCompanies updatss)
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
        public bool deleteData(int IdInformationCompanies)
        {
            try
            {
                var catr = GetById(IdInformationCompanies);
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
        public List<TBInformationCompanies> GetAllv(int IdInformationCompanies)
        {
            List<TBInformationCompanies> MySlider = dbcontext.TBInformationCompaniess.OrderByDescending(n => n.IdInformationCompanies == IdInformationCompanies).Where(a => a.IdInformationCompanies == IdInformationCompanies).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
        public bool DELETPHOTO(int IdInformationCompanies)
        {
            try
            {
                var catr = GetById(IdInformationCompanies);
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

        // //////////////////////////////////////////////////////API/////////////////////////////////////////////////////

        public async Task<List<TBViewInformationCompanies>> GetAllAsync(int pageNumber, int pageSize)
        {
            List<TBViewInformationCompanies> MySlIder = await dbcontext.ViewInformationCompanies.OrderByDescending(n => n.IdInformationCompanies).Where(a => a.CurrentState == true)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize).ToListAsync();
            return MySlIder;
        }

        public async Task<List<TBViewInformationCompanies>> GetAllvAsync(int Id)
        {
            List<TBViewInformationCompanies> MySlIder = await dbcontext.ViewInformationCompanies.OrderByDescending(n => n.IdInformationCompanies == Id).Where(a => a.IdInformationCompanies == Id).ToListAsync();
            return MySlIder;
        }

        public async Task<TBInformationCompanies> GetByIdAsync(int Id)
        {
            TBInformationCompanies sslId = await dbcontext.TBInformationCompaniess.FirstOrDefaultAsync(a => a.IdInformationCompanies == Id && a.CurrentState == true);
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

        public async Task<bool> AddAsync(TBInformationCompanies savee)
        {
            try
            {
                await dbcontext.AddAsync<TBInformationCompanies>(savee);
                await dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(TBInformationCompanies updatss)
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

        public Task<bool> DELETPHOTOAsync(int IdInformationCompanies)
        {
            var result = DELETPHOTO(IdInformationCompanies);
            return Task.FromResult(result);
        }

        public Task<bool> DELETPHOTOWethErrorAsync(string PhotoNAme)
        {
            var result = DELETPHOTOWethError(PhotoNAme);
            return Task.FromResult(result);
        }
    }
}
