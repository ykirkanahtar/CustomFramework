using System.Collections.Generic;
using System.Threading.Tasks;
using CustomFramework.Authorization.Attributes;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.WebApiUtils.Identity.Contracts.Requests;
using CustomFramework.WebApiUtils.Identity.Models;

namespace CustomFramework.WebApiUtils.Identity.Business
{
    public interface IPermissionManager 
    {
        Task<bool> HasPermission(IEnumerable<PermissionAttribute> attributes);
    }

}