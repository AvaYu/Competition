using MarsFramework.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
			public void SaveValidService()
			{
				// Creates a toggle for the given test, adds all log events under it    
				test = extent.StartTest("Save a valid service");

				// ShareSkill object and save a valid service
				ShareSkill obj = new ShareSkill();
				obj.ValidSkill();
			}

			[Test]
			public void SaveInvalidService()
			{
				// Creates a toggle for the given test, adds all log events under it    
				test = extent.StartTest("Save an invalid service");

				// ShareSkill object and save an invalid service
				ShareSkill obj = new ShareSkill();
				obj.InvalidSkill();			
			}

			[Test]
			public void DeleteLastService()
			{
				// Creates a toggle for the given test, adds all log events under it    
				test = extent.StartTest("Delete the last service");

				// ManageListings object and delete the last service of the last page
				ManageListings obj = new ManageListings();
				obj.DeleteSkill();
			}
		}
	}
}