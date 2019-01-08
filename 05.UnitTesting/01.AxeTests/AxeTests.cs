using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        private const int DummyHealth = 10;
        private const int DummyExperiance = 10;

        private Dummy dummy;

        [SetUp]
        public void Setup()
        {
            this.dummy = new Dummy(DummyHealth, DummyExperiance);


        }

        [Test]
        public void TestIfWeaponLosesDurabilityAfterAttack()
        {
            int attackPoints = 10;
            int durability = 10;
            //Arrange
            Axe axe = new Axe(attackPoints, durability);

            //Act
            axe.Attack(dummy);
            
            var expectedResult = 9;
            var actualResult = axe.DurabilityPoints;

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(10,0)]
        [TestCase(5,-1)]
        public void TestAttackingWithBrokenWeapon(int attackPoints, int durability)
        {
            //int attackPoints = 10;
            //int durability = 0;

            Axe axe = new Axe(attackPoints, durability);

            Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
            //Assert.Throws(typeof(InvalidOperationException), () => axe.Attack(dummy));
        }
    }
}