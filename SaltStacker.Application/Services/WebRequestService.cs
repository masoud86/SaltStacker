using Newtonsoft.Json;
using SaltStacker.Application.Custom;
using SaltStacker.Application.Interfaces;
using SaltStacker.Application.ViewModels.WebRequest;
using SaltStacker.Common.Helper;
using System.Net.Http.Headers;
using System.Text;

namespace SaltStacker.Application.Services
{
    public class WebRequestService : IWebRequestService
    {
        public WebRequestService()
        {
        }

        public async Task<T> CallAsync<T>(ApiModel api, object parameters, string baseUrl = "", string publicKey = "", string privateKey = "", string receiptNumber = null, string requestNumber = null, string userId = null)
        {
            var url = baseUrl + api.Url;

            switch (api.Type)
            {
                case WebRequestType.Post:
                    return await PostAsync<T>(url, parameters, api.Name, publicKey, privateKey, receiptNumber, requestNumber, userId);
                case WebRequestType.Put:
                    return await PutAsync<T>(url, parameters, api.Name, publicKey, privateKey, receiptNumber, requestNumber, userId);
                case WebRequestType.Delete:
                    return await DeleteAsync<T>(url, parameters, api.Name, publicKey, privateKey, receiptNumber, requestNumber, userId);
                default:
                    return await GetAsync<T>(url, parameters, api.Name, publicKey, privateKey, receiptNumber, requestNumber, userId);
            }
        }

        private async Task<T> GetAsync<T>(string url, object parameters, string apiTitle, string publicKey = "", string privateKey = "", string receiptNumber = null, string requestNumber = null, string userId = null)
        {
            try
            {
                var customDelegatingHandler = new HmacDelegatingHandler(publicKey, privateKey);
                using var client = HttpClientFactory.Create(customDelegatingHandler);

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("fa-IR"));

                var absoluteUrl = $"{url}?{parameters.ConvertObjectQuerystring()}";
                using var response = await client.GetAsync(absoluteUrl);

                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();

                if (typeof(T) == typeof(String))
                {
                    return (T)(object)responseBody;
                }

                var responseModel = JsonConvert.DeserializeObject<T>(responseBody);
                return responseModel;
            }
            catch (Exception ex)
            {
                var response = new WebServiceResult
                {
                    Succeeded = false,
                    Errors = new List<Error>
                    {
                        new Error
                        {
                            ErrorMessages = new List<ErrorMessage>
                            {
                                new ErrorMessage
                                {
                                    Culture = CultureHelper.CurrentCulture,
                                    Message = ex.ToString()
                                }
                            }
                        }
                    }
                };
                return JsonConvert.DeserializeObject<T>(response.ToString());
            }
        }

        private async Task<T> PostAsync<T>(string url, object parameters, string apiTitle, string publicKey = "", string privateKey = "", string receiptNumber = null, string requestNumber = null, string userId = null)
        {
            try
            {

                var customDelegatingHandler = new HmacDelegatingHandler(publicKey, privateKey);
                using var client = HttpClientFactory.Create(customDelegatingHandler);

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("fa-IR"));

                var json = JsonConvert.SerializeObject(parameters);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                using var response = await client.PostAsync(url, data);
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();

                //TODO: Remove after model have been changed
                responseBody = responseBody
                    .Replace("countOfMovement", "capacity")
                    .Replace("fa_IR", "fa-IR")
                    .Replace("en_US", "en-US")
                    .Replace("errorMessage", "errorMessages");

                if (typeof(T) == typeof(string))
                {
                    return (T)(object)responseBody;
                }

                var responseModel = JsonConvert.DeserializeObject<T>(responseBody);
                return responseModel;
            }
            catch (Exception ex)
            {
                var response = new WebServiceResult
                {
                    Succeeded = false,
                    Errors = new List<Error>
                    {
                        new Error
                        {
                            ErrorMessages = new List<ErrorMessage>
                            {
                                new ErrorMessage
                                {
                                    Culture = CultureHelper.CurrentCulture,
                                    Message = ex.ToString()
                                }
                            }
                        }
                    }
                };
                return JsonConvert.DeserializeObject<T>(response.ToString());
            }
        }

        private async Task<T> PutAsync<T>(string url, object parameters, string apiTitle, string publicKey = "", string privateKey = "", string receiptNumber = null, string requestNumber = null, string userId = null)
        {
            try
            {
                var customDelegatingHandler = new HmacDelegatingHandler(publicKey, privateKey);
                using var client = HttpClientFactory.Create(customDelegatingHandler);

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("fa-IR"));

                var json = JsonConvert.SerializeObject(parameters);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                using var response = await client.PutAsync(url, data);
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();
                var responseModel = JsonConvert.DeserializeObject<T>(responseBody);
                return responseModel;
            }
            catch (Exception ex)
            {
                var response = new WebServiceResult
                {
                    Succeeded = false,
                    Errors = new List<Error>
                    {
                        new Error
                        {
                            ErrorMessages = new List<ErrorMessage>
                            {
                                new ErrorMessage
                                {
                                    Culture = CultureHelper.CurrentCulture,
                                    Message = ex.ToString()
                                }
                            }
                        }
                    }
                };
                return JsonConvert.DeserializeObject<T>(response.ToString());
            }
        }

        private async Task<T> DeleteAsync<T>(string url, object parameters, string apiTitle, string publicKey = "", string privateKey = "", string receiptNumber = null, string requestNumber = null, string userId = null)
        {
            try
            {

                var customDelegatingHandler = new HmacDelegatingHandler(publicKey, privateKey);
                using var client = HttpClientFactory.Create(customDelegatingHandler);

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("fa-IR"));

                var absoluteUrl = $"{url}?{parameters.ConvertObjectQuerystring()}";
                using var response = await client.DeleteAsync(absoluteUrl);

                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();
                var responseModel = JsonConvert.DeserializeObject<T>(responseBody);
                return responseModel;
            }
            catch (Exception ex)
            {
                var response = new WebServiceResult
                {
                    Succeeded = false,
                    Errors = new List<Error>
                    {
                        new Error
                        {
                            ErrorMessages = new List<ErrorMessage>
                            {
                                new ErrorMessage
                                {
                                    Culture = CultureHelper.CurrentCulture,
                                    Message = ex.ToString()
                                }
                            }
                        }
                    }
                };
                return JsonConvert.DeserializeObject<T>(response.ToString());
            }
        }
    }
}
