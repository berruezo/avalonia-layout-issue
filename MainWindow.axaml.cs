using Avalonia.Controls;
using Avalonia.Media;

namespace MyNewAvaloniaApplication
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DockPanel result = new DockPanel();

            DockPanel buttonsPanel = new DockPanel();

            Panel buttonsArea = CreateButtonsArea();
            DockPanel.SetDock(buttonsArea, Dock.Top);
            buttonsPanel.Children.Add(buttonsArea);
            buttonsPanel.LastChildFill = false;

            mBottomPanel = new Panel();
            DockPanel.SetDock(mBottomPanel, Dock.Bottom);

            result.Children.Add(mBottomPanel);
            result.Children.Add(buttonsPanel);

            Content = result;
        }

        Panel CreateButtonsArea()
        {
            DockPanel result = new DockPanel();

            Button showPanelButton = new Button();
            showPanelButton.Content = "Show panel";

            Button hidePanelButton = new Button();
            hidePanelButton.Content = "Hide panel";
            hidePanelButton.IsVisible = false;

            Panel contentPanel = new Panel();
            contentPanel.Background = new SolidColorBrush(Colors.Red);
            contentPanel.Height = 50;

            showPanelButton.Click += (sender, args) =>
            {
                mBottomPanel.Children.Add(contentPanel);

                showPanelButton.IsVisible = false;
                hidePanelButton.IsVisible = true;

                //result.InvalidateMeasure(); // This fixes the issue
            };

            hidePanelButton.Click += (sender, args) =>
            {
                mBottomPanel.Children.Remove(contentPanel);

                showPanelButton.IsVisible = true;
                hidePanelButton.IsVisible = false;

                //result.InvalidateMeasure(); // This fixes the issue
            };

            DockPanel.SetDock(showPanelButton, Dock.Left);
            DockPanel.SetDock(hidePanelButton, Dock.Left);

            result.Children.Add(showPanelButton);
            result.Children.Add(hidePanelButton);

            result.LastChildFill = false;

            return result;
        }

        Panel mBottomPanel;
    }
}