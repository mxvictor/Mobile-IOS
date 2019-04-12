using Foundation;
using System;
using UIKit;

namespace PrimeiroApp
{
    public partial class TelaPrincipal : UIViewController
    {
        public TelaPrincipal (IntPtr handle) : base (handle)
        {
        }
        partial void ButtonText_TouchUpInside(UIButton sender)
        {
            var idade = Convert.ToInt32(TextField.Text) * 7;
            

            LabelText.Text = ("A Idade Humana do seu Cachorro e: " + Convert.ToString(idade));
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
    }
}