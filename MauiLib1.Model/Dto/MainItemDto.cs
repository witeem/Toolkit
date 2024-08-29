using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiLib1.Model.Dto
{
    public partial class MainItemDto : ObservableObject
    {     
        public string Key { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string Detail { get; set; }

        [RelayCommand]
        async Task Add()
        {
            await Shell.Current.GoToAsync($"//{Title}");
        }
    }
}
