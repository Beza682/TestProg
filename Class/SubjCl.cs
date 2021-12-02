using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TestProg
{
    public class SubjCl
    {
        public bool Add(string name)
        {
            CheckCl checkCl = new CheckCl();
            DatabaseEntities db = new DatabaseEntities();
            try
            {
                Subjects subjects = new Subjects();

                var subj_check = db.Subjects.FirstOrDefault(ch => ch.Name == name);

                if (string.IsNullOrWhiteSpace(name))
                {
                    MessageBox.Show("Вы не полностью заполнили форму", "Предметы", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if ((checkCl.Cyr_Check(name)) == false)
                {
                    MessageBox.Show("Форма заполнена не корректно", "Предметы", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (subj_check != null)
                {
                    MessageBox.Show("Данный предмет уже существует.", "Предметы", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    subjects.Name = name;
                    db.Subjects.Add(subjects);
                    db.SaveChanges();
                }
            }
            catch
            {
                MessageBox.Show("Внесите корректные значения", "Предметы", MessageBoxButton.OK, MessageBoxImage.Error);
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
                var d_s = db.Subjects.Where(i => i.Id == num).FirstOrDefault();
                if (d_s == null)
                {
                    MessageBox.Show("Вы не выбрали строку.", "Предметы", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    db.Subjects.Remove(d_s);
                    db.SaveChanges();
                }
            }
            catch
            {
                MessageBox.Show("Нельзя удалить предмет, который присвоен преподавателю.\nОчистите список преподавателей.", "Предметы", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
        public bool Update(string id, string name)
        {
            CheckCl checkCl = new CheckCl();
            DatabaseEntities db = new DatabaseEntities();
            try
            {
                int num = Convert.ToInt32(id);
                var u_s = db.Subjects.Where(u => u.Id == num).FirstOrDefault();
                var subj_check = db.Subjects.FirstOrDefault(ch => ch.Name == name);

                if (string.IsNullOrWhiteSpace(name))
                {
                    MessageBox.Show("Вы не полностью заполнили форму", "Предметы", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if ((checkCl.Cyr_Check(name)) == false)
                {
                    MessageBox.Show("Форма заполнена не корректно", "Предметы", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (subj_check != null)
                {
                    MessageBox.Show("Данный предмет уже существует.", "Предметы", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    if (u_s == null)
                    {
                        MessageBox.Show("Вы не выбрали строку.", "Предметы", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                    u_s.Name = name;
                    db.SaveChanges();
                }

            }
            catch
            {
                MessageBox.Show("Введите корректные значения.", "Предметы", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
    }
}