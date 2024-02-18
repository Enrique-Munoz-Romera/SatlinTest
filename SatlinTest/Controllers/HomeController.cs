using Microsoft.AspNetCore.Mvc;
using SatlinTest.Back.Repositories;
using SatlinTest.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SatlinTest.Controllers
{
    public class HomeController : Controller
    {
        ServiceApi ServiceApi;
        UserRepo repo;
        
        public HomeController(ServiceApi service, UserRepo repo)
        {
            this.ServiceApi = service;
            this.repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<User> users = repo.GetUsers();          
            return View(users);
        }

        [HttpPost]
        public async Task<IActionResult> Index(int id, string username)
        {
            this.repo.UpdateUser(id, username);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            repo.DeleteUser(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> SearchUsers()
        {
            List<User> userList = await this.ServiceApi.GetUsersAsync();
            foreach (var user in userList)
            {
                var us = repo.GetUser(user.id);
                if (us == null)
                {
                    repo.CreateUser(user);
                }
                else
                {
                    if(us.username != user.username)
                    {
                        repo.UpdateUser(user.id, user.username);
                    }
                }
            }
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
