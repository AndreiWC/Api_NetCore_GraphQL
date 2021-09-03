using System.Threading;
using System.Threading.Tasks;
using Api.Domain.DTOs.User;
using HotChocolate;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;
using HotChocolate.Types;

namespace Api.Application.GraphQL.GraphQlInscricao
{
    public class Subscription
    {
        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<UserDto>> OnUserCreate([Service] ITopicEventReceiver eventReceiver,
            CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<string, UserDto>("User Created", cancellationToken);
        }


        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<UserDto>> OnUserGet([Service] ITopicEventReceiver eventReceiver,
            CancellationToken cancellationToken) => await eventReceiver.SubscribeAsync<string, UserDto>("ReturnedUser", cancellationToken);
    }
}