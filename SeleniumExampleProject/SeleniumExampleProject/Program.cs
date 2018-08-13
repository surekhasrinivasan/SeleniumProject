using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

class Program
{
    static void Main()
    {
        IWebDriver driver = new ChromeDriver();

        driver.Navigate().GoToUrl("http://executeautomation.com/demosite/index.html?UserName=&Password=&Login=Login");

        driver.Manage().Window.Maximize();

        Thread.Sleep(3000);

        //Element can be found by name, id, CSS selector, XPath
        IWebElement element = driver.FindElement(By.Name("Initial"));

        if (element.Displayed)
        {
            //System.Console.WriteLine("Yes I can see the element!!");
            GreenMessage("Yes I can see the element!!");
        }
        else
        {
            //System.Console.WriteLine("No I cannot see the element!!");
            RedMessage("No I cannot see the element!!");
        }

        driver.Quit();
    }

    private static void GreenMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(message);
        Console.ForegroundColor = ConsoleColor.White;
    }

    private static void RedMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ForegroundColor = ConsoleColor.White;
    }
}