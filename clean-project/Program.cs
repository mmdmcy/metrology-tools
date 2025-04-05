using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// API Controllers as Minimal API endpoints
var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddSingleton<IHolidayService, HolidayService>();
builder.Services.AddSingleton<IPlannerService, PlannerService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Use middleware
app.UseStaticFiles();
app.UseCors("AllowAll");

// Holiday Helper endpoints
app.MapGet("/api/holiday/availability/{employeeId}", async (string employeeId, IHolidayService service) =>
{
    var result = await service.GetAvailability(employeeId);
    return Results.Ok(result);
});

app.MapGet("/api/holiday/availability/competency/{competency}", async (string competency, IHolidayService service) =>
{
    var result = await service.GetAvailabilityByCompetency(competency);
    return Results.Ok(result);
});

app.MapPost("/api/holiday/submit", async (VacationRequest request, IHolidayService service) =>
{
    var result = await service.SubmitVacationRequest(request);
    return Results.Ok(result);
});

// PI Planner endpoints
app.MapGet("/api/planner/{programIncrement}", async (int programIncrement, IPlannerService service) =>
{
    var result = await service.GetFeatures(programIncrement);
    return Results.Ok(result);
});

app.MapPost("/api/planner/feature", async (Feature feature, IPlannerService service) =>
{
    var result = await service.AddFeature(feature);
    return Results.Ok(result);
});

app.MapPut("/api/planner/feature", async (Feature feature, IPlannerService service) =>
{
    var result = await service.UpdateFeature(feature);
    return Results.Ok(result);
});

app.MapPut("/api/planner/feature/move", async (dynamic data, IPlannerService service) =>
{
    var featureId = data.featureId.ToString();
    var targetPi = (int)data.targetPi;
    var result = await service.MoveFeature(featureId, targetPi);
    return Results.Ok(result);
});

// Root and test endpoint
app.MapGet("/", () => Results.Redirect("/index.html"));
app.MapGet("/api/hello", () => new { message = "Hello from Metrology Tools API" });

// Specify binding URL
app.Urls.Add("http://localhost:5179");

app.Run();

// Models
public class VacationRequest
{
    public string EmployeeId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public double FTEPercentage { get; set; }
    public string CompetencyArea { get; set; }
}

public class Feature
{
    public string Id { get; set; }
    public string Title { get; set; }
    public int StoryPoints { get; set; }
    public string AssignedTeam { get; set; }
    public string Status { get; set; }
    public int ProgramIncrement { get; set; }
}

// Services
public interface IHolidayService
{
    Task<List<VacationRequest>> GetAvailability(string employeeId);
    Task<List<VacationRequest>> GetAvailabilityByCompetency(string competency);
    Task<bool> SubmitVacationRequest(VacationRequest request);
}

public class HolidayService : IHolidayService
{
    private static readonly List<VacationRequest> _requests = new List<VacationRequest>();

    public Task<List<VacationRequest>> GetAvailability(string employeeId)
    {
        var result = _requests.Where(r => r.EmployeeId == employeeId).ToList();
        return Task.FromResult(result);
    }
    
    public Task<List<VacationRequest>> GetAvailabilityByCompetency(string competency)
    {
        var result = _requests.Where(r => r.CompetencyArea == competency).ToList();
        return Task.FromResult(result);
    }

    public Task<bool> SubmitVacationRequest(VacationRequest request)
    {
        _requests.Add(request);
        return Task.FromResult(true);
    }
}

public interface IPlannerService
{
    Task<List<Feature>> GetFeatures(int programIncrement);
    Task<bool> AddFeature(Feature feature);
    Task<bool> UpdateFeature(Feature feature);
    Task<bool> MoveFeature(string featureId, int targetPi);
}

public class PlannerService : IPlannerService
{
    private static readonly List<Feature> _features = new List<Feature>();

    public Task<List<Feature>> GetFeatures(int programIncrement)
    {
        var result = _features.Where(f => f.ProgramIncrement == programIncrement).ToList();
        return Task.FromResult(result);
    }

    public Task<bool> AddFeature(Feature feature)
    {
        _features.Add(feature);
        return Task.FromResult(true);
    }

    public Task<bool> UpdateFeature(Feature feature)
    {
        var index = _features.FindIndex(f => f.Id == feature.Id);
        if (index == -1) return Task.FromResult(false);
        
        _features[index] = feature;
        return Task.FromResult(true);
    }

    public Task<bool> MoveFeature(string featureId, int targetPi)
    {
        var feature = _features.FirstOrDefault(f => f.Id == featureId);
        if (feature == null) return Task.FromResult(false);
        
        feature.ProgramIncrement = targetPi;
        return Task.FromResult(true);
    }
}
