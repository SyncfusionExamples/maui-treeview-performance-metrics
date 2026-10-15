
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace SyncfusionTreeView
{
    public class TreeViewModel : INotifyPropertyChanged
    {
        #region Private Fields

        private string name;
        private bool hasChildren;
        private ObservableCollection<TreeViewModel> children;

        #endregion

        #region Public Properties

        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(nameof(Name)); }
        }
        public bool HasChildren
        {
            get { return hasChildren; }
            set { hasChildren = value; OnPropertyChanged(nameof(HasChildren)); }
        }
        public ObservableCollection<TreeViewModel> Children
        {
            get { return children; }
            set { children = value; OnPropertyChanged(nameof(Children)); }
        }

        #endregion

        #region Constructor

        public TreeViewModel(string name)
        {
            Name = name;
            Children = new ObservableCollection<TreeViewModel>();
            HasChildren = false;
        }

        #endregion

        #region Property Changed

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if(this.PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
