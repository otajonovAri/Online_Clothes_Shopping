using EducationApp.Core;
using Microsoft.AspNetCore.Authorization;

namespace EducationApp.Application;

public class HasPermissionAttribute : AuthorizeAttribute
{
    public HasPermissionAttribute(Permission permission)
        : base(policy: permission.ToString())
    {
        
    }
}
