using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoisonApple
{
    class Program
    {
        static void Main(string[] args)
        {
            ApplePick applePick = new ApplePick();
            IEnumerable<Apple> pick = applePick.PickApples();
            List<Apple> smallPick = pick.Take(10000).ToList();

            //foreach (var apple in smallPick)
            //{
            //    Console.WriteLine(apple);
            //} 

            //How many Apples are Poisoned?
            var poison = smallPick.GroupBy(apple => apple.Poisoned);
            var PoisonApples = poison.Single(apples => apples.Key == true);
            //Console.WriteLine("How many Apples are Poisoned?");
            //Console.WriteLine(PoisonApples.Count());

            //what is the most common colour apple after Red?
            var query = (from a in smallPick
                         group a by a into gr
                         orderby gr.Count() descending
                         select gr.Key).ToArray();
            //Console.WriteLine("What is the most common colour Apple after Red?");
            //Console.WriteLine(query[2]);

            Console.ReadLine();
        }
    }
}
