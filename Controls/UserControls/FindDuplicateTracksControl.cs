using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using CustomControls.ExtensionMethods;

using ItunesCache;
using ItunesCache.Models;

namespace CustomControls.UserControls
{
    public partial class FindDuplicateTracksControl : UserControl
    {
        private List<List<SearchTrack>> _duplicates;

        public FindDuplicateTracksControl()
        {
            InitializeComponent();
        }

        private void PopulateTracksDataGridView()
        {
            tracksDataGridView.DataSource = _duplicates.Select(displayTracks => displayTracks[0]).ToList();
        }

        private void ScanForDuplicates()
        {
            _duplicates = (from t in Data.Instance.SearchTracks group t by t.CombinedNameArtistMetaphone into g where g.IsMultiple() select g.ToList()).ToList();
        }

        private void ScanForDuplicatesButton_Click(object sender, EventArgs e)
        {
            ScanForDuplicates();

            PopulateTracksDataGridView();
        }
    }
}
