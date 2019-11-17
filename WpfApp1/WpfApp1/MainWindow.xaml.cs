using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
    }

    private void Find_Button_Click(object sender, RoutedEventArgs e)
    {
      if (Pages_Frame.Items.Count == 0)
      {
        MessageBox.Show("Откройте новую вкладку!");
      }
      else
      {
        Global.CurrentPage.Source = new Uri("http://" + Find_TextBox.Text);
        Main_Frame.Content = Global.CurrentPage;
      }
    }

    private void GoForward_Button_Click(object sender, RoutedEventArgs e)
    {

      try
      {
        Global.CurrentPage.GoForward();
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }

    private void GoBack_Button_Click(object sender, RoutedEventArgs e)
    {
      try
      {
        Global.CurrentPage.GoBack();
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }

    private void NewPage_Button_Click(object sender, RoutedEventArgs e)
    {
      Global.PageIndexer++;
      Pages_Frame.Items.Add(new TabItem {
        Header = new TextBlock { Text = $"Page {Global.PageIndexer.ToString()}" },
        Content = new WebBrowser() 
      });
    }

    private void Pages_Frame_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      Global.CurrentPage = (WebBrowser)Pages_Frame.SelectedContent;
      Global.CurrentItem = (TabItem)Pages_Frame.SelectedItem;
      Main_Frame.Content = Global.CurrentPage;
    }

    private void DeletePage_Button_Click(object sender, RoutedEventArgs e)
    {
      Pages_Frame.Items.Remove(Global.CurrentItem);
      Main_Frame.Content = "Выберите вкладку!";
    }
  }
}
