namespace Kozuti_Ellenorzes
{
    internal class Jarmuvek
    {
        public int ora, perc, mp;
        public string rendszam;
        
        public Jarmuvek(string sor)
        {
            string[] m = sor.Split(' ');
            ora = int.Parse(m[0]); perc = int.Parse(m[1]);
            mp = int.Parse(m[2]); rendszam = m[3];
        }
    }
}