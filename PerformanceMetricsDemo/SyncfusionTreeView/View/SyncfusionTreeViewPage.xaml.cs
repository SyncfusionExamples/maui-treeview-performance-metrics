using Syncfusion.Maui.Popup;

namespace SyncfusionTreeView;

public partial class SyncfusionTreeViewPage : ContentPage
{
	public SyncfusionTreeViewPage()
	{
		InitializeComponent();
	}

    private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
		Extensions.stopwatch.Reset();
        Extensions.stopwatch.Start();

        if (sender is SearchBar search)
		{
			this.treeView.FilterText = search.Text;
		}
    }

    private void treeView_Filtered(object sender, Syncfusion.Maui.TreeView.FilteredEventArgs e)
    {
        Extensions.stopwatch.Stop();
        Extensions.loadTimeSeconds = Extensions.stopwatch.Elapsed.TotalSeconds;

        var popup = new SfPopup();
        popup.ShowHeader = false;
        popup.PopupStyle.CornerRadius = new CornerRadius(0);
        popup.PopupStyle.PopupBackground = Colors.White;
        popup.PopupStyle.HasShadow = false;
        popup.AutoSizeMode = PopupAutoSizeMode.Both;
        popup.ContentTemplate = new DataTemplate(() =>
        {
            var stackLayout = new StackLayout() { Padding = new Thickness(10), Spacing = 2 };
            var totalCountLable = new Label() { TextColor = Colors.Black, Text = "Total Items:   " + Extensions.toatlItemsCount.ToString() };
            var loadedCountLable = new Label() { TextColor = Colors.Black, Text = "Loaded Items:   " + Extensions.itemCount.ToString() };
            var totalSeconds = new Label() { TextColor = Colors.Black, Text = "Total Seconds:   " + Extensions.loadTimeSeconds.ToString() };
            stackLayout.Children.Add(totalCountLable);
            stackLayout.Children.Add(loadedCountLable);
            stackLayout.Children.Add(totalSeconds);
            return stackLayout;
        });

        popup.Show();

    }
}