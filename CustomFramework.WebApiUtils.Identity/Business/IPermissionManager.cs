using System.Collections.Generic;
using System.Threading.Tasks;
using CustomFramework.Authorization.Attributes;

namespace CustomFramework.WebApiUtils.Identity.Business
{
    public interface IPermissionManager 
    {
        Task<bool> HasPermission(IEnumerable<PermissionAttribute> attributes, IList<string> roles);
        Task<bool> HasPermission(IEnumerable<PermissionAttribute> attributes);
    }

}