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
}
