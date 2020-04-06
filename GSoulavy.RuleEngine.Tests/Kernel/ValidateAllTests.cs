﻿using System.Collections.Generic;
using GSoulavy.RuleEngine.Tests.Models;
using Xunit;

namespace GSoulavy.RuleEngine.Tests.Kernel
{
   public class ValidateAllTests
   {
      [Fact(DisplayName = "ValidateAll[with param]: true")]
      public void ValidateAllW_True()
      {
         // Arrange
         var rules = new List<Rule>
         {
            new Rule {RuleName = "1", Expression = "(f.Age > 3 && f.Income < 50000) || f.NumberOfChildren > 2"},
            new Rule {RuleName = "2", Expression = "(f.Age > 3 && f.Income > 100000) || f.NumberOfChildren > 5" }
         };

         var p = new Person {Age = 37, Income = 45000, NumberOfChildren = 3};
         var ruleEngine = new RulesEngine();
         ruleEngine.AddRules(rules);
         // Act
         var result = ruleEngine.ValidateAll(p, "1");
         // Assert
         Assert.True(result);
      }

      [Fact(DisplayName = "ValidateAll[without param]: true")]
      public void ValidateAllWp_True()
      {
         // Arrange
         var rule = new Rule {RuleName = "1", Expression = "(f.Age > 3 && f.Income < 50000) || f.NumberOfChildren > 2"};
         var p = new Person {Age = 37, Income = 45000, NumberOfChildren = 3};
         var ruleEngine = new RulesEngine();
         ruleEngine.AddRule(rule);
         // Act
         var result = ruleEngine.ValidateAll(p);
         // Assert
         Assert.True(result);
      }

      [Fact(DisplayName = "ValidateAll[with param]: false")]
      public void ValidateW_False()
      {
         // Arrange
         var rules = new List<Rule>
         {
            new Rule {RuleName = "1", Expression = "(f.Age > 3 && f.Income < 50000) || f.NumberOfChildren > 2"},
            new Rule {RuleName = "2", Expression = "(f.Age > 3 && f.Income > 100000) || f.NumberOfChildren > 5"}
         };

         var p = new Person {Age = 37, Income = 45000, NumberOfChildren = 3};
         var ruleEngine = new RulesEngine();
         ruleEngine.AddRules(rules);

         // Act
         var result = ruleEngine.ValidateAll(p, "2");
         // Assert
         Assert.False(result);
      }

      [Fact(DisplayName = "ValidateAll[without param]: false")]
      public void ValidateWp_False()
      {
         // Arrange
         var rules = new List<Rule>
         {
            new Rule {RuleName = "1", Expression = "(f.Age > 3 && f.Income < 50000) || f.NumberOfChildren > 2"},
            new Rule {RuleName = "2", Expression = "(f.Age > 3 && f.Income > 100000) || f.NumberOfChildren > 5"}
         };
         var p = new Person {Age = 37, Income = 45000, NumberOfChildren = 3};
         var ruleEngine = new RulesEngine();
         ruleEngine.AddRules(rules);
         // Act
         var result = ruleEngine.ValidateAll(p);
         // Assert
         Assert.False(result);
      }
   }
}