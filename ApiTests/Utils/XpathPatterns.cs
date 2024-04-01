﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Utils
{
    static class XpathPatterns
    {
        public static readonly string preciseTextXpath = "//*[text()='{0}']";
        public static readonly string typeText = "//input[@type='text']";
    }
}
