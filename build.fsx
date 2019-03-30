(* FAKE: 5.12.1 *)
#r "paket: groupref Main //"
#load ".fake/build.fsx/intellisense.fsx"

#load "demo/Demo.App/Dsl.fs"
#load "demo/Demo.Gui/Dsl/Prefabs.fs"

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

let libProjects =
    !! "src/Dap.Fabulous.Controls/*.csproj"
    ++ "src/Dap.Fabulous/*.fsproj"
    ++ "src/Dap.Fabulous.Android/*.fsproj"
    ++ "src/Dap.Fabulous.iOS/*.fsproj"
    ++ "src/Dap.Fabulous.Mac/*.fsproj"
    ++ "src/Dap.Fabulous.Forms/*.fsproj"
    ++ "src/Dap.Fabulous.Ooui/*.fsproj"

let allProjects =
    libProjects
    ++ "demo/Demo.App/*.fsproj"
    ++ "demo/Demo.Fabulous/*.fsproj"

DotNet.create (DotNet.mixed libProjects) allProjects

NuGet.extend NuGet.release feed libProjects

DotNet.createPrepares [
    ["Demo.App"], fun _ ->
        Demo.App.Dsl.compile ["demo" ; "Demo.App"]
        |> List.iter traceSuccess
    ["Demo.Gui"], fun _ ->
        Demo.Gui.Dsl.Prefabs.compile ["demo" ; "Demo.Gui"]
        |> List.iter traceSuccess
]

Target.runOrDefault DotNet.Build
