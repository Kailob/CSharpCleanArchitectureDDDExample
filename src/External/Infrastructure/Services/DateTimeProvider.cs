using CADDD.Application.Common.Interfaces.Services;

namespace CADDD.Infrastructure.Services;

public class DateTimeProvider: IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}