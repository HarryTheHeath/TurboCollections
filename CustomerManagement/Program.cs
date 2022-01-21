using System;
using TurboCollections;

namespace CustomerManagement
{
    public class Program
    {
        static void Main(string[] args)
        {
            var turboList = new TurboList<float>();
            turboList.Add(3f);
            turboList.Add(-7f);
            turboList.Add(1337f);
            turboList.Add(1337f);
            turboList.RemoveAt(1);

            foreach (var item in turboList)
            {
                Console.WriteLine(item);
            }
        }
    }
}