using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Provider;
using EntityProj;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        //Todo rename test methods for clear description
        public void TestMethod1()
        {
            RepoProvider repo= new RepoProvider();
            var testResult =repo.GetCategoryWithProducts("Cars");
            Assert.IsInstanceOfType(testResult, typeof(IEnumerable<Category>));
        }
        [TestMethod]
        public void TestMethod2()
        {
            string inputCategory = "Cars";
            RepoProvider repo = new RepoProvider();
            var testResult = repo.GetCategoryWithProducts(inputCategory);
            foreach (var item in testResult) {
                Assert.AreEqual<string>(item.CategoryName, inputCategory);
            }
            }
    }
}
