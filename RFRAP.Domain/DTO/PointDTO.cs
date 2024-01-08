namespace RFRAP.Domain.DTO;

public readonly struct PointDTO(double x, double y)
{
    public double X => x;
    public double Y => y;
}