using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watson_Assistant_trial
{
    public class MessageDto
    {
        public InputDto input { get; set; }
        public dynamic context { get; set; }
        public bool alternate_intents { get; set; }
    }
}
