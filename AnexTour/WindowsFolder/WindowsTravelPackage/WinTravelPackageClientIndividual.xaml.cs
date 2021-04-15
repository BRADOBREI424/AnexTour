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

namespace AnexTour.WindowsFolder.WindowsTravelPackage
{
    /// <summary>
    /// Interaction logic for WinTravelPackageClientIndividual.xaml
    /// </summary>
    public partial class WinTravelPackageClientIndividual : Window
    {
        SqlConnection sqlConnection =
            new SqlConnection(App.ConnectionString());
        SqlCommand sqlCommand;
        SqlDataReader dataReader;
        ClassFolder.ClassCB classCB;
        ClassFolder.ClassAdd classAdd;
        ClassFolder.ClassRead classRead;
        public WinTravelPackageClientIndividual()
        {
            InitializeComponent();
            classCB = new ClassFolder.ClassCB();
            classAdd = new ClassFolder.ClassAdd();
            classRead = new ClassFolder.ClassRead();
        }

        private void btnAddTravelAgent_Click(object sender, RoutedEventArgs e)
        {
            WindowsAdd.WinAddTravelAgent winAddTravelAgent =
                new WindowsAdd.WinAddTravelAgent();
            winAddTravelAgent.ShowDialog();
        }

        private void btnAddCountry_Click(object sender, RoutedEventArgs e)
        {            
            WindowsAdd.WinAddCountry winAddCountry =
                new WindowsAdd.WinAddCountry();
            winAddCountry.ShowDialog();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            classCB.LoadTourOperator(cbTourOperator);
            classCB.LoadTravelAgent(cbTravelAgent);
            classCB.LoadCountry(cbCountry);
            classCB.LoadPriceType(cbPriceType);
            classCB.LoadClientIndividual(cbClient);
            classCB.LoadOKUN(cbOKUN);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if(dpDateOfIssue.SelectedDate.ToString()=="")
            {
                ClassFolder.ClassMB.MBError("Введите дату оформления путевки");
                dpDateOfIssue.Focus();
            }           
            else if(string.IsNullOrEmpty(tbTranscriptOKUN.Text))
            {
                ClassFolder.ClassMB.MBError("Введите расшифровку ОКУН");
                tbTranscriptOKUN.Focus();
            }
            else if(string.IsNullOrEmpty(tbPrice.Text))
            {
                ClassFolder.ClassMB.MBError("Введите цену");
                tbPrice.Focus();
            }
            else if(cbTourOperator.SelectedValue.ToString()=="")
            {
                ClassFolder.ClassMB.MBError("Выберите туроператора");
                cbTourOperator.Focus();
            }
            else if(cbTravelAgent.SelectedValue.ToString()=="")
            {
                ClassFolder.ClassMB.MBError("Выберите турагента");
                cbTravelAgent.Focus();
            }
            else if(cbCountry.SelectedValue.ToString()=="")
            {
                ClassFolder.ClassMB.MBError("Выберите страну");
                cbCountry.Focus();
            }
            else if(cbPriceType.SelectedValue.ToString()=="")
            {
                ClassFolder.ClassMB.MBError("Выберите тип оплаты");
                cbPriceType.Focus();
            }
            else if(cbClient.SelectedValue.ToString()=="")
            {
                ClassFolder.ClassMB.MBError("Выберите клиента");
                cbClient.Focus();
            }
            else
            {
                try
                {
                    sqlConnection.Open();

                    
                    classRead.ReadTourOperator(cbTourOperator);
                    classRead.ReadTravelAgent(cbTravelAgent);
                    classRead.ReadClientIndividual(cbClient);
                    classAdd.AddTravelPackageClinetIndividual(dpDateOfIssue, tbPrice, cbCountry, cbPriceType, cbOKUN);

                    ClassFolder.ClassMB.MBInformation("Путевка оформлена");
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

        private void cbOKUN_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                sqlConnection.Open();                               

                sqlCommand = new SqlCommand("select * from dbo.OUKN " +
                    "where IdOUKN=" +
                    $"'{cbOKUN.SelectedValue.ToString()}'", sqlConnection);
                dataReader = sqlCommand.ExecuteReader();
                dataReader.Read();
                tbTranscriptOKUN.Text = dataReader[2].ToString();
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
}
