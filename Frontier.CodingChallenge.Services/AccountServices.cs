using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Frontier.CodingChallenge.Interfaces;
using Frontier.CodingChallenge.Models;
using Newtonsoft.Json;

namespace Frontier.CodingChallenge.Services
{
    public class AccountServices : IAccountService
    {
        private readonly HttpClient client = new HttpClient();

        /// <summary>
        /// Get the accounts from the repository.
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<Account>> GetAccounts()
        {
            //Make call to api. Normally url would be in config. Would also add resilience to cal
            HttpResponseMessage response = await client.GetAsync("https://frontiercodingtests.azurewebsites.net/api/accounts/getall");
            //put it in responsebody
            var responseBody = await response.Content.ReadAsStringAsync();
            //convert it to List of Accounts
            var retVal = JsonConvert.DeserializeObject<List<Account>>(responseBody); 
            return retVal;
        }
    }
}
