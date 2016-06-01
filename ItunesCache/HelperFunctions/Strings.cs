using System;

namespace ItunesCache.HelperFunctions
{
    internal static class Strings
    {
        public static void NormaliseArtistAndTrackname(ref string artist, ref string trackName)
        {
            // if the artist has ", The" on the end, move it to the beginning
            if (artist.EndsWith(", the", StringComparison.OrdinalIgnoreCase) || artist.EndsWith(",the", StringComparison.OrdinalIgnoreCase))
            {
                artist = artist.Substring(0, artist.Length - 3).Trim();
                artist = "The " + artist.Substring(0, artist.Length - 1);
            }

            // replace Ampersands
            artist = artist.Replace("&", "And");
            trackName = trackName.Replace("&", "And");
        }
    }
}
