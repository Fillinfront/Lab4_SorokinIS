using LAB4;
using Serilog;
using Serilog.Sinks.File;
using Serilog.Sinks.MSSqlServer;
using HtmlAgilityPack;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using System.Text;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

class Program
{
    public class PostData
    {
        public int NormalId { get; set; }
        public string Login { get; set; }
        public string Message { get; set; }
    }

    public static List<PostData> postDataList = new List<PostData>();

    static void Main()
    {
        IWebDriver driver = new ChromeDriver();
        driver.Url = "https://forum.littleone.ru/showthread.php?t=4271950&page=2";


        var posts = driver.FindElements(By.XPath("//*[@class='postbitlegacy postbitim postcontainer old']"));

        foreach (var post in posts)
        {
            try
            {
                string id = post.FindElement(By.XPath(".//a[@class='postcounter']")).Text;
                string normalId = id.Replace("#", "");
                int messageID = Convert.ToInt32(normalId);
                string login = post.FindElement(By.XPath(".//div[@class='popupmenu memberaction']")).Text;
                string message = post.FindElement(By.XPath(".//div[@class='content']")).Text;

                postDataList.Add(new PostData
                {
                    NormalId = messageID,
                    Login = login,
                    Message = message
                });
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine("Не удалось найти элемент. сообщение ошибки: " + ex.Message);
            }
        }

        foreach (var post in postDataList)
        {
            DataFunc dataFunc = new DataFunc();
            dataFunc.Add(post.NormalId, post.Login, post.Message);
        }

        driver.Quit();

    }
}