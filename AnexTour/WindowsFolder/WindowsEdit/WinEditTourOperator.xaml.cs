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

namespace AnexTour.WindowsFolder.WindowsEdit
{
    /// <summary>
    /// Логика взаимодействия для WinEditTourOperator.xaml
    /// </summary>
    public partial class WinEditTourOperator : Window
    {
        SqlConnection sqlConnection =
           new SqlConnection(App.ConnectionString());
        SqlCommand sqlCommand;
        SqlDataReader dataReader;
        ClassFolder.ClassCB classCB;
        ClassFolder.ClassRead classRead;
        ClassFolder.ClassEdit classEdit;
        public WinEditTourOperator()
        {
            InitializeComponent();
            classCB = new ClassFolder.ClassCB();
            classRead = new ClassFolder.ClassRead();
            classEdit = new ClassFolder.ClassEdit();
        }

        private void btnAddAddressRegistration_Click(object sender, RoutedEventArgs e)
        {
            WinAddAddress winAddAddress = new WinAddAddress();
            winAddAddress.ShowDialog();
        }

        private void btnAddAddressLocation_Click(object sender, RoutedEventArgs e)
        {
            WinAddAddress winAddAddress = new WinAddAddress();
            winAddAddress.ShowDialog();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            classRead.ReadDirector(cbDirector);

            classRead.ReadAddressRegistration(cbAddressRegistration);

            classRead.ReadAddressLocation(cbAddressLocation);

            classEdit.Edit("update dbo.TourOperator " +
                $"set FullNameTourOperator='{tbFullName.Text}', " +
                $"IdRegisterAddress=" +
                $"'{ClassFolder.TableFolder.ClassAddress.IdAddressRegistration}', " +
                $"IdAddressLocation=" +
                $"'{ClassFolder.TableFolder.ClassAddress.IdAddressLoacation}', " +
                $"PhoneNumber='{tbPhoneNumber.Text}', " +
                $"Email='{tbEmail.Text}', " +
                $"IdDirector=" +
                $"'{ClassFolder.TableFolder.ClassDirector.IdDirector}', " +
                $"INN='{tbINN.Text}', " +
                $"KPP='{tbKPP.Text}', " +
                $"OGRN='{tbOGRN.Text}', " +
                $"OKPO='{tbOKPO.Text}' " +               
                $"where IdTourOperator=" +
                $"'{ClassFolder.TableFolder.ClassTourOperator.IdTourOperator}'");
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                classCB.LoadAddress(cbAddressRegistration);
                classCB.LoadAddress(cbAddressLocation);
                classCB.LoadDirector(cbDirector);
                sqlConnection.Open();
                sqlCommand = new SqlCommand("select * from dbo.ViewTourOperator " +
                    $"where [IdTourOperator]=" +
                    $"'{ClassFolder.TableFolder.ClassTourOperator.IdTourOperator}'", 
                    sqlConnection);
                dataReader = sqlCommand.ExecuteReader();
                dataReader.Read();
                tbFullName.Text = dataReader[1].ToString();
                tbPhoneNumber.Text = dataReader[16].ToString();
                tbEmail.Text = dataReader[17].ToString();                              
                tbINN.Text = dataReader[23].ToString();
                tbKPP.Text = dataReader[24].ToString();
                tbOGRN.Text = dataReader[25].ToString();
                tbOKPO.Text = dataReader[26].ToString();

                classRead.ReadDirectorDataGrid(dataReader[18].ToString(),dataReader[19].ToString(), dataReader[20].ToString(), 
                    dataReader[21].ToString(), dataReader[22].ToString());

                classRead.ReadDirectorEdit(ClassFolder.TableFolder.ClassDirector.IdDirector);

                cbDirector.Text = ClassFolder.TableFolder.ClassDirector.NameDirector;

                classRead.ReadAddressRegistrationDataGrid(dataReader[2].ToString(), dataReader[3].ToString(), dataReader[4].ToString(), dataReader[5].ToString(), dataReader[6].ToString(),
                    dataReader[7].ToString(), dataReader[8].ToString());

                classRead.ReadAddressRegistrationEdit(ClassFolder.TableFolder.ClassAddress.IdAddressRegistration);

                cbAddressRegistration.Text = ClassFolder.TableFolder.ClassAddress.NameAddressRegistration;

                classRead.ReadAddressLocationDataGrid(dataReader[9].ToString(), dataReader[10].ToString(), dataReader[11].ToString(), dataReader[12].ToString(), dataReader[13].ToString(),
                   dataReader[14].ToString(), dataReader[15].ToString());

                classRead.ReadAddressLocationEdit(ClassFolder.TableFolder.ClassAddress.IdAddressLoacation);

                cbAddressLocation.Text = ClassFolder.TableFolder.ClassAddress.NameAddressLocation;
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError(ex);
            }
        }

        private void btnAddDirector_Click(object sender, RoutedEventArgs e)
        {
            WindowsAdd.WinAdddDirector winAdddDirector =
                new WindowsAdd.WinAdddDirector();
            winAdddDirector.ShowDialog();
        }
    }
}
