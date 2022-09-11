using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;

namespace howto_floodfill
{
    class FloodTools
    {
        // Flood the area at this point.
        // Color pixels matching the starting pixel's color.
        public static void FloodFill(Bitmap bm, int x, int y, Color new_color)
        {
            // Get the old and new colors' components.
            byte old_r  = bm.GetPixel(x, y).R;
            byte old_g  = bm.GetPixel(x, y).G;
            byte old_b  = bm.GetPixel(x, y).B;
            byte new_r  = new_color.R;
            byte new_g  = new_color.G;
            byte new_b  = new_color.B;

            // If the colors are the same, we're done.
            if ((old_r == new_r) && (old_g == new_g) && (old_b == new_b)) return;

            // Start with the original point in the stack.
            Stack<Point> points = new Stack<Point>();
            points.Push(new Point(x, y));
            bm.SetPixel(x, y, new_color);

            // Make a BitmapBytesARGB32 object and lock the image.
            Bitmap32 bm32 = new Bitmap32(bm);
            bm32.LockBitmap();

            // While the stack is not empty, process a point.
            while (points.Count > 0)
            {
                Point pt = points.Pop();
                if (pt.X > 0) CheckPoint(bm32, points, pt.X - 1, pt.Y, old_r, old_g, old_b, new_r, new_g, new_b);
                if (pt.Y > 0) CheckPoint(bm32, points, pt.X, pt.Y - 1, old_r, old_g, old_b, new_r, new_g, new_b);
                if (pt.X < bm.Width - 1) CheckPoint(bm32, points, pt.X + 1, pt.Y, old_r, old_g, old_b, new_r, new_g, new_b);
                if (pt.Y < bm.Height - 1) CheckPoint(bm32, points, pt.X, pt.Y + 1, old_r, old_g, old_b, new_r, new_g, new_b);
            }

            // Unlock the bitmap.
            bm32.UnlockBitmap();
        }

        // See if this point should be added to the stack.
        private static void CheckPoint(Bitmap32 bm32, Stack<Point> points, int x, int y, byte old_r, byte old_g, byte old_b, byte new_r, byte new_g, byte new_b)
        {
            int pix = y * bm32.RowSizeBytes + x * Bitmap32.PixelSizeBytes;
            byte b = bm32.ImageBytes[pix];
            byte g = bm32.ImageBytes[pix + 1];
            byte r = bm32.ImageBytes[pix + 2];

            if ((r == old_r) && (g == old_g) && (b == old_b))
            {
                points.Push(new Point(x, y));
                bm32.ImageBytes[pix] = new_b;
                bm32.ImageBytes[pix + 1] = new_g;
                bm32.ImageBytes[pix + 2] = new_r;
            }
        }
    }
}
