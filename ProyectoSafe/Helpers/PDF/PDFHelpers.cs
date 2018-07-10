using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers.PDF
{
    public class PDFHelpers
    {
        public static Paragraph AddDescription(string title, string value)
        {
            Paragraph description = new Paragraph();
            description.Add(new Chunk(title, Fonts.Bold));
            description.Add(new Chunk(value, Fonts.Standard));

            return description;
        }

        public static Paragraph AddSubtitle(string value)
        {
            Paragraph subtitle = new Paragraph();
            subtitle.Add(new Chunk(value, Fonts.Subtitulo));

            return subtitle;
        }
    }
}
