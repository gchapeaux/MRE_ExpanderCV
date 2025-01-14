using CommunityToolkit.Maui.Views;

namespace MRE_ExpanderCV
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();

            CV.ItemsSource = Enumerable.Range(1,25);
        }

        private void Expander_ExpandedChanged(object sender, CommunityToolkit.Maui.Core.ExpandedChangedEventArgs e)
        {
            if (sender is Expander ex && e.IsExpanded)
            {
                Console.WriteLine($"=== Expander {ex.BindingContext} clicked. ===");
                List<Expander> expanders = CV.GetVisualTreeDescendants().OfType<Expander>().ToList();
                foreach (var expander in expanders)
                {
                    if (expander != ex)
                    {
                        expander.IsExpanded = false;
                    }
                }

                int position = expanders.IndexOf(ex);
                CV.ScrollTo(position, position: ScrollToPosition.Start);

            }
        }

    }

}
