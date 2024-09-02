using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Infarstuructre.BL;

public interface IIShippingAddress
{
    List<TBViewShippingAddress> GetAll();
    TBShippingAddress GetById(int IdShippingAddress);
    bool saveData(TBShippingAddress save);
    bool UpdateData(TBShippingAddress updats);
    bool deleteData(int id);
    List<TBViewShippingAddress> GetAllv(int IdShippingAddress);
    List<TBViewShippingAddress> GetAllDataentry(string user);

    //////////////API///////////////////////////////////////////////
    ///
    Task<List<TBViewShippingAddress>> GetAllAsync(int pageNumber, int pageSize);
    Task<TBShippingAddress> GetByIdAsync(int IdShippingAddress);
    Task<bool> saveDataAsync(TBShippingAddress save);
    Task<bool> UpdateDataAsync(TBShippingAddress updats);
    Task<bool> deleteDataAsync(int IdShippingAddress);
    Task<List<TBViewShippingAddress>> GetAllvAsync(int IdShippingAddress);
    Task<List<TBViewShippingAddress>> GetAllDataentryAsync(string user);
    Task<List<TBViewShippingAddress>> GetAlWithConditionAsync(Expression<Func<TBViewShippingAddress, bool>> condition);
}
public class CLSShippingAddress : IIShippingAddress
{
    private readonly MasterDbcontext dbcontext;
    public CLSShippingAddress(MasterDbcontext dbcontext)
    {
        this.dbcontext = dbcontext;
    }
  



    public List<TBViewShippingAddress> GetAll()
    {
        List<TBViewShippingAddress> MySlider = dbcontext.ViewShippingAddress.OrderByDescending(n => n.IdShippingAddress).Where(a => a.CurrentState == true).ToList();
        return MySlider;
    }



    public List<TBViewShippingAddress> GetAllDataentry(string user)
    {
        List<TBViewShippingAddress> MySlider = dbcontext.ViewShippingAddress.Where(a => a.DateEntry == user && a.CurrentState == true).ToList();
        return MySlider;
    }



    public List<TBViewShippingAddress> GetAllv(int IdShippingAddress)
    {
        List<TBViewShippingAddress> MySlider = dbcontext.ViewShippingAddress.OrderByDescending(n => n.IdShippingAddress).Where(a => a.IdShippingAddress == IdShippingAddress).Where(a => a.CurrentState == true).ToList();
        return MySlider;
    }



    public TBShippingAddress GetById(int IdShippingAddress)
    {
        TBShippingAddress sslid = dbcontext.TBShippingAddresses.FirstOrDefault(p => p.IdShippingAddress == IdShippingAddress);
        return sslid;
    }



    public bool saveData(TBShippingAddress save)
    {
        try
        {
            dbcontext.Add<TBShippingAddress>(save);
            dbcontext.SaveChanges();

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }



    public bool UpdateData(TBShippingAddress updats)
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

    public bool deleteData(int id)
    {
        try
        {
            var ctr = GetById(id);
            ctr.CurrentState = false;
            dbcontext.Entry(ctr).State = EntityState.Modified;
            dbcontext.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }


    ////////////////////////////////////////////////////////////////////API/////////////////////////////////////////////////////////////////////////
    ///
    public async Task<bool> UpdateDataAsync(TBShippingAddress updats)
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

    public async Task<List<TBViewShippingAddress>> GetAlWithConditionAsync(Expression<Func<TBViewShippingAddress, bool>> condition)
    {
        List<TBViewShippingAddress> data = await dbcontext.ViewShippingAddress.Where(condition).ToListAsync();
        return data;
    }

    public async Task<bool> saveDataAsync(TBShippingAddress save)
    {
        try
        {
            await dbcontext.AddAsync<TBShippingAddress>(save);
            await dbcontext.SaveChangesAsync();

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<TBShippingAddress> GetByIdAsync(int IdShippingAddress)
    {
        TBShippingAddress sslid = await dbcontext.TBShippingAddresses.FirstOrDefaultAsync(p => p.IdShippingAddress == IdShippingAddress);
        return sslid;
    }

    public async Task<List<TBViewShippingAddress>> GetAllvAsync(int IdShippingAddress)
    {
        List<TBViewShippingAddress> MySlider = await dbcontext.ViewShippingAddress.OrderByDescending(n => n.IdShippingAddress).Where(a => a.IdShippingAddress == IdShippingAddress).Where(a => a.CurrentState == true).ToListAsync();
        return MySlider;
    }

    public async Task<List<TBViewShippingAddress>> GetAllDataentryAsync(string user)
    {
        List<TBViewShippingAddress> MySlider = await dbcontext.ViewShippingAddress.Where(a => a.DateEntry == user && a.CurrentState == true).ToListAsync();
        return MySlider;
    }

    public async Task<List<TBViewShippingAddress>> GetAllAsync(int pageNumber, int pageSize)
    {
        List<TBViewShippingAddress> MySlider = await dbcontext.ViewShippingAddress.OrderByDescending(n => n.IdShippingAddress).Where(a => a.CurrentState == true).Skip((pageNumber - 1) * pageSize)
                .Take(pageSize).ToListAsync();
        return MySlider;
    }

    public async Task<bool> deleteDataAsync(int IdShippingAddress)
    {
        try
        {
            var profit = await GetByIdAsync(IdShippingAddress);
            profit.CurrentState = false;
            dbcontext.Entry(profit).State = EntityState.Modified;
            await dbcontext.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }


}
