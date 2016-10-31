using DataLayer.EntityModels;
using Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace DataLayer
{
    public class UserDAL
    {
        public UserInfos GetUserDetails(string Username)
        {
            using (var entity = new VehicleRegistrationContext())
            {
                var checkUserExisting = (from u in entity.UserInfos
                                         where u.Username == Username
                                         select u.Username).Count();
                if (checkUserExisting != 0)
                {
                    var getUserDetails = (from u in entity.UserInfos
                                          where u.Username == Username
                                          select new UserInfos()
                                          {
                                              UserId = u.UserId,
                                              Username = u.Username,
                                              Password = u.Password,
                                              Firstname = u.Firstname,
                                              Lastname = u.Lastname
                                          }).FirstOrDefault();
                    return getUserDetails;
                }
                else
                {
                    return null;
                }

            }
        }
        public List<ViewAllList> RegistrationsViewall()
        {
            using (var entity = new VehicleRegistrationContext())
            {

                var details = (from i in entity.OwnerVehicleIntermediates
                               join v in entity.VehicleDetails
                               on i.VehiclesId equals v.VehicleId
                               join o in entity.OwnerDetails
                               on i.OwnerId equals o.Id
                               join c in entity.VehicleNames
                               on v.VehicleNameId equals c.NameId
                              
                               where v.IsActive == true
                               select new ViewAllList()
                               {
                                   VehicleId = v.VehicleId,
                                   VehicleNumber = v.VehicleNumber,
                                   VehicleName = c.Name,
                                   OwnerName = o.OwnerName,
                                   Date = v.Date

                               }).ToList();

                return details;
            }
        }
        public ViewAllList ViewDetails(int id)
        {
            using (var entity = new VehicleRegistrationContext())
            {
                var details = (from i in entity.OwnerVehicleIntermediates
                               join v in entity.VehicleDetails
                               on i.VehiclesId equals v.VehicleId
                               join o in entity.OwnerDetails
                               on i.OwnerId equals o.Id
                               join c in entity.VehicleNames
                               on v.VehicleNameId equals c.NameId
                             
                               join y in entity.Countrys
                               on o.Country equals y.CountryId

                               where v.VehicleId == id
                               select new ViewAllList()
                               {
                                   VehicleId = v.VehicleId,
                                   VehicleNumber = v.VehicleNumber,
                                   VehicleName = c.Name,
                                   VehicleNameId=c.NameId,
                                  
                                   CountryId=y.CountryId,
                                   OwnerName = o.OwnerName,
                                   Address = o.Address,
                                   Country = y.CountryName,
                                   Colour = v.Colour,
                                   VehicleType = c.VehicleType,
                                   ChasisNumber = v.ChasisNumber,
                                   Date = v.Date
                               }).FirstOrDefault();
                return details;
            }
        }
        public List<SelectListItem> CountryDropdown()
        {
            using (var entity = new VehicleRegistrationContext())
            {
                var country = (from m in entity.Countrys

                               select new SelectListItem()
                               {
                                   Value = m.CountryId.ToString(),
                                   Text = m.CountryName

                               }).ToList();
                return country;
            }
        }
        public List<SelectListItem> OwnerDropdown()
        {
            using (var entity = new VehicleRegistrationContext())
            {
                var owner = (from m in entity.OwnerDetails

                            select new SelectListItem()
                            {
                                Value = m.OwnerName,
                                Text = m.OwnerName

                            }).ToList();
                return owner;
            }
        }
        public List<SelectListItem> NameDropdown()
        {
            using (var entity = new VehicleRegistrationContext())
            {
                var name = (from m in entity.VehicleNames

                            select new SelectListItem()
                            {
                                Value = m.NameId.ToString(),
                                Text = m.Name

                            }).ToList();
                return name;
            }
        }
        public int DeleteRegistration(int id)
        {
            using (var entity = new VehicleRegistrationContext())
            {
                var IsActive = (from m in entity.VehicleDetails
                                where m.VehicleId == id
                                select m).SingleOrDefault();
                IsActive.IsActive = false;
                int flag=entity.SaveChanges();
                string registrationNumber = IsActive.VehicleNumber;
                return flag;
            }
        }
        public int AddRegistration(CompleteDetailsViewModel addNew)
        {
            using (var entity = new VehicleRegistrationContext())
            {
                var vehicleUniqueness = (from m in entity.VehicleDetails
                                         where m.VehicleNumber == addNew.VehicleNumber
                                         select m.VehicleNumber).Count();
                var nameCount = (from n in entity.OwnerDetails
                                 where n.OwnerName == addNew.OwnerName
                                 select n.OwnerName).Count();
                if (vehicleUniqueness == 0)
                {


                    VehicleDetail addVehicle = new VehicleDetail();
                    addVehicle.VehicleNumber = addNew.VehicleNumber;
                    addVehicle.VehicleNameId = addNew.VehicleNameId;
                   
                    addVehicle.ChasisNumber = addNew.ChasisNumber;
                    addVehicle.Colour = addNew.Colour;
                    DateTime dateAndTime = DateTime.Today;
                    addVehicle.Date = dateAndTime.ToString("dd-MM-yyyy");
                    addVehicle.IsActive = true;
                    using (System.Data.Entity.DbContextTransaction dbTran = entity.Database.BeginTransaction())
                    {
                        try
                        {
                            entity.VehicleDetails.Add(addVehicle);
                            entity.SaveChanges();
                            var id = (from m in entity.VehicleDetails
                                      orderby m.VehicleId descending
                                      select m.VehicleId).FirstOrDefault();
                            if(nameCount==0)
                            {
                                OwnerDetail addOwner = new OwnerDetail();
                                addOwner.OwnerName = addNew.OwnerName;
                                addOwner.Country = addNew.CountryId;
                                addOwner.Address = addNew.Address;
                              
                                entity.OwnerDetails.Add(addOwner);
                                entity.SaveChanges();
                            }
                            var ownerId = (from o in entity.OwnerDetails
                                           where o.OwnerName == addNew.OwnerName
                                           select o.Id).FirstOrDefault();
                            OwnerVehicleIntermediate addDetails = new OwnerVehicleIntermediate();
                            addDetails.VehiclesId= Convert.ToInt32(id);
                            addDetails.OwnerId = ownerId;
                            entity.OwnerVehicleIntermediates.Add(addDetails);
                            entity.SaveChanges();
                            dbTran.Commit();
                            return 2;
                        }
                        catch
                        {
                            dbTran.Rollback();
                            return 0;
                        }

                    }

                }
                else
                {
                    return 0;
                }
            }
        }
        public int CheckExists(int id)
        {
            using (var entity = new VehicleRegistrationContext())
            {
                var checkUserExisting = (from u in entity.VehicleDetails
                                         where u.VehicleId == id
                                         select u.VehicleId).Count();
                return checkUserExisting;
            }

        }
        public int VehicleRegisterEdit(int id, CompleteDetailsViewModel edit)
        {
            using (var entity = new VehicleRegistrationContext())
            {
                using (System.Data.Entity.DbContextTransaction dbTran = entity.Database.BeginTransaction())
                {
                    try
                    {

                        var details = (from m in entity.VehicleDetails
                                       where m.VehicleId == id
                                       select m).FirstOrDefault();
                       
                        details.VehicleNameId = edit.VehicleNameId;
                       
                        details.Colour = edit.Colour;
                        details.ChasisNumber = edit.ChasisNumber;
                        
                       
                        entity.SaveChanges();
                        var nameCount = (from n in entity.OwnerDetails
                                         where n.OwnerName == edit.OwnerName
                                         select n.OwnerName).Count();
                        if (nameCount == 0)
                        {
                           

                            OwnerDetail addOwner = new OwnerDetail();
                            addOwner.OwnerName = edit.OwnerName;
                            addOwner.Address = edit.Address;
                            addOwner.Country = edit.CountryId;
                            entity.OwnerDetails.Add(addOwner);
                            entity.SaveChanges();
                        }
                       
                       
                        var ownerId = (from o in entity.OwnerDetails
                                       where o.OwnerName == edit.OwnerName
                                       select o.Id).FirstOrDefault();
                        var ownerNewDetails = (from m in entity.OwnerVehicleIntermediates
                                            join n in entity.OwnerDetails
                                            on m.OwnerId equals n.Id
                                            join v in entity.VehicleDetails
                                            on m.VehiclesId equals v.VehicleId
                                            where v.VehicleId == id
                                            select m).FirstOrDefault();
                        ownerNewDetails.OwnerId = ownerId;
                        int set=entity.SaveChanges();
                        dbTran.Commit();
                        return 2;
                    }
                    catch
                    {
                        dbTran.Rollback();
                        return 0;
                    }
                }

            }
        }
        public List<ViewAllList> RegistrationSearch(string searchText)
        {
            using (var entity = new VehicleRegistrationContext())
            {

                var details = (from i in entity.OwnerVehicleIntermediates
                               join v in entity.VehicleDetails
                               on i.VehiclesId equals v.VehicleId
                               join o in entity.OwnerDetails
                               on i.OwnerId equals o.Id
                               join c in entity.VehicleNames
                               on v.VehicleNameId equals c.NameId
                              
                               where ((o.OwnerName.Contains(searchText)||v.Date.Contains(searchText)) && v.IsActive == true)

                               select new ViewAllList()
                               {
                                   VehicleId = v.VehicleId,
                                   VehicleNumber = v.VehicleNumber,
                                   VehicleName = c.Name,
                                   OwnerName = o.OwnerName,
                                   Date = v.Date

                               }).ToList();
                return details;
            }
        }
    }
}

