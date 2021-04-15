using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AnexTour.ClassFolder
{
    class ClassAdd
    {
        SqlConnection sqlConnection =
        new SqlConnection(App.ConnectionString());
        SqlCommand sqlCommand;            

        public void AddAddress(TextBox tbPosteCode, 
            ComboBox cbCity, ComboBox cbStreet, TextBox tbHouse, 
            TextBox tbEnclosure, TextBox tbApartment)
        {
            try
            {
                sqlConnection.Open();
                this.sqlCommand = new SqlCommand("insert into dbo.Address(" +
                    "Postcode, IdCity, IdStreet, " +
                    "House, Enclosure, Apartment) " +
                    "Values(" +
                    "@Postcode, @IdCity," +
                    "@IdStreet, @House," +
                    "@Enclosure, @Apartment)",
                    sqlConnection);
                this.sqlCommand.Parameters.AddWithValue("Postcode", tbPosteCode.Text);
                this.sqlCommand.Parameters.AddWithValue("IdCity", Int32.Parse(cbCity.SelectedValue.ToString()));
                this.sqlCommand.Parameters.AddWithValue("IdStreet", Int32.Parse(cbStreet.SelectedValue.ToString()));
                this.sqlCommand.Parameters.AddWithValue("House", tbHouse.Text);
                this.sqlCommand.Parameters.AddWithValue("Enclosure", tbEnclosure.Text);
                this.sqlCommand.Parameters.AddWithValue("Apartment", tbApartment.Text);
                this.sqlCommand.ExecuteNonQuery();
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
        public void AddPasport(TextBox tbSeries,
            TextBox tbNumberPasport, ComboBox cbIssuedByWhom,
            DatePicker dpDateOfIssue, ComboBox cbGender,
            DatePicker dpDateOfBorn, TextBox tbPlaceOfBorn)
        {
            try
            {
                sqlConnection.Open();
                this.sqlCommand = new SqlCommand("Insert into dbo.PassportData(" +
                    "Series, Number, " +
                    "IssuedByWhom, DateOfIssue, " +
                    "Gender, DateOfBorn, " +
                    "PlaceOfBorn) " +
                    "Values(@Series, " +
                    "@Number, @IssuedByWhom, " +
                    "@DateOfIssue, @Gender, " +
                    "@DateOfBorn, @PlaceOfBorn)", 
                    sqlConnection);
                this.sqlCommand.Parameters.AddWithValue("Series", tbSeries.Text);
                this.sqlCommand.Parameters.AddWithValue("Number", tbNumberPasport.Text);
                this.sqlCommand.Parameters.AddWithValue("IssuedByWhom", Int32.Parse(cbIssuedByWhom.SelectedValue.ToString()));
                this.sqlCommand.Parameters.AddWithValue("DateOfIssue", dpDateOfIssue.SelectedDate.GetValueOrDefault());
                this.sqlCommand.Parameters.AddWithValue("Gender", Int32.Parse(cbGender.SelectedValue.ToString()));
                this.sqlCommand.Parameters.AddWithValue("DateOfBorn", dpDateOfBorn.SelectedDate.GetValueOrDefault());
                this.sqlCommand.Parameters.AddWithValue("PlaceOfBorn", tbPlaceOfBorn.Text);
                this.sqlCommand.ExecuteNonQuery();
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
        public void AddClientIndividual(TextBox tbLastName,
            TextBox tbFirstName, TextBox tbMiddleName, TextBox tbNumberPhone,
            TextBox tbEmail)
        {

            try
            {

                sqlConnection.Open();
                this.sqlCommand = new SqlCommand("Insert into dbo.ClientIndividual(" +
                    "Surname, Firstname, Middlename, Passport, " +
                    "PhoneNumber, Email, IdAddress)" +
                    "Values(@Surname, " +
                    "@Firstname, @Middlename, " +
                    "@Passport, @PhoneNumber, " +
                    "@Email, @IdAddress)",
                    sqlConnection);
                this.sqlCommand.Parameters.AddWithValue("Surname", tbLastName.Text);
                this.sqlCommand.Parameters.AddWithValue("Firstname", tbFirstName.Text);
                this.sqlCommand.Parameters.AddWithValue("Middlename", tbMiddleName.Text);
                this.sqlCommand.Parameters.AddWithValue("Passport", TableFolder.ClassPassport.IdPassport);
                this.sqlCommand.Parameters.AddWithValue("PhoneNumber", tbNumberPhone.Text);
                this.sqlCommand.Parameters.AddWithValue("Email", tbEmail.Text);
                this.sqlCommand.Parameters.AddWithValue("IdAddress", TableFolder.ClassAddress.IdAddress);
                this.sqlCommand.ExecuteNonQuery();

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

        public void AddDirector(TextBox tbLastName, TextBox tbFirstName,
            TextBox tbMiddleName, TextBox tbNumberPhone, TextBox tbEmail)
        {
            try
            {
                sqlConnection.Open();
                this.sqlCommand = new SqlCommand("Insert into dbo.Director(LastName, " +
                    "FirstName, MiddleName, NumberPhone, Email) " +
                    "Values(@LastName, " +
                    "@FirstName, @MiddleName, " +
                    "@NumberPhone, @Email)", sqlConnection);
                this.sqlCommand.Parameters.AddWithValue("LastName", tbLastName.Text);
                this.sqlCommand.Parameters.AddWithValue("FirstName", tbFirstName.Text);
                this.sqlCommand.Parameters.AddWithValue("MiddleName", tbMiddleName.Text);
                this.sqlCommand.Parameters.AddWithValue("NumberPhone", tbNumberPhone.Text);
                this.sqlCommand.Parameters.AddWithValue("Email", tbEmail.Text);
                this.sqlCommand.ExecuteNonQuery();
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
        public void AddClientLegalentity(TextBox tbFullName, TextBox tbNumberPhone,
            TextBox tbEmail, TextBox tbINN, TextBox tbOKPO)
        {
            try
            {
                sqlConnection.Open();
                this.sqlCommand = new SqlCommand("Insert into dbo.ClientLegalEntity(" +
                    "FullName, IdRegisterAddress, IdAddressLocation, NumberPhone, " +
                    "Email, INN, OKPO, IdDirector) " +
                    "Values(@FullName, @IdRegisterAddress, " +
                    "@IdAddressLocation, @NumberPhone, @Email, " +
                    "@INN, @OKPO, @IdDirector)", sqlConnection);
                this.sqlCommand.Parameters.AddWithValue("FullName", tbFullName.Text);
                this.sqlCommand.Parameters.AddWithValue("IdRegisterAddress",
                    TableFolder.ClassAddress.IdAddressRegistration);
                this.sqlCommand.Parameters.AddWithValue("IdAddressLocation", 
                    TableFolder.ClassAddress.IdAddressLoacation);
                this.sqlCommand.Parameters.AddWithValue("NumberPhone", tbNumberPhone.Text);
                this.sqlCommand.Parameters.AddWithValue("Email", tbEmail.Text);
                this.sqlCommand.Parameters.AddWithValue("INN", tbINN.Text);
                this.sqlCommand.Parameters.AddWithValue("OKPO", tbOKPO.Text);
                this.sqlCommand.Parameters.AddWithValue("IdDirector", 
                    TableFolder.ClassDirector.IdDirector);
                this.sqlCommand.ExecuteNonQuery();
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
        public void AddTourOperator(TextBox tbFullNameTourOperator,
            TextBox PhoneNumber, TextBox Email, TextBox INN, 
            TextBox KPP, TextBox OGRN, TextBox OKPO)
        {
            try
            {
                sqlConnection.Open();
                this.sqlCommand = new SqlCommand("Insert into dbo.TourOperator(" +
                    "FullNameTourOperator, IdRegisterAddress, IdAddressLocation, " +
                    "PhoneNumber, Email, IdDirector, INN, KPP, OGRN, OKPO) " +
                    "Values(@FullNameTourOperator, " +
                    "@IdRegisterAddress, @IdAddressLocation, @PhoneNumber, @Email, " +
                    "@IdDirector, @INN, @KPP, @OGRN, @OKPO)", sqlConnection);
                this.sqlCommand.Parameters.AddWithValue("FullNameTourOperator", tbFullNameTourOperator.Text);
                this.sqlCommand.Parameters.AddWithValue("IdRegisterAddress", 
                    TableFolder.ClassAddress.IdAddressRegistration);
                this.sqlCommand.Parameters.AddWithValue("IdAddressLocation", 
                    TableFolder.ClassAddress.IdAddressLoacation);
                this.sqlCommand.Parameters.AddWithValue("PhoneNumber", PhoneNumber.Text);
                this.sqlCommand.Parameters.AddWithValue("Email", Email.Text);
                this.sqlCommand.Parameters.AddWithValue("IdDirector", 
                    TableFolder.ClassDirector.IdDirector);
                this.sqlCommand.Parameters.AddWithValue("INN", INN.Text);
                this.sqlCommand.Parameters.AddWithValue("KPP", KPP.Text);
                this.sqlCommand.Parameters.AddWithValue("OGRN", OGRN.Text);
                this.sqlCommand.Parameters.AddWithValue("OKPO", OKPO.Text);
                this.sqlCommand.ExecuteNonQuery();
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
        public void AddTravelAgent(TextBox tbLastName,
            TextBox tbFirstName, TextBox tbMiddleName)
        {
            try
            {
                sqlConnection.Open();
                this.sqlCommand = new SqlCommand("Insert into dbo.TravelAgent(" +
                    "LastName, FirstName, MiddleName, PassportData) " +
                    "values(@LastName, @FirstName, " +
                    "@MiddleName, @PassportData)", sqlConnection);
                this.sqlCommand.Parameters.AddWithValue("LastName", 
                    tbLastName.Text);
                this.sqlCommand.Parameters.AddWithValue("FirstName",
                    tbFirstName.Text);
                this.sqlCommand.Parameters.AddWithValue("MiddleName",
                    tbMiddleName.Text);
                this.sqlCommand.Parameters.AddWithValue("PassportData",
                    TableFolder.ClassPassport.IdPassport);
                this.sqlCommand.ExecuteNonQuery();
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
        public void AddTravelPackageClinetIndividual(DatePicker dpDateOfIssue,
            TextBox tbPrice, ComboBox cbCountry, ComboBox cbPriceType, ComboBox cbOKUN)
        {
            try
            {
                sqlConnection.Open();

                this.sqlCommand = new SqlCommand("insert into dbo.TravelPackage(" +
                    "Date, IdOUKN, Price, IdTourOperator, TravelAgent, Country, " +
                    "PriceType, IdClientIndividula) values(" +
                    "@Date, @IdOUKN, @Price, @IdTourOperator, @TravelAgent, @Country, " +
                    "@PriceType, @IdClientIndividula)", sqlConnection);
                this.sqlCommand.Parameters.AddWithValue("Date", 
                    dpDateOfIssue.SelectedDate.GetValueOrDefault());
                this.sqlCommand.Parameters.AddWithValue("IdOUKN", 
                    Int32.Parse(cbOKUN.SelectedValue.ToString()));
                this.sqlCommand.Parameters.AddWithValue("Price", tbPrice.Text);
                this.sqlCommand.Parameters.AddWithValue("IdTourOperator",
                    TableFolder.ClassTourOperator.IdTourOperator);
                this.sqlCommand.Parameters.AddWithValue("TravelAgent",
                    TableFolder.ClassTravelAgent.IdTravelAgent);
                this.sqlCommand.Parameters.AddWithValue("Country", 
                    Int32.Parse(cbCountry.SelectedValue.ToString()));
                this.sqlCommand.Parameters.AddWithValue("PriceType",
                    Int32.Parse(cbPriceType.SelectedValue.ToString()));
                this.sqlCommand.Parameters.AddWithValue("IdClientIndividula",
                    TableFolder.ClassClient.IdClientIndividual);

                this.sqlCommand.ExecuteNonQuery();
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
        public void AddTravelPackageClinetLegalEntity(DatePicker dpDateOfIssue,
            TextBox tbPrice, ComboBox cbCountry, ComboBox cbPriceType, ComboBox cbOKUN)
        {
            try
            {
                sqlConnection.Open();

                this.sqlCommand = new SqlCommand("insert into dbo.TravelPackage(" +
                    "Date, IdOUKN, Price, IdTourOperator, TravelAgent, Country, " +
                    "PriceType, IdClientLegalEntity) values(" +
                    "@Date, @IdOUKN, @Price, @IdTourOperator, @TravelAgent, @Country, " +
                    "@PriceType, @IdClientLegalEntity)", sqlConnection);
                this.sqlCommand.Parameters.AddWithValue("Date",
                    dpDateOfIssue.SelectedDate.GetValueOrDefault());
                this.sqlCommand.Parameters.AddWithValue("IdOUKN",
                    Int32.Parse(cbOKUN.SelectedValue.ToString()));
                this.sqlCommand.Parameters.AddWithValue("Price", tbPrice.Text);
                this.sqlCommand.Parameters.AddWithValue("IdTourOperator",
                    TableFolder.ClassTourOperator.IdTourOperator);
                this.sqlCommand.Parameters.AddWithValue("TravelAgent",
                    TableFolder.ClassTravelAgent.IdTravelAgent);
                this.sqlCommand.Parameters.AddWithValue("Country",
                    Int32.Parse(cbCountry.SelectedValue.ToString()));
                this.sqlCommand.Parameters.AddWithValue("PriceType",
                    Int32.Parse(cbPriceType.SelectedValue.ToString()));
                this.sqlCommand.Parameters.AddWithValue("IdClientLegalEntity",
                    TableFolder.ClassClient.IdClientLegalEntity);

                this.sqlCommand.ExecuteNonQuery();
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
