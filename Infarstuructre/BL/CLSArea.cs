
namespace Infarstuructre.BL
{
    public interface IIArea
    {
        List<TBViewAreas> GetAll();
        Area GetById(int Id);
        bool saveData(Area savee);
        bool UpdateData(Area updatss);
        bool deleteData(int Id);
        List<TBViewAreas> GetAllv(int Id);
    }
    public class CLSArea: IIArea
    {
        MasterDbcontext dbcontext;
        public CLSArea(MasterDbcontext dbcontext1)
        {
            dbcontext=dbcontext1;
        }
        public List<TBViewAreas> GetAll()
        {
            List<TBViewAreas> MySlIder = dbcontext.ViewAreas.OrderByDescending(n => n.id).Where(a => a.CurrentState == true).ToList();
            return MySlIder;
        }
        public Area GetById(int Id)
        {
            Area sslId = dbcontext.areas.FirstOrDefault(a => a.Id == Id);
            return sslId;
        }
        public bool saveData(Area savee)
        {
            try
            {
                dbcontext.Add<Area>(savee);
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateData(Area updatss)
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
        public List<TBViewAreas> GetAllv(int Id)
        {
            List<TBViewAreas> MySlIder = dbcontext.ViewAreas.OrderByDescending(n => n.id == Id).Where(a => a.id == Id).ToList();
            return MySlIder;
        }
    }
}
