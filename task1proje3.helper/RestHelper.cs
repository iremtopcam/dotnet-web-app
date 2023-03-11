using Newtonsoft.Json;
using RestSharp;

namespace task1proje3.helper
{
    public class RestHelper <TRequest, TResponse>
    {
        public static TResponse Get(string url,string method,Dictionary<string,string> Headers )
        {
            RestRequest Request = new RestRequest();
            RestResponse Response = new RestResponse();

            try
            {
                var client = new RestClient(url);
                Request = new RestRequest(method,Method.Get);
                if (Headers != null && Headers.Count > 0)
                {
                    foreach (var item in Headers)
                    {
                        Request.AddHeader(item.Key,item.Value);

                    }

                }

                Response = client.Execute(Request);




            }
            catch (Exception ex )
            {

                Console.WriteLine(ex.Message);
                throw(ex);
                
            }

            return JsonConvert.DeserializeObject<TResponse>(Response.Content);
        
        
        }
            
    }
}