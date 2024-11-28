namespace IPv6
{
    internal class IPv6Cimek
    {
        public string a, b, c, d;
        public string e, f, g, h;
        public IPv6Cimek(string sor)
        {
            string[] m = sor.Split(':');
            a = m[0]; b = m[1]; c = m[2]; d = m[3];
            e = m[4]; f = m[5]; g = m[6]; h = m[7];
        }
    }
}