using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net.Http.Formatting;
using System.Reflection;

namespace Xem.Api
{
    public class XemJsonMediaTypeFormatter: JsonMediaTypeFormatter
    {
        public XemJsonMediaTypeFormatter()
        {
            this.SerializerSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new XemContractResolver()
            };
        }

        private class XemContractResolver: DefaultContractResolver
        {
            public XemContractResolver()
            {
                this.NamingStrategy = new CamelCaseNamingStrategy();
            }

            protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
            {
                var jsProperty = base.CreateProperty(member, memberSerialization);

                jsProperty.Writable = jsProperty.Writable || XemContractResolver.IsPropertyWithSetter(member, true);
                jsProperty.Readable = jsProperty.Readable || XemContractResolver.IsPropertyWithSetter(member, false);

                return jsProperty;
            }

            private static bool IsPropertyWithSetter(MemberInfo member, bool isNonPublic)
            {
                if (member is PropertyInfo property)
                {
                    return property.GetSetMethod(isNonPublic) != null;
                }

                return false;
            }
        }
    }
}
