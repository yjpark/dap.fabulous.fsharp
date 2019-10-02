(* FAKE: 5.16.1 *)
#r "paket: groupref Build //"
#load ".fake/build.fsx/intellisense.fsx"

open Fake.Core
open Fake.Core.TargetOperators
open Fake.IO.Globbing.Operators

open Dap.Build

open FSharp.Data
open Dap.Prelude
open Dap.Context.Generator.Util

[<Literal>]
let Prepare = "Prepare"

let feed =
    NuGet.Feed.Create (
        apiKey = NuGet.Environment "API_KEY_nuget_org"
        //server = NuGet.ProGet "https://nuget.yjpark.org/nuget/dap",
        //apiKey = NuGet.Environment "API_KEY_nuget_yjpark_org"
    )

let projects =
    !! "src/Dap.Fabulous.Controls/*.csproj"
    ++ "src/Dap.Fabulous/*.fsproj"
    ++ "src/Dap.Fabulous.Android/*.fsproj"
    ++ "src/Dap.Fabulous.iOS/*.fsproj"
    ++ "src/Dap.Fabulous.Mac/*.fsproj"
    ++ "src/Dap.Fabulous.Forms/*.fsproj"
    ++ "src/Dap.Fabulous.Ooui/*.fsproj"

NuGet.create NuGet.release feed projects

Target.runOrDefault DotNet.Build

