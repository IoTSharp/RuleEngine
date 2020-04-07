using System;
using System.Collections.Generic;
using System.Text;

namespace IoTSharp.RuleEngine
{
    public class RuleResult
    {
        public bool Result { get; internal set; }
        public List<string> Message { get; internal set; } = new List<string>();
        public string Output { get; internal set; }
    }
}
