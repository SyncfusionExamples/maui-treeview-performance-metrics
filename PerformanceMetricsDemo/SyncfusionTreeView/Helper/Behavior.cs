using Syncfusion.Maui.Popup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncfusionTreeView
{
    public class SyncfusionTreeViewPageBehavior : Behavior<ContentPage>
    {
        private Button? getDetailsButton;

        protected override void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);
            this.getDetailsButton = bindable.FindByName<Button>("detailsButton");
            this.getDetailsButton.Clicked += OnGetPerformanceMetrics;
            bindable.NavigatedFrom += Bindable_NavigatedFrom;
        }

        private void Bindable_NavigatedFrom(object? sender, NavigatedFromEventArgs e)
        {
            Extensions.stopwatch = null;
            Extensions.itemCount = 0;
            Extensions.loadTimeSeconds = 0;
        }

        protected override void OnDetachingFrom(ContentPage bindable)
        {
            base.OnDetachingFrom(bindable);
            if (this.getDetailsButton != null)
            {
                this.getDetailsButton.Clicked -= OnGetPerformanceMetrics;
                bindable.NavigatedFrom -= Bindable_NavigatedFrom;
                this.getDetailsButton = null;
            }
        }

        private void OnGetPerformanceMetrics(object? sender, EventArgs e)
        {
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

    public class MainPageBehavior : Behavior<ContentPage>
    {
        private Button? treeViewButton;
        private ContentPage? mainPage;
        private TreeViewViewModel? treeViewViewModel;
        private RadioButton? data_100;
        private RadioButton? data_1K;
        private RadioButton? data_10K;
        private RadioButton? data_1L;

        protected override void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);
            this.mainPage = bindable;
            this.treeViewButton = bindable.FindByName<Button>("treeViewButton");
            this.data_100 = bindable.FindByName<RadioButton>("data_100");
            this.data_1K = bindable.FindByName<RadioButton>("data_1K");
            this.data_10K = bindable.FindByName<RadioButton>("data_10K");
            this.data_1L = bindable.FindByName<RadioButton>("data_1L");
            this.treeViewButton.Clicked += OnTreeViewButtonClicked;
            this.data_100.CheckedChanged += OnDataChanged;
            this.data_1K.CheckedChanged += OnDataChanged;
            this.data_10K.CheckedChanged += OnDataChanged;
            this.data_1L.CheckedChanged += OnDataChanged;
            Extensions.toatlItemsCount = 100;
            this.treeViewViewModel = new TreeViewViewModel();
            this.treeViewViewModel.GenerateCompanyHierarchy();
        }

        protected override void OnDetachingFrom(ContentPage bindable)
        {
            base.OnDetachingFrom(bindable);
            if (this.treeViewButton != null && this.data_100 != null && this.data_1K != null && this.data_10K != null && this.data_1L != null)
            {
                this.treeViewButton.Clicked -= OnTreeViewButtonClicked;
                this.data_100.CheckedChanged -= OnDataChanged;
                this.data_1K.CheckedChanged -= OnDataChanged;
                this.data_10K.CheckedChanged -= OnDataChanged;
                this.data_1L.CheckedChanged -= OnDataChanged;
                this.treeViewButton = null;
                this.treeViewViewModel = null;
                this.mainPage = null;
            }
        }

        private void OnTreeViewButtonClicked(object? sender, EventArgs e)
        {
            var page = new SyncfusionTreeViewPage();
            page.BindingContext = this.treeViewViewModel;
            if (this.mainPage != null)
            {
                this.mainPage.Navigation.PushAsync(page);
            }
        }

        private void OnDataChanged(object? sender, CheckedChangedEventArgs e)
        {
            var button = sender as RadioButton;
            if (button != null && button.Content != null && this.treeViewViewModel != null)
            {
                var content = button.Content.ToString();
                if (content == "100")
                {
                    Extensions.toatlItemsCount = 100;
                    this.treeViewViewModel.GenerateCompanyHierarchy();
                }
                else if (content == "1K")
                {
                    Extensions.toatlItemsCount = 1000;
                    this.treeViewViewModel.GenerateCompanyHierarchy();
                }
                else if (content == "10K")
                {
                    Extensions.toatlItemsCount = 10000;
                    this.treeViewViewModel.GenerateCompanyHierarchy();
                }
                else if (content == "1L")
                {
                    Extensions.toatlItemsCount = 100000;
                    this.treeViewViewModel.GenerateCompanyHierarchy();
                }
            }
        }
    }
}
