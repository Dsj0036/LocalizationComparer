using System.Diagnostics;
using System;
using Console = System.ExConsole;
using Tweaker.Workers;
namespace Program
{
    public class Program
    {
        static string file = null;
       static LanguagesParser parser;
        static LanguagesContainer retail_container = null;
        static void Title()
        {
            Console.Write("Localization Comparer\n", ConsoleColor.Green);
            Console.Write("Created By Destructorrpy.\n", ConsoleColor.Green);
        }

        static string GetStartupPath() => Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

        static void Main(string[] args = null)
        {
            Title();
            string retail = GetStartupPath() + "\\retail.loc";

            if (File.Exists(retail))
            {
                parser = new LanguagesParser();
                retail_container = parser.Parse(File.ReadAllBytes(retail), (int a, int b) => {

                    Console.Write(string.Format("Loading: {0}/{1}\n", a, b));
                });
                Console.Clear();
                Title();

                if (args != null)
                {
                    if (args.Length > 0)
                    {
                        if (File.Exists(args[0]) && args[0].EndsWith(".loc"))
                        {
                            file = args[0];

                        }
                        else
                        {
                            Console.Write("Please open a working file you idiot.\n", ConsoleColor.Red);
                        }
                    }


                }
                if (file == null)
                {
                    Console.Write("[A] Open file\n", ConsoleColor.Yellow);
                    Console.Write("[S] Exit cancel\n", ConsoleColor.Yellow);
                    var r = System.Console.ReadKey();
                    if (r.KeyChar == 'a' || r.KeyChar == 'A')
                    {
                        Console.Clear();
                        file ??= OFD.Request("Localization Files (*.loc)\0*.loc\0");
                    }
                }
                if (File.Exists(file))
                {
                    LanguagesContainer active = null;
                    new Thread(() =>
                    {
                        int lines = 0;
                        byte[] data = File.ReadAllBytes(file);
                        
                        active = parser.Parse(data, (int a, int b) =>
                        {
                            Console.Write(string.Format("Loading: {0}/{1}\n", a, b));
                            if (++lines > 10)
                            {
                                Console.Clear();
                                lines = 0;
                            }
                        });

                        Console.Clear();
                        Console.Write("Select language to compare changes.\n");
                        int select = 0;
                        foreach (var line in active.Languages)
                        {
                            Console.Write(string.Format("[{0}] {1}\n", select, line.Key));
                            select++;
                        }
                        Console.Write("Valid [0/" + select + "]\n");
                        string f = Console.ReadLine();
                        if (int.TryParse(f, out int index))
                        {
                            var lang = active.Languages.ToArray()[index];
                            var baselang = retail_container.Languages.ToArray()[index];
                            Console.Clear();
                            var messages = lang.Value.Messages;
                            var basemsg = baselang.Value.Messages;
                            int count = messages.Count & basemsg.Count;

                            int differences = 0;
                            List<int> indexes = new List<int>();
                            for (int i = 0; i < count; i++)
                            {
                                if (basemsg[i].Message != messages[i].Message)
                                {
                                    differences++;
                                    indexes.Add(i);
                                }
                            }
                            Console.Clear();
                            if (differences > 0)
                            {
                                for (int i = 0; i < (differences); i++)
                                {
                                    int id = indexes[i];
                                    string msg = basemsg[id].Message;
                                    string newmsg = messages[id].Message;

                                    Console.Write("("+id+")", ConsoleColor.Gray);
                                    Console.Write(msg.Length > 30 ? msg[..30] + "..." : msg, ConsoleColor.DarkGray);
                                    Console.Write(" /// ", ConsoleColor.White);
                                    Console.Write(newmsg.Length > 30 ? newmsg[..30] + "..." : newmsg, ConsoleColor.White);
                                    Console.Write("\n");

                                }


                            }

                            Console.Write(string.Format("{0} differences. \n", differences), ConsoleColor.Yellow);
                            Console.Write("Press any key to continue.\n");
                            Console.ReadLine();
                            file = null;
                            Main();
                        }
                        else
                        {
                            file = null;
                            Main();
                        }


                    }).Start();
                    Title();
                }

            }
            else
            {
                Console.Write("Cannot start. No default local to compare.", ConsoleColor.Red);
                Console.Write("Please put an 'retail.loc' at StartupPath for continuing.\n",ConsoleColor.Red);
                Console.ReadLine();
            }

        }
    }
}
