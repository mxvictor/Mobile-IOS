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
    [Register ("FilmeListaAdd")]
    partial class FilmeListaAdd
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ButtonCadastrarFilme { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ButtonLoadImage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField TextFieldNome { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView TextFieldSinopse { get; set; }

        [Action ("ButtonCadastrarFilme_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void ButtonCadastrarFilme_TouchUpInside (UIKit.UIButton sender);

        [Action ("ButtonLoadImage_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void ButtonLoadImage_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (ButtonCadastrarFilme != null) {
                ButtonCadastrarFilme.Dispose ();
                ButtonCadastrarFilme = null;
            }

            if (ButtonLoadImage != null) {
                ButtonLoadImage.Dispose ();
                ButtonLoadImage = null;
            }

            if (TextFieldNome != null) {
                TextFieldNome.Dispose ();
                TextFieldNome = null;
            }

            if (TextFieldSinopse != null) {
                TextFieldSinopse.Dispose ();
                TextFieldSinopse = null;
            }
        }
    }
}