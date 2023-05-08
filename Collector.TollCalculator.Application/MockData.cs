using Collector.TollCalculator.Domain;

namespace Collector.TollCalculator.Application;

public static class MockData
{
    public static readonly List<Fee> Fees = new()
    {
        new Fee {StartHour = 06, StartMinute = 00, EndMinute = 29, TollFee = 8},
        new Fee {StartHour = 06, StartMinute = 30, EndMinute = 59, TollFee = 13},
        new Fee {StartHour = 07, StartMinute = 00, EndMinute = 59, TollFee = 18},
        new Fee {StartHour = 08, StartMinute = 00, EndMinute = 29, TollFee = 13},
        new Fee {StartHour = 08, StartMinute = 30, EndMinute = 59, TollFee = 8},
        new Fee {StartHour = 09, StartMinute = 00, EndMinute = 59, TollFee = 8},
        new Fee {StartHour = 10, StartMinute = 00, EndMinute = 59, TollFee = 8},
        new Fee {StartHour = 11, StartMinute = 00, EndMinute = 59, TollFee = 8},
        new Fee {StartHour = 12, StartMinute = 00, EndMinute = 59, TollFee = 8},
        new Fee {StartHour = 13, StartMinute = 00, EndMinute = 59, TollFee = 8},
        new Fee {StartHour = 14, StartMinute = 00, EndMinute = 59, TollFee = 8},
        new Fee {StartHour = 15, StartMinute = 00, EndMinute = 29, TollFee = 13},
        new Fee {StartHour = 15, StartMinute = 30, EndMinute = 59, TollFee = 18},
        new Fee {StartHour = 16, StartMinute = 00, EndMinute = 59, TollFee = 18},
        new Fee {StartHour = 17, StartMinute = 00, EndMinute = 59, TollFee = 13},
        new Fee {StartHour = 18, StartMinute = 00, EndMinute = 29, TollFee = 8}
    };

    public static readonly List<int> FreeMonths = new() {07};
    public static readonly List<DateTime> FreeDays = new()
    { 
        new DateTime(2013, 01, 01),
        new DateTime(2013, 03, 28),
        new DateTime(2013, 03, 29),
        new DateTime(2013, 04, 01),
        new DateTime(2013, 04, 30),
        new DateTime(2013, 05, 01),
        new DateTime(2013, 05, 08),
        new DateTime(2013, 05, 09),
        new DateTime(2013, 06, 05),
        new DateTime(2013, 06, 06),
        new DateTime(2013, 06, 21),
        new DateTime(2013, 11, 01),
        new DateTime(2013, 12, 24),
        new DateTime(2013, 12, 25),
        new DateTime(2013, 12, 26),
        new DateTime(2013, 12, 31)
    };
}