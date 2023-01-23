using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Persistence.Entities.Hateoas
{
    // Depending on your needs, this is where you add the type of resource that you want to tie to the response
    // For example, your resource links will have metadata for Create, Update, Get and Delete operations
    public enum LinkedResourceType
    {
        None,
        Prev,
        Next
    }
}
