using DataLayer.EntityModels;

namespace DataLayer
{
    public class EntityDal
    {
        public void AddData()
        {
           
            using (var entity = new VehicleRegistrationContext())
            {
                UserInfo add = new UserInfo();
               
                add.Username = "james@gmail.com";
                add.Password = "james";
                add.Firstname = "James";
                add.Lastname = "G";
             
                entity.UserInfos.Add(add);
                entity.SaveChanges();
            }
        }
    }
}
