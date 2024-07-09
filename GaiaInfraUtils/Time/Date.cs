namespace GaiaInfraUtils.Time;

public class Date
{
    private const long BaseTicks = 621355968000000000L;

    private const int MillisRate = 10000;

    public long TimeMillis { get; }

    public TimeZoneInfo TimeZone { get; }

    public Date()
    {
        this.TimeMillis = CurrentTimeMillis();
        this.TimeZone = TimeZoneInfo.Local;
    }

    public Date(long timeMillis)
    {
        this.TimeMillis = timeMillis;
        this.TimeZone = TimeZoneInfo.Local;
    }

    public Date(DateTime dateTime, TimeZoneInfo timeZone)
    {
        this.TimeMillis = TicksToTimeMillis(dateTime.Ticks);
        this.TimeZone = timeZone;
    }

    public Date(long timeMillis, TimeZoneInfo timeZone)
    {
        this.TimeMillis = timeMillis;
        this.TimeZone = timeZone;
    }

    public override string ToString()
    {
        return ToString("yyyy-MM-ddTHH:mm:ss.fffzzz");
    }

    public Date WithZone(TimeZoneInfo destTimeZone)
    {
        return new Date(this.TimeMillis, destTimeZone);
    }

    public Date WithZone(TimeZoneUtil.TimeZone timeZone)
    {
        return WithZone(TimeZoneUtil.GetTimeZoneInfo(timeZone));
    }

    public Date WithZoneRetainFields(TimeZoneInfo destTimeZone)
    {
        var dateTime = ToDateTime();
        var selfOffset = TimeZone.GetUtcOffset(dateTime);
        var destOffset = destTimeZone.GetUtcOffset(dateTime);

        var destTimeMillis = TimeMillis + CalculateOffsetMillis(selfOffset) - CalculateOffsetMillis(destOffset); 
        return new Date(destTimeMillis, destTimeZone);
    }

    public Date WithZoneRetainFields(TimeZoneUtil.TimeZone timeZone)
    {
        return WithZoneRetainFields(TimeZoneUtil.GetTimeZoneInfo(timeZone));
    }

    private static long CalculateOffsetMillis(TimeSpan timeSpan)
    {
        return timeSpan.Hours * 3600 * 1000 + timeSpan.Minutes * 60 * 1000 + 
               timeSpan.Seconds * 1000 + timeSpan.Milliseconds;
    }

    public string ToString(string pattern)
    {
        var dateTime = ToDateTime();
        var dateTimeOffset = new DateTimeOffset(dateTime);
        return dateTimeOffset.ToOffset(TimeZone.GetUtcOffset(dateTime)).ToString(pattern);
    }

    private DateTime ToDateTime()
    {
        var ticks = TimeMillisToTicks(TimeMillis);
        return new DateTime(ticks, DateTimeKind.Utc);
    }

    private static long TimeMillisToTicks(long timeMillis)
    {
        return timeMillis * MillisRate + BaseTicks;
    }

    public static long CurrentTimeMillis()
    {
        return (DateTime.Now.ToUniversalTime().Ticks - BaseTicks) / MillisRate;
    }

    public static long TicksToTimeMillis(long ticks)
    {
        return (ticks - BaseTicks) / MillisRate;
    }
}