using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo_App.Models
{
    class BoardModel
    {
        public string Title;
        public string Content;
        public int UserId;
        public int Size;
        public BoardModel(string title, string content, int userId, int size)
        {
            Title = title;
            Content = content;
            UserId = userId;
            Size = size;
        }
    }
}
