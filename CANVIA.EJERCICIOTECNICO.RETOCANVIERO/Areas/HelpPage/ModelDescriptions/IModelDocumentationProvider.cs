using System;
using System.Reflection;

namespace CANVIA.EJERCICIOTECNICO.RETOCANVIERO.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}