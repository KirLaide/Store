using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Controllers;
using System.Collections.Generic;
using System.Web.Mvc;
using SportsStore.WebUI.HtmlHelpers;

namespace SportsStore.UnitTests
{
    [TestClass]
    public class AdminTests
    {
        [TestMethod]
        public void Index_Contains_All_Product()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]
            {
                new Product {ProductID = 1, Name = "P1"},
                new Product {ProductID = 2, Name = "P2"},
                new Product {ProductID = 3, Name = "P3"},
            });
            AdminController target = new AdminController(mock.Object);
            Product[] result = ((IEnumerable<Product>) target.Index().ViewBag.Model).ToArray();

            Assert.AreEqual(result.Length, 3);
            Assert.AreEqual("P1", result[0].Name);
            Assert.AreEqual("P2", result[1].Name);
            Assert.AreEqual("P3", result[2].Name);
        }
    }
}
