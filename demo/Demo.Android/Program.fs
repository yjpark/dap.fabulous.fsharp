module Demo.Android.Program

open System
open Android.App

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Android
open Dap.Fabulous.Android

open Demo.App
open Demo.Fabulous

[<Activity (Label = "Fabulous.Demo", MainLauncher = true, Icon = "@mipmap/icon", Theme = "@style/MainTheme")>]
type MainActivity () =
    inherit FabulousActivity ()
    override this.UseFabulous () = true
    override this.DoSetup (bundle : Bundle) =
        let view = this.GetContentView ()
        view.SetBackgroundColor (Android.Graphics.Color.Black)
        let param = AndroidParam.Create ("Demo", this)
        setFabulousAndroidParam param
        App.RunFabulous ("demo-.log")
        |> ignore
