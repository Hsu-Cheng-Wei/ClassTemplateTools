namespace ClassTemplateTools.Contract
{
    internal interface ITypeHelp : IEnumerableBrackets
    {
        string BaseName(object obj);

        string ToConstructString(object obj);
    }
}
