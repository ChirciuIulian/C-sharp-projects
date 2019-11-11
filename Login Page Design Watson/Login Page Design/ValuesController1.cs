using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Speech.Synthesis;
using System.Web.Http;

namespace Login_Page_Design
{

    public class ValuesController : ApiController
    {
        Conversation_Helper helper = new Conversation_Helper("a36c2c60-aacd-4e33-967b-c9f93c32ab49", "1b7b6021-5621-4085-857c-c86cc1c5ad77", "5doIPZZQxEei");
        
        public dynamic Post([FromBody] MessageDto input)//[FromBody]string input, [FromBody]string stringContext = null)
        {
            var context = input.context;//JsonConvert.DeserializeObject(stringContext);
            var res = helper.GetResponse(input.input.text, context).GetAwaiter().GetResult();
            //context = helper.JsonProcesser(res);
            //string returned_value = ((dynamic)(JsonConvert.DeserializeObject(res))).output.text[0].ToString();
            ////using (SpeechSynthesizer synth = new SpeechSynthesizer())
            ////{
            ////    synth.SetOutputToDefaultAudioDevice();

            ////    synth.Speak(returned_value);

            ////}

            return JsonConvert.DeserializeObject(res);
        }
    }
}