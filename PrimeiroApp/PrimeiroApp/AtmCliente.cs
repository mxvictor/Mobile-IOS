using Foundation;
using System;
using UIKit;

namespace PrimeiroApp
{
    public partial class AtmCliente : UIViewController
    {
        public AtmCliente (IntPtr handle) : base (handle)
        {
        }

        public string recebido;
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Perform any additional setup after loading the view, typically from a nib.
            LabelTextCliente.Text = recebido;
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }


    }
}