using CargoConsolidator;
using CargoConsolidatorTests.DataModel;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CargoConsolidatorTests
{
    [TestFixture]
    public class ConsolidatorTest
    {
        DbContextOptions<TestDbContext> options;
        ICargoConsolidator consolidator;

        [OneTimeSetUp]
        public void OntimeSetup()
        {
            options = new DbContextOptionsBuilder<TestDbContext>()
                .UseInMemoryDatabase("testDb")
                .Options;

            consolidator = new CargoConsolidatorBuilder()
                .SetConnectionString("Data Source=testDb;Mode=Memory;Cache=Shared")
                .Build();
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void T1_AddReports()
        {
            //TODO Добавить xml репорт
            //TODO Добавить json репорт
            //TODO Проверить количество
            Assert.Pass();
        }

        [Test]
        public void T2_SentBetweenKnownStorages()
        {
            Assert.Pass();
        }

        [Test]
        public void T3_TryAddKnownCargo()
        {
            Assert.Pass();
        }
    }
}