using System;
using System.Threading.Tasks;
using Api.Domain.DTOs.User;
using Api.Domain.Interfaces.Services.User;
using HotChocolate;

namespace Api.Application.GraphQL.GraphQlMutation
{
    public class Mutation
    {
        private UserDtoUpdate userDtoUpdate;
        private UserDtoCreate userDtoCreate;

        public async Task<UserDtoUpdateResult> CreatePut([Service] IUserService _service,
          string name, Guid id, string email)
        {
            userDtoUpdate = new UserDtoUpdate
            {
                Name = name,
                Id = id,
                Email = email


            };

            var user = await _service.Put(userDtoUpdate);
            return user;
        }

        public async Task<UserDtoCreateResult> CreatePost([Service] IUserService _service,
          string name, string email)
        {
            userDtoCreate = new UserDtoCreate
            {
                Name = name,
                Email = email


            };

            var user = await _service.Post(userDtoCreate);
            return user;
        }

        public async Task<bool> Delete([Service] IUserService _service,
         Guid id)
        {
            
            var user = await _service.Delete(id);
            return user;
        }

    }
}