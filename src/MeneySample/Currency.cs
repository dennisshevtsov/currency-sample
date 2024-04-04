// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Diagnostics.CodeAnalysis;

namespace MeneySample;

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

  public static readonly Currency None;
  public static readonly Currency UnitedStatesDollar = new(code: "USD");
  public static readonly Currency Euro               = new(code: "EUR");
  public static readonly Currency BelarusianRouble   = new(code: "BYN");
  public static readonly Currency RussianRouble      = new(code: "RUB");
}
