﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;
using System.Drawing;
using ZXing;
using System.IO;

namespace BarcodeReader
{
    class BarcodeControl
    {
        public BitmapImage GenBarcode(string content, BarcodeFormat format = BarcodeFormat.QR_CODE)
        {
            BarcodeWriter writer = new BarcodeWriter();

            writer.Options = new ZXing.Common.EncodingOptions
            {
                Width = 700,
                Height = 120,
                PureBarcode = true,
                Margin = 10
            };
            if (format != 0)
            {
                writer.Format = format;
            }
            else
            {
                writer.Format = BarcodeFormat.QR_CODE;
            }
            
            Bitmap Barcode = writer.Write(content);

            MemoryStream ms = new MemoryStream();
            ((System.Drawing.Bitmap)Barcode).Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            ms.Seek(0, SeekOrigin.Begin);
            image.StreamSource = ms;
            image.EndInit();

            return image;
        }
    }
}
