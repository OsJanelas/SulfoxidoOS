using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace SulfoxidoOS
{
    class Kernel
    {
        static string currentPath = "C:\\";
        static string version = "1.0.2-STABLE";
        static ConsoleColor osColor = ConsoleColor.DarkMagenta;

        static void Main(string[] args)
        {
            Console.Title = "SulfoxidoOS - Initialize";
            BootSequence();

            while (true)
            {
                Console.ResetColor();
                Console.Write($"\n[{DateTime.Now.ToShortTimeString()}] ");
                Console.ForegroundColor = osColor;
                Console.Write("Sulfoxido");
                Console.ResetColor();
                Console.Write($":{currentPath}> ");

                string input = Console.ReadLine();
                ProcessCommand(input);
            }
        }

        static void BootSequence()
        {
            Console.ForegroundColor = osColor;
            Console.WriteLine("SULFOXIDO OS [Version " + version + "]");
            Console.WriteLine("Iniciando nucleo de processamento...");
            Thread.Sleep(800);
            Console.WriteLine("Montando HelioFS (File System)... OK");
            Console.WriteLine("Carregando GUI Interface... OK");
            Thread.Sleep(500);
            Console.Clear();

            Console.WriteLine("==================================================");
            Console.WriteLine("      S U L F O X I D O   O S   -   2 0 2 6      ");
            Console.WriteLine("==================================================");
            Console.WriteLine("Bem-vindo. Digite 'ajuda' para comandos.");
        }

        static void ProcessCommand(string input)
        {
            string[] parts = input.ToLower().Split(' ');
            string command = parts[0];

            switch (command)
            {
                case "ajuda":
                    ShowHelp();
                    break;
                case "cls":
                    Console.Clear();
                    break;
                case "relogio":
                    Console.WriteLine("Hora exata: " + DateTime.Now.ToString("HH:mm:ss"));
                    break;
                case "calc":
                    RunCalculator();
                    break;
                case "notas":
                    Process.Start("notepad.exe");
                    Console.WriteLine("Bloco de notas externo iniciado.");
                    break;
                case "ls":
                    ShowFiles();
                    break;
                case "tema":
                    ChangeTheme(parts);
                    break;
                case "sair":
                    Environment.Exit(0);
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Comando desconhecido.");
                    break;
            }
        }

        static void ShowHelp()
        {
            Console.WriteLine("\n--- COMANDOS SULFOXIDO ---");
            Console.WriteLine("ajuda    - Lista comandos");
            Console.WriteLine("ls       - Listar arquivos (HelioFS)");
            Console.WriteLine("calc     - Calculadora interna");
            Console.WriteLine("notas    - Editor de texto");
            Console.WriteLine("relogio  - Exibir hora");
            Console.WriteLine("tema     - Mudar cor (azul, verde, magenta)");
            Console.WriteLine("cls      - Limpar tela");
            Console.WriteLine("sair     - Desligar sistema");
        }

        static void RunCalculator()
        {
            Console.Write("Expressao (ex: 5 + 5): ");
            string exp = Console.ReadLine();
            try
            {
                // Simulação simples de cálculo
                Console.WriteLine("Resultado processado pelo nucleo.");
            }
            catch { Console.WriteLine("Erro de sintaxe."); }
        }

        static void ShowFiles()
        {
            string[] files = Directory.GetFiles(currentPath);
            Console.WriteLine("\nConteudo de " + currentPath);
            foreach (var file in files)
            {
                Console.WriteLine(" <DIR> " + Path.GetFileName(file));
            }
        }

        static void ChangeTheme(string[] parts)
        {
            if (parts.Length < 2) return;
            if (parts[1] == "azul") osColor = ConsoleColor.Cyan;
            if (parts[1] == "verde") osColor = ConsoleColor.Green;
            if (parts[1] == "magenta") osColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Tema alterado com sucesso.");
        }
    }
}