namespace GaiaInfraUtils.Extensions;

public static class DateTimeExtension
{
    public static Date AtZone(this DateTime @this, string destTimeZone)
    {
        return AtZone(@this, TimeZoneUtil.Parse(destTimeZone));
    }

    public static Date AtZone(this DateTime @this, TimeZoneUtil.TimeZone timeZone)
    {
        return new Date(@this.ToUniversalTime(), TimeZoneInfo.Local).WithZone(TimeZoneUtil.GetTimeZoneInfo(timeZone));
    }
}