using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛР2_ИДЗ
{
    class Programm
    {
        static void Main(string[] args)
        {

            Provider.Initial();
            Console.WriteLine("Провайдер готов к работе");
            Console.Write("Как к вам обращаться? ");
            string fio = Console.ReadLine();
            Console.Write(fio + ", Введите id клиента ");
            string id = Console.ReadLine();
            Client client=new Client(fio, id);
            Console.WriteLine("Уважаемый " + client.fio + ", выберите действие\n" +
                "1-Вывод списка тарифов\n" +
                "2-Проверить задолжности\n" +
                "0-Выход");
            int doIt = int.MaxValue;
            while (doIt > 0)
            {
                Console.Write("Ваш выбор: ");
                doIt = int.Parse(Console.ReadLine());
                switch (doIt)
                {
                    case 1:
                        Provider.ListTarifs();
                        break;
                    case 2:
                        Provider.Oplata(client);
                        break;
                    case 0:
                        doIt = 0;
                        break;
                    default: break;

                }
            }
            Console.ReadLine();
        }
    }
}