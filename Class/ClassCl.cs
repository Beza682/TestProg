using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TestProg
{
    public class ClassCl
    {
        public bool Add(string number)
        {
            CheckCl checkCl = new CheckCl();
            DatabaseEntities db = new DatabaseEntities();
            try
            {
                Classes classes = new Classes();

                var class_check = db.Classes.FirstOrDefault(ch => ch.Number == number);

                if (string.IsNullOrWhiteSpace(number))
                {
                    MessageBox.Show("Вы не полностью заполнили форму", "Классы", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if ((checkCl.Class_Check(number)) == false)
                {
                    MessageBox.Show("Форма заполнена не корректно", "Классы", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (class_check != null)
                {
                    MessageBox.Show("Данный класс уже существует.", "Классы", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    classes.Number = number;
                    db.Classes.Add(classes);
                    db.SaveChanges();
                }
            }
            catch
            {
                MessageBox.Show("Внесите корректные значения", "Классы", MessageBoxButton.OK, MessageBoxImage.Error);
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
                var d_c = db.Classes.Where(i => i.Id == num).FirstOrDefault();
                if (d_c == null)
                {
                    MessageBox.Show("Вы не выбрали строку.", "Классы", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    db.Classes.Remove(d_c);
                    db.SaveChanges();
                }
            }
            catch
            {
                MessageBox.Show("Нельзя удалить класс, который присвоен ученику.\nОчистите список учеников.", "Классы", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
        public bool Update(string id, string number)
        {
            CheckCl checkCl = new CheckCl();
            DatabaseEntities db = new DatabaseEntities();
            try
            {
                int num = Convert.ToInt32(id);
                var u_c = db.Classes.Where(u => u.Id == num).FirstOrDefault();
                var class_check = db.Classes.FirstOrDefault(ch => ch.Number == number);

                if (string.IsNullOrWhiteSpace(number))
                {
                    MessageBox.Show("Вы не полностью заполнили форму", "Классы", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if ((checkCl.Class_Check(number)) == false)
                {
                    MessageBox.Show("Форма заполнена не корректно", "Классы", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (class_check != null)
                {
                    MessageBox.Show("Данный класс уже существует.", "Классы", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    if (u_c == null)
                    {
                        MessageBox.Show("Вы не выбрали строку.", "Классы", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                    u_c.Number = number;
                    db.SaveChanges();
                }

            }
            catch
            {
                MessageBox.Show("Введите корректные значения.", "Классы", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
    }
}