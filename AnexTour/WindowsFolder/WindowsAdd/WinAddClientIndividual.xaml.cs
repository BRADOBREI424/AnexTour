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
    /// Логика взаимодействия для WinAddClientIndividual.xaml
    /// </summary>
    public partial class WinAddClientIndividual : Window
    {
        SqlConnection sqlConnection =
            new SqlConnection(App.ConnectionString());      
        ClassFolder.ClassCB classCB;
        ClassFolder.ClassAdd classAdd;
        ClassFolder.ClassRead classRead;
        public WinAddClientIndividual()
        {
            InitializeComponent();
            classCB = new ClassFolder.ClassCB();
            classAdd = new ClassFolder.ClassAdd();
            classRead = new ClassFolder.ClassRead();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAddCity_Click(object sender, RoutedEventArgs e)
        {
            WindowsFolder.WinAddCity winAddCity =
                new WinAddCity();
            winAddCity.ShowDialog();
        }

        private void btnAddStreet_Click(object sender, RoutedEventArgs e)
        {
            WindowsFolder.WinAddStreet winAddStreet =
                new WinAddStreet();
            winAddStreet.ShowDialog();
        }

        private void btnAddAuthority_Click(object sender, RoutedEventArgs e)
        {
            WindowsFolder.WinAddAuthority winAddAuthority =
                new WinAddAuthority();
            winAddAuthority.ShowDialog();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbLastName.Text))
            {
                ClassFolder.ClassMB.MBError("Введите фамилию");
                tbLastName.Focus();
            }
            else if (string.IsNullOrEmpty(tbFirstName.Text))
            {
                ClassFolder.ClassMB.MBError("Введите имя");
                tbFirstName.Focus();
            }
            else if (string.IsNullOrEmpty(tbNumberPhone.Text))
            {
                ClassFolder.ClassMB.MBError("Введите номер телефона");
                tbNumberPhone.Focus();
            }
            else if (string.IsNullOrEmpty(tbEmail.Text))
            {
                ClassFolder.ClassMB.MBError("Введите электронную почту");
                tbEmail.Focus();
            }            
            else if (string.IsNullOrEmpty(tbSeries.Text))
            {
                ClassFolder.ClassMB.MBError("Введите серию паспорта");
                tbSeries.Focus();
            }
            else if (string.IsNullOrEmpty(tbNumberPassport.Text))
            {
                ClassFolder.ClassMB.MBError("Введите номер паспорта");
                tbNumberPassport.Focus();
            }
            else if (cbIssuedByWhom.SelectedValue.ToString() == "")
            {
                ClassFolder.ClassMB.MBError("Выберите кем выдан паспорт");
                cbIssuedByWhom.Focus();
            }
            else if (dpDateOfIssue.SelectedDate.ToString() == "")
            {
                ClassFolder.ClassMB.MBError("Введите дату выдачи паспорта");
                dpDateOfIssue.Focus();
            }
            else if (cbGender.SelectedValue.ToString() == "")
            {
                ClassFolder.ClassMB.MBError("Выберите пол");
                cbGender.Focus();
            }
            else if (dpDateOfBorn.SelectedDate.ToString() == "")
            {
                ClassFolder.ClassMB.MBError("Введите дату рождения");
                dpDateOfBorn.Focus();
            }
            else if (string.IsNullOrEmpty(tbPlaceOfBorn.Text))
            {
                ClassFolder.ClassMB.MBError("Введите место рождения");
                tbPlaceOfBorn.Focus();
            }
            else
            {
                try
                {
                    sqlConnection.Open();
                    classRead.ReadAddress(cbAddress);
                    classAdd.AddPasport(tbSeries, tbNumberPassport, cbIssuedByWhom,
                        dpDateOfIssue, cbGender, dpDateOfBorn, tbPlaceOfBorn);
                    classRead.ReadPasport(tbSeries, tbNumberPassport, cbIssuedByWhom,
                        dpDateOfIssue, cbGender, dpDateOfBorn, tbPlaceOfBorn);
                    classAdd.AddClientIndividual(tbLastName, tbFirstName, tbMiddleName,
                        tbNumberPhone, tbEmail);
                    ClassFolder.ClassMB.MBInformation("Клиент добавлен");
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
            
            classCB.LoadIssuedByWhom(cbIssuedByWhom);
            classCB.LoadGender(cbGender);
            classCB.LoadAddress(cbAddress);
        }

        private void btnAddAddress_Click(object sender, RoutedEventArgs e)
        {
            WinAddAddress winAddAddress = new WinAddAddress();
            winAddAddress.ShowDialog();
        }
    }
}
