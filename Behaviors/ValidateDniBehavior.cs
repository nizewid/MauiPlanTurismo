using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiPlanTurismo.Behaviors
{
    public class ValidateDniBehavior : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry txtBox)
        {
            txtBox.TextChanged += OnDniTextChanged;
        }
        protected override void OnDetachingFrom(Entry entry)
        {
            entry.TextChanged -= OnDniTextChanged;
            base.OnDetachingFrom(entry);
        }

        private void OnDniTextChanged(object sender, TextChangedEventArgs e)
        {
            bool ok = ValidateDni(e.NewTextValue);

            ((Entry)sender).TextColor = ok ? Colors.Black : Colors.DarkRed;
            ((Entry)sender).BackgroundColor = ok ? Colors.White : Colors.LightPink;
        }
        private bool ValidateDni(string dni)
        {
            bool ok = true;
            if (dni.Length != 9)
            {
                ok = false;
            }
            else
            {
                string dniNumbers = dni.Substring(0, dni.Length - 1);
                string dniLetter = dni.Substring(dni.Length - 1, 1);
                var numbersValid = int.TryParse(dniNumbers, out int dniComplete);
                if (!numbersValid)
                {
                    ok = false;
                }
                if (CalculateDniLetter(dniComplete) != dniLetter)
                {
                    ok = false;
                }
            }

            return ok;
        }
        private string CalculateDniLetter(int dniNumbers)
        {
            //Cargamos los digitos de control
            string[] control = { "T", "R", "W", "A", "G", "M", "Y", "F", "P", "D", "X", "B", "N", "J", "Z", "S", "Q", "V", "H", "L", "C", "K", "E" };
            var mod = dniNumbers % 23;
            return control[mod];
        }
    }
}
