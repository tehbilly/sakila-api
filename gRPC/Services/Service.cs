using System.Threading.Tasks;
using Common;
using Grpc.Core;
using gRPC;
using Microsoft.Extensions.Logging;

namespace gRPC.Services
{
    public class Service : SakilaService.SakilaServiceBase
    {
        private readonly Repository _repository;

        public Service(Repository repository)
        {
            _repository = repository;
        }

        public override async Task ListActors(
            ListActorsRequest request,
            IServerStreamWriter<ListActorsResponse> responseStream,
            ServerCallContext context
        )
        {
            var actors = await _repository.GetActors();
            foreach (var actor in actors)
            {
                await responseStream.WriteAsync(new ListActorsResponse
                {
                    Actor = new Actor
                    {
                        Id = actor.ActorId,
                        FirstName = actor.FirstName,
                        LastName = actor.LastName,
                    }
                });
            }
        }

        public override async Task<GetActorResponse> GetActor(GetActorRequest request, ServerCallContext context)
        {
            var actor = await _repository.GetActor(request.Id);

            if (actor == null) return new GetActorResponse {Status = Status.Error};

            return new GetActorResponse
            {
                Actor = new Actor
                {
                    Id = actor.ActorId,
                    FirstName = actor.FirstName,
                    LastName = actor.LastName,
                }
            };
        }
    }
}