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
    public void Test1()
    {
        var b = new QueryBuilder<TestModel>();
        b.Where(s => s.Name == "name");
        

            
        
    }
}