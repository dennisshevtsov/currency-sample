// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using MeneySample;

namespace MoneySample.Test;

[TestClass]

public sealed class CurrencyTest
{
  [TestMethod]
  public void Equals_UnitedStatesDollarAndUnitedStatesDollar_TrueReturned()
  {
    // Arrange
    Currency dollar1 = Currency.UnitedStatesDollar;
    Currency dollar2 = Currency.UnitedStatesDollar;

    // Act
    bool result = dollar1.Equals(dollar2);

    // Assert
    Assert.IsTrue(result);
  }

  [TestMethod]
  public void Equals_UnitedStatesDollarAndEuro_FalseReturned()
  {
    // Arrange
    Currency dollar = Currency.UnitedStatesDollar;
    Currency euro   = Currency.Euro;

    // Act
    bool result = dollar.Equals(euro);

    // Assert
    Assert.IsFalse(result);
  }

  [TestMethod]
  public void Equals_UnitedStatesBelarusianRouble_FalseReturned()
  {
    // Arrange
    Currency dollar = Currency.UnitedStatesDollar;
    Currency rouble = Currency.BelarusianRouble;

    // Act
    bool result = dollar.Equals(rouble);

    // Assert
    Assert.IsFalse(result);
  }

  [TestMethod]
  public void Equals_UnitedStatesDollarAndRussianRouble_FalseReturned()
  {
    // Arrange
    Currency dollar = Currency.UnitedStatesDollar;
    Currency rouble = Currency.RussianRouble;

    // Act
    bool result = dollar.Equals(rouble);

    // Assert
    Assert.IsFalse(result);
  }

  [TestMethod]
  public void Equals_EuroAndUnitedStatesDollar_FalseReturned()
  {
    // Arrange
    Currency euro = Currency.Euro;
    Currency dollar = Currency.UnitedStatesDollar;

    // Act
    bool result = euro.Equals(dollar);

    // Assert
    Assert.IsFalse(result);
  }

  [TestMethod]
  public void Equals_EuroAndUnitedStatesEuro_TrueReturned()
  {
    // Arrange
    Currency euro1 = Currency.Euro;
    Currency euro2 = Currency.Euro;

    // Act
    bool result = euro1.Equals(euro2);

    // Assert
    Assert.IsTrue(result);
  }

  [TestMethod]
  public void Equals_EuroAndBelarusianRouble_FalseReturned()
  {
    // Arrange
    Currency euro = Currency.Euro;
    Currency rouble = Currency.BelarusianRouble;

    // Act
    bool result = euro.Equals(rouble);

    // Assert
    Assert.IsFalse(result);
  }

  [TestMethod]
  public void Equals_EuroAndRussianRouble_FalseReturned()
  {
    // Arrange
    Currency euro = Currency.Euro;
    Currency rouble = Currency.RussianRouble;

    // Act
    bool result = euro.Equals(rouble);

    // Assert
    Assert.IsFalse(result);
  }

  [TestMethod]
  public void Equals_BelarusianRoubleAndUnitedStatesDollar_FalseReturned()
  {
    // Arrange
    Currency rouble = Currency.BelarusianRouble;
    Currency dollar = Currency.UnitedStatesDollar;

    // Act
    bool result = rouble.Equals(dollar);

    // Assert
    Assert.IsFalse(result);
  }

  [TestMethod]
  public void Equals_BelarusianRoubleAndUnitedStatesEuro_FalseReturned()
  {
    // Arrange
    Currency rouble = Currency.BelarusianRouble;
    Currency euro   = Currency.Euro;

    // Act
    bool result = rouble.Equals(euro);

    // Assert
    Assert.IsFalse(result);
  }

  [TestMethod]
  public void Equals_BelarusianRoubleAndBelarusianRouble_TrueReturned()
  {
    // Arrange
    Currency rouble1 = Currency.BelarusianRouble;
    Currency rouble2 = Currency.BelarusianRouble;

    // Act
    bool result = rouble1.Equals(rouble2);

    // Assert
    Assert.IsTrue(result);
  }

  [TestMethod]
  public void Equals_BelarusianRoubleAndRussianRouble_FalseReturned()
  {
    // Arrange
    Currency belarusianRouble = Currency.BelarusianRouble;
    Currency roussianRouble   = Currency.RussianRouble;

    // Act
    bool result = belarusianRouble.Equals(roussianRouble);

    // Assert
    Assert.IsFalse(result);
  }

  [TestMethod]
  public void Equals_RussianRoubleAndUnitedStatesDollar_FalseReturned()
  {
    // Arrange
    Currency rouble = Currency.RussianRouble;
    Currency dollar = Currency.UnitedStatesDollar;

    // Act
    bool result = rouble.Equals(dollar);

    // Assert
    Assert.IsFalse(result);
  }

  [TestMethod]
  public void Equals_RussianRoubleAndUnitedStatesEuro_FalseReturned()
  {
    // Arrange
    Currency rouble = Currency.RussianRouble;
    Currency euro   = Currency.Euro;

    // Act
    bool result = rouble.Equals(euro);

    // Assert
    Assert.IsFalse(result);
  }

  [TestMethod]
  public void Equals_RussianRoubleAndBelarusianRouble_FalseReturned()
  {
    // Arrange
    Currency belarusianRouble = Currency.RussianRouble;
    Currency russianRouble    = Currency.BelarusianRouble;

    // Act
    bool result = belarusianRouble.Equals(russianRouble);

    // Assert
    Assert.IsFalse(result);
  }

  [TestMethod]
  public void Equals_RussianRoubleAndRussianRouble_TrueReturned()
  {
    // Arrange
    Currency rouble1 = Currency.RussianRouble;
    Currency rouble2 = Currency.RussianRouble;

    // Act
    bool result = rouble1.Equals(rouble2);

    // Assert
    Assert.IsTrue(result);
  }
}
