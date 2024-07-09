namespace GaiaInfraUtils.Time;

public static class DateTimeExtension
{
    public static Date WithZone(this DateTime @this, string destTimeZone)
    {
        return WithZone(@this, TimeZoneUtil.Parse(destTimeZone));
    }

    public static Date WithZone(this DateTime @this, TimeZoneUtil.TimeZone timeZone)
    {
        return new Date(@this.ToUniversalTime(), TimeZoneInfo.Local).WithZone(TimeZoneUtil.GetTimeZoneInfo(timeZone));
    }

    public static Date WithZoneRetainFields(this DateTime @this, string destTimeZone)
    {
        return WithZoneRetainFields(@this, TimeZoneUtil.Parse(destTimeZone));
    }

    public static Date WithZoneRetainFields(this DateTime @this, TimeZoneUtil.TimeZone timeZone)
    {
        return new Date(@this.ToUniversalTime(), TimeZoneInfo.Local).WithZoneRetainFields(TimeZoneUtil.GetTimeZoneInfo(timeZone));
    }
}