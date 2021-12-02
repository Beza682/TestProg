using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TestProg
{
    public class StudCl
    {
        public bool Add(string last, string first, string middle, int cl)
        {
            CheckCl checkCl = new CheckCl();
            DatabaseEntities db = new DatabaseEntities();
            try
            {
                Students students = new Students();


                if (string.IsNullOrWhiteSpace(last) || string.IsNullOrWhiteSpace(first) || string.IsNullOrWhiteSpace(middle) || string.IsNullOrWhiteSpace(Convert.ToString(cl)))
                {
                    MessageBox.Show("Вы не полностью заполнили форму", "Ученики", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if ((checkCl.Cyr_Check(last) || checkCl.Cyr_Check(first) || checkCl.Cyr_Check(middle)) == false)
                {
                    MessageBox.Show("Форма заполнена не корректно", "Ученики", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    students.st_last_name = last;
                    students.st_first_name = first;
                    students.st_middle_name = middle;
                    students.Class_Id = cl;
                    db.Students.Add(students);
                    db.SaveChanges();
                }
            }
            catch
            {
                MessageBox.Show("Внесите корректные значения", "Ученики", MessageBoxButton.OK, MessageBoxImage.Error);
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
                var d_s = db.Students.Where(i => i.Id == num).FirstOrDefault();
                if (d_s == null)
                {
                    MessageBox.Show("Вы не выбрали строку.", "Ученики", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    db.Students.Remove(d_s);
                    db.SaveChanges();
                }
            }
            catch
            {
                MessageBox.Show("Введите корректные значения.", "Ученики", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
        public bool Update(string id, string last, string first, string middle, int cl)
        {
            CheckCl checkCl = new CheckCl();
            DatabaseEntities db = new DatabaseEntities();
            try
            {
                int num = Convert.ToInt32(id);
                var u_s = db.Students.Where(u => u.Id == num).FirstOrDefault();

                if (string.IsNullOrWhiteSpace(last) || string.IsNullOrWhiteSpace(first) || string.IsNullOrWhiteSpace(middle) || string.IsNullOrWhiteSpace(Convert.ToString(cl)))
                {
                    MessageBox.Show("Вы не полностью заполнили форму", "Ученики", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if ((checkCl.Cyr_Check(last) || checkCl.Cyr_Check(first) || checkCl.Cyr_Check(middle)) == false)
                {
                    MessageBox.Show("Форма заполнена не корректно", "Ученики", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    if (u_s == null)
                    {
                        MessageBox.Show("Вы не выбрали строку.", "Ученики", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                    u_s.st_last_name = last;
                    u_s.st_first_name = first;
                    u_s.st_middle_name = middle;
                    u_s.Class_Id = cl;
                    db.SaveChanges();
                }

            }
            catch
            {
                MessageBox.Show("Введите корректные значения.", "Ученики", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
    }
}
