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

		private static void AddNewSkill(string title, string description, string category, string subcategory, string tags, string credit)
		{
			// Click on the Share Skill button
			GlobalDefinitions.driver.FindElement(By.XPath("//section[@class='nav-secondary']//a[contains(@class,'button')][contains(text(),'Share Skill')]")).Click();

			// Wait for fields to load
			Thread.Sleep(1000);

			// Input information into the Title field
			GlobalDefinitions.driver.FindElement(By.Name("title")).SendKeys(title);

			// Input information into the Description field
			GlobalDefinitions.driver.FindElement(By.Name("description")).SendKeys(description);

			// Choose Category
			GlobalDefinitions.driver.FindElement(By.Name("categoryId")).SendKeys(category);

			// Choose Subcategory
			GlobalDefinitions.driver.FindElement(By.Name("subcategoryId")).SendKeys(subcategory);

			// Input information into the Tags field and press Enter key
			IWebElement tag = GlobalDefinitions.driver.FindElement(By.XPath("(//input[@type='text'][@placeholder='Add new tag'])[1]"));
			tag.SendKeys(tags);
			tag.SendKeys(Keys.Enter);

			// Tick One-off service option of Service Type
			GlobalDefinitions.driver.FindElement(By.XPath("//input[@name='serviceType'][@value='1']")).Click();

			// Tick On-site option of Location Type
			GlobalDefinitions.driver.FindElement(By.XPath("//input[@name='locationType'][@value='0']")).Click();

			// Set Start date and End date of Available days
			GlobalDefinitions.driver.FindElement(By.XPath("//input[@placeholder='Start date']")).SendKeys("01-06-2019");
			GlobalDefinitions.driver.FindElement(By.XPath("//input[@placeholder='End date']")).SendKeys("30-06-2019");

			// Tick all weekdays and choose Start time and End time of Available days

			for (int i = 1; i <= 5; i++)
			{
				GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='fields']//input[@name='Available'][@index='" + i + "']")).Click();
				GlobalDefinitions.driver.FindElement(By.XPath("//input[@name='StartTime'][@index='" + i + "']")).SendKeys("0900");
				GlobalDefinitions.driver.FindElement(By.XPath("//input[@name='EndTime'][@index='" + i + "']")).SendKeys("1700");
			}

			// Tick Credit option of Skill Trade
			GlobalDefinitions.driver.FindElement(By.XPath("//input[@name='skillTrades'][@value='false']")).Click();

			// Input number into price field
			IWebElement creditprice = GlobalDefinitions.driver.FindElement(By.Name("charge"));
			creditprice.SendKeys(credit);

			// Tick Hidden option of Active
			GlobalDefinitions.driver.FindElement(By.XPath("//input[@name='isActive'][@value='false']")).Click();

			// Click on the Save button
			GlobalDefinitions.driver.FindElement(By.XPath("//input[@type='button'][@value='Save']")).Click();

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

