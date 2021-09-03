using System;
using System.Threading.Tasks;
using Api.Domain.DTOs.User;
using Api.Domain.Interfaces.Services.User;
using HotChocolate;

namespace Api.Application.GraphQL.GraphQlMutation
{
    public class Mutation
    {
        public async Task<UserDtoUpdateResult> CreatePut([Service] IUserService _service,
          string name, Guid id, string email)
        {
            UserDtoUpdate  userDtoCreate = new UserDtoUpdate
            {
                Name = name,
                Id = id,
                Email = email
                
            };

            var user = await _service.Put(userDtoCreate);
            return user;
        }
        
    }
}