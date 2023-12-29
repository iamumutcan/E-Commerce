using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace E_Commerce.DataIntegration.Blockchain
{
    public class BlockchainHandler
    {
        private readonly string _baseUrl = "http://localhost:5000/api/blockchain/";
        public async Task<bool> AddTransactions(TransactionBlock tx)
        {
            string url = _baseUrl + "AddTransactions";
            var result = false;
            try
            {
                var requestData = new { fromAddress = tx.fromAddressPrivateKey, toAddress= tx.toAddress, amount= tx.amount };
                string responseString = await SendPostRequest(url, requestData);

                if (!string.IsNullOrEmpty(responseString))
                {
                    dynamic responseData = JsonConvert.DeserializeObject(responseString);
                    result = responseData.data.result;
                }
            }
            catch (Exception ex)
            {
                // Handle exception
                // Console.WriteLine("Exception occurred: " + ex.Message);
            }

            return result;
        }

        public async Task<decimal> GetWalletBalance(string walletAddress)
        {
            string url = _baseUrl + "WalletBalance";
            decimal balance = 0;

            try
            {
                var requestData = new { walletAddress = walletAddress };
                string responseString = await SendPostRequest(url, requestData);

                if (!string.IsNullOrEmpty(responseString))
                {
                    dynamic responseData = JsonConvert.DeserializeObject(responseString);
                    balance = responseData.data.amount;
                }
            }
            catch (Exception ex)
            {
                // Handle exception
               // Console.WriteLine("Exception occurred: " + ex.Message);
            }

            return balance;
        }

        private async Task<string> SendPostRequest(string apiUrl, object requestData)
        {
            string responseString = string.Empty;

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var jsonContent = JsonConvert.SerializeObject(requestData);
                    var requestContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(apiUrl, requestContent);

                    if (response.IsSuccessStatusCode)
                    {
                        responseString = await response.Content.ReadAsStringAsync();
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

            return responseString;
        }


    }

}
