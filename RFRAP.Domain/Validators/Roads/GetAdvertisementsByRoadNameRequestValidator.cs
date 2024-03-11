using FluentValidation;
using RFRAP.Domain.Requests.Roads;

namespace RFRAP.Domain.Validators.Roads;

public class GetAdvertisementsByRoadNameRequestValidator : AbstractValidator<GetAdvertisementsByRoadNameRequest>
{
    public GetAdvertisementsByRoadNameRequestValidator()
    {
        RuleFor(request => request.RoadName)
            .NotEmpty();
    }
}