namespace Theatre.Test
{
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Theatre.Core;

    [TestClass]
    public class TheatreTests
    {
        [TestMethod]
        public void AddTheatre_TwoTimes_ShouldReturnCountEqualsTwo()
        {
            var db = new PerformanceDatabase();
            db.AddTheatre("Othelo");
            db.AddTheatre("Romemo and Juliet");

            var actualResult = db.ListTheatres();

            List<string> expectedResult = new List<string>();
            expectedResult.Add("Othelo");
            expectedResult.Add("Romemo and Juliet");
            string b = expectedResult[0];

            int count = 0;
            foreach (var theatre in actualResult)
            {
                string expectedName = expectedResult[count];
                Assert.AreEqual(theatre, expectedName);
                count++;
            }
        }

        [TestMethod]
        public void ListTheatres_NonEmptyList_ShouldReturnAllTheaters()
        {
            var db = new PerformanceDatabase();
            db.AddTheatre("Othelo");
            db.AddTheatre("Romemo and Juliet");

            var results = db.ListTheatres();
            Assert.AreEqual(2, results.Count());
        }
    }
}
