using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace arrays_ep3
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.ReadLine();
        }
        static void Targil3()
        {
            int numjudge = 10;
            int[] scores = new int[50];
            CollectVotes1(scores, numjudge);
            ShowTop3(scores);
        }
        static void CollectVotes1(int[] scores, int numjudge)
        {
            for (int judge = 0; judge < numjudge; judge++) 
            {
                Console.WriteLine($"judge {judge + 1} insert 3 ppl you choose to vote for ");
                int[] input = new int[3];
                for(int i = 0; i < input.Length; i++)
                {
                    Console.WriteLine($"insert num that you choose {i + 1}");
                    input[i] = int.Parse(Console.ReadLine());
                }
                for(int i = 0; i < input.Length; i++)
                {
                    int smh = input[i] - 1;
                    scores[smh] += (3 - i);
                }
            }
        }
        static void ShowTop3(int[] scores)
        {
            int[] num = new int[scores.Length];
            for (int i = 0; i < scores.Length; i++) num[i] = i + 1;
            for (int i = 0; i < scores.Length - 1; i++)
            {
                for (int j = i + 1; j < scores.Length; j++)
                {
                    if (scores[i] < scores[j])
                    {
                        int tempscore = scores[i];
                        scores[i] = scores[j];
                        scores[j] = tempscore;
                        int tempnum = num[i];
                        num[i] = num[j];
                        num[j] = tempnum;
                    }
                }
            }
            for (int i = 0; i < 3; i++) 
            {
                Console.WriteLine($"{i + 1} place is number {num[i]} with {scores[i]} points");
            }
        }
        static void Targil2()
        {
            int[,] building = new int[30, 7];
            int[] totalslaves = new int[30];
            int minfloor = 0;
            int minslaves = int.MaxValue;
            CollectSlave(building, totalslaves, ref minfloor, ref minslaves);
            ShowS(totalslaves);
            ShowMin(minfloor, minslaves);

        }
        static void CollectSlave(int[,] building, int[] totalslaves, ref int minfloor, ref int minslaves)
        {
            for (int floor = 0; floor < 30; floor++)
            {
                Console.WriteLine($"floor number {floor + 1}");
                int totalSlavesForFloor = 0;
                for (int office = 0; office < 7; office++)
                {
                    Console.Write($"insert the numbers of slaves inside office {office + 1}");
                    int slaves = int.Parse(Console.ReadLine());
                    building[floor, office] = slaves;
                    totalSlavesForFloor += slaves;
                }
                totalslaves[floor] = totalSlavesForFloor;
                if (totalSlavesForFloor < minslaves)
                {
                    minslaves = totalSlavesForFloor;
                    minfloor = floor;
                }
            }
        }
        static void ShowS(int[] totalslaves)
        {
            for (int floor = 0; floor < 30; floor++)
            {
                Console.WriteLine($"floor number {floor + 1} got {totalslaves[floor]} slaves");
            }
        }
        static void ShowMin(int minfloor, int minslaves)
        {
            Console.WriteLine($"the floor with the minimum slaves is floor number {minfloor + 1} with {minslaves} slaves");
        }
        static void Targil1()
        {
            int[] votes = new int[10];
            CollectVotes(votes);
            Show(votes);
        }
        static void CollectVotes(int[] votes)
        {
            Console.WriteLine("insert your fav song to finish insert 0");
            while (true)
            {
                int numbersong = int.Parse(Console.ReadLine());
                if (numbersong == 0)
                {
                    break;
                }
                votes[numbersong - 1]++;
            }
        }
        static void Show(int[] votes) 
        {
            Console.WriteLine("scores of the songs");
            for (int i = 0; i < votes.Length; i++)
            {
                Console.WriteLine($"for song number{i + 1}: {votes[i]} votes ");
            }
        }
    }
}
