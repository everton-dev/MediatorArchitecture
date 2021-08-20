using Domain.Models.Commands.Requests;
using Domain.Models.Commands.Responses;
using MediatR;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Pipelines
{
    public class ValidateCommandHandler<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> 
        where TResponse : DefaultResponse
    {
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (request is ValidateCommand validateCommand)
            {
                await validateCommand.Validate();
                if (!validateCommand.IsValid)
                {
                    var validations = new DefaultResponse();

                    foreach (var notification in validateCommand.Notifications)
                        validations.AddValidation(notification.Message);

                    var serializedParent = JsonConvert.SerializeObject(validations);
                    var response = JsonConvert.DeserializeObject<TResponse>(serializedParent);

                    //var response = validations as TResponse;

                    return response;
                }
            }

            TResponse result = await next();
            return result;
        }
    }
}