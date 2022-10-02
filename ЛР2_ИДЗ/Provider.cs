using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛР2_ИДЗ
{
    internal class Provider
    {
        public static Dictionary<Client,Tariff> TC = new Dictionary<Client,Tariff>();
        public static List<Tariff> tarifs = new List<Tariff>();
        public static List<Client> clients = new List<Client>();

        public static void Initial()
        {
            var tarif=new Tariff();
            tarif.price = 500;
            tarif.name = "GigiZaShagi";
            tarif.minutes = 200;
            tarif.gigabytes = 20;
            tarifs.Add(tarif);
            tarif = new Tariff();
            tarif.price = 300;
            tarif.name = "TarifSelect";
            tarif.minutes = 100;
            tarif.gigabytes = 5;
            tarifs.Add(tarif);

            Client client = new Client("Артем", "001");
            Client client2 = new Client("Иван", "002");
            clients.Add(client);
            clients.Add(client2);
            TC.Add(clients[0], tarifs[0]);
            TC.Add(clients[1], tarifs[1]);
        }

        public static void Oplata(Client client)
        {
            foreach (Client client2 in clients)
            {
                if (client.id == client2.id)
                {
                    foreach (var client1 in TC.Keys)
                    {
                        if (client.id == client1.id)
                        {
                            int dolg = TC[client1].price;
                            Console.WriteLine("Долг по оплате: " + dolg + "\n" +
                                "Оплатить долг?\n" +
                                "1- Да\n" +
                                "2- Нет");
                            int doIt = int.Parse(Console.ReadLine());
                            switch (doIt)
                            {
                                case 1:
                                    TC.Remove(client1);
                                    Console.WriteLine("Оплата проведена, задолжностей нет");
                                    break;
                                case 2:
                                    break;
                                default: break;
                            }
                            break;
                        }
                        else
                        {
                            Console.WriteLine("У клиента нет задолжностей");
                            break;
                        }
                    }
                    break;

                }
                else
                {
                    Console.WriteLine("Клиент не существует в базе данных провайдера!");
                    break;
                }
            }
        }

        public static void ListTarifs()
        {
            if (tarifs.Count != 0)
            {
                foreach (Tariff tariff in tarifs)
                {
                    Console.WriteLine(tariff.price + "\n" + tariff.name + "\n" + tariff.gigabytes + "\n" + tariff.minutes);
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Список тарифов пуст");
            }
        }
    }
}
