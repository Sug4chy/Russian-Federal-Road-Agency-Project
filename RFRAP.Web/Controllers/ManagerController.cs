using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using RFRAP.Domain.DTOs;
using RFRAP.Domain.Exceptions;
using RFRAP.Domain.Exceptions.Errors;
using RFRAP.Domain.Services.Roads;
using RFRAP.Domain.Services.Segments;
using RFRAP.Domain.Services.VerifiedPoints;

namespace RFRAP.Web.Controllers;


[ApiController]
[Route("/api/[controller]")]
public class ManagerController([FromServices] IVerifiedPointsService verifiedPointsService) : ControllerBase
{
    [HttpPost("new")]
    public async Task CreateVerifiedPointAsync(
        [FromBody] VerifiedPointDto pointDto, 
        [FromServices] IRoadService roadService,
        [FromServices] IValidator<VerifiedPointDto> verifiedPointDtoValidator,
        [FromServices] ISegmentService segmentService,
        CancellationToken ct = default)
    {
        
        var validationResult = await verifiedPointDtoValidator.ValidateAsync(pointDto, ct);
        BadRequestException.ThrowByValidationResult(validationResult);
        
        var road = await roadService.GetRoadByNameAsync(pointDto.RoadName, ct);
        NotFoundException.ThrowIfNull(road, RoadErrors.NoSuchRoadWithName(pointDto.RoadName));

        var segments = await segmentService.GetSegmentsByRoadNameAsync(pointDto.RoadName, ct);

        var segment = segments is null ? null : 
            segmentService.GetNearestSegmentByCoordinates(pointDto.Coordinates, segments);

        await verifiedPointsService.CreateVerifiedPointAsync(pointDto, segment, road!, ct);
    }

    [HttpGet("{verifiedPointId}")]
    public async Task<VerifiedPointDto> GetVerifiedPointAsync(
        Guid verifiedPointId,
        CancellationToken ct = default)
    {
        var point = await verifiedPointsService.GetVerifiedPointAsync(verifiedPointId, ct);
        NotFoundException.ThrowIfNull(point, PointErrors.NoSuchPointWithId(verifiedPointId));

        return new VerifiedPointDto
        {
            Name = point!.Name,
            Coordinates = new PointDto
            {
                Longitude = point.Longitude,
                Latitude = point.Latitude
            },
            Type = point.Type,
            RoadName = point.Road!.Name
        };
    }

    [HttpPut("{verifiedPointId}")]
    public async Task EditVerifiedPointAsync(
        Guid verifiedPointId,
        [FromBody] VerifiedPointDto pointDto,
        [FromServices] IRoadService roadService,
        [FromServices] ISegmentService segmentService,
        [FromServices] IValidator<VerifiedPointDto> validator,
        CancellationToken ct = default)
    {
        var validationResult = await validator.ValidateAsync(pointDto, ct);
        BadRequestException.ThrowByValidationResult(validationResult);
        
        var point = await verifiedPointsService.GetVerifiedPointAsync(verifiedPointId, ct);
        NotFoundException.ThrowIfNull(point, PointErrors.NoSuchPointWithId(verifiedPointId));

        var road = await roadService.GetRoadByNameAsync(pointDto.RoadName, ct);
        NotFoundException.ThrowIfNull(road, RoadErrors.NoSuchRoadWithName(pointDto.RoadName));
        
        var segments = await segmentService.GetSegmentsByRoadNameAsync(pointDto.RoadName, ct);

        var segment = segments is null ? null : 
            segmentService.GetNearestSegmentByCoordinates(pointDto.Coordinates, segments);

        await verifiedPointsService.EditVerifiedPointAsync(point!, pointDto, road!, segment, ct);
    }

    [HttpDelete("{verifiedPointId}")]
    public async Task DeleteVerifiedPoint(
        Guid verifiedPointId, 
        CancellationToken ct = default)
    {
        var point = await verifiedPointsService.GetVerifiedPointAsync(verifiedPointId, ct);
        NotFoundException.ThrowIfNull(point, PointErrors.NoSuchPointWithId(verifiedPointId));
        
        await verifiedPointsService.DeleteVerifiedPointAsync(point!, ct);
    }
}