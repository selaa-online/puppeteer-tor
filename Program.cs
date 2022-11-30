
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using PuppeteerSharp;
using System;
using System.Threading;
using System.Threading.Tasks;


namespace puppeteer_tor
{
    internal class Program
    {
        static async Task Main(string[] args)
        {


            // Initiating Browser configuration
            Console.WriteLine("Intiating Tor Browser");
 
             Browser browser = (Browser)await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = false,
                ExecutablePath = @"C:\Users\selaka.nanayakkara\Desktop\Tor Browser\Browser\firefox.exe",
                Product = Product.Firefox,
                UserDataDir = @"C:\Users\selaka.nanayakkara\Desktop\Tor Browser\Browser\TorBrowser\Data\profile.default",
                DefaultViewport = null,
                IgnoreHTTPSErrors = true,
                Args = new[] { "-wait-for-browser" }
            });

            // Enabling prxoy connectivilty
            Console.WriteLine("Intiating Tor proxy");
            var page = await browser.PagesAsync();
            Page page1 =(Page)page[0];
            await page1.ClickAsync("#connectButton");

            // Loading geoblocked url.
            Console.WriteLine("Navigating to the URL");
            Page page3 =(Page)await browser.NewPageAsync();
            page3.DefaultNavigationTimeout = 0;
            await page3.GoToAsync("http://nebraskalegislature.gov/laws/browse-chapters.php?chapter=20");

            // Fetching content from the page.
            Console.WriteLine("Fetching content in the URL.");
            var content = await page3.GetContentAsync();
            
            Console.WriteLine("Content fetching completed! ");

            // Closing Browser
            Console.WriteLine("Closing browser.");
            await browser.CloseAsync();

         }
    }

 }



