namespace SchoolPerformanceTablesMock.Models;

public class School
{
     public int Id { get; set; }
     public string? Name { get; set; }
     public string? SchoolType { get; set; }
     public int MinAge { get; set; }
     public int MaxAge { get; set; }
     //TODO: add ofsted rating lookup
     public string? OfstedRating { get; set; }
     public string? Website { get; set; }
     //TODO: add education phase lookup
     public string? EducationPhase { get; set; }
     //TODO: add local authority lookup
     public string? LocalAuthority { get; set; }
}