using GoDinner.Application.Common.Interfaces.Services;

namespace GoDinner.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTimeOffset Now => DateTimeOffset.Now;
}