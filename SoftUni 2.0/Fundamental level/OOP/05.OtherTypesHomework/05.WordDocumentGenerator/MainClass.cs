namespace _05.WordDocumentGenerator
{
    using Novacode;
    using System.Drawing;

    public class MainClass
    {
        private static void Main()
        {
            //Used a help from others HWs.
            string fileName = @"C:\Users\Георги\Desktop\СофтУни\Fundamentals\OOP\05.OtherTypes\05.OtherTypesHomework\05.WordDocumentGenerator.docx";

            using (var doc = DocX.Create(fileName))
            {
                // Headline 
                string headlineText = "SoftUni OOP Game Contest";
                Paragraph headline = doc.InsertParagraph(headlineText);
                headline.Font(new System.Drawing.FontFamily("Arial Black"));
                headline.FontSize(20);
                headline.Bold();
                headline.Alignment = Alignment.center;

                // Picture
                Picture mainPic = doc.AddImage("rpg-game.png").CreatePicture();
                mainPic.Height = mainPic.Height * 2 / 3;
                mainPic.Width = mainPic.Width / 3;
                Paragraph picture = doc.InsertParagraph(string.Empty, false);
                picture.InsertPicture(mainPic);
                doc.InsertParagraph(string.Empty, false);

                // First paragraph
                Paragraph firstParagraph = doc.InsertParagraph("SoftUni is organizing a contest for the best ");
                firstParagraph.Append("role playing game ").Bold().
                Append("from the OOP teamwork projects.The winning teams will receive a ").
                Append("grand prize").Bold().UnderlineColor(System.Drawing.Color.Black).
                Append("!").
                AppendLine("The game should be:").
                Font(new System.Drawing.FontFamily("Calibri")).
                FontSize(14);

                // Bullets
                List bulletList = doc.AddList("Properly structured and follow all good OOP practices", 1, ListItemType.Bulleted);
                doc.AddListItem(bulletList, "Awesome", 1);
                doc.AddListItem(bulletList, "..Very Awesome", 1);
                doc.InsertList(bulletList);

                // Additional paragraph for space
                doc.InsertParagraph(string.Empty,false);

                // Table
                Table teamTable = doc.AddTable(4, 3);
                teamTable.Alignment = Alignment.center;
                teamTable.AutoFit = AutoFit.Window;

                string[] tableTitles = new string[3] { "Team", "Game", "Score" };

                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (i == 0)
                        {
                            teamTable.Rows[i].Cells[j].FillColor = Color.Blue;
                            teamTable.Rows[i].Cells[j].Paragraphs[0].Append(tableTitles[j]).Color(Color.White).Bold().Alignment = Alignment.center;
                        }
                        else
                        {
                            teamTable.Rows[i].Cells[j].Paragraphs[0].Append("-").Alignment = Alignment.center;
                        }
                    }
                }

                doc.InsertTable(teamTable);
                doc.InsertParagraph(string.Empty);

                // Last paragraph
                doc.InsertParagraph("The top 3 teams will receive a ").
                Append("SPECTACULAR").Bold().CapsStyle(CapsStyle.caps).
                Append(" prize:").
                Alignment = Alignment.center;

                doc.InsertParagraph("A HANDSHAKE FROM NAKOV").
                    Color(Color.LightBlue).
                    Bold().
                    UnderlineColor(Color.LightBlue).
                    FontSize(20).
                    Alignment = Alignment.center;

                doc.Save();
            }
        }
    }
}
