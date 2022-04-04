using System;
using NUnit.Framework;
using Model;

namespace UnitTests.Model
{
    /// <summary>
    /// Набор тестов для класса Run
    /// </summary>
    [TestFixture]
    class RunTest
    {
        /// <summary>
        /// Тестирование свойства P1 на позитивных тестах
        /// </summary>
        /// <param name="value">Значение свойства P1</param>
        /// <param name="expected">Ожидаемое значение</param>
        [Test]
        [TestCase(5, 5, TestName = "Тестирование P1 при присваивании 5.")]
        [TestCase(100, 100, TestName = "Тестирование P1 при присваивании 100 значения")]
        public void P1PosTest(int value, int expected)
        {
            var run = new Run();
            run.P1 = value;
            Assert.AreEqual(expected, run.P1);
        }

        /// <summary>
        /// Тестирование свойства P1 на негативных тестах
        /// </summary>
        /// <param name="value">Значение свойства P1</param>
        /// <param name="expectedException">Ожидаемое исключение</param>
        [TestCase(-1, typeof(ArgumentException), TestName = "Тестирование P1 при присваивании -1")]
        [TestCase(int.MinValue, typeof(ArgumentException), TestName = "Тестирование P1 при присваивании min значения")]
        public void P1NegTest(int value, Type expectedException)
        {
            var run = new Run();
            Assert.Throws(expectedException, () => run.P1 = value);
        }

        /// <summary>
        /// Тестирование свойства P2 на позитивных тестах
        /// </summary>
        /// <param name="value">Значение свойства P2</param>
        /// <param name="expected">Ожидаемое значение</param>
        [Test]
        [TestCase(5, 5, TestName = "Тестирование P2 при присваивании 5.")]
        [TestCase(100, 100, TestName = "Тестирование P2 при присваивании 100 значения")]
        public void P2PosTest(int value, int expected)
        {
            var run = new Run();
            run.P2 = value;
            Assert.AreEqual(expected, run.P2);
        }

        /// <summary>
        /// Тестирование свойства P2 на негативных тестах
        /// </summary>
        /// <param name="value">Значение свойства P2</param>
        /// <param name="expectedException">Ожидаемое исключение</param>
        [TestCase(-1, typeof(ArgumentException), TestName = "Тестирование P2 при присваивании -1")]
        [TestCase(double.MinValue, typeof(ArgumentException), TestName = "Тестирование P2 при присваивании min значения")]
        public void P2NegTest(double value, Type expectedException)
        {
            var run = new Run();
            Assert.Throws(expectedException, () => run.P2 = value);
        }

        /// <summary>
        /// Тестирование метода Spend на позитивных тестах
        /// </summary>
        /// <param name="value1">Значение свойства P1</param>
        /// <param name="value2">Значение свойства P2</param>
        /// <param name="expected">Ожидаемое значение</param>
        [Test]
        [TestCase(0, 0, 0, TestName = "Тестирование Run.Spend при значениях P1 = 0 и P2 = 0.")]
        [TestCase(5, 5, 300, TestName = "Тестирование Run.Spend при значениях P1 = 5 и P2 = 5.")]
        [TestCase(2, 100, 2400, TestName = "Тестирование Run.Spend при значениях P1 = 2 и P2 = 100.")]
        [TestCase(1000, 1000, 12000000, TestName = "Тестирование Run.Spend при значениях P1 = 1000 и P2 = 1000.")]

        public void SpendPosTest(int value1, double value2, double expected)
        {
            var run = new Run();
            run.P1 = value1;
            run.P2 = value2;
            Assert.AreEqual(expected, run.Spend());
        }

        /// <summary>
        /// Тестирование метода Spend на негативном тесте
        /// </summary>
        /// <param name="value1">Значение свойства P1</param>
        /// <param name="value2">Значение свойства P2</param>
        /// <param name="expectedException">Значение исключения</param>
        [Test]
        [TestCase(int.MaxValue, double.MaxValue, typeof(OverflowException), TestName = "Тестирование Run.Spend при max значениях")]

        public void SpendNegTest(int value1, double value2, Type expectedException)
        {
            var run = new Run();
            run.P1 = value1;
            run.P2 = value2;
            try
            {
                checked
                {
                    run.Spend();
                }
            }
            catch (OverflowException ex)
            {
                expectedException = ex.GetType();
            }
        }
    }
}