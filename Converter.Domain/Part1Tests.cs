using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Converter.Domain
{
    [TestClass]
    public class Part1Tests
    {
        [TestMethod]
        public void SingleArabic_ReturnsCorrectRoman()
        {
            Assert.AreEqual("I", RomanNumeralConverter.ToRoman(1));
            Assert.AreEqual("V", RomanNumeralConverter.ToRoman(5));
            Assert.AreEqual("X", RomanNumeralConverter.ToRoman(10));
            Assert.AreEqual("L", RomanNumeralConverter.ToRoman(50));
            Assert.AreEqual("C", RomanNumeralConverter.ToRoman(100));
            Assert.AreEqual("D", RomanNumeralConverter.ToRoman(500));
            Assert.AreEqual("M", RomanNumeralConverter.ToRoman(1000));
        }

        [TestMethod]
        public void UpToThreeOver_ReturnsExtraIs()
        {
            Assert.AreEqual("III", RomanNumeralConverter.ToRoman(3));
            Assert.AreEqual("VII", RomanNumeralConverter.ToRoman(7));
            Assert.AreEqual("XIII", RomanNumeralConverter.ToRoman(13));
            Assert.AreEqual("LI", RomanNumeralConverter.ToRoman(51));
            Assert.AreEqual("CII", RomanNumeralConverter.ToRoman(102));
            Assert.AreEqual("DIII", RomanNumeralConverter.ToRoman(503));
            Assert.AreEqual("MI", RomanNumeralConverter.ToRoman(1001));
        }
    }

    public static class RomanNumeralConverter
    {
        private static List<string> romans = new List<string> { "M" ,"D", "C", "L", "X", "V", "I" };
        private static List<int> arabics = new List<int> { 1000, 500, 100, 50, 10, 5, 1 };

        public static string ToRoman(int arabic)
        {
            var n = arabic;
            var roman = new StringBuilder();

            while (n > 0)
            {
                var nextArabic = arabics.Where(a => a <= n).Max();
                roman.Append(romans[arabics.IndexOf(nextArabic)]);
                n -= nextArabic;
            }
            
            return roman.ToString();
        }
    }
}
