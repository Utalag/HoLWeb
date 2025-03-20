using Microsoft.VisualStudio.TestTools.UnitTesting;
using HoLWeb.DataLayer.Database;
using HoLWeb.DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System.Threading.Tasks;

//using Xunit;

namespace HoLWeb.DataLayerTests.Repositories
{
    //[TestClass]
    //public class GenericRepositoryTests
    //{
    //    private HoLWebDbContext _context;
    //    private GenericRepository<World> _repository;

    //    [TestInitialize]
    //    public void Setup()
    //    {
    //        var options = new DbContextOptionsBuilder<HoLWebDbContext>()
    //            .UseInMemoryDatabase(databaseName: "TestDatabase")
    //            .Options;

    //        _context = new HoLWebDbContext(options);
    //        var logger = new Logger<DbSet<World>>(new NullLoggerFactory());
    //        _repository = new WorldRepository(_context,logger);
    //    }

    //    [TestMethod]
    //    public async Task UpdateAsync_ShouldUpdateEntity()
    //    {
    //        // Arrange
    //        var world = new World { Id = 1,WorldName = "Test World" };
    //        _context.Worlds.Add(world);
    //        await _context.SaveChangesAsync();

    //        // Act
    //        world.WorldName = "Updated World";
    //        var result = await _repository.UpdateAsync(world);

    //        // Assert
    //        var updatedWorld = await _context.Worlds.FindAsync(world.Id);
    //        Assert.IsNotNull(updatedWorld);
    //        Assert.AreEqual("Updated World",updatedWorld.WorldName);
    //    }
    //}
}