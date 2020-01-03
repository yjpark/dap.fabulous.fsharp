[<RequireQualifiedAccess>]
module Dap.Fabulous.Uno.Feature.UnoPlatform

open System
open System.Threading

open Dap.Prelude
open Dap.Context
open Dap.Platform

open Dap.Gui
open Dap.Gui.App
open Dap.Fabulous
open Dap.Fabulous.Uno

let private onExit (logging : ILogging) (logger : ILogger) (exited : AutoResetEvent) =
    fun (_sender : obj) (cancelArgs : ConsoleCancelEventArgs) ->
        logWarn logger "Uno" "Quitting ..." cancelArgs
        logging.Close ()
        exited.Set() |> ignore

let private waitForExit (logging : ILogging) (logger : ILogger) =
    let exited = new AutoResetEvent(false)
    let onExit' = new ConsoleCancelEventHandler (onExit logging logger exited)
    Console.CancelKeyPress.AddHandler onExit'
    exited.WaitOne() |> ignore

type Context (logging : ILogging) =
    inherit GuiPlatform.Context<UnoParam, int> (logging, DotNetCore_Uno)
    override this.DoInit (param : UnoParam) =
        Uno.UI.Port <- param.Port
        Xamarin.Forms.Forms.Init ()
        let fabulousParam = getFabulousParam ()
        Xamarin.Forms.Forms.LoadApplication fabulousParam.Application
    override this.DoShow (param : UnoParam, presenter : IPresenter) =
        param.Port
    override this.DoRun (param : UnoParam) =
        waitForExit logging this
        0
    interface IUnoPlatform with
        member this.Param = this.Param
    member this.AsUnoPlatform = this :> IUnoPlatform
