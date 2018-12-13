using NUnit.Framework;
using StorageMaster.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StorageMaster.Tests.Structure
{
    public class VehicleTests
    {
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
            var vehicleType = GetType("Vehicle");

            var actualProperties = vehicleType.GetProperties();

            var expectedProperties = new Dictionary<string, Type>
            {
                { "Capacity", typeof(int) },
                { "Trunk", typeof(IReadOnlyCollection<Product>) },
                { "IsFull", typeof(bool) },
                { "IsEmpty", typeof(bool) }
            };

            //new[] { "Capacity", "Trunk", "IsFull", "IsEmpty" };

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
            var vehicleType = GetType("Vehicle");

            var expectedMethods = new List<Method>
            {
                new Method(typeof(void), "LoadProduct", typeof(Product)),
                new Method(typeof(Product), "Unload")
            };

            var loadProductMethod = vehicleType.GetMethod("LoadProduct");
            var unloadMethod = vehicleType.GetMethod("Unload");

            Assert.That(loadProductMethod, Is.Not.Null, "LoadProduct method doesn't exists");
            Assert.That(unloadMethod, Is.Not.Null, "Unload method doesn't exists");

            var loadProductReturnType = loadProductMethod.ReturnType == typeof(void);
            var unloadReturnType = unloadMethod.ReturnType == typeof(Product);

            Assert.That(loadProductReturnType, $"LoadProduct invalid return type");
            Assert.That(unloadReturnType, $"Unload invalid return type");
            //foreach (var actualMethod in actualMethods)
            //{
            //    var actualReturnType = actualMethod.ReturnType;
            //    var actualName = actualMethod.Name;
            //    var actualParams = actualMethod.GetParameters();

            //    var expectedMethod = expectedMethods.FirstOrDefault(x => x.Name == actualName);

            //    Assert.That(expectedMethod, Is.Not.Null, $"{expectedMethod.Name} doesn't exists");

            //    var isValidReturnType = expectedMethod.ReturnType == actualReturnType;

            //    Assert.That(isValidReturnType, $"{actualMethod.Name} Invalid return type");

            //    foreach (var actualParam in actualParams)
            //    {
            //        var isValidParams = expectedMethod.InputParameters.Any(x => x.Name == actualParam.Name);

            //        Assert.That(isValidParams, $"{actualMethod.Name} Missing parameter");
            //    }
            //}
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
