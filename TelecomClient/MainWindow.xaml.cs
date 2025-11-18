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
using TelecomClient.Services;

using TelecomClient.Models;


namespace TelecomClient
{
    public partial class MainWindow : Window
    {
        private readonly ApiService _apiService;

        public MainWindow()
        {
            InitializeComponent();
            _apiService = new ApiService();
            LoadData();
        }

        private async Task LoadData()
        {
            var abonents = await _apiService.GetAbonents();
            AbonentsGrid.ItemsSource = abonents;
        }

        private async void Refresh_Click(object sender, RoutedEventArgs e)
        {
            await LoadData();
        }

        private async void Add_Click(object sender, RoutedEventArgs e)
        {
            var window = new AbonentWindow();
            if (window.ShowDialog() == true)
            {
                await _apiService.AddAbonent(window.Abonent);
                await LoadData();
            }
        }

        private async void Update_Click(object sender, RoutedEventArgs e)
        {
            if (AbonentsGrid.SelectedItem is Abonent selected)
            {
                var window = new AbonentWindow(selected);
                if (window.ShowDialog() == true)
                {
                    await _apiService.UpdateAbonent(selected.LastName, window.Abonent);
                    await LoadData();
                }
            }
            else
            {
                MessageBox.Show("Выберите абонента для изменения");
            }
        }


        private async void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (AbonentsGrid.SelectedItem is Abonent selected)
            {
                await _apiService.DeleteAbonent(selected.LastName);
                await LoadData();
            }
            else
            {
                MessageBox.Show("Выберите абонента для удаления");
            }
        }
    }
}


