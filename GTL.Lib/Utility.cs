using System;
using System.Collections.Generic;
using System.Text;

namespace GTL.Lib
{
    public static class Utility
    {
        public static DateTime GetServerTime()
        {
            return DateTime.UtcNow;
        }
    }
}
