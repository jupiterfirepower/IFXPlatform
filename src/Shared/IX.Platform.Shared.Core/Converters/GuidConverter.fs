namespace IX.Platform.Shared.Core

open System
//open System.Text.Json.Serialization

//open Newtonsoft.Json
open System.Text.Json

module Converters =

    /// GUID converter
    type GuidConverter() =
      inherit System.Text.Json.Serialization.JsonConverter<Guid>()

      override x.CanConvert t =
        typeof<Guid>.Equals t

      override x.Write(writer, value, serializer) =
        if value <> Guid.Empty then
          writer.WriteStringValue(value.ToString("N"))
        else
          writer.WriteStringValue("")

      override x.Read(reader, t, serializer) =
        let mutable guid = new Guid()
        let res = reader.TryGetGuid(&guid)
        Console.WriteLine("guid {0}", guid)
        guid
        //match reader.TokenType with
        //| JsonTokenType.None -> Guid.Empty 
        //| JsonTokenType.String ->
        //  match reader.GetString() with
        //  | str when String.IsNullOrEmpty str -> Guid.Empty 
        //  | str -> new Guid(str) 
        //| _ -> failwith "Invalid token when attempting to read Guid."