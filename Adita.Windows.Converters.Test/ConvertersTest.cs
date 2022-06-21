using Microsoft.VisualStudio.TestTools.UnitTesting;
using Adita.Windows.Converters;
using System.Globalization;
using System;

namespace Adita.Windows.Converters.Test
{
    [TestClass]
    public class ConvertersTest
    {
        [TestMethod]
        public void ArithmeticConverterTest()
        {
            const double value = 200d;

            ArithmeticOperationConverter arithmeticOperationConverter = new ArithmeticOperationConverter();
            var result = arithmeticOperationConverter.Convert(value, value.GetType(), "@VALUE*20", CultureInfo.CurrentCulture);

            Assert.AreEqual(result, 4000d);
        }
        [TestMethod]
        public void EqualityTest()
        {
            const double value = 2000;
            const double value1 = 2001;

            EqualityConverter equalityConverter = new EqualityConverter();

            var result = (bool)equalityConverter.Convert(value, value.GetType(), value1, CultureInfo.CurrentCulture);

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void InequalityTest()
        {
            const double value = 2000;
            const double value1 = 2001;

            InequalityConverter inequalityConverter = new InequalityConverter();

            var result = (bool)inequalityConverter.Convert(value, value.GetType(), value1, CultureInfo.CurrentCulture);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void ArrayMultiValueConverterTest()
        {
            object[] array = new object[5];
            array[0] = 10;
            array[1] = 20;
            array[2] = 30;
            array[3] = 40;
            array[4] = 50;

            ArrayMultiValueConverter converter = new ArrayMultiValueConverter();
            var result = (object[])converter.Convert(array, array.GetType(), new object(), CultureInfo.CurrentCulture);

            Assert.AreEqual(5, result.Length);

            for(int i = 0; i < array.Length; i++)
            {
                Assert.AreEqual(array[i], result[i]);
            }

        }
        [TestMethod]
        public void GreaterThanConverterTest()
        {
            GreaterThanConverter converter = new();

            var result = (bool)converter.Convert(25d, typeof(double), 10d, CultureInfo.CurrentCulture);
            Assert.IsTrue(result);

            var result1 = (bool)converter.Convert(25d, typeof(double), 30d, CultureInfo.CurrentCulture);
            Assert.IsFalse(result1);

            var result2 = (bool)converter.Convert(25d, typeof(double), 25d, CultureInfo.CurrentCulture);
            Assert.IsFalse(result2);
        }
        [TestMethod]
        public void GreaterThanOrEqualConverterTest()
        {
            GreaterThanOrEqualConverter converter = new();

            var result = (bool)converter.Convert(25d, typeof(double), 25d, CultureInfo.CurrentCulture);
            Assert.IsTrue(result);

            var result1 = (bool)converter.Convert(35d, typeof(double), 30d, CultureInfo.CurrentCulture);
            Assert.IsTrue(result1);

            var result2 = (bool)converter.Convert(25d, typeof(double), 30d, CultureInfo.CurrentCulture);
            Assert.IsFalse(result2);
        }
        [TestMethod]
        public void LessThanConverterTest()
        {
            LessThanConverter converter = new();

            var result = (bool)converter.Convert(5d, typeof(double), 10d, CultureInfo.CurrentCulture);
            Assert.IsTrue(result);

            var result1 = (bool)converter.Convert(35d, typeof(double), 30d, CultureInfo.CurrentCulture);
            Assert.IsFalse(result1);

            var result2 = (bool)converter.Convert(25d, typeof(double), 25d, CultureInfo.CurrentCulture);
            Assert.IsFalse(result2);
        }
        [TestMethod]
        public void LessThanOrEqualConverterTest()
        {
            LessThanOrEqualConverter converter = new();

            var result = (bool)converter.Convert(25d, typeof(double), 25d, CultureInfo.CurrentCulture);
            Assert.IsTrue(result);

            var result1 = (bool)converter.Convert(5d, typeof(double), 30d, CultureInfo.CurrentCulture);
            Assert.IsTrue(result1);

            var result2 = (bool)converter.Convert(35d, typeof(double), 25d, CultureInfo.CurrentCulture);
            Assert.IsFalse(result2);
        }
        [TestMethod]
        public void NullConverterTest()
        {
            NullConverter converter = new();

            var result = (bool)converter.Convert(null!, null!, null!, CultureInfo.CurrentCulture);
            Assert.IsTrue(result);

            var result1 = (bool)converter.Convert(25, typeof(double), null!, CultureInfo.CurrentCulture);
            Assert.IsFalse(result1);
        }
        [TestMethod]
        public void StringConcatenateConverterTest()
        {
            string string1 = "Test";
            string string2 = "Method";

           object[] strings = new object[] { string1, string2 };

            StringConcatenateConverter converter = new();

            var result = (string)converter.Convert(strings, null!, null!, CultureInfo.CurrentCulture);

            Assert.AreEqual(string.Concat(string1, string2), result);
        }
        [TestMethod]
        public void StringIsNullOrWhiteSpaceConverterTest()
        {
            string string1 = string.Empty;
            string string2 = "";
            string string3 = " ";
            string string4 = "Test";

            StringNullOrWhiteSpaceConverter converter = new();

            var result = (bool)converter.Convert(string1, typeof(string), null!, CultureInfo.CurrentCulture);
            Assert.IsTrue(result);

            var result1 = (bool)converter.Convert(string2, typeof(string), null!, CultureInfo.CurrentCulture);
            Assert.IsTrue(result1);

            var result2 = (bool)converter.Convert(string3, typeof(string), null!, CultureInfo.CurrentCulture);
            Assert.IsTrue(result2);

            var result3 = (bool)converter.Convert(string4, typeof(string), null!, CultureInfo.CurrentCulture);
            Assert.IsFalse(result3);
        }
        [TestMethod]
        public void StringWhiteSpaceRemoverConverterTest()
        {
            string string1 = "Test Method";

            StringWhiteSpaceRemoverConverter converter = new();

            var result = (string)converter.Convert(string1, typeof(string), null!, CultureInfo.CurrentCulture);

            Assert.AreEqual(string1.Replace(" ", ""), result);
        }
        [TestMethod]
        public void TypeConverterTest()
        {
            double test = 100;

            TypeConverter converter = new();

            var result = (Type)converter.Convert(test, typeof(double), null!, CultureInfo.CurrentCulture);

            Assert.AreEqual(test.GetType(), result);
        }
        [TestMethod]
        public void MultiplierMultiValueConverterTest()
        {
            double a = 5;
            double b = 5;

            object[] test = new object[] {a,b}; 

            MultiplierMultiValueConverter converter = new();
            var result = (double)converter.Convert(test, null!, null!, CultureInfo.CurrentCulture);

            Assert.AreEqual(a * b, result);
        }
    }
}