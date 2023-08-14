using System.Reflection;
using Xem.Api.Mapping;

namespace Xem.Api.Formatting
{
    internal static class CompareOperatorExtensions
    {
        public static string AsString(this CompareOperator compareOperator)
        {
            FieldInfo fieldInfo = compareOperator.GetType().GetField(compareOperator.ToString());

            StringValueAttribute[] attributes = (StringValueAttribute[])fieldInfo.GetCustomAttributes(typeof(StringValueAttribute), false);

            if (attributes != null && attributes.Length > 0)
            {
                return attributes[0].Value;
            }
            else
            {
                return compareOperator.ToString();
            }
        }
    }
}
