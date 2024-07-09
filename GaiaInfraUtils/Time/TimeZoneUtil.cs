namespace GaiaInfraUtils.Time;

public abstract class TimeZoneUtil
{
    public class TimeZone(string id, TimeSpan timeSpan)
    {
        public string Id { get; } = id;

        public TimeSpan TimeSpan { get; } = timeSpan;
    }
    
    public static readonly TimeZone GMT_0 = new("GMT+00:00", TimeSpan.Zero);
    public static readonly TimeZone GMT_1 = new("GMT+01:00", TimeSpan.FromHours(1));
    public static readonly TimeZone GMT_2 = new("GMT+02:00", TimeSpan.FromHours(2));
    public static readonly TimeZone GMT_3 = new("GMT+03:00", TimeSpan.FromHours(3));
    public static readonly TimeZone GMT_3_30 = new("GMT+03:30", TimeSpan.FromHours(3.5));
    public static readonly TimeZone GMT_4 = new("GMT+04:00", TimeSpan.FromHours(4));
    public static readonly TimeZone GMT_4_30 = new("GMT+04:30", TimeSpan.FromHours(4.5));
    public static readonly TimeZone GMT_5 = new("GMT+05:00", TimeSpan.FromHours(5));
    public static readonly TimeZone GMT_5_30 = new("GMT+05:30", TimeSpan.FromHours(5.5));
    public static readonly TimeZone GMT_5_45 = new("GMT+05:45", TimeSpan.FromHours(5.75));
    public static readonly TimeZone GMT_6 = new("GMT+06:00", TimeSpan.FromHours(6));
    public static readonly TimeZone GMT_6_30 = new("GMT+06:30", TimeSpan.FromHours(6.5));
    public static readonly TimeZone GMT_7 = new("GMT+07:00", TimeSpan.FromHours(7));
    public static readonly TimeZone GMT_8 = new("GMT+08:00", TimeSpan.FromHours(8));
    public static readonly TimeZone GMT_8_45 = new("GMT+08:45", TimeSpan.FromHours(8.75));
    public static readonly TimeZone GMT_9 = new("GMT+09:00", TimeSpan.FromHours(9));
    public static readonly TimeZone GMT_9_30 = new("GMT+09:30", TimeSpan.FromHours(9.5));
    public static readonly TimeZone GMT_10 = new("GMT+10:00", TimeSpan.FromHours(10));
    public static readonly TimeZone GMT_10_30 = new("GMT+10:30", TimeSpan.FromHours(10.5));
    public static readonly TimeZone GMT_11 = new("GMT+11:00", TimeSpan.FromHours(11));
    public static readonly TimeZone GMT_12 = new("GMT+12:00", TimeSpan.FromHours(12));
    public static readonly TimeZone GMT_12_45 = new("GMT+12:45", TimeSpan.FromHours(12.75));
    public static readonly TimeZone GMT_13 = new("GMT+13:00", TimeSpan.FromHours(13));
    public static readonly TimeZone GMT_14 = new("GMT+14:00", TimeSpan.FromHours(14));

    public static readonly TimeZone M_GMT_1 = new("GMT-01:00", TimeSpan.FromHours(-1));
    public static readonly TimeZone M_GMT_2 = new("GMT-02:00", TimeSpan.FromHours(-2));
    public static readonly TimeZone M_GMT_2_30 = new("GMT-02:30", TimeSpan.FromHours(-2.5));
    public static readonly TimeZone M_GMT_3 = new("GMT-03:00", TimeSpan.FromHours(-3));
    public static readonly TimeZone M_GMT_4 = new("GMT-04:00", TimeSpan.FromHours(-4));
    public static readonly TimeZone M_GMT_5 = new("GMT-05:00", TimeSpan.FromHours(-5));
    public static readonly TimeZone M_GMT_6 = new("GMT-06:00", TimeSpan.FromHours(-6));
    public static readonly TimeZone M_GMT_7 = new("GMT-07:00", TimeSpan.FromHours(-7));
    public static readonly TimeZone M_GMT_8 = new("GMT-08:00", TimeSpan.FromHours(-8));
    public static readonly TimeZone M_GMT_9 = new("GMT-09:00", TimeSpan.FromHours(-9));
    public static readonly TimeZone M_GMT_9_30 = new("GMT-09:30", TimeSpan.FromHours(-9.5));
    public static readonly TimeZone M_GMT_10 = new("GMT-10:00", TimeSpan.FromHours(-10));
    public static readonly TimeZone M_GMT_11 = new("GMT-11:00", TimeSpan.FromHours(-11));

    private static readonly Dictionary<string, TimeZone> TimeZoneDictionary = new ()
    {
        ["GMT+00:00"] = GMT_0, 
        ["GMT+01:00"] = GMT_1, 
        ["GMT+02:00"] = GMT_2, 
        ["GMT+03:00"] = GMT_3, 
        ["GMT+03:30"] = GMT_3_30, 
        ["GMT+04:00"] = GMT_4, 
        ["GMT+04:30"] = GMT_4_30, 
        ["GMT+05:00"] = GMT_5, 
        ["GMT+05:30"] = GMT_5_30, 
        ["GMT+05:45"] = GMT_5_45, 
        ["GMT+06:00"] = GMT_6, 
        ["GMT+06:30"] = GMT_6_30, 
        ["GMT+07:00"] = GMT_7, 
        ["GMT+08:00"] = GMT_8, 
        ["GMT+08:45"] = GMT_8_45, 
        ["GMT+09:00"] = GMT_9, 
        ["GMT+09:30"] = GMT_9_30, 
        ["GMT+10:00"] = GMT_10, 
        ["GMT+10:30"] = GMT_10_30, 
        ["GMT+11:00"] = GMT_11, 
        ["GMT+12:00"] = GMT_12, 
        ["GMT+12:45"] = GMT_12_45, 
        ["GMT+13:00"] = GMT_13, 
        ["GMT+14:00"] = GMT_14, 
        
        ["GMT-01:00"] = M_GMT_1, 
        ["GMT-02:00"] = M_GMT_2, 
        ["GMT-02:30"] = M_GMT_2_30, 
        ["GMT-03:00"] = M_GMT_3, 
        ["GMT-04:00"] = M_GMT_4, 
        ["GMT-05:00"] = M_GMT_5, 
        ["GMT-06:00"] = M_GMT_6, 
        ["GMT-07:00"] = M_GMT_7, 
        ["GMT-08:00"] = M_GMT_8, 
        ["GMT-09:00"] = M_GMT_9, 
        ["GMT-09:30"] = M_GMT_9_30, 
        ["GMT-10:00"] = M_GMT_10, 
        ["GMT-11:00"] = M_GMT_11, 
    };

    public static TimeZone Parse(string timezone)
    {
        if (timezone.StartsWith('+') || timezone.StartsWith('-'))
        {
            timezone = "GMT" + timezone;
        }
        else if (timezone.StartsWith("UTC"))
        {
            timezone = timezone.Replace("UTC", "GMT");
        }
        else if (!timezone.StartsWith("GMT"))
        {
            timezone = "GMT+" + timezone;
        }

        return TimeZoneDictionary[timezone];
    }

    public static TimeZoneInfo GetTimeZone(string timezone)
    {
        return GetTimeZoneInfo(Parse(timezone));
    }
    
    public static TimeZoneInfo GetTimeZoneInfo(TimeZone timeZone)
    {
        return TimeZoneInfo.CreateCustomTimeZone(timeZone.Id, timeZone.TimeSpan, timeZone.Id, timeZone.Id);
    }
}