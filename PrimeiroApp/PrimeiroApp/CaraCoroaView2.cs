using Foundation;
using System;
using UIKit;

namespace PrimeiroApp
{
    public partial class CaraCoroaView2 : UIViewController
    {
        public CaraCoroaView2 (IntPtr handle) : base (handle)
        {
        }

        public int escolha;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.


            if (escolha == 1)
            {
                MoedaImageView.Image = UIImage.FromBundle("imagens-cara-coroa/moeda_coroa.png");
            }

            else
            {
                MoedaImageView.Image = UIImage.FromBundle("imagens-cara-coroa/moeda_cara.png");
            }
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}