module Demo.iOS.Program

open System

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.iOS
open Dap.Fabulous.iOS

open Demo.App
open Demo.Fabulous

[<EntryPoint>]
[<STAThread>]
let main argv =
    setFabulousIOSParam <| IOSParam.Create ("Demo")
    App.RunFabulous ("demo-.log")
