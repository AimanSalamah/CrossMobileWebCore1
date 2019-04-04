using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Mobile.Service
{
    public class DataStore<T>
    {
        public T Post(T model)
        {
            HttpClient client = new HttpClient();
            var respons = client.PostAsJsonAsync($"http://localhost:50397/api/{typeof(T).Name}", model).Result;
            if (respons.StatusCode == System.Net.HttpStatusCode.Created)
            {
                var data = respons.Content.ReadAsAsync<T>().Result;
                return data;
            }
            else
            {
                return default(T);
            }

        }
        public List<T> Get()
        {
            try
            {
                HttpClient client = new HttpClient();
                var respons = client.GetAsync($"http://localhost:50397/api/{typeof(T).Name}").Result;
                return respons.Content.ReadAsAsync<List<T>>().Result;
            }
            catch (Exception ex)
            {
                switch (ex.GetType().Name)
                {
                    case "com exception":
                        //do somthig
                        break;
                    case "exception1":
                        //do somthig
                        break;
                    case "exception2":
                        //do somthig
                        break;
                    default:
                        //do general exception messge
                        return null;
                        break;
                }
                //do something with ex
                return null;
            }

        }
    }
}
