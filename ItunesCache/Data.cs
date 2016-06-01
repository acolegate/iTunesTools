using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using ItunesCache.HelperFunctions;
using ItunesCache.Models;

using iTunesLib;

namespace ItunesCache
{
    [Serializable]
    public class Data
    {
        private static readonly string SerialisedDataPathAndFilename = Path.GetTempPath() + @"data.raw";
        private Dictionary<string, string> _artistMetaphones;
        private Dictionary<string, List<string>> _metaPhoneArtists;
        private Dictionary<string, List<string>> _metaphoneTrackNames;
        private HashSet<SearchTrack> _searchTracks;
        private Dictionary<string, string> _trackNameMetaphones;

        #region collections

        public HashSet<SearchTrack> SearchTracks
        {
            get
            {
                return _searchTracks;
            }
        }

        #region events

        #endregion

        public delegate void ProgressMadeDelegate(object sender, ProgressMadeEventArgs args);

        public static event ProgressMadeDelegate ProgressMade;

        private static void RaiseProgressMadeEvent(int tracksProcessed, int trackCount)
        {
            ProgressMadeDelegate handler = ProgressMade;
            if (handler != null)
            {
                handler(_instance, new ProgressMadeEventArgs(tracksProcessed, trackCount));
            }
        }

        public class ProgressMadeEventArgs : EventArgs
        {
            public ProgressMadeEventArgs(int value, int maxValue)
            {
                Value = value;
                MaxValue = maxValue;
            }

            public int MaxValue { get; private set; }
            public int Value { get; private set; }
        }

        public static DateTime? SerialisedDate
        {
            get
            {
                DateTime? date = null;

                if (File.Exists(SerialisedDataPathAndFilename))
                {
                    FileInfo fileInfo = new FileInfo(SerialisedDataPathAndFilename);
                    if (fileInfo.Length > 0)
                    {
                        date = fileInfo.CreationTime;
                    }
                }

                return date;
            }
        }

        #endregion

        #region singleton

        private static Data _instance;

        private string _libraryXmlPath;

        public static Data Instance
        {
            get
            {
                return _instance ?? (_instance = new Data());
            }
        }

        public string LibraryXmlPath
        {
            get
            {
                return _libraryXmlPath;
            }
        }

        public Dictionary<string, List<string>> MetaPhoneArtists
        {
            get
            {
                return _metaPhoneArtists;
            }
        }

        public Dictionary<string, List<string>> MetaphoneTrackNames
        {
            get
            {
                return _metaphoneTrackNames;
            }
        }

        #endregion

        // http://www.joshkunz.com/iTunesControl/

        // ReSharper disable once MemberCanBeMadeStatic.Global
        public void InitialiseFromItunes()
        {
            iTunesApp iTunesApp = new iTunesApp();

            Data data = new Data {
                                     _libraryXmlPath = iTunesApp.LibraryXMLPath
                                 };

            int trackCount = iTunesApp.LibraryPlaylist.Tracks.Count;
            int tracksProcessed = 0;
            int onePercent = trackCount / 100;

            data._searchTracks = new HashSet<SearchTrack>();
            data._artistMetaphones = new Dictionary<string, string>(trackCount);
            data._trackNameMetaphones = new Dictionary<string, string>(trackCount);
            data._metaPhoneArtists = new Dictionary<string, List<string>>(trackCount);
            data._metaphoneTrackNames = new Dictionary<string, List<string>>(trackCount);

            string artistMetaphone;
            string trackNameMetaphone;

            string artist;
            string trackName;

            foreach (IITTrack track in iTunesApp.LibraryPlaylist.Tracks)
            {
                if (string.IsNullOrEmpty(track.Artist) == false && string.IsNullOrEmpty(track.Name) == false && Itunes.IsMusicFile(track))
                {
                    artist = track.Artist.Trim();
                    trackName = track.Name.Trim();

                    Strings.NormaliseArtistAndTrackname(ref artist, ref trackName);

                    if (data._artistMetaphones.TryGetValue(artist, out artistMetaphone) == false)
                    {
                        artistMetaphone = Metaphone.Encode(artist);

                        if (artistMetaphone.Length > 1)
                        {
                            data._artistMetaphones.Add(artist, artistMetaphone);

                            if (data.MetaPhoneArtists.ContainsKey(artistMetaphone) == false)
                            {
                                data.MetaPhoneArtists.Add(artistMetaphone, new List<string> {
                                                                                                artist
                                                                                            });
                            }
                            else
                            {
                                if (data.MetaPhoneArtists[artistMetaphone].Contains(artist) == false)
                                {
                                    data.MetaPhoneArtists[artistMetaphone].Add(artist);
                                }
                            }
                        }
                    }

                    if (data._trackNameMetaphones.TryGetValue(trackName, out trackNameMetaphone) == false)
                    {
                        trackNameMetaphone = Metaphone.Encode(trackName);

                        if (trackNameMetaphone.Length > 1)
                        {
                            data._trackNameMetaphones.Add(trackName, trackNameMetaphone);

                            if (data.MetaphoneTrackNames.ContainsKey(trackNameMetaphone) == false)
                            {
                                data.MetaphoneTrackNames.Add(trackNameMetaphone, new List<string> {
                                                                                                      trackName
                                                                                                  });
                            }
                            else
                            {
                                if (data.MetaphoneTrackNames[trackNameMetaphone].Contains(trackName) == false)
                                {
                                    data.MetaphoneTrackNames[trackNameMetaphone].Add(trackName);
                                }
                            }
                        }
                    }

                    data._searchTracks.Add(new SearchTrack(track, trackNameMetaphone + '|' + artistMetaphone));
                }

                tracksProcessed++;

                if (tracksProcessed == 1 || tracksProcessed % onePercent == 0 || tracksProcessed == trackCount)
                {
                    RaiseProgressMadeEvent(tracksProcessed, trackCount);
                }
            }

            // attempt to reduce the size of the searchtracks collection
            data._searchTracks.TrimExcess();

            Serialization.SerializeToFile(data, SerialisedDataPathAndFilename);

            _instance = data;
        }

        // ReSharper disable once MemberCanBeMadeStatic.Global
        public void InitialiseFromStaticFile()
        {
            RaiseProgressMadeEvent(0, 0);

            _instance = Serialization.DeserializeFromFile<Data>(SerialisedDataPathAndFilename);

            RaiseProgressMadeEvent(_instance.SearchTracks.Count, _instance.SearchTracks.Count);
            
            Thread.Sleep(500);
        }
    }
}
