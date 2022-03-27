using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Task50
{
    public class EmployeeInfo
    {
        public string Name { get; set; }

        public string Position { get; set; }

        public string Office { get; set; }

        public EmployeeInfo(string name, string position, string office)
        {
            Name = name;
            Position = position;
            Office = office;
        }
    }
}
