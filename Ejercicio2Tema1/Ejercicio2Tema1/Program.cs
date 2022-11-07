namespace Program
{
    public delegate void MyDelegate();
    class Program
    {
        public static bool MenuGenerator(string[] menuOptions, MyDelegate[] Operations)
        {
            int ChooseOption = 0;
            bool menu = true;
            if (menuOptions == null || Operations == null)
            {
                Console.WriteLine("If the options or the operations are null the menu can´t be created");
                return false;
            }
            if (menuOptions.Length != Operations.Length)
            {
                Console.WriteLine("The menu need to have the same amount of options and operations or it cannot be created");
                return false;
            }
            else
            {  
                do
                {
                    try
                    {
                        Console.WriteLine("Choose one of the following options:\n");
                        for (int i = 0; i < menuOptions.Length; i++)
                        {
                            Console.WriteLine("{0}-) {1}\n", i + 1, menuOptions[i]);
                        }
                        Console.WriteLine($"{menuOptions.Length + 1}-) Exit");
                        ChooseOption = Convert.ToInt32(Console.ReadLine());
                        if (ChooseOption < 0 || ChooseOption > menuOptions.Length + 1)
                        {
                            Console.WriteLine("Error, the option must be one of the mentioned");
                        }
                        else if (ChooseOption <= menuOptions.Length && ChooseOption > 0)
                        {
                            Operations[ChooseOption - 1].Invoke();
                        }
                    }
                    catch (FormatException)
                    {
                        Console.Clear();
                        Console.WriteLine("There was an unexpected error while creating the menu");
                    }

                } while (ChooseOption != menuOptions.Length + 1);
                return menu;
            }
        }
        static void f1()
        {
            //Console.WriteLine("A");
        }
        static void f2()
        {
            //Console.WriteLine("B");
        }
        static void f3()
        {
            //Console.WriteLine("C");
        }
        static void f4()
        {
            //Console.WriteLine("D");
        }
        static void Main(string[] args)
        {
            //
            MenuGenerator(new string[] { "Op1", "Op2", "Op3", "Op4" },
            new MyDelegate[] { () => Console.WriteLine("DragonQuest"), () => Console.WriteLine("Pokemon"), () => Console.WriteLine("FinalFantasy"), () => Console.WriteLine("DQMJ2") });
            Console.WriteLine("GoodBye");
            Console.ReadKey();
        }

    }
}