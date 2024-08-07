namespace GravelPit
{
    internal class MainUrl
    {
        private static string Url_ = ""; // insert here ip / address of server api
        private static string localNetworkAddress = "";
        public static bool useLocalHost = false;
        public static bool useLocalIp = false;
        public static string Url
        {
            get
            {
                if (useLocalHost)
                    return "http://localhost:5000";
                else if (useLocalIp)
                    return localNetworkAddress;
                else
                    return Url_;
            }
        }
    }
}
