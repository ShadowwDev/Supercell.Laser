namespace Supercell.Laser.Core
{
    using System;
    using Supercell.Laser.Logic;
    using Supercell.Laser.Core.Network;
    using Supercell.Laser.Home.Database;

    class Program
    {
        static void Main()
        {
            Console.Title = "Core";
            LogicConfiguration.Load();
            Mongo.Initialize();

            ServerSocket.Init();
        }
    }
}
