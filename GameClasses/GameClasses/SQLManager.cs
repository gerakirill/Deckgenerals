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

namespace GameClasses
{
    /// <summary>
    /// Supporting clsss
    /// </summary>
    public class User
    {
        public string login;
        public string pass;
        public string email;

    }

    /// <summary>
    /// Class to connect with DataBase
    /// </summary>
    public class SQLManager
    {

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
        /// <returns>true if mathes, false if not</returns>
        public bool UserValidated(string userLogin, string userPass)
        {
            bool result = false;
            string pass = "";

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
            return result;
        }
        
        /// <summary>
        /// Func gets all informtion of user
        /// </summary>
        /// <param name="userLogin">user login</param>
        /// <returns></returns>
        public User GetUser(string userLogin)
        {
            User usr = new User();
            this.OpenConnection();
            string sql = string.Format("Select PlayerName AS PL, PlayerPassword AS PS, PlayerEmail AS E From Players Where PlayerName = '{0}'", userLogin);
            using (SqlCommand command = new SqlCommand(sql, this.connect))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    usr.login = reader["PL"].ToString().Trim();
                    usr.pass = reader["PS"].ToString().Trim();
                    usr.email = reader["E"].ToString().Trim();
                }
                reader.Close();
            }
            this.CloseConnection();
            return usr;
        }
        
        /// <summary>
        /// Func gets all user logins
        /// </summary>
        /// <returns></returns>
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
        /// <returns></returns>
        public Deck GetDeck(string userLogin, string deckName)
        {
            this.OpenConnection();
            DataTable deck = new DataTable();            
            string sql = string.Format("Select * From Deck, Card where Deck.DeckName = '{0}' and Deck.PlayerName = '{1}' and Deck.CardName = Card.CardName", deckName, userLogin);
            using (SqlCommand cmd = new SqlCommand(sql, this.connect))
            {
                SqlDataReader dr = cmd.ExecuteReader();
                deck.Load(dr);
                dr.Close();
            }
            Deck newDeck = new Deck();
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
                        typeOfCard = CardTypes.empty;
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
                        typeOfCard = CardTypes.empty;
                        break;
                }

                int resourceReq = (int)row["ResourceReq"];
                int abilityVal = (int)row["AbilityVal"];
                string abilityText = "";
                if (row["AbilityText"].ToString().Trim()!=null)
                {
                    abilityText = row["AbilityText"].ToString().Trim();
                }

                byte[] data = (byte[])row["CardImage"];
                MemoryStream ms = new MemoryStream(data);

                Image cardImage = Image.FromStream(ms);

                int attackVal = (int)row["AttackValue"];

                int strengthVal = (int)row["StrengthValue"];

                Card newCard = new Card(cardName,typeOfCard, abilityTypeOfCard, resourceReq, abilityVal, abilityText, cardImage, attackVal, strengthVal, rarityOfCard);
                newDeck.AddCard(newCard);
            }
            return newDeck;
        }
        
        public void OpenConnection()
        {
            connect = new SqlConnection("Data Source=127.0.0.1, 1433; Network Library=DBMSSOCN; User ID = user; PWD = qwe; Initial Catalog = PlayersDecks");
            connect.Open();
        }

        public void CloseConnection()
        {
            connect.Close();
        }


        private SqlConnection connect = null;
        public event Action UserCreated;
    }
}
 