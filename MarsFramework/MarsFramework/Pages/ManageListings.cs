using MarsFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarsFramework.Pages
{
	class ManageListings
	{
		public ManageListings()
		{
			PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
		}

		// Find the Manage Listings tab 
		[FindsBy(How = How.XPath, Using = "//a[contains(text(),'Manage Listings')]")]
		private IWebElement Managelistings { get; set; }
		
		internal void DeleteLastPage()
		{
			// Click Manage Listings tab
			Managelistings.Click();
			Thread.Sleep(1000);

			// Save the last page number
			int lastPageButtonNumber = Convert.ToInt32(GlobalDefinitions.driver.FindElement(By.XPath("//div[contains(@class,'pagination')]/button[last() - 1]")).Text);

			// Go to the last page 
			GlobalDefinitions.driver.FindElement(By.XPath("//div[contains(@class,'pagination')]/button[last() - 1]")).Click();
			Thread.Sleep(1000);

			// Check how many listings on this page
			int listingCount = GlobalDefinitions.driver.FindElements(By.XPath("//tbody/tr")).Count;

			for (int i = 0; i < listingCount; i++)
			{
				// Click on the delete icon of the last service
				GlobalDefinitions.driver.FindElement(By.XPath("//tr[last()]//i[@class='remove icon']")).Click();

				// Click on the "Yes" button of the popup dialog
				GlobalDefinitions.driver.FindElement(By.XPath("//div[contains(@class,'tiny modal')]//button[contains(text(),'Yes')]")).Click();

				Thread.Sleep(500);
			}

			Thread.Sleep(500);

			// Verify if seller is able to navigate to the previous page
			int newLastPageButtonText = Convert.ToInt32(GlobalDefinitions.driver.FindElement(By.XPath("//div[contains(@class, 'pagination')]//button[contains(@class,'currentPage')]")).Text);
			Assert.That(newLastPageButtonText == lastPageButtonNumber - 1);
		}
	}
}
