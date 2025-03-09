public class Veetel {
    public int iNap { get; set; }
    public int iAmator { get; set; }
    public string sFeljegyes { get; set; }

    public Veetel(string sor1, string sor2) {
        iNap = int.Parse(sor1.Split(' ')[0]);
        iAmator = int.Parse(sor1.Split(' ')[1]);
        sFeljegyes = sor2;
    }
}