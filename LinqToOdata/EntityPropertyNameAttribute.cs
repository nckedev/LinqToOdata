namespace LinqToOdata;

public class EntityPropertyNameAttribute : Attribute
{
    public string EntityPropertyName { get; }

    public EntityPropertyNameAttribute(string name)
    {
        EntityPropertyName = name;
    }
}