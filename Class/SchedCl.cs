using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TestProg
{
    public class SchedCl
    {
        public bool Add(string date, string time, int cl, int teacher)
        {
            CheckCl checkCl = new CheckCl();
            DatabaseEntities db = new DatabaseEntities();
            try
            {
                Schedule schedule = new Schedule();

                if (string.IsNullOrWhiteSpace(date) || string.IsNullOrWhiteSpace(time) || string.IsNullOrWhiteSpace(Convert.ToString(cl)) || string.IsNullOrWhiteSpace(Convert.ToString(teacher)))
                {
                    MessageBox.Show("Вы не полностью заполнили форму", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    DateTime.TryParse(date, out DateTime conv_date);
                    schedule.date = conv_date;
                    schedule.time = time;
                    schedule.Class_Id= cl;
                    schedule.Teacher_Id = teacher;
                    db.Schedule.Add(schedule);
                    db.SaveChanges();
                }
            }
            catch
            {
                MessageBox.Show("Внесите корректные значения", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
        public bool Delete(string id)
        {
            DatabaseEntities db = new DatabaseEntities();

            try
            {
                int num = Convert.ToInt32(id);
                var d_s = db.Schedule.Where(i => i.Id == num).FirstOrDefault();
                if (d_s == null)
                {
                    MessageBox.Show("Вы не выбрали строку.", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    db.Schedule.Remove(d_s);
                    db.SaveChanges();
                }
            }
            catch
            {
                MessageBox.Show("Введите корректные значения.", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
        public bool Update(string id, string date, string time, int cl, int teacher)
        {
            CheckCl checkCl = new CheckCl();
            DatabaseEntities db = new DatabaseEntities();
            try
            {
                int num = Convert.ToInt32(id);
                var u_s = db.Schedule.Where(u => u.Id == num).FirstOrDefault();

                if (string.IsNullOrWhiteSpace(date) || string.IsNullOrWhiteSpace(time) || string.IsNullOrWhiteSpace(Convert.ToString(cl)) || string.IsNullOrWhiteSpace(Convert.ToString(teacher)))
                {
                    MessageBox.Show("Вы не полностью заполнили форму", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    if (u_s == null)
                    {
                        MessageBox.Show("Вы не выбрали строку.", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                    DateTime.TryParse(date, out DateTime conv_date);
                    u_s.date = conv_date;
                    u_s.time = time;
                    u_s.Class_Id = cl;
                    u_s.Teacher_Id = teacher;
                    db.SaveChanges();
                }

            }
            catch
            {
                MessageBox.Show("Введите корректные значения.", "Расписание", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
    }
}