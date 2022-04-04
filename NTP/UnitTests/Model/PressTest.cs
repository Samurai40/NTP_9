using System;
using NUnit.Framework;
using Model;

namespace UnitTests.Model
{
    /// <summary>
    /// Набор тестов для класса Press
    /// </summary>
    [TestFixture]
    class PressTest
    {
        /// <summary>
        /// Тестирование метода Spend на позитивных тестах
        /// </summary>
        /// <param name="value1">Значение свойства P1</param>
        /// <param name="value2">Значение свойства P2</param>
        /// <param name="expected">Ожидаемое значение</param>
        [Test]
        [TestCase(0, 0, 0, TestName = "Тестирование Press.Spend при значениях P1 = 0 и P2 = 0.")]
        [TestCase(20, 50, 100, TestName = "Тестирование Press.Spend при значениях P1 = 20 и P2 = 50.")]
        [TestCase(10, 100, 100, TestName = "Тестирование Press.Spend при значениях P1 = 10 и P2 = 100.")]
        [TestCase(1000, 1000, 100000, TestName = "Тестирование Press.Spend при значениях P1 = 1000 и P2 = 1000.")]

        public void SpendPosTest(int value1, double value2, double expected)
        {
            var pres = new Press();
            pres.P1 = value1;
            pres.P2 = value2;
            Assert.AreEqual(expected, pres.Spend());
        }

        /// <summary>
        /// Тестирование метода Spend на негативном тесте
        /// </summary>
        /// <param name="value1">Значение свойства P1</param>
        /// <param name="value2">Значение свойства P2</param>
        /// <param name="expectedException">Значение исключения</param>
        [Test]
        [TestCase(int.MaxValue, double.MaxValue, typeof(OverflowException), TestName = "Тестирование Press.Spend при max значениях")]

        public void SpendNegTest(int value1, double value2, Type expectedException)
        {
            var pres = new Press();
            pres.P1 = value1;
            pres.P2 = value2;
            try
            {
                checked
                {
                    pres.Spend();
                }
            }
            catch (OverflowException ex)
            {
                expectedException = ex.GetType();
            }
        }
    }
}