﻿namespace GameEngine.Utilities
{
    public static class ImageHelper
    {
        static public Bitmap Rotate(Image image, float angle)
        {
            //create a new empty bitmap to hold rotated image
            Bitmap rotatedBmp = new(image.Width, image.Height);
            rotatedBmp.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            //make a graphics object from the empty bitmap
            Graphics g = Graphics.FromImage(rotatedBmp);

            //Put the rotation point in the center of the image
            g.TranslateTransform(image.Width / 2, image.Height / 2);

            //rotate the image
            g.RotateTransform(-angle);

            //move the image back
            g.TranslateTransform(-image.Width / 2, -image.Height / 2);

            //draw passed in image onto graphics object
            g.DrawImage(image, new PointF(0, 0));

            return rotatedBmp;
        }
    }
}
