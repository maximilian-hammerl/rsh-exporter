﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using RSHExporter.Utils;

namespace RSHExporter.View.Pages;

public partial class WelcomePage : Page
{
    public WelcomePage()
    {
        InitializeComponent();

        CollectDataCheckBox.IsChecked = CollectDataAccepted;

        VersionTextBlock.Text = Util.GetVersion();
    }

    public static bool CollectDataAccepted { get; private set; } = false;

    private void HelpButton_OnClick(object sender, RoutedEventArgs e)
    {
        DialogUtil.ShowHelpAndHighlight(
            (brush => { WelcomeTextBlock.Background = brush; },
                RSHExporter.Resources.Localization.Resources.HelpWelcomeStep1),
            (brush => CollectDataContent.Background = brush,
                RSHExporter.Resources.Localization.Resources.HelpWelcomeStep2),
            (brush => RepositoryTextBlock.Background = brush,
                RSHExporter.Resources.Localization.Resources.HelpWelcomeStep3),
            (brush => VersionTextBlock.Background = brush,
                RSHExporter.Resources.Localization.Resources.HelpWelcomeStep4),
            (brush => TeamTextBlock.Background = brush,
                RSHExporter.Resources.Localization.Resources.HelpWelcomeStep5),
            (brush => ContinueButtonContent.Background = brush,
                RSHExporter.Resources.Localization.Resources.HelpWelcomeStep6)
        );
    }

    private void FeedbackButton_OnClick(object sender, RoutedEventArgs e)
    {
        FeedbackUtil.HandleFeedback("FeedbackPage");
    }

    private void ContinueButton_OnClick(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new LoginPage());
    }

    private void BackButton_OnClick(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new LicensePage());
    }

    private void CollectDataCheckBox_OnChecked(object sender, RoutedEventArgs e)
    {
        CollectDataAccepted = true;
    }

    private void CollectDataCheckBox_OnUnchecked(object sender, RoutedEventArgs e)
    {
        CollectDataAccepted = false;
    }

    private void Hyperlink_OnRequestNavigate(object sender, RequestNavigateEventArgs e)
    {
        Util.OpenBrowser(e.Uri);
        e.Handled = true;
    }
}