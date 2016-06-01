using System;

using ItunesCache.HelperFunctions;

using iTunesLib;

namespace ItunesCache.Models
{
    [Serializable]
    public class SearchTrack
    {
        public SearchTrack(IITTrack track, string combinedNameArtistMetaphone = null)
        {
            Name = track.Name != null ? track.Name.Trim() : string.Empty;
            Artist = track.Artist != null ? track.Artist.Trim() : string.Empty;
            Album = track.Album != null ? track.Album.Trim() : null;
            Comments = track.Comment != null ? track.Comment.Trim() : null;
            Genre = track.Genre != null ? track.Genre.Trim() : null;

            BitRate = track.BitRate;
            CombinedNameArtistMetaphone = combinedNameArtistMetaphone ?? Metaphone.Encode(Name) + "|" + Metaphone.Encode(Artist);
            DatabaseId = track.TrackDatabaseID;
            Duration = track.Duration;
            PlaylistId = track.playlistID;
            Size = track.Size;
            SourceId = track.sourceID;
            Time = track.Time;
            TrackCount = track.TrackCount;
            TrackId = track.trackID;
            TrackNumber = track.TrackNumber;
            Year = track.Year;
            Location = ((dynamic)track).Location;
        }

        public string Album { get; set; }
        public string Artist { get; set; }
        public int BitRate { get; set; }
        public string CombinedNameArtistMetaphone { get; set; }
        public string Comments { get; set; }
        public int DatabaseId { get; set; }
        public int Duration { get; set; }
        public string Genre { get; set; }
        public string Location { get; set; }
        public string Name { get; set; }
        public int PlaylistId { get; set; }
        public long Size { get; set; }
        public int SourceId { get; set; }
        public string Time { get; set; }
        public int TrackCount { get; set; }
        public int TrackId { get; set; }
        public int TrackNumber { get; set; }

        // ReSharper disable once UnusedMember.Global
        public string TrackNumberSummary
        {
            get
            {
                return TrackNumber != 0 && TrackCount != 0 ? TrackNumber + " of " + TrackCount : (TrackNumber != 0 ? TrackNumber.ToString() : string.Empty);
            }
        }

        public IITTrack TrackObject
        {
            get
            {
                return (IITTrack)new iTunesApp().GetITObjectByID(SourceId, PlaylistId, TrackId, DatabaseId);
            }
        }

        public int Year { get; set; }

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
