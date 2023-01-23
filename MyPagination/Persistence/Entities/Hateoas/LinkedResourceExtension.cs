namespace Persistence.Entities.Hateoas
{
    // extension method for adding link resources
    public static class LinkedResourceExtension
    {
        public static void AddResourceLink(this ILinkedResource resource, LinkedResourceType resourceType, string routURL)
        {
            resource.Links ??= new Dictionary<LinkedResourceType, LinkedResource>();

            resource.Links[resourceType] = new LinkedResource(routURL);
        }
    }
}
