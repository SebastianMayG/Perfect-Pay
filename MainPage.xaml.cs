namespace Perfect_Pay
{
    public partial class MainPage : ContentPage
    {
        decimal bill;

        int tip, noPersons = 1;

        public MainPage()
        {
            InitializeComponent();
        }

        private void CalculateTotal()
        {
            var totalTip = (bill * tip) / 100;

            // Por persona
            var tipByPerson = (totalTip / noPersons);
            lblTipByPerson.Text = $"{tipByPerson:C}";

            // Subtotal
            var subtotal = (bill / noPersons);
            lblSubtotal.Text = $"{subtotal:C}";

            // Total
            var totalByPerson = (bill + totalTip) / noPersons;
            lblTotal.Text = $"{totalByPerson:C}";
        }

        private void txtBill_Completed(object sender, EventArgs e)
        {
            bill = decimal.Parse(txtBill.Text);
            CalculateTotal();
        }

        private void sldTip_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            tip = (int)sldTip.Value;
            lblTip.Text = $"Tip: {tip}%";
            CalculateTotal();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                var btn = (Button)sender;
                var perc = int.Parse(btn.Text.Replace("%", ""));
                sldTip.Value = perc;
            }
        }

        private void btnMinus_Clicked(object sender, EventArgs e)
        {
            if (noPersons > 1)
            {
                noPersons--;
            }

            lblNoPersons.Text = noPersons.ToString();
            CalculateTotal();
        }

        private void btnPlus_Clicked(object sender, EventArgs e)
        {
            noPersons++;
            lblNoPersons.Text = noPersons.ToString();
            CalculateTotal();
        }
    }

}
