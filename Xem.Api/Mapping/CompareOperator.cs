using Xem.Api.Formatting;

namespace Xem.Api.Mapping
{
    public enum CompareOperator
    {
        [StringValue("ne")]
        NotEqual = 1,
        [StringValue("gt")]
        GreaterThan,
        [StringValue("ge")]
        GreaterOrEqualThan,
        [StringValue("lt")]
        LessThan,
        [StringValue("le")]
        LessOrEqualThan,
        [StringValue("eq")]
        Equal
    }
}
