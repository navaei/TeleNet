using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TeleNet.Models.Utils
{
    public static class Extensions
    {
        public static TAttribute GetAttribute<TAttribute>(this Enum enumValue)
            where TAttribute : Attribute
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<TAttribute>();
        }

        public static string ShortName(this Enum enumValue)
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<DisplayAttribute>().ShortName;
        }

        public static string GetName(this Enum enumValue)
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<DisplayAttribute>().Name;
        }

        public static bool EqualsNameValue(this Enum enumValue, string value)
        {
            int num;
            if (int.TryParse(value, out num))
                return Convert.ToInt32(enumValue) == num;

            var val = enumValue.GetType()
                .GetMember(enumValue.ToString())
                .First()
                .GetCustomAttribute<DisplayAttribute>().ShortName;

            return val == value;
        }

        public static Exception GetInnerException(this Exception exception)
        {
            if (exception.InnerException != null)
                exception = GetInnerException(exception.InnerException);


            return exception;
        }


        public static int GetDate(this DateTime dateTime)
        {
            return Helpers.GetDate(dateTime);
        }

        public static DateTime GetDate(this int dateTime)
        {
            return Helpers.GetDate(dateTime);
        }

        public static string SubstringX(this string str, int len)
        {
            return !string.IsNullOrEmpty(str) && str.Length > len ? str.Substring(0, len) : str;
        }

    }
}
