using System.Diagnostics;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ItunesCache.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void MethodName_Scenario_Expectation()
        {
            //Arrange

            Data.ProgressMade += Instance_ProgressMade;

            //Act
            //Data.Instance.InitialiseFromItunes();
            Data.Instance.InitialiseFromStaticFile();

            //foreach (SearchTrack searchTrack in Data.Instance.SearchTracks)
            //{
            //}

            //Assert
            Assert.Inconclusive();

            // Cleanup
        }

        private static void Instance_ProgressMade(object sender, Data.ProgressMadeEventArgs args)
        {
            Debug.WriteLine(args.Value + @" / " + args.MaxValue);
        }
    }
}
