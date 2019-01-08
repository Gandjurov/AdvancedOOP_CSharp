using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    [TestFixture]
    class DummyTests
    {
        private Dummy dummy;

        [Test]
        public void DummyLosesHealthIfAttacked()
        {
            dummy = new Dummy(10, 10);
            dummy.TakeAttack(5);

            var expectedResult = 5;
            var actualResult = dummy.Health;

            //Assert
            Assert.AreEqual(expectedResult, actualResult, "Dummy doesn't lose health if attacked");

        }

        [Test]
        public void DeadDummyThrowsExpectionIfAttacked()
        {
            dummy = new Dummy(0, 123);

            Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(20), 
                "Dead Dummy doesn't throw invalid operation exception!");
        }

        [Test]
        public void DeadDummyCanGiveXP()
        {
            dummy = new Dummy(0, 123);

            var actualResult = dummy.GiveExperience();
            var expectedResult = 123;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void AliveDummyCantGiveXP()
        {
            dummy = new Dummy(10, 123);

            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
        }
    }
}
