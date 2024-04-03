// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Diagnostics.CodeAnalysis;

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

  public override bool Equals([NotNullWhen(true)] object? obj)
  {
    if (obj is not Money money)
    {
      throw new InvalidOperationException("Invalid type of object to compare to money");
    }

    return TotalMinorUnits == money.TotalMinorUnits;
  }

  public override int GetHashCode() => HashCode.Combine(TotalMinorUnits, Currency);

  public static bool operator <(Money a, Money b)
  {
    if (a.Currency != b.Currency)
    {
      throw new InvalidOperationException("Same currency required to compare money");
    }

    return a.TotalMinorUnits < b.TotalMinorUnits;
  }
  public static bool operator >(Money a, Money b) => a.TotalMinorUnits > b.TotalMinorUnits;

  public static bool operator <=(Money a, Money b) => a.TotalMinorUnits <= b.TotalMinorUnits;
  public static bool operator >=(Money a, Money b) => a.TotalMinorUnits >= b.TotalMinorUnits;

  public static bool operator ==(Money a, Money b) => a.TotalMinorUnits == b.TotalMinorUnits;
  public static bool operator !=(Money a, Money b) => a.TotalMinorUnits != b.TotalMinorUnits;

  public static Money None { get; }

  public static Money UnitedStatesDollar(ushort cents) => new(currency: Currency.UnitedStatesDollar, totalMinorUnits: cents);
  public static Money Euro(ushort cents)               => new(currency: Currency.Euro, totalMinorUnits: cents);
  public static Money BelarusianRouble(ushort kopecks) => new(currency: Currency.BelarusianRouble, totalMinorUnits: kopecks);
  public static Money RussianRouble(ushort kopecks)    => new(currency: Currency.RussianRouble, totalMinorUnits: kopecks);
}
