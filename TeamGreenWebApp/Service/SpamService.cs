using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TeamGreenWebApp.Models;

namespace TeamGreenWebApp.Service
{
    public class SpamService
    {
        public async Task<bool> InvokeRequestResponseService(string header)
        {
            var handler = new HttpClientHandler()
            {
                ClientCertificateOptions = ClientCertificateOption.Manual,
                ServerCertificateCustomValidationCallback =
                        (httpRequestMessage, cert, cetChain, policyErrors) => { return true; }
            };
            using (var client = new HttpClient(handler))
            {
                // Request data goes here
                var scoreRequest = new
                {
                    Inputs = new Dictionary<string, List<Dictionary<string, string>>>()
                    {
                        {
                            "data",
                            new List<Dictionary<string, string>>()
                            {
                                new Dictionary<string, string>()
                                {
                                    {
                                        "message", $"{header}"
                                    },
                                    {
                                        "Column3", $"{header}"
                                    },
                                }
                            }
                        },
                    },
                    GlobalParameters = new Dictionary<string, string>()
                    {
                        {
                            "method", "predict"
                        },
                    }
                };

                const string apiKey = "tVvn6f1MpYhZfho3eGacZ1C8WRKoNGzC";
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
                client.BaseAddress = new Uri("http://695fc2be-7713-4f1b-a5bd-2325f06b733a.southcentralus.azurecontainer.io/score");

                var requestString = JsonConvert.SerializeObject(scoreRequest);
                var content = new StringContent(requestString);

                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                HttpResponseMessage response = await client.PostAsync("", content);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();

                    if (result.Contains("[1.0]"))
                    {
                        return true;
                    }

                    if (result.Contains("[0.0]"))
                    {
                        return false;
                    }

                }

                return false;
            }
        }
    }
}
