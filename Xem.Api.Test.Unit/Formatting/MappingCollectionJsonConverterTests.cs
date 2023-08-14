using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xem.Api.Formatting;
using Xem.Api.Mapping;

namespace Xem.Api.Tests.Formatting
{
    [TestClass]
    public class MappingCollectionJsonConverterTests
    {
        private readonly MappingCollectionJsonConverter converter = new();

        [TestInitialize]
        public void Initialize()
        {
        }

        [TestMethod]
        public void CanConvert_should_allow_MappingCollection_type()
        {
            this.converter.CanConvert(typeof(MappingCollection)).Should().BeTrue();
        }

        [TestMethod]
        public void CanConvert_should_not_allow_type_other_than_MappingCollection()
        {
            this.converter.CanConvert(typeof(NameCollection)).Should().BeFalse();
        }
    }
}
