using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TestProg
{
    public class TeachCl
    {
        public bool Add(string last, string first, string middle, int subj, int cab)
        {
            CheckCl checkCl = new CheckCl();
            DatabaseEntities db = new DatabaseEntities();
            try
            {
                Teachers teachers = new Teachers();


                if (string.IsNullOrWhiteSpace(last) || string.IsNullOrWhiteSpace(first) || string.IsNullOrWhiteSpace(middle))
                {
                    MessageBox.Show("Вы не полностью заполнили форму", "Перподаватели", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if ((checkCl.Cyr_Check(last) || checkCl.Cyr_Check(first) || checkCl.Cyr_Check(middle)) == false)
                {
                    MessageBox.Show("Форма заполнена не корректно", "Перподаватели", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    teachers.tch_last_name = last;
                    teachers.tch_first_name = first;
                    teachers.tch_middle_name = middle;
                    teachers.Subject_Id = subj;
                    teachers.Cab_Id = cab;
                    db.Teachers.Add(teachers);
                    db.SaveChanges();
                }
            }
            catch
            {
                MessageBox.Show("Внесите корректные значения", "Перподаватели", MessageBoxButton.OK, MessageBoxImage.Error);
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
                var d_t = db.Teachers.Where(i => i.Id == num).FirstOrDefault();
                if (d_t == null)
                {
                    MessageBox.Show("Вы не выбрали строку.", "Перподаватели", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    db.Teachers.Remove(d_t);
                    db.SaveChanges();
                }
            }
            catch
            {
                MessageBox.Show("Введите корректные значения.", "Перподаватели", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
        public bool Update(string id, string last, string first, string middle, int subj, int cab)
        {
            CheckCl checkCl = new CheckCl();
            DatabaseEntities db = new DatabaseEntities();
            try
            {
                int num = Convert.ToInt32(id);
                var u_t = db.Teachers.Where(u => u.Id == num).FirstOrDefault();

                if (string.IsNullOrWhiteSpace(last) || string.IsNullOrWhiteSpace(first) || string.IsNullOrWhiteSpace(middle))
                {
                    MessageBox.Show("Вы не полностью заполнили форму", "Перподаватели", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if ((checkCl.Cyr_Check(last) || checkCl.Cyr_Check(first) || checkCl.Cyr_Check(middle)) == false)
                {
                    MessageBox.Show("Форма заполнена не корректно", "Перподаватели", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    if (u_t == null)
                    {
                        MessageBox.Show("Вы не выбрали строку.", "Перподаватели", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                    u_t.tch_last_name = last;
                    u_t.tch_first_name = first;
                    u_t.tch_middle_name = middle;
                    u_t.Subject_Id = subj;
                    u_t.Cab_Id = cab;
                    db.SaveChanges();
                }

            }
            catch
            {
                MessageBox.Show("Введите корректные значения.", "Перподаватели", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
    }
}

