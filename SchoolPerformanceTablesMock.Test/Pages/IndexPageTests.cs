using Microsoft.Build.Framework;
using Microsoft.Extensions.Logging;
using SchoolPerformanceTablesMock.Pages;
using Microsoft.Extensions.Logging.Abstractions;

namespace SchoolPerformanceTablesMock.Test.Pages;

public class IndexPageTests
{
    private readonly IndexModel _model;

    public IndexPageTests()
    {
        //arrange
        ILogger<IndexModel> loggerMock = new NullLogger<IndexModel>();
        _model = new IndexModel(loggerMock);

    }

    [Fact]
    public void OnGet_LoadsWelcomePage()
    {
        
    }
}