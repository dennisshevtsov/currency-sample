// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace MeneySample;

public readonly struct MinorUnitRatio
{
  private MinorUnitRatio(ulong ratio) => Ratio = ratio;
  private ulong Ratio { get; }

  public override string ToString() => Ratio.ToString();

  public static readonly MinorUnitRatio Ratio100          = new(ratio: 100);
  public static readonly MinorUnitRatio UnitedStatesCents = MinorUnitRatio.Ratio100;
  public static readonly MinorUnitRatio EuroCents         = MinorUnitRatio.Ratio100;
  public static readonly MinorUnitRatio BelarusianKopecks = MinorUnitRatio.Ratio100;
  public static readonly MinorUnitRatio RussianKopecks    = MinorUnitRatio.Ratio100;
}
