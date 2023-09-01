using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Windows;

namespace KriptoTakipSistemi.singleton
{
    internal class User
    {
        public enum ROLE
        {
            DEVELOPER,
            ADMIN,
            REGULAR_USER,
            NONE,
        }

        public class PriceAlarm
        {

            public enum VALIDITY_PERIOD
            {
                PERPETUAL,
                ONE_TIME,
            }
            public enum CONDITION
            {
                CROSS_UP,
                CROSS_DOWN,
                CROSS,
            }
            public long id;
            public string symbol;
            public double price;
            public bool active;
            public CONDITION condition;
            public VALIDITY_PERIOD validityPeriod;
            public bool removed;

            public double lastPrice = -1; // runtime variable which is not kept in database.

            public PriceAlarm Copy()
            {
                PriceAlarm copy = new PriceAlarm();
                copy.id = id;
                copy.symbol = symbol;
                copy.price = price;
                copy.active = active;
                copy.condition = condition;
                copy.validityPeriod = validityPeriod;
                copy.removed = removed;
                copy.lastPrice = lastPrice;
                return copy;
            }
        }
        private static User instance = new User();

        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<string> FavoriteSymbols { get; set; }
        public ROLE Role;
        public List<PriceAlarm> Alarms { get; set; }

        public User()
        {
            Id = -1;
            FirstName = null;
            LastName = null;
            Email = null;
            FavoriteSymbols = new List<string>();
            Alarms = new List<PriceAlarm>();
            Role = ROLE.NONE;
        }

        public static User Instance => instance;

        public event Action LoggedIn;
        public event Action LoggedOut;

        public event Action<string> FavoriteSymbolAdded;
        public event Action<string> FavoriteSymbolRemoved;

        public event Action<PriceAlarm> AlarmAdded;
        public event Action<PriceAlarm> AlarmRemoved;
        public event Action<PriceAlarm> AlarmUpdated;
        public void LogIn(string email, string password)
        {
            if (this.Id >= 0)
            {
                return;
            }

            JArray result;
            try
            {
                result = DataService.Instance.LoginQuery(email, password);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata");
                return;
            }
            JObject userInfo = result[0] as JObject;
            this.Id = long.Parse(userInfo["id"].ToString());
            this.FirstName = userInfo["first_name"].ToString();
            this.LastName = userInfo["last_name"].ToString();
            this.Email = userInfo["email"].ToString();
            bool success = Enum.TryParse<ROLE>(userInfo["role"].ToString(), out Role);
            this.FavoriteSymbols.Clear();
            this.FavoriteSymbols = DataService.Instance.UserFavoriteSymbolsQuery(Id);
            this.Alarms.Clear();
            this.Alarms = DataService.Instance.UserAlarmsQuery(Id);
            OnLoggedIn();
        }

        public void LogOut()
        {
            Id = -1;
            FirstName = null;
            LastName = null;
            Email = null;
            FavoriteSymbols.Clear();
            Role = ROLE.NONE;
            OnLoggedOut();
        }

        public bool checkUser()
        {
            return Id >= 0;
        }

        protected virtual void OnLoggedIn()
        {
            LoggedIn?.Invoke();
        }

        protected virtual void OnLoggedOut()
        {
            LoggedOut?.Invoke();
        }

        public bool AddFavoriteSymbol(string symbol)
        {
            if (FavoriteSymbols.Contains(symbol))
            {
                return false;
            }

            int result = DataService.Instance.UserAddFavoriteSymbol(Id, symbol);
            if (result == 1)
            {
                FavoriteSymbols.Add(symbol);
                FavoriteSymbolAdded(symbol);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RemoveFavoriteSymbol(string symbol)
        {
            if (!FavoriteSymbols.Contains(symbol)) { return false; }
            int result = DataService.Instance.UserRemoveFavoriteSymbol(Id, symbol);
            if (result == 1)
            {
                FavoriteSymbols.Remove(symbol);
                FavoriteSymbolRemoved(symbol);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddPriceAlarm(string symbol, double price, bool active, PriceAlarm.CONDITION condition, PriceAlarm.VALIDITY_PERIOD validityPeriod)
        {
            long alarmId = DataService.Instance.UserAddPriceAlarm(Id, symbol, price, active, condition, validityPeriod);
            if (alarmId != -1)
            {
                PriceAlarm priceAlarm = new PriceAlarm();
                priceAlarm.id = alarmId;
                priceAlarm.symbol = symbol;
                priceAlarm.price = price;
                priceAlarm.active = active;
                priceAlarm.condition = condition;
                priceAlarm.validityPeriod = validityPeriod;
                priceAlarm.removed = false;
                Alarms.Add(priceAlarm);
                AlarmAdded(priceAlarm);
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool RemovePriceAlarm(PriceAlarm priceAlarm)
        {
            int result = DataService.Instance.UserRemovePriceAlarm(Id, priceAlarm.id);
            if (result == 1)
            {
                priceAlarm.removed = true;
                AlarmRemoved(priceAlarm);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdatePriceAlarm(PriceAlarm priceAlarm, PriceAlarm updatedAlarm)
        {
            if (priceAlarm.id != updatedAlarm.id)
            {
                return false;
            }

            int result = DataService.Instance.UserUpdatePriceAlarm(Id, updatedAlarm.id, updatedAlarm.price, updatedAlarm.validityPeriod, updatedAlarm.condition, updatedAlarm.active);
            if (result == 1)
            {
                priceAlarm.price = updatedAlarm.price;
                priceAlarm.validityPeriod = updatedAlarm.validityPeriod;
                priceAlarm.condition = updatedAlarm.condition;
                priceAlarm.active = updatedAlarm.active;
                AlarmUpdated(priceAlarm);
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool UpdateEmail(string newEmail)
        {
            int result = DataService.Instance.ChangeUserEmail(Id, newEmail);
            if (result == 1)
            {
                Email = newEmail;
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
