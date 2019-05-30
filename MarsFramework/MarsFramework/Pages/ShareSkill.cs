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

		// Find Share Skill button on Home page
		[FindsBy(How = How.XPath, Using = "//section[@class='nav-secondary']//a[contains(@class,'button')][contains(text(),'Share Skill')]")]
		private IWebElement Shareskill { get; set; }

		// Find the Title field on Share Skill page
		[FindsBy(How = How.Name, Using = "title")]
		private IWebElement Title { get; set; }

		// Find the the Description field on Share Skill page
		[FindsBy(How = How.Name, Using = "description")]
		private IWebElement Description { get; set; }

		// Find the Category on Share Skill page
		[FindsBy(How = How.Name, Using = "categoryId")]
		private IWebElement Category { get; set; }

		// Find the Subcategory on Share Skill page
		[FindsBy(How = How.Name, Using = "subcategoryId")]
		private IWebElement Subcategory { get; set; }

		// Find the Tags field on Share Skill page
		[FindsBy(How = How.XPath, Using = "(//input[@type='text'][@placeholder='Add new tag'])[1]")]
		private IWebElement Tags { get; set; }

		// Find the Service Type field and tick One-off service option
		[FindsBy(How = How.XPath, Using = "//input[@name='serviceType'][@value='1']")]
		private IWebElement ServiceType { get; set; }

		// Find the Location Type field and tick On-site option
		[FindsBy(How = How.XPath, Using = "//input[@name='locationType'][@value='0']")]
		private IWebElement LocationType { get; set; }

		// Find the Start date of Available days field
		[FindsBy(How = How.XPath, Using = "//input[@placeholder='Start date']")]
		private IWebElement Startdate { get; set; }

		// Find the End date of Available days field
		[FindsBy(How = How.XPath, Using = "//input[@placeholder='End date']")]
		private IWebElement Enddate { get; set; }

		// Find the Save button
		[FindsBy(How = How.XPath, Using = "//input[@type='button'][@value='Save']")]
		private IWebElement Save { get; set; }

		// Find the Skill Trade field
		[FindsBy(How = How.XPath, Using = "//input[@name='skillTrades'][@value='false']")]
		private IWebElement SkillTrade { get; set; }

		// Find the Credit field
		[FindsBy(How = How.Name, Using = "charge")]
		private IWebElement Credit { get; set; }

		// Find the Active field
		[FindsBy(How = How.XPath, Using = "//input[@name='isActive'][@value='false']")]
		private IWebElement Active { get; set; }

		internal void AddNewSkill(string title, string description, string category, string subcategory, string tags, string credit)
		{
			// Click on the Share Skill button on Home page
			Shareskill.Click();
			Thread.Sleep(1000);

			// Wait for fields to load
			Thread.Sleep(1000);

			// Input information into the Title field
			Title.SendKeys(title);

			// Input information into the Description field
			Description.SendKeys(description);

			// Choose Category
			Category.SendKeys(category);

			// Choose Subcategory
			Subcategory.SendKeys(subcategory);

			// Input information into the Tags field and press Enter key
			Tags.SendKeys(tags);
			Tags.SendKeys(Keys.Enter);

			// Tick One-off service option of Service Type
			ServiceType.Click();

			// Tick On-site option of Location Type
			LocationType.Click();

			// Set Start date and End date of Available days
			Startdate.SendKeys("01-06-2019");
			Enddate.SendKeys("30-06-2019");

			// Tick all weekdays, set Start time as 9:00 and End time as 17:00

			for (int i = 1; i <= 5; i++)
			{
				GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='fields']//input[@name='Available'][@index='" + i + "']")).Click();
				GlobalDefinitions.driver.FindElement(By.XPath("//input[@name='StartTime'][@index='" + i + "']")).SendKeys("0900");
				GlobalDefinitions.driver.FindElement(By.XPath("//input[@name='EndTime'][@index='" + i + "']")).SendKeys("1700");
			}

			// Tick Credit option of Skill Trade
			SkillTrade.Click();

			// Input number into price field
			Credit.SendKeys(credit);

			// Tick Hidden option of Active
			Active.Click();

			// Click on the Save button
			Save.Click();
			Thread.Sleep(500);
		}

		internal void SaveValidSkill()
		{
			// Populate the Excel Sheet
			GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ShareSkill");

			AddNewSkill(
				GlobalDefinitions.ExcelLib.ReadData(2, "Title"),
				GlobalDefinitions.ExcelLib.ReadData(2, "Description"),
				GlobalDefinitions.ExcelLib.ReadData(2, "Category"),
				GlobalDefinitions.ExcelLib.ReadData(2, "Subcategory"),
				GlobalDefinitions.ExcelLib.ReadData(2, "Tags"),
				GlobalDefinitions.ExcelLib.ReadData(2, "Credit"));
		}

		internal void SaveInvalidSkill()
		{
			// Populate the Excel Sheet
			GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ShareSkill");

			AddNewSkill(
				GlobalDefinitions.ExcelLib.ReadData(3, "Title"),
				GlobalDefinitions.ExcelLib.ReadData(3, "Description"),
				GlobalDefinitions.ExcelLib.ReadData(3, "Category"),
				GlobalDefinitions.ExcelLib.ReadData(3, "Subcategory"),
				GlobalDefinitions.ExcelLib.ReadData(3, "Tags"),
				GlobalDefinitions.ExcelLib.ReadData(3, "Credit"));
		}
	}
}

