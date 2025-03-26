namespace BennerLogic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var net = new Network(4);

            net.AddItem(1);
            net.AddItem(2);
            net.AddItem(3);
            net.AddItem(4);

            net.Connect(1, 2);
            net.Connect(2, 3);
            net.Connect(3, 4);

            Console.WriteLine(net.LevelConnection(1, 4));

            Console.WriteLine(net.Query(1, 3));

            net.Disconnect(1, 2);

            Console.WriteLine(net.Query(1, 3));

            Console.WriteLine(net.LevelConnection(1, 4));
        }
    }
}
