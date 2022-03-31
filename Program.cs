using System;
using System.Collections.Generic;
using ToDo_App.Models;

namespace ToDo_App
{
    class Program
    {
        public static UserList _users { get; set; }
        public static BoardLists _boards { get; set; }
        static void Main(string[] args)
        {
            _boards = new BoardLists();
            _users = new UserList();
            while (true)
            {
                HomePage();
            }
        }

        public static void HomePage()
        {
            int choice;
            Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :)");
            Console.WriteLine("*******************************************");
            Console.WriteLine("(1) Board Listelemek");// getBoard and printLine (from getBoard) methods call
            Console.WriteLine("(2) Board'a Kart Eklemek");
            Console.WriteLine("(3) Board'dan Kart Silmek");
            Console.WriteLine("(4) Kart Taşımak");
            choice = Int32.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    GetBoard();
                    break;
                case 2:
                    newBoard();
                    break;
                case 3:
                    removeBoard();
                    break;
                case 4:
                    moveBoard();
                    break;
                default:
                    Console.WriteLine("Geçersiz seçim yaptınız!");
                    break;
            }
        }
        public static void GetBoard()
        {
            Console.WriteLine("TODO Line");
            Console.WriteLine("************************");
            if (_boards.ToDo.Count > 0)
                printLines(_boards.ToDo, _users);
            else
                Console.WriteLine("~BOŞ~");

            Console.WriteLine("IN PROGRESS Line");
            Console.WriteLine("************************");

            if (_boards.InProgress.Count > 0)
                printLines(_boards.InProgress, _users);
            else
                Console.WriteLine("~BOŞ~");

            Console.WriteLine("DONE Line");
            Console.WriteLine("************************");
            if (_boards.Done.Count > 0)
                printLines(_boards.Done, _users);
            else
                Console.WriteLine("~BOŞ~");
        }
        public static void newBoard()
        {
            Console.WriteLine("Başlık Giriniz                                  :");
            string _title = Console.ReadLine();
            Console.WriteLine("İçerik Giriniz                                  :");
            string _content = Console.ReadLine();
            int _size = Convert.ToInt16(NumberControl("Büyüklük Seçiniz -> XS(1),S(2),M(3),L(4),XL(5)  :"));
        tekrar:
            int _userId = Convert.ToInt16(NumberControl("Kişi Seçiniz (1-5 arası bir rakam)              :"));
            if ((_userId) > 0 && (_userId < 6))
                _boards.ToDo.Add(new BoardModel(_title, _content, _userId, _size));
            else
            {
                Console.WriteLine("Girilen numara yanlış, Lütfen 1 ile 5 arasında bir rakam giriniz");
                goto tekrar;
            }
        }

        public static void removeBoard()
        {
            string _title;
            Console.WriteLine("Öncelikle silmek istediğiniz kartı seçmeniz gerekiyor.");
            Console.WriteLine("Lütfen kart başlığını yazınız:");
            _title = Console.ReadLine();

            int todo, inProgress, done;
            todo = _boards.ToDo.FindIndex(x => x.Title.ToLower() == _title.ToLower());
            inProgress = _boards.InProgress.FindIndex(x => x.Title.ToLower() == _title.ToLower());
            done = _boards.Done.FindIndex(x => x.Title.ToLower() == _title.ToLower());

            if (todo >= 0)
                _boards.ToDo.RemoveAt(todo);
            else if (inProgress >= 0)
                _boards.InProgress.RemoveAt(inProgress);
            else if (done >= 0)
                _boards.Done.RemoveAt(done);
            else
            {
                Console.WriteLine("Aradığınız kart bulunamadı.");
                HomePage();
            }
            Console.WriteLine("İşlem başarılı bir şekilde tamamlandı.");
        }

        public static void moveBoard()
        {
            string _title, _line = String.Empty;
            BoardModel _board = new BoardModel(null, null, -1, -1);

            Console.WriteLine("Öncelikle taşımak istediğiniz kartı seçmeniz gerekiyor.");
            Console.WriteLine("Lütfen kart başlığını yazınız:");
            _title = Console.ReadLine();

            int todo, inProgress, done;
            todo = _boards.ToDo.FindIndex(x => x.Title.ToLower() == _title.ToLower());
            inProgress = _boards.InProgress.FindIndex(x => x.Title.ToLower() == _title.ToLower());
            done = _boards.Done.FindIndex(x => x.Title.ToLower() == _title.ToLower());

            if (todo >= 0)
            {
                _board = _boards.ToDo[todo];
            }
            else if (inProgress >= 0)
            {
                _board = _boards.ToDo[inProgress];
            }
            else if (done >= 0)
            {
                _board = _boards.ToDo[done];
            }
            else
            {
                Console.WriteLine("Aradığınız krtiterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.");
                Console.WriteLine("* İşlemi sonlandırmak için : (1)");
                Console.WriteLine("* Yeniden denemek için : (2)");
                int _choice = Int32.Parse(Console.ReadLine());

                if (_choice == 1)
                    HomePage();
                else if (_choice == 2)
                    moveBoard();
                else
                {
                    Console.WriteLine("Geçersiz işlem seçtiniz. İşlem sonlandırılıyor.");
                    HomePage();
                }
            }

            if (_board.Title != null)
            {
                Console.WriteLine("Bulunan Kart Bilgileri:");
                Console.WriteLine("**************************************");
                Console.WriteLine("Başlık      : {0}", _board.Title);
                Console.WriteLine("İçerik      : {0}", _board.Content);
                Console.WriteLine("Atanan Kişi : {0}", _users.users.Find(x => x.Id == _board.UserId).FullName);
                Console.WriteLine("Büyüklük    : {0}", ((BoardSizeEnumModel)_board.Size).ToString());
                Console.WriteLine("Line        : {0}", _line);

                Console.WriteLine("Lütfen taşımak istediğiniz Line'ı seçiniz:");
                Console.WriteLine("(1) TODO");
                Console.WriteLine("(2) IN PROGRESS");
                Console.WriteLine("(3) DONE");
                int _choice1 = Int32.Parse(Console.ReadLine());

                if (_choice1 == 1)
                {
                    _boards.ToDo.Add(_board);
                }
                else if (_choice1 == 2)
                {
                    _boards.InProgress.Add(_board);
                }
                else if (_choice1 == 3)
                {

                    _boards.Done.Add(_board);
                }
                else
                {
                    Console.WriteLine("Geçersiz işlem seçtiniz. İşlem sonlandırılıyor.");
                    HomePage();
                }
                if (todo >= 0)
                {
                    _boards.ToDo.RemoveAt(_boards.ToDo.FindIndex(x => x.Title.ToLower() == _title.ToLower()));
                }
                else if (inProgress >= 0)
                {
                    _boards.InProgress.RemoveAt(_boards.ToDo.FindIndex(x => x.Title.ToLower() == _title.ToLower()));
                }
                else if (done >= 0)
                {
                    _boards.Done.RemoveAt(_boards.ToDo.FindIndex(x => x.Title.ToLower() == _title.ToLower()));
                }
                GetBoard();
            }

        }

        public static void printLines(List<BoardModel> col, UserList users)
        {
            foreach (var item in col)
            {
                Console.WriteLine("Başlık      : {0}", item.Title);
                Console.WriteLine("İçerik      : {0}", item.Content);
                Console.WriteLine("Atanan Kişi : {0}", users.users.Find(x => x.Id == item.UserId).FullName);
                Console.WriteLine("Büyüklük    : {0}", ((BoardSizeEnumModel)item.Size).ToString());
                Console.WriteLine("-");
            }
        }
        public static string NumberControl(string text)
        {
        tekrar:
            Console.Write(text);
            string str = Console.ReadLine();
            string numbers = "0123456789";
            foreach (char item in str)
            {
                if (!numbers.Contains(item))
                {
                    Console.WriteLine("Hatalı Numara Girdiniz Tekrar Deneyiniz.");
                    goto tekrar;
                }
            }
            return str;
        }
    }
}
