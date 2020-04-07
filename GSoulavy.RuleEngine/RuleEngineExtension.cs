using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace GSoulavy.RuleEngine
{
    public static class RuleEngineExtension
    {
        public static bool IsSupport(this JValue p)
        {
            return p.Type.IsSupport();
        }
        public static bool IsSupport(this JProperty p)
        {
            return p.Type.IsSupport();
        }
        public static bool IsSupport(this JObject p)
        {
            return p.Type.IsSupport();
        }
        public static bool IsSupport(this JToken p)
        {
            return p.Type.IsSupport();
        }
        public static bool IsSupport(this JTokenType p)
        {
            return p == JTokenType.String
                                        || p== JTokenType.Date
                                        || p== JTokenType.Boolean
                                        ||  p== JTokenType.Bytes
                                        || p== JTokenType.Float
                                        || p  == JTokenType.Guid
                                        || p == JTokenType.TimeSpan
                                        || p  == JTokenType.Uri
                                        || p  == JTokenType.Integer;
        }


        public static Type JTokenTypeToType(this JTokenType jTokenType)
        {
            Type t;
            switch (jTokenType)
            {
                case JTokenType.None:
                    t = typeof(string);
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
