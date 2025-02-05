using System.Runtime.InteropServices.ComTypes;

public class Jeladas {
    public string rendszam;
    public int ora; public int perc; public int sebesseg;

    public Jeladas(string rendszam, int ora, int perc, int sebesseg) {
        this.rendszam = rendszam;
        this.ora = ora;
        this.perc = perc;
        this.sebesseg = sebesseg;
    }
}