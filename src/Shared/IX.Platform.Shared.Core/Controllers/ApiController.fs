namespace IX.Platform.Shared.Core

open Microsoft.AspNetCore.Mvc
open Microsoft.AspNetCore.Http
open MediatR
open Microsoft.AspNetCore.Mvc;
open Microsoft.Extensions.DependencyInjection;
open System

module Controllers =

    [<AbstractClass>]
    [<ApiController>]
    [<Route("api/[controller]")>]
    type ApiController(provider:IServiceProvider) =
        inherit ControllerBase()

        [<DefaultValue>] val mutable mediator:MediatR.IMediator

        member val Mediator = provider.GetService<MediatR.IMediator>() with get, set

        member x.HandleAsync<'a>(request : MediatR.IRequest<'a>) = async { return x.Mediator.Send(request) }


