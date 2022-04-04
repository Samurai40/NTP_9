using System;
using NUnit.Framework;
using Model;

namespace UnitTests.Model
{
    /// <summary>
    /// Набор тестов для класса Swim
    /// </summary>
    [TestFixture]
    class SwimTest
    {
        /// <summary>
        /// Тестирование метода Spend на позитивных тестах
        /// </summary>
        /// <param name="value1">Значение свойства P1</param>
        /// <param name="value2">Значение свойства P2</param>
        /// <param name="expected">Ожидаемое значение</param>
        [Test]
        [TestCase(0, 0, 0, TestName = "Тестирование Swim.Spend при значениях P1 = 0 и P2 = 0.")]
        [TestCase(1, 5, 960, TestName = "Тестирование Swim.Spend при значениях P1 = 1 и P2 = 5.")]
        [TestCase(2, 10, 2560, TestName = "Тестирование Swim.Spend при значениях P1 = 2 и P2 = 10.")]
        [TestCase(1000, 1000, 0, TestName = "Тестирование Swim.Spend при значениях P1 = 1000 и P2 = 1000.")]

        public void SpendPosTest(int value1, double value2, double expected)
        {
            var swim = new Swim();
            swim.P1 = value1;
            swim.P2 = value2;
            Assert.AreEqual(expected, swim.Spend());
        }

        /// <summary>
        /// Тестирование метода Spend на негативном тесте
        /// </summary>
        /// <param name="value1">Значение свойства P1</param>
        /// <param name="value2">Значение свойства P2</param>
        /// <param name="expectedException">Значение исключения</param>
        [Test]
        [TestCase(int.MaxValue, double.MaxValue, typeof(OverflowException), TestName = "Тестирование Swim.Spend при max значениях")]

        public void SpendNegTest(int value1, double value2, Type expectedException)
        {
            var swim = new Swim();
            swim.P1 = value1;
            swim.P2 = value2;
            try
            {
                checked
                {
                    swim.Spend();
                }
            }
            catch (OverflowException ex)
            {
                expectedException = ex.GetType();
            }
        }
    }
}