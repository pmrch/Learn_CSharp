using System.Net;

namespace IPv6;

class Program
{
    static void Main(string[] args)
    {
        List<string> cimek = new List<string>();
        foreach (var item in File.ReadAllLines("ip.txt"))
        {
            cimek.Add(item);
        }
    }
}
