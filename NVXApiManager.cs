using System;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.Extensions.Caching.Memory;
using System.Net.Http.Headers;
using System.Windows.Forms;


namespace Crestron_NVX
{
    
    public class NvxApiManager
    {
        private readonly HttpClient _client;
        private readonly IMemoryCache _cache;
        private readonly string _ip;
        
        
        //Constructor of the NvxApiManager class
        public NvxApiManager(string ip,IMemoryCache cache)
        {
            _client = new HttpClient();
            _cache = cache;
            _ip = ip;
        }

        //This method is called to start a session with the device.
        public async Task<HttpResponseMessage> BeginSession()
        {

            var request = new HttpRequestMessage(HttpMethod.Get, $"https://{_ip}/userlogin.html");
            var response = await _client.SendAsync(request);
            
            if (response.IsSuccessStatusCode)
            {
                CacheTrackID(response);
            }
          
            return response;

        }   

        //This method is called to authenticate the user.
        public async Task<HttpResponseMessage> Authenticate(string username, string password)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, $"https://{_ip}/userlogin.html");
            request.Content = new StringContent($"login={username}&&passwd={password}");
            request.Headers.Add("Cookie", $"TRACKID={_cache.Get("TRACKID")}");
            request.Headers.Add("Origin", $"https://{_ip}");
            request.Headers.Add("Referer", $"https://{_ip}/userlogin.html");

            var response = await _client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                CacheResponse(response);
                return response;
            }
            else
            {
                throw new Exception("Failed to authenticate. Please check username and password and try again.");
            }
        }

        //This method is called to get the resolution and current sync status of the device.
        public async Task<string> GetAsync(string url)
        {
            //Creates a new request and adds required headers
            var request = new HttpRequestMessage(HttpMethod.Get, "https://" + _ip + url);
            if (_cache.TryGetValue("headers", out object headers))
            {
                foreach (var header in (HttpHeaders)headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }
            }

            //Retrieves required cookies from cache and adds them to the new request
            var cookieNames = new[] { "AuthByPasswd", "TRACKID", "iv", "tag", "userid", "userstr" };
            foreach (var cookieName in cookieNames)
            {
                if (_cache.TryGetValue(cookieName, out object cookieValue))
                {
                    request.Headers.Add("Cookie", $"{cookieName}={cookieValue}");
                }
            }

            var response = await _client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                CacheResponse(response);
            }
            else
            {
                throw new Exception($"Failed to get data. Error code {response.StatusCode}");
            }
            return response.Content.ToString();
        }

        //This method is called to retrieve the TRACKID from the response and store it in cache.
        private void CacheTrackID(HttpResponseMessage response)
        {
            var trackID = response.Headers.GetValues("Set-Cookie").FirstOrDefault(x => x.StartsWith("TRACKID"));
            _cache.Set("TRACKID", trackID, TimeSpan.FromHours(1));
        }

        //This method is called to retrieve the cookies from the response and store them in cache.
        private void CacheResponse(HttpResponseMessage response)
        {
            _cache.Set("headers", response.Headers, TimeSpan.FromHours(1));

            var cookies = response.Headers.GetValues("Set-Cookie");
            foreach (var cookie in cookies)
            {
                var cookieParts = cookie.Split(';')[0].Split('=');
                var cookieName = cookieParts[0];
                var cookieValue = cookieParts[1];
                _cache.Set(cookieName, cookieValue, TimeSpan.FromHours(1));
            }
        }

        //This method is called to end the session with the device.
        public async Task<HttpResponseMessage>EndSession()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://{_ip}/logout");
            await _client.SendAsync(request);
            _cache.Remove("TRACKID");
            _cache.Remove("headers");
            _cache.Remove("cookies");
            return null;
        }

    }
}