namespace FestivalManager.Tests
{
    using FestivalManager.Core.Controllers;
    using FestivalManager.Core.Controllers.Contracts;
    using FestivalManager.Entities;
    using FestivalManager.Entities.Contracts;
    using FestivalManager.Entities.Sets;
    using NUnit.Framework;
    using System.Collections.Generic;

    [TestFixture]
	public class SetControllerTests
    {
		[Test]
	    public void Test()
	    {
            IStage stage = new Stage();
            ISetController setController = new SetController(stage);

            ISet set = new Short("set1");
            stage.AddSet(set);

            string expectedResult = "1. set1:\r\n-- Did not perform";
            string actualResult = setController.PerformSets();

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
	}
}