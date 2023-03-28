using Newtonsoft.Json;

using RestSharp;


namespace LaravelAPILogin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Login("christopherjherd@gmail.com", "123456789");
        }

        static void Login(string username, string password) {
            string url = "https://www.sherburnaeroclub.com/auth/login";
            Dictionary<String,String> data = new Dictionary<String,String>();
            data["username"] = username;
            data["password"] = password;

            var jsonData = JsonConvert.SerializeObject(data);
            var client = new RestClient(url);
            var request = new RestRequest()
                          .AddBody(jsonData) ;  
            RestResponse response = new();
            try { response = client.GetAsync(request).Result; }
            catch(Exception ex) {
                Console.WriteLine(ex.Message.ToString());
            }
            Dictionary<object, object> dataDictionaryClean = JsonConvert.DeserializeObject<Dictionary<object,object>>(response.Content.ToString());


        }
    }
}