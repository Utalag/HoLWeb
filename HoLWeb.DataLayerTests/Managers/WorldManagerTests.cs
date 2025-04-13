using Microsoft.VisualStudio.TestTools.UnitTesting;
using HoLWeb.DataLayer.Repositories;
using HoLWeb.DataLayer.Database;
using HoLWeb.DataLayer.Models;
using HoLWeb.BusinessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using AutoMapper;
using System.Threading.Tasks;
using Moq;
using HoLWeb.DataLayer.Interfaces;

namespace HoLWeb.DataLayerTests.Managers
{


    //[TestClass]
    //public class WorldManagerTests
    //{
    //    private WorldManager _worldManager;
    //    private Mock<IWorldRepository> _mockWorldRepository;
    //    private Mock<IRaceRepository> _mockRaceRepository;
    //    private Mock<INarrativeRepository> _mockNarrativeRepository;
    //    private Mock<IThumbImgWorldRepository> _mockThumbImgRepository;
    //    private Mock<IGenericRepository<World>> _mockGenericRepository;
    //    private IMapper _mapper;

    //    [TestInitialize]
    //    public void Setup()
    //    {
    //        var options = new DbContextOptionsBuilder<HoLWebDbContext>()
    //            .UseInMemoryDatabase(databaseName: "TestDatabase")
    //            .Options;

    //        var logger = new Logger<DbSet<World>>(new NullLoggerFactory());

    //        var config = new MapperConfiguration(cfg =>
    //        {
    //            cfg.CreateMap<World,WorldDto>()
    //                .ForMember(m => m.RaceIds,opt => opt.MapFrom(m => m.Races.Select(s => s.Id).ToList()))
    //                .ForMember(n => n.NarrativeIds,opt => opt.MapFrom(n => n.Narratives.Select(s => s.Id).ToList()))
    //                .ForMember(img => img.ThumbnailImageId,opt => opt.MapFrom(img => img.ThumbnailImage.Id))
    //                .ForMember(pl => pl.PlayersInWorld,opt => opt.MapFrom(pl => pl.PlayersInWorld.Select(s => s.Id).ToList()))
    //                .ForMember(ignore => ignore.Narratives,opt => opt.Ignore())
    //                .ForMember(ignore => ignore.Races,opt => opt.Ignore())
    //                .ForMember(ignore => ignore.ThumbnailImage,opt => opt.Ignore());

    //            cfg.CreateMap<WorldDto,World>()
    //                .ForMember(m => m.Narratives,opt => opt.Ignore())
    //                .ForMember(m => m.Races,opt => opt.Ignore())
    //                .ForMember(m => m.ThumbnailImage,opt => opt.Ignore());
    //        });

    //        _mapper = config.CreateMapper();
    //        _mockWorldRepository = new Mock<IWorldRepository>();
    //        _mockRaceRepository = new Mock<IRaceRepository>();
    //        _mockNarrativeRepository = new Mock<INarrativeRepository>();
    //        _mockThumbImgRepository = new Mock<IThumbImgWorldRepository>();
    //        _mockGenericRepository = new Mock<IGenericRepository<World>>();

    //        _worldManager = new WorldManager(
    //            logger,
    //            _mapper,
    //            _mockGenericRepository.Object,
    //            _mockRaceRepository.Object,
    //            _mockNarrativeRepository.Object,
    //            _mockThumbImgRepository.Object,
    //            _mockWorldRepository.Object
    //        );
    //    }

    //    private WorldDto TestWorld { get; set; } = new WorldDto
    //    {
    //        WorldName = "New World",
    //        WorldDescription = "Description of the test world",
    //        AmountOfMagicInTheWorld = 50
    //    };

    //    [TestMethod]
    //    public async Task AddDataAsync_ShouldAddEntity()
    //    {
    //        _mockWorldRepository.Setup(repo => repo.InsertAsync(It.IsAny<World>()))
    //            .ReturnsAsync((World world) =>
    //            {
    //                world.Id = 1;
    //                return world;
    //            });

    //        // Act
    //        var result = await _worldManager.AddDataAsync(TestWorld);

    //        // Assert
    //        Assert.IsNotNull(result);
    //        Assert.AreEqual("New World",result.WorldName);
    //        Assert.AreEqual("Description of the test world",result.WorldDescription);
    //        Assert.AreEqual(50,result.AmountOfMagicInTheWorld);
    //        Assert.AreEqual(1,result.Id);
    //    }

    //    [TestMethod]
    //    public async Task UpdateDataAsync_ShouldUpdateEntity()
    //    {
    //        // Arrange
    //        var world = new World
    //        {
    //            Id = 1,
    //            WorldName = "Test World",
    //            WorldDescription = "Initial Description",
    //            AmountOfMagicInTheWorld = 30
    //        };

    //        //_mockWorldRepository.Setup(repo => repo.FindByIdAsync(1))
    //        //    .ReturnsAsync(world);

    //        var updatedWorldDto = new WorldDto
    //        {
    //            Id = 1,
    //            WorldName = "Updated World",
    //            WorldDescription = "Updated Description",
    //            AmountOfMagicInTheWorld = 60
    //        };

    //        _mockWorldRepository.Setup(repo => repo.UpdateAsync(It.IsAny<World>()))
    //            .ReturnsAsync((World w) => w);

    //        // Act
    //        var result = await _worldManager.UpdateDataAsync(updatedWorldDto,1);

    //        // Assert
    //        Assert.IsNotNull(result);
    //        Assert.AreEqual("Updated World",result.WorldName);
    //        Assert.AreEqual("Updated Description",result.WorldDescription);
    //        Assert.AreEqual(60,result.AmountOfMagicInTheWorld);
    //    }
    //}
}