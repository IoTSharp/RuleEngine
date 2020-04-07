using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace GSoulavy.RuleEngine
{
   public class RulesEngine
   {
      private readonly List<(string Key, string Value)> _rules;

      public RulesEngine()
      {
         _rules = new List<(string Key, string Value)>();
      }

      public void AddRule(Rule rule)
      {
         _rules.Add((rule.RuleName, rule.Expression));
      }

      public void AddRules(IEnumerable<Rule> rules)
      {
         _rules.AddRange(rules.Select(r => (r.RuleName, r.Expression)));
      }

      public void RemoveRule(Rule rule)
      {
         _rules.Remove((rule.RuleName, rule.Expression));
      }

      public void RemoveRules(IEnumerable<Rule> rules)
      {
         foreach (var rule in rules)
            _rules.Remove((rule.RuleName, rule.Expression));
      }

      public bool Validate<T>(T fact, string rule)
      {
         return Evaluate<T, bool>(fact, rule);
      }

      public bool ValidateAll<T>(T fact, string key = null)
      {
         return key != null
            ? _rules.Where(r => r.Key.Equals(key)).Select(r => r.Value).All(rule => Validate(fact, rule))
            : _rules.Select(r => r.Value).All(rule => Validate(fact, rule));
      }

      public bool ValidateAny<T>(T fact, string key = null)
      {
         return key != null
            ? _rules.Where(r => r.Key.Equals(key)).Select(r => r.Value).Any(rule => Validate(fact, rule))
            : _rules.Select(r => r.Value).Any(rule => Validate(fact, rule));
      }

      public TR Evaluate<T, TR>(T fact, string rule)
      {
            object obj = null;
            ParameterExpression parameter = null;
            if (typeof(T) == typeof(JObject))
            {
                JObject jObject = fact as JObject;
                var dc = from p in jObject.Properties()
                         where   p.Value.IsSupport()
                         select new DynamicProperty(p.Name, p.Value.Type.JTokenTypeToType());
                var type = DynamicClassFactory.CreateType(dc.ToArray());
                parameter = Expression.Parameter(type, "f");
                obj = jObject.ToObject(type);
            }
            else
            {
                parameter = Expression.Parameter(typeof(T), "f");
                obj = fact;
            }
            var lambdaExpression = DynamicExpressionParser.ParseLambda(new[] { parameter }, null, rule);
            return (TR)lambdaExpression.Compile().DynamicInvoke(obj);
        }
    }
}