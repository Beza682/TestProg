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

namespace TestProg
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DatabaseEntities db;
        public MainWindow()
        {
            InitializeComponent();
            db = new DatabaseEntities();

            Time_Cb.Items.Add("08:30 - 09:15");
            Time_Cb.Items.Add("09:30 - 10:15");
            Time_Cb.Items.Add("10:30 - 11:15");
            Time_Cb.Items.Add("11:30 - 12:15");
            Time_Cb.Items.Add("13:00 - 13:45");
            Time_Cb.Items.Add("14:00 - 14:45");
            Time_Cb.Items.Add("15:00 - 15:45");
            Time_Cb.Items.Add("16:00 - 16:45");
        }

        private void Class_Check(object sender, TextCompositionEventArgs e)
        {
            CheckCl checkCl = new CheckCl();
            if (checkCl.Class_Check(e.Text) == false)
            {
                e.Handled = true;
            }
        }
        private void Cyr_Check(object sender, TextCompositionEventArgs e)
        {
            CheckCl checkCl = new CheckCl();
            if (checkCl.Cyr_Check(e.Text) == false)
            {
                e.Handled = true;
            }
        }
        private void Date_Check(object sender, TextCompositionEventArgs e)
        {
            CheckCl checkCl = new CheckCl();
            if (checkCl.Date_Check(e.Text) == false)
            {
                e.Handled = true;
            }
        }
        private void Sched_Add(object sender, RoutedEventArgs e)
        {
            SchedCl schedCl = new SchedCl();
            if (schedCl.Add(Date.SelectedDate.ToString(), Time_Cb.SelectedItem.ToString(), (Class_Cb.SelectedItem as Classes).Id, (Teach_Cb.SelectedItem as Teachers).Id) == true)
            {
                Date.SelectedDate = null;
                Time_Cb.SelectedIndex = -1;
                Class_Cb.SelectedIndex = -1;
                Subj_Cb.SelectedIndex = -1;
                Teach_Cb.SelectedIndex = -1;
                db = new DatabaseEntities();
                SchedGrid.ItemsSource = db.Schedule.ToList();
            }
        }

        private void Sched_Update(object sender, RoutedEventArgs e)
        {
            {
                SchedCl schedCl = new SchedCl();
                db = new DatabaseEntities();
                Schedule schedule = SchedGrid.SelectedItem as Schedule;

                if (SchedGrid.SelectedItem == null)
                {
                    MessageBox.Show("Вы не выбрали строку.", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                db.Schedule.Where(i => i.Id == schedule.Id).FirstOrDefault();
                if (schedCl.Update(schedule != null ? schedule.Id.ToString() : "0", Date.SelectedDate.ToString(), Time_Cb.SelectedItem.ToString(), (Class_Cb.SelectedItem as Classes).Id, (Teach_Cb.SelectedItem as Teachers).Id) == true)
                {
                    Date.SelectedDate = null;
                    Time_Cb.SelectedIndex = -1;
                    Class_Cb.SelectedIndex = -1;
                    Subj_Cb.SelectedIndex = -1;
                    Teach_Cb.SelectedIndex = -1;
                    db = new DatabaseEntities();
                    SchedGrid.ItemsSource = db.Schedule.ToList();
                }
            }
        }

        private void Sched_Delete(object sender, RoutedEventArgs e)
        {
            SchedCl schedCl = new SchedCl();
            Schedule schedule = SchedGrid.SelectedItem as Schedule;


            if (SchedGrid.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали строку.", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            db.Schedule.Where(i => i.Id == schedule.Id).FirstOrDefault();
            schedCl.Delete(schedule != null ? schedule.Id.ToString() : "0");
            db = new DatabaseEntities();
            SchedGrid.ItemsSource = db.Schedule.ToList();
        }

        private void Subj_Cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(Subj_Cb.SelectedIndex == -1)
            {
                WM_Teach_and_Cb.Visibility = Visibility.Collapsed;
            }
            else
            {
                WM_Teach_and_Cb.Visibility = Visibility.Visible;
                int Teach_Subj = (Subj_Cb.SelectedItem as Subjects).Id;
                Teach_Cb.ItemsSource = db.Teachers.Where(i => i.Subject_Id == Teach_Subj).ToList();
            }
        }

        private void Teacher_Add(object sender, RoutedEventArgs e)
        {
            TeachCl teachCl = new TeachCl();
            if (teachCl.Add(tch_last_name.Text, tch_first_name.Text, tch_middle_name.Text, (SubjTeach_Cb.SelectedItem as Subjects).Id, (Cab_Cb.SelectedItem as Cabinets).Id) == true)
            {
                SubjTeach_Cb.SelectedIndex = -1;
                Cab_Cb.SelectedIndex = -1;
                tch_last_name.Clear();
                tch_first_name.Clear();
                tch_middle_name.Clear();
                db = new DatabaseEntities();
                TeachGrid.ItemsSource = db.Teachers.ToList();
                Teach_Cb.ItemsSource = db.Teachers.ToList();
            }
        }

        private void Teacher_Update(object sender, RoutedEventArgs e)
        {
            {
                TeachCl teachCl = new TeachCl();
                db = new DatabaseEntities();
                Teachers teachers = TeachGrid.SelectedItem as Teachers;

                if (TeachGrid.SelectedItem == null)
                {
                    MessageBox.Show("Вы не выбрали строку.", "Преподаватели", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                db.Teachers.Where(i => i.Id == teachers.Id).FirstOrDefault();
                if (teachCl.Update(teachers != null ? teachers.Id.ToString() : "0", tch_last_name.Text, tch_first_name.Text, tch_middle_name.Text, (SubjTeach_Cb.SelectedItem as Subjects).Id, (Cab_Cb.SelectedItem as Cabinets).Id) == true)
                {
                    SubjTeach_Cb.SelectedIndex = -1;
                    Cab_Cb.SelectedIndex = -1;
                    tch_last_name.Clear();
                    tch_first_name.Clear();
                    tch_middle_name.Clear();
                    db = new DatabaseEntities();
                    TeachGrid.ItemsSource = db.Teachers.ToList();
                    Teach_Cb.ItemsSource = db.Teachers.ToList();
                }
            }
        }
        private void Teacher_Delete(object sender, RoutedEventArgs e)
        {
            TeachCl teachCl = new TeachCl();
            Teachers teachers = TeachGrid.SelectedItem as Teachers;


            if (TeachGrid.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали строку.", "Преподаватели", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            db.Teachers.Where(i => i.Id == teachers.Id).FirstOrDefault();
            teachCl.Delete(teachers != null ? teachers.Id.ToString() : "0");
            db = new DatabaseEntities();
            TeachGrid.ItemsSource = db.Teachers.ToList();
            Teach_Cb.ItemsSource = db.Teachers.ToList();
        }

        private void CabWin(object sender, RoutedEventArgs e)
        {
            new CabWin().ShowDialog();
            db = new DatabaseEntities();
            Cab_Cb.ItemsSource = db.Cabinets.ToList();
        }

        private void SubjectWin(object sender, RoutedEventArgs e)
        {
            new SubjectWin().ShowDialog();
            db = new DatabaseEntities();
            SubjTeach_Cb.ItemsSource = db.Subjects.ToList();
            Subj_Cb.ItemsSource = db.Subjects.ToList();
        }

        private void Student_Add(object sender, RoutedEventArgs e)
        {
            StudCl studCl = new StudCl();
            if (studCl.Add(st_last_name.Text, st_first_name.Text, st_middle_name.Text, (ClassStud_Cb.SelectedItem as Classes).Id) == true)
            {
                ClassStud_Cb.SelectedIndex = -1;
                st_last_name.Clear();
                st_first_name.Clear();
                st_middle_name.Clear();
                db = new DatabaseEntities();
                StudGrid.ItemsSource = db.Students.ToList();
            }
        }

        private void Student_Update(object sender, RoutedEventArgs e)
        {
            {
                StudCl studCl = new StudCl();
                db = new DatabaseEntities();
                Students students = StudGrid.SelectedItem as Students;

                if (StudGrid.SelectedItem == null)
                {
                    MessageBox.Show("Вы не выбрали строку.", "Ученики", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                db.Students.Where(i => i.Id == students.Id).FirstOrDefault();
                if (studCl.Update(students != null ? students.Id.ToString() : "0", st_last_name.Text, st_first_name.Text, st_middle_name.Text, (ClassStud_Cb.SelectedItem as Classes).Id) == true)
                {
                    ClassStud_Cb.SelectedIndex = -1;
                    st_last_name.Clear();
                    st_first_name.Clear();
                    st_middle_name.Clear();
                    db = new DatabaseEntities();
                    StudGrid.ItemsSource = db.Students.ToList();
                }
            }
        }
        private void Student_Delete(object sender, RoutedEventArgs e)
        {
            StudCl studCl = new StudCl();
            Students students = StudGrid.SelectedItem as Students;

            if (StudGrid.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали строку.", "Ученики", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            db.Students.Where(i => i.Id == students.Id).FirstOrDefault();
            studCl.Delete(students != null ? students.Id.ToString() : "0");
            db = new DatabaseEntities();
            StudGrid.ItemsSource = db.Students.ToList();
        }

        private void Class_Add(object sender, RoutedEventArgs e)
        {
            ClassCl classCl = new ClassCl();
            if (classCl.Add(Class_Number.Text) == true)
            {
                Class_Number.Clear();
                db = new DatabaseEntities();
                ClassGrid.ItemsSource = db.Classes.ToList();
                Class_Cb.ItemsSource = db.Classes.ToList();
                ClassStud_Cb.ItemsSource = db.Classes.ToList();
            }
        }
        
        private void Class_Update(object sender, RoutedEventArgs e)
        {
            ClassCl classCl = new ClassCl();
            db = new DatabaseEntities();
            Classes classes = ClassGrid.SelectedItem as Classes;

            if (ClassGrid.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали строку.", "Классы", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            db.Classes.Where(i => i.Id == classes.Id).FirstOrDefault();
            if (classCl.Update(classes != null ? classes.Id.ToString() : "0", Class_Number.Text) == true)
            {
                Class_Number.Clear();
                db = new DatabaseEntities();
                ClassGrid.ItemsSource = db.Classes.ToList();
                Class_Cb.ItemsSource = db.Classes.ToList();
                ClassStud_Cb.ItemsSource = db.Classes.ToList();
            }
        }

        private void Class_Delete(object sender, RoutedEventArgs e)
        {
            ClassCl classCl = new ClassCl();
            Classes classes = ClassGrid.SelectedItem as Classes;

            if (ClassGrid.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали строку.", "Классы", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            db.Classes.Where(i => i.Id == classes.Id).FirstOrDefault();
            classCl.Delete(classes != null ? classes.Id.ToString() : "0");
            db = new DatabaseEntities();
            ClassGrid.ItemsSource = db.Classes.ToList();
            Class_Cb.ItemsSource = db.Classes.ToList();
            ClassStud_Cb.ItemsSource = db.Classes.ToList();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SchedGrid.ItemsSource = db.Schedule.ToList();
            Class_Cb.ItemsSource = db.Classes.ToList();
            Subj_Cb.ItemsSource = db.Subjects.ToList();


            TeachGrid.ItemsSource = db.Teachers.ToList();
            Cab_Cb.ItemsSource = db.Cabinets.ToList();
            SubjTeach_Cb.ItemsSource = db.Subjects.ToList();

            StudGrid.ItemsSource = db.Students.ToList();
            ClassStud_Cb.ItemsSource = db.Classes.ToList();

            ClassGrid.ItemsSource = db.Classes.ToList();
        }
    }
}
