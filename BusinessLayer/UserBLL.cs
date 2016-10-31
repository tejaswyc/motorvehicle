using DataLayer;
using Model;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BusinessLayer
{
    public class UserBLL
    {
        UserDAL userDal = new UserDAL();
        public UserInfosViewModel GetDetails(string Username)
        {
            
            UserInfos details =userDal.GetUserDetails(Username);
            UserInfosViewModel userInfoView = new UserInfosViewModel();
            if (details != null)
            {
                userInfoView.UserId = details.UserId;
                userInfoView.Username = details.Username;
                userInfoView.Password = details.Password;
                userInfoView.Firstname = details.Firstname;
                userInfoView.Lastname = details.Lastname;
                return userInfoView;
            }
            else
            {
                return null;
            }
        }
        public ListViewAllViewModel ViewallRegistration()
        {
           
            ListViewAllViewModel viewallobj = new ListViewAllViewModel();

            List<ViewAllList> allRegistrations = userDal.RegistrationsViewall();
            viewallobj.collections = allRegistrations;
            return (viewallobj);
        }
        public ViewAllListViewModel GetRegistrationDetails(int id)
        {
            ViewAllList getDetails = userDal.ViewDetails(id);
            ViewAllListViewModel completeDetails = new ViewAllListViewModel();
                                 completeDetails.VehicleId = getDetails.VehicleId;
                                 completeDetails.VehicleNumber = getDetails.VehicleNumber;
                                 completeDetails.VehicleName = getDetails.VehicleName;
                                 completeDetails.OwnerName = getDetails.OwnerName;
                                 completeDetails.Address = getDetails.Address;
                                 completeDetails.Country = getDetails.Country;
                                 completeDetails.Colour = getDetails.Colour;
                                 completeDetails.VehicleType = getDetails.VehicleType;
                                 completeDetails.ChasisNumber = getDetails.ChasisNumber;
                                 completeDetails.Date = getDetails.Date;
            return completeDetails;
        }
        public CompleteDetailsViewModel BindDropdown()
        {
            CompleteDetailsViewModel addNew = new CompleteDetailsViewModel();
            addNew.CountryList=userDal.CountryDropdown();
           
            addNew.OwnerList = userDal.OwnerDropdown();
            addNew.NameList = userDal.NameDropdown();
            return addNew;
        }
        public int DeleteVehicle(int id)
        {
           int flag=userDal.DeleteRegistration(id);
            return flag;
        }
        public int AddVehicle(CompleteDetailsViewModel addVehicle)
        {
              int count = userDal.AddRegistration(addVehicle);
            
            return count;
        }
        public CompleteDetailsViewModel GetEditDetails(int id)
        {
            ViewAllList details = userDal.ViewDetails(id);
            CompleteDetailsViewModel edit = new CompleteDetailsViewModel();
         
            edit.CountryList = userDal.CountryDropdown();
           
            edit.OwnerList = userDal.OwnerDropdown();
            

            edit.NameList = userDal.NameDropdown();
            edit.VehicleName = details.VehicleName;
            edit.CountryName = details.Country;
            edit.VehicleNumber = details.VehicleNumber;
            edit.Colour = details.Colour;
            edit.ChasisNumber = details.ChasisNumber;
            edit.OwnerName = details.OwnerName;
            edit.Address = details.Address;
            edit.Date = details.Date;
            return edit;

        }
        public int checkIfExists(int id)
        {
            int check=userDal.CheckExists(id);
            return check;
        }
        public int EditVehicleRegistration(int id, CompleteDetailsViewModel editRegistration)
        { 
            int editCount = userDal.VehicleRegisterEdit(id,editRegistration);
            return editCount;
        }
        public ListViewAllViewModel SearchRegistration(string searchText)
        {
            List<ViewAllList> allRegistrations=userDal.RegistrationSearch(searchText);
            ListViewAllViewModel viewallobj = new ListViewAllViewModel();

           
            viewallobj.collections = allRegistrations;
            return (viewallobj);
        }
    }
}
