namespace Cegauto_FP
{
    public class Autok
    {
        public int nap, km_ora, km_szamlalo;
        public string ki_be;
        public string ora_perc, rendszam;

        public Autok(string sor)
        {
            string[] m = sor.Split(' ');
            nap = int.Parse(m[0]); ora_perc = m[1]; rendszam = m[2];
            km_ora = int.Parse(m[3]); km_szamlalo = int.Parse(m[4]);

            if (int.Parse(m[5]) == 0) ki_be = "ki"; else ki_be = "be";
        }
    }
}