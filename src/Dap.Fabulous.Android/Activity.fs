[<AutoOpen>]
module Dap.Fabulous.Android.Activity

open System
open System.Threading.Tasks
open FSharp.Control.Tasks.V2

open Android.App
open Android.Content
open Android.Content.PM
open Android.Runtime
open Android.Views
open Android.Widget
open Android.OS
open Xamarin.Forms.Platform.Android

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Fabulous
open Dap.Android
open Dap.Gui
open Dap.Gui.Internal

type ARelativeLayout = Android.Widget.RelativeLayout

let getFabulousAndroidParam () =
    getAndroidParam ()

let setFabulousAndroidParam (param' : AndroidParam) =
    setAndroidParam param'

[<AbstractClass>]
type FabulousActivity () =
    inherit FormsAppCompatActivity ()
    abstract member UseFabulous : unit -> bool
    default __.UseFabulous () = true
    abstract member DoSetup : Bundle -> unit
    override this.OnCreate (bundle: Bundle) =
        base.OnCreate (bundle)
        Xamarin.Essentials.Platform.Init (this, bundle)
        logWip (getLogging ()) "1 FabulousActivity.OnCreated" (this.UseFabulous ())
        if this.UseFabulous () then
            Xamarin.Forms.Forms.Init (this, bundle)
        this.DoSetup bundle
        if hasFabulousParam () then
            let fabulousParam = getFabulousParam ()
            this.LoadApplication (fabulousParam.Application)
    override this.OnRequestPermissionsResult (requestCode: int, permissions: string[], [<GeneratedEnum>] grantResults: Android.Content.PM.Permission[]) =
        Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults)
        base.OnRequestPermissionsResult(requestCode, permissions, grantResults)
    member this.SwitchTheme (theme : int32) =
        this.SetTheme (theme)
        (*
        let logger = (getLogging ()) .GetLogger "FabulousActivity.SwitchTheme"
        Dap.Fabulous.Decorator.Util.getInstanceValue<FormsAppCompatActivity, ARelativeLayout> logger "_layout" this
        |> Option.iter (fun content ->
            let loading = new Android.Widget.TextView (Android.App.Application.Context)
            this.SetContentView (loading)
            this.SetTheme (theme)
            this.SetContentView (content)
        )
        *)
    member this.SwitchDarkTheme () =
        this.SwitchTheme (Resource.Style.Base_Theme_AppCompat)
    member this.SwitchLightTheme () =
        this.SwitchTheme (Resource.Style.Base_Theme_AppCompat_Light)