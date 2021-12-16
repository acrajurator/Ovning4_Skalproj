using System;
using System.Collections;

/*
frågor.
1. Hur fungerar stacken och heapen?
stacken är en ordnan samling i minnet där allt ligger på hög utan några hål i den. det är sist in först ut vilket 
ser till att minnnet hålls perfekt ordnat men det hindrar även att man lägger till saker som man inte har koll på när det behövs sättas in eller tas ur minnet.
Heapen är för allt som behöver sparas i minne men man kan inte hålla koll på vilken exakt ordning det kommer behövas i minnet.
Det gäller i c# reference types medans value types beror på var de deklarerades.

2. Vad är value types respektive reference types?
value types sparar ett specifikt värde medans references är stället i minnet där pointers pekar på för allt som ärver av system.object.

3.
då ReturnValue innehåller value types så är det värdet som ändras i int y.
medans i ReturnValue2 så är det en reference som sätts till en annan reference alltså pekar både y och x mot samma object 
och båda kan ändra det då de titta på samma object.
*/

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParanthesis"
                    + "\n5. Iterative Fibona"
                    + "\n6. Iterative Even"
                    + "\n7. Recursive Even"
                    + "\n8. Recursive Fibona"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    case '5':
                        Console.WriteLine("input number for Iterative Fibona");
                        Console.WriteLine(IterativeFibona(GetInt32Input()));

                        break;
                    case '6':
                        Console.WriteLine("input number for Iterative Even");
                        Console.WriteLine(IterativeEven(GetInt32Input()));

                        break;
                    case '7':
                        Console.WriteLine("input number for Recursive Even");
                        Console.WriteLine(RecursiveEven(GetInt32Input()));

                        break;
                    case '8':
                        Console.WriteLine("input number for Recursive Fibona");
                        Console.WriteLine(RecursiveFibona(GetInt32Input()));

                        break;

                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4, 5, 6 , 7, 8)");
                        break;
                }
            }
        }

        private static int GetInt32Input()
        {
            bool loop = true;
            while (loop)
            {
                string number = Console.ReadLine();
                try
                {


                    int num = Int32.Parse(number);
                    return num;
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return 0;
        }

        /*
fråga.
Vilken​​ av ovanstående ​​funktioner​​ är​​ mest ​​minnesvänlig​​ och ​​varför?(iterative vs recursive)
jag tror recursive behöver mer minne då den behöver hålla kolla på de tidigare användningarna av sig själv
*/
        private static int IterativeFibona(int n)
        {
            int first = 0, second = 1, result = 0, i;
            for (i = 0; i < n; i++)
            {
                if (i <= 1)
                    result = i;
                else
                {
                    result = first + second;
                    first = second;
                    second = result;
                }
            }
            return result;
        }
        private static int IterativeEven(int n)
        {
            if (n == 1) return 0;
            int result = -4;
            for (int i = 0; i <= n; i++)
            {
                result += 2;
            }
            return result;
        }
        private static int RecursiveEven(int n)
        {
            if (n == 1)
            {
                return 0;
            }
            return (RecursiveEven(n - 1) + 2);
        }
        private static int RecursiveFibona(int n)
        {
            if (n == 0)
            {
                return 0;
            }
            else if (n == 1)
            {
                return 1;
            }
            else
            {
                return (RecursiveFibona(n - 1) + RecursiveFibona(n - 2));
            }
        }


        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */


            /*Frågor
            2. När ökar listans kapacitet?
            När listan blir full.
            3. Med hur mycket ökar kapaciteten?
            Den dubblas
            4. Varför ökar inte listans kapacitet i samma takt som element läggs till?
            Skulle gissa att det tar tid att skapa en ny array varje gång och att den gamla 
            arrayen ligger kvar i minnet tills den rensas bort.
            5. Minsar kapaciteten när element tas bort ur listan?
            Nej det gör det inte.
            6. När är det då fördelaktigt att använda en egendefinierad array istället för
            en lista?
            Det verkar inte finnas så många fördelad med att använda arrays istället för list i c#. 
            En array tar lite mindre minne, lite snabbare på att veta sin storlek, lite snabbare på att veta om den innehåller nåt specifikt.
            En list är mycket snabbare på att sätta in/ ta ut och alla andra sätt att ändra i den. 
            Även på arrays fördelar så är list inte så långt bakom.
            



            */
            List<string> theList = new List<string>();
            bool looping = true;
            while (looping)
            {
                Console.WriteLine("Write a + before your string to write or a - to remove. 0 to Go Back");

                string input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input))
                {
                    char nav = input[0];
                    string value = input.Substring(1);




                    switch (nav)
                    {

                        case '+':
                            theList.Add(value);
                            Console.WriteLine("The count is: " + theList.Count);
                            Console.WriteLine("The capacity is: " + theList.Capacity);
                            break;
                        case '-':
                            theList.Remove(value);

                            Console.WriteLine("The count is: " + theList.Count);
                            Console.WriteLine("The capacity is: " + theList.Capacity); ;
                            break;
                        case '3':
                            theList.ForEach(Console.WriteLine);
                            break;
                        case '0':
                            looping = false;
                            break;
                        default:
                            Console.WriteLine("Please enter some valid input (0, -, +)");
                            break;

                    }
                }

            }
        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
             * 
             * 
             * 
            */
            Queue que = new Queue();
            bool looping = true;
            while (looping)
            {

                Console.WriteLine("1. add item to queue, 2 remove first element in queue. 3 print queue. 0 to Go Back");

                string input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input))
                {
                    char nav = input[0];
                    switch (nav)
                    {

                        case '1':

                            Console.WriteLine("Insert string into queue");
                            input = Console.ReadLine();
                            que.Enqueue(input);

                            Console.WriteLine("Queue count is: " + que.Count);
                            break;
                        case '2':
                            Console.WriteLine("The removed element is: " + que.Dequeue());
                            Console.WriteLine("Queue count is: " + que.Count);
                            break;
                        case '3':
                            foreach (var var in que)
                                Console.WriteLine(var);
                            break;
                        case '0':
                            looping = false;
                            break;
                        default:
                            Console.WriteLine("Please enter some valid input (0, 1, 2, 3)");
                            break;

                    }
                }

            }


        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */
            // frågor. varför är det inte så smart att använda stack för en ica-kö?
            //för att en stack tar det nyaste elementet först. så den personen som stått kortast i kö får gå först.

            bool looping = true;
            while (looping)
            {

                Console.WriteLine("1. add string to reverse, 0 to Go Back");

                string input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input))
                {
                    char nav = input[0];

                    switch (nav)
                    {

                        case '1':

                            Console.WriteLine("Insert string to be reversed");
                            input = Console.ReadLine();
                            char[] charArr = input.ToCharArray();
                            int size = charArr.Length;
                            Stack stack = new Stack(size);

                            int i;
                            for (i = 0; i < size; ++i)
                            {
                                stack.Push(charArr[i]);
                            }

                            for (i = 0; i < size; ++i)
                            {
                                charArr[i] = (char)stack.Pop();
                            }

                            Console.WriteLine(charArr);

                            break;

                        case '0':
                            looping = false;
                            break;
                        default:
                            Console.WriteLine("Please enter some valid input (0, 1)");
                            break;

                    }
                }

            }

        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

            bool looping = true;
            while (looping)
            {

                Console.WriteLine("1. add string to checked, 0 to Go Back");

                string input = Console.ReadLine();
                char nav = input[0];

                if (!string.IsNullOrEmpty(input))
                {
                    switch (nav)
                    {

                        case '1':

                            Console.WriteLine("Your string has matching brackets: " +
                            CheckParanthesisCases());
                            break;

                        case '0':
                            looping = false;
                            break;
                        default:
                            Console.WriteLine("Please enter some valid input (0, 1)");
                            break;

                    }
                }

            }

        }

        private static bool CheckParanthesisCases()
        {
            Stack<char> stackLeftside = new Stack<char>();
            Console.WriteLine("Insert string to be checked");
            String input = Console.ReadLine();
            char[] charArr = input.ToCharArray();
            for (int i = 0; i < charArr.Length; ++i)
            {
                switch (charArr[i])
                {
                    case ('('):
                    case ('['):
                    case ('{'):
                        stackLeftside.Push(charArr[i]);
                        break;
                    case (')'):
                        if (stackLeftside.Count > 0 && stackLeftside.Peek() == '(')
                            stackLeftside.Pop();
                        break;
                    case (']'):
                        if (stackLeftside.Count > 0 && stackLeftside.Peek() == '[')
                            stackLeftside.Pop();
                        break;

                    case ('}'):
                        if (stackLeftside.Count > 0 && stackLeftside.Peek() == '{')
                            stackLeftside.Pop();

                        break;
                    default:
                        break;
                }

            }
            if (stackLeftside.Count == 0)
                return true;

            return false;
        }
    }
}

