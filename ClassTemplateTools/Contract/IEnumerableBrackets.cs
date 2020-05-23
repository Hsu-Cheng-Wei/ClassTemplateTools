using System.Collections.Generic;

namespace ClassTemplateTools.Contract
{
    internal interface IEnumerableBrackets
    {
        string ReassemblyStringInBrackets(IEnumerable<string> strs, string title);
    }
}
