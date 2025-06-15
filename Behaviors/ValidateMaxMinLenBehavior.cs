using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiPlanTurismo.Behaviors
{
    public class ValidateMaxMinLenBehavior : Behavior<Entry>
    {
        public int MinLength { get; set; }
        public int MaxLength { get; set; }
        protected override void OnAttachedTo(Entry entry)
        {
            entry.TextChanged += OnTextChanged;
        }
        protected override void OnDetachingFrom(Entry entry)
        {
            entry.TextChanged -= OnTextChanged;
            base.OnDetachingFrom(entry);
        }
        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            bool valid = ValidateTextField(e.NewTextValue);

            if (valid)
            {
                ((Entry)sender).TextColor = Colors.Black;
                ((Entry)sender).BackgroundColor = Colors.White;
            }
            else
            {
                ((Entry)sender).TextColor = Colors.Red;
                ((Entry)sender).BackgroundColor = Color.FromArgb("#FFCDD2");
            }
        }
        private bool ValidateTextField(string text)
        {
            bool valid = true;

            if (text.Length < MinLength || text.Length > MaxLength)
            {
                valid = false;
            }
            return valid;
        }
    }
}