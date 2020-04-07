using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GSoulavy.RuleEngine
{
    public class RuleFlowEngine
    {
        private readonly Rule root;
        private readonly RulesEngine engine = new RulesEngine();
        public RuleFlowEngine(Rule rule)
        {
            root = rule;
            engine.AddRule(rule);
        }
  
        public RuleResult Execute(string json)
        {
            return Execute(root, json);
        }
        public RuleResult Execute(Rule _rule, string json)
        {
            var rr = new RuleResult();
            var jo = JObject.Parse(json);
            rr.Result = engine.Validate(jo, _rule.Expression);
            if (rr.Result)
            {
                rr.Output = SelectJson(jo, _rule.ThenSelect);
                if (_rule.Then != null && !string.IsNullOrEmpty(rr.Output))
                {
                    var rrt = Execute(_rule.Then, rr.Output);
                    rr.Message.AddRange(rrt.Message);
                    rr.Output = rrt.Output;
                    rr.Result = rrt.Result;
                }
            }
            else
            {
                rr.Message.Add(_rule.ErrorMessage);
                rr.Output = SelectJson(jo, _rule.ElseSelect);
                var rrt = Execute(_rule.Then, rr.Output);
                rr.Message.AddRange(rrt.Message);
                rr.Output = rrt.Output;
                rr.Result = rrt.Result;
            }
            return rr;
        }

        private string SelectJson(JObject jo, string selectparam)
        {
            JToken token = null;
            if (!string.IsNullOrEmpty(selectparam))
            {
                var sep = selectparam.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                if (sep.Length == 1)
                {
                    var ary = sep.First().Split(new string[] { " as ", " As ", " AS " }, StringSplitOptions.RemoveEmptyEntries);
                    var jt = jo.SelectToken(ary[0]);
                    if (ary.Length >= 2)
                    {
                        JObject jObject = new JObject();
                        jObject.Add(ary[1], jt);
                    }
                    else if (jt.Type== JTokenType.Object || jt.Type== JTokenType.Array || jt.Type== JTokenType.Property )
                    {
                        token = jt;
                    }
                    else
                    {
                        token = jt;
                    }
                }
                else
                {
                    JObject jObject = new JObject();
                    sep.ToList().ForEach(s =>
                    {
                        var ary = s.Split(new string[] { " as ", " As ", " AS " }, StringSplitOptions.RemoveEmptyEntries);
                        var jt = jo.SelectToken(ary[0]);
                        if (ary.Length == 2)
                        {
                            if (jt.IsSupport())
                            {
                                jObject.Add( ary[1], jt);
                            }
                            else
                            {
                                jObject.Add(new JProperty(ary[1], jt.Children()));
                            }
                        }
                        else
                        {
                            if (jt.IsSupport())
                            {
                                jObject.AddFirst(jt);
                            }
                            else if (jt.HasValues)
                            {
                                jObject.Add(jt.Children());
                            }
                        }
                    });
                    token = jObject;
                }
            }
            return token.ToString();
        }
    }
}
