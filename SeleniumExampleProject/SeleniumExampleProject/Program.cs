using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

class Program
{
    static IWebDriver driver = new ChromeDriver();
    static IWebElement element;
    static IWebElement textBox;
    static IWebElement radioButton;
    static IWebElement checkBox;
    
    static void Main()
    {
        driver.Navigate().GoToUrl("http://executeautomation.com/demosite/index.html?UserName=&Password=&Login=Login");

        driver.Manage().Window.Maximize();

        Thread.Sleep(3000);

        //Element can be found by name, id, CSS selector, XPath
        try
        {
            element = driver.FindElement(By.Name("Initial"));

            if (element.Displayed)
            {
                //System.Console.WriteLine("Yes I can see the element!!");
                GreenMessage("Yes I can see the element!!");
            }            
        }
        catch (NoSuchElementException)
        {
            //System.Console.WriteLine("No I cannot see the element!!");
            RedMessage("No I cannot see the element!!");            
        }

        //Input text in the text box
        textBox = driver.FindElement(By.Id("Initial"));
        textBox.SendKeys("S");
        Console.WriteLine("Initial is: " + textBox.GetAttribute("value"));

        textBox = driver.FindElement(By.Id("FirstName"));
        textBox.SendKeys("Smith");
        Console.WriteLine("First Name is: " + textBox.GetAttribute("value"));
        
        textBox = driver.FindElement(By.Id("MiddleName"));
        textBox.SendKeys("None");
        Console.WriteLine("Middle Name is: " + textBox.GetAttribute("value"));

        Thread.Sleep(5000);

        //textBox.Clear(); //clears the text in the text box
        //textBox.GetAttribute("maxlength"); //gives the maximum length of characters the text box can take

        //Radio Button
        radioButton = driver.FindElement(By.CssSelector("#details > table > tbody > tr:nth-child(5) > td:nth-child(2) > input[type=\"radio\"]:nth-child(1)"));

        if (radioButton.GetAttribute("checked") == "true")
        {
            Console.WriteLine("The radio button is checked and its value is: " + radioButton.GetAttribute("value"));
        }
        else
        {
            Console.WriteLine("The radio button is NOT checked");
        }

        Thread.Sleep(5000);

        //CheckBox
        checkBox = driver.FindElement(By.CssSelector("#details > table > tbody > tr:nth-child(6) > td:nth-child(2) > input[type=\"checkbox\"]:nth-child(1)"));

        if (checkBox.GetAttribute("checked") == "true")
        {
            Console.WriteLine("The checkbox is checked");
        }
        else
        {
            Console.WriteLine("The checkbox is NOT checked");
        }
        
        checkBox = driver.FindElement(By.CssSelector("#details > table > tbody > tr:nth-child(6) > td:nth-child(2) > input[type=\"checkbox\"]:nth-child(2)"));
        checkBox.Click();
        Console.WriteLine("The value of the checked box is: " + checkBox.GetAttribute("value"));

        Thread.Sleep(5000);

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