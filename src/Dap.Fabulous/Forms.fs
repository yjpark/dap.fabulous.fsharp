[<AutoOpen>]
module Dap.Fabulous.BaseForm

open Microsoft.Maui
open Microsoft.Maui.Graphics
open Microsoft.Maui.Controls
open Fabulous
open Fabulous.Maui

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui
open Dap.Gui.Internal
open Dap.Fabulous

module ViewTypes = Dap.Fabulous.View.Types
module ViewLogic = Dap.Fabulous.View.Logic

[<AbstractClass>]
type BaseForm<'form, 'page when 'form :> IPrefab and 'page :> Page> (logging : ILogging, page : 'page) =
    inherit BasePrefab<'form, LabelProps, 'page> (FormKind, LabelProps.Create, logging, page)
    member this.Page = this.Widget
    interface IForm<'page> with
        member this.Page = this.Page
    interface IForm with
        member this.Page0 = this.Page :> Page

(*
let private createLoadingPage (backgroundColor : Color) (brandImage : string option) (brandImageX : float option) (brandImageY : float option) =
    let content' =
        brandImage
        |> Option.map (fun image ->
            [
                View.Image(source = image, anchorX = 0.5, anchorY = 0.5)
                    .LayoutFlags(AbsoluteLayoutFlags.PositionProportional)
                    .LayoutBounds(
                        new Rectangle (
                            brandImageX |> Option.defaultValue 0.5,
                            brandImageY |> Option.defaultValue 0.5,
                            AbsoluteLayout.AutoSize,
                            AbsoluteLayout.AutoSize
                        )
                    )
            ]
        )|> Option.defaultValue []
    let page =
        View.ContentPage (
            "loading",
            View.AbsoluteLayout (
                backgroundColor = backgroundColor,
                children = content'
            )
        )
    page.backgroundColor(backgroundColor)
    page.Compile().Target :?> ContentPage

type LoadingForm (logging : ILogging, backgroundColor : Color, ?brandImage : string, ?brandImageX : float, ?brandImageY : float) =
    inherit BaseForm<LoadingForm, ContentPage> (logging, createLoadingPage backgroundColor brandImage brandImageX brandImageY)
    new (l : ILogging) =
        new LoadingForm (l, Colors.White)
    override this.Self = this
    override __.Spawn l = new LoadingForm (l)
    interface ILoadingForm
    interface IFallback
*)
