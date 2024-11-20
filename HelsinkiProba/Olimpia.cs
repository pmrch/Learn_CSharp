using System.Runtime.InteropServices;

namespace Helsinki
{
    internal class Helyezes
    {
        public int helyezes;
        public int sportolok;
        public string sportag;
        public string versenyszam;

        public Helyezes(string sor)
        {
            string[] m = sor.Split();
            helyezes = int.Parse(m[0]);
            sportolok = int.Parse(m[1]);
            sportag = m[2];
            versenyszam = m[3];
        }
    }
}