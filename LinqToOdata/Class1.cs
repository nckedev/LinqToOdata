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
 * $count -> Count
 * $orderby -> OrderBy
 * $orderby desc -> OrderByDesc
 * $search -> Search
 *
 */

public class QueryBuilder<TModel> where TModel : class
{
    private StringBuilder _queryStringBuilder = new();
    private List<string> _list;

    public QueryBuilder()
    {
        _list = new();
    }

    public QueryBuilder(IEnumerable<string> list)
    {
        _list = list.ToList();
    }

    //todo ska returna string
    public string ToQuery()
    {
        return _list.Aggregate("", (current, str) => current + str);
    }


    public QueryBuilder<TModel> Where(Expression<Func<TModel, bool>> predicate)
    {
        var a = Parser.ParseExpression(predicate.Body, new StringBuilder());
        _list.Add("$filter=" + a);
        return this;
    }

    public QueryBuilder<TResult> Select<TResult>(Expression<Func<TModel, TResult>> selector) where TResult : class
    {
        var a = Parser.ParseSelectorExpression(selector);
        return new QueryBuilder<TResult>(_list);
    }

}

internal static class Token
{
    internal const char LeftParen = '(';
    internal const char RightParen = ')';
}