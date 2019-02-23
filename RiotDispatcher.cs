using SVN.Debug;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SVN.RiotApi
{
    public static class RiotDispatcher
    {
        private static List<DateTime> Requests { get; } = new List<DateTime>();
        public static TimeSpan Timeout { get; set; } = TimeSpan.FromMinutes(1);
        public static List<(int requests, TimeSpan timespan)> Limits { get; } = new List<(int, TimeSpan)>();

        private static bool IsEmpty
        {
            get => !RiotDispatcher.Limits.Any();
        }

        private static bool SleepRequired
        {
            get
            {
                if (RiotDispatcher.IsEmpty)
                {
                    RiotDispatcher.SetDefaultLimits();
                }

                var datetime = DateTime.Now;
                var maxLimit = RiotDispatcher.Limits.Max(x => x.timespan);
                RiotDispatcher.Requests.RemoveAll(x => x < datetime.Add(-maxLimit));

                return RiotDispatcher.Limits.Any(x => x.requests <= RiotDispatcher.Requests.Count(y => datetime.Add(-x.timespan) <= y && y <= datetime));
            }
        }

        private static void SetDefaultLimits()
        {
            RiotDispatcher.Limits.Add((20, TimeSpan.FromSeconds(1)));
            RiotDispatcher.Limits.Add((100, TimeSpan.FromMinutes(2)));
        }

        public static void Sleep()
        {
            var timeouttime = DateTime.Now.Add(RiotDispatcher.Timeout);

            while (RiotDispatcher.SleepRequired)
            {
                if (timeouttime < DateTime.Now)
                {
                    timeouttime = DateTime.Now.Add(RiotDispatcher.Timeout);
                    Logger.Write($"sleeptime waited {RiotDispatcher.Timeout.TotalSeconds:N0} seconds");
                }
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }

            RiotDispatcher.Requests.Add(DateTime.Now);
        }
    }
}