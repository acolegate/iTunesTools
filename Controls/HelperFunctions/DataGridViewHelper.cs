using System.Collections.Generic;
using System.Windows.Forms;

using CustomControls.BindingLists;
using CustomControls.Formatters;

using ItunesCache.Models;

namespace CustomControls.HelperFunctions
{
    public static class DataGridViewHelper
    {
        public static void PopulateGridView(DataGridView gridView, IEnumerable<SearchTrack> searchTracks)
        {
            gridView.SuspendLayout();

            gridView.DataSource = new SortableBindingList<SearchTrack>(searchTracks);

            gridView.ResumeLayout();
        }

        public static void PopulateGridView(DataGridView gridView, SearchTrack searchTrack)
        {
            PopulateGridView(gridView, new List<SearchTrack> {
                                                                 searchTrack
                                                             });
        }

        public static void SetupDataGridView(DataGridView dataGridView)
        {
            dataGridView.AutoGenerateColumns = false;

            dataGridView.Columns.Clear();

            dataGridView.Columns.Add(DataGridViewTextColumn("TrackId", false));

            DataGridViewTextBoxColumn nameColumn = DataGridViewTextColumn("Name", DataGridViewColumnSortMode.Automatic);
            nameColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            nameColumn.Resizable = DataGridViewTriState.False;
            dataGridView.Columns.Add(nameColumn);

            DataGridViewTextBoxColumn artistColumn = DataGridViewTextColumn("Artist", DataGridViewColumnSortMode.Automatic);
            artistColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            artistColumn.Resizable = DataGridViewTriState.False;
            dataGridView.Columns.Add(artistColumn);

            DataGridViewTextBoxColumn commentsColumn = DataGridViewTextColumn("Comments", DataGridViewColumnSortMode.Automatic);
            commentsColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            commentsColumn.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView.Columns.Add(commentsColumn);

            DataGridViewTextBoxColumn albumColumn = DataGridViewTextColumn("Album", DataGridViewColumnSortMode.Automatic);
            albumColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            albumColumn.Resizable = DataGridViewTriState.False;
            dataGridView.Columns.Add(albumColumn);

            DataGridViewTextBoxColumn yearColumn = DataGridViewTextColumn("Year", DataGridViewContentAlignment.MiddleCenter);
            yearColumn.DefaultCellStyle.FormatProvider = new Year();
            yearColumn.Resizable = DataGridViewTriState.False;
            yearColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView.Columns.Add(yearColumn);

            DataGridViewTextBoxColumn genreColumn = DataGridViewTextColumn("Genre", DataGridViewColumnSortMode.Automatic);
            genreColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView.Columns.Add(genreColumn);

            DataGridViewTextBoxColumn timeColumn = DataGridViewTextColumn("Duration", "Time", DataGridViewColumnSortMode.Automatic, DataGridViewContentAlignment.MiddleRight);
            timeColumn.DefaultCellStyle.FormatProvider = new Seconds();
            timeColumn.Resizable = DataGridViewTriState.False;
            timeColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView.Columns.Add(timeColumn);

            DataGridViewTextBoxColumn bitRateColumn = DataGridViewTextColumn("BitRate", "Bit Rate", DataGridViewColumnSortMode.Automatic, DataGridViewContentAlignment.MiddleRight);
            bitRateColumn.DefaultCellStyle.Format = "0 kbps";
            bitRateColumn.Resizable = DataGridViewTriState.False;
            bitRateColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView.Columns.Add(bitRateColumn);

            DataGridViewTextBoxColumn trackNumberColumn = DataGridViewTextColumn("TrackNumberSummary", "Track Number", DataGridViewContentAlignment.MiddleRight);
            trackNumberColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            trackNumberColumn.Resizable = DataGridViewTriState.False;
            dataGridView.Columns.Add(trackNumberColumn);

            DataGridViewTextBoxColumn sizeColumn = DataGridViewTextColumn("Size", DataGridViewColumnSortMode.Automatic, DataGridViewContentAlignment.MiddleRight);
            sizeColumn.DefaultCellStyle.FormatProvider = new Bytes();
            sizeColumn.Resizable = DataGridViewTriState.False;
            dataGridView.Columns.Add(sizeColumn);
        }

        private static DataGridViewTextBoxColumn DataGridViewTextColumn(string propertyName, DataGridViewColumnSortMode sortMode, DataGridViewContentAlignment alignment)
        {
            return DataGridViewTextColumn(propertyName, true, propertyName, alignment, sortMode);
        }

        private static DataGridViewTextBoxColumn DataGridViewTextColumn(string propertyName, string headerText, DataGridViewColumnSortMode sortMode, DataGridViewContentAlignment alignment)
        {
            return DataGridViewTextColumn(propertyName, true, headerText, alignment, sortMode);
        }

        private static DataGridViewTextBoxColumn DataGridViewTextColumn(string propertyName, string headerText, DataGridViewContentAlignment alignment)
        {
            return DataGridViewTextColumn(propertyName, true, headerText, alignment, DataGridViewColumnSortMode.NotSortable);
        }

        private static DataGridViewTextBoxColumn DataGridViewTextColumn(string propertyName, DataGridViewContentAlignment alignment)
        {
            return DataGridViewTextColumn(propertyName, true, propertyName, alignment, DataGridViewColumnSortMode.NotSortable);
        }

        private static DataGridViewTextBoxColumn DataGridViewTextColumn(string propertyName, bool visible)
        {
            return DataGridViewTextColumn(propertyName, visible, propertyName, DataGridViewContentAlignment.NotSet, DataGridViewColumnSortMode.NotSortable);
        }

        private static DataGridViewTextBoxColumn DataGridViewTextColumn(string propertyName, DataGridViewColumnSortMode sortMode)
        {
            return DataGridViewTextColumn(propertyName, true, propertyName, DataGridViewContentAlignment.NotSet, sortMode);
        }

        private static DataGridViewTextBoxColumn DataGridViewTextColumn(string propertyName, bool visible, string headerText, DataGridViewContentAlignment alignment, DataGridViewColumnSortMode sortMode)
        {
            DataGridViewTextBoxColumn tbc = new DataGridViewTextBoxColumn {
                                                                              DataPropertyName = propertyName,
                                                                              HeaderText = headerText,
                                                                              SortMode = sortMode,
                                                                              Visible = visible,
                                                                              DefaultCellStyle = {
                                                                                                     Alignment = alignment
                                                                                                 }
                                                                          };
            tbc.HeaderCell.Style.Alignment = alignment;

            return tbc;
        }
    }
}
