﻿using ClassTemplateTools.Contract;

namespace ClassTemplateTools.TypeHelp.ValueType
{
    [TypeName("Decimal")]
    internal class DecimalTypeHelp : ValueTypeHelp
    {
        public override string ToConstructString(object obj)
        {
            return base.ToConstructString(obj) + 'M';
        }
    }
}
