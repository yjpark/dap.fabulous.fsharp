module Demo.Mac.Program

open System

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Mac
open Dap.Fabulous.Mac

open Demo.App
open Demo.Fabulous

[<EntryPoint>]
[<STAThread>]
let main argv =
    setFabulousMacParam <| MacParam.Create ("Demo")
    App.RunFabulous ("demo-.log")
