using System.Linq.Expressions;
using System.Text;

namespace LinqToOdata;

internal static class Parser
{
    internal static string ParseExpression(Expression expr, StringBuilder stringBuilder)
    {
        return "";
    }

    internal static string ParseSelectorExpression(Expression expr)
    {
        if (expr is MemberExpression memberExpression)
        {
            return memberExpression.Member.Name;
        }

        return "";
    }
}