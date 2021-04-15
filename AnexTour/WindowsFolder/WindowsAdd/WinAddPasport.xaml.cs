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

namespace AnexTour.WindowsFolder.WindowsAdd
{
    /// <summary>
    /// Логика взаимодействия для WinAddPasport.xaml
    /// </summary>
    public partial class WinAddPasport : Window
    {
        SqlConnection sqlConnection =
           new SqlConnection(App.ConnectionString());     
        ClassFolder.ClassAdd classAdd;
        ClassFolder.ClassCB classCB;
        public WinAddPasport()
        {
            InitializeComponent();
            classAdd = new ClassFolder.ClassAdd();
            classCB = new ClassFolder.ClassCB();
        }

        private void btnAddAuthority_Click(object sender, RoutedEventArgs e)
        {
            WinAddAuthority winAddAuthority = new WinAddAuthority();
            winAddAuthority.ShowDialog();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrEmpty(tbSeries.Text))
            {
                ClassFolder.ClassMB.MBError("Введите серию паспорта");
                tbSeries.Focus();
            }
            else if (string.IsNullOrEmpty(tbNumber.Text))
            {
                ClassFolder.ClassMB.MBError("Введите номер паспорта");
                tbNumber.Focus();
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
                    classAdd.AddPasport(tbSeries, tbNumber, cbIssuedByWhom,
                    dpDateOfIssue, cbGender, dpDateOfBorn, tbPlaceOfBorn);
                    ClassFolder.ClassMB.MBInformation("Паспорт добавлен");
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
            classCB.LoadGender(cbGender);
            classCB.LoadIssuedByWhom(cbIssuedByWhom);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
