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
    Money     money = Money.UnitedStatesDollar(cents: 1000UL);
    object notMoney = new();

    // Act
    Action action = () => money.Equals(notMoney);

    // Arrange
    Assert.ThrowsException<InvalidOperationException>(action);
  }

  [TestMethod]
  public void Equals_ObjectWithPackedSameMoney_TrueReturned()
  {
    // Arrange
    Money  money1 = Money.UnitedStatesDollar(cents: 1000UL);
    object money2 = Money.UnitedStatesDollar(cents: 1000UL);

    // Act
    bool result = money1.Equals(money2);

    // Arrange
    Assert.IsTrue(result);
  }

  [TestMethod]
  public void Equals_ObjectWithPackedDifferentMoney_TrueReturned()
  {
    // Arrange
    Money  money1 = Money.UnitedStatesDollar(cents: 1000UL);
    object money2 = Money.UnitedStatesDollar(cents: 2000UL);

    // Act
    bool result = money1.Equals(money2);

    // Arrange
    Assert.IsFalse(result);
  }

  [TestMethod]
  public void Equals_UnitedStatesDollarsAndObjectWithPackedEuro_ExceptionThrown()
  {
    // Arrange
    Money  money1 = Money.UnitedStatesDollar(cents: 1000UL);
    object money2 = Money.Euro(cents: 2000UL);

    // Act
    Action action = () => money1.Equals(money2);

    // Arrange
    Assert.ThrowsException<InvalidOperationException>(action);
  }

  [TestMethod]
  public void Equals_SameMoney_TrueReturned()
  {
    // Arrange
    Money money1 = Money.UnitedStatesDollar(cents: 1000UL);
    Money money2 = Money.UnitedStatesDollar(cents: 1000UL);

    // Act
    bool result = money1.Equals(money2);

    // Arrange
    Assert.IsTrue(result);
  }

  [TestMethod]
  public void Equals_DifferentMoney_TrueReturned()
  {
    // Arrange
    Money money1 = Money.UnitedStatesDollar(cents: 1000UL);
    Money money2 = Money.UnitedStatesDollar(cents: 2000UL);

    // Act
    bool result = money1.Equals(money2);

    // Arrange
    Assert.IsFalse(result);
  }

  [TestMethod]
  public void Equals_UnitedStatesDollarsAndEuro_ExceptionThrown()
  {
    // Arrange
    Money money1 = Money.UnitedStatesDollar(cents: 1000UL);
    Money money2 = Money.Euro(cents: 2000UL);

    // Act
    Action action = () => money1.Equals(money2);

    // Arrange
    Assert.ThrowsException<InvalidOperationException>(action);
  }

  [TestMethod]
  public void CompareTo_SameMoney_0Returned()
  {
    // Arrange
    Money money1 = Money.UnitedStatesDollar(cents: 1000UL);
    Money money2 = Money.UnitedStatesDollar(cents: 1000UL);

    // Act
    int result = money1.CompareTo(money2);

    // Arrange
    Assert.AreEqual(0, result);
  }

  [TestMethod]
  public void CompareTo_GreaterMoneyAndLesserMoney_1Returned()
  {
    // Arrange
    Money money1 = Money.UnitedStatesDollar(cents: 2000UL);
    Money money2 = Money.UnitedStatesDollar(cents: 1000UL);

    // Act
    int result = money1.CompareTo(money2);

    // Arrange
    Assert.AreEqual(1, result);
  }

  [TestMethod]
  public void CompareTo_LesserMoneyAndGreaterMoney_Minus1Returned()
  {
    // Arrange
    Money money1 = Money.UnitedStatesDollar(cents: 1000UL);
    Money money2 = Money.UnitedStatesDollar(cents: 2000UL);

    // Act
    int result = money1.CompareTo(money2);

    // Arrange
    Assert.AreEqual(-1, result);
  }

  [TestMethod]
  public void CompareTo_UnitedStatesDollarsAndEuro_ExceptionThrown()
  {
    // Arrange
    Money money1 = Money.UnitedStatesDollar(cents: 1000UL);
    Money money2 = Money.Euro(cents: 2000UL);

    // Act
    Action action = () => money1.CompareTo(money2);

    // Arrange
    Assert.ThrowsException<InvalidOperationException>(action);
  }

  [TestMethod]
  public void OperatorLess_DifferentCurrencies_ExceptionThrown()
  {
    // Arrange
    Money money1 = Money.UnitedStatesDollar(cents: 1000UL);
    Money money2 = Money.Euro(cents: 2000UL);

    // Act
    Func<object> action = () => money1 < money2;

    // Arrange
    Assert.ThrowsException<InvalidOperationException>(action);
  }
}
