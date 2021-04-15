using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace AnexTour.WindowsFolder
{
    /// <summary>
    /// Логика взаимодействия для WinAddAddress.xaml
    /// </summary>
    public partial class WinAddAddress : Window
    {
        SqlConnection sqlConnection =
            new SqlConnection(App.ConnectionString());
        ClassFolder.ClassCB classCB;
        ClassFolder.ClassAdd classAdd;
        ClassFolder.ClassRead classRead;
        public WinAddAddress()
        {
            InitializeComponent();
            classCB = new ClassFolder.ClassCB();
            classAdd = new ClassFolder.ClassAdd();
            classRead = new ClassFolder.ClassRead();
        }

        private void btnAddCity_Click(object sender, RoutedEventArgs e)
        {
            WinAddCity winAddCity = new WinAddCity();
            winAddCity.ShowDialog();
        }

        private void btnAddStreet_Click(object sender, RoutedEventArgs e)
        {
            WinAddStreet winAddStreet = new WinAddStreet();
            winAddStreet.ShowDialog();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(tbPosteCode.Text))
            {
                ClassFolder.ClassMB.MBError("Введите индекс");
                tbPosteCode.Focus();
            }
            else if(string.IsNullOrEmpty(tbHouse.Text))
            {
                ClassFolder.ClassMB.MBError("Введите номер дома");
                tbHouse.Focus();
            }
            else if(cbCity.SelectedValue.ToString()=="")
            {
                ClassFolder.ClassMB.MBError("Выберите город");
                cbCity.Focus();
            }
            else if(cbStreet.SelectedValue.ToString()=="")
            {
                ClassFolder.ClassMB.MBError("Выберите улицу");
                cbStreet.Focus();
            }
            else if(string.IsNullOrEmpty(tbApartment.Text))
            {
                ClassFolder.ClassMB.MBError("Введите номер квартиры");
                tbApartment.Focus();
            }
            else
            {
                try
                {
                    sqlConnection.Open();
                    classAdd.AddAddress(tbPosteCode, cbCity, cbStreet, tbHouse,
                            tbEnclosure, tbApartment);
                    classRead.ReadAddress(tbPosteCode, cbCity, cbStreet, tbHouse,
                            tbEnclosure, tbApartment);
                    ClassFolder.ClassMB.MBInformation("Адрес добавлен");
                }
                catch (Exception ex)
                {

                    ClassFolder.ClassMB.MBError(ex);
                }
                finally
                {
                    sqlConnection.Close();
                }

            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            classCB.LoadCity(cbCity);
            classCB.LoadStreet(cbStreet);
        }
    }
}
