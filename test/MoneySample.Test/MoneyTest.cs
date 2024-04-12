// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace MoneySample.Test;

[TestClass]
public sealed class MoneyTest
{
  [TestMethod]
  public void Equals_NotMoney_ExceptionThrown()
  {
    // Arrange
    Money     money = Money.USD(cents: 1000UL);
    object notMoney = new();

    // Act
    Action action = () => money.Equals(notMoney);

    // Assert
    Assert.ThrowsException<InvalidOperationException>(action);
  }

  [TestMethod]
  public void Equals_ObjectWithPackedSameMoney_TrueReturned()
  {
    // Arrange
    Money  money1 = Money.USD(cents: 1000UL);
    object money2 = Money.USD(cents: 1000UL);

    // Act
    bool result = money1.Equals(money2);

    // Assert
    Assert.IsTrue(result);
  }

  [TestMethod]
  public void Equals_ObjectWithPackedDifferentMoney_FalseReturned()
  {
    // Arrange
    Money  money1 = Money.USD(cents: 1000UL);
    object money2 = Money.USD(cents: 2000UL);

    // Act
    bool result = money1.Equals(money2);

    // Assert
    Assert.IsFalse(result);
  }

  [TestMethod]
  public void Equals_UnitedStatesDollarsAndObjectWithPackedEuro_ExceptionThrown()
  {
    // Arrange
    Money  money1 = Money.USD(cents: 1000UL);
    object money2 = Money.EUR(cents: 2000UL);

    // Act
    Action action = () => money1.Equals(money2);

    // Assert
    Assert.ThrowsException<InvalidOperationException>(action);
  }

  [TestMethod]
  public void Equals_SameMoney_TrueReturned()
  {
    // Arrange
    Money money1 = Money.USD(cents: 1000UL);
    Money money2 = Money.USD(cents: 1000UL);

    // Act
    bool result = money1.Equals(money2);

    // Assert
    Assert.IsTrue(result);
  }

  [TestMethod]
  public void Equals_DifferentMoney_FalseReturned()
  {
    // Arrange
    Money money1 = Money.USD(cents: 1000UL);
    Money money2 = Money.USD(cents: 2000UL);

    // Act
    bool result = money1.Equals(money2);

    // Assert
    Assert.IsFalse(result);
  }

  [TestMethod]
  public void Equals_UnitedStatesDollarsAndEuro_ExceptionThrown()
  {
    // Arrange
    Money money1 = Money.USD(cents: 1000UL);
    Money money2 = Money.EUR(cents: 2000UL);

    // Act
    Action action = () => money1.Equals(money2);

    // Assert
    Assert.ThrowsException<InvalidOperationException>(action);
  }

  [TestMethod]
  public void CompareTo_SameMoney_0Returned()
  {
    // Arrange
    Money money1 = Money.USD(cents: 1000UL);
    Money money2 = Money.USD(cents: 1000UL);

    // Act
    int result = money1.CompareTo(money2);

    // Assert
    Assert.AreEqual(0, result);
  }

  [TestMethod]
  public void CompareTo_GreaterMoneyAndLesserMoney_1Returned()
  {
    // Arrange
    Money money1 = Money.USD(cents: 2000UL);
    Money money2 = Money.USD(cents: 1000UL);

    // Act
    int result = money1.CompareTo(money2);

    // Assert
    Assert.AreEqual(1, result);
  }

  [TestMethod]
  public void CompareTo_LesserMoneyAndGreaterMoney_Minus1Returned()
  {
    // Arrange
    Money money1 = Money.USD(cents: 1000UL);
    Money money2 = Money.USD(cents: 2000UL);

    // Act
    int result = money1.CompareTo(money2);

    // Assert
    Assert.AreEqual(-1, result);
  }

  [TestMethod]
  public void CompareTo_UnitedStatesDollarsAndEuro_ExceptionThrown()
  {
    // Arrange
    Money money1 = Money.USD(cents: 1000UL);
    Money money2 = Money.EUR(cents: 2000UL);

    // Act
    Action action = () => money1.CompareTo(money2);

    // Assert
    Assert.ThrowsException<InvalidOperationException>(action);
  }

  [TestMethod]
  public void OperatorLesser_DifferentCurrencies_ExceptionThrown()
  {
    // Arrange
    Money money1 = Money.USD(cents: 1000UL);
    Money money2 = Money.EUR(cents: 2000UL);

    // Act
    Func<object> action = () => money1 < money2;

    // Assert
    Assert.ThrowsException<InvalidOperationException>(action);
  }

  [TestMethod]
  public void OperatorLesser_LesserAndGreater_TrueReturned()
  {
    // Arrange
    Money money1 = Money.USD(cents: 1000UL);
    Money money2 = Money.USD(cents: 2000UL);

    // Act
    bool result = money1 < money2;

    // Assert
    Assert.IsTrue(result);
  }

  [TestMethod]
  public void OperatorLesser_GreaterAndLesser_FalseReturned()
  {
    // Arrange
    Money money1 = Money.USD(cents: 2000UL);
    Money money2 = Money.USD(cents: 1000UL);

    // Act
    bool result = money1 < money2;

    // Assert
    Assert.IsFalse(result);
  }

  [TestMethod]
  public void OperatorLesser_SameAmount_FalseReturned()
  {
    // Arrange
    Money money1 = Money.USD(cents: 1000UL);
    Money money2 = Money.USD(cents: 1000UL);

    // Act
    bool result = money1 < money2;

    // Assert
    Assert.IsFalse(result);
  }

  [TestMethod]
  public void OperatorGreat_DifferentCurrencies_ExceptionThrown()
  {
    // Arrange
    Money money1 = Money.USD(cents: 1000UL);
    Money money2 = Money.EUR(cents: 2000UL);

    // Act
    Func<object> action = () => money1 > money2;

    // Assert
    Assert.ThrowsException<InvalidOperationException>(action);
  }

  [TestMethod]
  public void OperatorGreat_LesserAndGreater_FalseReturned()
  {
    // Arrange
    Money money1 = Money.USD(cents: 1000UL);
    Money money2 = Money.USD(cents: 2000UL);

    // Act
    bool result = money1 > money2;

    // Assert
    Assert.IsFalse(result);
  }

  [TestMethod]
  public void OperatorGreat_GreaterAndLesser_TrueReturned()
  {
    // Arrange
    Money money1 = Money.USD(cents: 2000UL);
    Money money2 = Money.USD(cents: 1000UL);

    // Act
    bool result = money1 > money2;

    // Assert
    Assert.IsTrue(result);
  }

  [TestMethod]
  public void OperatorGreat_SameAmount_FalseReturned()
  {
    // Arrange
    Money money1 = Money.USD(cents: 1000UL);
    Money money2 = Money.USD(cents: 1000UL);

    // Act
    bool result = money1 > money2;

    // Assert
    Assert.IsFalse(result);
  }

  [TestMethod]
  public void OperatorLesserOrEqual_DifferentCurrencies_ExceptionThrown()
  {
    // Arrange
    Money money1 = Money.USD(cents: 1000UL);
    Money money2 = Money.EUR(cents: 2000UL);

    // Act
    Func<object> action = () => money1 <= money2;

    // Assert
    Assert.ThrowsException<InvalidOperationException>(action);
  }

  [TestMethod]
  public void OperatorLesserOrEqual_LesserAndGreater_TrueReturned()
  {
    // Arrange
    Money money1 = Money.USD(cents: 1000UL);
    Money money2 = Money.USD(cents: 2000UL);

    // Act
    bool result = money1 <= money2;

    // Assert
    Assert.IsTrue(result);
  }

  [TestMethod]
  public void OperatorLesserOrEqual_GreaterAndLesser_FalseReturned()
  {
    // Arrange
    Money money1 = Money.USD(cents: 2000UL);
    Money money2 = Money.USD(cents: 1000UL);

    // Act
    bool result = money1 <= money2;

    // Assert
    Assert.IsFalse(result);
  }

  [TestMethod]
  public void OperatorLesserOrEqual_SameAmount_TrueReturned()
  {
    // Arrange
    Money money1 = Money.USD(cents: 1000UL);
    Money money2 = Money.USD(cents: 1000UL);

    // Act
    bool result = money1 <= money2;

    // Assert
    Assert.IsTrue(result);
  }

  [TestMethod]
  public void OperatorGreaterOrEqual_DifferentCurrencies_ExceptionThrown()
  {
    // Arrange
    Money money1 = Money.USD(cents: 1000UL);
    Money money2 = Money.EUR(cents: 2000UL);

    // Act
    Func<object> action = () => money1 >= money2;

    // Assert
    Assert.ThrowsException<InvalidOperationException>(action);
  }

  [TestMethod]
  public void OperatorGreatOrEqual_LesserAndGreater_FalseReturned()
  {
    // Arrange
    Money money1 = Money.USD(cents: 1000UL);
    Money money2 = Money.USD(cents: 2000UL);

    // Act
    bool result = money1 >= money2;

    // Assert
    Assert.IsFalse(result);
  }

  [TestMethod]
  public void OperatorGreatOrEqual_GreaterAndLesser_TrueReturned()
  {
    // Arrange
    Money money1 = Money.USD(cents: 2000UL);
    Money money2 = Money.USD(cents: 1000UL);

    // Act
    bool result = money1 >= money2;

    // Assert
    Assert.IsTrue(result);
  }

  [TestMethod]
  public void OperatorGreatOrEqual_SameAmount_TrueReturned()
  {
    // Arrange
    Money money1 = Money.USD(cents: 1000UL);
    Money money2 = Money.USD(cents: 1000UL);

    // Act
    bool result = money1 >= money2;

    // Assert
    Assert.IsTrue(result);
  }

  [TestMethod]
  public void OperatorEqual_SameAmount_TrueReturned()
  {
    // Arrange
    Money money1 = Money.USD(cents: 1000UL);
    Money money2 = Money.USD(cents: 1000UL);

    // Act
    bool result = money1 == money2;

    // Assert
    Assert.IsTrue(result);
  }

  [TestMethod]
  public void OperatorEqual_DifferentAmount_FalseReturned()
  {
    // Arrange
    Money money1 = Money.USD(cents: 1000UL);
    Money money2 = Money.USD(cents: 2000UL);

    // Act
    bool result = money1 == money2;

    // Assert
    Assert.IsFalse(result);
  }

  [TestMethod]
  public void OperatorEqual_DifferentCurrencies_ExceptionThrown()
  {
    // Arrange
    Money money1 = Money.USD(cents: 1000UL);
    Money money2 = Money.EUR(cents: 2000UL);

    // Act
    Func<object> action = () => money1 == money2;

    // Assert
    Assert.ThrowsException<InvalidOperationException>(action);
  }

  [TestMethod]
  public void OperatorNotEqual_SameAmount_FalseReturned()
  {
    // Arrange
    Money money1 = Money.USD(cents: 1000UL);
    Money money2 = Money.USD(cents: 1000UL);

    // Act
    bool result = money1 != money2;

    // Assert
    Assert.IsFalse(result);
  }

  [TestMethod]
  public void OperatorNotEqual_DifferentAmount_TrueReturned()
  {
    // Arrange
    Money money1 = Money.USD(cents: 1000UL);
    Money money2 = Money.USD(cents: 2000UL);

    // Act
    bool result = money1 != money2;

    // Assert
    Assert.IsTrue(result);
  }

  [TestMethod]
  public void OperatorNotEqual_DifferentCurrencies_ExceptionThrown()
  {
    // Arrange
    Money money1 = Money.USD(cents: 1000UL);
    Money money2 = Money.EUR(cents: 2000UL);

    // Act
    Func<object> action = () => money1 != money2;

    // Assert
    Assert.ThrowsException<InvalidOperationException>(action);
  }

  [TestMethod]
  public void ToString_UnitedStatesDollars_CorrectStringReturned()
  {
    // Arrange
    Money money = Money.USD(cents: 1234UL);

    // Act
    string actual = money.ToString();

    // Assert
    Assert.AreEqual("12.34 USD", actual);
  }

  [TestMethod]
  public void ToString_Euros_CorrectStringReturned()
  {
    // Arrange
    Money money = Money.EUR(cents: 1234UL);

    // Act
    string actual = money.ToString();

    // Assert
    Assert.AreEqual("12.34 EUR", actual);
  }

  [TestMethod]
  public void ToString_BelarusianRoubles_CorrectStringReturned()
  {
    // Arrange
    Money money = Money.BYN(kopecks: 1234UL);

    // Act
    string actual = money.ToString();

    // Assert
    Assert.AreEqual("12.34 BYN", actual);
  }

  [TestMethod]
  public void ToString_RussianRoubles_CorrectStringReturned()
  {
    // Arrange
    Money money = Money.RUB(kopecks: 1234UL);

    // Act
    string actual = money.ToString();

    // Assert
    Assert.AreEqual("12.34 RUB", actual);
  }

  [TestMethod]
  public void OperatorPlus_DifferentCurrencies_ExceptionThrown()
  {
    // Arrange
    Money money1 = Money.USD(cents: 1000UL);
    Money money2 = Money.EUR(cents: 2000UL);

    // Act
    Func<object> action = () => money1 + money2;

    // Assert
    Assert.ThrowsException<InvalidOperationException>(action);
  }

  [TestMethod]
  public void OperatorPlus_SameCurrencies_SumReturned()
  {
    // Arrange
    Money money1 = Money.USD(cents: 1000UL);
    Money money2 = Money.USD(cents: 2000UL);

    // Act
    Money actual = money1 + money2;

    // Assert
    Money expected = Money.USD(cents: 1000UL + 2000UL);
    Assert.AreEqual(expected, actual);
  }

  [TestMethod]
  public void OperatorMultiply_Money_ProductReturned()
  {
    // Arrange
    Money    money = Money.USD(cents: 1000UL);
    decimal factor = 0.95M;

    // Act
    Money actual = money * factor;

    // Assert
    Money expected = Money.USD(cents: (ulong)(1000UL * 0.95M));
    Assert.AreEqual(expected, actual);
  }
}
