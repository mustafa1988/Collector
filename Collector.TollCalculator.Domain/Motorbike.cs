using Collector.TollCalculator.Domain.Interfaces;

namespace Collector.TollCalculator.Domain;

public class Motorbike : IVehicle
{
    public string GetVehicleType()
    {
        return "Motorbike";
    }
}