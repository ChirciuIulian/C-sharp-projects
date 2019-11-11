using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Recognition;
using System.Speech.Synthesis;

namespace Watson_Assistant_trial
{
    class Program
    {

        static void Main(string[] args)
        {
            Conversation_Helper helper = new Conversation_Helper("a36c2c60-aacd-4e33-967b-c9f93c32ab49", "1b7b6021-5621-4085-857c-c86cc1c5ad77", "5doIPZZQxEei");
            dynamic context = null;
            Boolean cont = true;
            string mesaj = "";
            while (cont)
            {

                Console.WriteLine("Say something to Watson:");
                mesaj = Console.ReadLine();
                var res = helper.GetResponse(mesaj, context).GetAwaiter().GetResult();
                context = helper.JsonProcesser(res);
                using (SpeechSynthesizer synth = new SpeechSynthesizer())
                {
                    synth.SetOutputToDefaultAudioDevice();

                    synth.Speak(JsonConvert.DeserializeObject(res).output.text[0].ToString());

                }
                Console.WriteLine(context);
                Console.WriteLine(JsonConvert.DeserializeObject(res).output.text[0].ToString());
                Console.WriteLine("Do you want to continue the conversation? Y/N");
                 String n = Console.ReadLine();
                if (n == "N")
                {
                    cont = false;
                }
            }
        }

    }

}