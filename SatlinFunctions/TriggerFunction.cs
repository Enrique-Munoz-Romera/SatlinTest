using System;
using System.Collections.Generic;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using SatlinFunctions.Services;
using SatlinFunctions.Models;
using System.Threading.Tasks;
using SatlinFunctions.Back.Repositories;

namespace SatlinFunctions
{
    public class TriggerFunction
    {
        UserRepo repo;

        public TriggerFunction(UserRepo UR)
        {
            this.repo = UR;
        }

        [FunctionName("TriggerFunction")]
        public async Task Run([TimerTrigger("0 * * * * *")] TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {myTimer.Schedule}");
            string urlApi = Environment.GetEnvironmentVariable("Api");
            ServiceApi sa = new ServiceApi(urlApi);
            List<User> userList = await sa.GetUsersAsync();
            foreach (var user in userList)
            {
                var us = repo.GetUser(user.id);
                if (us == null)
                {
                    repo.CreateUser(user);
                }
                else
                {
                    if (us.username != user.username)
                    {
                        repo.UpdateUser(user.id, user.username);
                    }
                }
            }
        }
    }
}
