// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace PrimeiroApp
{
    [Register ("CombustivelView")]
    partial class CombustivelView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ButtonCombustivel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel teste123 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField TextAlcool { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel TextEscolha { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField TextGasolina { get; set; }

        [Action ("ButtonCombustivel_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void ButtonCombustivel_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (ButtonCombustivel != null) {
                ButtonCombustivel.Dispose ();
                ButtonCombustivel = null;
            }

            if (teste123 != null) {
                teste123.Dispose ();
                teste123 = null;
            }

            if (TextAlcool != null) {
                TextAlcool.Dispose ();
                TextAlcool = null;
            }

            if (TextEscolha != null) {
                TextEscolha.Dispose ();
                TextEscolha = null;
            }

            if (TextGasolina != null) {
                TextGasolina.Dispose ();
                TextGasolina = null;
            }
        }
    }
}