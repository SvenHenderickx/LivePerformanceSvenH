﻿using HuurAdministratie.Models;

namespace HuurAdministratie
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Oracle.DataAccess;
    using Oracle.DataAccess.Client;
    using Oracle.DataAccess.Types;

    public static class DatabaseManager
    {
        /// <summary>
        /// Database connection; uses Connectionstring
        /// </summary>
        private static OracleConnection _Connection = new OracleConnection(_ConnectionString);
        /// <summary>
        /// Temp data for connecting to the database; [Username], [Password], [server-IP]
        /// </summary>
        private const string _ConnectionId = "dbi318943",

            _ConnectionPassword = "password",

            _ConnectionAddress = "//fhictora01.fhict.local:1521/fhictora";


        private static string _ConnectionString
        {
            /// <summary>
            /// Data used to create the database connection 
            /// </summary>
            get
            {
                return string.Format("Data Source={0};Persist Security Info=True;User Id={1};Password={2}", _ConnectionAddress, _ConnectionId, _ConnectionPassword);
            }
        }


        /// <summary>
        /// Creates the command with sql query and database connection information
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        private static OracleCommand CreateOracleCommand(string sql)
        {
            OracleCommand command = new OracleCommand(sql, _Connection);
            command.CommandType = System.Data.CommandType.Text;

            return command;
        }

        /// <summary>
        ///  Opens the connection with the database, returns the reader
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        private static OracleDataReader ExecuteQuery(OracleCommand command)
        {
            try
            {
                if (_Connection.State == ConnectionState.Closed)
                {
                    try
                    {
                        _Connection.Open();
                    }
                    catch (OracleException exc)
                    {
                        Debug.WriteLine("Database connection failed!\n" + exc.Message);
                        throw;
                    }
                }

                OracleDataReader reader = command.ExecuteReader();

                return reader;
            }
            catch (OracleException)
            {
                return null;
            }
        }

        /// <summary>
        /// Opens the connection with the database and inserts the given information, returns true if insert worked
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        private static bool ExecuteNonQuery(OracleCommand command)
        {
            try
            {
                if (_Connection.State == ConnectionState.Closed)
                {
                    try
                    {
                        _Connection.Open();
                    }
                    catch (OracleException exc)
                    {
                        Debug.WriteLine("Database connection failed!\n" + exc.Message);
                        throw;
                    }
                }

                command.ExecuteNonQuery();
                return true;
            }
            catch (OracleException)
            {
                return false;
            }
        }

        /// <summary>
        /// Alle huurcontracten
        /// </summary>
        /// <returns></returns>
        public static List<HuurContract> GetHuurContracten()
        {
            List<HuurContract> tempList = new List<HuurContract>();
            List<Boot> bootList = new List<Boot>();
            try
            {
                OracleCommand command = CreateOracleCommand("SELECT * FROM Huurcontract");
                OracleDataReader reader = ExecuteQuery(command);

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["id"]);
                    string bootnaam = Convert.ToString(reader["bootnaam"]);
                    int huurderId = Convert.ToInt32(reader["huurderId"]);
                    DateTime datumBegin = Convert.ToDateTime(reader["beginDatum"]);
                    DateTime datumEind = Convert.ToDateTime(reader["eindDatum"]);
                    int aantalMeren = Convert.ToInt32(reader["aantalMeren"]);
                    double bedrag = Convert.ToDouble(reader["prijs"]);
                    tempList.Add(new HuurContract(id, datumBegin, datumEind, aantalMeren, bedrag, huurderId));
                }
                return tempList;
            }
            catch(Exception e)
            {
                throw e;
            }
            finally
            {
                _Connection.Close();
            }
        }

        /// <summary>
        /// De huurder van een contract
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        internal static Huurder GetHuurderFromContract(int id)
        {
            Huurder newHuurder = null;
            try
            {
                OracleCommand command = CreateOracleCommand("SELECT * FROM Huurder WHERE id = :huurderId");
                command.Parameters.Add(":huurderId", id);
                OracleDataReader reader = ExecuteQuery(command);

                while (reader.Read())
                {
                    int idHuurder = Convert.ToInt32(reader["id"]);
                    string email = Convert.ToString(reader["emailadres"]);
                    string naam = Convert.ToString(reader["naam"]);
                    newHuurder = new Huurder(id, naam, email);
                }
                return newHuurder;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                _Connection.Close();
            }
        }

        /// <summary>
        /// geeft de artikelen van een contract
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        internal static List<Artikel> GetArtikelFromContract(int id)
        {
            List<Artikel> tempList = new List<Artikel>();
            try
            {
                OracleCommand command = CreateOracleCommand("SELECT * FROM Artikelen INNER JOIN GehuurdeArtikelen ON artikelen.id = gehuurdeartikelen.artikelid WHERE huurcontractId = :huurcontractId");
                command.Parameters.Add(":huurcontractId", id);
                OracleDataReader reader = ExecuteQuery(command);

                while (reader.Read())
                {
                    int idArtikel = Convert.ToInt32(reader["id"]);
                    string naam = Convert.ToString(reader["naam"]);
                    double prijs = Convert.ToDouble(reader["prijs"]);
                    tempList.Add(new Artikel(idArtikel, naam, prijs));
                }
                return tempList;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                _Connection.Close();
            }
        }

        /// <summary>
        /// geeft de boten van een contract
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        internal static Boot GetBootFromContract(int id)
        {
            Boot newBoot = null;
            try
            {
                OracleCommand command = CreateOracleCommand("SELECT boot.naam, boot.type, boot.soort, motor.bootnaam as motornaam, motor.tankinhoud, spierkrachtaangedreven.bootnaam as spiernaam FROM Boot INNER JOIN Huurcontract ON boot.naam = huurcontract.bootnaam FULL OUTER JOIN Motor ON boot.naam = motor.bootnaam FULL OUTER JOIN Spierkrachtaangedreven ON boot.naam = spierkrachtaangedreven.bootnaam WHERE huurcontract.id = :huurcontractId");
                command.Parameters.Add(":huurcontractId", id);
                OracleDataReader reader = ExecuteQuery(command);

                while (reader.Read())
                {
                    string naam = Convert.ToString(reader["naam"]);
                    string type = Convert.ToString(reader["type"]);
                    string soort = Convert.ToString(reader["soort"]);
                    if (reader["motornaam"] != DBNull.Value)
                    {
                        int tankInhoud = Convert.ToInt32(reader["tankinhoud"]);
                        newBoot = new Motor(naam, type, soort, 15.00, tankInhoud);
                    }
                    else
                    {
                        newBoot = new Spierkrachtaangedreven(naam, type, soort, 10.00);
                    }
                }
                return newBoot;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                _Connection.Close();
            }
        }

        /// <summary>
        /// vaargebieden van een contract teruggeven
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        internal static List<Vaargebied> GetVaargebiedFromContract(int id)
        {
            List<Vaargebied> tempList = new List<Vaargebied>();
            try
            {
                OracleCommand command = CreateOracleCommand("SELECT * FROM Vaargebied INNER JOIN VaargebiedHuurcontract ON Vaargebied.ID = VaargebiedHuurcontract.VAARGEBIEDID WHERE huurcontractId = :huurcontractId");
                command.Parameters.Add(":huurcontractId", id);
                OracleDataReader reader = ExecuteQuery(command);

                while (reader.Read())
                {
                    int idVaargebied = Convert.ToInt32(reader["id"]);
                    string naam = Convert.ToString(reader["naam"]);
                    tempList.Add(new Vaargebied(idVaargebied, naam));
                }
                return tempList;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                _Connection.Close();
            }
        }

        /// <summary>
        /// alle mogelijken artikelen
        /// </summary>
        /// <returns></returns>
        internal static List<Artikel> GetAllArtikelen()
        {
            List<Artikel> tempList = new List<Artikel>();
            try
            {
                OracleCommand command = CreateOracleCommand("SELECT * FROM Artikelen");
                OracleDataReader reader = ExecuteQuery(command);

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["id"]);
                    string naam = Convert.ToString(reader["naam"]);
                    double prijs = Convert.ToDouble(reader["prijs"]);
                    tempList.Add(new Artikel(id, naam, prijs));
                }
                return tempList;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                _Connection.Close();
            }
        }

        /// <summary>
        /// alle mogelijken boten
        /// </summary>
        /// <returns></returns>
        internal static List<Boot> GetAlleBoten()
        {
            List<Boot> tempList = new List<Boot>();
            try
            {
                OracleCommand command = CreateOracleCommand("SELECT boot.naam, boot.type, boot.soort, motor.bootnaam as motornaam, motor.tankinhoud, spierkrachtaangedreven.bootnaam as spiernaam FROM Boot LEFT JOIN Motor ON boot.naam = motor.bootnaam LEFT JOIN Spierkrachtaangedreven ON boot.naam = spierkrachtaangedreven.bootnaam");
                OracleDataReader reader = ExecuteQuery(command);

                while (reader.Read())
                {
                    string naam = Convert.ToString(reader["naam"]);
                    string type = Convert.ToString(reader["type"]);
                    string soort = Convert.ToString(reader["soort"]);
                    if (reader["motornaam"] != DBNull.Value)
                    {
                        int tankInhoud = Convert.ToInt32(reader["tankinhoud"]);
                        tempList.Add(new Motor(naam, type, soort, 15.00, tankInhoud));
                    }
                    else
                    {
                        tempList.Add(new Spierkrachtaangedreven(naam, type, soort, 10.00));
                    }
                }
                return tempList;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                _Connection.Close();
            }
        }

        /// <summary>
        /// alle mogelijke vaargebieden
        /// </summary>
        /// <returns></returns>
        internal static List<Vaargebied> GetAllVaargebieden()
        {
            List<Vaargebied> tempList = new List<Vaargebied>();
            try
            {
                OracleCommand command = CreateOracleCommand("SELECT * FROM Vaargebied");
                OracleDataReader reader = ExecuteQuery(command);

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["id"]);
                    string naam = Convert.ToString(reader["naam"]);
                    tempList.Add(new Vaargebied(id, naam));
                }
                return tempList;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                _Connection.Close();
            }
        }

        /// <summary>
        /// voegt een huurder toe
        /// </summary>
        /// <param name="huurContract"></param>
        /// <returns></returns>
        internal static bool AddHuurder(HuurContract huurContract)
        {
            try
            {
                OracleCommand command = CreateOracleCommand("INSERT INTO Huurder(id, naam, emailadres) VALUES (:huurderId, :huurderNaam, :huurderEmail)");
                command.Parameters.Add(":huurderId", huurContract.Huurder.Id);
                command.Parameters.Add(":huurderNaam", huurContract.Huurder.Naam);
                command.Parameters.Add(":huurderEmail", huurContract.Huurder.EmailAdres);
               
                return ExecuteNonQuery(command);
            }
            catch (Exception exception)
            {
                throw new Exception("Something went wrong: " + exception.Message);
            }
            finally
            {
                _Connection.Close();
            }
        }

        /// <summary>
        /// voegt een nieuw contract toe
        /// </summary>
        /// <param name="huurContract"></param>
        /// <returns></returns>
        internal static bool AddHuurcontract(HuurContract huurContract)
        {
            try
            {
                OracleCommand command = CreateOracleCommand("INSERT INTO Huurcontract(id, bootnaam, huurderId, begindatum, einddatum, aantalmeren, prijs, bedrijfid) VALUES (:huurcontractId, :bootnaam, :huurderId, :beginDatum, :eindDatum, :aantalMeren, :prijs, '0')");
                command.Parameters.Add(":huurcontractId", huurContract.Id);
                command.Parameters.Add(":bootNaam", huurContract.Boot.Naam);
                command.Parameters.Add(":huurderId", huurContract.Huurder.Id);
                command.Parameters.Add(":beginDatum", huurContract.BeginDatum);
                command.Parameters.Add(":eindDatum", huurContract.EindDatum);
                command.Parameters.Add(":aantalMeren", huurContract.AantalMeren);
                command.Parameters.Add(":prijs", huurContract.Bedrag);
                return ExecuteNonQuery(command);
            }
            catch (Exception exception)
            {
                throw new Exception("Something went wrong: " + exception.Message);
            }
            finally
            {
                _Connection.Close();
            }
        }

        /// <summary>
        /// voegt de informatie toe van de koppeltablel over vaargebied
        /// </summary>
        /// <param name="huurContract"></param>
        /// <param name="vaargebiedId"></param>
        /// <returns></returns>
        internal static bool AddVaargebiedToContract(HuurContract huurContract, int vaargebiedId)
        {
            try
            {
                OracleCommand command = CreateOracleCommand("INSERT INTO VaargebiedHuurcontract (huurcontractId, vaargebiedId) VALUES (:huurcontractId, :vaargebiedId)");
                command.Parameters.Add(":huurcontractId", huurContract.Id);
                command.Parameters.Add(":vaargebiedId", vaargebiedId);

                return ExecuteNonQuery(command);
            }
            catch (Exception exception)
            {
                throw new Exception("Something went wrong: " + exception.Message);
            }
            finally
            {
                _Connection.Close();
            }
        }

        /// <summary>
        /// voegt de informatie in voor de koppeltabel van artikelen
        /// </summary>
        /// <param name="huurContract"></param>
        /// <param name="vaargebiedId"></param>
        /// <returns></returns>
        internal static bool AddArtikelenToContract(HuurContract huurContract, int artikelId)
        {
            try
            {
                OracleCommand command = CreateOracleCommand("INSERT INTO GehuurdeArtikelen (huurcontractId, artikelid) VALUES (:huurcontractId, :artikelId)");
                command.Parameters.Add(":huurcontractId", huurContract.Id);
                command.Parameters.Add(":artikelId", artikelId);

                return ExecuteNonQuery(command);
            }
            catch (Exception exception)
            {
                throw new Exception("Something went wrong: " + exception.Message);
            }
            finally
            {
                _Connection.Close();
            }
        }

        public static bool AddFullContract(HuurContract contract)
        {
            bool succes = true;
            if (!DatabaseManager.AddHuurder(contract))
                succes = false;
            if (!DatabaseManager.AddHuurcontract(contract))
                succes = false;
            foreach (Vaargebied vg in contract.BevaardeGebieden)
            {
                if (!DatabaseManager.AddVaargebiedToContract(contract, vg.Id))
                    succes = false;
            }
            foreach (Artikel a in contract.Artikelen)
            {
                if (!DatabaseManager.AddArtikelenToContract(contract, a.Id))
                    succes = false;
            }
            return succes;
        }
    }
}
