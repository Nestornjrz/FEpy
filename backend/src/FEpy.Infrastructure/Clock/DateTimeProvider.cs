using FEpy.Application.Abstractions.Clock;

namespace FEpy.Infrastructure.Clock;

internal sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime currentTime => DateTime.UtcNow;
}