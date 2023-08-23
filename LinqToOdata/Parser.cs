using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace LinqToOdata;

internal static class Parser
{
    internal static string ParseExpression(Expression expression, StringBuilder stringBuilder)
    {
        return expression switch
        {
            BinaryExpression expr => ParseBinaryExpression(expr, stringBuilder),
            MethodCallExpression expr => ParseMethodCallExpression(expr, stringBuilder),
            ConstantExpression expr => ParseConstantExpression(expr, stringBuilder),
            MemberExpression expr => ParseMemberExpression(expr, stringBuilder),
            _ => throw new Exception("End of parser")
        };
        return "";
    }

    private static string ParseBinaryExpression(Expression expr, StringBuilder stringBuilder)
    {
        return "";
    }

    private static string ParseMethodCallExpression(Expression expr, StringBuilder stringBuilder)
    {
        return "";
    }

    private static string ParseConstantExpression(Expression expr, StringBuilder stringBuilder)
    {
        return "";
    }

    private static string ParseMemberExpression(MemberExpression expr, StringBuilder stringBuilder)
    {
        stringBuilder.Append(GetNameOrAttributeName(expr.Member));
        return stringBuilder.ToString();
    }

    /// <summary>
    /// Parses the name of the selector property
    /// </summary>
    /// <param name="expr">The expression to parse</param>
    /// <param name="overrideWithAttribute">Override the property name with the
    /// name from the EntityPropertyNameAttribute, when true</param>
    /// <returns>The name of the selector</returns>
    internal static string ParseSelectorExpression(Expression expr, bool overrideWithAttribute = true)
    {
        ArgumentNullException.ThrowIfNull("Expression is null");

        if (expr is MemberExpression memberExpression)
        {
            return GetNameOrAttributeName(memberExpression.Member);
        }

        throw new ArgumentException("ParseSelectorExpression: expression is not a MemberExpression");
    }

    /// <summary>
    /// Gets the name or the the translated name of the property
    /// </summary>
    /// <param name="memberInfo">property member</param>
    /// <returns>tha name of the property</returns>
    private static string GetNameOrAttributeName(MemberInfo memberInfo)
    {
        var attr = memberInfo.GetCustomAttribute<EntityPropertyNameAttribute>();
        return attr is not null ? attr.EntityPropertyName : memberInfo.Name;
    }


    private static string ConvertExpressionType(ExpressionType type) => type switch
    {
        ExpressionType.AndAlso => "and", // ??
        ExpressionType.OrElse => "or", // ??
        ExpressionType.GreaterThan => "gt",
        ExpressionType.GreaterThanOrEqual => "gte",
        ExpressionType.LessThan => "lt",
        ExpressionType.LessThanOrEqual => "lte",
        ExpressionType.Equal => "eq",
        ExpressionType.NotEqual => "ne",
        _ => throw new NotImplementedException(type.ToString())
    };

}