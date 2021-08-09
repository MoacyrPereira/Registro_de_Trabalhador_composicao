using System;
using System.Collections.Generic;
using System.Globalization;
using EX_1.Entities.Enums;
using EX_1.Entities;

namespace EX_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Digite o nome do departamento: ");
            string deptName = Console.ReadLine();
            Console.WriteLine("Dados do trabalhador: ");
            Console.Write("Nome: ");
            string name = Console.ReadLine();
            Console.WriteLine("Nivel (Junior/Medio/Senior): ");
            WorkerLevel level = (WorkerLevel)Enum.Parse(typeof(WorkerLevel), Console.ReadLine());
            Console.Write("Salário Base: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Department dept = new Department(deptName);
            Worker worker = new Worker(name, level, baseSalary, dept);

            Console.WriteLine("Quantos contratos para esse trabalhador? ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Insira #{i} dados do contrato: ");
                Console.Write("Data (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Valor Por hora: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duração (Horas): ");
                int hours = int.Parse(Console.ReadLine());
                HourContract contract = new HourContract(date, valuePerHour, hours);
                worker.Addcontract(contract);
            }

            Console.WriteLine();

            Console.Write("Entre com o mês e o ano para calcular o gasto (MM/YYYY): ");
            string monthAnYear = Console.ReadLine();
            int month = int.Parse(monthAnYear.Substring(0, 2));
            int year = int.Parse(monthAnYear.Substring(3));

            Console.WriteLine("Nome: " + worker.Name);
            Console.WriteLine("Departamento: " + worker.Departament.Name);
            Console.WriteLine("Renda para " + monthAnYear + ", " +  worker.Income(year, month).ToString("F2",CultureInfo.InvariantCulture));

            Console.ReadLine();
        }
    }
}
