
namespace Infarstuructre.BL
{
    public interface IIUser
    {
        List<TBViewUsers> GetAll();
        User GetById(int Id);
    }
    public class CLSUser: IIUser
    {

        MasterDbcontext dbcontext;
        public CLSUser(MasterDbcontext dbcontext1)
        {
            dbcontext=  dbcontext1;
        }
        public List<TBViewUsers> GetAll()
        {
            List<TBViewUsers> MySlider = dbcontext.ViewUsers.OrderByDescending(n => n.id).ToList();
            return MySlider;
        }

        public User GetById(int Id)
        {
            User sslid = dbcontext.users.FirstOrDefault(a => a.Id == Id);
            return sslid;
        }
        //public bool deleteData(int Id)
        //{
        //    try
        //    {
        //        var catr = GetById(Id);

        //        User dele = dbcontext.users.Where(a => a.Id == Id).FirstOrDefault();
        //        dbcontex.TbSubCateegoorys.Remove(dele);
        //        dbcontext.Entry(catr).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        //        dbcontext.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }

        //}

    }
}
