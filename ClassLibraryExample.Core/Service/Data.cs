using ClassLibraryExample.Core.Pojo;
using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ClassLibraryExample.Core.Service
{
    class Data : ILoadData
    {

        public async Task<IEnumerable<Hit>> GetDataAsync(string message)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                //You are offline, notify the user
                return null;
            }

            using (var client = new HttpClient())
            {
                //if (message != null)
                //{
                //    Constants.URL.Replace("cats", message);
                    
                //}

                client.BaseAddress = new Uri(message);
                var jsonResponce = await client.GetStringAsync(client.BaseAddress);
                var responce = JsonConvert.DeserializeObject<ListHits>(jsonResponce);

                if (responce != null)
                {               
                    return responce.Hits;
                }
                else
                {
                    return null;
                }
            }

        }

        //public Task<IEnumerable<Hit>> SearchGetDataAsync(string message)
        //{
        //    if (!CrossConnectivity.Current.IsConnected)
        //    {
        //        //You are offline, notify the user
        //        return null;
        //    }

        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri(Constants.URL);
        //        var jsonResponce = await client.GetStringAsync(client.BaseAddress);
        //        var responce = JsonConvert.DeserializeObject<ListHits>(jsonResponce);

        //        if (responce != null)
        //        {
        //            return responce.Hits;
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //}
    }
}
