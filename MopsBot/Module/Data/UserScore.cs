﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;
using System.Threading.Tasks;

namespace MopsBot.Module.Data
{
    class UserScore
    {
        public List<User.User> users = new List<User.User>();

        public UserScore()
        {
            StreamReader read = new StreamReader("data//scores.txt");

            string fs = "";
            while ((fs = read.ReadLine()) != null)
            {
                string[] s = fs.Split(':');
                users.Add(new User.User(ulong.Parse(s[0]),int.Parse(s[1]), int.Parse(s[2])));
            }
            read.Close();
        }

        public void writeScore()
        {
            users = users.OrderByDescending(u => u.Score).ToList();

            StreamWriter write = new StreamWriter("data//scores.txt");

            foreach (User.User that in users)
            {
                write.WriteLine($"{that.ID}:{that.Score}:{that.Experience}");
            }
            write.Close();
        }
    }
}
