using System;
using System.Collections.Generic;

namespace IQCManagementSystem.Model
{
    public static class UserData
    {
        public static string usercode { get; set; }
        public static string username { get; set; }
        public static string factory { get; set; }
        public static bool isadmin { get; set; }
        public static List<string> role_permision { get; set; }
    }
}
