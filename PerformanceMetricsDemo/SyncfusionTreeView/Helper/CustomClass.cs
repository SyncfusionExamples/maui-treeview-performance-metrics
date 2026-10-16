using Syncfusion.Maui.TreeView;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SyncfusionTreeView
{
    public class CustomSfTreeView : SfTreeView
    {
        public CustomSfTreeView()
        {
            Extensions.stopwatch = new Stopwatch();
            Extensions.stopwatch.Start();
        }
    }
    public class CustomGrid : Grid
    {
        public CustomGrid()
        {
            Extensions.itemCount++;
        }
        protected override Size ArrangeOverride(Rect bounds)
        {
            if (Extensions.stopwatch != null)
            {
                Extensions.loadTimeSeconds = Extensions.stopwatch.Elapsed.TotalSeconds;
            }
            return base.ArrangeOverride(bounds);
        }
    }
}
