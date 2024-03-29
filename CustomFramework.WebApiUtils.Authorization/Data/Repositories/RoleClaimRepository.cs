﻿using CustomFramework.Data.Contracts;
using CustomFramework.Data.Repositories;
using CustomFramework.Data.Utils;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomFramework.WebApiUtils.Authorization.Models;

namespace CustomFramework.WebApiUtils.Authorization.Data.Repositories
{
    public class RoleClaimRepository : BaseRepository<RoleClaim, int>, IRoleClaimRepository
    {
        public RoleClaimRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<RoleClaim> GetByApplicationIdAndRoleIdAndClaimIdAsync(int applicationId, int roleId, int claimId)
        {
            return await Get(p => p.ApplicationId == applicationId && p.RoleId == roleId && p.ClaimId == claimId).FirstOrDefaultAsync();
        }

        public async Task<ICustomList<Claim>> GetClaimsByRoleIdAsync(int roleId)
        {
            return await GetAll(p => p.RoleId == roleId).Include(p => p.Claim).Select(p => p.Claim)
                .ToCustomList();
        }

        public async Task<ICustomList<Role>> GetRolesByClaimIdAsync(int claimId)
        {
            return await GetAll(p => p.ClaimId == claimId).Include(p => p.Role).Select(p => p.Role)
                .ToCustomList();
        }

        public async Task<ICustomList<RoleClaim>> RolesAreAuthorizedForClaimAsync(int applicationId, IEnumerable<Role> roles, int claimId)
        {
            var predicate = PredicateBuilder.New<RoleClaim>();
            predicate = roles.Aggregate(predicate, (current, role) => current.Or(p => p.RoleId == role.Id));
            predicate = predicate.And(p => p.ClaimId == claimId);
            predicate = predicate.And(p => p.ApplicationId == applicationId);

            return await GetAll(predicate: predicate).ToCustomList();
        }
    }
}