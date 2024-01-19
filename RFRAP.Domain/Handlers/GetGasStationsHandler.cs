using FluentValidation;
using RFRAP.Data.Entities;
using RFRAP.Domain.DTOs;
using RFRAP.Domain.Exceptions;
using RFRAP.Domain.Mappers;
using RFRAP.Domain.Responses;
using RFRAP.Domain.Services.Segments;

namespace RFRAP.Domain.Handlers;

public class GetGasStationsHandler(
    IValidator<string> validator,
    ISegmentService segmentService,
    IMapper<GasStation, GasStationDto> mapper)
{
    public async Task<GetGasStationsResponse> HandleAsync(string roadName, CancellationToken ct = default)
    {
        var validationResult = await validator.ValidateAsync(roadName, ct);
        BadRequestException.ThrowByValidationResult(validationResult);

        var roadSegments = await segmentService
            .GetSegmentsByRoadNameWithGasStationsAsync(roadName, ct);
        NotFoundException.ThrowIfNull(roadSegments, nameof(roadSegments));

        var gasStations = new List<GasStation>();
        for (int i = 0; i < roadSegments!.Count; i++)
        {
            var currentSegmentGasStations = roadSegments[i].GasStations 
                                            ?? Array.Empty<GasStation>();
            gasStations.AddRange(currentSegmentGasStations);
        }
        
        return new GetGasStationsResponse
        {
            GasStations = gasStations.Select(mapper.Map).ToArray()
        };
    }
}