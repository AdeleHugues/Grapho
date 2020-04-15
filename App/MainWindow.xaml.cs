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
using LaTeXExporter.Classes_d_exportation;
using Domain.Classes_métier;
using TestApp.Pages;
using DAL.Repositories;

namespace TestApp
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Patient P = PatientRepository.getPatient(2);
            AffichagePages.Content = new PagePatient(P);
        }

        private void PagePatientClick(object sender, RoutedEventArgs e)
        {
        }

        private void PageAnamneseClick(object sender, RoutedEventArgs e)
        {
        }

        private void PageVariablesClick(object sender, RoutedEventArgs e)
        {
        }

        private void PagePositionGraphoClick(object sender, RoutedEventArgs e)
        {
        }
    }
}
