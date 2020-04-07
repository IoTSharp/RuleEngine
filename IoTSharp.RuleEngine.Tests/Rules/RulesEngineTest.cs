using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IoTSharp.RuleEngine.Tests.RuleFlow
{
    public class RulesEngineTest
    {

        [Fact(DisplayName = "Execute_ByClass: 新疆米东北主线站")]
        void Execute_ByClass()
        {
            Rule rule = new Rule()
            {
                RuleName = "data",
                ErrorType = ErrorType.Error,
                ErrorMessage = "未能找到数据",
                Expression = "f.MsgT_Exit_Waste!=null",
                ThenSelect = "MsgT_Exit_Waste",
                 RuleExpressionType= RuleExpressionType.LambdaExpression,
                Then = new Rule()
                {
                    Expression = "f.STATION_NAME!=null && !f.STATION_NAME.StartsWith(\"某某收费站\")",
                    ThenSelect = "STATION_NAME",
                    ErrorMessage = "收费站配置信息错误",
                    RuleName = "moumou",
                    RuleExpressionType = RuleExpressionType.LambdaExpression
                }
            };
            var  engine = new RulesEngine(rule);
           var result= engine.Execute(Properties.Resources.MsgT_Exit_Waste)
                .OnSuccess(f => Console.WriteLine(f.Output))
                .OnFailed(f => Console.WriteLine(f.Message.ToArray()));
            Assert.True(result.Result);
            Assert.Equal("新疆米东北主线站", result.Output);

        }
    }
}
