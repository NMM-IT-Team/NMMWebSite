using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Diagnostics;
using Newtonsoft.Json.Linq;

namespace NMMEvents.DataLayer
{
    public class BaseSession
    {
        HttpClient client;

        public BaseSession()
        {
            client = new HttpClient();

        }

        public List<T> GetData<T>(Uri requestURI)
        {
            if (requestURI != null)
            {
                try
                {
                    HttpResponseMessage response = client.GetAsync(requestURI).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var content = response.Content.ReadAsStringAsync().Result;
                        if (content != null && content.Length > 0)
                        {
                            return JsonConvert.DeserializeObject<List<T>>(content);
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.InnerException.ToString());
                }
            }

            return null;
        }
    }
}
