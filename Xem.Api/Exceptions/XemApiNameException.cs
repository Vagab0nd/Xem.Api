using System;
namespace Xem.Api.Exceptions
{
    public class XemApiNameException : Exception
    {
        public XemApiNameException(Exception innerException) : base("Exception while fetching names.", innerException)
        {
        }
    }
}
