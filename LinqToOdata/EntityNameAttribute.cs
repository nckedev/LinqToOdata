namespace LinqToOdata;

public class EntityNameAttribute : Attribute
{
    public string EntityName { get; }

    public EntityNameAttribute(string name)
    {
        EntityName = name;
    }
}