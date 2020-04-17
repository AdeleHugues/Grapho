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

namespace TestApp.UI_Elements
{
    /// <summary>
    /// Logique d'interaction pour Circle.xaml
    /// </summary>
    public partial class Circle : UserControl
    {
        private Brush _previousFill = null;
        public static readonly DependencyProperty NomProperty = DependencyProperty.Register
        (
             "NomProche",
             typeof(string),
             typeof(Circle)
        );

        public string NomProche
        {
            get { return (string)GetValue(NomProperty); }
            set { SetValue(NomProperty, value); }
        }

        public static readonly DependencyProperty AgeProperty = DependencyProperty.Register
        (
             "AgeProche",
             typeof(int),
             typeof(Circle)
        );

        public int AgeProche
        {
            get { return (int)GetValue(AgeProperty); }
            set { SetValue(AgeProperty, value); }
        }

        public Circle()
        {
            InitializeComponent();
        }

        public Circle(Circle c)
        {
            InitializeComponent();
            this.dragElement.Height = c.dragElement.Height;
            this.dragElement.Width = c.dragElement.Height;
            this.dragElement.Fill = c.dragElement.Fill;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                // Package the data.
                DataObject data = new DataObject();
                data.SetData(DataFormats.StringFormat, dragElement.Fill.ToString());
                data.SetData("Double", dragElement.Height);
                data.SetData("Object", this);

                // Inititate the drag-and-drop operation.
                DragDrop.DoDragDrop(this, data, DragDropEffects.Copy | DragDropEffects.Move);

                //Cursor +
                Mouse.SetCursor(Cursors.Cross);
            }
        }

        protected override void OnDrop(DragEventArgs e)
        {
            base.OnDrop(e);

            // If the DataObject contains string data, extract it.
            if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                string dataString = (string)e.Data.GetData(DataFormats.StringFormat);

                // If the string can be converted into a Brush, 
                // convert it and apply it to the ellipse.
                BrushConverter converter = new BrushConverter();
                if (converter.IsValid(dataString))
                {
                    Brush newFill = (Brush)converter.ConvertFromString(dataString);
                    dragElement.Fill = newFill;
                }
            }
            e.Handled = true;
        }

        protected override void OnDragOver(DragEventArgs e)
        {
            base.OnDragOver(e);
            e.Effects = DragDropEffects.None;

            // If the DataObject contains string data, extract it.
            if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                string dataString = (string)e.Data.GetData(DataFormats.StringFormat);

                // If the string can be converted into a Brush, 
                // convert it and apply it to the ellipse.
                BrushConverter converter = new BrushConverter();
                if (converter.IsValid(dataString))
                {
                    Brush newFill = (Brush)converter.ConvertFromString(dataString);
                    dragElement.Fill = newFill;
                }
            }
            e.Handled = true;
        }

        protected override void OnDragEnter(DragEventArgs e)
        {
            base.OnDragEnter(e);
            // Save the current Fill brush so that you can revert back to this value in DragLeave.
            _previousFill = dragElement.Fill;

            // If the DataObject contains string data, extract it.
            if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                string dataString = (string)e.Data.GetData(DataFormats.StringFormat);

                // If the string can be converted into a Brush, 
                // convert it and apply it to the ellipse.
                BrushConverter converter = new BrushConverter();
                if (converter.IsValid(dataString))
                {
                    Brush newFill = (Brush)converter.ConvertFromString(dataString);
                    dragElement.Fill = newFill;
                }
            }
        }
        protected override void OnDragLeave(DragEventArgs e)
        {
            base.OnDragLeave(e);
            // Undo the preview that was applied in OnDragEnter.
            dragElement.Fill = _previousFill;
        }
    }
}
