using ClassTemplateTools.Contract;

namespace ClassTemplateTools.TypeHelp.ValueType
{
    [TypeName("Single")]
    internal class FloatTypeHelpe : ValueTypeHelp
    {
        public override string ToConstructString(object obj)
        {
            return base.ToConstructString(obj) + 'F';
        }
    }
}
