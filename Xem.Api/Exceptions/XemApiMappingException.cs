using System;
namespace Xem.Api.Exceptions
{
    public class XemApiMappingException : Exception
    {
        public XemApiMappingException(Exception innerException) : base("Exception while fetching mapping.", innerException)
        {
        }
    }
}
