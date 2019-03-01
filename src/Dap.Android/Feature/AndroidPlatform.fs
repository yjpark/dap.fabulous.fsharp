[<RequireQualifiedAccess>]
module Dap.Android.Feature.AndroidPlatform

open System
open System.Threading

open Dap.Prelude
open Dap.Context
open Dap.Platform

open Dap.Gui
open Dap.Gui.App
open Dap.Android

type Context (logging : ILogging, kind : string) =
    inherit GuiPlatform.Context<AndroidParam, Activity> (logging, kind)
    new (l) =
        new Context (l, AndroidPlatformKind)
    override this.DoInit (param : AndroidParam) =
        ()
    override this.DoShow (param : AndroidParam, presenter : IPresenter) =
        param.Activity.SetContentView (presenter.Prefab0.Widget0 :?> Widget)
        param.Activity
    override this.DoRun (param : AndroidParam) =
        param.Actions
        |> List.iter (fun action -> action this)
        //Note: Android's Run will not block, since it's not called from main()
        0
    member this.Window = this.Param.Activity
    interface IAndroidPlatform with
        member this.Param = this.Param
        member this.Window = this.Window
    member this.AsAndroidPlatform = this :> IAndroidPlatform
    interface IFallback