using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.StructurePatterns.FluentBuilder
{
    public class User
    {
        public string Name { get; set; }
        public string Company { get; set; }
        public int Age { get; set; }
        public bool IsMarried { get; set; }

        public static UserBuilder CreateBuilder()
        {
            return new UserBuilder();
        }
    }

    public class UserBuilder
    { 
        private User user;
        public UserBuilder()
        {
            user = new User();
        }
        public UserBuilder SetName(string name)
        {
            user.Name = name;
            return this;
        }
        public UserBuilder SetAge(int age)
        {
            user.Age = age > 0 ? age : 0;
            return this;
        }
        public UserBuilder IsMarried
        {
            get
            {
                user.IsMarried = true;
                return this;
            }
        }
        public static implicit operator User(UserBuilder builder)
        {
            return builder.user;
        }
    }
}
