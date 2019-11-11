

namespace Login_Page_Design
{
    public class MessageConverter
    {
        public string Convert_input(string mesaj, dynamic context)
        {
            var myInput = new InputDto() { text = mesaj };
            var message = new MessageDto()
            {
                input = myInput,
                context = context,
                alternate_intents = true
            };
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(message);

            return json;
        }
    }
}