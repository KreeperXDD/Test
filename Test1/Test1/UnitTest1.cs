using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Test1;

public class Tests
{
    private IWebDriver _driver = new ChromeDriver();
    
    [Test]
    public void Test1()
    {
        _driver.Navigate().GoToUrl("https://www.gosuslugi.ru/");
        _driver.FindElement(By.CssSelector(".login-button")).Click();
        
        var buttons = Find(By.CssSelector(".plain-button-inline"));
        var exceptionButton = buttons.ElementAt(1);
        exceptionButton.Click();
        
        buttons = Find(By.CssSelector(".plain-button-inline"));
        var recoverButton = buttons.ElementAt(3);
        recoverButton.Click();

        var isTrue = Find(By.CssSelector(".outline-none")).First().Displayed;

        Console.WriteLine(isTrue);
        
        Assert.Pass();
    }
    
    private IReadOnlyCollection <IWebElement> Find(By by)
    {
        while (true)
        {
            var elements = _driver.FindElements(by);

            if (elements.Count != 0)
            {
                return elements;
            }
            
            Thread.Sleep(10);
        }
    }
}