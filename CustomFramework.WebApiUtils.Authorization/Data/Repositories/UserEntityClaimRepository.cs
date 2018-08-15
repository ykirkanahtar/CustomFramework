using CustomFramework.Authorization.Enums;
using CustomFramework.Data.Contracts;
using CustomFramework.Data.Repositories;
using CustomFramework.Data.Utils;
using CustomFramework.WebApiUtils.Authorization.Models;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace CustomFramework.WebApiUtils.Authorization.Data.Repositories
{
    public class UserEntityClaimRepository : BaseRepository<UserEntityClaim, int>, IUserEntityClaimRepository
    {
        public UserEntityClaimRepository(DbContext dbContext) : base(dbContext)
        {

        }

        public async Task<UserEntityClaim> GetByApplicationIdAndUserIdAndEntityAsync(int applicationId, int userId, string entity)
        {
            return await Get(p => p.ApplicationId == applicationId && p.UserId == userId && p.Entity == entity).FirstOrDefaultAsync();

        }

        public async Task<ICustomList<UserEntityClaim>> UserIsAuthorizedForEntityClaimAsync(int applicationId, int userId, string entity, Crud crud)
        {
            var predicate = PredicateBuilder.New<UserEntityClaim>();
            predicate = predicate.And(p => p.ApplicationId == applicationId);
            predicate = predicate.And(p => p.UserId == userId);
            predicate = predicate.And(p => p.Entity == entity);
            PredicateBuilderForCrud(ref predicate, crud);

            return await GetAll(predicate: predicate).ToCustomList();
        }

        public async Task<ICustomList<UserEntityClaim>> GetAllByEntityAsync(string entity)
        {
            return await GetAll(predicate: p => p.Entity == entity).ToCustomList();
        }

        public async Task<ICustomList<UserEntityClaim>> GetAllByUserIdAsync(int userId)
        {
            return await GetAll(predicate: p => p.UserId == userId).ToCustomList();
        }

        private static void PredicateBuilderForCrud(ref ExpressionStarter<UserEntityClaim> predicate, Crud crud)
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