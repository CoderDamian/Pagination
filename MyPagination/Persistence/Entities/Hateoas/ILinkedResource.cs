namespace Persistence.Entities.Hateoas
{
    // This enable us to create dynamic links based on LinkedResourceType and on top of that, allowing us to easily create an extension method for adding links.
    public interface ILinkedResource
    {
        IDictionary<LinkedResourceType, LinkedResource> Links { get; set; }
    }
}
