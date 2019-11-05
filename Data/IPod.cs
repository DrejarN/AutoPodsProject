

namespace Data
{
    public interface IPod
    {
        string filenameForJson { get; set; }
        void deserializeList(string file);
    }
}
