using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using Microsoft.Win32;


namespace EduquayAPI.Models
{

    public static class CommonUtility
    {
        #region constants

        private const char PROJECT_FIELD_DELIMITER = ',';
        private const string EncryptionKey = "c0$moApp|ica%io#";
        private const string EncryptionKeyMobileApp = "C0530!$@te@3C1uTcH$!@2o!6";
        private const string Subkey = "Svecos";
        private const string SubkeyVersion = "Version01";

        #endregion constants

        /// <summary>
        /// Setting frequency values
        /// </summary>
        public enum Frequency
        {
            Seconds = 1,
            Minutes,
            Hours,
            Daily,
            Weekly,
            Monthly
        }

        public enum WinServiceAction
        {
            Start = 1,
            Stop,
            Restart
        }
        public enum WinServiceStatus
        {
            Scheduled=0,
            Completed,
            Failed,
            Pending
        }

        public static IEnumerable<T> CreateEnumerable<T>(params T[] values) => values;

        // <summary> 
        /// Method to check whether column exists or not 
        /// </summary> 
        /// <param name="reader">SqlDataReader</param> 
        /// <param name="columnName">columnName</param> 
        /// <returns>true if the columName is exists and false if not</returns> 
        public static bool IsColumnExistsAndNotNull(SqlDataReader reader, string columnName)
        {
            for (int count = 0; count < reader.FieldCount; count++)
            {
                if (reader.GetName(count).Trim().ToUpper() == columnName.Trim().ToUpper() && reader[count] != DBNull.Value)

                    return true;
            }

            return false;
        }


        #region GetListFromCommaSeperatedString
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="commmaSeperatedCodes"></param>
        /// <returns></returns>
        public static IList<NamedBusinessCode> CodesToList(string commmaSeperatedCodes)
        {
            IList<NamedBusinessCode> nbcList = new List<NamedBusinessCode>();
            string[] str = commmaSeperatedCodes.Split(PROJECT_FIELD_DELIMITER);
            foreach (string s in str)
            {
                NamedBusinessCode i = new NamedBusinessCode();
                i.Code = s;
                i.Name = string.Empty;
                nbcList.Add(i);
            }
            return nbcList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="commmaSeperatedCodes"></param>
        /// <returns></returns>
        public static IList<NamedBusinessCode> CodesToList(string commmaSeperatedCodes, bool integer)
        {
            IList<NamedBusinessCode> nbcList = new List<NamedBusinessCode>();
            string[] str = commmaSeperatedCodes.Split(PROJECT_FIELD_DELIMITER);
            foreach (string s in str)
            {
                NamedBusinessCode i = new NamedBusinessCode();
                if (integer)
                {
                    if (string.IsNullOrEmpty(s))
                        i.ID = -1;
                    else
                        i.ID = Convert.ToInt32(s);
                }
                else
                    i.Code = s;

                i.Name = string.Empty;
                nbcList.Add(i);
            }
            return nbcList;
        }

        #endregion GetListFromCommaSeperatedString

        #region convert string to Title Case

        /// <summary>
        /// Use the current thread's culture info for conversion
        /// </summary>
        public static string ToTitleCase(this string str)
        {
            var cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            return cultureInfo.TextInfo.ToTitleCase(str.ToLower());
        }
        #endregion convert string to Title Case

        
        /// <summary>
        /// conver array to string
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        static string ConvertStringArrayToString(string[] array)
        {
            //
            // Concatenate all the elements into a StringBuilder.
            //
            StringBuilder builder = new StringBuilder();
            foreach (string value in array)
            {
                builder.Append(value);
                builder.Append('.');
            }
            return builder.ToString();
        }

        /// <summary>
        /// Convert list of string to single string using the given delimiter
        /// </summary>
        /// <param name="list"></param>
        /// <param name="delimiter"></param>
        /// <returns></returns>
        public static string ConvertListToString(List<string> list, string delimiter)
        {
            StringBuilder builder = new StringBuilder();
            foreach (string lst in list)
            {
                if (!string.IsNullOrEmpty(builder.ToString()))
                    builder.Append(delimiter);
                builder.Append(lst);
            }
            return builder.ToString();
        }

        /// <summary>
        /// Encrypt password
        /// </summary>
        /// <param name="strEncrypted"></param>
        /// <returns></returns>
        public static string EnryptString(string strEncrypted)
        {
            byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(strEncrypted);
            string encryptedPassword = Convert.ToBase64String(b);
            return encryptedPassword;
        }

        /// <summary>
        /// Decrypt password
        /// </summary>
        /// <param name="encrString"></param>
        /// <returns></returns>
        public static string DecryptString(string encrString)
        {
            byte[] b = Convert.FromBase64String(encrString);
            string decryptedPassword = System.Text.ASCIIEncoding.ASCII.GetString(b);
            return decryptedPassword;
        }

        public static string GetSerialNumberByProcess()
        {
            string serialnumber = null;
            Process process = new Process
            {
                StartInfo = new ProcessStartInfo("cmd", "/c wmic bios get serialnumber")
                {
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
            // @"D:\Projects\.Net Questions\Samples\ServerSerialNumber\ServerSerialNumber\serial.cmd";
            process.Start();

            // Synchronously read the standard output of the spawned process. 
            StreamReader reader = process.StandardOutput;
            //string output = reader.ReadToEnd();

            process.WaitForExit();
            process.Close();

            string str = null;
            while (reader.Peek() > 0)
            {
                var readLine = reader.ReadLine();
                if (readLine != null) str = readLine.Trim();
                if (!string.IsNullOrEmpty(str) && !str.ToLower().Contains("serialnumber"))
                    serialnumber = str;
            }

            reader.Close();

            return serialnumber;
        }

        public static string GetIPAddressByProcess()
        {
            string ipAddress = null;
            var process = new Process
            {
                StartInfo = new ProcessStartInfo("cmd", "/c wmic nicconfig where 'IPEnabled  = True' get ipaddress")
                {
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
            // @"D:\Projects\.Net Questions\Samples\ServerSerialNumber\ServerSerialNumber\serial.cmd";
            process.Start();

            // Synchronously read the standard output of the spawned process. 
            StreamReader reader = process.StandardOutput;
            //string output = reader.ReadToEnd();

            process.WaitForExit();
            process.Close();

            string str = null;
            while (reader.Peek() > 0)
            {
                var readLine = reader.ReadLine();
                if (readLine != null) str = readLine.Trim();
                if (!string.IsNullOrEmpty(str) && !str.ToLower().Contains("ipaddress"))
                    ipAddress = str;
            }

            reader.Close();

            if (string.IsNullOrEmpty(ipAddress)) return ipAddress;
            var replace = ipAddress.Replace("{", string.Empty).Replace("}", string.Empty);

            var splIpAddress = replace.Split(',');
            var s = splIpAddress[0].Replace("\"", string.Empty);
            return s;
        }

        public static string Encrypt(string encryptText)
        {
            
            byte[] clearBytes = Encoding.Unicode.GetBytes(encryptText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    encryptText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return encryptText;
        }

        public static string Decrypt(string cipherText)
        {
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }

        public static string Encrypt_ActivationKey(string encryptText)
        {

            byte[] clearBytes = Encoding.Unicode.GetBytes(encryptText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x6e, 0x20, 0x76, 0x49, 0x61, 0x64, 0x65, 0x20, });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    encryptText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return encryptText;
        }

        public static string Decrypt_ActivationKey(string cipherText)
        {

            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x6e, 0x20, 0x76, 0x49, 0x61, 0x64, 0x65, 0x20, });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }

        public static byte[] EncKeyGeneration()
        {
            byte[] salt = new byte[] { 0x6e, 0x20, 0x76, 0x49, 0x61, 0x64, 0x65, 0x20, };
            int iterations = 1024;
            var rfc2898 =
            new System.Security.Cryptography.Rfc2898DeriveBytes(EncryptionKeyMobileApp, salt, iterations);
            byte[] key = rfc2898.GetBytes(16);
            String keyB64 = Convert.ToBase64String(key);
            //System.Console.WriteLine("Key: " + keyB64);
            return key;
        }
        
        public static string GetInternalKey()
        {
            var key = GetSerialNumberByProcess();
            if (!string.IsNullOrEmpty(key))
            {
                return Encrypt(key);
            }
            return string.Empty;
        }

        public static string GetInternalKeyWithPackaType(string packageType)
        {
            var key = GetSerialNumberByProcess();

            if (string.IsNullOrEmpty(key))
            {
                key = GetIPAddressByProcess();
            }
            if (!string.IsNullOrEmpty(key))
            {
                return Encrypt(packageType + "@@" + key);
            }
            return string.Empty;
        }


        //Approach 2
        public static string InitialAccessKey()
        {
            var defaultKey = DateTime.Now.AddDays(30).ToShortDateString() + "&001" + "&M";
            
            var key = GetSerialNumberByProcess();
            if (string.IsNullOrEmpty(key))
            {
                key = GetIPAddressByProcess();
            }

            if (!string.IsNullOrEmpty(key))
            {
                defaultKey = key + "&" + defaultKey;
            }

            return Encrypt_ActivationKey(defaultKey);
        }


        /// <summary>
        /// Get Decrypted connection string 
        /// </summary>
        /// <param name="encryptedConnection"></param>
        /// <returns></returns>
        public static string GetParsedConnectionString(string encryptedConnection)
        {
            string connectionString = string.Empty;
            string userid = null;
            string password = null;
            string dbServer = null;
            string dbName = null;

            if (!string.IsNullOrEmpty(encryptedConnection))
            {
                if (encryptedConnection.ToLower().Contains("user id"))
                {
                    var connectionParameters = encryptedConnection.Split(';');
                    if (connectionParameters.Length <= 0) return connectionString;
                    foreach (var t in connectionParameters)
                    {
                        if (t.ToLower().Contains("user id") || t.ToLower().Contains("userid"))
                        {
                            userid = DecryptString(t.Substring(t.IndexOf("=", StringComparison.Ordinal)+1));
                        }
                        else if (t.ToLower().Contains("password"))
                        {
                            password = DecryptString(t.Substring(t.IndexOf("=", StringComparison.Ordinal) + 1));
                        }
                        else if (t.ToLower().Contains("data source"))
                        {
                            dbServer = t.Substring(t.IndexOf("=", StringComparison.Ordinal) + 1);
                        }
                        else if (t.ToLower().Contains("catalog"))
                        {
                            dbName = t.Substring(t.IndexOf("=", StringComparison.Ordinal) + 1);
                        }
                    }
                    connectionString = string.IsNullOrEmpty(dbName)
                        ? string.Format("Data Source={0};User ID={1};password={2};Connection Timeout=60", dbServer, userid, password)
                        : string.Format("Data Source={0};User ID={1};password={2};Initial Catalog={3};", dbServer,
                            userid, password, dbName);
                }
                else
                {
                    connectionString = encryptedConnection;
                }

            }

            return connectionString;
        }

        public static string GetWebServiceConfigFilePath(string xmlFilePath)
        {
            const string mobileServiceDir = "Cosmo.WebServices";
            var parent = !Directory.Exists(Path.Combine(xmlFilePath, mobileServiceDir)) ? Directory.GetParent(Directory.GetParent(xmlFilePath).ToString()).FullName : xmlFilePath;

            return  Path.Combine(parent, mobileServiceDir, "Web.config");
        }

        public static string GetWebServicePath(string xmlFilePath)
        {
            const string mobileServiceDir = "Cosmo.WebServices";
            var parent = !Directory.Exists(Path.Combine(xmlFilePath, mobileServiceDir)) ? Directory.GetParent(Directory.GetParent(xmlFilePath).ToString()).FullName : xmlFilePath;

            return Path.Combine(parent, mobileServiceDir);
        }


        public static string FormatBytes(decimal bytes)
        {
            const int scale = 1024;
            string[] orders = new string[] { "GB", "MB", "KB", "Bytes" };
            long max = (long)Math.Pow(scale, orders.Length - 1);
            foreach (string order in orders)
            {
                if (bytes > max)
                {
                    return string.Format("{0:##.##} {1}", Decimal.Divide(bytes, max), order);
                }

                max /= scale;
            }
            return "0 Bytes";
        }

        public static DateTime ConvertToServerTime(string dateTime, string clientTimeZone)
        {
            if(string.IsNullOrEmpty( dateTime)) return DateTime.Now;

            var receivedTime = Convert.ToDateTime(dateTime);
            var timezone = GetClientZone(clientTimeZone);
            var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(timezone);
            var serverTime = TimeZoneInfo.ConvertTime(receivedTime, timeZoneInfo, TimeZoneInfo.Local);
            return serverTime;
        }

        public static DateTime ConvertToLocalTime(DateTime? dateTime, string clientTimeZone)
        {
            if(dateTime == null) return  DateTime.Now;

            var receivedTime = Convert.ToDateTime(dateTime);
            var timezone = GetClientZone(clientTimeZone);
            var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(timezone);

            var serverTime = TimeZoneInfo.ConvertTime(receivedTime, timeZoneInfo);
            return serverTime;
        }

        public static DateTime ConvertPdtToLocalTime(DateTime? dateTime, string serverTimeZone, string clientTimeZone)
        {
            if (dateTime == null) return DateTime.Now;

            var receivedTime = Convert.ToDateTime(dateTime);
            var timezoneServer = GetClientZone(serverTimeZone);
            var timezoneLocal = GetClientZone(clientTimeZone);
            var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(timezoneServer);
            var timeZoneLocal = TimeZoneInfo.FindSystemTimeZoneById(timezoneLocal);

            var serverTime = TimeZoneInfo.ConvertTime(receivedTime, timeZoneInfo, timeZoneLocal);
            return serverTime;
        }

        public static DateTime ConvertTimeToPZone(DateTime? dateTime, string clientTimeZone)
        {
            DateTime Returndate = DateTime.Now;
            TimeZoneInfo Serverzone = null;

            System.Collections.ObjectModel.ReadOnlyCollection<TimeZoneInfo> timeZones = TimeZoneInfo.GetSystemTimeZones();
            foreach (TimeZoneInfo timeZoneInfos in timeZones)
            {
                Serverzone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneInfos.Id);
                Returndate = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Local, Serverzone);

                if (timeZoneInfos.Id.ToString().Equals("Pacific Standard Time"))
                {
                    break;
                }
            }

            return Returndate;
        }

        private static string GetClientZone(string timeZone)
        {
            var timeZoneList = new Dictionary<string, string>
            {
                {"Afghanistan Standard Time", "Afghanistan Standard Time"},
                {"Alaskan Standard Time", "Alaskan Standard Time"},
                {"Aleutian Standard Time", "Aleutian Standard Time"},
                {"Altai Standard Time", "Altai Standard Time"},
                {"Arab Standard Time", "Arab Standard Time"},
                {"Arabian Standard Time", "Arabian Standard Time"},
                {"Arabic Standard Time", "Arabic Standard Time"},
                {"Argentina Standard Time", "Argentina Standard Time"},
                {"Astrakhan Standard Time", "Astrakhan Standard Time"},
                {"Atlantic Standard Time", "Atlantic Standard Time"},
                {"AUS Central Standard Time", "AUS Central Standard Time"},
                {"Aus Central W. Standard Time", "Aus Central W. Standard Time"},
                {"AUS Eastern Standard Time", "AUS Eastern Standard Time"},
                {"Azerbaijan Standard Time", "Azerbaijan Standard Time"},
                {"Azores Standard Time", "Azores Standard Time"},
                {"Bahia Standard Time", "Bahia Standard Time"},
                {"Bangladesh Standard Time", "Bangladesh Standard Time"},
                {"Belarus Standard Time", "Belarus Standard Time"},
                {"Bougainville Standard Time", "Bougainville Standard Time"},
                {"Canada Central Standard Time", "Canada Central Standard Time"},
                {"Cape Verde Standard Time", "Cape Verde Standard Time"},
                {"Caucasus Standard Time", "Caucasus Standard Time"},
                {"Cen. Australia Standard Time", "Cen. Australia Standard Time"},
                {"Central America Standard Time", "Central America Standard Time"},
                {"Central Asia Standard Time", "Central Asia Standard Time"},
                {"Central Brazilian Standard Time", "Central Brazilian Standard Time"},
                {"Central Europe Standard Time", "Central Europe Standard Time"},
                {"Central European Standard Time", "Central European Standard Time"},
                {"Central Pacific Standard Time", "Central Pacific Standard Time"},
                {"Central Standard Time", "Central Standard Time"},
                {"Central Daylight Time", "Central Standard Time"},
                {"CDT", "Central Standard Time"},
                {"Central Standard Time (Mexico)", "Central Standard Time (Mexico)"},
                {"Chatham Islands Standard Time", "Chatham Islands Standard Time"},
                {"China Standard Time", "China Standard Time"},
                {"Cuba Standard Time", "Cuba Standard Time"},
                {"Dateline Standard Time", "Dateline Standard Time"},
                {"E. Africa Standard Time", "E. Africa Standard Time"},
                {"E. Australia Standard Time", "E. Australia Standard Time"},
                {"E. Europe Standard Time", "E. Europe Standard Time"},
                {"E. South America Standard Time", "E. South America Standard Time"},
                {"Easter Island Standard Time", "Easter Island Standard Time"},
                {"Eastern Standard Time", "Eastern Standard Time"},
                {"Eastern Daylight Time", "Eastern Standard Time"},
                {"EDT", "Eastern Standard Time"},
                {"Eastern Standard Time (Mexico)", "Eastern Standard Time (Mexico)"},
                {"Egypt Standard Time", "Egypt Standard Time"},
                {"Ekaterinburg Standard Time", "Ekaterinburg Standard Time"},
                {"Fiji Standard Time", "Fiji Standard Time"},
                {"FLE Standard Time", "FLE Standard Time"},
                {"Georgian Standard Time", "Georgian Standard Time"},
                {"GMT Standard Time", "GMT Standard Time"},
                {"Greenland Standard Time", "Greenland Standard Time"},
                {"Greenwich Standard Time", "Greenwich Standard Time"},
                {"GTB Standard Time", "GTB Standard Time"},
                {"Haiti Standard Time", "Haiti Standard Time"},
                {"Hawaiian Standard Time", "Hawaiian Standard Time"},
                {"India Standard Time", "India Standard Time"},
                {"Iran Standard Time", "Iran Standard Time"},
                {"Israel Standard Time", "Israel Standard Time"},
                {"Jordan Standard Time", "Jordan Standard Time"},
                {"Kaliningrad Standard Time", "Kaliningrad Standard Time"},
                {"Kamchatka Standard Time", "Kamchatka Standard Time"},
                {"Korea Standard Time", "Korea Standard Time"},
                {"Libya Standard Time", "Libya Standard Time"},
                {"Line Islands Standard Time", "Line Islands Standard Time"},
                {"Lord Howe Standard Time", "Lord Howe Standard Time"},
                {"Magadan Standard Time", "Magadan Standard Time"},
                {"Magallanes Standard Time", "Magallanes Standard Time"},
                {"Marquesas Standard Time", "Marquesas Standard Time"},
                {"Mauritius Standard Time", "Mauritius Standard Time"},
                {"Mid-Atlantic Standard Time", "Mid-Atlantic Standard Time"},
                {"Middle East Standard Time", "Middle East Standard Time"},
                {"Montevideo Standard Time", "Montevideo Standard Time"},
                {"Morocco Standard Time", "Morocco Standard Time"},
                {"Mountain Standard Time", "Mountain Standard Time"},
                {"Mountain Standard Time (Mexico)", "Mountain Standard Time (Mexico)"},
                {"Myanmar Standard Time", "Myanmar Standard Time"},
                {"N. Central Asia Standard Time", "N. Central Asia Standard Time"},
                {"Namibia Standard Time", "Namibia Standard Time"},
                {"Nepal Standard Time", "Nepal Standard Time"},
                {"New Zealand Standard Time", "New Zealand Standard Time"},
                {"Newfoundland Standard Time", "Newfoundland Standard Time"},
                {"Norfolk Standard Time", "Norfolk Standard Time"},
                {"North Asia East Standard Time", "North Asia East Standard Time"},
                {"North Asia Standard Time", "North Asia Standard Time"},
                {"North Korea Standard Time", "North Korea Standard Time"},
                {"Omsk Standard Time", "Omsk Standard Time"},
                {"Pacific SA Standard Time", "Pacific SA Standard Time"},
                {"Pacific Standard Time", "Pacific Standard Time"},
                {"Pacific Standard Time (Mexico)", "Pacific Standard Time (Mexico)"},
                {"Pacific Daylight Time", "Pacific Standard Time"},
                {"PDT", "Pacific Standard Time"},
                {"Pakistan Standard Time", "Pakistan Standard Time"},
                {"Paraguay Standard Time", "Paraguay Standard Time"},
                {"Romance Standard Time", "Romance Standard Time"},
                {"Russia Time Zone 10", "Russia Time Zone 10"},
                {"Russia Time Zone 11", "Russia Time Zone 11"},
                {"Russia Time Zone 3", "Russia Time Zone 3"},
                {"Russian Standard Time", "Russian Standard Time"},
                {"SA Eastern Standard Time", "SA Eastern Standard Time"},
                {"SA Pacific Standard Time", "SA Pacific Standard Time"},
                {"SA Western Standard Time", "SA Western Standard Time"},
                {"Saint Pierre Standard Time", "Saint Pierre Standard Time"},
                {"Sakhalin Standard Time", "Sakhalin Standard Time"},
                {"Samoa Standard Time", "Samoa Standard Time"},
                {"Sao Tome Standard Time", "Sao Tome Standard Time"},
                {"Saratov Standard Time", "Saratov Standard Time"},
                {"SE Asia Standard Time", "SE Asia Standard Time"},
                {"Singapore Standard Time", "Singapore Standard Time"},
                {"South Africa Standard Time", "South Africa Standard Time"},
                {"Sri Lanka Standard Time", "Sri Lanka Standard Time"},
                {"Sudan Standard Time", "Sudan Standard Time"},
                {"Syria Standard Time", "Syria Standard Time"},
                {"Taipei Standard Time", "Taipei Standard Time"},
                {"Tasmania Standard Time", "Tasmania Standard Time"},
                {"Tocantins Standard Time", "Tocantins Standard Time"},
                {"Tokyo Standard Time", "Tokyo Standard Time"},
                {"Tomsk Standard Time", "Tomsk Standard Time"},
                {"Tonga Standard Time", "Tonga Standard Time"},
                {"Transbaikal Standard Time", "Transbaikal Standard Time"},
                {"Turkey Standard Time", "Turkey Standard Time"},
                {"Turks And Caicos Standard Time", "Turks And Caicos Standard Time"},
                {"Ulaanbaatar Standard Time", "Ulaanbaatar Standard Time"},
                {"US Eastern Standard Time", "US Eastern Standard Time"},
                {"US Mountain Standard Time", "US Mountain Standard Time"},
                {"UTC", "UTC"},
                {"UTC+12", "UTC+12"},
                {"UTC+13", "UTC+13"},
                {"UTC-02", "UTC-02"},
                {"UTC-08", "UTC-08"},
                {"UTC-09", "UTC-09"},
                {"UTC-11", "UTC-11"},
                {"Venezuela Standard Time", "Venezuela Standard Time"},
                {"Vladivostok Standard Time", "Vladivostok Standard Time"},
                {"W. Australia Standard Time", "W. Australia Standard Time"},
                {"W. Central Africa Standard Time", "W. Central Africa Standard Time"},
                {"W. Europe Standard Time", "W. Europe Standard Time"},
                {"W. Mongolia Standard Time", "W. Mongolia Standard Time"},
                {"West Asia Standard Time", "West Asia Standard Time"},
                {"West Bank Standard Time", "West Bank Standard Time"},
                {"West Pacific Standard Time", "West Pacific Standard Time"},
                {"Yakutsk Standard Time", "Yakutsk Standard Time"}
            };

            var tz = timeZoneList[timeZone];
            return tz;
        }

    }

    public class ConverTime
    {
        private string _receivedTimeZone;

        public ConverTime(string receivedTimeZone)
        {
            _receivedTimeZone = receivedTimeZone;
        }

    }
}
