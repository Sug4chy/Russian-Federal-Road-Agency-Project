using FluentValidation;
using RFRAP.Domain.DTOs;
using RFRAP.Domain.Requests.Utility;

namespace RFRAP.Domain.Validators.Utility;

public class AddSegmentRequestValidator : AbstractValidator<AddSegmentRequest>
{
    public AddSegmentRequestValidator()
    {
        RuleFor(request => request.RoadName)
            .NotNull()
            .NotEmpty();
        RuleFor(request => request.Segment.Point1)
            .NotNull()
            .Must(BeValidPoint);
        RuleFor(request => request.Segment.Point2)
            .NotNull()
            .Must(BeValidPoint);
    }

    private static bool BeValidPoint(PointDto point)
    => point.X is >= 0D and <= 180D 
       && point.Y is >= -90D and <= 90D;
}