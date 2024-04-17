namespace MusicPortal.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Song> Songs { get; }
        public PageViewModel PageViewModel { get; }
        public IndexViewModel(IEnumerable<Song> songs, PageViewModel viewModel)
        {
            Songs = songs;
            PageViewModel = viewModel;
        }
    }
}
