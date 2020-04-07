# IoTSharp.RuleEngine


# About  IoTSharp.RuleEngine 
 IoTSharp.RuleEngine is a https://github.com/gsoulavy/RuleEngine fork, I'm  will  implement a rule engine for IoTSharp based on https://github.com/gsoulavy/RuleEngine, so, thanks to Gab Soulavy for the great work.
 
 

### Purpose

This simple rule engine is a .NET Standard library 2.0, which uses Microsoft's DLR DynamicExpressionParser in the background. The goal was to make a simple engine which is easy to use and compatible with many projects.

### Use

#### Instantiating the kernel

The IKernel interface is implemented with Kerner in order to support Inverson Of Control.

```cs
IKernel ruleEngine = new Kernel();
```

##### Role of the IRule
The engine is designed to use any object as a rule which implements IRule interface in order to make it easy to use with an ORM.

```cs
public interface IRule
{
    string Key { get; set; }
    string Expression { get; set; }
}
```
```cs
//...
void AddRule(IRule rule);
//...
```


##### Simple Validation
String expressions can be simply against the object passed to the engine.<br/>
Creating a fact:
```cs
var fact = new Person {Age = 37, Income = 45000, NumberOfChildren = 3};
```

Validating the fact:
```cs
var result = ruleEngine.Validate(fact, "(f.Age > 3 && f.Income > 100000) || f.NumberOfChildren > 5");
// result = false
```

##### Validate All
More than one expreession can be added to the engine
```cs
var rules = new List<Rule>
{
    new Rule {Key = "1", Expression = "(f.Age > 3 && f.Income < 50000) || f.NumberOfChildren > 2"},
    new Rule {Key = "2", Expression = "(f.Age > 3 && f.Income > 100000) || f.NumberOfChildren > 5"}
};

ruleEngine.AddRules(rules);

// Validate against all rules when no key passed
var result = ruleEngine.ValidateAll(f);
// result = false

// Only validate against rules with the matching key
var result = ruleEngine.ValidateAll(f, "1");
// result = true
```

##### Validate Any
The calls are the same as the case of validate all, however it returns true if any case is true.
```cs
var rules = new List<Rule>
{
    new Rule {Key = "1", Expression = "(f.Age > 3 && f.Income < 50000) || f.NumberOfChildren > 2"},
    new Rule {Key = "2", Expression = "(f.Age > 3 && f.Income > 100000) || f.NumberOfChildren > 5"}
};

ruleEngine.AddRules(rules);

// Validate against all rules when no key passed
var result = ruleEngine.ValidateAny(f);
// result = true

// Only validate against rules with the matching key
var result = ruleEngine.ValidateAny(f, "1");
// result = true
```

##### Workflow Rules Engine

下面的示例实现了 在输入的数据中通过规则链MsgT_Exit_Waste 中的 STATION_NAME  不为空并且不以“某某某收费站”开头的数据输出， 这是个简单的例子 只有 Then , 没有Else  

```
         Rule rule = new Rule()
            {
                RuleName = "data",
                ErrorType = ErrorType.Error,
                ErrorMessage = "未能找到数据",
                Expression = "f.MsgT_Exit_Waste!=null",
                ThenSelect = "MsgT_Exit_Waste",
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
            var result = engine.Execute(Properties.Resources.MsgT_Exit_Waste);
            Assert.True(result.Result);
            Assert.Equal("新疆米东北主线站", result.Output);
```
