// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace MoneyType.Test;

[TestClass]
public sealed class CurrencyTest
{
  [TestMethod]
  public void Equals_UnitedStatesDollarAndObject_ExceptionThrown()
  {
    // Arrange
    Currency dollar = Currency.USD;
    object      obj = new();

    // Act
    Action action = () => dollar.Equals(obj);

    // Assert
    Assert.ThrowsException<InvalidOperationException>(action);
  }

  [TestMethod]
  public void Equals_UnitedStatesDollarAndUnitedStatesDollar_TrueReturned()
  {
    // Arrange
    Currency dollar1 = Currency.USD;
    Currency dollar2 = Currency.USD;

    // Act
    bool result = dollar1.Equals(dollar2);

    // Assert
    Assert.IsTrue(result);
  }

  [TestMethod]
  public void Equals_UnitedStatesDollarAndEuro_FalseReturned()
  {
    // Arrange
    Currency dollar = Currency.USD;
    Currency euro   = Currency.EUR;

    // Act
    bool result = dollar.Equals(euro);

    // Assert
    Assert.IsFalse(result);
  }

  [TestMethod]
  public void Equals_UnitedStatesBelarusianRouble_FalseReturned()
  {
    // Arrange
    Currency dollar = Currency.USD;
    Currency rouble = Currency.BYN;

    // Act
    bool result = dollar.Equals(rouble);

    // Assert
    Assert.IsFalse(result);
  }

  [TestMethod]
  public void Equals_UnitedStatesDollarAndRussianRouble_FalseReturned()
  {
    // Arrange
    Currency dollar = Currency.USD;
    Currency rouble = Currency.RUB;

    // Act
    bool result = dollar.Equals(rouble);

    // Assert
    Assert.IsFalse(result);
  }

  [TestMethod]
  public void Equals_EuroAndUnitedStatesDollar_FalseReturned()
  {
    // Arrange
    Currency   euro = Currency.EUR;
    Currency dollar = Currency.USD;

    // Act
    bool result = euro.Equals(dollar);

    // Assert
    Assert.IsFalse(result);
  }

  [TestMethod]
  public void Equals_EuroAndUnitedStatesEuro_TrueReturned()
  {
    // Arrange
    Currency euro1 = Currency.EUR;
    Currency euro2 = Currency.EUR;

    // Act
    bool result = euro1.Equals(euro2);

    // Assert
    Assert.IsTrue(result);
  }

  [TestMethod]
  public void Equals_EuroAndBelarusianRouble_FalseReturned()
  {
    // Arrange
    Currency   euro = Currency.EUR;
    Currency rouble = Currency.BYN;

    // Act
    bool result = euro.Equals(rouble);

    // Assert
    Assert.IsFalse(result);
  }

  [TestMethod]
  public void Equals_EuroAndRussianRouble_FalseReturned()
  {
    // Arrange
    Currency   euro = Currency.EUR;
    Currency rouble = Currency.RUB;

    // Act
    bool result = euro.Equals(rouble);

    // Assert
    Assert.IsFalse(result);
  }

  [TestMethod]
  public void Equals_BelarusianRoubleAndUnitedStatesDollar_FalseReturned()
  {
    // Arrange
    Currency rouble = Currency.BYN;
    Currency dollar = Currency.USD;

    // Act
    bool result = rouble.Equals(dollar);

    // Assert
    Assert.IsFalse(result);
  }

  [TestMethod]
  public void Equals_BelarusianRoubleAndUnitedStatesEuro_FalseReturned()
  {
    // Arrange
    Currency rouble = Currency.BYN;
    Currency   euro = Currency.EUR;

    // Act
    bool result = rouble.Equals(euro);

    // Assert
    Assert.IsFalse(result);
  }

  [TestMethod]
  public void Equals_BelarusianRoubleAndBelarusianRouble_TrueReturned()
  {
    // Arrange
    Currency rouble1 = Currency.BYN;
    Currency rouble2 = Currency.BYN;

    // Act
    bool result = rouble1.Equals(rouble2);

    // Assert
    Assert.IsTrue(result);
  }

  [TestMethod]
  public void Equals_BelarusianRoubleAndRussianRouble_FalseReturned()
  {
    // Arrange
    Currency belarusianRouble = Currency.BYN;
    Currency   roussianRouble = Currency.RUB;

    // Act
    bool result = belarusianRouble.Equals(roussianRouble);

    // Assert
    Assert.IsFalse(result);
  }

  [TestMethod]
  public void Equals_RussianRoubleAndUnitedStatesDollar_FalseReturned()
  {
    // Arrange
    Currency rouble = Currency.RUB;
    Currency dollar = Currency.USD;

    // Act
    bool result = rouble.Equals(dollar);

    // Assert
    Assert.IsFalse(result);
  }

  [TestMethod]
  public void Equals_RussianRoubleAndUnitedStatesEuro_FalseReturned()
  {
    // Arrange
    Currency rouble = Currency.RUB;
    Currency   euro = Currency.EUR;

    // Act
    bool result = rouble.Equals(euro);

    // Assert
    Assert.IsFalse(result);
  }

  [TestMethod]
  public void Equals_RussianRoubleAndBelarusianRouble_FalseReturned()
  {
    // Arrange
    Currency belarusianRouble = Currency.RUB;
    Currency    russianRouble = Currency.BYN;

    // Act
    bool result = belarusianRouble.Equals(russianRouble);

    // Assert
    Assert.IsFalse(result);
  }

  [TestMethod]
  public void Equals_RussianRoubleAndRussianRouble_TrueReturned()
  {
    // Arrange
    Currency rouble1 = Currency.RUB;
    Currency rouble2 = Currency.RUB;

    // Act
    bool result = rouble1.Equals(rouble2);

    // Assert
    Assert.IsTrue(result);
  }

  [TestMethod]
  public void EqualOperator_UnitedStatesDollarAndUnitedStatesDollar_TrueReturned()
  {
    // Arrange
    Currency dollar1 = Currency.USD;
    Currency dollar2 = Currency.USD;

    // Act
    bool result = dollar1 == dollar2;

    // Assert
    Assert.IsTrue(result);
  }

  [TestMethod]
  public void EqualOperator_UnitedStatesDollarAndEuro_FalseReturned()
  {
    // Arrange
    Currency dollar = Currency.USD;
    Currency   euro = Currency.EUR;

    // Act
    bool result = dollar == euro;

    // Assert
    Assert.IsFalse(result);
  }

  [TestMethod]
  public void EqualOperator_UnitedStatesBelarusianRouble_FalseReturned()
  {
    // Arrange
    Currency dollar = Currency.USD;
    Currency rouble = Currency.BYN;

    // Act
    bool result = dollar == rouble;

    // Assert
    Assert.IsFalse(result);
  }

  [TestMethod]
  public void EqualOperator_UnitedStatesDollarAndRussianRouble_FalseReturned()
  {
    // Arrange
    Currency dollar = Currency.USD;
    Currency rouble = Currency.RUB;

    // Act
    bool result = dollar == rouble;

    // Assert
    Assert.IsFalse(result);
  }

  [TestMethod]
  public void EqualOperator_EuroAndUnitedStatesDollar_FalseReturned()
  {
    // Arrange
    Currency   euro = Currency.EUR;
    Currency dollar = Currency.USD;

    // Act
    bool result = euro == dollar;

    // Assert
    Assert.IsFalse(result);
  }

  [TestMethod]
  public void EqualOperator_EuroAndUnitedStatesEuro_TrueReturned()
  {
    // Arrange
    Currency euro1 = Currency.EUR;
    Currency euro2 = Currency.EUR;

    // Act
    bool result = euro1 == euro2;

    // Assert
    Assert.IsTrue(result);
  }

  [TestMethod]
  public void EqualOperator_EuroAndBelarusianRouble_FalseReturned()
  {
    // Arrange
    Currency   euro = Currency.EUR;
    Currency rouble = Currency.BYN;

    // Act
    bool result = euro == rouble;

    // Assert
    Assert.IsFalse(result);
  }

  [TestMethod]
  public void EqualOperator_EuroAndRussianRouble_FalseReturned()
  {
    // Arrange
    Currency   euro = Currency.EUR;
    Currency rouble = Currency.RUB;

    // Act
    bool result = euro == rouble;

    // Assert
    Assert.IsFalse(result);
  }

  [TestMethod]
  public void EqualOperator_BelarusianRoubleAndUnitedStatesDollar_FalseReturned()
  {
    // Arrange
    Currency rouble = Currency.BYN;
    Currency dollar = Currency.USD;

    // Act
    bool result = rouble == dollar;

    // Assert
    Assert.IsFalse(result);
  }

  [TestMethod]
  public void EqualOperator_BelarusianRoubleAndUnitedStatesEuro_FalseReturned()
  {
    // Arrange
    Currency rouble = Currency.BYN;
    Currency   euro = Currency.EUR;

    // Act
    bool result = rouble == euro;

    // Assert
    Assert.IsFalse(result);
  }

  [TestMethod]
  public void EqualOperator_BelarusianRoubleAndBelarusianRouble_TrueReturned()
  {
    // Arrange
    Currency rouble1 = Currency.BYN;
    Currency rouble2 = Currency.BYN;

    // Act
    bool result = rouble1 == rouble2;

    // Assert
    Assert.IsTrue(result);
  }

  [TestMethod]
  public void EqualOperator_BelarusianRoubleAndRussianRouble_FalseReturned()
  {
    // Arrange
    Currency belarusianRouble = Currency.BYN;
    Currency   roussianRouble = Currency.RUB;

    // Act
    bool result = belarusianRouble == roussianRouble;

    // Assert
    Assert.IsFalse(result);
  }

  [TestMethod]
  public void EqualOperator_RussianRoubleAndUnitedStatesDollar_FalseReturned()
  {
    // Arrange
    Currency rouble = Currency.RUB;
    Currency dollar = Currency.USD;

    // Act
    bool result = rouble == dollar;

    // Assert
    Assert.IsFalse(result);
  }

  [TestMethod]
  public void EqualOperator_RussianRoubleAndUnitedStatesEuro_FalseReturned()
  {
    // Arrange
    Currency rouble = Currency.RUB;
    Currency   euro = Currency.EUR;

    // Act
    bool result = rouble == euro;

    // Assert
    Assert.IsFalse(result);
  }

  [TestMethod]
  public void EqualOperator_RussianRoubleAndBelarusianRouble_FalseReturned()
  {
    // Arrange
    Currency belarusianRouble = Currency.RUB;
    Currency    russianRouble = Currency.BYN;

    // Act
    bool result = belarusianRouble == russianRouble;

    // Assert
    Assert.IsFalse(result);
  }

  [TestMethod]
  public void EqualOperator_RussianRoubleAndRussianRouble_TrueReturned()
  {
    // Arrange
    Currency rouble1 = Currency.RUB;
    Currency rouble2 = Currency.RUB;

    // Act
    bool result = rouble1 == rouble2;

    // Assert
    Assert.IsTrue(result);
  }

  [TestMethod]
  public void NotEqualOperator_UnitedStatesDollarAndUnitedStatesDollar_FalseReturned()
  {
    // Arrange
    Currency dollar1 = Currency.USD;
    Currency dollar2 = Currency.USD;

    // Act
    bool result = dollar1 != dollar2;

    // Assert
    Assert.IsFalse(result);
  }

  [TestMethod]
  public void NotEqualOperator_UnitedStatesDollarAndEuro_TrueReturned()
  {
    // Arrange
    Currency dollar = Currency.USD;
    Currency   euro = Currency.EUR;

    // Act
    bool result = dollar != euro;

    // Assert
    Assert.IsTrue(result);
  }

  [TestMethod]
  public void NotEqualOperator_UnitedStatesBelarusianRouble_TrueReturned()
  {
    // Arrange
    Currency dollar = Currency.USD;
    Currency rouble = Currency.BYN;

    // Act
    bool result = dollar != rouble;

    // Assert
    Assert.IsTrue(result);
  }

  [TestMethod]
  public void NotEqualOperator_UnitedStatesDollarAndRussianRouble_TrueReturned()
  {
    // Arrange
    Currency dollar = Currency.USD;
    Currency rouble = Currency.RUB;

    // Act
    bool result = dollar != rouble;

    // Assert
    Assert.IsTrue(result);
  }

  [TestMethod]
  public void NotEqualOperator_EuroAndUnitedStatesDollar_TrueReturned()
  {
    // Arrange
    Currency   euro = Currency.EUR;
    Currency dollar = Currency.USD;

    // Act
    bool result = euro != dollar;

    // Assert
    Assert.IsTrue(result);
  }

  [TestMethod]
  public void NotEqualOperator_EuroAndUnitedStatesEuro_FalseReturned()
  {
    // Arrange
    Currency euro1 = Currency.EUR;
    Currency euro2 = Currency.EUR;

    // Act
    bool result = euro1 != euro2;

    // Assert
    Assert.IsFalse(result);
  }

  [TestMethod]
  public void NotEqualOperator_EuroAndBelarusianRouble_TrueReturned()
  {
    // Arrange
    Currency   euro = Currency.EUR;
    Currency rouble = Currency.BYN;

    // Act
    bool result = euro != rouble;

    // Assert
    Assert.IsTrue(result);
  }

  [TestMethod]
  public void NotEqualOperator_EuroAndRussianRouble_TrueReturned()
  {
    // Arrange
    Currency   euro = Currency.EUR;
    Currency rouble = Currency.RUB;

    // Act
    bool result = euro != rouble;

    // Assert
    Assert.IsTrue(result);
  }

  [TestMethod]
  public void NotEqualOperator_BelarusianRoubleAndUnitedStatesDollar_TrueReturned()
  {
    // Arrange
    Currency rouble = Currency.BYN;
    Currency dollar = Currency.USD;

    // Act
    bool result = rouble != dollar;

    // Assert
    Assert.IsTrue(result);
  }

  [TestMethod]
  public void NotEqualOperator_BelarusianRoubleAndUnitedStatesEuro_TrueReturned()
  {
    // Arrange
    Currency rouble = Currency.BYN;
    Currency   euro = Currency.EUR;

    // Act
    bool result = rouble != euro;

    // Assert
    Assert.IsTrue(result);
  }

  [TestMethod]
  public void NotEqualOperator_BelarusianRoubleAndBelarusianRouble_FalseReturned()
  {
    // Arrange
    Currency rouble1 = Currency.BYN;
    Currency rouble2 = Currency.BYN;

    // Act
    bool result = rouble1 != rouble2;

    // Assert
    Assert.IsFalse(result);
  }

  [TestMethod]
  public void NotEqualOperator_BelarusianRoubleAndRussianRouble_TrueReturned()
  {
    // Arrange
    Currency belarusianRouble = Currency.BYN;
    Currency   roussianRouble = Currency.RUB;

    // Act
    bool result = belarusianRouble != roussianRouble;

    // Assert
    Assert.IsTrue(result);
  }

  [TestMethod]
  public void NotEqualOperator_RussianRoubleAndUnitedStatesDollar_TrueReturned()
  {
    // Arrange
    Currency rouble = Currency.RUB;
    Currency dollar = Currency.USD;

    // Act
    bool result = rouble != dollar;

    // Assert
    Assert.IsTrue(result);
  }

  [TestMethod]
  public void NotEqualOperator_RussianRoubleAndUnitedStatesEuro_TrueReturned()
  {
    // Arrange
    Currency rouble = Currency.RUB;
    Currency   euro = Currency.EUR;

    // Act
    bool result = rouble != euro;

    // Assert
    Assert.IsTrue(result);
  }

  [TestMethod]
  public void NotEqualOperator_RussianRoubleAndBelarusianRouble_TrueReturned()
  {
    // Arrange
    Currency belarusianRouble = Currency.RUB;
    Currency    russianRouble = Currency.BYN;

    // Act
    bool result = belarusianRouble != russianRouble;

    // Assert
    Assert.IsTrue(result);
  }

  [TestMethod]
  public void NotEqualOperator_RussianRoubleAndRussianRouble_FalseReturned()
  {
    // Arrange
    Currency rouble1 = Currency.RUB;
    Currency rouble2 = Currency.RUB;

    // Act
    bool result = rouble1 != rouble2;

    // Assert
    Assert.IsFalse(result);
  }

  [TestMethod]
  public void Parce_4LettersCode_ExceptionThrownd()
  {
    // Arrange
    string code = "AAAA";

    // Act
    Func<object> act = () => Currency.Parse(code);

    // Assert
    Assert.ThrowsException<InvalidCastException>(act);
  }

  [TestMethod]
  public void Parce_2LettersCode_ExceptionThrownd()
  {
    // Arrange
    string code = "AA";

    // Act
    Func<object> act = () => Currency.Parse(code);

    // Assert
    Assert.ThrowsException<InvalidCastException>(act);
  }

  [TestMethod]
  public void Parce_EmptyCode_ExceptionThrownd()
  {
    // Arrange
    string code = "";

    // Act
    Func<object> act = () => Currency.Parse(code);

    // Assert
    Assert.ThrowsException<ArgumentException>(act);
  }

  [TestMethod]
  public void Parce_NullCode_ExceptionThrownd()
  {
    // Arrange
    string code = null!;

    // Act
    Func<object> act = () => Currency.Parse(code);

    // Assert
    Assert.ThrowsException<ArgumentNullException>(act);
  }

  [TestMethod]
  public void Parce_UnknownCode_ExceptionThrownd()
  {
    // Arrange
    string code = "AAA";

    // Act
    Func<object> act = () => Currency.Parse(code);

    // Assert
    Assert.ThrowsException<InvalidCastException>(act);
  }

  [TestMethod]
  public void Parce_USDCode_USDReturned()
  {
    // Arrange
    string code = "USD";

    // Act
    Currency currency = Currency.Parse(code);

    // Assert
    Assert.AreEqual(Currency.USD, currency);
  }

  [TestMethod]
  public void Parce_EURCode_EURReturned()
  {
    // Arrange
    string code = "EUR";

    // Act
    Currency currency = Currency.Parse(code);

    // Assert
    Assert.AreEqual(Currency.EUR, currency);
  }

  [TestMethod]
  public void Parce_BYNCode_BYNReturned()
  {
    // Arrange
    string code = "BYN";

    // Act
    Currency currency = Currency.Parse(code);

    // Assert
    Assert.AreEqual(Currency.BYN, currency);
  }

  [TestMethod]
  public void Parce_RUBCode_RUBReturned()
  {
    // Arrange
    string code = "RUB";

    // Act
    Currency currency = Currency.Parse(code);

    // Assert
    Assert.AreEqual(Currency.RUB, currency);
  }
}
