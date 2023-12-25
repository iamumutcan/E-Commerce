using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace E_Commerce.DataIntegration.Blockchain
{
    public class BlockchainHandler
    {
        private readonly string _baseUrl = "http://localhost:5000/apiV2/blockchain/";

        public async Task<decimal> GetWalletBalance(string walletAddress)
        {
            string url = _baseUrl + "WalletBalance";
            decimal balance = 0;

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var requestData = new { walletAddress = walletAddress };
                    var jsonContent = JsonConvert.SerializeObject(requestData);
                    var requestContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                    
                    HttpResponseMessage response = await client.PostAsync(url, requestContent);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseString = await response.Content.ReadAsStringAsync();
                        dynamic responseData = JsonConvert.DeserializeObject(responseString);
                        balance = responseData.data.amount;
                    }
                    else
                    {
                        // Handle error response
                        Console.WriteLine("Error occurred: " + response.ReasonPhrase);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception
                Console.WriteLine("Exception occurred: " + ex.Message);
            }

            return balance;
        }
    }
}
