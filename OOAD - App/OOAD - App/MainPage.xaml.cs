using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using SQLite;
using OOAD___App.Model;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace OOAD___App
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 

    public sealed partial class MainPage : Page
    {
        SQLiteAsyncConnection conn = new SQLiteAsyncConnection("Baza.db");
        public MainPage()
        {
            this.InitializeComponent();


            /* Kreiranje Tabela
            conn.CreateTableAsync<Liga>();
            conn.CreateTableAsync<Igrac>();
            conn.CreateTableAsync<Klub>();
             */


            this.NavigationCacheMode = NavigationCacheMode.Required;

            /*Za bazu podataka je koristen SQLite i potrebno je podatke rucno unijeti u kodu*/

            /*Igrac l = new Igrac()
            {
                ime="Leon",
                prezime="Benko",
                datumRodenja=DateTime.Now,
                datumRegistracije=DateTime.Now,
                brojAsistencija=0,
                brojCrvenih=0,
                brojGolova=0,
                brojZutih=2,
                drzava="Hrvatska",
                jmbg="1225445",
                suspenzija=false,
                klub_id=1
            };
            conn.InsertAsync(l);*/

            /*Klub k = new Klub()
            {
                naziv = "FK Zeljo",
                grad = "Sarajevo",
                trener = "Deno",
                liveStream = true,
                liga_id = 1
            };
            conn.InsertAsync(k);*/

            /*Liga o = new Liga()
            {
                naziv = "BH Druga",
                brojKlubova = 10,
                pocetak = DateTime.Now,
                kraj = DateTime.Now
            };
            conn.InsertAsync(o);*/

            var rezLiga = conn.QueryAsync<Liga>("Select * from Liga");
            var listaL = rezLiga.Result;
            ComboBoxLiga.ItemsSource = listaL;
            ComboBoxLiga.DisplayMemberPath = "naziv";
        }


        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxLiga.SelectedIndex != -1)
            {
                TextBlockKlub.Visibility = Windows.UI.Xaml.Visibility.Visible;
                ComboBoxKlub.Visibility = Windows.UI.Xaml.Visibility.Visible;
                var liga = ComboBoxLiga.SelectedItem as Liga;
                var rezKlub = conn.QueryAsync<Klub>("Select * from Klub where liga_id="+liga.liga_id);
                var listaK = rezKlub.Result;
                ComboBoxKlub.ItemsSource = listaK;
                ComboBoxKlub.DisplayMemberPath = "naziv";
            }
            else
            {
                TextBlockKlub.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                ComboBoxKlub.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            }
        }

        private void ComboBoxKlub_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxKlub.SelectedIndex != -1)
            {
                ListBoxIgraci.Visibility = Windows.UI.Xaml.Visibility.Visible;

                var klub = ComboBoxKlub.SelectedItem as Klub;
                var rezIgrac = conn.QueryAsync<Igrac>("Select * from Igrac where klub_id="+klub.klub_id);
                var listaI = rezIgrac.Result;
                ListBoxIgraci.ItemsSource = listaI;
                ListBoxIgraci.DisplayMemberPath = "displayMember";
            }
            else
                ListBoxIgraci.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void ListBoxIgraci_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBoxIgraci.SelectedIndex != -1)
            {
                TextBlockZuti.Visibility = Windows.UI.Xaml.Visibility.Visible;
                TextBlockCrveni.Visibility = Windows.UI.Xaml.Visibility.Visible;
                ImageZuti.Visibility = Windows.UI.Xaml.Visibility.Visible;
                ImageCrveni.Visibility = Windows.UI.Xaml.Visibility.Visible;

                var igrac = ListBoxIgraci.SelectedItem as Igrac;
                TextBlockZuti.Text = igrac.brojZutih.ToString();
                TextBlockCrveni.Text = igrac.brojCrvenih.ToString();
            }
            else
            {
                TextBlockZuti.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                TextBlockCrveni.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                ImageZuti.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                ImageCrveni.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            }
        }
    }
}
