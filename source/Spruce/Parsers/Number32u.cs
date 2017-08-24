﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Spruce.Parsers {
  public class Number32u : Number {
    protected static readonly string FirstChars;
    protected static readonly string Chars;

    static Number32u() {
      Chars = CharSets.Number;
      // Hex, etc.. need to find current X# syntax
      FirstChars = "" + Chars;
    }

    public override object Parse(string aText, ref int rStart) {
      if (FirstChars.IndexOf(aText[rStart]) == -1) {
        return null;
      }

      int i;
      for (i = rStart + 1; i < aText.Length; i++) {
        if (Chars.IndexOf(aText[i]) == -1) {
          break;
        }
      }

      string xText = aText.Substring(rStart, i - rStart);
      rStart = i;
      return UInt32.Parse(xText);
    }
  }
}