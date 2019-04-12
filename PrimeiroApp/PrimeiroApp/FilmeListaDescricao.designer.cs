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
    [Register ("FilmeListaDescricao")]
    partial class FilmeListaDescricao
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView ImageViewDesc { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel LabelTituloDesc { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView TextViewdesc { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (ImageViewDesc != null) {
                ImageViewDesc.Dispose ();
                ImageViewDesc = null;
            }

            if (LabelTituloDesc != null) {
                LabelTituloDesc.Dispose ();
                LabelTituloDesc = null;
            }

            if (TextViewdesc != null) {
                TextViewdesc.Dispose ();
                TextViewdesc = null;
            }
        }
    }
}