using System;
using System.IO.Ports;
using Project;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Threading;

namespace conti
{
    class Program
    {
        static SerialPort _serialPort;
        static Data _data;
        public static void Main()
        {
            _data = new Data(); //Set my connection to database

            List<ModulPrincipal> parts = new List<ModulPrincipal>();

            _serialPort = new SerialPort();
            _serialPort.PortName = "COM3"; // Set your board COM
            _serialPort.BaudRate = 9600;
            _serialPort.Open();


            ModulPrincipal modulPrincipal = new ModulPrincipal();

            while (_serialPort.IsOpen)
            {
                _serialPort.WriteLine("1");
                string a = _serialPort.ReadExisting();
                string[] numbers = Regex.Split(a, @"\D+");
                Console.WriteLine("Realizam modulul cu datele");

                int contor = 0;
                foreach (string value in numbers)
                {
                    if (!string.IsNullOrEmpty(value))
                    {
                        int i = int.Parse(value);
                        if (contor == 0)
                        {
                            modulPrincipal.setCodModul(i);
                            contor++;
                        }
                        else if (contor == 1)
                        {
                            modulPrincipal.setLotCondensatoare(i);
                            contor++;
                        }
                        else if (contor == 2)
                        {
                            modulPrincipal.setLotRezistente(i);
                            contor++;
                        }
                        else
                        {
                            contor = 0;
                        }
                        Console.WriteLine(i);
                    }
                }
                if (!_data.search(modulPrincipal))
                {
                    Console.WriteLine("S-a gasit o inregistrare la fel!");
                    parts.Add(modulPrincipal);
                }
                else
                {
                    _data.insert(modulPrincipal);
                    Console.WriteLine("Datele au fost inregistrate!");
                }

                if (parts.Count % 10 == 0)
                {
                    parts.ToString();
                    parts.Clear();
                }
                Thread.Sleep(2500);
            }

          
            
            //Thread.Sleep(1500);
            //contor++;

            /* while (_serialPort.IsOpen)
             {
                 _serialPort.WriteLine("1");

                 if (a == _serialPort.ReadExisting())
                 {
                          continue;
                 }

                 a = _serialPort.ReadExisting();
                 Console.WriteLine(a);

                 string[] numbers = Regex.Split(a, @"\D+");

                 int numarGasit = 0;
                 if (a != "")
                 {
                      modulPrincipal = new ModulPrincipal();
                 }

                 foreach (string value in numbers)
                 {
                     if (!string.IsNullOrEmpty(value))
                     {
                         int i = int.Parse(value);
                         if (numarGasit == 0)
                         {
                             modulPrincipal.setCodModul(i);
                             numarGasit++;
                         }
                         else if (numarGasit == 1)
                         {
                             modulPrincipal.setLotRezistente(i);
                             numarGasit++;
                         }
                         else if (numarGasit == 2)
                         {
                             numarGasit++;
                             modulPrincipal.setLotCondensatoare(i);
                         }
                         if (i == 9999)
                         {
                             numarGasit = 0;
                         }
                     }
                 }

                 if (!_data.search(modulPrincipal) && a!="")
                 {
                     Console.WriteLine("S-a gasit o inregistrare la fel!");
                     Console.WriteLine(modulPrincipal.ToString());
                     parts.Add(modulPrincipal);
                 }
                 else if(a!="")
                 {
                     _data.insert(modulPrincipal);
                     Console.WriteLine("Datele au fost inregistrate!");
                 }

                 if (parts.Count % 20 == 0)
                 {
                     parts.ToString();
                     parts.Clear();
                 }
             }*/
        }
    }
}