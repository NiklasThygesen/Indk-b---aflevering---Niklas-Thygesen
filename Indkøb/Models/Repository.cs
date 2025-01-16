namespace Indkøb.Models
{
    public static class Repository
    {
        private static List<TilføjVarer> tilføjListe = new();
        public static IEnumerable<TilføjVarer> Tilføj => tilføjListe;

        public static void AddTilføjVarer(TilføjVarer tilføj)
        {
            Console.WriteLine(tilføj);
            tilføjListe.Add(tilføj);
        }

        public static void RemoveTilføjVarer(string name)
        {
            var itemToRemove = tilføjListe.FirstOrDefault(x => x.Name == name);
            if (itemToRemove != null)
            {
                tilføjListe.Remove(itemToRemove);
            }
        }
    }
}
