using System;

namespace BusinessLogic.Utilities
{
    public static class DateTimeProvider
    {
        private static DateTime? s_now;

        public static DateTime Now
        {
            get
            {
                if (s_now == null)
                {
                    return DateTime.Now;
                }

                return (DateTime)s_now;

            }
            set
            {
                s_now = value;
            }
        }

        public static void Reset() => s_now = null;


    }
}
