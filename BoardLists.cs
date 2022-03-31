using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo_App.Models
{
    class BoardLists
    {
        public List<BoardModel> ToDo = new List<BoardModel>();
        public List<BoardModel> InProgress = new List<BoardModel>();
        public List<BoardModel> Done = new List<BoardModel>();

        public BoardLists()
        {
            ToDo.Add(new BoardModel("C#", "C# hakkında bilgiler", 1, ((int)BoardSizeEnumModel.M)));
            InProgress.Add(new BoardModel("Asp.Net ", "Asp.Net hakkında bilgiler", 1, ((int)BoardSizeEnumModel.S)));
            Done.Add(new BoardModel("C# OOP ", "C# OOP hakkında bilgiler", 1, ((int)BoardSizeEnumModel.S)));
        }

        internal object GetProperty(string line)
        {
            throw new NotImplementedException();
        }
    }
}
