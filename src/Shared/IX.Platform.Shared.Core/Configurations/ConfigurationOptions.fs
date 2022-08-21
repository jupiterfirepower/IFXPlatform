namespace IX.Platform.Shared.Core

open System

module Configurations =

    [<AbstractClass>]
    type ConfigurationOptions() =
        abstract OptionsName : string with get

    type ConnectionStringsOptions() =
        inherit ConfigurationOptions()

        override x.OptionsName = "ConnectionStrings"

        member val DefaultConnection = String.Empty with get, set

