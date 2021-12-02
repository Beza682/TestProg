using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace TestProg
{
    public class CabCl
    {
        public bool Add(string cab)
        {
            CheckCl checkCl = new CheckCl();
            DatabaseEntities db = new DatabaseEntities();
            try
            {
                Cabinets cabinets = new Cabinets();

                int cnov_cab = Convert.ToInt32(cab);
                var cab_check = db.Cabinets.FirstOrDefault(ch => ch.Cab == cnov_cab);

                if (string.IsNullOrWhiteSpace(cab))
                {
                    MessageBox.Show("Вы не полностью заполнили форму", "Кабинеты", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if ((checkCl.Num_Check(cab)) == false)
                {
                    MessageBox.Show("Форма заполнена не корректно", "Кабинеты", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (cab_check != null)
                {
                    MessageBox.Show("Данный кабинет уже существует.", "Кабинеты", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    cabinets.Cab = cnov_cab;
                    db.Cabinets.Add(cabinets);
                    db.SaveChanges();
                }
            }
            catch
            {
                MessageBox.Show("Внесите корректные значения", "Кабинеты", MessageBoxButton.OK, MessageBoxImage.Error);
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
                var d_c = db.Cabinets.Where(i => i.Id == num).FirstOrDefault();
                if (d_c == null)
                {
                    MessageBox.Show("Вы не выбрали строку.", "Кабинеты", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    db.Cabinets.Remove(d_c);
                    db.SaveChanges();
                }
            }
            catch
            {
                MessageBox.Show("Нельзя удалить кабинет, который присвоен преподавателю.\nОчистите список преподавателей.", "Кабинеты", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
        public bool Update(string id, string cab)
        {
            CheckCl checkCl = new CheckCl();
            DatabaseEntities db = new DatabaseEntities();
            try
            {
                int num = Convert.ToInt32(id);
                int cnov_cab = Convert.ToInt32(cab);
                var u_c = db.Cabinets.Where(u => u.Id == num).FirstOrDefault();
                var cab_check = db.Cabinets.FirstOrDefault(ch => ch.Cab == cnov_cab);

                if (string.IsNullOrWhiteSpace(cab))
                {
                    MessageBox.Show("Вы не полностью заполнили форму", "Кабинеты", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if ((checkCl.Num_Check(cab)) == false)
                {
                    MessageBox.Show("Форма заполнена не корректно", "Кабинеты", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (cab_check != null)
                {
                    MessageBox.Show("Данный кабинет уже существует.", "Кабинеты", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    if (u_c == null)
                    {
                        MessageBox.Show("Вы не выбрали строку.", "Кабинеты", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                    u_c.Cab = cnov_cab;
                    db.SaveChanges();
                }

            }
            catch
            {
                MessageBox.Show("Введите корректные значения.", "Кабинеты", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
    }
}