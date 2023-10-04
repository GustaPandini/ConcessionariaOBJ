using System;
using System.Collections;
using System.IO.Pipes;
using System.Reflection;
using System.Text.Json;

namespace ConsoleApp2
{
    internal class Program
    {

        List<Automovel> Lista_Automovel = new List<Automovel>();

        static void Main(string[] args)
        {
            Menu.MenuPrincipal();
        }

    }
}