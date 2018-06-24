using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace seleniumtraining.tests
{
    [TestFixture]
    public class AddToCartPageObject: TestBase
    {
        [Test]
        public void AddToCart_PageObject()
        {
            app.AddToCart("Green Duck");
        }
    }
}
