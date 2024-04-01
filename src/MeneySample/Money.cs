// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace MeneySample;

public readonly record struct Money(ulong TotalMinorUnits, Currency Currency)
{
  private const ulong MinorUnitRatio = 100UL;

  public ulong MajorUnits => TotalMinorUnits / Money.MinorUnitRatio;
  public ulong MinorUnits => TotalMinorUnits % Money.MinorUnitRatio;
  public decimal TotalMajorUnits => (decimal)TotalMinorUnits / MinorUnitRatio;

  public override string ToString() => $"{MajorUnits}.{MinorUnits} {Currency}";

  public static Money UnitedStatesDollar(ushort cents) => new(TotalMinorUnits: cents, Currency: Currency.UnitedStatesDollar);
  public static Money Euro(ushort cents) => new(TotalMinorUnits: cents, Currency: Currency.Euro);
  public static Money BelarusianRouble(ushort kopecks) => new(TotalMinorUnits: kopecks, Currency: Currency.BelarusianRouble);
  public static Money RussianRouble(ushort kopecks) => new(TotalMinorUnits: kopecks, Currency: Currency.RussianRouble);
}
