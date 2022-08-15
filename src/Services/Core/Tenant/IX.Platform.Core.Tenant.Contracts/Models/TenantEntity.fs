namespace IX.Platform.Core.Tenant.Contracts.Models

open System
open System.Text.Json
open System.Text.Json.Serialization

//open System.Text.Json.Serialization
//open IX.Platform.Shared.Core.Converters
//open Newtonsoft.Json
open System.Text.Json.Serialization.Metadata
open IX.Platform.Shared.Core.Converters

[<CLIMutable>]
type TenantEntity = 
    { 
       //[<JsonPropertyName("Gid")>]
       //[<JsonConverter(typedefof<GuidConverter>)>]
       Gid: Guid
       //[<JsonPropertyName("CompanyName")>]
       CompanyName: string
    }



    

