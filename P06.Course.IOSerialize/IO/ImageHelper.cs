using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06.Course.IOSerialize.IO
{
    public class ImageHelper
    {
        private static string ImagePath = Constant.ImagePath;
        private static string VerifyPath = Constant.VerifyPath;
        //Bitmap is like a canvas, Graphics is like a hand, using Pen or Brush painting on the Bitmap

        public static void Drawing()
        {
            Bitmap bitmapobj = new Bitmap(200,350);
            //create a new Graphics based on Bitmap object
            Graphics g = Graphics.FromImage(bitmapobj); 
            g.Clear(Color.White);
            //create obj used for painting, like Pen or Brush
            Pen redPen = new Pen(Color.Red,8);

            //paint graph
            g.DrawLine(redPen,50,20,500,20);
            g.DrawEllipse(Pens.Black,new Rectangle(0,0,200,100));
            g.DrawArc(Pens.Aqua,new Rectangle(0,0,100,100),60,180 );
            g.DrawLine(Pens.Blue,0,0,100,100 );
            g.DrawRectangle(Pens.Chartreuse,new Rectangle(0,0,100,100));
            g.DrawString("this is my picture",
                new Font("Magic R", 12),
                new SolidBrush(Color.Green), new PointF(10,10) );

            if (!Directory.Exists(ImagePath))
                Directory.CreateDirectory(ImagePath);

            bitmapobj.Save(ImagePath + "pic1.jpg", ImageFormat.Jpeg);

            //free up all obj
            bitmapobj.Dispose();
            g.Dispose();

        }






    }
}
