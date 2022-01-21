using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SlightlyHarderTests_w_Fakes
{
    [TestClass]
    public class FavoriteColorGenerator2_WhenGetting_withFakes
    {
      //  [TestMethod]
        public void On_Tuesday_Should_Be_Yellow()
        {

        ////	/****************************************
        ////	 *										*
        ////	 *            DONT USE FAKES			*
        ////	 *										*
        ////	 * *************************************/

            // Shims can be used only in a ShimsContext:
            using (ShimsContext.Create())
           {
                //    // Arrange:
                //    // Shim DateTime.Now to return a fixed date:
                //System.Fakes.ShimDateTime.NowGet = () =>
                //{
                //    return new DateTime(2017, 1, 31); // This was a Tuesday
                //};

                //    // Instantiate the component under test:
                //    var componentUnderTest = new MyComponent();

                //    // Act:
                //    int year = componentUnderTest.GetTheCurrentYear();

                //    // Assert:
                //    // This will always be true if the component is working:
                //    Assert.AreEqual(fixedYear, year);
            }
        }

        // [TestMethod]
        public void On_Wed_Should_Be_Blue()
        {

        }
    }
}