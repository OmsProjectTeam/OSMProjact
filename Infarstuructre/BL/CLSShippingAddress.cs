using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infarstuructre.BL;

public interface IIShippingAddress
{
    List<TBViewShippingAddress> GetAll();
    TBShippingAddress GetById(int IdShipping);
    bool saveData(TBShippingAddress save);
    bool UpdateData(TBShippingAddress updats);
    bool deleteData(int IdShipping);
    List<TBViewShippingAddress> GetAllv(int IdShipping);
    public List<TBViewShippingAddress> GetAllDataentry(string user);
}
public class CLSShippingAddress : IIShippingAddress
{
    private readonly MasterDbcontext dbcontext;
    public CLSShippingAddress(MasterDbcontext dbcontext)
    {
        this.dbcontext = dbcontext;
    }
    public bool deleteData(int IdShipping)
    {
        try
        {
            var profit = GetById(IdShipping);
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

    public List<TBViewShippingAddress> GetAllv(int IdShipping)
    {
        List<TBViewShippingAddress> MySlider = dbcontext.ViewShippingAddress.OrderByDescending(n => n.IdShippingAddress).Where(a => a.IdShippingAddress == IdShipping).Where(a => a.CurrentState == true).ToList();
        return MySlider;
    }

    public TBShippingAddress GetById(int IdShipping)
    {
        TBShippingAddress sslid = dbcontext.TBShippingAddresses.FirstOrDefault(p => p.IdShippingAddress == IdShipping);
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
}
