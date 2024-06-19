

namespace Infarstuructre.BL
{
    public interface IIRolesName
    {
        List<RolesName> GetAll();
        RolesName GetById(int Id);
        bool saveData(RolesName savee);
        bool UpdateData(RolesName updatss);
        bool deleteData(int Id);

    }

    public class CLSRolesName: IIRolesName
    {
        MasterDbcontext dbcontext;
        public CLSRolesName(MasterDbcontext dbcontext1)
        {
            dbcontext=dbcontext1;
        }
        public List<RolesName> GetAll()
        {
            List<RolesName> MySlider = dbcontext.RolesNames.OrderByDescending(n => n.Id).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
        public RolesName GetById(int Id)
        {
            RolesName sslid = dbcontext.RolesNames.FirstOrDefault(a => a.Id == Id);
            return sslid;
        }
        public bool saveData(RolesName savee)
        {
            try
            {
                dbcontext.Add<RolesName>(savee);
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateData(RolesName updatss)
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
                //var catr = GetById(Id);
                //catr.CurrentState = false;
                ////TbSubCateegoory dele = dbcontex.TbSubCateegoorys.Where(a => a.IdBrand == IdBrand).FirstOrDefault();
                ////dbcontex.TbSubCateegoorys.Remove(dele);
                //dbcontext.Entry(catr).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                //dbcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
