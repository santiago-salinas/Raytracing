using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Utilities
{
    public class DateTimeProvider
    {
        private static DateTime? now;

        public static DateTime Now {
            get
            {
                if (now == null)
                {
                    now = DateTime.Now;
                }

                return (DateTime)now;

            }
            set
            {
                now = value;
            } 
        }

        public static void Reset() => now = null;


    }
}
