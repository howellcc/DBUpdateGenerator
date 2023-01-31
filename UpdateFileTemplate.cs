using System;


namespace DBUpdateFileGenerator
{
   internal static class UpdateFileTemplate
   {

      public static string UpdateTemplate1 = $"using LCS.Core.Enumerations;\r\nusing LCS.Core.Extensions;\r\nusing System.Text;\r\nusing LCS.Express.Models.Enumerations;\r\n\r\nnamespace LCS.BL.Database.Updater\r\n{{\r\n   public partial class DatabaseUpdater\r\n   {{\r\n      //***************  SPECIAL NOTE ***************//\r\n      //\r\n      //When adding structural changes, such as adding a table, it is important to drop them from the database first.\r\n      //  This is because the update could have partially run already and structural changes are not rolled back when a rollback is executed.\r\n      //  The AddIndex, AddForeignKey, and AddColumn functions handle this for you.\r\n      //\r\n      //*********************************************//\r\n\r\n";

      public static string UpdateTemplate2 = $"   }}\r\n}}\r\n";

   }
}
