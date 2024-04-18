// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace MoneyType.Test;

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
    Assert.AreEqual("USD000000000000000012.34", actual);
  }

  [TestMethod]
  public void ToString_Euros_CorrectStringReturned()
  {
    // Arrange
    Money money = Money.EUR(cents: 1234UL);

    // Act
    string actual = money.ToString();

    // Assert
    Assert.AreEqual("EUR000000000000000012.34", actual);
  }

  [TestMethod]
  public void ToString_BelarusianRoubles_CorrectStringReturned()
  {
    // Arrange
    Money money = Money.BYN(kopecks: 1234UL);

    // Act
    string actual = money.ToString();

    // Assert
    Assert.AreEqual("BYN000000000000000012.34", actual);
  }

  [TestMethod]
  public void ToString_RussianRoubles_CorrectStringReturned()
  {
    // Arrange
    Money money = Money.RUB(kopecks: 1234UL);

    // Act
    string actual = money.ToString();

    // Assert
    Assert.AreEqual("RUB000000000000000012.34", actual);
  }

  [TestMethod]
  public void ToString_MaxValue_CorrectStringReturned()
  {
    // Arrange
    Money money = Money.USD(cents: ulong.MaxValue);

    // Act
    string actual = money.ToString();

    // Assert
    Assert.AreEqual("USD184467440737095516.15", actual);
  }

  [TestMethod]
  public void ToString_OneDigitAfterPoint_CorrectStringReturned()
  {
    // Arrange
    Money money = Money.USD(cents: 1203UL);

    // Act
    string actual = money.ToString();

    // Assert
    Assert.AreEqual("USD000000000000000012.03", actual);
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

  [TestMethod]
  public void Parce_TooLongString_ExceptionThrown()
  {
    // Arrange
    string value = "0000000000000000000000000";

    // Act
    Func<object> act = () => Money.Parce(value);

    // Assert
    Assert.ThrowsException<InvalidCastException>(act);
  }

  [TestMethod]
  public void Parce_TooShortString_ExceptionThrown()
  {
    // Arrange
    string value = "00000000000000000000000";

    // Act
    Func<object> act = () => Money.Parce(value);

    // Assert
    Assert.ThrowsException<InvalidCastException>(act);
  }

  [TestMethod]
  public void Parce_EmptyString_ExceptionThrown()
  {
    // Arrange
    string value = "";

    // Act
    Func<object> act = () => Money.Parce(value);

    // Assert
    Assert.ThrowsException<ArgumentException>(act);
  }

  [TestMethod]
  public void Parce_NullString_ExceptionThrown()
  {
    // Arrange
    string value = null!;

    // Act
    Func<object> act = () => Money.Parce(value);

    // Assert
    Assert.ThrowsException<ArgumentNullException>(act);
  }

  [TestMethod]
  public void Parce_USDString_USDReturned()
  {
    // Arrange
    string value = "USD000000000000000012.34";

    // Act
    Money actual = Money.Parce(value);

    // Assert
    Money expected = Money.USD(cents: 1234UL);
    Assert.AreEqual(expected, actual);
  }

  [TestMethod]
  public void Parce_EURString_EURReturned()
  {
    // Arrange
    string value = "EUR000000000000000012.34";

    // Act
    Money actual = Money.Parce(value);

    // Assert
    Money expected = Money.EUR(cents: 1234UL);
    Assert.AreEqual(expected, actual);
  }

  [TestMethod]
  public void Parce_BYNString_BYNReturned()
  {
    // Arrange
    string value = "BYN000000000000000012.34";

    // Act
    Money actual = Money.Parce(value);

    // Assert
    Money expected = Money.BYN(kopecks: 1234UL);
    Assert.AreEqual(expected, actual);
  }

  [TestMethod]
  public void Parce_RUBString_RUBReturned()
  {
    // Arrange
    string value = "RUB000000000000000012.34";

    // Act
    Money actual = Money.Parce(value);

    // Assert
    Money expected = Money.RUB(kopecks: 1234UL);
    Assert.AreEqual(expected, actual);
  }

  [TestMethod]
  public void Parce_OneDigitAfterPoint_CorrectValueReturnedReturned()
  {
    // Arrange
    string value = "RUB000000000000000012.03";

    // Act
    Money actual = Money.Parce(value);

    // Assert
    Money expected = Money.RUB(kopecks: 1203UL);
    Assert.AreEqual(expected, actual);
  }
}
