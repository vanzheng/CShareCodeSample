using Business;
using Domain;
using NUnit.Framework;

namespace NHibernateSampleTests
{
    /// <summary>
    /// Summary description for SampleTests
    /// </summary>
    [TestFixture]
    public class SampleTests
    {
        [Test]
        public void GetProductByIdTest()
        {
            Product product = new Product()
            {
                Name = "Test 1",
                Category = "cate 1",
                Discontinued = false,
            };
            ProductRepository dal = new ProductRepository();
            dal.Add(product);
            Product model = dal.GetModel(1);
            Assert.AreEqual(1, model.Id);
        }
    }
}
