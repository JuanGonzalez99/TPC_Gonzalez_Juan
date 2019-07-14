using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Helpers
{
    public static class Converter
    {
        public static bool ToBoolean(object parameter)
        {
            try
            {
                bool result = (bool)parameter;
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static string ToString(object parameter)
        {
            try
            {
                string result = (string)parameter;
                return result;
            }
            catch (Exception)
            {
                return "";
            }
        }

        public static byte ToByte(object parameter)
        {
            try
            {
                byte result = (byte)parameter;
                return result;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static byte? ToNulleableByte(object parameter)
        {
            try
            {
                byte? result = (byte?)parameter;
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static short ToShort(object parameter)
        {
            try
            {
                short result = (short)parameter;
                return result;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static int ToInt(object parameter)
        {
            try
            {
                int result = (int)parameter;
                return result;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static long ToLong(object parameter)
        {
            try
            {
                long result = (long)parameter;
                return result;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static DateTime ToDateTime(object parameter)
        {
            try
            {
                DateTime result = (DateTime)parameter;
                return result;
            }
            catch (Exception)
            {
                return DateTime.MinValue;
            }
        }

        public static DateTime? ToNulleableDateTime(object parameter)
        {
            try
            {
                DateTime? result = (DateTime?)parameter;
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static TimeSpan ToTimeSpan(object parameter)
        {
            try
            {
                TimeSpan result = (TimeSpan)parameter;
                return result;
            }
            catch (Exception)
            {
                return TimeSpan.MinValue;
            }
        }
    }
}
