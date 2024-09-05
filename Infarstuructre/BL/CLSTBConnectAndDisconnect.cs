using Domin.Entity.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Infarstuructre.BL
{
	public interface IIConnectAndDisconnect
	{
		List<TBConnectAndDisConnect> GetAll();

        bool addConnection(TBConnectAndDisConnect save);
		bool RemoveConnection(string ConnectId);
		TBConnectAndDisConnect GetById(string ConnectId);
        TBConnectAndDisConnect GetByName(string name);

        ///////////////////////API/////////////////////////////////
        ///
        Task<List<TBConnectAndDisConnect>> GetAllAsync(int pageNumber, int pageSize);
        Task<TBConnectAndDisConnect> GetByIdAsync(string Id);
        Task<TBConnectAndDisConnect> GetByNameAsync(string name);
        Task<bool> DeleteAsync(string ConnectId);
        Task<bool> AddAsync(TBConnectAndDisConnect savee);


    }
	public class CLSTBConnectAndDisconnect : IIConnectAndDisconnect
	{
		MasterDbcontext dbcontext;
		public CLSTBConnectAndDisconnect(MasterDbcontext dbcontext1) 
		{
			dbcontext = dbcontext1;
		}

		public List<TBConnectAndDisConnect> GetAll()
		{
			List<TBConnectAndDisConnect> MySlider = dbcontext.TBConnectAndDisConnects.ToList();
			return MySlider;

		}

         public TBConnectAndDisConnect GetById(string ConnectId)
		{
			TBConnectAndDisConnect sslid = dbcontext.TBConnectAndDisConnects.FirstOrDefault(a => a.ConnectId == ConnectId);
			return sslid;
		}

		public TBConnectAndDisConnect GetByName(string name)
		{
            TBConnectAndDisConnect sslid = dbcontext.TBConnectAndDisConnects.OrderBy(a => a.TimeConnection).Where(a => a.UserName == name).LastOrDefault();
            return sslid;
		}

		public bool addConnection(TBConnectAndDisConnect save)
		{
			try
			{
				dbcontext.Add<TBConnectAndDisConnect>(save);
				dbcontext.SaveChanges();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool RemoveConnection(string ConnectId)
		{
			try
			{
				var catr = GetById(ConnectId);
				dbcontext.Remove<TBConnectAndDisConnect>(catr);
				dbcontext.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

        // //////////////////////////////////////////////////////API/////////////////////////////////////////////////////

        public async Task<List<TBConnectAndDisConnect>> GetAllAsync(int pageNumber, int pageSize)
        {
            List<TBConnectAndDisConnect> MySlIder = await dbcontext.TBConnectAndDisConnects.OrderByDescending(n => n.IdConnectAndDisConnect).Skip((pageNumber - 1) * pageSize)
                .Take(pageSize).ToListAsync();
            return MySlIder;
        }

        public async Task<TBConnectAndDisConnect> GetByIdAsync(string Id)
        {
            TBConnectAndDisConnect sslId = await dbcontext.TBConnectAndDisConnects.FirstOrDefaultAsync(a => a.ConnectId == Id);
            return sslId;
        }

        public async Task<TBConnectAndDisConnect> GetByNameAsync(string name)
        {
            TBConnectAndDisConnect sslid = await dbcontext.TBConnectAndDisConnects.OrderBy(a => a.TimeConnection).Where(a => a.UserName == name).LastOrDefaultAsync();
            return sslid;
        }

        public async Task<bool> DeleteAsync(string ConnectId)
        {
            try
            {
                var catr = GetById(ConnectId);
                dbcontext.Remove<TBConnectAndDisConnect>(catr);
                await dbcontext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> AddAsync(TBConnectAndDisConnect savee)
        {
            try
            {
                await dbcontext.AddAsync<TBConnectAndDisConnect>(savee);
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
