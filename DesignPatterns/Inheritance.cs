using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Relations.Inheritance
{
    class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    class Manager : User
    {
        public string Company { get; set; }
    }
}
