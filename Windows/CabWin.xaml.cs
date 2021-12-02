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
using System.Windows.Shapes;

namespace TestProg
{
    /// <summary>
    /// Логика взаимодействия для CabWin.xaml
    /// </summary>
    public partial class CabWin : Window
    {
        DatabaseEntities db;
        public CabWin()
        {
            InitializeComponent();
            db = new DatabaseEntities();
        }
        private void Num_Check(object sender, TextCompositionEventArgs e)
        {
            CheckCl checkCl = new CheckCl();
            if (checkCl.Num_Check(e.Text) == false)
            {
                e.Handled = true;
            }
        }
        private void Cab_Add(object sender, RoutedEventArgs e)
        {
            CabCl cabCl = new CabCl();
            if (cabCl.Add(Cab_Number.Text) == true)
            {
                Cab_Number.Clear();
                db = new DatabaseEntities();
                CabGrid.ItemsSource = db.Cabinets.ToList();
            }
        }
        private void Cab_Update(object sender, RoutedEventArgs e)
        {
            CabCl cabCl = new CabCl();
            db = new DatabaseEntities();
            Cabinets cabinets = CabGrid.SelectedItem as Cabinets;

            if (CabGrid.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали строку.", "Кабинет", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            db.Cabinets.Where(i => i.Id == cabinets.Id).FirstOrDefault();
            if (cabCl.Update(cabinets != null ? cabinets.Id.ToString() : "0", Cab_Number.Text) == true)
            {
                Cab_Number.Clear();
                db = new DatabaseEntities();
                CabGrid.ItemsSource = db.Cabinets.ToList();
            }
        }
        private void Cab_Delete(object sender, RoutedEventArgs e)
        {
            CabCl cabCl = new CabCl();
            Cabinets cabinets = CabGrid.SelectedItem as Cabinets;

            if (CabGrid.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали строку.", "Кабинет", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            db.Cabinets.Where(i => i.Id == cabinets.Id).FirstOrDefault();
            cabCl.Delete(cabinets != null ? cabinets.Id.ToString() : "0");
            db = new DatabaseEntities();
            CabGrid.ItemsSource = db.Cabinets.ToList();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db = new DatabaseEntities();
            CabGrid.ItemsSource = db.Cabinets.ToList();
        }
    }
}
