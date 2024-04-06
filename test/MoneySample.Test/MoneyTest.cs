// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using MeneySample;

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
}
