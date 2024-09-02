using Domin.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Infarstuructre.BL;
public interface IITransfer
{
    List<TBViewTransfer> GetAll();
    TBTransfer GetById(int IdProfit);
    bool saveData(TBTransfer save);
    bool UpdateData(TBTransfer updats);
    bool deleteData(int IdProfit);
    List<TBViewTransfer> GetAllv(int IdProfit);
    public List<TBViewTransfer> GetAllDataentry(string user);

    //////////////////// API /////////////////////////////////////
    ///
    Task<IEnumerable<TBViewTransfer>> GetAllProfitsAsync(int pageNumber, int pageSize);
    Task<TBTransfer> GetProfitByIdAsync(int Id);
    Task<IEnumerable<TBViewTransfer>> GetAllProfitsWithConditionAsync(Expression<Func<TBViewTransfer, bool>> condition);
    Task<bool> AddProfitsAsync(TBTransfer save);
    Task<bool> UpdateProfitAsync(TBTransfer update);
    Task<bool> DELETPHOTOWethErrorAsync(string PhotoNAme);
    Task<bool> DELETPHOTOAsync(int IdProfit);
}

public class CLSTransfer : IITransfer
{
    private readonly MasterDbcontext dbcontext;
    public CLSTransfer(MasterDbcontext dbcontext)
    {
        this.dbcontext = dbcontext;
    }

    public List<TBViewTransfer> GetAll()
    {
        List<TBViewTransfer> MySlider = dbcontext.ViewProfits.OrderByDescending(n => n.IdTransfer).Where(a => a.CurrentState == true).ToList();
        return MySlider;
    }

    public TBTransfer GetById(int IdProfit)
    {
        TBTransfer sslid = dbcontext.TBTransfers.FirstOrDefault(p => p.IdTransfer == IdProfit);
        return sslid;
    }


    public bool deleteData(int IdProfit)
    {
        try
        {
            var profit = GetById(IdProfit);
            profit.CurrentState = false;
            dbcontext.Entry(profit).State = EntityState.Modified;
            dbcontext.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public bool DELETPHOTO(int IdProfit)
    {
        try
        {
            var catr = GetById(IdProfit);
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

    public List<TBViewTransfer> GetAllDataentry(string user)
    {
        List<TBViewTransfer> MySlider = dbcontext.ViewProfits.Where(a => a.DataEntry == user && a.CurrentState == true).ToList();
        return MySlider;
    }

    public List<TBViewTransfer> GetAllv(int IdProfit)
    {
        List<TBViewTransfer> MySlider = dbcontext.ViewProfits.OrderByDescending(n => n.IdTransfer).Where(a => a.IdTransfer == IdProfit).Where(a => a.CurrentState == true).ToList();
        return MySlider;
    }

    public bool saveData(TBTransfer save)
    {
        try
        {
            dbcontext.Add<TBTransfer>(save);
            dbcontext.SaveChanges();

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public bool UpdateData(TBTransfer updats)
    {
        try
        {
            dbcontext.Entry(updats).State = EntityState.Modified;
            dbcontext.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    //  /////////////////Api//////////////////////////////////////////////////////////////////////

    public async Task<IEnumerable<TBViewTransfer>> GetAllProfitsAsync(int pageNumber, int pageSize)
    {
        List<TBViewTransfer> MySlider = await dbcontext.ViewProfits.OrderByDescending(n => n.IdTransfer).Where(a => a.CurrentState == true).Skip((pageNumber - 1) * pageSize)
                .Take(pageSize).ToListAsync();
        return MySlider;
    }

    public async Task<IEnumerable<TBViewTransfer>> GetAllProfitsWithConditionAsync(Expression<Func<TBViewTransfer, bool>> condition)
    {
        List<TBViewTransfer> data = await dbcontext.ViewProfits.Where(condition).ToListAsync();
        return data;
    }
    public async Task<TBTransfer> GetProfitByIdAsync(int Id)
    {
        TBTransfer sslid = await dbcontext.TBTransfers.FirstOrDefaultAsync(p => p.IdTransfer == Id);
        return sslid;
    }

    public async Task<bool> AddProfitsAsync(TBTransfer save)
    {
        try
        {
            await dbcontext.AddAsync<TBTransfer>(save);
            await dbcontext.SaveChangesAsync();

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<bool> UpdateProfitAsync(TBTransfer updats)
    {
        try
        {
            dbcontext.Entry(updats).State = EntityState.Modified;
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
