﻿using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;

namespace JPK
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<Plik> observableCollectionListaPlikow = new ObservableCollection<Plik>();
        private string plikXSD;
        private string plikXML;

        public MainWindow()
        {
            InitializeComponent();
            listBoxPliki.ItemsSource = observableCollectionListaPlikow;
        }

        private void buttonDodajPlik_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Pliki XML (*.XML)| *.XML";
            openFileDialog.Multiselect = true;
            openFileDialog.Title = "Wybierz pliki do wczytania";
            openFileDialog.FileName = "";

            if (openFileDialog.ShowDialog() == true)
            {
                int iloscPominietych = 0;
                StringBuilder pominietePliki = new StringBuilder();

                foreach (String file in openFileDialog.FileNames)
                {
                    try
                    {
                        if (observableCollectionListaPlikow.Count > 0)
                        {
                            bool czyIstnieje = false;
                            foreach (var item in observableCollectionListaPlikow)
                            {
                                if (String.Equals(file, item.Nazwa))
                                {
                                    czyIstnieje = true;
                                    iloscPominietych++;
                                    pominietePliki.AppendLine(file);
                                }
                            }
                            if (!czyIstnieje)
                            {
                                dodajElementDoListy(file, observableCollectionListaPlikow);
                                listBoxPliki.UnselectAll();
                            }
                        }
                        else
                        {
                            dodajElementDoListy(file, observableCollectionListaPlikow);
                            listBoxPliki.UnselectAll();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
                if (iloscPominietych > 0)
                {
                    String naglowek = "JPK";
                    String message = "Następujące pliki były dodane wcześniej i zostały pominięte:"
                        + Environment.NewLine
                        + pominietePliki.ToString();
                    MessageBox.Show(message, naglowek, MessageBoxButton.OK);
                }
            }
        }

        private void dodajElementDoListy(String element, ObservableCollection<Plik> listaPlikow)
        {
            Plik elementListy = new Plik();
            elementListy.Status = XML.walidacja(element, plikXSD);
            elementListy.CzyPolaczony = false;
            elementListy.IdPliku = "";
            elementListy.Nazwa = element;
            listaPlikow.Add(elementListy);
        }

        private void buttonWyczyscListe_Click(object sender, RoutedEventArgs e)
        {
            String message = "Czy na pewno usunąć wszystkie pliki?";
            if (MessageBox.Show(message, "JPK", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                observableCollectionListaPlikow.Clear();
            }
        }

        private void buttonUsunPlik_Click(object sender, RoutedEventArgs e)
        {
            String message = "Czy na pewno usunąć zaznaczony plik?";
            if (MessageBox.Show(message, "iJPK", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                int pozycjaDoUsuniecia = listBoxPliki.SelectedIndex;
                observableCollectionListaPlikow.RemoveAt(pozycjaDoUsuniecia);
            }
        }

        private void buttonWybierzXSD_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Pliki XSD (*.XSD)| *.XSD";
            openFileDialog.Multiselect = false;
            openFileDialog.Title = "Wybierz pliki do wczytania";

            if (openFileDialog.ShowDialog() == true)
            {
                labelPlikXSD.Content = openFileDialog.FileName;
                plikXSD = openFileDialog.FileName;
            }

        }

        private void listBoxPliki_PreviewMouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var item = (sender as ListBox).SelectedItem;
            if (item != null)
            {
                plikXML = (item as Plik).Nazwa.ToString();
                textBlockStatus.Document.Blocks.Clear();
                textBlockStatus.AppendText(XML.walidacjaInfo(plikXML, plikXSD));
            }


        }

        private void buttonPokazXML_Click(object sender, RoutedEventArgs e)
        {
            PodgladXML podgladXMLWindow = new PodgladXML();
            podgladXMLWindow.Owner = this;
            Uri myUri = new Uri(plikXML);
            podgladXMLWindow.webBrowserPodgladXML.Source = myUri;
            podgladXMLWindow.ShowDialog();
        }

        private void buttonPokazSprzedaz_Click(object sender, RoutedEventArgs e)
        {
            PodgladSprzedaz podgladSprzedazWindow = new PodgladSprzedaz(plikXML);
            podgladSprzedazWindow.Owner = this;
            podgladSprzedazWindow.ShowDialog();
        }
    }
}
