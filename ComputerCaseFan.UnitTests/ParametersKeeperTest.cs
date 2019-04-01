using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ComputerCaseFan.UnitTests
{
    public class ParametersKeeperTest
    {
        private ParametersKeeper _keeper;

        [SetUp]
        public void InitParameterKeeper()
        {
            _keeper = new ParametersKeeper(20, 2, 0.15, 6, 15);

        }

        [Test(Description = "Позитивный тест геттера FrameLength")]
        public void TestFrameLengthGet_CorrectValue()
        {
            var expected = 20;

            var actual = _keeper.FrameLength;

            Assert.AreEqual(expected, actual, "Геттер FrameLength возвращает неправильное значение");
        }

        [Test(Description = "Позитивный тест геттера HolesDiameter")]
        public void TestHolesDiameterGet_CorrectValue()
        {
            var expected = 2;

            var actual = _keeper.HolesDiameter;

            Assert.AreEqual(expected, actual, "Геттер HolesDiameter возвращает неправильное значение");
        }

        [Test(Description = "Позитивный тест геттера BladeThickness")]
        public void TestBladeThicknessGet_CorrectValue()
        {
            var expected = 0.15;

            var actual = _keeper.BladeThickness;

            Assert.AreEqual(expected, actual, "Геттер BladeThickness возвращает неправильное значение");
        }

        [Test(Description = "Позитивный тест геттера BladesQuantity")]
        public void TestBladesQuantityGet_CorrectValue()
        {
            var expected = 6;

            var actual = _keeper.BladesQuantity;

            Assert.AreEqual(expected, actual, "Геттер BladesQuantity возвращает неправильное значение");
        }

        [Test(Description = "Позитивный тест геттера BladeTurn")]
        public void TestBladeTurnGet_CorrectValue()
        {
            var expected = 15;

            var actual = _keeper.BladeTurn;

            Assert.AreEqual(expected, actual, "Геттер BladeTurn возвращает неправильное значение");
        }


        [TestCase(20, 2, 0.15, 6, 15, TestName = "Тест конструктора ParametersKeeper")]
        public void TestParametersKeeperConstructor(double expectedFrameLength, double expectedHolesDiameter, 
            double expectedBladeThickness, int expectedBladesQuantity, double expectedBladeTurn)
        {
            Assert.AreEqual(expectedFrameLength, _keeper.FrameLength);
            Assert.AreEqual(expectedHolesDiameter, _keeper.HolesDiameter);
            Assert.AreEqual(expectedBladeThickness, _keeper.BladeThickness);
            Assert.AreEqual(expectedBladesQuantity, _keeper.BladesQuantity);
            Assert.AreEqual(expectedBladeTurn, _keeper.BladeTurn);
        }

    }
}
