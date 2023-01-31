using System;
using System.Collections.Generic;
using System.IO;
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
using static System.Net.Mime.MediaTypeNames;

namespace DBUpdateFileGenerator
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

      private void btnGo_Click(object sender, RoutedEventArgs e)
      {
         int starterNumber = 0;

         if (int.TryParse(txtRange.Text, out starterNumber))
         {
            if (starterNumber > 99)
            {
               showMessageBox();
            }
            else
            {
               buildFileRange(starterNumber);
               MessageBoxResult result = MessageBox.Show("Done.");
            }
         }
         else
         {
            showMessageBox();
         }
      }

      private void showMessageBox()
      {
         MessageBoxResult result = MessageBox.Show("Please enter a 1 or 2 digit integer.");
      }

      private void buildFileRange(int starterNumber)
      {
         starterNumber = (starterNumber * 1000) + 1;

         for (int i = 0; i < 10; i++)
         {
            createFile(starterNumber);
            starterNumber += 100;
         }
      }

      private void createFile(int fileStarterNumber)
      {
         int endingUpdateNumber = fileStarterNumber + 99;

         string updateDirectory = System.IO.Path.GetFullPath(@"..\..\..\") + "updatefiles";

         string filePath = updateDirectory + $"\\DatabaseUpdater_{fileStarterNumber}_{endingUpdateNumber}.cs";

         string fileContents = UpdateFileTemplate.UpdateTemplate1;

         int update = fileStarterNumber;

         while (update <= endingUpdateNumber)
         {
            if (update % 10 == 1)
            {
               fileContents += $"      #region Updates {update} - {update + 9}\r\n";
            }

            fileContents += $"         #region Update {update}\r\n";
            fileContents += "         #endregion\r\n";

            if (update % 10 == 0)
            {
               fileContents += "      #endregion\r\n\r\n";
            }
            else
            {
               fileContents += "\r\n";
            }
            update++;
         }

         fileContents += "\r\n";
         fileContents += UpdateFileTemplate.UpdateTemplate2;

         File.WriteAllText(filePath, fileContents);

      }

   }
}
