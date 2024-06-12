

namespace Infarstuructre.BL
{
    public interface IICity
    {
        List<City> GetAll();
        City GetById(int Id);
        bool saveData(City savee);
        bool UpdateData(City updatss);
        bool deleteData(int Id);
    }
    public class CLSCity: IICity
    {
        MasterDbcontext dbcontext;
        public CLSCity(MasterDbcontext dbcontext1)
        {
            dbcontext = dbcontext1;
        }
        public List<City> GetAll()
        {
            List<City> MySlider = dbcontext.cities.OrderByDescending(n => n.Id).ToList();
            return MySlider;
        }
        public City GetById(int Id)
        {
            City sslid = dbcontext.cities.FirstOrDefault(a => a.Id == Id);
            return sslid;
        }
        public bool saveData(City savee)
        {
            try
            {
                dbcontext.Add<City>(savee);
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateData(City updatss)
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
