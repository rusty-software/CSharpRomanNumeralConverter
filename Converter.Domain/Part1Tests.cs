using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

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
    }

    public static class RomanNumeralConverter
    {
        private static Dictionary<int, string> arabicRomanMap = new Dictionary<int, string>
        {
            {1, "I"},
            {5, "V"},
            {10, "X"},
            {50, "L"},
            {100, "C"},
            {500, "D"},
            {1000, "M"},
        };

        public static string ToRoman(int arabic)
        {
            return arabicRomanMap[arabic];
        }
    }
}
