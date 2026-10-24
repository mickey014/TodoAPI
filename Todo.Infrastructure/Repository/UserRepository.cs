using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Todo.Domain.DomainEntities;
using Todo.Domain.RepositoryInterface;
using Todo.Infrastructure.Persistence.Entities;

namespace Todo.Infrastructure.Repository
{
    public class UserRepository : GenericRepository<UserDomain, User>, IUserRepository
    {
        public UserRepository(
            TodoAppDbContext todoAppDbContext, 
            IMapper _mapper) : base(todoAppDbContext, _mapper)
        {

        }

        public async Task<UserDomain> GetByEmailAsync(string emailAddress)
        {
            var user = await _todoAppDbContext.Users.FirstOrDefaultAsync(x => x.Email == emailAddress);

            return _mapper.Map<UserDomain>(user);
        }
    }
}
