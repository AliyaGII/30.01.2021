using System;

namespace _30._01._2021
{
    class DocumentWorker
    {
        public virtual void OpenDocument()
        {
            Console.WriteLine("Документ открыт");
        }

        public virtual void EditDocument()
        {
            Console.WriteLine("Редактирование документа доступно в версии Про");
        }

        public virtual void SaveDocument()
        {
            Console.WriteLine("Сохранение документа доступно в версии Про");
        }
    }
    class ProDocumentWorker : DocumentWorker
    {
        public override void EditDocument()
        {
            Console.WriteLine("Документ отредактирован");
        }

        public override void SaveDocument()
        {
            Console.WriteLine("Документ сохранен в старом формате, сохранение в остальных форматах доступно в версии Эксперт");
        }
    }
    class ExpertDocumentWorker : ProDocumentWorker
    {
        public override void SaveDocument()
        {
            Console.WriteLine("Документ сохранен в новом формате");
        }
    }

    public interface IPlayable
    {
        public void Play();
        public void Pause();
        public void Stop();
    }
    public interface IRecordable
    {
        public void Record();
        public void Pause();
        public void Stop();
    }
    class Player : IPlayable, IRecordable
    {
        void IPlayable.Play()
        {
            Console.WriteLine("Проигрывается");
        }

        void IPlayable.Pause()
        {
            Console.WriteLine("На паузе");
        }

        void IPlayable.Stop()
        {
            Console.WriteLine("Остановленно");
        }

        void IRecordable.Record()
        {
            Console.WriteLine("Записывает");
        }

        void IRecordable.Pause()
        {
            Console.WriteLine("Запись на паузе");
        }

        void IRecordable.Stop()
        {
            Console.WriteLine("Запись остановлена");
        }

    }




    class Program
    {
        static void Main(string[] args)
        {
            const string proKey = "pro";
            const string expKey = "exp";
            Console.WriteLine("Введите ключ");
            string key = Console.ReadLine();
            DocumentWorker document = new DocumentWorker();

            switch (key)
            {
                case proKey:
                    document = new ProDocumentWorker();
                    break;
                case expKey:
                    document = new ExpertDocumentWorker();
                    break;
                default:
                    document = new DocumentWorker();
                    break;
            }
            Console.WriteLine("Введите команды для работы с документом: \n1-Открыть документ, \n2-Редактировать документ, \n3-Сохранить, \n4-выход");
            bool A = true;

            while (A == true)
            {
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.ForegroundColor = ConsoleColor.DarkMagenta; document.OpenDocument(); Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case "2":
                        Console.ForegroundColor = ConsoleColor.DarkMagenta; document.EditDocument(); Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case "3":
                        Console.ForegroundColor = ConsoleColor.DarkMagenta; document.SaveDocument(); Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case "4":
                        A = false; Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Выход"); Console.ForegroundColor = ConsoleColor.White;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Неправильная команда!"); Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
            }


            IPlayable player = new Player();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            player.Play();
            player.Pause();
            player.Stop();
            Console.WriteLine();
            IRecordable recorder = new Player();
            Console.ForegroundColor = ConsoleColor.Cyan;
            recorder.Record();
            recorder.Pause();
            recorder.Stop();
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }
    }
}
        
          
           
