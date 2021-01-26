﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AllTests.Extensions {
    public static class DateTimeExtensions {


        public static long ToJavascriptTimestamp(this DateTime input) {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var time = input.Subtract(new TimeSpan(epoch.Ticks));
            return (long)(time.Ticks / 10000);
        }


    }
}
