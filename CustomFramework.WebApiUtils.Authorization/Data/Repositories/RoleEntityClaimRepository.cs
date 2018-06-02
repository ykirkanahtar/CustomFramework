using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CustomFramework.Authorization.Enums;
using CustomFramework.Data;
using CustomFramework.Data.Contracts;
using CustomFramework.Data.Utils;
using CustomFramework.WebApiUtils.Authorization.Models;
using LinqKit;
using Microsoft.EntityFrameworkCore;

namespace CustomFramework.WebApiUtils.Authorization.Data.Repositories
{
    public class RoleEntityClaimRepository : BaseRepository<RoleEntityClaim, int>, IRoleEntityClaimRepository
    {
        public RoleEntityClaimRepository(DbContext dbContext) : base(dbContext)
        {

        }

        public async Task<RoleEntityClaim> GetByRoleIdAndEntityAsync(int roleId, string entity)
        {
            return await Get(p => p.RoleId == roleId && p.Entity == entity).FirstOrDefaultAsync();
        }

        public async Task<ICustomList<RoleEntityClaim>> RolesAreAuthorizedForEntityClaimAsync(IEnumerable<Role> roles, string entity, Crud crud)
        {
            var predicate = PredicateBuilder.New<RoleEntityClaim>();

            foreach (var role in roles)
            {
                predicate = predicate.Or(p => p.RoleId == role.Id);
            }

            predicate = predicate.And(p => p.Entity == entity);
            PredicateBuilderForCrud(ref predicate, crud);

            return await GetAll(predicate: predicate).ToCustomList();
        }

        public async Task<ICustomList<RoleEntityClaim>> GetAllByEntityAsync(string entity)
        {
            return await GetAll(p => p.Entity == entity).ToCustomList();
        }

        public async Task<ICustomList<RoleEntityClaim>> GetAllByRoleIdAsync(int roleId)
        {
            return await GetAll(p => p.RoleId == roleId).ToCustomList();
        }

        private static void PredicateBuilderForCrud(ref ExpressionStarter<RoleEntityClaim> predicate, Crud crud)
        {
            switch (crud)
            {
                case Crud.Create:
                    predicate = predicate.And(p => p.CanCreate);
                    break;
                case Crud.Update:
                    predicate = predicate.And(p => p.CanUpdate);
                    break;
                case Crud.Delete:
                    predicate = predicate.And(p => p.CanDelete);
                    break;
                case Crud.Select:
                    predicate = predicate.And(p => p.CanSelect);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(crud), crud, null);
            }
        }
    }
}