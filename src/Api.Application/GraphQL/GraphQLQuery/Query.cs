using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.DTOs.User;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.User;
using HotChocolate;
using HotChocolate.Subscriptions;

namespace Api.Application.GraphQL.GraphQLQuery
{
    public class Query
    {

        public async Task<IEnumerable<UserDto>> GetAllUser([Service] IUserService _userService) => await _userService.GetAll();


        public async Task<UserDto> GetUser([Service] IUserService _userService,
           [Service] ITopicEventSender eventSender, Guid id)
        {
            var user = _userService.Get(id);
            await eventSender.SendAsync("Returneduser", user);
            return await user;
        }

    }
}