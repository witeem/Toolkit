using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiApp1.ViewModel
{
    public partial class CatsViewModel : ObservableObject
    {
        readonly IConnectivity connectivity;

        public CatsViewModel(IConnectivity connectivity)
        {
            this.connectivity = connectivity;
        }
    }
}
