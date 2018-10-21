using DataGridCustomization.Model;
using DataGridCustomization.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

using System.Windows.Media;
using System.Windows.Threading;

namespace DataGridCustomization.View
{
    /// <summary>
    /// Interaction logic for Window5.xaml
    /// </summary>
    public partial class PersonManagement : Window
    {
        #region Private Members

        int columnOffsetWidth = 60;
        int group1ColNavCtr = 0;
        int group2ColNavCtr = 0;
        int group3ColNavCtr = 0;
        int staticColumns = 2; //First Name and Last Name..Update if add more freeze columns
        List<Person> copiedRows = new List<Person>();
        DataGridCell currentCell = null;

        #endregion

        #region Constructor

        public PersonManagement()
        {
            InitializeComponent();
            this.DataContext = new PersonManagementViewModel();
            HideDefaultGroupColumns();
        }

        #endregion

        #region Event Handlers

        private void dg1_GotFocus(object sender, RoutedEventArgs e)
        {

            if (e.OriginalSource.GetType() == typeof(DataGridCell))
            {
                currentCell = e.OriginalSource as DataGridCell;//Set current Cell
                // Starts the Edit on the row;
                DataGrid grd = (DataGrid)sender;
                grd.BeginEdit(e);

                Control control = GetFirstChildByType<Control>(e.OriginalSource as DataGridCell);
                if (control != null)
                {

                    control.Focus();
                    ((TextBox)control).SelectAll();
                }
            }
        }

        private void dg1_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {

            var uiElement = e.OriginalSource as UIElement;
            if (uiElement != null)
            {
                var selectedRow = dg1.ItemContainerGenerator.ContainerFromItem(dg1.CurrentItem) as DataGridRow;

                if (e.Key == Key.V && Keyboard.Modifiers == ModifierKeys.Control)
                {
                    PasteClipboardCopiedRows();
                }

                //Handle the Key Down 
                if (e.Key == Key.Right || e.Key == Key.Left || e.Key == Key.Up || e.Key == Key.Down)
                {
                    e.Handled = true;
                }

                //If the Column Index is last column Index and Arrow key is pressed
                if ((dg1.CurrentCell.Column.DisplayIndex == dg1.Columns.Count - 1) && e.Key == Key.Right)
                {
                    //Get column Index
                    var columnIndex = dg1.Columns.IndexOf(dg1.CurrentColumn);
                    //Get Row Index
                    var rowIndex = dg1.Items.IndexOf(dg1.CurrentItem);

                    //Get index of the next column
                    columnIndex = columnIndex + 1;

                    //Reset column index if user is at the end of the row
                    if (columnIndex > dg1.Columns.Count - 1)
                    {
                        rowIndex = rowIndex + 1;
                        columnIndex = 0;

                        //If user has reached the last row and last column, add a new row
                        if (rowIndex > dg1.Items.Count - 1)
                        {
                            var itemsSource = dg1.ItemsSource as ObservableCollection<Person>;
                            if (itemsSource != null)
                            {
                                var newItem = new Person();
                                itemsSource.Add(newItem);
                            }
                        }
                    }

                    //There should always be a selected cell
                    if (dg1.SelectedCells.Count != 0)
                    {
                        SelectCellByIndex(dg1, rowIndex, columnIndex);
                    }
                }

                //Enable navigation as per Arrow Key
                if (e.Key == Key.Right)
                    uiElement.MoveFocus(new TraversalRequest(FocusNavigationDirection.Right));
                else if (e.Key == Key.Left)
                    uiElement.MoveFocus(new TraversalRequest(FocusNavigationDirection.Left));
                else if (e.Key == Key.Up)
                    uiElement.MoveFocus(new TraversalRequest(FocusNavigationDirection.Up));
                else if (e.Key == Key.Down)
                    uiElement.MoveFocus(new TraversalRequest(FocusNavigationDirection.Down));
            }
        }
                     
        private void btnPreviousGroup1_Click(object sender, RoutedEventArgs e)
        {
            if (group1ColNavCtr > 1)
            {
                group1ColNavCtr--;
            }
            ShowHideGroupColumns(1, group1ColNavCtr);
            var scrollerViewer = GetScrollViewer();
            if (scrollerViewer != null)
            {
                scrollerViewer.ScrollToHorizontalOffset(scrollerViewer.HorizontalOffset - columnOffsetWidth);
            }


        }

        private void btnNextGroup1_Click(object sender, RoutedEventArgs e)
        {
            if (group1ColNavCtr < 6)
            {
                group1ColNavCtr++;
            }
            ShowHideGroupColumns(1, group1ColNavCtr);
            var scrollerViewer = GetScrollViewer();
            if (scrollerViewer != null)
            {
                scrollerViewer.ScrollToHorizontalOffset(scrollerViewer.HorizontalOffset + columnOffsetWidth);
            }
        }

        private void btnPreviousGroup2_Click(object sender, RoutedEventArgs e)
        {

            if (group2ColNavCtr > 1)
            {
                group2ColNavCtr--;
            }

            ShowHideGroupColumns(2, group2ColNavCtr);

            var scrollerViewer = GetScrollViewer();
            if (scrollerViewer != null)
            {
                scrollerViewer.ScrollToHorizontalOffset(scrollerViewer.HorizontalOffset - columnOffsetWidth);
            }
        }

        private void btnNextGroup2_Click(object sender, RoutedEventArgs e)
        {
            if (group2ColNavCtr < 6)
            {
                group2ColNavCtr++;
            }
            ShowHideGroupColumns(2, group2ColNavCtr);

            var scrollerViewer = GetScrollViewer();
            if (scrollerViewer != null)
            {
                scrollerViewer.ScrollToHorizontalOffset(scrollerViewer.HorizontalOffset + columnOffsetWidth);
            }
        }

        private void btnPreviousGroup3_Click(object sender, RoutedEventArgs e)
        {
            if (group3ColNavCtr > 1)
            {
                group3ColNavCtr--;
            }
            ShowHideGroupColumns(3, group3ColNavCtr);

            var scrollerViewer = GetScrollViewer();
            if (scrollerViewer != null)
            {
                scrollerViewer.ScrollToHorizontalOffset(scrollerViewer.HorizontalOffset - columnOffsetWidth);
            }
        }

        private void btnNextGroup3_Click(object sender, RoutedEventArgs e)
        {
            if (group3ColNavCtr < 6)
            {
                group3ColNavCtr++;
            }
            ShowHideGroupColumns(3, group3ColNavCtr);
            var scrollerViewer = GetScrollViewer();
            if (scrollerViewer != null)
            {
                scrollerViewer.ScrollToHorizontalOffset(scrollerViewer.HorizontalOffset + columnOffsetWidth);
            }
        }

        private void dg1_CopyingRowClipboardContent(object sender, DataGridRowClipboardEventArgs e)
        {
            //For now allow single row copy. If multiple row copy required, then need to handle
            copiedRows.Clear();
            copiedRows.Add(e.Item as Person);
        }


        #endregion

        #region Private Methods

        private void HideDefaultGroupColumns()
        {
            for (int i = 7; i < 12; i++)
            {
                dg1.Columns[i].Visibility = Visibility.Hidden;
            }
            for (int i = 17; i < 22; i++)
            {
                dg1.Columns[i].Visibility = Visibility.Hidden;
            }
            for (int i = 27; i < 32; i++)
            {
                dg1.Columns[i].Visibility = Visibility.Hidden;
            }
        }

        private void ShowHideGroupColumns(int groupIndex, int ctr)
        {
            int startIndex = (staticColumns - 1) + ((groupIndex - 1) * 10) + ctr;
            int endIndex = (staticColumns - 1) + (groupIndex * 10) + ctr - 5;
            //Default hide all columns within the group
            for (int i = (staticColumns + ((groupIndex - 1) * 10)); i < (staticColumns + (groupIndex * 10)); i++)
            {
                dg1.Columns[i].Visibility = Visibility.Hidden;
            }
            //Show the columns falling between calculated range
            for (int i = startIndex; i < endIndex; i++)
            {
                dg1.Columns[i].Visibility = Visibility.Visible;
            }
        }

        /// <summary>
        /// Past Copied Rows
        /// </summary>
        private void PasteClipboardCopiedRows()
        {
            //When user clicks on First Name and Paste, then Paste the Row
            //This is required to handle cell and row level copy/paste contradiction
            if (currentCell != null && Convert.ToString(currentCell.Column.Header) == "First Name")
            {
                ObservableCollection<Person> itemsSource = dg1.ItemsSource as ObservableCollection<Person>;
                if (itemsSource != null && copiedRows.Count > 0)
                {
                    //Insert at the end. Code if need to set in specific Index
                    itemsSource.Insert(itemsSource.Count, copiedRows[0]);
                }
            }

        }
        
        #region Handle Scroll If required

        ScrollViewer GetScrollViewer()
        {
            ScrollViewer scrollViewer = GetFirstChildByType<ScrollViewer>(dg1);


            return scrollViewer;
            if (VisualTreeHelper.GetChildrenCount(this) == 0) return null;
            var x = VisualTreeHelper.GetChild(this, 0);
            if (x == null) return null;
            if (VisualTreeHelper.GetChildrenCount(x) == 0) return null;
            return VisualTreeHelper.GetChild(x, 0) as ScrollViewer;
        }

        private T GetFirstChildByType<T>(DependencyObject prop) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(prop); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild((prop), i) as DependencyObject;
                if (child == null)
                    continue;

                T castedProp = child as T;
                if (castedProp != null)
                    return castedProp;

                castedProp = GetFirstChildByType<T>(child);

                if (castedProp != null)
                    return castedProp;
            }
            return null;
        }

        public void SelectCellByIndex(DataGrid dataGrid, int rowIndex, int columnIndex)
        {
            if (!dataGrid.SelectionUnit.Equals(DataGridSelectionUnit.CellOrRowHeader))
                throw new ArgumentException("The SelectionUnit of the DataGrid must be set to Cell.");

            if (rowIndex < 0 || rowIndex > (dataGrid.Items.Count - 1))
                throw new ArgumentException(string.Format("{0} is an invalid row index.", rowIndex));

            if (columnIndex < 0 || columnIndex > (dataGrid.Columns.Count - 1))
                throw new ArgumentException(string.Format("{0} is an invalid column index.", columnIndex));

            dataGrid.SelectedCells.Clear();

            object item = dataGrid.Items[rowIndex];
            //Get row by Index and scroll to the row
            DataGridRow row = dataGrid.ItemContainerGenerator.ContainerFromIndex(rowIndex) as DataGridRow;
            if (row == null)
            {
                dataGrid.ScrollIntoView(item);
                row = dataGrid.ItemContainerGenerator.ContainerFromIndex(rowIndex) as DataGridRow;
            }
            if (row != null)
            {
                //Get cell by index and focus
                DataGridCell cell = GetCell(dataGrid, row, columnIndex);
                if (cell != null)
                {
                    DataGridCellInfo dataGridCellInfo = new DataGridCellInfo(cell);
                    dataGrid.SelectedCells.Add(dataGridCellInfo);
                    cell.Focus();
                }
            }
        }

        public DataGridCell GetCell(DataGrid dataGrid, DataGridRow rowContainer, int column)
        {
            if (rowContainer != null)
            {
                DataGridCellsPresenter presenter = GetFirstChildByType<DataGridCellsPresenter>(rowContainer);
                if (presenter == null)
                {
                    /* if the row has been virtualized away, call its ApplyTemplate() method
                     * to build its visual tree in order for the DataGridCellsPresenter
                     * and the DataGridCells to be created */
                    rowContainer.ApplyTemplate();
                    presenter = GetFirstChildByType<DataGridCellsPresenter>(rowContainer);
                }
                if (presenter != null)
                {
                    DataGridCell cell = presenter.ItemContainerGenerator.ContainerFromIndex(column) as DataGridCell;
                    if (cell == null)
                    {
                        /* bring the column into view
                         * in case it has been virtualized away */
                        dataGrid.ScrollIntoView(rowContainer, dataGrid.Columns[column]);
                        cell = presenter.ItemContainerGenerator.ContainerFromIndex(column) as DataGridCell;
                    }
                    return cell;
                }
            }
            return null;
        }

        #endregion

        #endregion
    }

}
