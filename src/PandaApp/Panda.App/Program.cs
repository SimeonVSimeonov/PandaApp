﻿using SIS.MvcFramework;

namespace Panda.App
{
    public static class Program
    {
        public static void Main()
        {
            WebHost.Start(new Startup());
        }
    }
}
