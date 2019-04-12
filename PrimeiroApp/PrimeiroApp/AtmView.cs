using Foundation;
using System;
using UIKit;

namespace PrimeiroApp
{
    public partial class AtmView : UIViewController
    {
        public AtmView (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);

            if (segue.Identifier == "ClienteDados")
            {
                var atmcliente = segue.DestinationViewController as AtmCliente;

                atmcliente.recebido = testeText.Text;

                
            }
        }
    }
}