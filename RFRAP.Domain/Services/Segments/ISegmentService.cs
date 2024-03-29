﻿using RFRAP.Data.Entities;
using RFRAP.Domain.DTOs;

namespace RFRAP.Domain.Services.Segments;

public interface ISegmentService
{
    Segment GetNearestSegmentByCoordinates(PointDto point, IEnumerable<Segment> segments);
    Task<List<Segment>?> GetSegmentsByRoadNameAsync(string roadName, CancellationToken ct = default);
    Task<List<Segment>?> GetSegmentsByRoadNameWithVerifiedPointsAsync(
        string roadName, VerifiedPointType pointType, CancellationToken ct = default);
    Task CreateAndSaveSegmentAsync(SegmentDto dto, Road road, CancellationToken ct = default);
}