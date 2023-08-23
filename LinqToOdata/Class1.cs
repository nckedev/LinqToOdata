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

    public QueryBuilder<TResult> Select<TResult>(Expression<Func<TModel, TResult>> selector) where TResult : class
    {
        return new QueryBuilder<TResult>();
    }

}

internal static class Token
{
    internal const char LeftParen = '(';
    internal const char RightParen = ')';
}