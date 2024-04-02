// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace MeneySample;

public readonly struct Money
{
  private const ulong MinorUnitRatio = 100UL;

  private Money(Currency currency, ulong totalMinorUnits) => (Currency, TotalMinorUnits) = (currency, totalMinorUnits);

  private Currency Currency { get; }
  private ulong TotalMinorUnits { get; }

  private ulong MajorUnits => TotalMinorUnits / Money.MinorUnitRatio;
  private ulong MinorUnits => TotalMinorUnits % Money.MinorUnitRatio;

  public override string ToString() => $"{MajorUnits}.{MinorUnits} {Currency}";

  public static Money None { get; }

  public static Money UnitedStatesDollar(ushort cents) => new(currency: Currency.UnitedStatesDollar, totalMinorUnits: cents);
  public static Money Euro(ushort cents)               => new(currency: Currency.Euro, totalMinorUnits: cents);
  public static Money BelarusianRouble(ushort kopecks) => new(currency: Currency.BelarusianRouble, totalMinorUnits: kopecks);
  public static Money RussianRouble(ushort kopecks)    => new(currency: Currency.RussianRouble, totalMinorUnits: kopecks);
}
