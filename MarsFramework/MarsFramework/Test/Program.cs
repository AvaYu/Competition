using MarsFramework.Global;
using MarsFramework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarsFramework
{
	public class Program
	{
		[TestFixture]
		[Category("Sprint1")]
		class Tenant : Global.Base
		{
			[Test]
			public void UserAccount()
			{
				// Creates a toggle for the given test, adds all log events under it    
				test = extent.StartTest("Search for a Property");

				// Create a class and object to call the method
				Profile obj = new Profile();
				obj.EditProfile();
			}

			[Test]
			public void SaveValidSkill()
			{
				// Creates a toggle for the given test, adds all log events under it    
				test = extent.StartTest("Save a valid skill");

				// ShareSkill object and save a valid skill
				ShareSkill obj = new ShareSkill();
				obj.SaveValidSkill();

				// Verify if add the skill successfully and navigate to ListingManagement
				Assert.IsNotNull(GlobalDefinitions.driver.FindElement(By.XPath("//h2[contains(text(),'Manage Listings')]")));
			}

			[Test]
			public void SaveInvalidSkill()
			{
				// Creates a toggle for the given test, adds all log events under it    
				test = extent.StartTest("Save an invalid skill");

				// ShareSkill object and save an invalid skill
				ShareSkill obj = new ShareSkill();
				obj.SaveInvalidSkill();

				// Verify if add the skill successfully
				IWebElement actualtext = GlobalDefinitions.driver.FindElement(By.XPath("//div[contains(@class,'ns-type-error')]"));
				Assert.That(actualtext.Text, Is.EqualTo("Please complete the form correctly."));
			}

			[Test]
			public void DeleteLastSkill()
			{
				// Creates a toggle for the given test, adds all log events under it    
				test = extent.StartTest("Delete the last skill page");

				// ManageListings object and delete all of the skill listings on the last page
				ManageListings obj = new ManageListings();
				obj.DeleteLastPage();
			}
		}
	}
}