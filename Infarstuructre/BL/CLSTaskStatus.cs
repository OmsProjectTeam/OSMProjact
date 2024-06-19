

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

    }
}
