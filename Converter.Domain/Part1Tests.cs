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

        [TestMethod]
        public void OnePowerLessThan_ReturnsPrefixed()
        {
            Assert.AreEqual("IV", RomanNumeralConverter.ToRoman(4));
            Assert.AreEqual("IX", RomanNumeralConverter.ToRoman(9));
            Assert.AreEqual("XIV", RomanNumeralConverter.ToRoman(14));
            Assert.AreEqual("XIX", RomanNumeralConverter.ToRoman(19));
            Assert.AreEqual("XXIV", RomanNumeralConverter.ToRoman(24));
            Assert.AreEqual("XXIX", RomanNumeralConverter.ToRoman(29));
            Assert.AreEqual("XXXIV", RomanNumeralConverter.ToRoman(34));
            Assert.AreEqual("XXXIX", RomanNumeralConverter.ToRoman(39));
            Assert.AreEqual("XL", RomanNumeralConverter.ToRoman(40));
            Assert.AreEqual("XC", RomanNumeralConverter.ToRoman(90));
            Assert.AreEqual("CD", RomanNumeralConverter.ToRoman(400));
            Assert.AreEqual("CM", RomanNumeralConverter.ToRoman(900));
            Assert.AreEqual("MCD", RomanNumeralConverter.ToRoman(1400));
        }
    }

    public static class RomanNumeralConverter
    {
        private static List<string> romans = new List<string> { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
        private static List<int> arabics = new List<int> { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };

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
