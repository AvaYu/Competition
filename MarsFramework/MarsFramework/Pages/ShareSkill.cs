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
	class ShareSkill
	{
		public ShareSkill()
		{
			PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
		}

		internal void ValidSkill()
		{
			// Click on the Share Skill button
			GlobalDefinitions.driver.FindElement(By.XPath("//section[@class='nav-secondary']//a[contains(@class,'button')][contains(text(),'Share Skill')]")).Click();

			//Populate the Excel Sheet
			GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ShareSkill");
			Thread.Sleep(1000);

			// Input Testing into the Title field
			IWebElement title = GlobalDefinitions.driver.FindElement(By.Name("title"));
			title.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Title"));

			// Input Selenium into the Description field
			IWebElement description = GlobalDefinitions.driver.FindElement(By.Name("description"));
			description.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));

			// Choose Category as Business
			IWebElement category = GlobalDefinitions.driver.FindElement(By.Name("categoryId"));
			category.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Category"));

			// Choose Subcategory as Market Advice
			IWebElement subcategory = GlobalDefinitions.driver.FindElement(By.Name("subcategoryId"));
			subcategory.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Subcategory"));

			// Input Automation into the Tags field and press Enter key
			IWebElement tag = GlobalDefinitions.driver.FindElement(By.XPath("(//input[@type='text'][@placeholder='Add new tag'])[1]"));
			tag.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Tags"));
			tag.SendKeys(Keys.Enter);

			// Tick One-off service option of Service Type
			GlobalDefinitions.driver.FindElement(By.XPath("//input[@name='serviceType'][@value='1']")).Click();

			// Tick On-site option of Location Type
			GlobalDefinitions.driver.FindElement(By.XPath("//input[@name='locationType'][@value='0']")).Click();

			// Tick Credit option of Skill Trade
			GlobalDefinitions.driver.FindElement(By.XPath("//input[@name='skillTrades'][@value='false']")).Click();

			// Input 10 into price field
			IWebElement creditprice = GlobalDefinitions.driver.FindElement(By.Name("charge"));
			creditprice.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Credit"));

			// Tick Hidden option of Active
			GlobalDefinitions.driver.FindElement(By.XPath("//input[@name='isActive'][@value='false']")).Click();

			// Click on the Save button
			GlobalDefinitions.driver.FindElement(By.XPath("//input[@type='button'][@value='Save']")).Click();

			Thread.Sleep(500);

			// Verify if add the skill successfully and navigate to ListingManagement
			Assert.IsNotNull(GlobalDefinitions.driver.FindElement(By.XPath("//h2[contains(text(),'Manage Listings')]")));
		}

		internal void InvalidSkill()
		{
			// Click on the Share Skill button
			GlobalDefinitions.driver.FindElement(By.XPath("//section[@class='nav-secondary']//a[contains(@class,'button')][contains(text(),'Share Skill')]")).Click();

			//Populate the Excel Sheet
			GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ShareSkill");
			Thread.Sleep(1000);

			// Input C# into the Title field
			IWebElement title = GlobalDefinitions.driver.FindElement(By.Name("title"));
			title.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Title"));

			// Input [Test Fixture] into the Description field
			IWebElement description = GlobalDefinitions.driver.FindElement(By.Name("description"));
			description.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Description"));

			// Choose Category as Digital Marketing
			IWebElement category = GlobalDefinitions.driver.FindElement(By.Name("categoryId"));
			category.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Category"));

			// Choose Subcategory as Video Marketing
			IWebElement subcategory = GlobalDefinitions.driver.FindElement(By.Name("subcategoryId"));
			subcategory.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Subcategory"));

			// Input C# into the Tags field and press Enter key
			IWebElement tag = GlobalDefinitions.driver.FindElement(By.XPath("(//input[@type='text'][@placeholder='Add new tag'])[1]"));
			tag.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Tags"));
			tag.SendKeys(Keys.Enter);

			// Tick Hourly basis service option of Service Type
			GlobalDefinitions.driver.FindElement(By.XPath("//input[@name='serviceType'][@value='0']")).Click();

			// Tick Online option of Location Type
			GlobalDefinitions.driver.FindElement(By.XPath("//input[@name='locationType'][@value='1']")).Click();

			// Tick Skill-exchange option of Skill Trade
			GlobalDefinitions.driver.FindElement(By.XPath("//input[@name='skillTrades'][@value='true']")).Click();

			// Input Java into the Skill-Exchange field and press enter key
			IWebElement skillexchange = GlobalDefinitions.driver.FindElement(By.XPath("(//input[@type='text'][@placeholder='Add new tag'])[2]"));
			skillexchange.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Skill-Exchange"));
			skillexchange.SendKeys(Keys.Enter);

			// Tick Active option of Active
			GlobalDefinitions.driver.FindElement(By.XPath("//input[@name='isActive'][@value='true']")).Click();

			// Click on the Save button
			GlobalDefinitions.driver.FindElement(By.XPath("//input[@type='button'][@value='Save']")).Click();

			// Verify if add the skill successfully
			IWebElement actualtext = GlobalDefinitions.driver.FindElement(By.XPath("//div[contains(@class,'ns-type-error')]"));
			Assert.That(actualtext.Text, Is.EqualTo("Please complete the form correctly."));
		}
	}
}

