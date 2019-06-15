using System;

namespace Tribools
{
    class Program
    {
        static Tribool trueT = Tribool.True;
        static Tribool falseT = Tribool.False;
        static Tribool indefinitely = Tribool.Indefinitely;

        static void Main(string[] args)
        {
            var tribool = Tribool.True;
            var indefinitelyTribool = Tribool.Indefinitely;
            Tribool trueTribool = true;
            Tribool falseTribool = false;

            Console.WriteLine(indefinitelyTribool);
            Console.WriteLine(trueTribool);
            Console.WriteLine(falseTribool);

            if (tribool)
                Console.WriteLine("Is true\n");
            else if (!tribool)
                Console.WriteLine("Is false\n");
            else
                Console.WriteLine("Is indefinitely\n");

            Console.WriteLine(tribool.ToString());

            Console.WriteLine("\nEqual? " + (tribool == Tribool.False));

            Console.WriteLine("True && Ident - " + (tribool && Tribool.Indefinitely));

            Console.WriteLine("--val - " + --tribool);

            Console.WriteLine("\nTrue - " + trueT);
            Console.WriteLine("False - " + falseT);
            Console.WriteLine("Indefinitely - " + indefinitely);
            
            Console.WriteLine("\ntrue & false: " + (trueT && falseT));
            Console.WriteLine("true & Indefinitely: " + (trueT && indefinitely));
            Console.WriteLine("Indefinitely & false: " + (indefinitely && falseT));
            Console.WriteLine("true & true: " + (trueT && trueT));
            Console.WriteLine("false & false: " + (falseT && falseT));
            Console.WriteLine("Indefinitely & Indefinitely: " + (indefinitely && indefinitely));

            Console.WriteLine("\nOperations:");
            Console.WriteLine("Commutativity: " + Commutativity());
            Console.WriteLine("Associativity: " + Associativity());

             Tables();
        }

        private static bool Commutativity()
        {
            return (trueT && indefinitely) == (indefinitely && trueT) &&
                   (trueT || indefinitely) == (indefinitely || trueT);
        }

        private static bool Associativity()
        {
            return (trueT || indefinitely || falseT) ==
                   (trueT || (indefinitely || falseT)) &&
                   (trueT && indefinitely && falseT) ==
                   (trueT && (indefinitely && falseT));
        }

        public static void Neg()
        {
            Console.WriteLine("___________________");
            Console.WriteLine("\n{0, 5}| {1, 5}", "NEG", "!A");
            Console.WriteLine("{0, 5}| {1, 5}|", "-1", (!falseT).ToStringNumber());
            Console.WriteLine("{0, 5}| {1, 5}|", "0", (!indefinitely).ToStringNumber());
            Console.WriteLine("{0, 5}| {1, 5}|", "+1", (!trueT).ToStringNumber());
            Console.WriteLine("___________________\n");
        }

        private static void PrintTable(string operation, Func<Tribool, Tribool, string> func)
        {
            Console.WriteLine("___________________");
            Console.WriteLine("\n{0, 15}| {1, 5}| {2, 5}| {3, 5}|", operation, "-1", "0", "+1");
            Console.WriteLine("{0, 15}| {1, 5}| {2, 5}| {3, 5}|", "-1", func(falseT, falseT), func(falseT, indefinitely), func(falseT, trueT));
            Console.WriteLine("{0, 15}| {1, 5}| {2, 5}| {3, 5}|", "0", func(indefinitely, falseT), func(indefinitely, indefinitely), func(indefinitely, trueT));
            Console.WriteLine("{0, 15}| {1, 5}| {2, 5}| {3, 5}|", "+1", func(trueT, falseT), func(trueT, indefinitely), func(trueT, trueT));
            Console.WriteLine("___________________\n");
        }

        private static void Tables()
        {
            PrintTable("MIN(A, B)", (x, y) => (x && y).ToStringNumber());
            
            PrintTable("MAX(A, B)", (x, y) => (x || y).ToStringNumber());
            
            PrintTable("XOR(A, B)", (x, y) => (x ^ y).ToStringNumber());
            Neg();
        }
    }
}
