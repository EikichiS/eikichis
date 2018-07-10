using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers.PDF
{
    public class Fonts
    {

        public static Font Standard
        {
            get
            {
                return new Font(Font.FontFamily.HELVETICA, 11, Font.NORMAL, BaseColor.BLACK);
            }
        }

        public static Font StandardCh
        {
            get
            {
                return new Font(Font.FontFamily.HELVETICA, 9, Font.NORMAL, BaseColor.BLACK);
            }
        }

        public static Font Bold
        {
            get
            {
                return new Font(Font.FontFamily.HELVETICA, 11, Font.BOLD, BaseColor.BLACK);
            }
        }

        public static Font BoldCh
        {
            get
            {
                return new Font(Font.FontFamily.HELVETICA, 9, Font.BOLD, BaseColor.BLACK);
            }
        }

        public static Font Subtitulo
        {
            get
            {
                return new Font(Font.FontFamily.HELVETICA, 13, Font.BOLD, BaseColor.BLACK);
            }
        }

        public static Font Titulo
        {
            get
            {
                return new Font(Font.FontFamily.HELVETICA, 16, Font.BOLD, BaseColor.BLACK);
            }
        }
    }
}
