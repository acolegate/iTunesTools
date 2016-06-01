using System;
using System.Collections.Generic;
using System.Linq;

using ItunesCache.Models;

namespace CustomControls.HelperFunctions
{
    public static class ConsolidateDataHelper
    {
        public static string ConsolidateAlbumData(SearchTrack trackToKeep, IEnumerable<SearchTrack> selectedTracks)
        {
            if (string.IsNullOrEmpty(trackToKeep.Album) == false)
            {
                return trackToKeep.Album;
            }
            string album = string.Empty;

            foreach (SearchTrack selectedTrack in selectedTracks.Where(selectedTrack => string.IsNullOrEmpty(selectedTrack.Album) == false))
            {
                album = selectedTrack.Album.Trim();
                break;
            }

            return album;
        }

        public static string ConsolidateCommentsData(IEnumerable<SearchTrack> tracks)
        {
            List<string> allComments = new List<string>();

            foreach (SearchTrack track in tracks)
            {
                if (string.IsNullOrEmpty(track.Comments) == false)
                {
                    foreach (string comment in track.Comments.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        if (allComments.Contains(comment.Trim()) == false)
                        {
                            allComments.Add(comment.Trim());
                        }
                    }
                }
            }

            return string.Join("|", allComments);
        }

        public static string ConsolidateGenreData(SearchTrack trackToKeep, IEnumerable<SearchTrack> selectedTracks)
        {
            if (string.IsNullOrEmpty(trackToKeep.Genre) == false)
            {
                return trackToKeep.Genre;
            }
            string genre = string.Empty;

            foreach (SearchTrack selectedTrack in selectedTracks.Where(selectedTrack => string.IsNullOrEmpty(selectedTrack.Genre) == false))
            {
                genre = selectedTrack.Genre.Trim();
                break;
            }

            return genre;
        }

        public static int ConsolidateTrackCountData(SearchTrack trackToKeep, IEnumerable<SearchTrack> selectedTracks)
        {
            return trackToKeep.TrackCount > 0 ? trackToKeep.TrackCount : selectedTracks.Where(selectedTrack => selectedTrack.TrackCount != 0).Select(selectedTrack => selectedTrack.TrackCount).FirstOrDefault();
        }

        public static int ConsolidateTrackNumberData(SearchTrack trackToKeep, IEnumerable<SearchTrack> selectedTracks)
        {
            return trackToKeep.TrackNumber > 0 ? trackToKeep.TrackNumber : selectedTracks.Where(selectedTrack => selectedTrack.TrackNumber != 0).Select(selectedTrack => selectedTrack.TrackNumber).FirstOrDefault();
        }

        public static int ConsolidateYearData(IEnumerable<SearchTrack> selectedTracks)
        {
            int lowestYear = 9999;

            foreach (SearchTrack track in selectedTracks)
            {
                if (track.Year != 0 && track.Year < lowestYear)
                {
                    lowestYear = track.Year;
                }
            }

            return lowestYear != 9999 ? lowestYear : 0;
        }
    }
}
