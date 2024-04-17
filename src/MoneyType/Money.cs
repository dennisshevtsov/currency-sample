// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Diagnostics.CodeAnalysis;

namespace MoneyType;

public readonly struct Money : IComparable<Money>, IEquatable<Money>
{
  private const ulong MinorUnitRatio = 100UL;

  private Money(Currency currency, ulong totalMinorUnits) => (Currency, TotalMinorUnits) = (currency, totalMinorUnits);

  private Currency Currency { get; }
  private ulong TotalMinorUnits { get; }
 
  private ulong MajorUnits => TotalMinorUnits / Money.MinorUnitRatio;
  private ulong MinorUnits => TotalMinorUnits % Money.MinorUnitRatio;

  public override string ToString() => $"{Currency}{MajorUnits:D18}.{MinorUnits}";

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

  public static Money operator +(Money a, Money b)
  {
    if (a.Currency != b.Currency)
    {
      throw new InvalidOperationException("Same currency required to sum money");
    }

    return new Money(currency: a.Currency, totalMinorUnits: a.TotalMinorUnits + b.TotalMinorUnits);
  }

  public static Money operator *(Money a, decimal b)
  {
    if (b < 0M)
    {
      throw new InvalidOperationException("Positive number required to multiply money");
    }

    return new Money(currency: a.Currency, totalMinorUnits: (ulong)(a.TotalMinorUnits * b));
  }

  public static implicit operator ulong(Money money   ) => money.TotalMinorUnits;
  public static implicit operator Currency(Money money) => money.Currency;

  public static Money Parce(string value)
  {
    int stringMoneyLength = 3 + 18 + 1 + 2;
    if (value.Length != stringMoneyLength)
    {
      throw new InvalidCastException("Invalid length of string");
    }

    Currency currency = Currency.Parse(value.Substring(0, 3));

    ulong majorUnits = ulong.Parse(value.Substring(3, 18));
    ulong minorUnits = ulong.Parse(value.Substring(23, 2));
    ulong totalMinorUnits = majorUnits * Money.MinorUnitRatio + minorUnits;

    return new Money(currency: currency, totalMinorUnits: totalMinorUnits);
  }

  public static Money None { get; }
  public static Money USD(ulong cents  ) => new(currency: Currency.USD, totalMinorUnits: cents);
  public static Money EUR(ulong cents  ) => new(currency: Currency.EUR, totalMinorUnits: cents);
  public static Money BYN(ulong kopecks) => new(currency: Currency.RYN, totalMinorUnits: kopecks);
  public static Money RUB(ulong kopecks) => new(currency: Currency.RUB, totalMinorUnits: kopecks);
}
