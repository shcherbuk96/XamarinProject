using ClassLibraryExample.Core.Pojo;
using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ClassLibraryExample.Core.Models;
using MonkeyCache.LiteDB;

namespace ClassLibraryExample.Core.Service
{
    public class Data : ILoadData
    {
        public async Task<IEnumerable<HitModel>> GetDataAsync(string message)
        {
            Barrel.ApplicationId = Constants.NameDataBase;
            Barrel.EncryptionKey = Constants.KeyDataBase;

            if (!CrossConnectivity.Current.IsConnected)
            {
                //You are offline, notify the user
                return Barrel.Current.Get<IEnumerable<HitModel>>(key: Constants.KeyDataBase);
            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(message);
                var jsonResponce = await client.GetStringAsync(client.BaseAddress);
                var responce = JsonConvert.DeserializeObject<ListHitsModel>(jsonResponce);

                if (responce != null)
                {
                    Barrel.Current.Add(key: Constants.KeyDataBase, data: responce.Hits, expireIn: TimeSpan.FromDays(1));
                    return responce.Hits;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
