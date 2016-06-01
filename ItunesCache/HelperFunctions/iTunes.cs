using iTunesLib;

namespace ItunesCache.HelperFunctions
{
    internal static class Itunes
    {
        public static bool IsMusicFile(IITTrack track)
        {
            string kind = track.KindAsString;
            return (kind == "MPEG audio file" || kind == "Apple Lossless audio file" || kind == "AAC audio file") && track.Genre != "Podcast";
        }
    }
}
