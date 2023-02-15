using Microsoft.AspNetCore.Mvc;
using SchoolPerformanceTablesMock.Models;
using SchoolPerformanceTablesMock.Pages.Schools;
using SchoolPerformanceTablesMock.Services.Interfaces;

namespace SchoolPerformanceTablesMock.Test.Pages.Schools;

public class DetailsPageTests
{
    private readonly Mock<IRepository<School>> _mockRepository;

    public DetailsPageTests()
    {
        _mockRepository = new Mock<IRepository<School>>();
    }
    [Fact]

    public async Task OnGetAsync_FetchesSchoolDetails()
    {
        // Arrange
        School expectedSchool = GetSampleSchool();
        
        _mockRepository.Setup(repository => repository.GetById(1))
            .ReturnsAsync(GetSampleSchool);
        var pageModel = new DetailsModel(_mockRepository.Object);

        // Act
        await pageModel.OnGetAsync(1);
        
        // Assert

        School actualSchool = pageModel.School;
        actualSchool.Should().BeEquivalentTo(expectedSchool);
    }

    [Fact]
    public async Task OnGetAsync_WithNonExistingId_ShouldReturn404()
    {
        // Arrange
        _mockRepository.Setup(repository => repository.GetById(1).Result)
            .Returns((School?)null);
        var pageModel = new DetailsModel(_mockRepository.Object);

        // Act
        var result = await pageModel.OnGetAsync(1);
        
        // Assert
        result.Should().BeOfType<NotFoundResult>("Because no school is found");
    }

    private School GetSampleSchool() =>
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
        };
}