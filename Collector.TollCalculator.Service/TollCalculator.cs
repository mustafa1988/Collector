using Collector.TollCalculator.Application;
using Collector.TollCalculator.Domain.Enums;
using Collector.TollCalculator.Domain.Interfaces;

namespace Collector.TollCalculator.Service;

public class TollCalculator
{
    /**
     * Calculate the total toll fee for one day
     *
     * @param vehicle - the vehicle
     * @param dates   - date and time of all passes on one day
     * @return - the total toll fee for that day
     */

    public int GetTollFee(IVehicle vehicle, List<DateTime> dates)
    {
        if (!dates.Any() || vehicle == null)
        {
            throw new Exception("Bad user request");
        }
        
        if (Enum.IsDefined(typeof(Enums.TollFreeVehicles), vehicle.GetVehicleType())) return 0;

        var intervalStart = dates.First();
        var startFee = GetTollFee(intervalStart);
        var totalFee = 0;
        foreach (var date in dates)
        {
            var nextFee = GetTollFee(date);
            var minutes = (date - intervalStart).TotalMinutes;
            
            if (minutes <= 60.00)
            {
                if (nextFee >= startFee)
                {
                    totalFee = nextFee;
                }
            }
            else
            {
                totalFee += nextFee;
            }
        }
        
        return totalFee > 60 ? 60 : totalFee;
    }
    
    private static int GetTollFee(DateTime date)
    {
        if (IsTollFreeDate(date)) return 0;

        var result = MockData.Fees.FirstOrDefault(fee =>
            fee.StartHour == date.Hour && fee.StartMinute <= date.Minute && fee.EndMinute >= date.Minute);
        
        return result?.TollFee ?? 0;
    }

    private static bool IsTollFreeDate(DateTime date)
    {
        if (date.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday ||
            MockData.FreeMonths.Any(a => a == date.Month)) return true;
        
        return MockData.FreeDays.Any(freeDates => DateTime.Compare(freeDates.Date, date.Date) == 0);
    }
}