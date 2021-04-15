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
    /// Логика взаимодействия для WinEditClientIndividual.xaml
    /// </summary>
    public partial class WinEditClientIndividual : Window
    {

        SqlConnection sqlConnection =
           new SqlConnection(App.ConnectionString());
        SqlCommand sqlCommand;
        SqlDataReader dataReader;
        ClassFolder.ClassCB classCB;
        ClassFolder.ClassRead classRead;
        ClassFolder.ClassEdit classEdit;

        public WinEditClientIndividual()
        {
            InitializeComponent();
            classCB = new ClassFolder.ClassCB();
            classRead = new ClassFolder.ClassRead();
            classEdit = new ClassFolder.ClassEdit();
        }

        private void btnAddAuthority_Click(object sender, RoutedEventArgs e)
        {
            WinAddAuthority winAddAuthority = new WinAddAuthority();
            winAddAuthority.ShowDialog();
        }

        private void btnAddAddress_Click(object sender, RoutedEventArgs e)
        {
            WinAddAddress winAddAddress = new WinAddAddress();
            winAddAddress.ShowDialog();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
               
                classCB.LoadAddress(cbAddress);
                classCB.LoadPasport(cbPassport);
                sqlConnection.Open();
                sqlCommand = new SqlCommand("select * from dbo.ViewClientIndividual " +
                    $"where [Id]=" +
                    $"'{ClassFolder.TableFolder.ClassClient.IdClientIndividual}'", sqlConnection);
                dataReader = sqlCommand.ExecuteReader();
                dataReader.Read();
                tbLastName.Text = dataReader[1].ToString();
                tbFirstName.Text = dataReader[2].ToString();
                tbMiddleName.Text = dataReader[3].ToString();
                tbNumberPhone.Text = dataReader[11].ToString();
                tbEmail.Text = dataReader[12].ToString();

                classRead.ReadPasportDataGrid(dataReader[4].ToString(), dataReader[5].ToString(), 
                    dataReader[6].ToString(), dataReader[7].ToString(), dataReader[8].ToString(), 
                    dataReader[9].ToString(), dataReader[10].ToString());
               

                classRead.ReadPasportEdit(ClassFolder.TableFolder.ClassPassport.IdPassport);

                cbPassport.Text = ClassFolder.TableFolder.ClassPassport.NamePasport;


                classRead.ReadAddressDataGrid(dataReader[13].ToString(), dataReader[14].ToString(), dataReader[15].ToString(), dataReader[16].ToString(), dataReader[17].ToString(),
                    dataReader[18].ToString(), dataReader[19].ToString());

                
                
                classRead.ReadAddressEdit(ClassFolder.TableFolder.ClassAddress.IdAddress);

                                
                cbAddress.Text = ClassFolder.TableFolder.ClassAddress.NameAddress;

            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError(ex);
            }             
           
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

            classRead.ReadPasport(cbPassport);
            
            classRead.ReadAddress(cbAddress);
            
            classEdit.Edit("update dbo.ClientIndividual " +
                $"set Surname='{tbLastName.Text}', " +
                $"Firstname='{tbFirstName.Text}', " +
                $"Middlename='{tbMiddleName.Text}', " +
                $"Passport='{ClassFolder.TableFolder.ClassPassport.IdPassport}', " +
                $"PhoneNumber='{tbNumberPhone.Text}', " +
                $"Email='{tbEmail.Text}', " +
                $"IdAddress='{ClassFolder.TableFolder.ClassAddress.IdAddress}' " +
                $"where Id=" +
                $"'{ClassFolder.TableFolder.ClassClient.IdClientIndividual}'");
        }

        private void btnAddPasport_Click(object sender, RoutedEventArgs e)
        {
            WindowsAdd.WinAddPasport winAddPasport =
                new WindowsAdd.WinAddPasport();
            winAddPasport.ShowDialog();
        }
    }
}
