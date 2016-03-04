using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntityClassLibrary;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;


namespace ProjectTests
{
    [TestClass]
    public class DatabaseTests
    {
        [TestMethod]
        public void test_GetItems_Calls_Read_Database_Method_Of_sqlDatabaseReader_When_Called()
        {
            //Arrange
            Mock<SqlDatabaseReader> mockDB = new Mock<SqlDatabaseReader>();
            Repository repo= new Repository(mockDB.Object);

            //Act
            List<Category> ListOfCategory = repo.GetItems();

            //Assert
            mockDB.Verify(r => r.ReadQuantity(), Times.Once);
        }

        [TestMethod]
        public void test_GetAllItems_ReturnsListOfItemsItReceivesFromReadAllMethodOfReadItemCommand_WhenCalled()
        {
            //Arrange

            Mock<SqlDatabaseReader> mockDB = new Mock<SqlDatabaseReader>();
            mockDB.Setup(r => r.ReadQuantity()).Returns(new List<Category>());
            Repository repo = new Repository(mockDB.Object);

            //Act
            var resultList = repo.GetItems();
            //Assert
            CollectionAssert.AreEqual(resultList, new List<Category>());
        }

        //Testing non quesy scenarios
        //[TestMethod]
        //public void Test_CreateCategory_saves_a_category_via_context()
        //{
        //    var mockSet = new Mock<DbSet<Category>>();
        //    var mockContext = new Mock<ProjectEntities>();
        //    mockContext.Setup(m => m.Categories).Returns(mockSet.Object);

        //    var method = new DatabaseMethods(mockContext.Object);
        //    method.AddCategory(1000, "Dresses");

        //    mockSet.Verify(m => m.Add(It.IsAny<Category>()), Times.Once());
        //    mockContext.Verify(m => m.SaveChanges(), Times.Once());
 
        //}


        // [TestMethod]
        //public void GetAllCategory_orders_by_CategoryName()
        //{
        //    Mock<ProjectEntities> projectEntites = new Mock<ProjectEntites>();
        //     var data = new List<Category>
        //    {
        //        new Category { CategoryName = "Dresses" },
        //        new Category { CategoryName = "Skirts" },
        //        new Category { CategoryName = "Tops" },
        //    }.AsQueryable();

        //    //var mockSet = new Mock<DbSet<Category>>();
        //    mockSet.As<IQueryable<Category>>().Setup(m => m.Provider).Returns(data.Provider);
        //    mockSet.As<IQueryable<Category>>().Setup(m => m.Expression).Returns(data.Expression);
        //    mockSet.As<IQueryable<Category>>().Setup(m => m.ElementType).Returns(data.ElementType);
        //    mockSet.As<IQueryable<Category>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

        //    var mockContext = new Mock<ProjectEntities>();
        //    mockContext.Setup(c => c.Categories).Returns(mockSet.Object);

        //    var service = new DatabaseMethods(mockContext.Object);
        //    var categories = service.GetAllCategory();

        //    Assert.AreEqual(3, categories.Count);
        //    Assert.AreEqual("Dresses", categories[0].CategoryName);
        //    Assert.AreEqual("Skirts", categories[1].CategoryName);
        //    Assert.AreEqual("Tops", categories[2].CategoryName);
        //}

        [TestMethod]
        public void GetAllCategory_orders_by_CategoryId()
        {
            var data = new List<Category>
            {
                new Category { CategoryId = 1000 },
                new Category { CategoryId = 1001 },
                new Category { CategoryId = 1002 },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Category>>();
            mockSet.As<IQueryable<Category>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Category>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Category>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Category>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ProjectEntities>();
            mockContext.Setup(c => c.Categories).Returns(mockSet.Object);

            var service = new DatabaseMethods(mockContext.Object);
            var categories = service.GetAllCategory();

            Assert.AreEqual(3, categories.Count);
            Assert.AreEqual(1000, categories[0].CategoryId);
            Assert.AreEqual(1001, categories[1].CategoryId);
            Assert.AreEqual(1002, categories[2].CategoryId);
        }

        [TestMethod]
        public void GetAllCategory_orders_by_CategoryName_and_CategoryId()
        {
            var data = new List<Category>
            {
                new Category { CategoryId = 1000, CategoryName="Dresses"},
                new Category { CategoryId = 1001, CategoryName="Skirts"},
                new Category { CategoryId = 1002, CategoryName="Tops"},
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Category>>();
            mockSet.As<IQueryable<Category>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Category>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Category>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Category>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ProjectEntities>();
            mockContext.Setup(c => c.Categories).Returns(mockSet.Object);

            var service = new DatabaseMethods(mockContext.Object);
            var categories = service.GetAllCategory();

            Assert.AreEqual(3, categories.Count);
            Assert.AreEqual(1000, categories[0].CategoryId, "Dresses", categories[0].CategoryName);
            Assert.AreEqual(1001, categories[1].CategoryId, "Skirts", categories[0].CategoryName);
            Assert.AreEqual(1002, categories[2].CategoryId, "Tops", categories[0].CategoryName);
        }

        [TestMethod]
        public void CreateCategory_saves_a_category_via_context()
        {
            var mockSet = new Mock<DbSet<Category>>();

            var mockContext = new Mock<ProjectEntities>();
            mockContext.Setup(m => m.Categories).Returns(mockSet.Object);

            var service = new DatabaseMethods(mockContext.Object);
            service.AddCategory(1004, "Trousers");

            mockSet.Verify(m => m.Add(It.IsAny<Category>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestMethod]
        public void CreateCategory_saves_two_categories_via_context()
        {
            var mockSet = new Mock<DbSet<Category>>();

            var mockContext = new Mock<ProjectEntities>();
            mockContext.Setup(m => m.Categories).Returns(mockSet.Object);

            var service = new DatabaseMethods(mockContext.Object);
            service.AddCategory(1004, "Trousers");
            service.AddCategory(1005, "Trousers");

            mockSet.Verify(m => m.Add(It.IsAny<Category>()));
            mockContext.Verify(m => m.SaveChanges());
        }


    }
}
