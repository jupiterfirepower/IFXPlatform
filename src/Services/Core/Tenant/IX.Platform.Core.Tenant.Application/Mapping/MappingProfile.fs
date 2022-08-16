namespace IX.Platform.Core.Tenant.Application

open AutoMapper
open IX.Platform.Core.Tenant.Contracts.Entities
open IX.Platform.Core.Tenant.Contracts.Models
open System.Linq.Expressions
open System

module Mapping = 
       type AutoMapper.IMappingExpression<'TSource, 'TDestination> with
            // The overloads in AutoMapper's ForMember method seem to confuse
            // F#'s type inference, forcing you to supply explicit type annotations
            // for pretty much everything to get it to compile. By simply supplying
            // a different name, 
            member this.ForMemberFs<'TMember>
                    (destGetter:Expression<Func<'TDestination, 'TMember>>,
                     sourceGetter:Action<IMemberConfigurationExpression<'TSource, 'TDestination, 'TMember>>) =
                this.ForMember(destGetter, sourceGetter)

       type MappingProfile() =
             inherit Profile()
             do 
                base.CreateMap<Tenant, TenantEntity>() |> ignore

