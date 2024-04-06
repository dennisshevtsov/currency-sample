// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Diagnostics.CodeAnalysis;

namespace MoneySample;

public readonly struct Money : IComparable<Money>, IEquatable<Money>
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

    return CompareTo(money) == 0;
  }

  public bool Equals(Money other) => CompareTo(other) == 0;

  public override int GetHashCode() => HashCode.Combine(TotalMinorUnits, Currency);

  public int CompareTo(Money other)
  {
    if (Currency != other.Currency)
    {
      throw new InvalidOperationException("Same currency required to compare money");
    }

    if (TotalMinorUnits == other.TotalMinorUnits)
    {
      return 0;
    }

    if (TotalMinorUnits > other.TotalMinorUnits)
    {
      return 1;
    }

    return -1;
  }

  public static bool operator <(Money a, Money b) => a.CompareTo(b) < 0;
  public static bool operator >(Money a, Money b) => a.CompareTo(b) > 0;

  public static bool operator <=(Money a, Money b) => a.CompareTo(b) <= 0;
  public static bool operator >=(Money a, Money b) => a.CompareTo(b) >= 0;

  public static bool operator ==(Money a, Money b) => a.CompareTo(b) == 0;
  public static bool operator !=(Money a, Money b) => a.CompareTo(b) != 0;

  public static Money None { get; }

  public static Money UnitedStatesDollar(ulong cents) => new(currency: Currency.UnitedStatesDollar, totalMinorUnits: cents);
  public static Money               Euro(ulong cents) => new(currency: Currency.Euro              , totalMinorUnits: cents);
  public static Money BelarusianRouble(ulong kopecks) => new(currency: Currency.BelarusianRouble  , totalMinorUnits: kopecks);
  public static Money    RussianRouble(ulong kopecks) => new(currency: Currency.RussianRouble     , totalMinorUnits: kopecks);
}
