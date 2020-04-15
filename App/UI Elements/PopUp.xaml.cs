using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DAL.Repositories;
using Domain.Classes_métier;

namespace TestApp.UI_Elements
{
    /// <summary>
    /// Logique d'interaction pour PopUp.xaml
    /// </summary>
    public partial class PopUp : UserControl
    {
        public PopUp()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty PatientProperty = DependencyProperty.Register
        (
             "PatientId",
             typeof(int),
             typeof(PopUp),
             new PropertyMetadata(0)
        );

        public int IdPatientActuel
        {
            get { return (int)GetValue(PatientProperty); }
            set { SetValue(PatientProperty, value); }
        }

        private void NouveauContactClick(object sender, RoutedEventArgs e)
        {

            if (TextBoxTel.Text != "" || TextBoxEmail.Text != "")
            {
                var radios = StackRadio.Children.OfType<RadioButton>();
                RadioButton checkedRadio = radios.FirstOrDefault(rb => rb.GroupName == "Contact" && (bool)rb.IsChecked);

                //Ajout d'un nouveau contact
                ContactRepository.nouveauContact(IdPatientActuel, new Contact(checkedRadio.Content.ToString(), TextBoxTel.Text, TextBoxEmail.Text, null));
            }

            Grid g = (Grid)this.Parent;
            Popup p = (Popup)g.Parent;
            p.IsOpen = false;
        }
    }
}
