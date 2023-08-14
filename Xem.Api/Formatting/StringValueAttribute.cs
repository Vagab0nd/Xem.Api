using System;

namespace Xem.Api.Formatting
{
    internal class StringValueAttribute: Attribute
    {
        public StringValueAttribute(string value)
        {
            this.Value = value;
        }

        public string Value { get;}
    }
}
