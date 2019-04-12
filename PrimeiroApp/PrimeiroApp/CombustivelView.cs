using Foundation;
using System;
using UIKit;

namespace PrimeiroApp
{
    public partial class CombustivelView : UIViewController
    {
        public CombustivelView(IntPtr handle) : base(handle)
        {
        }

        partial void ButtonCombustivel_TouchUpInside(UIButton sender)
        {

            if (validarDados(TextAlcool.Text, TextGasolina.Text))
            {
                TextEscolha.Text = ("Campo Vazio, Informe um valor ");
            }

            else
            {
                var alcool = Convert.ToDouble(TextAlcool.Text);

                var gasolina = Convert.ToDouble(TextGasolina.Text);

                if ((alcool/gasolina) >= 0.7)
                {
                    TextEscolha.Text = ("Melhor utilizar Gasolina");
                }
                else
                {
                    TextEscolha.Text = ("Melhor utilizar Alcool");
                }


            }

        }

        public bool  validarDados(string textAlcool, string textGasolina)
        {
            return string.IsNullOrEmpty(textAlcool) || string.IsNullOrEmpty(textGasolina);
        }
    }
}