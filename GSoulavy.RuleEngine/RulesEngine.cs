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
                var dc = from p in jObject.Properties() select new DynamicProperty(p.Name, JTokenTypeToType(p.Value.Type));
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
         Type JTokenTypeToType(JTokenType jTokenType)
        {
            Type t;
            switch (jTokenType)
            {
                case JTokenType.None:
                    t =typeof(string);
                    break;
                case JTokenType.Object:
                    t = typeof(string);
                    break;
                case JTokenType.Array:
                    t = typeof(object);
                    break;
                case JTokenType.Constructor:
                    t = typeof(string);
                    break;
                case JTokenType.Property:
                    t = typeof(string);
                    break;
                case JTokenType.Comment:
                    t = typeof(string);
                    break;
                case JTokenType.Integer:
                    t = typeof(int);
                    break;
                case JTokenType.Float:
                    t = typeof(float);
                    break;
                case JTokenType.String:
                    t = typeof(string);
                    break;
                case JTokenType.Boolean:
                    t = typeof(bool);
                    break;
                case JTokenType.Null:
                    t = typeof(string);
                    break;
                case JTokenType.Undefined:
                    t = typeof(string);
                    break;
                case JTokenType.Date:
                    t = typeof(DateTime);
                    break;
                case JTokenType.Raw:
                    t = typeof(byte[]);
                    break;
                case JTokenType.Bytes:
                    t = typeof(byte[]);
                    break;
                case JTokenType.Guid:
                    t = typeof(Guid);
                    break;
                case JTokenType.Uri:
                    t = typeof(Uri);
                    break;
                case JTokenType.TimeSpan:
                    t = typeof(TimeSpan);
                    break;
                default:
                    t = typeof(string);
                    break;
            }
            return t;
        }
    }
}