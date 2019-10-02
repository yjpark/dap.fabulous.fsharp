(* FAKE: 5.16.1 *)
#r "paket: groupref Build //"
#load ".fake/build.fsx/intellisense.fsx"

#load "demo/Demo.App/Dsl.fs"

open Fake.Core
open Fake.Core.TargetOperators
open Fake.IO.Globbing.Operators

open Dap.Build

open FSharp.Data
open Dap.Prelude
open Dap.Context.Generator.Util

let projects =
    !! "demo/Demo.App/*.fsproj"
    ++ "demo/Demo.Fabulous/*.fsproj"
    ++ "demo/Demo.Ooui/*.fsproj"

DotNet.create DotNet.debug projects

DotNet.createPrepares [
    ["Demo.App"], fun _ ->
        Demo.App.Dsl.compile ["demo" ; "Demo.App"]
        |> List.iter traceSuccess
]

Target.runOrDefault DotNet.Build
