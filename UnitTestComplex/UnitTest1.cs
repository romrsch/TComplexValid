using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TComplexValid;
namespace UnitTestComplex
{
    [TestClass]
    public class UnitTest1
    {
        // Тест для создания комплексного числа из вызова типа TComplex(real, im):
        [TestMethod]
        public void TestTComplexCreation()
        {
            TComplex complexNum = new TComplex(2.5, 4.5);
            Assert.AreEqual(2.5, complexNum.real);
            Assert.AreEqual(4.5, complexNum.im);
        }

        //Тест для операции сложения двух комплексных чисел:
        [TestMethod]
        
        public void TestTComplexAddition()
        {
            TComplex complexNum1 = new TComplex(2.5, 3.5);
            TComplex complexNum2 = new TComplex(1.5, 2.5);
            TComplex result = complexNum1 + complexNum2;
            Assert.AreEqual(4, result.real);
            Assert.AreEqual(6, result.im);
        }
        //Тест на создание комплексного числа из строки, содержащей мнимую часть
        [TestMethod]
        public void TestTComplexConstructorWithImaginaryPart()
        {
            string complexNum = "2-i6";
            bool onlyRealAPP = false;
            TComplex complex = new TComplex(complexNum, onlyRealAPP);
            Assert.AreEqual(2, complex.real);
            Assert.AreEqual(-6, complex.im);
            Assert.AreEqual("2-i6", complex.ToString());
            Assert.IsTrue(complex.ToString().Contains("i"));
        }

        // Тест на сложение двух комплексных чисел
        [TestMethod]
        public void TestTComplexAddition1()
        {
            TComplex a = new TComplex(2.5, 1.5);
            TComplex b = new TComplex(3.5, 2.5);
            TComplex expected = new TComplex(6, 4);

            TComplex actual = a + b;

            Assert.AreEqual(expected.real, actual.real);
            Assert.AreEqual(expected.im, actual.im);
        }

        // Тест для операции вычитания двух комплексных чисел:
        [TestMethod]
        public void TestTComplexSubtraction()
        {
            TComplex complexNum1 = new TComplex(2.5, 3.5);
            TComplex complexNum2 = new TComplex(1.5, 2.5);
            TComplex result = complexNum1 - complexNum2;
            Assert.AreEqual(1, result.real);
            Assert.AreEqual(1, result.im);
        }
        // Тест для операции умножения двух комплексных чисел:
        [TestMethod]
        public void TestTComplexMultiplication()
        {
            TComplex a = new TComplex(2.5, 1.5);
            TComplex b = new TComplex(3.5, 2.5);
            TComplex expected = new TComplex(5, 11.5);
            TComplex actual = a * b;
            Assert.AreEqual(expected.real, actual.real);
            Assert.AreEqual(expected.im, actual.im);
        }

        // Тест для операции деления двух комплексных чисел:
        [TestMethod]
        public void TestTComplexDivision()
        {
            TComplex complexNum1 = new TComplex(2, 5);
            TComplex complexNum2 = new TComplex(5, 5);
            TComplex result = complexNum1 / complexNum2;
            Assert.AreEqual(0.7, result.real);
            Assert.AreEqual(0.3, result.im, 0.0001);
        }
        // тест проверяет, что операция унарного минуса работает корректно для комплексного числа.
        [TestMethod]
        public void TestTComplexMinus()
        {
            TComplex complexNum = new TComplex(2.5, 3.5);
            TComplex result = complexNum.minus();
            Assert.AreEqual(-2.5, result.real);
            Assert.AreEqual(-3.5, result.im);
        }
    }
}
