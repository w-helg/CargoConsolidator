using CargoConsolidator;
using CargoConsolidatorTests.DataModel;
using Microsoft.EntityFrameworkCore;
using System.IO;
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
            consolidator.AddReport(@"..\..\..\TestData\init1.zip");
            consolidator.AddReport(@"..\..\..\TestData\init2.zip");

            consolidator.AddReport(@"..\..\..\TestData\work1.zip");

            using var context = new TestDbContext(options);

            var item1 = context.Items.FirstOrDefault<Item>(x => x.Id == 1);
            
            Assert.That(item1, Is.Not.Null);
            Assert.That(item1.Value, Is.EqualTo(33));

            var item2 = context.Items.FirstOrDefault<Item>(x => x.Id == 2);

            Assert.That(item2, Is.Not.Null);
            Assert.That(item2.Value, Is.EqualTo(5));

            var item3 = context.Items.FirstOrDefault<Item>(x => x.Id == 3);

            Assert.That(item3, Is.Not.Null);
            Assert.That(item3.Value, Is.EqualTo(5));
        }

        [TestCase(@"..\..\..\TestData\transfer.zip", Description = "Тест трансфера между известныи складами")]
        [TestCase(@"..\..\..\TestData\carcoIdDuplicate.zip", Description = "Попытка добавить существующий груз")]
        public void T2_AddTransferAndWring(string path)
        {
            int oldValue = 0;

            using (var context = new TestDbContext(options))
            {
                var item = context.Items.FirstOrDefault<Item>(x => x.Id == 1);

                oldValue = item.Value;
            }

            consolidator.AddReport(@"..\..\..\TestData\transfer.zip");

            using (var context = new TestDbContext(options))
            {
                var item = context.Items.FirstOrDefault<Item>(x => x.Id == 1);

                Assert.That(item.Value, Is.EqualTo(oldValue));
            }
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void T4_GetItemAmount(int itemId)
        {
            consolidator.AddReport(@"..\..\..\TestData\work1.zip");

            using var context = new TestDbContext(options);

            var item = context.Items.FirstOrDefault<Item>(x => x.Id == itemId);
            var amount = consolidator.GetAmount(itemId);

            Assert.That(item.Value, Is.EqualTo(amount));
        }
    }
}
