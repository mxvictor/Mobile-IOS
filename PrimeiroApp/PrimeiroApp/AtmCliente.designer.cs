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
    [Register ("AtmCliente")]
    partial class AtmCliente
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel LabelTextCliente { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (LabelTextCliente != null) {
                LabelTextCliente.Dispose ();
                LabelTextCliente = null;
            }
        }
    }
}