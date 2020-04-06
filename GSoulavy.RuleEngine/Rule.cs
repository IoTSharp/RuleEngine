using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GSoulavy.RuleEngine
{
    public enum ErrorType
    {
        Error,
        Warning,
        Info

    }
    public enum RuleExpressionType
    {
        LambdaExpression
    }
    public class Rule
    {
        public string RuleName { get; set; }
        public string Expression { get; set; }
        public string ErrorMessage { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public ErrorType ErrorType { get; set; } = ErrorType.Error;
        [JsonConverter(typeof(StringEnumConverter))]
        public RuleExpressionType RuleExpressionType { get; set; }
        public Rule Then { get; set; }
        public Rule Else { get; set; }

        public string ThenSelect { get; set; }
        public string ElseSelect { get; set; }
    }
}