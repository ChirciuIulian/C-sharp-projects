using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Watson_Assistant_trial
{
    class Conversation_Helper
    {
        private readonly string _Server;
        private readonly NetworkCredential _NetCredential;
        MessageConverter converter = new MessageConverter();


        public Conversation_Helper(string workSpaceId, string userId, string password)
        {
            _Server = string.Format("https://gateway.watsonplatform.net/conversation/api/v1/workspaces/{0}/message?version={1}", workSpaceId, DateTime.Today.ToString("yyyy-MM-dd"));
            _NetCredential = new NetworkCredential(userId, password);
        }


        public async Task<string> GetResponse(string input, dynamic context)
        {
            string req = null;
            req = converter.Convert_input(input, context);
            using (var handler = new HttpClientHandler
            {
                Credentials = _NetCredential
            })
            using (var client = new HttpClient(handler))
            {
                var cont = new HttpRequestMessage();
                cont.Content = new StringContent(req.ToString(), Encoding.UTF8, "application/json");
                var result = await client.PostAsync(_Server, cont.Content);
                return await result.Content.ReadAsStringAsync();
            }
        }


        public dynamic JsonProcesser(string message)
        {
            dynamic deser = JsonConvert.DeserializeObject(message);
            return deser.context;
        }

    }
}

