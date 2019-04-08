using Foundation;
using System;
using UIKit;

namespace PrimeiroApp
{
    public partial class CaraCoroaView : UIViewController
    {
        public CaraCoroaView(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);

            Random num = new Random();
            var num1 = num.Next(0, 2);

            var escolhaMoeda = segue.DestinationViewController as CaraCoroaView2;
            escolhaMoeda.escolha = num1;

        }


        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}