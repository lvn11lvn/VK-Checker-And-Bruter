using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace VK_Checker_By_MENHERA
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            MainForm mainForm = new();
            Application.Run(mainForm);
        }
    }

    public class VK
    {
        public HttpClientHandler httpClientHandler = new();
        public HttpClient httpClient;
        public string Login;
        public string Password;

        public VK(string useragent = "", string login = "", string password = "", string proxy = "", string proxyType = "", int requestTimeout = 2, string proxyUsername = "", string proxyPassword = "")
        {
            Login = login;
            Password = password;
            if (!string.IsNullOrEmpty(proxy) && !string.IsNullOrEmpty(proxyType))
            {
                if (!string.IsNullOrEmpty(proxyUsername) && !string.IsNullOrEmpty(proxyPassword))
                {
                    ICredentials credentials = new NetworkCredential(proxyUsername, proxyPassword);
                    httpClientHandler.Proxy = new WebProxy($"{proxyType.ToLower()}://{proxy}", true, null, credentials);
                }
                else
                {
                    httpClientHandler.Proxy = new WebProxy($"{proxyType.ToLower()}://{proxy}");
                }
            }
            httpClient = new(httpClientHandler)
            {
                Timeout = TimeSpan.FromSeconds(requestTimeout)
            };
            httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(useragent);
        }

        public HttpResponseMessage GetVkSession()
        {
            if (string.IsNullOrEmpty(Login))
            {
                throw new LoginRequired("Login required");
            }
            if (string.IsNullOrEmpty(Password))
            {
                throw new PasswordRequired("Password required");
            }

            HttpResponseMessage response = httpClient.Send(new HttpRequestMessage
            {

                Method = HttpMethod.Get,
                RequestUri = new Uri("https://vk.com/login"),
            });
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            if (response.RequestMessage?.RequestUri?.AbsolutePath == "/429.html")
            {
                foreach (Cookie cookie in httpClientHandler.CookieContainer.GetCookies(new Uri("https://vk.com/429.html")).Cast<Cookie>())
                {
                    if (cookie.Name == "hash429")
                    {
                        string hash429_md5 = Convert.ToHexString(MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(cookie.Value)));
                        cookie.Expires = DateTime.Now.Subtract(TimeSpan.FromDays(1));
                        string sdf = $"{response.RequestMessage.RequestUri.AbsoluteUri}&key={hash429_md5}";
                        response = httpClient.Send(new HttpRequestMessage(HttpMethod.Get, sdf));
                        break;
                    }
                }
            }

            string responseStr = response.Content.ReadAsStringAsync().Result;
            string to_match_value = Regex.Match(responseStr, "\"to\":\"(.*?)\"").Value;
            string ip_h_match_value = Regex.Match(responseStr, "name=\"ip_h\" value=\"([a-z0-9]+)\"").Value;
            string lg_h_match_value = Regex.Match(responseStr, "name=\"lg_h\" value=\"([a-z0-9]+)").Value;
            string lg_domain_h_match_value = Regex.Match(responseStr, "name=\"lg_domain_h\" value=\"([a-z0-9]+)\"").Value;

            Dictionary<string, string> payload = new()
            {
                { "act", "login" },
                { "role", "al_frame" },
                { "expire", "" },
                { "to", to_match_value == "" ? to_match_value : to_match_value.Split(':')[1].Replace("\"", "") },
                { "recaptcha", "" },
                { "captcha_sid", "" },
                { "captcha_key", "" },
                { "_origin", "https://vk.com" },
                { "utf8", "1" },
                { "ip_h", ip_h_match_value == "" ? ip_h_match_value : ip_h_match_value[(Regex.Match(responseStr, "name=\"ip_h\" value=\"([a-z0-9]+)\"").Value.IndexOf("value=\"") + "value=\"".Length)..].Replace("\"", "") },
                { "lg_h", lg_h_match_value == "" ? lg_h_match_value : lg_h_match_value[(Regex.Match(responseStr, "name=\"lg_h\" value=\"([a-z0-9]+)\"").Value.IndexOf("value=\"") + "value=\"".Length)..].Replace("\"", "") },
                { "lg_domain_h", lg_domain_h_match_value == "" ? lg_domain_h_match_value : lg_domain_h_match_value[(Regex.Match(responseStr, "name=\"lg_domain_h\" value=\"([a-z0-9]+)\"").Value.IndexOf("value=\"") + "value=\"".Length)..].Replace("\"", "") },
                { "ul", "" },
                { "email", Login },
                { "pass", Password },
            };

            FormUrlEncodedContent content = new(payload);
            response = httpClient.Send(new HttpRequestMessage
            {

                Method = HttpMethod.Post,
                RequestUri = new Uri("https://login.vk.com/?act=login"),
                Headers = {
                    {"Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8" },
                    {"Accept-Language", "en-US,en;q=0.5" },
                    {"Referer", "https://vk.com/" },
                    { HttpRequestHeader.ContentType.ToString(), "application/x-www-form-urlencoded" },
                    {"Origin", "https://vk.com" },
                },
                Content = content,
            });

            responseStr = response.Content.ReadAsStringAsync().Result;

            if (responseStr.Contains("onLoginCaptcha") || responseStr.Contains("onLoginReCaptcha"))
            {
                throw new Captcha($"Captcha");
            }

            if (responseStr.Contains("onLoginFailed"))
            {
                throw new BadPassword($"BadPassword");
            }

            if (responseStr.Contains("onLoginDone"))
            {

                HttpResponseMessage check = httpClient.Send(new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://vk.com/feed"),
                });

                if (check.RequestMessage?.RequestUri?.Query == "?act=blocked")
                {
                    throw new AccountBlocked($"AccountBlocked");
                }

                if (check.RequestMessage?.RequestUri?.Query == "?act=authcheck")
                {
                    throw new TwoFactorAuth($"TwofactorAuth");
                }

                return response;
            }

            throw new UnhandledError($"UnhandledError: {responseStr}");
        }
    }

    public class VkApiError : Exception
    {
        public VkApiError(string message)
            : base(message) { }
    }

    public class AuthError : VkApiError
    {
        public AuthError(string message)
            : base(message) { }
    }

    public class TwoFactorAuth : AuthError
    {
        public TwoFactorAuth(string message)
            : base(message) { }
    }

    public class BadPassword : AuthError
    {
        public BadPassword(string message)
            : base(message) { }
    }

    public class AccountBlocked : AuthError
    {
        public AccountBlocked(string message)
            : base(message) { }
    }

    public class Captcha : AuthError
    {
        public Captcha(string message)
            : base(message) { }
    }

    public class PasswordRequired : AuthError
    {
        public PasswordRequired(string message)
            : base(message) { }
    }

    public class LoginRequired : AuthError
    {
        public LoginRequired(string message)
            : base(message) { }
    }

    public class UnhandledError : Exception
    {
        public UnhandledError(string message)
            : base(message) { }
    }
}
