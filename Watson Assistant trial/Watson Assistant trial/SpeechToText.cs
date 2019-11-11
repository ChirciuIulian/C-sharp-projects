using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Recognition;

namespace Watson_Assistant_trial
{
    public class SpeechToText
    {
        public static string Speech_text()
        {
            SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
            recognizer.SetInputToDefaultAudioDevice();
            recognizer.LoadGrammar(new DictationGrammar());
            recognizer.RecognizeAsync(RecognizeMode.Multiple);
            recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(Speech_helper);

            return recognizer.ToString() ;

        }

        public static void Speech_helper(object sender, SpeechRecognizedEventArgs e)
        {
            e.Result.Text.ToString();
        }

    }
}
