using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AnexTour.ClassFolder
{
    class ClassRead
    {
        SqlConnection sqlConnection =
            new SqlConnection(App.ConnectionString());
        SqlCommand sqlCommand;
        SqlDataReader dataReader;

        public void ReadAddress(ComboBox cbAddress)
        {
            try
            {
                string[] Address = cbAddress.SelectedValue.ToString().Split
                    (new char[] { ' ' });
                string Postcode = Address[0];
                string Region = Address[1];
                string City = Address[2];
                string Street = Address[3];
                string House = Address[4];
                string Enclosure = Address[5];
                string Apartment = Address[6];

                sqlConnection.Open();

                this.sqlCommand = new SqlCommand("Select IdAddress from dbo.ViewAddress " +
                    $"where Postcode='{Postcode}' and NameRegion='{Region}' " +
                    $" and NameCity='{City}' " +
                    $"and NameStreet='{Street}' and " +
                    $"House='{House}' and Enclosure='{Enclosure}' " +
                    $"and Apartment='{Apartment}'",
                    sqlConnection);
                this.dataReader = this.sqlCommand.ExecuteReader();
                this.dataReader.Read();

                TableFolder.ClassAddress.IdAddress = Int32.Parse(dataReader[0].ToString());

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
        public void ReadPasport(ComboBox cbPasport)
        {
            try
            {
                string[] Pasport = cbPasport.SelectedValue.ToString().Split
                    (new char[] { ' ' });
                string Series = Pasport[0];
                string Number = Pasport[1];
                string Authority = Pasport[2];
                string DateIssue = Pasport[3];
                string Gender = Pasport[5];
                string DateBorn = Pasport[6];
                string PalceBorn = Pasport[8];

                sqlConnection.Open();

                this.sqlCommand = new SqlCommand("Select Id from dbo.ViewPasport " +
                    $"where Series='{Series}' and Number='{Number}' " +
                    $" and NameAuthority='{Authority}' " +
                    $"and DateOfIssue='{DateIssue}' and " +
                    $"NameGender='{Gender}' and DateOfBorn='{DateBorn}' " +
                    $"and PlaceOfBorn='{PalceBorn}'",
                    sqlConnection);
                this.dataReader = this.sqlCommand.ExecuteReader();
                this.dataReader.Read();

                TableFolder.ClassPassport.IdPassport = Int32.Parse(dataReader[0].ToString());

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
        public void ReadDirector(ComboBox cbDirector)
        {
            try
            {
                string[] Director = cbDirector.SelectedValue.ToString().Split
                    (new char[] { ' ' });
                string LastName = Director[0];
                string FirstName = Director[1];
                string MiddleName = Director[2];
                string NumberPhone = Director[3];
                string Email = Director[4];

                sqlConnection.Open();

                this.sqlCommand = new SqlCommand("Select IdDirector from dbo.Director " +
                    $"where LastName='{LastName}' and FirstName='{FirstName}' " +
                    $" and MiddleName='{MiddleName}' " +
                    $"and NumberPhone='{NumberPhone}' and " +
                    $"Email='{Email}'",
                    sqlConnection);
                this.dataReader = this.sqlCommand.ExecuteReader();
                this.dataReader.Read();

                TableFolder.ClassDirector.IdDirector = Int32.Parse(dataReader[0].ToString());

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
        public void ReadTourOperator(ComboBox cbTourOperator)
        {
            try
            {
                string[] massTourOperator = cbTourOperator.SelectedValue.ToString().Split
                    (new char[] { ' ' });
                string FullNameTourOperator = massTourOperator[0];             
                            

                sqlConnection.Open();

                this.sqlCommand = new SqlCommand("Select IdTourOperator from dbo.ViewTourOperator " +
                    $"where FullNameTourOperator='{FullNameTourOperator}'",
                    sqlConnection);
                this.dataReader = this.sqlCommand.ExecuteReader();
                this.dataReader.Read();

                TableFolder.ClassTourOperator.IdTourOperator = Int32.Parse(dataReader[0].ToString());

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
        public void ReadTravelAgent(ComboBox cbTravelAgent)
        {
            try
            {
                string[] massTravelAgent = cbTravelAgent.SelectedValue.ToString().Split
                (new char[] { ' ' });
                string LastName = massTravelAgent[0];
                string FirstName = massTravelAgent[1];
                string MiddleName = massTravelAgent[2];                

                sqlConnection.Open();

                this.sqlCommand = new SqlCommand("select IdTravelAgent from dbo.ViewTravelAgentRead " +
                    $"where LastName='{LastName}' and FirstName='{FirstName}' " +
                    $"and MiddleName='{MiddleName}'", sqlConnection);

                this.dataReader = this.sqlCommand.ExecuteReader();
                this.dataReader.Read();

                TableFolder.ClassTravelAgent.IdTravelAgent = Int32.Parse(dataReader[0].ToString());
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
        public void ReadClientIndividual(ComboBox cbClientIndividual)
        {
            try
            {
                string[] massClientIndividual = cbClientIndividual.SelectedValue.ToString().Split
                (new char[] { ' ' });
                string LastName = massClientIndividual[0];
                string FirstName = massClientIndividual[1];
                string MiddleName = massClientIndividual[2];               

                sqlConnection.Open();

                this.sqlCommand = new SqlCommand("select Id from dbo.ViewClientIndividualRead " +
                    $"where Surname='{LastName}' and Firstname='{FirstName}' " +
                    $"and Middlename='{MiddleName}'", sqlConnection);

                this.dataReader = this.sqlCommand.ExecuteReader();
                this.dataReader.Read();

                TableFolder.ClassClient.IdClientIndividual = Int32.Parse(dataReader[0].ToString());
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
        public void ReadClientLegalEntity(ComboBox cbClientLegalEntity)
        {
            try
            {
                string[] massClientLegalEntity = cbClientLegalEntity.SelectedValue.ToString().Split
                (new char[] { ' ' });
                string FullName = massClientLegalEntity[0];               

                sqlConnection.Open();

                this.sqlCommand = new SqlCommand("select IdClientLegalEntity " +
                    "from dbo.ViewClientLegalEntityRead " +
                    $"where FullName='{FullName}'",
                    sqlConnection);

                this.dataReader = this.sqlCommand.ExecuteReader();
                this.dataReader.Read();

                TableFolder.ClassClient.IdClientLegalEntity = Int32.Parse(dataReader[0].ToString());
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

        public void ReadAddressRegistration(ComboBox cbAddress)
        {
            try
            {
                string[] Address = cbAddress.SelectedValue.ToString().Split
                    (new char[] { ' ' });
                string Postcode = Address[0];
                string Region = Address[1];
                string City = Address[2];
                string Street = Address[3];
                string House = Address[4];
                string Enclosure = Address[5];
                string Apartment = Address[6];

                sqlConnection.Open();

                this.sqlCommand = new SqlCommand("Select IdAddress from dbo.ViewAddress " +
                    $"where Postcode='{Postcode}' and NameRegion='{Region}' " +
                    $" and NameCity='{City}' " +
                    $"and NameStreet='{Street}' and " +
                    $"House='{House}' and Enclosure='{Enclosure}' " +
                    $"and Apartment='{Apartment}'",
                    sqlConnection);
                this.dataReader = this.sqlCommand.ExecuteReader();
                this.dataReader.Read();

                TableFolder.ClassAddress.IdAddressRegistration = Int32.Parse(dataReader[0].ToString());

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
        public void ReadAddressLocation(ComboBox cbAddress)
        {
            try
            {
                string[] Address = cbAddress.SelectedValue.ToString().Split
                    (new char[] { ' ' });
                string Postcode = Address[0];
                string Region = Address[1];
                string City = Address[2];
                string Street = Address[3];
                string House = Address[4];
                string Enclosure = Address[5];
                string Apartment = Address[6];

                sqlConnection.Open();

                this.sqlCommand = new SqlCommand("Select IdAddress from dbo.ViewAddress " +
                    $"where Postcode='{Postcode}' and NameRegion='{Region}' " +
                    $" and NameCity='{City}' " +
                    $"and NameStreet='{Street}' and " +
                    $"House='{House}' and Enclosure='{Enclosure}' " +
                    $"and Apartment='{Apartment}'",
                    sqlConnection);
                this.dataReader = this.sqlCommand.ExecuteReader();
                this.dataReader.Read();

                TableFolder.ClassAddress.IdAddressLoacation = Int32.Parse(dataReader[0].ToString());

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
        public void ReadAddress(TextBox tbPosteCode, ComboBox cbCity,
            ComboBox cbStreet, TextBox tbHouse,
            TextBox tbEnclosure, TextBox tbApartment)
        {
            try
            {
                sqlConnection.Open();

                this.sqlCommand = new SqlCommand("Select IdAddress from dbo.Address " +
                    $"where Postcode='{tbPosteCode.Text}' " +
                    $" and IdCity='{cbCity.SelectedValue.ToString()}' " +
                    $"and IdStreet='{cbStreet.SelectedValue.ToString()}' and " +
                    $"House='{tbHouse.Text}' and Enclosure='{tbEnclosure.Text}' " +
                    $"and Apartment='{tbApartment.Text}'",
                    sqlConnection);
                this.dataReader = this.sqlCommand.ExecuteReader();
                this.dataReader.Read();

                TableFolder.ClassAddress.IdAddress = Int32.Parse(dataReader[0].ToString());
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
        public void ReadPasport(TextBox tbSeries, TextBox tbNumber,
            ComboBox cbIssuedByWhom, DatePicker dpDateOfIssue,
            ComboBox cbGender, DatePicker dpDateOfBorn,
            TextBox tbPlaceOfBorn)
        {
            try
            {
                sqlConnection.Open();

                this.sqlCommand = new SqlCommand("Select Id from dbo.PassportData " +
                    $"where Series='{tbSeries.Text}' and " +
                    $"Number='{tbNumber.Text}' and " +
                    $"IssuedByWhom='{cbIssuedByWhom.SelectedValue.ToString()}' and " +
                    $"DateOfIssue='{dpDateOfIssue.SelectedDate.GetValueOrDefault()}' and " +
                    $"Gender='{cbGender.SelectedValue.ToString()}' and " +
                    $"DateOfBorn='{dpDateOfBorn.SelectedDate.GetValueOrDefault()}' and " +
                    $"PlaceOfBorn='{tbPlaceOfBorn.Text}'",
                    sqlConnection);
                this.dataReader = this.sqlCommand.ExecuteReader();
                this.dataReader.Read();
                TableFolder.ClassPassport.IdPassport = Int32.Parse(dataReader[0].ToString());
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
        public void ReadPasportDataGrid(string series, string number, string nameAuthority,
            string dateIssue, string nameGender, string dateBorn, string placeBorn)
        {
            try
            {
                sqlConnection.Open();

                this.sqlCommand = new SqlCommand("Select Id from dbo.ViewPasport " +
                    $"where Series='{series}' and Number='{number}' " +
                    $" and NameAuthority='{nameAuthority}' " +
                    $"and DateOfIssue='{dateIssue}' and " +
                    $"NameGender='{nameGender}' and DateOfBorn='{dateBorn}' " +
                    $"and PlaceOfBorn='{placeBorn}'",
                    sqlConnection);
                this.dataReader = this.sqlCommand.ExecuteReader();
                this.dataReader.Read();

                TableFolder.ClassPassport.IdPassport = Int32.Parse(dataReader[0].ToString());
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
        public void ReadDirectorDataGrid(string lastName, string firstName, string middleName,
            string numberPhone, string email)
        {
            try
            {
                sqlConnection.Open();

                this.sqlCommand = new SqlCommand("Select IdDirector from dbo.Director " +
                    $"where LastName='{lastName}' and FirstName='{firstName}' " +
                    $" and MiddleName='{middleName}' " +
                    $"and NumberPhone='{numberPhone}' and " +
                    $"Email='{email}'",
                    sqlConnection);
                this.dataReader = this.sqlCommand.ExecuteReader();
                this.dataReader.Read();

                TableFolder.ClassDirector.IdDirector = Int32.Parse(dataReader[0].ToString());
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
        public void ReadPasportEdit(int idPasport)
        {
            try
            {

                sqlConnection.Open();

                this.sqlCommand = new SqlCommand("Select Series, " +
                    "Number, NameAuthority, " +
                    "DateOfIssue, NameGender, DateOfBorn, " +
                    "PlaceOfBorn from dbo.ViewPasport " +
                    $"where Id=" +
                    $"'{TableFolder.ClassPassport.IdPassport}'",
                    sqlConnection);
                this.dataReader = this.sqlCommand.ExecuteReader();
                this.dataReader.Read();

                TableFolder.ClassPassport.NamePasport = dataReader[0].ToString() + " " + dataReader[1].ToString() + " " + dataReader[2].ToString() + " " +
                        dataReader[3].ToString() + " " + dataReader[4].ToString() + " " +
                        dataReader[5].ToString() + " " + dataReader[6].ToString();
                TableFolder.ClassPassport.IdPassport = Int32.Parse(dataReader[0].ToString());

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
        public void ReadDirectorEdit(int idDirector)
        {
            try
            {

                sqlConnection.Open();

                this.sqlCommand = new SqlCommand("Select LastName, " +
                    "FirstName, MiddleName, " +
                    "NumberPhone, Email from dbo.Director " +
                    $"where IdDirector=" +
                    $"'{TableFolder.ClassDirector.IdDirector}'",
                    sqlConnection);
                this.dataReader = this.sqlCommand.ExecuteReader();
                this.dataReader.Read();

                TableFolder.ClassDirector.NameDirector = dataReader[0].ToString() + " " + dataReader[1].ToString() + " " + dataReader[2].ToString() + " " +
                        dataReader[3].ToString() + " " + dataReader[4].ToString();
                TableFolder.ClassDirector.IdDirector = Int32.Parse(dataReader[0].ToString());

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
        public void ReadDirector(TextBox tbLastName, TextBox tbFirstName,
            TextBox tbMiddleName, TextBox tbNumberPhone, TextBox tbEmail)
        {
            try
            {
                sqlConnection.Open();
                this.sqlCommand = new SqlCommand("Select IdDirector from dbo.Director " +
                    $"where LastName='{tbLastName.Text}' and " +
                    $"FirstName='{tbFirstName.Text}' and " +
                    $"MiddleName='{tbMiddleName.Text}' and " +
                    $"NumberPhone='{tbNumberPhone.Text}' and " +
                    $"Email='{tbEmail.Text}'", sqlConnection);
                this.dataReader = this.sqlCommand.ExecuteReader();
                this.dataReader.Read();
                TableFolder.ClassDirector.IdDirector = Int32.Parse(dataReader[0].ToString());
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
        public void ReadOKUN(ComboBox cbOKUN)
        {
            try
            {
                sqlConnection.Open();
                this.sqlCommand = new SqlCommand("Select IdOUKN from dbo.OUKN " +
                    $"where Code='{cbOKUN.Text}'", sqlConnection);
                this.dataReader = this.sqlCommand.ExecuteReader();
                this.dataReader.Read();
                TableFolder.ClassOKUN.IdOKUN = Int32.Parse(dataReader[0].ToString());
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

        public void ReadAddressDataGrid(string postcode, string region, string nameCity,
            string nameStreet, string house, string enclosure, string apartment)
        {
            try
            {

                sqlConnection.Open();

                this.sqlCommand = new SqlCommand("Select IdAddress from dbo.ViewAddress " +
                    $"where Postcode='{postcode}' and NameRegion='{region}' " +
                    $" and NameCity='{nameCity}' " +
                    $"and NameStreet='{nameStreet}' and " +
                    $"House='{house}' and Enclosure='{enclosure}' " +
                    $"and Apartment='{apartment}'",
                    sqlConnection);
                this.dataReader = this.sqlCommand.ExecuteReader();
                this.dataReader.Read();

                TableFolder.ClassAddress.IdAddress = Int32.Parse(dataReader[0].ToString());

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
        public void ReadAddressRegistrationDataGrid(string postcode, string region, 
            string nameCity, string nameStreet, 
            string house, string enclosure, string apartment)
        {
            try
            {

                sqlConnection.Open();

                this.sqlCommand = new SqlCommand("Select IdAddress from dbo.ViewAddress " +
                    $"where Postcode='{postcode}' and NameRegion='{region}' " +
                    $" and NameCity='{nameCity}' " +
                    $"and NameStreet='{nameStreet}' and " +
                    $"House='{house}' and Enclosure='{enclosure}' " +
                    $"and Apartment='{apartment}'",
                    sqlConnection);
                this.dataReader = this.sqlCommand.ExecuteReader();
                this.dataReader.Read();

                TableFolder.ClassAddress.IdAddressRegistration = Int32.Parse(dataReader[0].ToString());

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
        public void ReadAddressLocationDataGrid(string postcode, string region, string nameCity, 
            string nameStreet, string house, string enclosure, string apartment)
        {
            try
            {

                sqlConnection.Open();

                this.sqlCommand = new SqlCommand("Select IdAddress from dbo.ViewAddress " +
                    $"where Postcode='{postcode}' and NameRegion='{region}' " +
                    $" and NameCity='{nameCity}' " +
                    $"and NameStreet='{nameStreet}' and " +
                    $"House='{house}' and Enclosure='{enclosure}' " +
                    $"and Apartment='{apartment}'",
                    sqlConnection);
                this.dataReader = this.sqlCommand.ExecuteReader();
                this.dataReader.Read();

                TableFolder.ClassAddress.IdAddressLoacation = Int32.Parse(dataReader[0].ToString());

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

        public void ReadAddressEdit(int idAddress)
        {
            try
            {

                sqlConnection.Open();

                this.sqlCommand = new SqlCommand("Select Postcode, " +
                    "NameRegion, NameCity, " +
                    "NameStreet, House, Enclosure, " +
                    "Apartment from dbo.ViewAddress " +
                    $"where IdAddress=" +
                    $"'{TableFolder.ClassAddress.IdAddress}'",
                    sqlConnection);
                this.dataReader = this.sqlCommand.ExecuteReader();
                this.dataReader.Read();

                TableFolder.ClassAddress.NameAddress = dataReader[0].ToString() + " " + dataReader[1].ToString() + " " + dataReader[2].ToString() + " " +
                        dataReader[3].ToString() + " " + dataReader[4].ToString() + " " +
                        dataReader[5].ToString() + " " + dataReader[6].ToString();
                TableFolder.ClassAddress.IdAddress = Int32.Parse(dataReader[0].ToString());

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
        public void ReadAddressRegistrationEdit(int idAddress)
        {
            try
            {

                sqlConnection.Open();

                this.sqlCommand = new SqlCommand("Select Postcode, " +
                    "NameRegion, NameCity, " +
                    "NameStreet, House, Enclosure, " +
                    "Apartment from dbo.ViewAddress " +
                    $"where IdAddress=" +
                    $"'{TableFolder.ClassAddress.IdAddressRegistration}'",
                    sqlConnection);
                this.dataReader = this.sqlCommand.ExecuteReader();
                this.dataReader.Read();

                TableFolder.ClassAddress.NameAddressRegistration = dataReader[0].ToString() + " " + dataReader[1].ToString() + " " + dataReader[2].ToString() + " " +
                        dataReader[3].ToString() + " " + dataReader[4].ToString() + " " +
                        dataReader[5].ToString() + " " + dataReader[6].ToString();
                TableFolder.ClassAddress.IdAddressRegistration = Int32.Parse(dataReader[0].ToString());

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
        public void ReadAddressLocationEdit(int idAddress)
        {
            try
            {

                sqlConnection.Open();

                this.sqlCommand = new SqlCommand("Select Postcode, " +
                    "NameRegion, NameCity, " +
                    "NameStreet, House, Enclosure, " +
                    "Apartment from dbo.ViewAddress " +
                    $"where IdAddress=" +
                    $"'{TableFolder.ClassAddress.IdAddressLoacation}'",
                    sqlConnection);
                this.dataReader = this.sqlCommand.ExecuteReader();
                this.dataReader.Read();

                TableFolder.ClassAddress.NameAddressLocation = dataReader[0].ToString() + " " + dataReader[1].ToString() + " " + dataReader[2].ToString() + " " +
                        dataReader[3].ToString() + " " + dataReader[4].ToString() + " " +
                        dataReader[5].ToString() + " " + dataReader[6].ToString();
                TableFolder.ClassAddress.IdAddressLoacation = Int32.Parse(dataReader[0].ToString());

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
