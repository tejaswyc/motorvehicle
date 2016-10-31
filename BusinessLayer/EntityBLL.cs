using DataLayer;

namespace BusinessLayer
{
    public class EntityBLL
    {
        public void AddingUser()
        {
            EntityDal objUser = new EntityDal();
            objUser.AddData();
        }
    }
}
