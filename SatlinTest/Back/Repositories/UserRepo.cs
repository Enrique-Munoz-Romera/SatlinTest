using SatlinTest.Back.Data;
using SatlinTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SatlinTest.Back.Repositories
{
    public class UserRepo
    {
        BackContext context;
        GeoRepo geoRepo;
        CompanyRepo companyRepo;
        AddressRepo addressRepo;

        public UserRepo(BackContext Context, GeoRepo GeoRepo, CompanyRepo CompanyRepo, AddressRepo AddressRepo) { 
            this.context = Context;
            this.geoRepo = GeoRepo;
            this.companyRepo = CompanyRepo;
            this.addressRepo = AddressRepo;
        }

        #region Get
        public List<User> GetUsers()
        {
            var query = from datos in this.context.User
                        select datos;
            List<User> users = query.ToList();

            foreach (var user in users)
            {
                user.address = this.addressRepo.GetAddress(user.addressId);
                user.address.geo = this.geoRepo.GetGeo(user.address.geoId);
                user.company = this.companyRepo.GetCompany(user.companyId);
            }

            return users;
        }

        public User GetUser(int id)
        {
            var query = from datos in this.context.User where datos.id == id
                        select datos;
            return query.FirstOrDefault();
        }
        #endregion

        #region Post
        public void CreateUser(User user)
        {
            Address address = user.address;
            Geo geo = user.address.geo;
            Company company = user.company;

            this.context.Geo.Add(geo);
            this.context.Address.Add(address);
            this.context.Company.Add(company);
            this.context.User.Add(user);

            this.context.SaveChanges();
        }
        #endregion

        #region Update
        public void UpdateUser(int id, string username)
        {
            User user = this.GetUser(id);
            user.username = username;
            this.context.Update(user);
            this.context.SaveChanges();
        }
        #endregion

        #region Delete
        public void DeleteUser(int id)
        {
            User user = this.GetUser(id);
            this.context.Remove(user);
            this.context.SaveChanges();
        }
        #endregion
    }
}
