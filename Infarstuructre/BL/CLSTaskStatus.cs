

using Microsoft.EntityFrameworkCore;

namespace Infarstuructre.BL
{
    public interface IITaskStatus
    {
        List<TaskStatus> GetAll();
        TaskStatus GetById(int Id);
        bool saveData(TaskStatus savee);
        bool UpdateData(TaskStatus updatss);
        bool deleteData(int Id);
        List<TaskStatus> GetAllv(int Id);
        ////////////////////////////API///////////////////////////////////////
        ///
        Task<List<TaskStatus>> GetAllAsync(int pageNumber, int pageSize);
        Task<List<TaskStatus>> GetAllvAsync(int Id);
        Task<TaskStatus> GetByIdAsync(int Id);
        Task<bool> DeleteAsync(int Id);
        Task<bool> AddAsync(TaskStatus savee);
        Task<bool> UpdateAsync(TaskStatus updatss);

    }
    public class CLSTaskStatus:IITaskStatus
    {
        MasterDbcontext dbcontext;
        public CLSTaskStatus(MasterDbcontext dbcontext1 )
        {
            dbcontext=dbcontext1;
        }
        public List<TaskStatus> GetAll()
        {
            List<TaskStatus> MySlider = dbcontext.task_status.OrderByDescending(n => n.Id).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
        public TaskStatus GetById(int Id)
        {
            TaskStatus sslid = dbcontext.task_status.FirstOrDefault(a => a.Id == Id);
            return sslid;
        }
        public bool saveData(TaskStatus savee)
        {
            try
            {
                dbcontext.Add<TaskStatus>(savee);
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateData(TaskStatus updatss)
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
                var catr = GetById(Id);
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
        public List<TaskStatus> GetAllv(int Id)
        {
            List<TaskStatus> MySlider = dbcontext.task_status.OrderByDescending(n => n.Id == Id).Where(a => a.Id == Id).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }

        // //////////////////////////////////////////////////////API/////////////////////////////////////////////////////

        public async Task<List<TaskStatus>> GetAllAsync(int pageNumber, int pageSize)
        {
            List<TaskStatus> MySlIder = await dbcontext.task_status.OrderByDescending(n => n.Id).Where(a => a.CurrentState == true).Skip((pageNumber - 1) * pageSize)
                .Take(pageSize).ToListAsync();
            return MySlIder;
        }

        public async Task<List<TaskStatus>> GetAllvAsync(int Id)
        {
            List<TaskStatus> MySlIder = await dbcontext.task_status.OrderByDescending(n => n.Id == Id).Where(a => a.Id == Id).ToListAsync();
            return MySlIder;
        }

        public async Task<TaskStatus> GetByIdAsync(int Id)
        {
            TaskStatus sslId = await dbcontext.task_status.FirstOrDefaultAsync(a => a.Id == Id && a.CurrentState == true);
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

        public async Task<bool> AddAsync(TaskStatus savee)
        {
            try
            {
                await dbcontext.AddAsync<TaskStatus>(savee);
                await dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(TaskStatus updatss)
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
