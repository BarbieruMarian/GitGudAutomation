﻿using TestingAutomation.Driver;

namespace TestingAutomation.Settings
{
    public class TestSettings
    {
        public BrowserType BrowserType { get; set; }
        public Uri? ApplicationUrl { get; set; }
        public int TimeoutInterval { get; set; }
    }
}