namespace LinqToOdata.Test;

public enum TestEnum
{
    Active,
    Inactive,
    Cancelled,
}

public class TestModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public TestEnum Status { get; set; }
    
}

public class UnitTest1
{
    [Fact]
    public void Where()
    {
        var q = new QueryBuilder<TestModel>().Where(s => s.Name == "name").ToQuery();
        Assert.Equal($"$filter=Name eq 'name'", q);
    }

    [Fact]
    public void Where_BinaryExpression()
    {
        var q = new QueryBuilder<TestModel>().Where(x => x.Name == "name" && x.Quantity > 1).ToQuery();
        Assert.Equal("$filter=Name eq 'name' and Quantity gt 1", q);
    }

    [Fact]
    public void Where_BinaryExpressionPrecedence()
    {
        var q = new QueryBuilder<TestModel>()
            .Where(x => x.Name == "name" && (x.Quantity < 5 || x.Quantity > 10)).ToQuery();
        Assert.Equal("$filter=Name eq 'name' and (Quantity lt 5 or Quantity gt 10)", q);
    }
}