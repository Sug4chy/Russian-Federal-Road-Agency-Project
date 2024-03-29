﻿using FluentValidation;
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
            .Must(ValidationDefaults.BeValidPoint);
        RuleFor(request => request.Segment.Point2)
            .Must(ValidationDefaults.BeValidPoint);
    }
}