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
using TestApp.UI_Elements;
using Domain.Classes_métier;
using DAL.Repositories;

namespace TestApp.Pages
{
    /// <summary>
    /// Logique d'interaction pour PagePatient.xaml
    /// </summary>
    public partial class PagePatient : Page
    {
        protected Patient patient;
        protected bool modification;
        public string[] placeholders = new string[] { "Nom", "Prénom" };
        public PagePatient(Patient _patient)
        {
            InitializeComponent();
            if (_patient != null)
            {
                patient = _patient;
                modification = true;
            }
            else
            {
                patient = new Patient(null, null, false, DateTime.Now, null, null, null);
                modification = false;
                int id = PatientRepository.nouveauPatient(patient, -1);
                Tests tests = new Tests();
                TestsRepository.nouveauxTests(patient.PatientId, tests);
                patient.PatientId = id;
            }
            PopUpContact.IdPatientActuel = patient.PatientId;
            InitialisationComposants();
        }


        //================= INFORMATIONS GENERALES =================
        public void InitialisationComposants()
        {
            Id.Content = patient.PatientId.ToString();
            DatePickerJour.SelectedDate = DateTime.Now;

            if (modification == true)
            {
                TextBox1.Text = patient.PatientNom;
                TextBox2.Text = patient.PatientPrenom;
                DatePickerNaissance.SelectedDate = patient.PatientNaissance;
                TextBlockAffichageAge.Content = (DateTime.Now.Year - patient.PatientNaissance.Year).ToString() + " ans " + (DateTime.Now.Month - patient.PatientNaissance.Month).ToString() + " mois ";

                var contacts = ContactRepository.getContactsPatient(patient.PatientId);
                foreach (Contact contact in contacts) 
                    creerGridContact(contact.ContactDesignation, contact.ContactTelephone, contact.ContactMail);

                var adresses = AdresseRepository.getAdressesPatient(patient.PatientId);
                foreach (Adresse adresse in adresses)
                    creerGridAdresse(adresse.AdresseDesignation, adresse.AdresseRue, adresse.AdresseCP, adresse.AdresseVille);

                if (DatePickerJour.SelectedDate != null && DatePickerNaissance.SelectedDate != null && (DateTime)DatePickerNaissance.SelectedDate != DateTime.MinValue)
                    TextBlockAffichageAge.Content = calculerAge((DateTime)DatePickerNaissance.SelectedDate, (DateTime)DatePickerJour.SelectedDate);

                Tests tests = TestsRepository.getTestsPatient(patient.PatientId);
                if(tests != null)
                {
                    OrigineDemande.Text = tests.OrigineDemande;
                    Acuite.Text = tests.Acuite;
                    Orthoptie.Text = tests.Orthoptie;
                    ReflexeVisuel.Text = tests.Reflexe;
                    TestLateralite.Text = tests.Lateralite;
                    ConnaissanceLateralite.Text = tests.ConnaissanceLateralite;
                    Pattes.Text = tests.Pattes;
                }

                var suivis = SuiviRepository.getSuivisPatient(patient.PatientId);
                if(suivis != null)
                {
                    foreach (Suivi suivi in suivis)
                    {
                        Specialiste specialiste = SpecialisteRepository.getSpecialiste(suivi.SpecialisteId);
                        creerGridSuivis(specialiste, suivi.Debut, suivi.Fin);
                    }
                }

            }
        }
        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            int index = int.Parse(textBox.Name.Substring(7, 1));
            if (textBox.Text != placeholders[index - 1])
            {
                if (index == 1)
                    PatientRepository.updateNomPatient(patient.PatientId, textBox.Text);
                else
                    PatientRepository.updatePrenomPatient(patient.PatientId, textBox.Text);
            }
        }
        private void creerGridContact(string _designation, string _telephone, string _mail)
        {
            //On transforme la dernière ligne en plus petite
            int nbLignes = GridContacts.RowDefinitions.Count;
            GridContacts.RowDefinitions[nbLignes - 1].Height = new GridLength(0.26, GridUnitType.Star);

            //On définit une nouvelle ligne de la bonne hauteur
            RowDefinition nouvelleLigne = new RowDefinition();
            if (1 - nbLignes * 0.26 > 0)
                nouvelleLigne.Height = new GridLength( 1 - nbLignes * 0.26, GridUnitType.Star);
            else
                nouvelleLigne.Height = new GridLength(0.1, GridUnitType.Star);


            //On l'ajoute à la grille
            GridContacts.RowDefinitions.Add(nouvelleLigne);

            //On lui donne le nom adéquat
            nouvelleLigne.Name = "GridContactLigne" + (nbLignes + 1).ToString();

            Grid nouvelleGrid = new Grid();


            ColumnDefinition colonne1 = new ColumnDefinition();
            colonne1.Width = new GridLength(0.29, GridUnitType.Star);
            ColumnDefinition colonne2 = new ColumnDefinition();
            colonne2.Width = new GridLength(0.64, GridUnitType.Star);
            ColumnDefinition colonne3 = new ColumnDefinition();
            colonne3.Width = new GridLength(0.07, GridUnitType.Star);
            nouvelleGrid.ColumnDefinitions.Add(colonne1);
            nouvelleGrid.ColumnDefinitions.Add(colonne2);
            nouvelleGrid.ColumnDefinitions.Add(colonne3);

            Image image = new Image();
            image.Width = 60;
            image.Height = 60;
            BitmapImage b = new BitmapImage();
            b.BeginInit();
            if (_designation == "Père" || _designation == "Mère" || _designation == "Patient")
                b.UriSource = new Uri("C://Users//adele//Documents//2A//S2//04-Projetinfo//Images//1x//" + _designation + ".png");
            else
                b.UriSource = new Uri("C://Users//adele//Documents//2A//S2//04-Projetinfo//Images//1x//Autre.png");
            b.EndInit();
            image.Source = b;
            Grid.SetColumn(image, 0);
            nouvelleGrid.Children.Add(image);

            Grid.SetRow(nouvelleGrid, nbLignes - 1);
            GridContacts.Children.Add(nouvelleGrid);

            Grid infosContact = new Grid();
            RowDefinition ligneA = new RowDefinition();
            RowDefinition ligneB = new RowDefinition();
            RowDefinition ligneC = new RowDefinition();
            RowDefinition ligneD = new RowDefinition();
            RowDefinition ligneE = new RowDefinition();

            ligneA.Height = new GridLength(0.2, GridUnitType.Star);
            ligneB.Height = new GridLength(0.5, GridUnitType.Star);
            ligneC.Height = new GridLength(0.25, GridUnitType.Star);
            ligneD.Height = new GridLength(0.25, GridUnitType.Star);
            ligneE.Height = new GridLength(0.2, GridUnitType.Star);

            infosContact.RowDefinitions.Add(ligneA);
            infosContact.RowDefinitions.Add(ligneB);
            infosContact.RowDefinitions.Add(ligneC);
            infosContact.RowDefinitions.Add(ligneD);
            infosContact.RowDefinitions.Add(ligneE);

            TextBlock designation = new TextBlock();
            designation.Text = _designation;
            designation.FontFamily = new FontFamily("Roboto Light");
            designation.FontSize = 15;
            designation.Foreground = new SolidColorBrush(Color.FromArgb(100, 255, 125, 35));
            Grid.SetRow(designation, 1);
            infosContact.Children.Add(designation);

            TextBlock mail = new TextBlock();
            mail.Text = _mail;
            mail.FontFamily = new FontFamily("Roboto Light");
            mail.FontSize = 11;
            designation.Foreground = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#221d38"));
            Grid.SetRow(mail, 2);
            infosContact.Children.Add(mail);

            TextBlock telephone = new TextBlock();
            telephone.Text = _telephone;
            telephone.FontFamily = new FontFamily("Roboto Light");
            telephone.FontSize = 11;
            telephone.Foreground = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#221d38"));
            Grid.SetRow(telephone, 3);
            infosContact.Children.Add(telephone);

            Grid.SetColumn(infosContact, 1);
            nouvelleGrid.Children.Add(infosContact);


        }
        private void creerGridAdresse(string _designation, string _rue, string _CP, string _ville)
        {
            int nbLignes = GridAdresses.RowDefinitions.Count;

            //On crée un nouvelle ligne dans la grid principale
            RowDefinition nouvelleLigne = new RowDefinition();
            nouvelleLigne.Height = new GridLength(1, GridUnitType.Star);
            GridAdresses.RowDefinitions.Add(nouvelleLigne);

            //On définit une nouvelle grille qui contiendra la nouvelle adresse
            Grid nouvelleGrid = new Grid();
            Thickness margin = nouvelleGrid.Margin;
            margin.Top = 10;
            margin.Bottom = 10;
            nouvelleGrid.Margin = margin;

            RowDefinition ligne1 = new RowDefinition();
            RowDefinition ligne2 = new RowDefinition();
            RowDefinition ligne3 = new RowDefinition();

            ligne1.Height = new GridLength(1, GridUnitType.Star);
            ligne2.Height = new GridLength(1, GridUnitType.Star);
            ligne3.Height = new GridLength(1, GridUnitType.Star);

            nouvelleGrid.RowDefinitions.Add(ligne1);
            nouvelleGrid.RowDefinitions.Add(ligne2);
            nouvelleGrid.RowDefinitions.Add(ligne3);

            //On définit l'image de l'adresse en fonction de sa désignation
            Image image = new Image();
            image.Width = 90;
            image.Height = 90;
            BitmapImage b = new BitmapImage();
            b.BeginInit();
            if (_designation == "Père" || _designation == "Mère")
                b.UriSource = new Uri("C://Users//adele//Documents//2A//S2//04-Projetinfo//Images//1x//" + _designation + ".png");
            else
                b.UriSource = new Uri("C://Users//adele//Documents//2A//S2//04-Projetinfo//Images//1x//Autre.png");
            b.EndInit();
            image.Source = b;
            Grid.SetRow(image, 0);
            nouvelleGrid.Children.Add(image);

            //On définit la rue et la ville
            TextBlock rue = new TextBlock();
            rue.Text = _rue;
            rue.FontFamily = new FontFamily("Roboto Light");
            rue.FontSize = 12;
            rue.Foreground = new SolidColorBrush(Color.FromRgb(34, 29, 56));
            rue.HorizontalAlignment = HorizontalAlignment.Center;
            margin = rue.Margin;
            margin.Top = 5;
            rue.Margin = margin;
            Grid.SetRow(rue, 1);
            nouvelleGrid.Children.Add(rue);

            TextBlock ville = new TextBlock();
            ville.Text = _CP + " " + _ville;
            ville.FontFamily = new FontFamily("Roboto Light");
            ville.FontSize = 12;
            ville.Foreground = new SolidColorBrush(Color.FromRgb(34, 29, 56));
            ville.HorizontalAlignment = HorizontalAlignment.Center;
            Grid.SetRow(ville, 2);
            nouvelleGrid.Children.Add(ville);

            GridAdresses.Children.Add(nouvelleGrid);
            Grid.SetRow(nouvelleGrid, nbLignes-1);

        }
        private void DatePicker_CalendarClosed(object sender, RoutedEventArgs e)
        {
            DatePicker datePicker = (DatePicker)sender;
            if (datePicker.Name == "DatePickerNaissance")
                PatientRepository.updateNaissancePatient(patient.PatientId, (DateTime)datePicker.SelectedDate);
            
            if (DatePickerJour.SelectedDate != null && DatePickerNaissance.SelectedDate != null)
                TextBlockAffichageAge.Content = calculerAge((DateTime)DatePickerNaissance.SelectedDate, (DateTime)DatePickerJour.SelectedDate);
        }
        private string calculerAge(DateTime naissance, DateTime jour)
        {
            int annees;
            int mois = 0;

            annees = jour.Year - naissance.Year;

            if (jour.Month < naissance.Month)
            {
                annees--;
                mois += 12 - naissance.Month;
                mois += jour.Month;
            }
            else
                mois = jour.Month - naissance.Month;

            return annees + " ans " + mois + " mois";
        }
        private void ajouterUnContactClick(object sender, RoutedEventArgs e)
        {
            PopUpEnglobanteContact.IsOpen = true;
        }
        private void PopUpClosed(object sender, EventArgs e)
        {
            GridContacts.Children.Clear();

            var contacts = ContactRepository.getContactsPatient(patient.PatientId);
            foreach (Contact contact in contacts)
                creerGridContact(contact.ContactDesignation, contact.ContactTelephone, contact.ContactMail);
        }

        //================= SUIVI =================
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox combobox = (ComboBox)sender;
            ComboBoxItem typeItem = (ComboBoxItem)combobox.SelectedItem;
            string value = typeItem.Content.ToString();

            switch(combobox.Name)
            {
                case "OrigineDemande":
                    TestsRepository.updateOrigineDemandeTests(patient.PatientId, value);
                    break;
                case "Acuite":
                    TestsRepository.updateAcuiteTests(patient.PatientId, value);
                    break;
                case "Orthoptie":
                    TestsRepository.updateOrthoptieTests(patient.PatientId, value);
                    break;
                case "ReflexeVisuel":
                    TestsRepository.updateReflexeTests(patient.PatientId, value);
                    break;
                case "TestLateralite":
                    TestsRepository.updateLateraliteTests(patient.PatientId, value);
                    break;
                case "ConnaissanceLateralite":
                    TestsRepository.updateConnaissanceLateraliteTests(patient.PatientId, value);
                    break;
                case "Pattes":
                    TestsRepository.updatePattesTests(patient.PatientId, value);
                    break;
            }
        }
        private void creerGridSuivis(Specialiste _specialiste, DateTime _debut, DateTime _fin)
        {
            //On transforme la dernière ligne en plus petite
            int nbLignes = GridSuivis.RowDefinitions.Count;
            GridSuivis.RowDefinitions[nbLignes - 1].Height = new GridLength(0.4, GridUnitType.Star);

            //On définit une nouvelle ligne de la bonne hauteur
            RowDefinition nouvelleLigne = new RowDefinition();
            if (1 - nbLignes * 0.4 > 0)
            {
                nouvelleLigne.Height = new GridLength(1 - nbLignes * 0.4, GridUnitType.Star);
                //On l'ajoute à la grille
                GridSuivis.RowDefinitions.Add(nouvelleLigne);
            }

            Border border = new Border();
            border.BorderThickness = new Thickness(0);
            border.CornerRadius = new CornerRadius(15);
            border.Background = new SolidColorBrush(Color.FromRgb(212, 210, 234));
            border.Margin = new Thickness(10, 5, 10, 5);

            GridSuivis.Children.Add(border);
            Grid.SetRow(border, nbLignes - 1);

            Grid nouvelleGrid = new Grid();
            border.Child = nouvelleGrid;

            //Définition des colonnes
            ColumnDefinition colonne1 = new ColumnDefinition();
            ColumnDefinition colonne2 = new ColumnDefinition();
            colonne1.Width = new GridLength(0.4, GridUnitType.Star);
            colonne2.Width = new GridLength(0.6, GridUnitType.Star);
            nouvelleGrid.ColumnDefinitions.Add(colonne1);
            nouvelleGrid.ColumnDefinitions.Add(colonne2);

            Grid affichageSpecialiste = new Grid();
            nouvelleGrid.Children.Add(affichageSpecialiste);
            Grid.SetColumn(affichageSpecialiste, 0);

            RowDefinition ligne1 = new RowDefinition();
            RowDefinition ligne2 = new RowDefinition();
            ligne1.Height = new GridLength(1, GridUnitType.Star);
            ligne2.Height = new GridLength(1, GridUnitType.Star);
            affichageSpecialiste.RowDefinitions.Add(ligne1);
            affichageSpecialiste.RowDefinitions.Add(ligne2);

            TextBlock specialite = new TextBlock();
            specialite.Text = _specialiste.SpecialisteSpecialite;
            specialite.FontSize = 14;
            specialite.FontFamily = new FontFamily("Roboto");
            specialite.Foreground = new SolidColorBrush(Color.FromRgb(66, 71, 120));
            specialite.VerticalAlignment = VerticalAlignment.Bottom;
            Thickness margin = specialite.Margin;
            margin.Left = 20;
            margin.Top = 5;
            specialite.Margin = margin;
            affichageSpecialiste.Children.Add(specialite);
            Grid.SetRow(specialite, 0);

            TextBlock specialiste = new TextBlock();
            specialiste.Text = _specialiste.SpecialistePrenom + " " + _specialiste.SpecialisteNom;
            specialiste.FontSize = 12;
            specialiste.FontFamily = new FontFamily("Roboto Light");
            specialiste.Foreground = new SolidColorBrush(Color.FromRgb(142, 137, 162));
            specialiste.VerticalAlignment = VerticalAlignment.Top;
            margin = specialiste.Margin;
            margin.Left = 20;
            specialiste.Margin = margin;
            affichageSpecialiste.Children.Add(specialiste);
            Grid.SetRow(specialiste, 1);


            Grid affichageSuivi = new Grid();
            nouvelleGrid.Children.Add(affichageSuivi);
            Grid.SetColumn(affichageSuivi, 1);

            ColumnDefinition colonneA = new ColumnDefinition();
            ColumnDefinition colonneB = new ColumnDefinition();
            ColumnDefinition colonneC = new ColumnDefinition();
            colonneA.Width = new GridLength(1, GridUnitType.Star);
            colonneB.Width = new GridLength(1, GridUnitType.Star);
            colonneC.Width = new GridLength(1, GridUnitType.Star);
            affichageSuivi.ColumnDefinitions.Add(colonneA);
            affichageSuivi.ColumnDefinitions.Add(colonneB);
            affichageSuivi.ColumnDefinitions.Add(colonneC);

            string[] mois = new string[] { "Janvier", "Février", "Mars", "Avril", "Mai", "Juin", "Juillet", "Août", "Septembre", "Octobre", "Novembre", "Décembre" };

            TextBlock debut = new TextBlock();
            debut.Text = mois[_debut.Month - 1] + " " + _debut.Year;
            debut.FontSize = 12;
            debut.FontFamily = new FontFamily("Roboto Light");
            debut.Foreground = new SolidColorBrush(Color.FromRgb(66, 71, 120));
            debut.HorizontalAlignment = HorizontalAlignment.Right;
            debut.VerticalAlignment = VerticalAlignment.Center;
            affichageSuivi.Children.Add(debut);
            Grid.SetColumn(debut, 0);

            Separator separator = new Separator();
            margin = separator.Margin;
            margin.Left = 15;
            margin.Right = 15;
            separator.Margin = margin;
            affichageSuivi.Children.Add(separator);
            Grid.SetColumn(separator, 1);

            TextBlock fin = new TextBlock();
            fin.Text = mois[_fin.Month - 1] + " " + _fin.Year;
            fin.FontSize = 12;
            fin.FontFamily = new FontFamily("Roboto Light");
            fin.Foreground = new SolidColorBrush(Color.FromRgb(66, 71, 120));
            fin.HorizontalAlignment = HorizontalAlignment.Left;
            fin.VerticalAlignment = VerticalAlignment.Center;
            affichageSuivi.Children.Add(fin);
            Grid.SetColumn(fin, 2);

        }


        //================= DRAG AND DROP =================
        private void panel_Supr(object sender, DragEventArgs e)
        {

            // If an element in the panel has already handled the drop,
            // the panel should not also handle it.
            if (e.Handled == false)
            {
                Panel _panel = (Panel)sender;
                UIElement _element = (UIElement)e.Data.GetData("Object");

                if (_panel != null && _element != null)
                {
                    // Get the panel that the element currently belongs to,
                    // then remove it from that panel and add it the Children of
                    // the panel that its been dropped on.
                    Panel _parent = (Panel)VisualTreeHelper.GetParent(_element);

                    if (_parent != null)
                    {
                        if (e.KeyStates == DragDropKeyStates.ControlKey &&
                            e.AllowedEffects.HasFlag(DragDropEffects.Copy))
                        {
                            _parent.Children.Remove(_element);

                            // set the value to return to the DoDragDrop call
                            e.Effects = DragDropEffects.Copy;
                        }
                        else if (e.AllowedEffects.HasFlag(DragDropEffects.Move))
                        {
                            _parent.Children.Remove(_element);
                            // set the value to return to the DoDragDrop call
                            e.Effects = DragDropEffects.Move;
                        }
                    }
                }
            }
        }
        private void panel_Drop(object sender, DragEventArgs e)
        {
            // If an element in the panel has already handled the drop,
            // the panel should not also handle it.
            if (e.Handled == false)
            {
                Panel _panel = (Panel)sender;
                UIElement _element = (UIElement)e.Data.GetData("Object");

                if (_panel != null && _element != null)
                {
                    // Get the panel that the element currently belongs to,
                    // then remove it from that panel and add it the Children of
                    // the panel that its been dropped on.
                    Panel _parent = (Panel)VisualTreeHelper.GetParent(_element);

                    if (_parent != null)
                    {
                        if (e.KeyStates == DragDropKeyStates.ControlKey &&
                            e.AllowedEffects.HasFlag(DragDropEffects.Copy))
                        {
                            Circle _circle = new Circle((Circle)_element);
                            _panel.Children.Add(_circle);
                            // set the value to return to the DoDragDrop call
                            e.Effects = DragDropEffects.Copy;
                        }
                        else if (e.AllowedEffects.HasFlag(DragDropEffects.Move))
                        {
                            _parent.Children.Remove(_element);
                            _panel.Children.Add(_element);
                            // set the value to return to the DoDragDrop call
                            e.Effects = DragDropEffects.Move;
                        }
                    }
                }
            }


        }
        private void SexeLateralite_Loaded(object sender, RoutedEventArgs e)
        {
            BitmapImage btpImg = new BitmapImage();
            btpImg.BeginInit();

            Circle C = (Circle)sender;
            switch(C.Name)
            {
                case "GarconDroitier":
                    btpImg.UriSource = new Uri(@"C:/Users/adele/Pictures/lac bleu 2.jpg");
                    break;
                case "GarconGaucher":
                    btpImg.UriSource = new Uri(@"C:/Users/adele/Pictures/2019-2020/Campagnes 2020/20200130_225525_964.jpg");
                    break;
                case "FilleDroitiere":
                    btpImg.UriSource = new Uri(@"C:/Users/adele/Pictures/IMG_7868.JPG");
                    break;
                case "FilleGauchere":
                    btpImg.UriSource = new Uri(@"C:/Users/adele/Pictures/2019-2020/Campagnes 2020/20200130_225525_964.jpg");
                    break;
            }

            btpImg.EndInit();
            C.icone.ImageSource = btpImg;
        }

    }
}
