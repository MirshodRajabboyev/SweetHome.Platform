using SweetHome.Domain.Constants;

namespace SweetHome.Service.Common.Helpers;

public class TimeHelper
{
    public static DateTime GetDateTime()
    {
        var dtTime = DateTime.UtcNow;
        dtTime.AddHours(TimeConstants.UTS);
        return dtTime;
    }
}
