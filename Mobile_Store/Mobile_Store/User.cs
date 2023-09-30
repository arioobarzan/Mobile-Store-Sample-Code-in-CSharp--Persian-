using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mobile_Store
{
  partial   class User
    {
      public User(string username,string password,string type):this()
      {
          this.UserName = username;
          this.Password = password;
          this.Type = type;
      }

      public User() { }
      public override string ToString()
      {
          return UserName+"";
      }
    }
}
