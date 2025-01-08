namespace Lift
{
    public class Lift
    {
        public int ora, perc, masodperc;
        public int sorszam, start, end;

        public Lift(string sor)
        {
            string[] m = sor.Split();
            ora = int.Parse(m[0]); perc = int.Parse(m[1]); masodperc = int.Parse(m[2]);
            sorszam = int.Parse(m[3]); start = int.Parse(m[4]); end = int.Parse(m[5]); 
        }
    }
}