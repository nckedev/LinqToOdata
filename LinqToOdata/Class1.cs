using System.Diagnostics.Contracts;
using System.Linq.Expressions;
using System.Text;

namespace LinqToOdata;

/**
 * $filter -> Where
 * $select -> Select
 * $expand -> Expand
 * $top -> Top
 * $skip -> Skip
 * $take -> Take
 *
 */
public class Class1
{
    public Class1()
    {
        var a = new List<int>().Where(x => x == 1);
    }
}

public class QueryBuilder<TModel> where TModel : class
{
    private StringBuilder _queryStringBuilder = new();

    public string ToQuery()
    {
        return _queryStringBuilder.ToString();
    }


    public QueryBuilder<TModel> Where(Expression<Func<TModel, bool>> predicate)
    {
        var a = Parser.ParseExpression(predicate, new StringBuilder());
        return this;
    }

    internal void AddString(string s)
    {
        _queryStringBuilder.Append(s);
    }
}


internal static class Parser
{
    [Pure]
    internal static string ParseExpression(Expression expr, StringBuilder stringBuilder)
    {
        return "";
    }
}

internal static class Token
{
    internal const char LeftParen = '(';
    internal const char RightParen = ')';
}