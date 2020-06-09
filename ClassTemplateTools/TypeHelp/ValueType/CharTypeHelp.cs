using ClassTemplateTools.Contract;

namespace ClassTemplateTools.TypeHelp.ValueType
{
    [TypeName("Char")]
    internal class CharTypeHelp : ValueTypeHelp
    {
        public override string ToConstructString(object obj)
        => $"\'{obj.ToString()}\'";
    }
}
