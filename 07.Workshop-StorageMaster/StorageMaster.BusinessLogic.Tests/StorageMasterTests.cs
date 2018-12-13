namespace StorageMaster.BusinessLogic.Tests
{
    using NUnit.Framework;
    using StorageMaster.Entities.Products;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    [TestFixture]
    public class StorageMasterTests
    {
        [Test]
        public void ValidateAddProductMethod()
        {
            var storageMasterType = this.GetType("StorageMaster");
            var addProductMethod = storageMasterType.GetMethod("AddProduct");

            var instance = Activator.CreateInstance(storageMasterType);

            string productType = "SolidStateDrive";
            double price = 230.43;

            var actualResult = addProductMethod.Invoke(instance, new object[] { productType, price });
            var expectedResult = $"Added SolidStateDrive to pool";

            Assert.AreEqual(expectedResult, actualResult);

            var productPoolField = (IDictionary<string, Stack<Product>>)storageMasterType
                                            .GetField("productsPool", (BindingFlags)62)
                                            .GetValue(instance);
            
            Assert.That(productPoolField[productType].Count, Is.EqualTo(1));
        }

        private Type GetType(string type)
        {
            var targetType = typeof(StartUp)
                .Assembly
                .GetTypes()
                .FirstOrDefault(x => x.Name == type);

            return targetType;
        }
    }
}
