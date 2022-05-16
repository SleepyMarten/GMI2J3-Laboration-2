using NUnit.Framework;
using KeesTalksTech.Utilities.Latin.Numerals;
using System;


namespace RomanNumeralTests
{
    public class RomanNumeralNuTests
    {
        //Note.. Parsing == Parse Roman Numeral string into a number... (FromRomanNumeral)
        //Note...ToString(RomanNumerlNotation) is (ToRomanNumeral)
        //.Number == FromRomanNumeral
        //.ToString == ToRomanNumeral
        [TestFixture]
        public class TestKnownValues
        {
            [TestCase(10)]
            public void TestFromRomanKnownValues(int value)
            {
                Assert.That(value, Is.EqualTo(RomanNumeral.Parse("X").Number));
            }            
            [TestCase("X")]
            public void TestToRomanKnownValues(string value)
            {
                Assert.That(new RomanNumeral(10).ToString(), Is.EqualTo(value));
            }
        }
        [TestFixture]
        public class FromRomanBadInput
        {
            //[SetUp]
            //public void setup()
            //{
            //    var listofnumerals = new List<string>() { "IIMXCC", "VX", "DCM", "CMM", "IXIV", "MCMC", "XCX", "IVI", "LM", "LD", "LC" };
            //}
            [TestCase("ABC")]
            [TestCase("1.5")]
            public void TestFromRomanBadInputString(string value)
            {   
                //Check if it can handle if the string input is bad, it is to return null.
                Assert.IsNull(RomanNumeral.Parse(value));
            }

            [Test]
            public void TestFromRomanMalformedAntecedent()
            {
                var listOfMalformedAntecedent = new List<string>() { "IIMXCC", "VX", "DCM", "CMM", "IXIV", "MCMC", "XCX", "IVI", "LM", "LD", "LC" };

                //assert does not contain format like in RomanNUmeral.NUMERAL_OPTIONS.
                //Assert.That(value,Does.Not.Contain(RomanNumeral.NUMERAL_OPTIONS));
                //Assert.That(RomanNumeral.NUMERAL_OPTIONS, Has.No.Member(value));
                foreach (string numerals in listOfMalformedAntecedent)
                {
                    Assert.That(RomanNumeral.NUMERAL_OPTIONS, Has.No.Member(numerals));
                }
            }
            [Test]
            public void TestFromRomanRepeatedPairs()
            {
                var listOfRepeatedPairs = new List<string>() { "CMCM", "CDCD", "XCXC", "XLXL", "IXIX", "IVIV" };
                foreach (string numerals in listOfRepeatedPairs)
                {
                    Assert.That(RomanNumeral.NUMERAL_OPTIONS, Has.No.Member(numerals));
                }
            }            
            [Test]
            public void TestFromRomanRepeatedNumerals()
            {
                var listOfRepeatedNumerals = new List<string>() { "MMMMM", "DD", "CCCC", "LL", "XXXX", "VV", "IIII" };
                foreach (string numerals in listOfRepeatedNumerals)
                {
                    Assert.That(RomanNumeral.NUMERAL_OPTIONS, Has.No.Member(numerals));
                }
                //Will fail 100000000%
                //new RomanNumeral(22222222).ToString();
            }


        }
        [TestFixture]
        public class ToRomanBadInput
        {
            [TestCase(null)]
            [TestCase("")]
            public void TestFromRomanBadInputNullOrEmpty(string value)
            {
                //Check that "null" or empty string returns "0".
                Assert.Zero(RomanNumeral.Parse(value).Number);
            }

            [TestCase(-1)]
            [TestCase(-3)]
            [TestCase(-2)]
            public void TestToRomanInputNegativeInteger(int value)
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => new RomanNumeral(value).ToString());
            }
        }
    }
}
