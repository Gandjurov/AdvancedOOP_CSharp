using NUnit.Framework;
using StorageMaster.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace StorageMaster.Tests.Structure
{
    [TestFixture]
    public class VehicleTests
    {
        private Type vehicle;

        [SetUp]
        public void SetUp()
        {
            this.vehicle = this.GetType("Vehicle");
        }

        //Validate entities
        [Test]
        public void ValidateAllVehicles()
        {
            var types = new[]
            {
                "Semi",
                "Truck",
                "Van",
                "Vehicle"
            };

            foreach (var type in types)
            {
                var currentType = GetType(type);

                Assert.That(currentType, Is.Not.Null, $"{type} doesn't exists");
            }
        }

        [Test]
        public void ValidateVehicleProperties()
        {
            //typeof(Vehicle)
            var actualProperties = vehicle.GetProperties();

            var expectedProperties = new Dictionary<string, Type>
            {
                { "Capacity", typeof(int) },
                { "Trunk", typeof(IReadOnlyCollection<Product>) },
                { "IsFull", typeof(bool) },
                { "IsEmpty", typeof(bool) }
            };

            //return type
            
            foreach (var actualProperty in actualProperties)
            {
                var isValidProperty = expectedProperties.Any(x => x.Key == actualProperty.Name &&
                                      actualProperty.PropertyType == x.Value);

                Assert.That(isValidProperty, $"{actualProperty.Name} doesn't exists!");
            }
        }

        //Existing Methods:
        //void LoadProduct(Product product)
        //Product Unload()
        [Test]
        public void ValidateVehicleMethods()
        {
            var expectedMethods = new List<Method>
            {
                new Method(typeof(void), "LoadProduct", typeof(Product)),
                new Method(typeof(Product), "Unload")
            };

            foreach (var expectedMethod in expectedMethods)
            {
                var currentMethod = vehicle.GetMethod(expectedMethod.Name);

                Assert.That(currentMethod, Is.Not.Null, $"{expectedMethod.Name} method doesn't exists");

                var currentMethodReturnType = currentMethod.ReturnType == expectedMethod.ReturnType;
                Assert.That(currentMethodReturnType, $"{expectedMethod.Name} invalid return type");

                var expectedMethodParams = expectedMethod.InputParameters;
                var actualParams = currentMethod.GetParameters();

                for (int i = 0; i < expectedMethodParams.Length; i++)
                {
                    var actualParam = actualParams[i].ParameterType;
                    var expectedParam = expectedMethodParams[i];

                    Assert.AreEqual(expectedParam, actualParam);
                }
            }

        }

        [Test]
        public void ValidateVehicleFields()
        {
            var trunkField = vehicle.GetField("trunk", BindingFlags.NonPublic | BindingFlags.Instance);

            Assert.That(trunkField, Is.Not.Null, $"Invalid field");
        }

        [Test]
        public void ValidateVehicleIsAbstract()
        {
            Assert.That(vehicle.IsAbstract, $"Vehicle class must be abstract!");
        }

        [Test]
        public void ValidateVehicleChildClasses()
        {
            var derivedTypes = new[]
            {
                GetType("Semi"),
                GetType("Truck"),
                GetType("Van")
            };

            foreach (var derivedType in derivedTypes)
            {
                Assert.That(derivedType.BaseType, Is.EqualTo(vehicle), $"{derivedType} doesn't inherit {vehicle}!");
            }
        }

        private Type GetType(string type)
        {
            var targetType = typeof(StartUp)
                .Assembly
                .GetTypes()
                .FirstOrDefault(x => x.Name == type);

            return targetType;
        }

        private class Method
        {
            public Method(Type returnType, string name, params Type[] inputParams)
            {
                this.ReturnType = returnType;
                this.Name = name;
                this.InputParameters = inputParams;
            }
            public Type ReturnType { get; set; }

            public string Name { get; set; }
            
            public Type[] InputParameters { get; set; }
        }
    }
}
