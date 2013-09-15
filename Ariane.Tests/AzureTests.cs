﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Ariane.Tests
{
	[TestFixture]
	public class AzureTests
	{
		[Test]
		public void Send_Person()
		{
			var bus = new BusManager(); 
			bus.Register.AddAzureWriter("test.azure");

			var person = new Person();
			person.FirsName = Guid.NewGuid().ToString();
			person.LastName = Guid.NewGuid().ToString();

			bus.Send("test.azure", person);

			System.Threading.Thread.Sleep(5 * 1000);
		}

		[Test]
		public void Receive_Person()
		{
			var bus = new BusManager();
			bus.Register.AddAzureReader("test.azure", typeof(PersonMessageReader));

			bus.StartReading();

			System.Threading.Thread.Sleep(5 * 1000);


		}
	}
}