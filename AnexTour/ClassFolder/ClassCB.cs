using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AnexTour.ClassFolder
{
       
    class ClassCB
    {
       SqlConnection sqlConnection =
       new SqlConnection(App.ConnectionString());
        SqlDataAdapter dataAdapter;
        SqlCommand sqlCommand;
        DataSet dataSet;
        SqlDataReader dataReader;
        

        public void LoadRegion(ComboBox cbRegion)
        {
            try
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter("Select IdRegion, " +
                    "NameRegion from dbo.Region order by IdRegion ASC",
                    sqlConnection);
                dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "[Region]");
                cbRegion.ItemsSource = dataSet.Tables["[Region]"].DefaultView;
                cbRegion.DisplayMemberPath = dataSet.Tables["[Region]"].Columns["NameRegion"].ToString();
                cbRegion.SelectedValuePath = dataSet.Tables["[Region]"].Columns["IdRegion"].ToString();
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
        public void LoadCity(ComboBox cbCity)
        {
            try
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter("Select IdCity," +
                    "NameCity from dbo.City order by IdCity ASC",
                    sqlConnection);
                dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "[City]");
                cbCity.ItemsSource = dataSet.Tables["[City]"].DefaultView;
                cbCity.DisplayMemberPath = dataSet.Tables["[City]"].Columns["NameCity"].ToString();
                cbCity.SelectedValuePath = dataSet.Tables["[City]"].Columns["IdCity"].ToString();
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
        public void LoadStreet(ComboBox cbStreet)
        {
            try
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter("Select IdStreet," +
                    "NameStreet from dbo.Street order by IdStreet ASC",
                    sqlConnection);
                dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "[Street]");
                cbStreet.ItemsSource = dataSet.Tables["[Street]"].DefaultView;
                cbStreet.DisplayMemberPath = dataSet.Tables["[Street]"].Columns["NameStreet"].ToString();
                cbStreet.SelectedValuePath = dataSet.Tables["[Street]"].Columns["IdStreet"].ToString();
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
        public void LoadIssuedByWhom(ComboBox cbIssuedByWhom)
        {
            try
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter("Select IdAuthority," +
                    "NameAuthority from dbo.TheAuthorityThatIssuedThePassport " +
                    "order by IdAuthority ASC",
                    sqlConnection);
                dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "[TheAuthorityThatIssuedThePassport]");
                cbIssuedByWhom.ItemsSource = dataSet.Tables["[TheAuthorityThatIssuedThePassport]"].DefaultView;
                cbIssuedByWhom.DisplayMemberPath = dataSet.Tables["[TheAuthorityThatIssuedThePassport]"].
                    Columns["NameAuthority"].ToString();
                cbIssuedByWhom.SelectedValuePath = dataSet.Tables["[TheAuthorityThatIssuedThePassport]"].
                    Columns["IdAuthority"].ToString();
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
        public void LoadGender(ComboBox cbGender)
        {
            try
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter("Select IdGender," +
                    "NameGender from dbo.Gender order by IdGender ASC",
                    sqlConnection);
                dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "[Gender]");
                cbGender.ItemsSource = dataSet.Tables["[Gender]"].DefaultView;
                cbGender.DisplayMemberPath = dataSet.Tables["[Gender]"].Columns["NameGender"].ToString();
                cbGender.SelectedValuePath = dataSet.Tables["[Gender]"].Columns["IdGender"].ToString();
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
        public void LoadAddress(ComboBox cbAddress)
        {
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("select * from dbo.ViewAddress " +
                    "order by IdAddress ASC",
                    sqlConnection);
                dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    cbAddress.Items.Add(dataReader[1].ToString() + " " + dataReader[2].ToString() + " " +
                        dataReader[3].ToString() + " " + dataReader[4].ToString() + " " +
                        dataReader[5].ToString() + " " + dataReader[6].ToString() + " " +
                        dataReader[7].ToString());
                }                
            }
            catch (Exception ex)
            {
                ClassMB.MBError(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public void LoadTourOperator(ComboBox cbTourOperator)
        {
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("select * from dbo.ViewTourOperatorComboBox " +
                    "order by IdTourOperator", sqlConnection);
                dataReader = sqlCommand.ExecuteReader();
                while(dataReader.Read())
                {
                    cbTourOperator.Items.Add(dataReader[1].ToString() + " " +
                        dataReader[2].ToString() + " " +
                        dataReader[3].ToString() + " " + dataReader[4].ToString() + " " +
                        dataReader[5].ToString() + " " + dataReader[6].ToString() + " " +
                        dataReader[7].ToString() + " " + dataReader[8].ToString());
                }
            }
            catch (Exception ex)
            {
                ClassMB.MBError(ex);                
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public void LoadTravelAgent(ComboBox cbTravelAgent)
        {
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("select * from dbo.TravelAgent " +
                    "order by IdTravelAgent", sqlConnection);
                dataReader = sqlCommand.ExecuteReader();
                while(dataReader.Read())
                {
                    cbTravelAgent.Items.Add(dataReader[1].ToString() + " " +
                        dataReader[2].ToString() + " " + dataReader[3].ToString());
                }
            }
            catch (Exception ex)
            {
                ClassMB.MBError(ex);                
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public void LoadCountry(ComboBox cbCountry)
        {
            try
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter("Select IdCountry," +
                    "CountryName from dbo.Country order by IdCountry ASC",
                    sqlConnection);
                dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "[Country]");
                cbCountry.ItemsSource = dataSet.Tables["[Country]"].DefaultView;
                cbCountry.DisplayMemberPath = dataSet.Tables["[Country]"].Columns["CountryName"].ToString();
                cbCountry.SelectedValuePath = dataSet.Tables["[Country]"].Columns["IdCountry"].ToString();
            }
            catch (Exception ex)
            {
                ClassMB.MBError(ex);                
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public void LoadPriceType(ComboBox cbPiceType)
        {
            try
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter("Select IdPriceType," +
                    "NamePriceType from dbo.PriceType order by IdPriceType ASC",
                    sqlConnection);
                dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "[PriceType]");
                cbPiceType.ItemsSource = dataSet.Tables["[PriceType]"].DefaultView;
                cbPiceType.DisplayMemberPath = dataSet.Tables["[PriceType]"].Columns["NamePriceType"].ToString();
                cbPiceType.SelectedValuePath = dataSet.Tables["[PriceType]"].Columns["IdPriceType"].ToString();
            }
            catch (Exception ex)
            {
                ClassMB.MBError(ex);            
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public void LoadClientIndividual(ComboBox cbClientIndividual)
        {
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("select * from dbo.ClientIndividual " +
                    "order by Id", sqlConnection);
                dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    cbClientIndividual.Items.Add(dataReader[1].ToString() + " " +
                        dataReader[2].ToString() + " " +
                        dataReader[3].ToString() + " " + dataReader[5].ToString() + " " +
                        dataReader[6].ToString());
                }
            }
            catch (Exception ex)
            {
                ClassMB.MBError(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public void LoadClientLegalEntity(ComboBox cbClientLegalEntity)
        {
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("select * from dbo.ClientLegalEntity " +
                    "order by IdClientLegalEntity", sqlConnection);
                dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    cbClientLegalEntity.Items.Add(dataReader[1].ToString() + " " +
                        dataReader[4].ToString() + " " +
                        dataReader[5].ToString() + " " + dataReader[6].ToString() + " " +
                        dataReader[7].ToString());
                }
            }
            catch (Exception ex)
            {
                ClassMB.MBError(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public void LoadPasport(ComboBox cbPassport)
        {
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("select * from dbo.ViewPasport " +
                    "order by Id ASC", sqlConnection);
                dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    cbPassport.Items.Add(dataReader[1].ToString() + " " + dataReader[2].ToString() + " " +
                        dataReader[3].ToString() + " " + dataReader[4].ToString() + " " +
                        dataReader[5].ToString() + " " + dataReader[6].ToString() + " " +
                        dataReader[7].ToString());
                }
            }
            catch (Exception ex)
            {
                ClassMB.MBError(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public void LoadOKUN(ComboBox cbOKUN)
        {
            try
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter("Select IdOUKN," +
                    "Code from dbo.OUKN order by IdOUKN ASC",
                    sqlConnection);
                dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "[OUKN]");
                cbOKUN.ItemsSource = dataSet.Tables["[OUKN]"].DefaultView;
                cbOKUN.DisplayMemberPath = dataSet.Tables["[OUKN]"].Columns["Code"].ToString();
                cbOKUN.SelectedValuePath = dataSet.Tables["[OUKN]"].Columns["IdOUKN"].ToString();
            }
            catch (Exception ex)
            {
                ClassMB.MBError(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public void LoadDirector(ComboBox cbDirector)
        {
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("select * from dbo.Director " +
                    "order by IdDirector ASC", sqlConnection);
                dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    cbDirector.Items.Add(dataReader[1].ToString() + " " + dataReader[2].ToString() + " " +
                        dataReader[3].ToString() + " " + dataReader[4].ToString() + " " +
                        dataReader[5].ToString());
                }
            }
            catch (Exception ex)
            {
                ClassMB.MBError(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
