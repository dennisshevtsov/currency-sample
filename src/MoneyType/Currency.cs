// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Diagnostics.CodeAnalysis;

namespace MoneyType;

public readonly struct Currency : IEquatable<Currency>
{
  private Currency(string code) => Code = code;
  private string Code { get; }

  public override string ToString() => Code;

  public bool Equals(Currency other) => Code == other.Code;

  public override bool Equals([NotNullWhen(true)] object? obj)
  {
    if (obj is not Currency currency)
    {
      throw new InvalidOperationException("Invalid type of object to compare to currency");
    }

    return Equals(currency);
  }

  public override int GetHashCode() => Code.GetHashCode();

  public static bool operator ==(Currency a, Currency b) => a.Equals(b);
  public static bool operator !=(Currency a, Currency b) => !a.Equals(b);

  public static Currency Parse(string value)
  {
    ArgumentNullException.ThrowIfNullOrEmpty(value);

    if (value.Length != 3)
    {
      throw new InvalidCastException($"Invalid length {value.Length} of string to convert to Currency");
    }

    if (value == Currency.USD.Code) return Currency.USD;
    if (value == Currency.EUR.Code) return Currency.EUR;
    if (value == Currency.RYN.Code) return Currency.RYN;
    if (value == Currency.RUB.Code) return Currency.RUB;

    throw new InvalidCastException($"Invalid value {value} to convert to Currency");
  }

  public static readonly Currency None;
  public static readonly Currency USD = new(code: "USD");
  public static readonly Currency EUR = new(code: "EUR");
  public static readonly Currency RYN = new(code: "BYN");
  public static readonly Currency RUB = new(code: "RUB");
}
