using System;
using System.Collections.Generic;
using System.Text;
using Emgu.CV.Structure;
using Emgu.CV;
using System.Linq;

namespace SS_OpenCV
{
    class ImageClass
    {

        /// <summary>
        /// Image Negative using EmguCV library
        /// Slower method
        /// </summary>
        /// <param name="img">Image</param>
        /// 

        public static void Negative(Image<Bgr, byte> img)
        {
            unsafe
            {
                MIplImage m = img.MIplImage;
                byte* dataPtr = (byte*)m.imageData.ToPointer(); // Pointer to the image
                byte blue, green, red;

                int width = img.Width;
                int height = img.Height;
                int nChan = m.nChannels; // number of channels - 3
                int padding = m.widthStep - m.nChannels * m.width; // alinhament bytes (padding)
                int x, y;

                if (nChan == 3) // image in RGB
                {
                    for (y = 0; y < height; y++)
                    {
                        for (x = 0; x < width; x++)
                        {
                            //retrive 3 colour components
                            blue = dataPtr[0];
                            green = dataPtr[1];
                            red = dataPtr[2];


                            // store in the image
                            dataPtr[0] = (byte)(255 - (int)blue);
                            dataPtr[1] = (byte)(255 - (int)green);
                            dataPtr[2] = (byte)(255 - (int)red);

                            // advance the pointer to the next pixel
                            dataPtr += nChan;
                        }

                        //at the end of the line advance the pointer by the aligment bytes (padding)
                        dataPtr += padding;
                    }
                }
            }
        }

        /// <summary>
        /// Convert to gray
        /// Direct access to memory - faster method
        /// </summary>
        /// <param name="img">image</param>
        public static void ConvertToGray(Image<Bgr, byte> img)
        {
            unsafe
            {
                // direct access to the image memory(sequencial)
                // direcion top left -> bottom right

                MIplImage m = img.MIplImage;
                byte* dataPtr = (byte*)m.imageData.ToPointer(); // Pointer to the image
                byte blue, green, red, gray;

                int width = img.Width;
                int height = img.Height;
                int nChan = m.nChannels; // number of channels - 3
                int padding = m.widthStep - m.nChannels * m.width; // alinhament bytes (padding)
                int x, y;

                if (nChan == 3) // image in RGB
                {
                    for (y = 0; y < height; y++)
                    {
                        for (x = 0; x < width; x++)
                        {
                            //retrive 3 colour components
                            blue = dataPtr[0];
                            green = dataPtr[1];
                            red = dataPtr[2];

                            // convert to gray
                            gray = (byte)Math.Round(((int)blue + green + red) / 3.0);

                            // store in the image
                            dataPtr[0] = gray;
                            dataPtr[1] = gray;
                            dataPtr[2] = gray;

                            // advance the pointer to the next pixel
                            dataPtr += nChan;
                        }

                        //at the end of the line advance the pointer by the aligment bytes (padding)
                        dataPtr += padding;
                    }
                }
            }
        }

        public static void RedChannel(Image<Bgr, byte> img)
        {
            unsafe
            {
                // direct access to the image memory(sequencial)
                // direcion top left -> bottom right

                MIplImage m = img.MIplImage;
                byte* dataPtr = (byte*)m.imageData.ToPointer(); // Pointer to the image
                byte red;

                int width = img.Width;
                int height = img.Height;
                int nChan = m.nChannels; // number of channels - 3
                int padding = m.widthStep - m.nChannels * m.width; // alinhament bytes (padding)
                int x, y;

                if (nChan == 3) // image in RGB
                {
                    for (y = 0; y < height; y++)
                    {
                        for (x = 0; x < width; x++)
                        {
                            //retrive 3 colour components
                            red = dataPtr[2];


                            // store in the image
                            dataPtr[0] = red;
                            dataPtr[1] = red;

                            // advance the pointer to the next pixel
                            dataPtr += nChan;
                        }

                        //at the end of the line advance the pointer by the aligment bytes (padding)
                        dataPtr += padding;
                    }
                }
            }
        }

        public static void GreenChannel(Image<Bgr, byte> img)
        {
            unsafe
            {
                // direct access to the image memory(sequencial)
                // direcion top left -> bottom right

                MIplImage m = img.MIplImage;
                byte* dataPtr = (byte*)m.imageData.ToPointer(); // Pointer to the image
                byte green;

                int width = img.Width;
                int height = img.Height;
                int nChan = m.nChannels; // number of channels - 3
                int padding = m.widthStep - m.nChannels * m.width; // alinhament bytes (padding)
                int x, y;

                if (nChan == 3) // image in RGB
                {
                    for (y = 0; y < height; y++)
                    {
                        for (x = 0; x < width; x++)
                        {
                            //retrive 3 colour components
                            green = dataPtr[1];


                            // store in the image
                            dataPtr[0] = green;
                            dataPtr[2] = green;

                            // advance the pointer to the next pixel
                            dataPtr += nChan;
                        }

                        //at the end of the line advance the pointer by the aligment bytes (padding)
                        dataPtr += padding;
                    }
                }
            }
        }

        public static void BlueChannel(Image<Bgr, byte> img)
        {
            unsafe
            {
                // direct access to the image memory(sequencial)
                // direcion top left -> bottom right

                MIplImage m = img.MIplImage;
                byte* dataPtr = (byte*)m.imageData.ToPointer(); // Pointer to the image
                byte blue;

                int width = img.Width;
                int height = img.Height;
                int nChan = m.nChannels; // number of channels - 3
                int padding = m.widthStep - m.nChannels * m.width; // alinhament bytes (padding)
                int x, y;

                if (nChan == 3) // image in RGB
                {
                    for (y = 0; y < height; y++)
                    {
                        for (x = 0; x < width; x++)
                        {
                            //retrive 3 colour components
                            blue = dataPtr[0];


                            // store in the image
                            dataPtr[1] = blue;
                            dataPtr[2] = blue;

                            // advance the pointer to the next pixel
                            dataPtr += nChan;
                        }

                        //at the end of the line advance the pointer by the aligment bytes (padding)
                        dataPtr += padding;
                    }
                }
            }
        }

        public static void BrightContrast(Image<Bgr, byte> img, int brilho, double contraste)
        {
            unsafe
            {
                // direct access to the image memory(sequencial)
                // direcion top left -> bottom right

                MIplImage m = img.MIplImage;
                byte* dataPtr = (byte*)m.imageData.ToPointer(); // Pointer to the image
                byte red, green, blue;
                double nred, ngreen, nblue;

                int width = img.Width;
                int height = img.Height;
                int nChan = m.nChannels; // number of channels - 3
                int padding = m.widthStep - m.nChannels * m.width; // alinhament bytes (padding)
                int x, y;

                if (nChan == 3) // image in RGB
                {
                    for (y = 0; y < height; y++)
                    {
                        for (x = 0; x < width; x++)
                        {
                            //retrive 3 colour components
                            blue = dataPtr[0];
                            green = dataPtr[1];
                            red = dataPtr[2];

                            // alter color components

                            if (contraste < 0) { contraste = 0; }
                            else if (contraste > 3) { contraste = 3; }

                            nblue = Math.Round(blue * contraste + brilho);
                            ngreen = Math.Round(green * contraste + brilho);
                            nred = Math.Round(red * contraste + brilho);

                            if (nblue <= 0) { nblue = 0; }
                            else if (nblue >= 255) { nblue = 255; }
                            if (ngreen <= 0) { ngreen = 0; }
                            else if (ngreen >= 255) { ngreen = 255; }
                            if (nred <= 0) { nred = 0; }
                            else if (nred >= 255) { nred = 255; }


                            // store in the image
                            dataPtr[0] = (byte)nblue;
                            dataPtr[1] = (byte)ngreen;
                            dataPtr[2] = (byte)nred;

                            // advance the pointer to the next pixel
                            dataPtr += nChan;
                        }

                        //at the end of the line advance the pointer by the aligment bytes (padding)
                        dataPtr += padding;
                    }
                }
            }
        }

        public static void Translation(Image<Bgr, byte> img, Image<Bgr, byte> imgCopy, int dx, int dy)
        {
            unsafe
            {
                // direct access to the image memory(sequencial)
                // direcion top left -> bottom right

                MIplImage m = img.MIplImage;
                MIplImage mc = imgCopy.MIplImage;
                byte* dataPtr = (byte*)m.imageData.ToPointer(); // Pointer to the image
                byte* dataPtrC = (byte*)mc.imageData.ToPointer();

                int width = img.Width;
                int height = img.Height;
                int nChan = m.nChannels; // number of channels - 3
                int widthStep = m.widthStep;
                byte blue, green, red;
                int xo, yo;

                if (nChan == 3) // image in RGB
                {
                    // obter apontador do inicio da imagem MIplImage m = img.MIplImage; byte* dataPtr = (byte*)m.imageData.ToPointer();
                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        { // calcula endereço do pixel no ponto (x,y)

                            xo = x - dx;
                            yo = y - dy;
                            if (xo >= 0 && xo < width && yo >= 0 && yo < height)
                            {
                                blue = (dataPtrC + yo * widthStep + xo * nChan)[0];
                                green = (dataPtrC + yo * widthStep + xo * nChan)[1];
                                red = (dataPtrC + yo * widthStep + xo * nChan)[2];

                                (dataPtr + y * widthStep + x * nChan)[0] = blue;
                                (dataPtr + y * widthStep + x * nChan)[1] = green;
                                (dataPtr + y * widthStep + x * nChan)[2] = red;
                            }
                            else
                            {
                                (dataPtr + y * widthStep + x * nChan)[0] = 0;
                                (dataPtr + y * widthStep + x * nChan)[1] = 0;
                                (dataPtr + y * widthStep + x * nChan)[2] = 0;
                            }

                        }
                    }
                }
            }
        }

        public static void Rotation(Image<Bgr, byte> img, Image<Bgr, byte> imgCopy, float angle)
        {
            unsafe
            {
                // direct access to the image memory(sequencial)
                // direcion top left -> bottom right

                MIplImage m = img.MIplImage;
                MIplImage mc = imgCopy.MIplImage;
                byte* dataPtr = (byte*)m.imageData.ToPointer(); // Pointer to the image
                byte* dataPtrC = (byte*)mc.imageData.ToPointer();

                int width = img.Width;
                int height = img.Height;
                int nChan = m.nChannels; // number of channels - 3
                int widthStep = m.widthStep;
                byte blue, green, red;
                int xo, yo;

                if (nChan == 3) // image in RGB
                {
                    // obter apontador do inicio da imagem MIplImage m = img.MIplImage; byte* dataPtr = (byte*)m.imageData.ToPointer();
                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        { // calcula endereço do pixel no ponto (x,y)

                            xo = (int)Math.Round((x - width / 2) * Math.Cos(angle) - (height / 2 - y) * Math.Sin(angle) + width / 2);
                            yo = (int)Math.Round(-(x - width / 2) * Math.Sin(angle) - (height / 2 - y) * Math.Cos(angle) + height / 2);
                            if (xo >= 0 && xo < width && yo >= 0 && yo < height)
                            {
                                blue = (dataPtrC + yo * widthStep + xo * nChan)[0];
                                green = (dataPtrC + yo * widthStep + xo * nChan)[1];
                                red = (dataPtrC + yo * widthStep + xo * nChan)[2];

                                (dataPtr + y * widthStep + x * nChan)[0] = blue;
                                (dataPtr + y * widthStep + x * nChan)[1] = green;
                                (dataPtr + y * widthStep + x * nChan)[2] = red;
                            }
                            else
                            {
                                (dataPtr + y * widthStep + x * nChan)[0] = 0;
                                (dataPtr + y * widthStep + x * nChan)[1] = 0;
                                (dataPtr + y * widthStep + x * nChan)[2] = 0;
                            }

                        }
                    }
                }
            }
        }

        public static void Scale(Image<Bgr, byte> img, Image<Bgr, byte> imgCopy, float scaleFactor)
        {
            unsafe
            {
                // direct access to the image memory(sequencial)
                // direcion top left -> bottom right

                MIplImage m = img.MIplImage;
                MIplImage mc = imgCopy.MIplImage;
                byte* dataPtr = (byte*)m.imageData.ToPointer(); // Pointer to the image
                byte* dataPtrC = (byte*)mc.imageData.ToPointer();

                int width = img.Width;
                int height = img.Height;
                int nChan = m.nChannels; // number of channels - 3
                int widthStep = m.widthStep;
                byte blue, green, red;
                int xo, yo;

                if (nChan == 3) // image in RGB
                {
                    // obter apontador do inicio da imagem MIplImage m = img.MIplImage; byte* dataPtr = (byte*)m.imageData.ToPointer();
                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        { // calcula endereço do pixel no ponto (x,y)

                            xo = (int)Math.Round(x / scaleFactor);
                            yo = (int)Math.Round(y / scaleFactor);
                            if (xo >= 0 && xo < width && yo >= 0 && yo < height)
                            {
                                blue = (dataPtrC + yo * widthStep + xo * nChan)[0];
                                green = (dataPtrC + yo * widthStep + xo * nChan)[1];
                                red = (dataPtrC + yo * widthStep + xo * nChan)[2];

                                (dataPtr + y * widthStep + x * nChan)[0] = blue;
                                (dataPtr + y * widthStep + x * nChan)[1] = green;
                                (dataPtr + y * widthStep + x * nChan)[2] = red;
                            }
                            else
                            {
                                (dataPtr + y * widthStep + x * nChan)[0] = 0;
                                (dataPtr + y * widthStep + x * nChan)[1] = 0;
                                (dataPtr + y * widthStep + x * nChan)[2] = 0;
                            }

                        }
                    }
                }
            }
        }

        public static void Scale_point_xy(Image<Bgr, byte> img, Image<Bgr, byte> imgCopy, float scaleFactor, int centerX, int centerY)
        {
            unsafe
            {
                // direct access to the image memory(sequencial)
                // direcion top left -> bottom right

                MIplImage m = img.MIplImage;
                MIplImage mc = imgCopy.MIplImage;
                byte* dataPtr = (byte*)m.imageData.ToPointer(); // Pointer to the image
                byte* dataPtrC = (byte*)mc.imageData.ToPointer();

                int width = img.Width;
                int height = img.Height;
                int nChan = m.nChannels; // number of channels - 3
                int widthStep = m.widthStep;
                byte blue, green, red;
                int xo, yo;

                if (nChan == 3) // image in RGB
                {
                    // obter apontador do inicio da imagem MIplImage m = img.MIplImage; byte* dataPtr = (byte*)m.imageData.ToPointer();
                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        { // calcula endereço do pixel no ponto (x,y)

                            xo = (int)Math.Round(((x - centerX) / scaleFactor) + centerX);
                            yo = (int)Math.Round(((y - centerY) / scaleFactor) + centerY);
                            if (xo >= 0 && xo < width && yo >= 0 && yo < height)
                            {
                                blue = (dataPtrC + yo * widthStep + xo * nChan)[0];
                                green = (dataPtrC + yo * widthStep + xo * nChan)[1];
                                red = (dataPtrC + yo * widthStep + xo * nChan)[2];

                                (dataPtr + y * widthStep + x * nChan)[0] = blue;
                                (dataPtr + y * widthStep + x * nChan)[1] = green;
                                (dataPtr + y * widthStep + x * nChan)[2] = red;
                            }
                            else
                            {
                                (dataPtr + y * widthStep + x * nChan)[0] = 0;
                                (dataPtr + y * widthStep + x * nChan)[1] = 0;
                                (dataPtr + y * widthStep + x * nChan)[2] = 0;
                            }

                        }
                    }
                }
            }
        }

        public static void Mean(Image<Bgr, byte> img, Image<Bgr, byte> imgCopy)
        {
            unsafe
            {
                // direct access to the image memory(sequencial)
                // direcion top left -> bottom right

                MIplImage m = img.MIplImage;
                MIplImage mc = imgCopy.MIplImage;
                byte* dataPtr = (byte*)m.imageData.ToPointer(); // Pointer to the image
                byte* dataPtrC = (byte*)mc.imageData.ToPointer();

                int width = img.Width;
                int height = img.Height;
                int nChan = m.nChannels; // number of channels - 3
                int widthStep = m.widthStep;
                int y0, y2;
                int x0, x2;

                byte blue, green, red;
                double blue00, green00, red00;
                double blue01, green01, red01;
                double blue02, green02, red02;
                double blue10, green10, red10;
                double blue11, green11, red11;
                double blue12, green12, red12;
                double blue20, green20, red20;
                double blue21, green21, red21;
                double blue22, green22, red22;

                if (nChan == 3) // image in RGB
                {

                    // obter apontador do inicio da imagem MIplImage m = img.MIplImage; byte* dataPtr = (byte*)m.imageData.ToPointer();
                    for (int y = 0; y < height; y++)
                    {
                        y0 = y - 1;
                        y2 = y + 1;

                        if (y == 0) { y0 = y; }
                        else if (y == height - 1) { y2 = y; }

                        for (int x = 0; x < width; x++)
                        { // calcula endereço do pixel no ponto (x,y)
                            x0 = x - 1;
                            x2 = x + 1;

                            if (x == 0) { x0 = x; }
                            else if (x == width - 1) { x2 = x; }

                            blue00 = (dataPtrC + y0 * widthStep + x0 * nChan)[0];
                            green00 = (dataPtrC + y0 * widthStep + x0 * nChan)[1];
                            red00 = (dataPtrC + y0 * widthStep + x0 * nChan)[2];

                            blue01 = (dataPtrC + y0 * widthStep + x * nChan)[0];
                            green01 = (dataPtrC + y0 * widthStep + x * nChan)[1];
                            red01 = (dataPtrC + y0 * widthStep + x * nChan)[2];

                            blue02 = (dataPtrC + y0 * widthStep + x2 * nChan)[0];
                            green02 = (dataPtrC + y0 * widthStep + x2 * nChan)[1];
                            red02 = (dataPtrC + y0 * widthStep + x2 * nChan)[2];

                            blue10 = (dataPtrC + y * widthStep + x0 * nChan)[0];
                            green10 = (dataPtrC + y * widthStep + x0 * nChan)[1];
                            red10 = (dataPtrC + y * widthStep + x0 * nChan)[2];

                            blue11 = (dataPtrC + y * widthStep + x * nChan)[0];
                            green11 = (dataPtrC + y * widthStep + x * nChan)[1];
                            red11 = (dataPtrC + y * widthStep + x * nChan)[2];

                            blue12 = (dataPtrC + y * widthStep + x2 * nChan)[0];
                            green12 = (dataPtrC + y * widthStep + x2 * nChan)[1];
                            red12 = (dataPtrC + y * widthStep + x2 * nChan)[2];

                            blue20 = (dataPtrC + y2 * widthStep + x0 * nChan)[0];
                            green20 = (dataPtrC + y2 * widthStep + x0 * nChan)[1];
                            red20 = (dataPtrC + y2 * widthStep + x0 * nChan)[2];

                            blue21 = (dataPtrC + y2 * widthStep + x * nChan)[0];
                            green21 = (dataPtrC + y2 * widthStep + x * nChan)[1];
                            red21 = (dataPtrC + y2 * widthStep + x * nChan)[2];

                            blue22 = (dataPtrC + y2 * widthStep + x2 * nChan)[0];
                            green22 = (dataPtrC + y2 * widthStep + x2 * nChan)[1];
                            red22 = (dataPtrC + y2 * widthStep + x2 * nChan)[2];

                            blue = (byte)Math.Round((blue00 + blue01 + blue02 + blue10 + blue11 + blue12 + blue20 + blue21 + blue22) / 9);
                            green = (byte)Math.Round((green00 + green01 + green02 + green10 + green11 + green12 + green20 + green21 + green22) / 9);
                            red = (byte)Math.Round((red00 + red01 + red02 + red10 + red11 + red12 + red20 + red21 + red22) / 9);

                            (dataPtr + y * widthStep + x * nChan)[0] = blue;
                            (dataPtr + y * widthStep + x * nChan)[1] = green;
                            (dataPtr + y * widthStep + x * nChan)[2] = red;

                        }
                    }
                }
            }
        }

        public static void NonUniform(Image<Bgr, byte> img, Image<Bgr, byte> imgCopy, float[,] matrix, float matrixWeight)
        {
            unsafe
            {
                // direct access to the image memory(sequencial)
                // direcion top left -> bottom right

                MIplImage m = img.MIplImage;
                MIplImage mc = imgCopy.MIplImage;
                byte* dataPtr = (byte*)m.imageData.ToPointer(); // Pointer to the image
                byte* dataPtrC = (byte*)mc.imageData.ToPointer();

                int width = img.Width;
                int height = img.Height;
                int nChan = m.nChannels; // number of channels - 3
                int widthStep = m.widthStep;
                int y0, y2;
                int x0, x2;

                int blue, green, red;
                double blue00, green00, red00;
                double blue01, green01, red01;
                double blue02, green02, red02;
                double blue10, green10, red10;
                double blue11, green11, red11;
                double blue12, green12, red12;
                double blue20, green20, red20;
                double blue21, green21, red21;
                double blue22, green22, red22;

                if (nChan == 3) // image in RGB
                {

                    // obter apontador do inicio da imagem MIplImage m = img.MIplImage; byte* dataPtr = (byte*)m.imageData.ToPointer();
                    for (int y = 0; y < height; y++)
                    {
                        y0 = y - 1;
                        y2 = y + 1;

                        if (y == 0) { y0 = y; }
                        else if (y == height - 1) { y2 = y; }

                        for (int x = 0; x < width; x++)
                        { // calcula endereço do pixel no ponto (x,y)
                            x0 = x - 1;
                            x2 = x + 1;

                            if (x == 0) { x0 = x; }
                            else if (x == width - 1) { x2 = x; }

                            blue00 = (dataPtrC + y0 * widthStep + x0 * nChan)[0];
                            green00 = (dataPtrC + y0 * widthStep + x0 * nChan)[1];
                            red00 = (dataPtrC + y0 * widthStep + x0 * nChan)[2];

                            blue01 = (dataPtrC + y0 * widthStep + x * nChan)[0];
                            green01 = (dataPtrC + y0 * widthStep + x * nChan)[1];
                            red01 = (dataPtrC + y0 * widthStep + x * nChan)[2];

                            blue02 = (dataPtrC + y0 * widthStep + x2 * nChan)[0];
                            green02 = (dataPtrC + y0 * widthStep + x2 * nChan)[1];
                            red02 = (dataPtrC + y0 * widthStep + x2 * nChan)[2];

                            blue10 = (dataPtrC + y * widthStep + x0 * nChan)[0];
                            green10 = (dataPtrC + y * widthStep + x0 * nChan)[1];
                            red10 = (dataPtrC + y * widthStep + x0 * nChan)[2];

                            blue11 = (dataPtrC + y * widthStep + x * nChan)[0];
                            green11 = (dataPtrC + y * widthStep + x * nChan)[1];
                            red11 = (dataPtrC + y * widthStep + x * nChan)[2];

                            blue12 = (dataPtrC + y * widthStep + x2 * nChan)[0];
                            green12 = (dataPtrC + y * widthStep + x2 * nChan)[1];
                            red12 = (dataPtrC + y * widthStep + x2 * nChan)[2];

                            blue20 = (dataPtrC + y2 * widthStep + x0 * nChan)[0];
                            green20 = (dataPtrC + y2 * widthStep + x0 * nChan)[1];
                            red20 = (dataPtrC + y2 * widthStep + x0 * nChan)[2];

                            blue21 = (dataPtrC + y2 * widthStep + x * nChan)[0];
                            green21 = (dataPtrC + y2 * widthStep + x * nChan)[1];
                            red21 = (dataPtrC + y2 * widthStep + x * nChan)[2];

                            blue22 = (dataPtrC + y2 * widthStep + x2 * nChan)[0];
                            green22 = (dataPtrC + y2 * widthStep + x2 * nChan)[1];
                            red22 = (dataPtrC + y2 * widthStep + x2 * nChan)[2];

                            blue = (int)Math.Round(((blue00 * matrix[0, 0]) + (blue01 * matrix[0, 1]) + (blue02 * matrix[0, 2]) + (blue10 * matrix[1, 0]) + (blue11 * matrix[1, 1]) + (blue12 * matrix[1, 2]) + (blue20 * matrix[2, 0]) + (blue21 * matrix[2, 1]) + (blue22 * matrix[2, 2])) / matrixWeight);
                            green = (int)Math.Round(((green00 * matrix[0, 0]) + (green01 * matrix[0, 1]) + (green02 * matrix[0, 2]) + (green10 * matrix[1, 0]) + (green11 * matrix[1, 1]) + (green12 * matrix[1, 2]) + (green20 * matrix[2, 0]) + (green21 * matrix[2, 1]) + (green22 * matrix[2, 2])) / matrixWeight);
                            red = (int)Math.Round(((red00 * matrix[0, 0]) + (red01 * matrix[0, 1]) + (red02 * matrix[0, 2]) + (red10 * matrix[1, 0]) + (red11 * matrix[1, 1]) + (red12 * matrix[1, 2]) + (red20 * matrix[2, 0]) + (red21 * matrix[2, 1]) + (red22 * matrix[2, 2])) / matrixWeight);

                            if (blue >= 255) { blue = 255; }
                            if (green >= 255) { green = 255; }
                            if (red >= 255) { red = 255; }

                            (dataPtr + y * widthStep + x * nChan)[0] = (byte)blue;
                            (dataPtr + y * widthStep + x * nChan)[1] = (byte)green;
                            (dataPtr + y * widthStep + x * nChan)[2] = (byte)red;

                        }
                    }
                }
            }
        }

        public static void Sobel(Image<Bgr, byte> img, Image<Bgr, byte> imgCopy)
        {
            unsafe
            {
                // direct access to the image memory(sequencial)
                // direcion top left -> bottom right

                MIplImage m = img.MIplImage;
                MIplImage mc = imgCopy.MIplImage;
                byte* dataPtr = (byte*)m.imageData.ToPointer(); // Pointer to the image
                byte* dataPtrC = (byte*)mc.imageData.ToPointer();

                int width = img.Width;
                int height = img.Height;
                int nChan = m.nChannels; // number of channels - 3
                int widthStep = m.widthStep;
                int y0, y2;
                int x0, x2;

                int blue, green, red;
                double blue00, green00, red00;
                double blue01, green01, red01;
                double blue02, green02, red02;
                double blue10, green10, red10;
                double blue11, green11, red11;
                double blue12, green12, red12;
                double blue20, green20, red20;
                double blue21, green21, red21;
                double blue22, green22, red22;

                if (nChan == 3) // image in RGB
                {

                    // obter apontador do inicio da imagem MIplImage m = img.MIplImage; byte* dataPtr = (byte*)m.imageData.ToPointer();
                    for (int y = 0; y < height; y++)
                    {
                        y0 = y - 1;
                        y2 = y + 1;

                        if (y == 0) { y0 = y; }
                        else if (y == height - 1) { y2 = y; }

                        for (int x = 0; x < width; x++)
                        { // calcula endereço do pixel no ponto (x,y)
                            x0 = x - 1;
                            x2 = x + 1;

                            if (x == 0) { x0 = x; }
                            else if (x == width - 1) { x2 = x; }

                            blue00 = (dataPtrC + y0 * widthStep + x0 * nChan)[0];
                            green00 = (dataPtrC + y0 * widthStep + x0 * nChan)[1];
                            red00 = (dataPtrC + y0 * widthStep + x0 * nChan)[2];

                            blue01 = (dataPtrC + y0 * widthStep + x * nChan)[0];
                            green01 = (dataPtrC + y0 * widthStep + x * nChan)[1];
                            red01 = (dataPtrC + y0 * widthStep + x * nChan)[2];

                            blue02 = (dataPtrC + y0 * widthStep + x2 * nChan)[0];
                            green02 = (dataPtrC + y0 * widthStep + x2 * nChan)[1];
                            red02 = (dataPtrC + y0 * widthStep + x2 * nChan)[2];

                            blue10 = (dataPtrC + y * widthStep + x0 * nChan)[0];
                            green10 = (dataPtrC + y * widthStep + x0 * nChan)[1];
                            red10 = (dataPtrC + y * widthStep + x0 * nChan)[2];

                            blue11 = (dataPtrC + y * widthStep + x * nChan)[0];
                            green11 = (dataPtrC + y * widthStep + x * nChan)[1];
                            red11 = (dataPtrC + y * widthStep + x * nChan)[2];

                            blue12 = (dataPtrC + y * widthStep + x2 * nChan)[0];
                            green12 = (dataPtrC + y * widthStep + x2 * nChan)[1];
                            red12 = (dataPtrC + y * widthStep + x2 * nChan)[2];

                            blue20 = (dataPtrC + y2 * widthStep + x0 * nChan)[0];
                            green20 = (dataPtrC + y2 * widthStep + x0 * nChan)[1];
                            red20 = (dataPtrC + y2 * widthStep + x0 * nChan)[2];

                            blue21 = (dataPtrC + y2 * widthStep + x * nChan)[0];
                            green21 = (dataPtrC + y2 * widthStep + x * nChan)[1];
                            red21 = (dataPtrC + y2 * widthStep + x * nChan)[2];

                            blue22 = (dataPtrC + y2 * widthStep + x2 * nChan)[0];
                            green22 = (dataPtrC + y2 * widthStep + x2 * nChan)[1];
                            red22 = (dataPtrC + y2 * widthStep + x2 * nChan)[2];

                            blue = (int)Math.Round(Math.Abs(blue00 + 2 * blue10 + blue20 - (blue02 + 2 * blue12 + blue22)) + Math.Abs(blue20 + 2 * blue21 + blue22 - (blue00 + 2 * blue01 + blue02)));
                            green = (int)Math.Round(Math.Abs(green00 + 2 * green10 + green20 - (green02 + 2 * green12 + green22)) + Math.Abs(green20 + 2 * green21 + green22 - (green00 + 2 * green01 + green02)));
                            red = (int)Math.Round(Math.Abs(red00 + 2 * red10 + red20 - (red02 + 2 * red12 + red22)) + Math.Abs(red20 + 2 * red21 + red22 - (red00 + 2 * red01 + red02)));

                            if (blue >= 255) { blue = 255; }
                            else if (blue <= 0) { blue = 0; }
                            if (green >= 255) { green = 255; }
                            else if (green <= 0) { green = 0; }
                            if (red >= 255) { red = 255; }
                            else if (red <= 0) { red = 0; }

                            (dataPtr + y * widthStep + x * nChan)[0] = (byte)blue;
                            (dataPtr + y * widthStep + x * nChan)[1] = (byte)green;
                            (dataPtr + y * widthStep + x * nChan)[2] = (byte)red;

                        }
                    }
                }
            }
        }

        public static void Diferentiation(Image<Bgr, byte> img, Image<Bgr, byte> imgCopy)
        {
            unsafe
            {
                // direct access to the image memory(sequencial)
                // direcion top left -> bottom right

                MIplImage m = img.MIplImage;
                MIplImage mc = imgCopy.MIplImage;
                byte* dataPtr = (byte*)m.imageData.ToPointer(); // Pointer to the image
                byte* dataPtrC = (byte*)mc.imageData.ToPointer();

                int width = img.Width;
                int height = img.Height;
                int nChan = m.nChannels; // number of channels - 3
                int widthStep = m.widthStep;
                int x2, y2;

                int blue, green, red;

                double blue11, green11, red11;
                double blue12, green12, red12;
                double blue21, green21, red21;

                if (nChan == 3) // image in RGB
                {

                    // obter apontador do inicio da imagem MIplImage m = img.MIplImage; byte* dataPtr = (byte*)m.imageData.ToPointer();
                    for (int y = 0; y < height; y++)
                    {
                        y2 = y + 1;
                        if (y == height - 1) { y2 = y; }

                        for (int x = 0; x < width; x++)
                        { // calcula endereço do pixel no ponto (x,y)
                            x2 = x + 1;
                            if (x == width - 1) { x2 = x; }

                            blue11 = (dataPtrC + y * widthStep + x * nChan)[0];
                            green11 = (dataPtrC + y * widthStep + x * nChan)[1];
                            red11 = (dataPtrC + y * widthStep + x * nChan)[2];

                            blue12 = (dataPtrC + y * widthStep + x2 * nChan)[0];
                            green12 = (dataPtrC + y * widthStep + x2 * nChan)[1];
                            red12 = (dataPtrC + y * widthStep + x2 * nChan)[2];

                            blue21 = (dataPtrC + y2 * widthStep + x * nChan)[0];
                            green21 = (dataPtrC + y2 * widthStep + x * nChan)[1];
                            red21 = (dataPtrC + y2 * widthStep + x * nChan)[2];

                            blue = (int)Math.Round(Math.Abs(blue11 - blue12) + Math.Abs(blue11 - blue21));
                            green = (int)Math.Round(Math.Abs(green11 - green12) + Math.Abs(green11 - green21));
                            red = (int)Math.Round(Math.Abs(red11 - red12) + Math.Abs(red11 - red21));

                            if (blue >= 255) { blue = 255; }
                            else if (blue <= 0) { blue = 0; }
                            if (green >= 255) { green = 255; }
                            else if (green <= 0) { green = 0; }
                            if (red >= 255) { red = 255; }
                            else if (red <= 0) { red = 0; }

                            (dataPtr + y * widthStep + x * nChan)[0] = (byte)blue;
                            (dataPtr + y * widthStep + x * nChan)[1] = (byte)green;
                            (dataPtr + y * widthStep + x * nChan)[2] = (byte)red;

                        }
                    }
                }
            }
        }

        public static void Median(Image<Bgr, byte> img, Image<Bgr, byte> imgCopy)
        {
            unsafe
            {
                imgCopy.SmoothMedian(3).CopyTo(img);
            }
        }

        public static int[] Histogram_Gray(Emgu.CV.Image<Bgr, byte> img)
        {
            unsafe
            {
                // direct access to the image memory(sequencial)
                // direcion top left -> bottom right

                MIplImage m = img.MIplImage;
                byte* dataPtr = (byte*)m.imageData.ToPointer(); // Pointer to the image

                int width = img.Width;
                int height = img.Height;
                int nChan = m.nChannels; // number of channels - 3
                int widthStep = m.widthStep;

                int[] hist = new int[256];
                int blue, green, red;

                if (nChan == 3) // image in RGB
                {

                    // obter apontador do inicio da imagem MIplImage m = img.MIplImage; byte* dataPtr = (byte*)m.imageData.ToPointer();
                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        { // calcula endereço do pixel no ponto (x,y)

                            blue = (dataPtr + y * widthStep + x * nChan)[0];
                            green = (dataPtr + y * widthStep + x * nChan)[1];
                            red = (dataPtr + y * widthStep + x * nChan)[2];

                            hist[(int)Math.Round((blue + green + red) / 3.0)] += 1;
                        }
                    }
                }
                return hist;
            }

        }

        public static int[,] Histogram_RGB(Emgu.CV.Image<Bgr, byte> img)
        {
            unsafe
            {
                // direct access to the image memory(sequencial)
                // direcion top left -> bottom right

                MIplImage m = img.MIplImage;
                byte* dataPtr = (byte*)m.imageData.ToPointer(); // Pointer to the image

                int width = img.Width;
                int height = img.Height;
                int nChan = m.nChannels; // number of channels - 3
                int widthStep = m.widthStep;

                int[,] hist = new int[3, 256];

                int blue, green, red;

                if (nChan == 3) // image in RGB
                {

                    // obter apontador do inicio da imagem MIplImage m = img.MIplImage; byte* dataPtr = (byte*)m.imageData.ToPointer();
                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        { // calcula endereço do pixel no ponto (x,y)

                            blue = (dataPtr + y * widthStep + x * nChan)[0];
                            green = (dataPtr + y * widthStep + x * nChan)[1];
                            red = (dataPtr + y * widthStep + x * nChan)[2];

                            hist[0, blue] += 1;
                            hist[1, green] += 1;
                            hist[2, red] += 1;
                        }
                    }
                }
                return hist;
            }
        }


        public static int[,] Histogram_All(Emgu.CV.Image<Bgr, byte> img)
        {
            unsafe
            {
                // direct access to the image memory(sequencial)
                // direcion top left -> bottom right

                MIplImage m = img.MIplImage;
                byte* dataPtr = (byte*)m.imageData.ToPointer(); // Pointer to the image

                int width = img.Width;
                int height = img.Height;
                int nChan = m.nChannels; // number of channels - 3
                int widthStep = m.widthStep;

                int[,] hist = new int[4, 256];

                int blue, green, red;

                if (nChan == 3) // image in RGB
                {

                    // obter apontador do inicio da imagem MIplImage m = img.MIplImage; byte* dataPtr = (byte*)m.imageData.ToPointer();
                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        { // calcula endereço do pixel no ponto (x,y)

                            blue = (dataPtr + y * widthStep + x * nChan)[0];
                            green = (dataPtr + y * widthStep + x * nChan)[1];
                            red = (dataPtr + y * widthStep + x * nChan)[2];

                            hist[0, (int)Math.Round((blue + green + red) / 3.0)] += 1;
                            hist[1, blue] += 1;
                            hist[2, green] += 1;
                            hist[3, red] += 1;
                        }
                    }
                }
                return hist;
            }
        }

        public static int Areas(int x, int y, int height, int width, int[,] pixelMatrix, int[] areas)
        {
            int a = 0;
            int Nobjects = 0;

            for (y = 1; y < height - 1; y++)
            {
                for (x = 1; x < width - 1; x++)
                {
                    if (pixelMatrix[x, y] != 0)
                    {
                        a = pixelMatrix[x, y];
                        areas[a] += 1;
                        if (areas[a] == 1) { Nobjects +=1; } // a segunda condição torna o código mais rápido
                    }
                }
            }
            return Nobjects;
        }
        public static void ConvertToBW(Emgu.CV.Image<Bgr, byte> img, int threshold)
        {
            unsafe
            {
                MIplImage m = img.MIplImage;
                byte* dataPtr = (byte*)m.imageData.ToPointer();
                byte blue, green, red;
                int width = img.Width;
                int height = img.Height;
                int nChan = m.nChannels;
                int npi = width * height;
                int x, y = 0;
                double gray;

                for (y = 0; y < height; y++)
                {
                    for (x = 0; x < width; x++)
                    {
                        blue = (dataPtr + y * m.widthStep + x * nChan)[0];
                        green = (dataPtr + y * m.widthStep + x * nChan)[1];
                        red = (dataPtr + y * m.widthStep + x * nChan)[2];

                        gray = (double)Math.Round((blue + green + red) / 3.0);

                        if (gray >= threshold)
                        {
                            (dataPtr + y * m.widthStep + x * nChan)[0] = 255;
                            (dataPtr + y * m.widthStep + x * nChan)[1] = 255;
                            (dataPtr + y * m.widthStep + x * nChan)[2] = 255;
                        }

                        else
                        {
                            (dataPtr + y * m.widthStep + x * nChan)[0] = 0;
                            (dataPtr + y * m.widthStep + x * nChan)[1] = 0;
                            (dataPtr + y * m.widthStep + x * nChan)[2] = 0;
                        }
                    }
                }

            }

        }

        public static void ConvertToBW_Otsu(Emgu.CV.Image<Bgr, byte> img)
        {
            unsafe
            {
                int total = 0;
                int[] histogram = Histogram_Gray(img);
                double[] Phistogram = new double[256];

                for (int i = 0; i <= 255; i++)
                {
                    total += histogram[i];
                }


                double q1 = histogram[0];
                double q2 = total - q1;

                double u1 = 0;
                double u2 = 0;

                double max = 0;
                int threshold = 1;

                for (int i = 1; i <= 255; i++)
                {
                    u2 += i * histogram[i];
                }

                double var = q1 * q2 * Math.Pow((u1 - u2 / q2), 2);

                for (int t = 1; t < 256; t++)
                {

                    if (var >= max)
                    {
                        max = var;
                        threshold = t;
                    }

                    q1 += histogram[t];
                    q2 -= histogram[t];
                    u1 += t * histogram[t];
                    u2 -= t * histogram[t];
                    var = q1 * q2 * Math.Pow(((u1 / q1 - u2 / q2)), 2);

                }
                ConvertToBW(img, threshold);
            }
        }

        public static void ConvertToBW_HSV(Emgu.CV.Image<Bgr, byte> img, int color)   //0 for red, 1 for black
        {
            unsafe
            {
                MIplImage m = img.MIplImage;
                byte* dataPtr = (byte*)m.imageData.ToPointer();
                double max, min, b, r, g;
                double hue = 0, sat = 0, val = 0;
                int y, x;
                int width = img.Width;
                int height = img.Height;
                int nChan = m.nChannels;
                int npi = width * height;

                for (y = 0; y < height; y++)
                {
                    for (x = 0; x < width; x++)
                    {
                        b = (double)((dataPtr + y * m.widthStep + x * nChan)[0]) / 255;
                        g = (double)((dataPtr + y * m.widthStep + x * nChan)[1]) / 255;
                        r = (double)((dataPtr + y * m.widthStep + x * nChan)[2]) / 255;

                        max = Math.Max(b, Math.Max(g, r));
                        min = Math.Min(b, Math.Min(g, r));

                        val = max;
                        if (color == 1)
                        {
                            if (val <= 0.3)
                            {
                                (dataPtr + y * m.widthStep + x * nChan)[0] = 255;
                                (dataPtr + y * m.widthStep + x * nChan)[1] = 255;
                                (dataPtr + y * m.widthStep + x * nChan)[2] = 255;
                            }
                            else
                            {
                                (dataPtr + y * m.widthStep + x * nChan)[0] = 0;
                                (dataPtr + y * m.widthStep + x * nChan)[1] = 0;
                                (dataPtr + y * m.widthStep + x * nChan)[2] = 0;
                            }
                        }
                        if (color == 0)
                        {
                            if (max != 0)
                            {
                                sat = (max - min) / max;
                                if (max == r)
                                {
                                    hue = 60 * (g - b) / (max - min);
                                }
                                if (max == g)
                                {
                                    hue = 60 * (b - r) / (max - min) + 120;
                                }

                                if (max == b)
                                {
                                    hue = 60 * (r - g) / (max - min) + 240;
                                }
                            }
                            if (hue < 0)
                            {
                                hue += 360;
                            }

                            else if (hue > 360)
                            {
                                hue -= 360;
                            }
                            if ((hue >= 340 || hue <= 10) && (sat >= 0.29) && (val >= 0.29))
                            {
                                (dataPtr + y * m.widthStep + x * nChan)[0] = 255;
                                (dataPtr + y * m.widthStep + x * nChan)[1] = 255;
                                (dataPtr + y * m.widthStep + x * nChan)[2] = 255;
                            }
                            else
                            {
                                (dataPtr + y * m.widthStep + x * nChan)[0] = 0;
                                (dataPtr + y * m.widthStep + x * nChan)[1] = 0;
                                (dataPtr + y * m.widthStep + x * nChan)[2] = 0;
                            }
                        }
                    }
                }
            }
        }

        public static void CompLigadas(int height, int width, int[,] pixelMatrix)
        {
            unsafe
            {
                int[] neighbourhood = new int[9];
                bool changed = false;
                int x, y;
                int currentValue;
                int min;

                while (changed == false)
                {
                    changed = false;
                    for (y = 1; y < height - 1; y++)
                    {
                        for (x = 1; x < width - 1; x++)
                        {
                            neighbourhood[0] = pixelMatrix[x - 1, y - 1];
                            neighbourhood[1] = pixelMatrix[x, y - 1];
                            neighbourhood[2] = pixelMatrix[x + 1, y - 1];
                            neighbourhood[3] = pixelMatrix[x - 1, y];
                            neighbourhood[4] = pixelMatrix[x, y];
                            neighbourhood[5] = pixelMatrix[x + 1, y];
                            neighbourhood[6] = pixelMatrix[x - 1, y + 1];
                            neighbourhood[7] = pixelMatrix[x, y + 1];
                            neighbourhood[8] = pixelMatrix[x + 1, y + 1];

                            if (pixelMatrix[x, y] != 0)
                            {
                                currentValue = pixelMatrix[x, y];
                                min = neighbourhood.Where(f => f > 0).Min();
                                pixelMatrix[x, y] = (int)min;
                                if (pixelMatrix[x, y] != currentValue)
                                {
                                    changed = true;
                                }
                            }
                        }
                    }
                    if (changed == true)
                    {
                        changed = false;
                        for (y = height - 2; y >= 1; y--)
                        {
                            for (x = width - 2; x >= 1; x--)
                            {
                                neighbourhood[0] = pixelMatrix[x - 1, y - 1];
                                neighbourhood[1] = pixelMatrix[x, y - 1];
                                neighbourhood[2] = pixelMatrix[x + 1, y - 1];
                                neighbourhood[3] = pixelMatrix[x - 1, y];
                                neighbourhood[4] = pixelMatrix[x, y];
                                neighbourhood[5] = pixelMatrix[x + 1, y];
                                neighbourhood[6] = pixelMatrix[x - 1, y + 1];
                                neighbourhood[7] = pixelMatrix[x, y + 1];
                                neighbourhood[8] = pixelMatrix[x + 1, y + 1];
                                if (pixelMatrix[x, y] != 0)
                                {
                                    currentValue = pixelMatrix[x, y];
                                    min = neighbourhood.Where(f => f > 0).Min();
                                    pixelMatrix[x, y] = (int)min;
                                    if (pixelMatrix[x, y] != currentValue)
                                    {
                                        changed = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }



        /// <summary>
        /// Traffic Signs Detection
        /// </summary>
        /// <param name="img">Input image</param>
        /// <param name="imgCopy">Image Copy</param>
        /// <param name="limitSign">List of speed limit value and positions (speed limit value, Left-x,Top-y,Right-x,Bottom-y) of all detected limit signs</param>
        /// <param name="warningSign">List of value (-1) and positions (-1, Left-x, Top-y, Right-x, Bottom-y) of all detected warning signs</param>
        /// <param name="prohibitionSign">List of value (-1) and positions (-1, Left-x, Top-y, Right-x, Bottom-y) of all detected prohibition signs</param>
        /// <param name="level">Image Level</param>
        /// <returns>image with traffic signs detected</returns>
        public static Image<Bgr, byte> Signs(
            Image<Bgr, byte> img,
            Image<Bgr, byte> imgCopy,
            out List<string[]> limitSign,
            out List<string[]> warningSign,
            out List<string[]> prohibitionSign,
            int level)
        {

            unsafe
            {
                limitSign = new List<string[]>();
                warningSign = new List<string[]>();
                prohibitionSign = new List<string[]>();

                //string[] dummy_vector1 = new string[5];
                //dummy_vector1[0] = "70"; // Speed limit
                //dummy_vector1[1] = "1160"; // Left-x
                //dummy_vector1[2] = "330"; // Top-y
                //dummy_vector1[3] = "1200"; // Right-x
                //dummy_vector1[4] = "350"; // Bottom-y
                //string[] dummy_vector2 = new string[5];
                //dummy_vector2[0] = "-1"; // value -1
                //dummy_vector2[1] = "669"; // Left-x
                //dummy_vector2[2] = "469"; // Top-y
                //dummy_vector2[3] = "680"; // Right-x
                //dummy_vector2[4] = "480"; // Bottom-y
                string[] dummy_vector3 = new string[5];
                //dummy_vector3[0] = "-1"; // value -1
                //dummy_vector3[1] = "669"; // Left-x
                //dummy_vector3[2] = "469"; // Top-y
                //dummy_vector3[3] = "680"; // Right-x
                //dummy_vector3[4] = "480"; // Bottom-y

                //limitSign.Add(dummy_vector1);
                //warningSign.Add(dummy_vector2);
                //prohibitionSign.Add(dummy_vector3);



                ////ISTO DEPOIS TEM DE SER ALTERADO - o path é suposto ser em relaão a ste ficheiro, nãoà minha pasta
                Image<Bgr, Byte> digit_0 = new Image<Bgr, Byte>("C:\\Users\\Daniel Santos\\OneDrive\\António\\SS\\projeto\\Imagens\\0.png");
                MIplImage d0m = digit_0.MIplImage;
                byte* D0dataPtr = (byte*)d0m.imageData.ToPointer();
                Image<Bgr, Byte> digit_1 = new Image<Bgr, Byte>("C:\\Users\\Daniel Santos\\OneDrive\\António\\SS\\projeto\\Imagens\\0.png");
                MIplImage d1m = digit_1.MIplImage;
                byte* D1dataPtr = (byte*)d1m.imageData.ToPointer();
                Image<Bgr, Byte> digit_2 = new Image<Bgr, Byte>("C:\\Users\\Daniel Santos\\OneDrive\\António\\SS\\projeto\\Imagens\\0.png");
                MIplImage d2m = digit_2.MIplImage;
                byte* D2dataPtr = (byte*)d2m.imageData.ToPointer();
                Image<Bgr, Byte> digit_3 = new Image<Bgr, Byte>("C:\\Users\\Daniel Santos\\OneDrive\\António\\SS\\projeto\\Imagens\\0.png");
                MIplImage d3m = digit_3.MIplImage;
                byte* D3dataPtr = (byte*)d3m.imageData.ToPointer();
                Image<Bgr, Byte> digit_4 = new Image<Bgr, Byte>("C:\\Users\\Daniel Santos\\OneDrive\\António\\SS\\projeto\\Imagens\\0.png");
                MIplImage d4m = digit_4.MIplImage;
                byte* D4dataPtr = (byte*)d4m.imageData.ToPointer();
                Image<Bgr, Byte> digit_5 = new Image<Bgr, Byte>("C:\\Users\\Daniel Santos\\OneDrive\\António\\SS\\projeto\\Imagens\\0.png");
                MIplImage d5m = digit_5.MIplImage;
                byte* D5dataPtr = (byte*)d5m.imageData.ToPointer();
                Image<Bgr, Byte> digit_6 = new Image<Bgr, Byte>("C:\\Users\\Daniel Santos\\OneDrive\\António\\SS\\projeto\\Imagens\\0.png");
                MIplImage d6m = digit_6.MIplImage;
                byte* D6dataPtr = (byte*)d6m.imageData.ToPointer();
                Image<Bgr, Byte> digit_7 = new Image<Bgr, Byte>("C:\\Users\\Daniel Santos\\OneDrive\\António\\SS\\projeto\\Imagens\\0.png");
                MIplImage d7m = digit_7.MIplImage;
                byte* D7dataPtr = (byte*)d7m.imageData.ToPointer();
                Image<Bgr, Byte> digit_8 = new Image<Bgr, Byte>("C:\\Users\\Daniel Santos\\OneDrive\\António\\SS\\projeto\\Imagens\\0.png");
                MIplImage d8m = digit_8.MIplImage;
                byte* D8dataPtr = (byte*)d8m.imageData.ToPointer();
                Image<Bgr, Byte> digit_9 = new Image<Bgr, Byte>("C:\\Users\\Daniel Santos\\OneDrive\\António\\SS\\projeto\\Imagens\\0.png");
                MIplImage d9m = digit_9.MIplImage;
                byte* D9dataPtr = (byte*)d9m.imageData.ToPointer();

                MIplImage m = img.MIplImage;
                byte* dataPtr = (byte*)m.imageData.ToPointer();
                MIplImage Copym = imgCopy.MIplImage;
                byte* CopydataPtr = (byte*)Copym.imageData.ToPointer();
                int width = img.Width;
                int height = img.Height;
                int nChan = m.nChannels;
                int npi = width * height;
                int x=0, y=0;

                int pixelValue;
                int[,] pixelMatrix = new int[width, height];
                int tag = 1;



                ConvertToBW_HSV(img, 0);


                for (y = 0; y < height; y++)
                {
                    for (x = 0; x < width; x++)
                    {
                        pixelValue = (dataPtr + y * m.widthStep + x * nChan)[0];

                        if (pixelValue == 255)
                        {
                            pixelMatrix[x, y] = tag;
                            tag += 1;
                        }

                        else
                        {
                            pixelMatrix[x, y] = 0;
                        }
                    }
                }

                CompLigadas(height, width, pixelMatrix);

                //Teste Colorífico do Algoritmo de Componentes Ligados (APAGAR DEPOIS)

                //for (y = 1; y < height - 1; y++)
                //{
                //    for (x = 1; x < width - 1; x++)
                //    {
                //        if (pixelMatrix[x, y] != 0)
                //        {
                //            (dataPtr + y * m.widthStep + x * nChan)[0] = (byte)(pixelMatrix[x, y] + 30);
                //            (dataPtr + y * m.widthStep + x * nChan)[1] = (byte)(pixelMatrix[x, y] - 5);
                //            (dataPtr + y * m.widthStep + x * nChan)[2] = (byte)(pixelMatrix[x, y] * 2);
                //        }
                //    }

                //}

                //Encontrar o Objecto que Precisamos

                //Cálculo das Áreas dos objectos econtrados e número de objectos diferentes

                int[] areas = new int[npi];
                int Nobjects = Areas(x, y, height, width, pixelMatrix, areas);
                int counter0 = 0;
                int a =0;
                byte blue, green, red;
                int[] digits=new int[10];

                while (counter0 < Nobjects) {
                    
                    if (areas[a] != 0) { counter0 += 1; }
                    if (areas[a] >= 500)
                    {
                        int counter1 = 0;
                        int minx = width;
                        int maxx = 0;
                        int miny = height;
                        int maxy = 0;
                        for (y = 1; y < height - 1; y++)
                        {
                            for (x = 1; x < width - 1; x++)
                            {
                                if (pixelMatrix[x, y] == a)
                                {
                                    if (x <= minx) { minx = x; }
                                    if (x >= maxx) { maxx = x; }
                                    if (y <= miny) { miny = y; }
                                    if (y >= maxy) { maxy = y; }
                                }
                                if (x <= maxx && x >= minx && y <= maxy && y >= miny)
                                {
                                    blue = (CopydataPtr + y * Copym.widthStep + x * nChan)[0];
                                    green = (CopydataPtr + y * Copym.widthStep + x * nChan)[1];
                                    red = (CopydataPtr + y * Copym.widthStep + x * nChan)[2];

                                    (dataPtr + y * m.widthStep + x * nChan)[0] = blue;
                                    (dataPtr + y * m.widthStep + x * nChan)[1] = green;
                                    (dataPtr + y * m.widthStep + x * nChan)[2] = red;
                                }
                                else
                                {
                                    (dataPtr + y * m.widthStep + x * nChan)[0] = 255;
                                    (dataPtr + y * m.widthStep + x * nChan)[1] = 255;
                                    (dataPtr + y * m.widthStep + x * nChan)[2] = 255;
                                }
                            }
                        }
                        ConvertToBW_HSV(img, 1);   // a segmentação não está perfeita mas estou demasiado cansado para ver fazer isto

                        for (y = miny; y < maxy; y++)
                        {
                            for (x = minx; x < maxx; x++)
                            {
                                pixelValue = (dataPtr + y * m.widthStep + x * nChan)[0];
                                if (pixelValue == 255)
                                {
                                    pixelMatrix[x, y] = tag;
                                    tag += 1;
                                }

                                else
                                {
                                    pixelMatrix[x, y] = 0;
                                }
                            }
                        }
                        //string lasttxt = "";
                        //int dx = maxx - minx;
                        //int dy = maxy - miny;
                        //CompLigadas(dy, dx, pixelMatrix);
                        //int[] letterAreas = new int[dy * dx];
                        //int Nletters = Areas(x, y, dy, dx, pixelMatrix, letterAreas); // especializar porque só preciso no maximo de 3 areas, neste caso
                        //while (counter1 < Nletters)
                        //{
                        //    if (areas[a] != 0) { counter0 += 1; }
                        //    if (areas[a] >= 500)
                        //    {
                        //        int gray = 0;
                        //        int grayD0 = 0;
                        //        int grayD1 = 0;
                        //        int grayD2 = 0;
                        //        int grayD3 = 0;
                        //        int grayD4 = 0;
                        //        int grayD5 = 0;
                        //        int grayD6 = 0;
                        //        int grayD7 = 0;
                        //        int grayD8 = 0;
                        //        int grayD9 = 0;

                        //        int lminx = dx;
                        //        int lmaxx = 0;
                        //        int lminy = dy;
                        //        int lmaxy = 0;
                                
                        //        for (y = miny; y < maxy; y++)
                        //        {
                        //            for (x = minx; x < maxx; x++)
                        //            {
                        //                if (pixelMatrix[x, y] == a)
                        //                {
                        //                    if (x <= lminx) { lminx = x; }
                        //                    if (x >= lmaxx) { lmaxx = x; }
                        //                    if (y <= lminy) { lminy = y; }
                        //                    if (y >= lmaxy) { lmaxy = y; }
                        //                }
                        //            }
                        //        }
                        //        for (y = lminy; y < lmaxy; y++)
                        //        {
                        //            for (x = lminx; x < lmaxx; x++)
                        //            {
                        //                gray = (int)Math.Round(((int)(CopydataPtr + y * Copym.widthStep + x * nChan)[0]+(int)(CopydataPtr + y * Copym.widthStep + x * nChan)[1]+(int)(CopydataPtr + y * Copym.widthStep + x * nChan)[2]) / 3.0);
                        //                grayD0 += gray - (int)Math.Round(((int)(D0dataPtr + y * d0m.widthStep + x * nChan)[0] + (int)(D0dataPtr + y * d0m.widthStep + x * nChan)[1] + (int)(D0dataPtr + y * d0m.widthStep + x * nChan)[2]) / 3.0);
                        //                grayD1 += gray - (int)Math.Round(((int)(D1dataPtr + y * d1m.widthStep + x * nChan)[0] + (int)(D1dataPtr + y * d1m.widthStep + x * nChan)[1] + (int)(D1dataPtr + y * d1m.widthStep + x * nChan)[2]) / 3.1);
                        //                grayD2 += gray - (int)Math.Round(((int)(D2dataPtr + y * d2m.widthStep + x * nChan)[0] + (int)(D2dataPtr + y * d2m.widthStep + x * nChan)[1] + (int)(D2dataPtr + y * d2m.widthStep + x * nChan)[2]) / 3.0);
                        //                grayD3 += gray - (int)Math.Round(((int)(D3dataPtr + y * d3m.widthStep + x * nChan)[0] + (int)(D3dataPtr + y * d3m.widthStep + x * nChan)[1] + (int)(D3dataPtr + y * d3m.widthStep + x * nChan)[2]) / 3.0);
                        //                grayD4 += gray - (int)Math.Round(((int)(D4dataPtr + y * d4m.widthStep + x * nChan)[0] + (int)(D4dataPtr + y * d4m.widthStep + x * nChan)[1] + (int)(D4dataPtr + y * d4m.widthStep + x * nChan)[2]) / 3.0);
                        //                grayD5 += gray - (int)Math.Round(((int)(D5dataPtr + y * d5m.widthStep + x * nChan)[0] + (int)(D5dataPtr + y * d5m.widthStep + x * nChan)[1] + (int)(D5dataPtr + y * d5m.widthStep + x * nChan)[2]) / 3.0);
                        //                grayD6 += gray - (int)Math.Round(((int)(D6dataPtr + y * d6m.widthStep + x * nChan)[0] + (int)(D6dataPtr + y * d6m.widthStep + x * nChan)[1] + (int)(D6dataPtr + y * d6m.widthStep + x * nChan)[2]) / 3.0);
                        //                grayD7 += gray - (int)Math.Round(((int)(D7dataPtr + y * d7m.widthStep + x * nChan)[0] + (int)(D7dataPtr + y * d7m.widthStep + x * nChan)[1] + (int)(D7dataPtr + y * d7m.widthStep + x * nChan)[2]) / 3.0);
                        //                grayD8 += gray - (int)Math.Round(((int)(D8dataPtr + y * d8m.widthStep + x * nChan)[0] + (int)(D8dataPtr + y * d8m.widthStep + x * nChan)[1] + (int)(D8dataPtr + y * d8m.widthStep + x * nChan)[2]) / 3.0);
                        //                grayD9 += gray - (int)Math.Round(((int)(D9dataPtr + y * d9m.widthStep + x * nChan)[0] + (int)(D9dataPtr + y * d9m.widthStep + x * nChan)[1] + (int)(D9dataPtr + y * d9m.widthStep + x * nChan)[2]) / 3.0);
                        //            }
                        //        }
                        //        int i,j;
                        //        string txt = "0";
                        //        int[] grayD ={ grayD0, grayD1, grayD2, grayD3,grayD4,grayD5,grayD6,grayD7,grayD8,grayD9};
                        //        for (i=0; i<9; i++)
                        //        {
                        //            if (grayD[i]<= grayD[i + 1])
                        //            { 
                        //                grayD[i + 1] = grayD[i];
                        //                txt=grayD[i + 1].ToString();
                        //            }
                        //        }
                        //        lasttxt += txt;
                        //    }
                        //}
                        string[] dummy_vector = { "-1", minx.ToString(), miny.ToString(), maxx.ToString(), maxy.ToString() };

                        prohibitionSign.Add(dummy_vector);
                    }

                    
                    a += 1;
                }

                for (y = 0; y < height - 1; y++)
                {
                    for (x = 0; x < width; x++)
                    {
                        blue = (CopydataPtr + y * Copym.widthStep + x * nChan)[0];
                        green = (CopydataPtr + y * Copym.widthStep + x * nChan)[1];
                        red = (CopydataPtr + y * Copym.widthStep + x * nChan)[2];

                        (dataPtr + y * m.widthStep + x * nChan)[0] = blue;
                        (dataPtr + y * m.widthStep + x * nChan)[1] = green;
                        (dataPtr + y * m.widthStep + x * nChan)[2] = red;
                    }
                }

                int squares;
                for (squares = 0; squares < prohibitionSign.Count(); squares++)
                {
                    string[] tempView = prohibitionSign[squares];
                    for (y = 0; y < height ; y++)
                    {
                        for (x = 0; x < width; x++)
                        {
                            if ((x <= Convert.ToInt32(tempView[3]) && x >= Convert.ToInt32(tempView[1]) && (y == Convert.ToInt32(tempView[4]) || y == Convert.ToInt32(tempView[2]))) || (y <= Convert.ToInt32(tempView[4]) && y >= Convert.ToInt32(tempView[2]) && (x == Convert.ToInt32(tempView[3]) || x == Convert.ToInt32(tempView[1]))))
                            {
                                (dataPtr + y * m.widthStep + x * nChan)[0] = (byte)0;
                                (dataPtr + y * m.widthStep + x * nChan)[1] = (byte)0;
                                (dataPtr + y * m.widthStep + x * nChan)[2] = (byte)255;
                            }
                        }
                    }
                }

                Image<Bgr, byte> lastimg = img;

                //int minx = width; // acho que ele disse na aula que não convem fazer-se assism
                //int maxx = 0;
                //int miny = height;
                //int maxy = 0;

                ////fazer o rectangulo
                //for (y = 1; y < height - 1; y++)
                //{
                //    for (x = 1; x < width - 1; x++)
                //    {
                //        if (pixelMatrix[x, y] == maxObject)
                //        {
                //            if (x <= minx) { minx = x; }
                //            if (x >= maxx) { maxx = x; }
                //            if (y <= miny) { miny = y; }
                //            if (y >= maxy) { maxy = y; }
                //        }
                //    }
                //}
                //dummy_vector1[0] = "-1";
                //dummy_vector1[1] = minx.ToString();
                //dummy_vector1[2] = miny.ToString();
                //dummy_vector1[3] = maxx.ToString();
                //dummy_vector1[4] = miny.ToString();



                //// Isto tambem é para apagar
                //for (y = 0; y < height - 1; y++)
                //{
                //    for (x = 0; x < width; x++)
                //    {
                //        if (x==maxx || x==minx|| y==maxy||y==miny)
                //        {
                //            (dataPtr + y * m.widthStep + x * nChan)[0] = (byte)0;
                //            (dataPtr + y * m.widthStep + x * nChan)[1] = (byte)0;
                //            (dataPtr + y * m.widthStep + x * nChan)[2] = (byte)0;
                //        }
                //    }
                //}






                //int dx = maxx - minx;
                //int dy = maxy - miny;

                //Image<Bgr, Byte> prohibition_signal = new Image<Bgr, Byte>(maxx - minx, maxy - miny);
                //MIplImage m0 = prohibition_signal.MIplImage;
                //byte* Prohib_dataPtr = (byte*)m0.imageData.ToPointer();

                ////select ROI
                //for (y = miny; y < maxy; y++)
                //{
                //    for (x = minx; x < maxx; x++)
                //    {
                //        blue = (CopydataPtr + y * Copym.widthStep + x * nChan)[0];
                //        green = (CopydataPtr + y * Copym.widthStep + x * nChan)[1];
                //        red = (CopydataPtr + y * Copym.widthStep + x * nChan)[2];

                //        (Prohib_dataPtr + (y - miny) * m0.widthStep + (x - minx) * nChan)[0] = blue;
                //        (Prohib_dataPtr + (y - miny) * m0.widthStep + (x - minx) * nChan)[1] = green;
                //        (Prohib_dataPtr + (y - miny) * m0.widthStep + (x - minx) * nChan)[2] = red;
                //    }
                //}
                //int threshold = 60;
                //ConvertToBW(prohibition_signal, threshold);

                //img = prohibition_signal;



                //Negative(prohibition_signal);
                //// a seguir é igual

                ////ALGORITMO DE COMPONENTES LIGADOS

                ////1 - Inicialização de Etiquetas

                //int[,] pixelMatrix0 = new int[dx, dy];

                //for (y = 0; y < dy; y++)
                //{
                //    for (x = 0; x < dx; x++)
                //    {
                //        pixelValue = (Prohib_dataPtr + y * m0.widthStep + x * nChan)[0];
                //        if (pixelValue == 255)
                //        {
                //            pixelMatrix0[x, y] = tag;
                //            tag += 1;
                //        }
                //        else
                //        {
                //            pixelMatrix0[x, y] = 0;
                //        }
                //    }
                //}

                //CompLigadas(dy, dx, pixelMatrix0);

                //////Teste Colorífico do Algoritmo de Componentes Ligados (APAGAR DEPOIS)

                //for (y = 1; y < dy - 1; y++)
                //{
                //    for (x = 1; x < dx - 1; x++)
                //    {
                //        if (pixelMatrix0[x, y] != 0)
                //        {
                //            (Prohib_dataPtr + y * m0.widthStep + x * nChan)[0] = (byte)(pixelMatrix0[x, y] + 30);
                //            (Prohib_dataPtr + y * m0.widthStep + x * nChan)[1] = (byte)(pixelMatrix0[x, y] - 5);
                //            (Prohib_dataPtr + y * m0.widthStep + x * nChan)[2] = (byte)(pixelMatrix0[x, y] * 2);
                //        }
                //    }

                //}

                //img = prohibition_signal;
                //////Encontrar o Objecto que Precisamos

                //////Cálculo das Áreas dos objectos econtrados e número de objectos diferentes

                //int[] areas0 = new int[npi];
                //int a0 = 0;
                //int maxObject0 = 0;
                //int maxObject1 = 0;

                //for (y = 1; y < dy; y++)
                //{
                //    for (x = 1; x < dx; x++)
                //    {
                //        if (pixelMatrix0[x, y] != 0)
                //        {
                //            a0 = pixelMatrix0[x, y];
                //            areas0[a0] += 1;
                //            if (areas0[a0] > areas[maxObject1] && a0 != maxObject1 && a0 != maxObject0)
                //            {
                //                if (areas0[a0] > areas[maxObject0])
                //                {
                //                    maxObject1 = maxObject0;
                //                    maxObject0 = a0;
                //                }
                //                else
                //                {
                //                    maxObject1 = a0;
                //                }
                //            }
                //        }
                //    }
                //}

                //bool estaMal = (maxObject0 == maxObject1);
                //int areade0 = areas[maxObject0];


                //int minx0 = dx; // acho que ele disse na aula que não convem fazer-se assism
                //int maxx0 = 0;
                //int miny0 = dy;
                //int maxy0 = 0;



                ////fazer o rectangulo
                //for (y = 1; y < dy - 1; y++)
                //{
                //    for (x = 1; x < dx - 1; x++)
                //    {
                //        if (pixelMatrix0[x, y] == maxObject1)
                //        {
                //            if (x <= minx0) { minx0 = x; }
                //            if (x >= maxx0) { maxx0 = x; }
                //            if (y <= miny0) { miny0 = y; }
                //            if (y >= maxy0) { maxy0 = y; }
                //        }
                //    }
                //}

                //dummy_vector2[0] = "-1";
                //dummy_vector2[1] = minx0.ToString();
                //dummy_vector2[2] = miny0.ToString();
                //dummy_vector2[3] = maxx0.ToString();
                //dummy_vector2[4] = miny0.ToString();



                //// Isto tambem é para apagar
                //for (y = 0; y < dy - 1; y++)
                //{
                //    for (x = 0; x < dx - 1; x++)
                //    {
                //        if (x == minx0 || x == maxx0 || y == miny0 || y == maxy0)
                //        {
                //            (Prohib_dataPtr + y * m0.widthStep + x * nChan)[0] = (byte)0;
                //            (Prohib_dataPtr + y * m0.widthStep + x * nChan)[1] = (byte)0;
                //            (Prohib_dataPtr + y * m0.widthStep + x * nChan)[2] = (byte)255;
                //        }
                //    }
                //}


                /*
                //Calcular Centroides

                int [] Cx = new int[Nobjects];
                int [] Cy = new int[Nobjects];
                int CoordX = 0;
                int CoordY = 0;
                int c = 0;

                for (a=0; a<npi; a++)
                {
                    if (areas[a] != 0)
                    {
                        for (y = 1; y < height - 1; y++)
                        {
                            for (x = 1; x < width - 1; x++)
                            {

                                if (pixelMatrix[x, y] == a)
                                {
                                    CoordX += x;
                                    CoordY += y;
                                }
                            }
                        }

                        Cx[c] = CoordX / areas[a];
                        Cy[c] = CoordY / areas[a];
                        c += 0;
                    }
                }*/


                //Encontrar pontos do Perimetro dos objectos econtrados. Calcular o Perimetro

                /*int P = 0;
                double FormFactor;                


                for(a=0; a<npi; a++)
                {
                    if (areas[a] != 0)
                    {
                        for (y = 1; y < height - 1; y++)
                        {
                            for (x = 1; x < width - 1; x++)
                            {
                                if (pixelMatrix[x, y] != 0 && pixelMatrix[x, y] == a)
                                {
                                    neighbourhood[0] = pixelMatrix[x - 1, y - 1];
                                    neighbourhood[1] = pixelMatrix[x, y - 1];
                                    neighbourhood[2] = pixelMatrix[x + 1, y - 1];
                                    neighbourhood[3] = pixelMatrix[x - 1, y];
                                    neighbourhood[4] = pixelMatrix[x, y];
                                    neighbourhood[5] = pixelMatrix[x + 1, y];
                                    neighbourhood[6] = pixelMatrix[x - 1, y + 1];
                                    neighbourhood[7] = pixelMatrix[x, y + 1];
                                    neighbourhood[8] = pixelMatrix[x + 1, y + 1];

                                    if (neighbourhood[1] == 0 ||
                                        neighbourhood[3] == 0 ||
                                        neighbourhood[5] == 0 || 
                                        neighbourhood[7] == 0)
                                    {
                                        P += 1;
                                    }
                                }
                            }
                        }

                        /*P = P - 1;
                        double pi=3.14159265359;
                        FormFactor = (4 * pi * areas[a]) / Math.Pow(P, 2);

                        if (FormFactor == 1)
                        {
                            for (y = 1; y < height - 1; y++)
                            {
                                for (x = 1; x < width - 1; x++)
                                {
                                    if (pixelMatrix[x, y] == a)
                                    {
                                        (dataPtr + y * m.widthStep + x * nChan)[0] = (byte)(pixelMatrix[x, y] + 30);
                                        (dataPtr + y * m.widthStep + x * nChan)[1] = (byte)(pixelMatrix[x, y] - 5);
                                        (dataPtr + y * m.widthStep + x * nChan)[2] = (byte)(pixelMatrix[x, y] * 2);
                                    }
                                }

                            }
                        }
                    }
                }*/
                img = lastimg;
                return img;
            }
        }
    }
}



