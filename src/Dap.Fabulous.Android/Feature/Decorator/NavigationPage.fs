[<RequireQualifiedAccess>]
module Dap.Fabulous.Android.Feature.Decorator.NavigationPage

open Xamarin.Forms
open Xamarin.Forms.Platform.Android
open Xamarin.Forms.Platform.Android.AppCompat

open Dap.Prelude
open Dap.Context
open Dap.Platform

open Dap.Fabulous.Decorator
open Dap.Fabulous.Android

type AToolbar = Android.Support.V7.Widget.Toolbar

// Xamarin.Forms.Platform.Android/AppCompat/NavigationPageRenderer.cs


type Decorator (logging : ILogging) =
    inherit EmptyContext (logging, SwitchCell.NativeDecoratorKind)
    interface NavigationPage.INativeDecorator with
        member this.SetBarActionColor (widget : NavigationPage) (color : Color) =
            // Can't change this easily, need to use Activity.SetTheme
            ()
        member this.UpdateBarStyle (widget : NavigationPage) =
            ()