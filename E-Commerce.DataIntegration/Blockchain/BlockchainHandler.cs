using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DataIntegration.Blockchain
{
    public class BlockchainHandler
    {
        private readonly string _baseUrl = "http://localhost:5000/api/blockchain/";
        public readonly string systemWalletAddres = "04b9c730bc86aa3b3234b1e47b20d2ceaa22c4cacb3c23e99f8b88415576942e754eb43f49cdd411cf260fc03f23cc312067301d114f04cb19b44e6960d51cef78";
        private readonly string systemPrivateKey = "67bc8f25231231e64f5b8b1222fdf8a46ad3d68f77bd7fa9eda203be6bdd0928";
        public async Task<bool> AddTransactions(TransactionBlock tx)
        {
            string url = _baseUrl + "AddTransactions";
            var result = false;
            try
            {
                var requestData = new { fromAddress = tx.fromAddressPrivateKey, toAddress = tx.toAddress, amount = tx.amount };
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
