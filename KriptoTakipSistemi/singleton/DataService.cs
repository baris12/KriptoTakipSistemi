using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KriptoTakipSistemi.singleton
{
    internal class DataService
    {
        private static DataService _instance;

        public static DataService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DataService();
                }

                return _instance;
            }
        }

        public JArray LoginQuery(string email, string password)
        {
            string queryString = $"SELECT id, first_name, last_name, email, role FROM users WHERE email='{email}' AND password='{password}'";
            JArray result = DatabaseConnection.Instance.SelectQuery(queryString);
            if (result.Count > 1)
            {
                throw new Exception("Multiple results in LoginQuery");
            }
            else if (result.Count <= 0)
            {
                throw new Exception("Kullanıcı adı veya şifre hatalı!");
            }

            return result;
        }
        /*
         [
            {
                "id":0,
                "first_name": "name",
                "last_name": "surname",
                "email": "abc@test.com",
                "role": "admin"
                
            }
         ]
         */

        public List<string> UserFavoriteSymbolsQuery(long userId)
        {
            List<string> symbols = new List<string>();
            string queryString = $"SELECT symbol FROM favorite_symbols WHERE user_id = {userId}";
            JArray result = DatabaseConnection.Instance.SelectQuery(queryString);
            if (result is JArray)
            {
                foreach (JObject symbol in result.Cast<JObject>())
                {
                    symbols.Add(symbol["symbol"].ToString());
                }
            }
            return symbols;
        }



        public int UserAddFavoriteSymbol(long userId, string symbol)
        {
            string queryString = $"INSERT INTO favorite_symbols(user_id, symbol) VALUES({userId}, '{symbol}')";
            int result = DatabaseConnection.Instance.ExecuteNonQuery(queryString);
            return result;
        }
        public int UserRemoveFavoriteSymbol(long userId, string symbol)
        {
            string queryString = $"DELETE FROM favorite_symbols WHERE user_id = {userId} AND symbol = '{symbol}'";
            int result = DatabaseConnection.Instance.ExecuteNonQuery(queryString);
            return result;
        }

        public long UserAddPriceAlarm(long userId, string symbol, double price, bool active, User.PriceAlarm.CONDITION condition, User.PriceAlarm.VALIDITY_PERIOD validityPeriod)
        {
            string queryString = $"INSERT INTO price_alarms (user_id, symbol, price, validity_period, condition, active, removed) VALUES({userId}, '{symbol}', {price.ToString().Replace(",", ".")}, '{validityPeriod}', '{condition}', {true}, {false}) RETURNING id";
            long returningId = DatabaseConnection.Instance.InsertAndGetId(queryString);
            return returningId;
        }
        public int UserRemovePriceAlarm(long userId, long alarmId)
        {
            string queryString = $"UPDATE price_alarms SET removed = {true} WHERE user_id = {userId} AND id = {alarmId}";
            int result = DatabaseConnection.Instance.ExecuteNonQuery(queryString);
            return result;
        }

        public int UserUpdatePriceAlarm(long userId, long alarmId, double price, User.PriceAlarm.VALIDITY_PERIOD validityPeriod, User.PriceAlarm.CONDITION condition, bool active)
        {
            string queryString = $"UPDATE price_alarms SET price = {price.ToString().Replace(",", ".")}, validity_period = '{validityPeriod}', condition = '{condition}', active = {active} WHERE user_id = {userId} AND id = {alarmId}";
            int result = DatabaseConnection.Instance.ExecuteNonQuery(queryString);
            return result;
        }
        public List<User.PriceAlarm> UserAlarmsQuery(long userId)
        {
            string queryString = $"SELECT * FROM price_alarms WHERE user_id = {userId} AND removed = false";
            JArray result = DatabaseConnection.Instance.SelectQuery(queryString);
            List<User.PriceAlarm> priceAlarms = new List<User.PriceAlarm>();
            foreach (JObject row in result.Cast<JObject>())
            {
                User.PriceAlarm priceAlarm = new User.PriceAlarm();
                if (!long.TryParse(row["id"].ToString(), out priceAlarm.id))
                {
                    throw new Exception("alarm hata");
                }

                priceAlarm.symbol = row["symbol"].ToString();
                if (!double.TryParse(row["price"].ToString(), out priceAlarm.price))
                {
                    throw new Exception("alarm hata");
                }

                if (!Enum.TryParse<User.PriceAlarm.VALIDITY_PERIOD>(row["validity_period"].ToString(), out priceAlarm.validityPeriod))
                {
                    throw new Exception("alarm hata");
                }

                if (!Enum.TryParse<User.PriceAlarm.CONDITION>(row["condition"].ToString(), out priceAlarm.condition))
                {
                    throw new Exception("alarm hata");
                }

                if (!bool.TryParse(row["active"].ToString(), out priceAlarm.active))
                {
                    throw new Exception("alarm hata");
                }

                if (!bool.TryParse(row["removed"].ToString(), out priceAlarm.removed))
                {
                    throw new Exception("alarm hata");
                }

                priceAlarms.Add(priceAlarm);
            }
            return priceAlarms;
        }
        public int UserChangePassword(long userId, string password)
        {
            throw new NotImplementedException();
        }

        public List<PAGE> QueryRolePrivilege(User.ROLE role)
        {
            List<PAGE> privileges = new List<PAGE>();
            string queryString = $"SELECT screen_name FROM role_screen_relation WHERE role = '{role}'";
            JArray result = DatabaseConnection.Instance.SelectQuery(queryString);
            foreach (JObject row in result.Cast<JObject>())
            {
                if (Enum.TryParse<PAGE>(row["screen_name"].ToString(), out PAGE page))
                {
                    privileges.Add(page);
                }
            }
            return privileges;
        }

        public List<User> QueryAllUsers()
        {
            List<User> users = new List<User>();
            string queryString = $"SELECT id, first_name, last_name, email, role FROM users WHERE email != '{User.Instance.Email}';";
            JArray result = DatabaseConnection.Instance.SelectQuery(queryString);
            foreach (JObject row in result.Cast<JObject>())
            {
                User user = new User();
                if (!Enum.TryParse<User.ROLE>(row["role"].ToString(), out user.Role))
                {
                    return new List<User>();
                }

                user.Id = long.Parse(row["id"].ToString());
                user.FirstName = row["first_name"].ToString();
                user.LastName = row["last_name"].ToString();
                user.Email = row["email"].ToString();
                users.Add(user);
            }
            return users;
        }

        public int ChangeUserEmail(long userId, string email)
        {
            string queryString = $"UPDATE users SET email = '{email}' WHERE id = {userId}";
            int result = DatabaseConnection.Instance.ExecuteNonQuery(queryString);
            return result;
        }
        public int ChangeUserPassword(long userId, string password)
        {
            string queryString = $"UPDATE users SET password = '{password}' WHERE id = {userId}";
            int result = DatabaseConnection.Instance.ExecuteNonQuery(queryString);
            return result;
        }
        public int ChangeUserRole(long userId, User.ROLE role)
        {
            string queryString = $"UPDATE users SET role = '{role}' WHERE id = {userId}";
            int result = DatabaseConnection.Instance.ExecuteNonQuery(queryString);
            return result;
        }

        public int AddPrivilegeToRole(User.ROLE role, PAGE page)
        {
            string queryString = $"INSERT INTO role_screen_relation(role, screen_name) VALUES('{role}', '{page}')";
            int result = DatabaseConnection.Instance.ExecuteNonQuery(queryString);
            return result;
        }
        public int RemovePrivilegeFromRole(User.ROLE role, PAGE page)
        {
            string queryString = $"DELETE FROM role_screen_relation WHERE role = '{role}' AND screen_name = '{page}'";
            int result = DatabaseConnection.Instance.ExecuteNonQuery(queryString);
            return result;
        }

        public int AddNewUser(string firstName, string lastName, string email, string password, User.ROLE role)
        {
            string queryString = $"INSERT INTO users(first_name, last_name, email, password, role) values('{firstName}', '{lastName}', '{email}', '{password}', '{role}');";
            int result = DatabaseConnection.Instance.ExecuteNonQuery(queryString);
            return result;
        }

        public bool UserCheckPassword(long userId, string password)
        {
            string queryString = $"SELECT CASE WHEN password = '{password}' THEN 1 ELSE 0 END AS is_password_correct FROM users WHERE id = {userId}";
            JArray result = DatabaseConnection.Instance.SelectQuery(queryString);
            if (result.Count == 1)
            {
                JObject value = result[0] as JObject;
                if (value != null)
                {
                    return value["is_password_correct"].ToString() == "1";
                }
            }
            return false;
        }
    }
}
