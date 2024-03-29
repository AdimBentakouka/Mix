﻿using System;
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
using Videotheque.Model;
using Videotheque.ViewModel;

namespace Videotheque.View
{
    /// <summary>
    /// Logique d'interaction pour Amis.xaml
    /// </summary>
    public partial class Amis : Page
    {
        private AmisViewModel AmisViewModel;
        public Amis()
        {
            InitializeComponent();
            TextSearch.Text = "Rechercher un ami";
        }

        public new async void IsLoaded(object sender, RoutedEventArgs e)
        {
            AmisViewModel = DataContext as AmisViewModel;
            await AmisViewModel.InitAmi();
            ShowAmi();
        }

        private void ShowAmi()
        {
            if (AmisViewModel != null)
            {
                AmisViewModel.ShowAmi(TextSearch.Text);
            }
        }

        private void TextSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TextSearch.Text.Equals("Rechercher un ami"))
            {
                TextSearch.Text = "";
            }
        }

        private void TextSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            ShowAmi();
        }

        private void OnClickAmi(object sender, MouseButtonEventArgs e)
        {
            if (ListBoxAmis.SelectedIndex > -1)
            {
                AmisViewModel.setFocusAmis(ListBoxAmis.SelectedValue.ToString());
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AmisViewModel.ShowAddAmiPage();
        }
    }
}
