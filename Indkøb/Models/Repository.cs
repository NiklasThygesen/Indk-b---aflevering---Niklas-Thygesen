namespace Indkøb.Models;

public static class Repository
{
    private static List<TilføjVarer> tilføj = new List<TilføjVarer>();

    public static IEnumerable<TilføjVarer> Tilføj => tilføj;

    public static void AddTilføjVarer(TilføjVarer tilføjVarer)
    {
        tilføj.Add(tilføjVarer);
    }

    public static void RemoveTilføjVarer(string name)
    {
        var item = tilføj.FirstOrDefault(v => v.Name == name);
        if (item != null)
        {
            tilføj.Remove(item);
        }
    }
}