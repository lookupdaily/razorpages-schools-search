using SchoolPerformanceTablesMock.Pages.Schools;
using SchoolPerformanceTablesMock.Models;
using SchoolPerformanceTablesMock.Services.Interfaces;

namespace SchoolPerformanceTablesMock.Test.Pages.Schools;

public class IndexPageTests
{
    private readonly Mock<IRepository<School>> _mockRepository;


    public IndexPageTests()
    {
        _mockRepository = new Mock<IRepository<School>>();
    }

    [Fact]
    public async Task OnGetAsync_PopulatesThePageModel_WithAListOfSchools()
    {
        // Arrange
        IList<School> expectedSchools = GetSampleSchools();
        _mockRepository.Setup(x => x.GetAll()).ReturnsAsync(GetSampleSchools);
        var pageModel = new IndexModel(_mockRepository.Object);

        // Act
        await pageModel.OnGetAsync();

        // Assert
        IList<School> actualSchools = pageModel.School;
        actualSchools.Should().ContainItemsAssignableTo<School>();
        actualSchools.Select(school => school.Name).Should().Equal(expectedSchools.Select(school => school.Name));
    }

    private IList<School> GetSampleSchools()
    {
        IList<School> output = new List<School>
        {
            new()
            {
                Name = "Our Lady's Convent High School",
                SchoolType = "Voluntary aided school",
                MinAge = 11,
                MaxAge = 18,
                OfstedRating = "Good",
                Website = "www.olc.edu",
                EducationPhase = "Secondary",
                LocalAuthority = "Hackney"
            },

            new()
            {
                Name = "St Anne's RC Primary",
                SchoolType = "Maintained",
                MinAge = 4,
                MaxAge = 11,
                OfstedRating = "Outstanding",
                Website = "www.stannes.edu",
                EducationPhase = "Primary",
                LocalAuthority = "Tower Hamlets"
            },

            new()
            {
                Name = "Orchard",
                SchoolType = "Academy",
                MinAge = 4,
                MaxAge = 11,
                OfstedRating = "Poor",
                Website = "www.orchard.edu",
                EducationPhase = "Primary",
                LocalAuthority = "Hackney"
            }
        };
        return output;
    }
}