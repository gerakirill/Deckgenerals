using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace GameClasses
{
    

    /// <summary>
    /// Class to connect with DataBase
    /// </summary>
    public class SQLManager
    {
        public static readonly string ALL_CARDS_USER = "Computer";      //user in db with all cards
        public static readonly string ALL_CARDS_DECK = "Allcards";      //deck in db with all cards

        public event Action UserCreated;
        public event Action DeckCreated;

        /// <summary>
        /// Func checks if current login is alredy used
        /// </summary>
        /// <param name="userLogin">user login</param>
        /// <returns>true if not used, false if used</returns>
        public bool IfLogInUsed(string userLogin)
        {
            bool result = true;
            foreach (var login in GetUsersLogins())
            {
                if (userLogin == login)
                {
                    result = false;
                }
            }
            return result;
        }
        
        /// <summary>
        /// Func checks if user login matches user pass
        /// </summary>
        /// <param name="userLogin">user login</param>
        /// <param name="userPass">use pass</param>
        /// <returns>true if matches, false if not</returns>
        public bool UserValidated(string userLogin, string userPass)
        {            
            bool result = false;
            string pass = "";

            try
            {
                this.OpenConnection();
                string sql = string.Format("Select PlayerPassword AS PP From Players Where PlayerName = '{0}'", userLogin);
                using (SqlCommand command = new SqlCommand(sql, this.connect))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        pass = reader["PP"].ToString().Trim();
                    }
                    reader.Close();
                }
                this.CloseConnection();
                if (userPass == pass)
                {
                    result = true;
                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
            }
            finally
            {
                this.CloseConnection();
            }
            
            return result;
        }
        
        /// <summary>
        /// Func gets all information of user
        /// </summary>
        /// <param name="userLogin">user login</param>
        /// <returns></returns>
        public User GetUser(string userLogin)
        {
            User usr = new User();

            try
            {
                this.OpenConnection();
                string sql = string.Format("Select PlayerName AS PL, PlayerPassword AS PS, PlayerEmail AS E, PlayerPoints AS P From Players Where PlayerName = '{0}'", userLogin);
                using (SqlCommand command = new SqlCommand(sql, this.connect))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        usr.login = reader["PL"].ToString().Trim();
                        usr.pass = reader["PS"].ToString().Trim();
                        usr.email = reader["E"].ToString().Trim();
                        usr.points = (int)reader["P"];
                    }
                    reader.Close();
                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
            }
            finally
            {
                this.CloseConnection();
            }
            return usr;
        }
        
        /// <summary>
        /// Func gets all user logins
        /// </summary>
        /// <returns>List of all logins in game</returns>
        public List<string> GetUsersLogins()
        {
            List<string> userLogins = new List<string>(0);
            this.OpenConnection();
            string sql = string.Format("Select PlayerName From Players");
            
            using (SqlCommand cmd = new SqlCommand(sql, this.connect))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    userLogins.Add(reader.ToString().Trim());
                }
                reader.Close();
            }
            this.CloseConnection();
            return userLogins;
        }

        /// <summary>
        /// Func adds new user
        /// </summary>
        /// <param name="usr">user to add</param>
        public void AddNewUser(User usr)
        {
            try
            {
                this.OpenConnection();
                var sqlCmd = new SqlCommand("AddNewPlayer", this.connect);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@PlayerName", usr.login);
                sqlCmd.Parameters.AddWithValue("@PlayerPassword", usr.pass);
                sqlCmd.Parameters.AddWithValue("@PlayerEmail", usr.email);
                sqlCmd.Parameters.AddWithValue("@AllCardsDeck", ALL_CARDS_DECK);
                sqlCmd.ExecuteNonQuery();
                this.CloseConnection();
                UserCreated();
            }
            catch (System.Data.SqlClient.SqlException)
            {
            }

            finally
            {
                this.CloseConnection();
            }            
        }

        /// <summary>
        /// Func gets user's deck
        /// </summary>
        /// <param name="userLogin">user login</param>
        /// <param name="deckName">user deck</param>
        /// <returns>Player Deck with specified name</returns>
        public Deck GetDeck(string userLogin, string deckName)
        {
            DataTable deck = new DataTable();
            Deck newDeck = new Deck();
            newDeck.DeckName = deckName;
            try
            {
                this.OpenConnection();
                string sql = string.Format("Select * From Deck, Card where Deck.DeckName = '{0}' and Deck.PlayerName = '{1}' and Deck.CardName = Card.CardName ", deckName, userLogin);
                using (SqlCommand cmd = new SqlCommand(sql, this.connect))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    deck.Load(dr);
                    dr.Close();
                }
                foreach (DataRow row in deck.Rows)
                {
                    string cardName = row["CardName"].ToString().Trim();
                    CardTypes typeOfCard;
                    int temp = (int)row["CardType"];
                    switch (temp)
                    {
                        case 1:
                            typeOfCard = CardTypes.city;
                            break;
                        case 2:
                            typeOfCard = CardTypes.resource;
                            break;
                        case 4:
                            typeOfCard = CardTypes.scene;
                            break;
                        case 8:
                            typeOfCard = CardTypes.armor;
                            break;
                        case 16:
                            typeOfCard = CardTypes.infantry;
                            break;
                        default:
                            typeOfCard = CardTypes.empty;
                            break;
                    }
                    AbilityTypes abilityTypeOfCard = AbilityTypes.empty;
                    temp = (int)row["CardAbilityType"];
                    switch (temp)
                    {
                        case 1:
                            abilityTypeOfCard = AbilityTypes.dealDamage;
                            break;
                        case 2:
                            abilityTypeOfCard = AbilityTypes.buildCity;
                            break;
                        case 3:
                            abilityTypeOfCard = AbilityTypes.addRes;
                            break;
                        default:
                            abilityTypeOfCard = AbilityTypes.empty;
                            break;
                    }

                    CardRarity rarityOfCard = CardRarity.empty;
                    temp = (int)row["CardRarity"];
                    switch (temp)
                    {
                        case 1:
                            rarityOfCard = CardRarity.Common;
                            break;
                        case 2:
                            rarityOfCard = CardRarity.Rare;
                            break;
                        case 4:
                            rarityOfCard = CardRarity.Unique;
                            break;
                        case 8:
                            rarityOfCard = CardRarity.Legendary;
                            break;
                        default:
                            rarityOfCard = CardRarity.empty;
                            break;
                    }

                    int resourceReq = (int)row["ResourceReq"];
                    int abilityVal = (int)row["AbilityVal"];
                    string abilityText = "";
                    if (row["AbilityText"].ToString().Trim() != null)
                    {
                        abilityText = row["AbilityText"].ToString().Trim();
                    }

                    byte[] data = (byte[])row["CardImage"];
                    MemoryStream ms = new MemoryStream(data);

                    Image cardImage = Image.FromStream(ms);

                    int attackVal = (int)row["AttackValue"];

                    int strengthVal = (int)row["StrengthValue"];

                    if (typeOfCard == CardTypes.city )
                    {
                        if (newDeck.DeckName != ALL_CARDS_DECK)         //if it is not deck with all cards then it mumst have city card
                        {
                            Card newCard = new Card(cardName, typeOfCard, abilityTypeOfCard, resourceReq, abilityVal, abilityText, cardImage, attackVal, strengthVal, rarityOfCard);
                            newDeck.CityCard =newCard;
                        }
                        else
                        {
                            Card newCard = new Card(cardName, typeOfCard, abilityTypeOfCard, resourceReq, abilityVal, abilityText, cardImage, attackVal, strengthVal, rarityOfCard);
                            newDeck.AddCard(newCard);
                        }

                    }
                    else
                    {
                        Card newCard = new Card(cardName, typeOfCard, abilityTypeOfCard, resourceReq, abilityVal, abilityText, cardImage, attackVal, strengthVal, rarityOfCard);
                        newDeck.AddCard(newCard);
                    }

                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
            }
            finally
            {
                this.CloseConnection();
            }
                    
            
            
            return newDeck;
        }

        /// <summary>
        /// Func returns all deck of player
        /// </summary>
        /// <param name="userLogin">player login</param>
        /// <returns>List of all player decks</returns>
        public List<Deck> GetDecks(string userLogin)
        {            
            List<Deck> decks = new List<Deck>();
            List<string> deckNames = new List<string>();
            try
            {
                this.OpenConnection();
                string sql = string.Format("Select DeckName From Deck where PlayerName = '{0}' and DeckName != '{1}' group by DeckName", userLogin, ALL_CARDS_DECK);
                using (SqlCommand cmd = new SqlCommand(sql, this.connect))              //Getting all names of player's decks
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int counter = 0;
                        string i = (string)reader.GetSqlString(counter);
                        deckNames.Add(i.Trim());
                        counter++;
                    }
                    reader.Close();
                }
                foreach (string playerDeck in deckNames)                                //Getting decks
                {
                    decks.Add(GetDeck(userLogin, playerDeck));
                }
                
            }
            catch (System.Data.SqlClient.SqlException)
            {
            }
            finally
            {
                this.CloseConnection();
            }
            return decks;

        }

        /// <summary>
        /// Func adds new deck to db
        /// </summary>
        /// <param name="newDeck">deck to add</param>
        /// <param name="userLogin">player login</param>
        public void AddNewDeck(Deck newDeck, string userLogin)
        {
            try
            {
                foreach (Card card in newDeck.cardsInCollection)
                {
                    this.OpenConnection();
                    var sqlCmd = new SqlCommand("AddNewDeck", this.connect);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@PlayerName", userLogin);
                    sqlCmd.Parameters.AddWithValue("@CardName", card.NameOfCard);
                    sqlCmd.Parameters.AddWithValue("@DeckName", newDeck.DeckName);
                    sqlCmd.ExecuteNonQuery();
                    this.CloseConnection();
                }
                if (newDeck.CityCard!=null)
                {
                    this.OpenConnection();
                    var sqlCmdt = new SqlCommand("AddNewDeck", this.connect);
                    sqlCmdt.CommandType = CommandType.StoredProcedure;
                    sqlCmdt.Parameters.AddWithValue("@PlayerName", userLogin);
                    sqlCmdt.Parameters.AddWithValue("@CardName", newDeck.CityCard.NameOfCard);
                    sqlCmdt.Parameters.AddWithValue("@DeckName", newDeck.DeckName);
                    sqlCmdt.ExecuteNonQuery();
                    this.CloseConnection();
                    DeckCreated();
                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
            }

            finally
            {
                this.CloseConnection();

            }
        }

        /// <summary>
        /// Func deletes deck
        /// </summary>
        /// <param name="deckName">Name of deck to delete</param>
        /// <param name="userLogin">Player login</param>
        public void DeleteDeck(string deckName, string userLogin)
        {
            try
            {
                this.OpenConnection();
                var sqlCmd = new SqlCommand("DeleteDeck", this.connect);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@PlayerName", userLogin);
                sqlCmd.Parameters.AddWithValue("@DeckName", deckName);
                sqlCmd.ExecuteNonQuery();
                this.CloseConnection();
            }
            catch (System.Data.SqlClient.SqlException)
            {
            }

            finally
            {
                this.CloseConnection();

            }
        }

        /// <summary>
        /// Finc updates player points
        /// </summary>
        /// <param name="playerName">Player login</param>
        /// <param name="pointsDelta">Difference in points</param>
        public void UpdatePoints(string playerName, int pointsDelta)
        {
            try
            {
                this.OpenConnection();
                var sqlCmd = new SqlCommand("UpdatePlayerPoints", this.connect);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@PlayerName", playerName);
                sqlCmd.Parameters.AddWithValue("@PointsDelta", pointsDelta);
                sqlCmd.ExecuteNonQuery();
                this.CloseConnection();
            }
            catch (System.Data.SqlClient.SqlException)
            {
            }

            finally
            {
                this.CloseConnection();

            }
        }



        public void OpenConnection()
        {
            //
            //connect = new SqlConnection("Data Source=DESKTOP-MD9J02F;Initial Catalog=PlayersDecks;Integrated Security=True");
            string dataSource = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\..\..\GameClasses\GameClasses\AppData\PlayersDecks.mdf"));
            string connection = string.Format("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='{0}';Integrated Security=True;Connect Timeout=30", dataSource);
            connect = new SqlConnection(connection);
            connect.Open();
        }

        public void CloseConnection()
        {
            connect.Close();
        }
        
        private SqlConnection connect = null;
        
    }
    
}
 