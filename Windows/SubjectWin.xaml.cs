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
    /// Логика взаимодействия для SubjectWin.xaml
    /// </summary>
    public partial class SubjectWin : Window
    {
        DatabaseEntities db;
        public SubjectWin()
        {
            InitializeComponent();
            db = new DatabaseEntities();
        }
        private void Cyr_Check(object sender, TextCompositionEventArgs e)
        {
            CheckCl checkCl = new CheckCl();
            if (checkCl.Cyr_Check(e.Text) == false)
            {
                e.Handled = true;
            }
        }
        private void Subj_Add(object sender, RoutedEventArgs e)
        {
            SubjCl subjCl = new SubjCl();
            if (subjCl.Add(Subj_Name.Text) == true)
            {
                Subj_Name.Clear();
                db = new DatabaseEntities();
                SubjGrid.ItemsSource = db.Subjects.ToList();
            }
        }
        private void Subj_Update(object sender, RoutedEventArgs e)
        {
            SubjCl subjCl = new SubjCl();
            db = new DatabaseEntities();
            Subjects subjects = SubjGrid.SelectedItem as Subjects;

            if (SubjGrid.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали строку.", "Кабинет", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            db.Subjects.Where(i => i.Id == subjects.Id).FirstOrDefault();
            if (subjCl.Update(subjects != null ? subjects.Id.ToString() : "0", Subj_Name.Text) == true)
            {
                Subj_Name.Clear();
                db = new DatabaseEntities();
                SubjGrid.ItemsSource = db.Subjects.ToList();
            }
        }
        private void Subj_Delete(object sender, RoutedEventArgs e)
        {
            SubjCl subjCl = new SubjCl();
            Subjects subjects = SubjGrid.SelectedItem as Subjects;

            if (SubjGrid.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали строку.", "Кабинет", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            db.Cabinets.Where(i => i.Id == subjects.Id).FirstOrDefault();
            subjCl.Delete(subjects != null ? subjects.Id.ToString() : "0");
            db = new DatabaseEntities();
            SubjGrid.ItemsSource = db.Subjects.ToList();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db = new DatabaseEntities();
            SubjGrid.ItemsSource = db.Subjects.ToList();
        }
    }
}
