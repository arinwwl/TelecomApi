using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Windows;
using TelecomClient.Models;

namespace TelecomClient
{
    public partial class AbonentWindow : Window
    {
        public Abonent Abonent { get; private set; }

        public AbonentWindow(Abonent abonent = null)
        {
            InitializeComponent();

            if (abonent != null)
            {
                // если редактируем существующего абонента
                LastNameBox.Text = abonent.LastName;
                PhoneBox.Text = abonent.PhoneNumber;
                FeeBox.Text = abonent.MonthlyFee.ToString();
                Abonent = abonent;
            }
            else
            {
                // если добавляем нового
                Abonent = new Abonent();
            }
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LastNameBox.Text) || string.IsNullOrWhiteSpace(PhoneBox.Text))
            {
                MessageBox.Show("Фамилия и телефон обязательны!");
                return;
            }

            Abonent.LastName = LastNameBox.Text;
            Abonent.PhoneNumber = PhoneBox.Text;

            if (decimal.TryParse(FeeBox.Text, out var fee))
                Abonent.MonthlyFee = fee;
            else
                Abonent.MonthlyFee = 0;

            DialogResult = true;
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
