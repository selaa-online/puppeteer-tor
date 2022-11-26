
using PuppeteerSharp;
using System.Threading;
using System.Threading.Tasks;


namespace puppeteer_tor
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            string enableAutomation = "--enable-automation";
            string noSandBox = "--no-sandbox";
            string disableSetUidSandBox = "--disable-setuid-sandbox";
            string[] argumentsWithoutExtension = new string[] { 
                "C:\\Users\\selaka.nanayakkara\\Desktop\\Tor Browser\\Browser\\TorBrowser\\Data\\profile.default",
                "--proxy-server=socks5://127.0.0.1:9050",
                "--disable-gpu",
                "--disable-dev-shm-usage",
                enableAutomation, disableSetUidSandBox, noSandBox };

            var options = new LaunchOptions
            {
                Headless = false,
                ExecutablePath = @"C:\Users\selaka.nanayakkara\Desktop\Tor Browser\Browser\firefox.exe",
                Args = argumentsWithoutExtension
            };

            using (var browser = await Puppeteer.LaunchAsync(options))
            {
                Thread.Sleep(5000);
                var page = await browser.NewPageAsync();
                await page.GoToAsync("https://check.torproject.org/");
                var element = await page.WaitForSelectorAsync("h1");
                var text = element.ToString();

            }
        }

    }

}

