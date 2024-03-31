// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace MeneySample;

public readonly record struct Money(ulong MajorUnits, ushort MinorUnits, ushort MinorUnitRatio, Currency Currency)
{
  public static Money UnitedStatesDollar(ulong dollars, ushort cents)
  {
    if (cents > 99)
    {
      throw new Exception($"Cent amount {cents} too large");
    }

    return new Money(MajorUnits: dollars, MinorUnits: cents, MinorUnitRatio: 100, Currency: Currency.UnitedStatesDollar);
  }

  public static Money Euro(ulong euros, ushort cents)
  {
    if (cents > 99)
    {
      throw new Exception($"Cent amount {cents} too large");
    }

    return new Money(MajorUnits: euros, MinorUnits: cents, MinorUnitRatio: 100, Currency: Currency.Euro);
  }

  public static Money BelarusianRouble(ulong roubles, ushort kopecks)
  {
    if (kopecks > 99)
    {
      throw new Exception($"Kopeck amount {kopecks} too large");
    }

    return new Money(MajorUnits: roubles, MinorUnits: kopecks, MinorUnitRatio: 100, Currency: Currency.BelarusianRouble);
  }

  public static Money RussianRouble(ulong roubles, ushort kopecks)
  {
    if (kopecks > 99)
    {
      throw new Exception($"Kopeck amount {kopecks} too large");
    }

    return new Money(MajorUnits: roubles, MinorUnits: kopecks, MinorUnitRatio: 100, Currency: Currency.RussianRouble);
  }
}
