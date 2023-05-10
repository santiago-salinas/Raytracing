using System;

namespace BusinessLogic
{
    public class DateTimeProvider
    {
        private static DateTime? s_now;

        public static DateTime Now
        {
            get
            {
                if (s_now == null)
                {
                    s_now = DateTime.Now;
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
