using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaceDetect
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            LoadImg();
        }

        private void btn_Open_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "請選擇圖檔";
            dialog.InitialDirectory = ".\\";
            dialog.Filter = "JPeg Image|*.jpg;*.jpeg;*.bmp;*.png;*.tif";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = dialog.FileName;
                LoadImg();
            }
        }

        private void LoadImg()
        {
            try
            {
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
            }
            catch { }

            using (Bitmap bmPic = new Bitmap(textBox1.Text))
                pictureBox1.Image = new Bitmap(bmPic);
        }

        private void btn_Detect_Click(object sender, EventArgs e)
        {
            var srcImage = new Mat(textBox1.Text);
            var grayImage = new Mat();
            if(srcImage.Channels() > 1)
                Cv2.CvtColor(srcImage, grayImage, ColorConversionCodes.BGRA2GRAY);
            Cv2.EqualizeHist(grayImage, grayImage);
            pictureBox3.Image = BitmapConverter.ToBitmap(grayImage);

            var cascade = new CascadeClassifier(@"Data\haarcascade_frontalface_alt.xml");
            var nestedCascade = new CascadeClassifier(@"Data\haarcascade_eye_tree_eyeglasses.xml");
            var faces = cascade.DetectMultiScale(
                image: grayImage,
                scaleFactor: 1.1,
                minNeighbors: 2,
                flags: HaarDetectionType.DoRoughSearch | HaarDetectionType.ScaleImage,
                minSize: new OpenCvSharp.Size(30, 30)
                );

            var rnd = new Random();
            var count = 1;
            foreach (var faceRect in faces)
            {
                var detectedFaceImage = new Mat(srcImage, faceRect);                
                var color = Scalar.FromRgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
                Cv2.Rectangle(srcImage, faceRect, color, 2);

                var detectedFaceGrayImage = new Mat();
                Cv2.CvtColor(detectedFaceImage, detectedFaceGrayImage, ColorConversionCodes.BGRA2GRAY);
                var nestedObjects = nestedCascade.DetectMultiScale(
                    image: detectedFaceGrayImage,
                    scaleFactor: 1.1,
                    minNeighbors: 2,
                    flags: HaarDetectionType.DoRoughSearch | HaarDetectionType.ScaleImage,
                    minSize: new OpenCvSharp.Size(30, 30));

                foreach (var nestedObject in nestedObjects)
                {
                    var center = new OpenCvSharp.Point
                    {
                        X = (int)(Math.Round(nestedObject.X + nestedObject.Width * 0.5, MidpointRounding.ToEven) + faceRect.Left),
                        Y = (int)(Math.Round(nestedObject.Y + nestedObject.Height * 0.5, MidpointRounding.ToEven) + faceRect.Top)
                    };
                    var radius = Math.Round((nestedObject.Width + nestedObject.Height) * 0.25, MidpointRounding.ToEven);
                    Cv2.Circle(srcImage, center, (int)radius, color, thickness: 3);
                }
                count++;
            }
            pictureBox2.Image = BitmapConverter.ToBitmap(srcImage);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var srcImage = new Mat(textBox1.Text);
            var grayImage = new Mat();
            if (srcImage.Channels() > 1)
                Cv2.CvtColor(srcImage, grayImage, ColorConversionCodes.BGRA2GRAY);
            Cv2.EqualizeHist(grayImage, grayImage);
            pictureBox3.Image = BitmapConverter.ToBitmap(grayImage);

            var cascade = new CascadeClassifier(@"Data\haarcascade_frontalface_alt.xml");
            var nestedCascade = new CascadeClassifier(@"Data\haarcascade_eye_tree_eyeglasses.xml");
            var faces = cascade.DetectMultiScale(
                image: grayImage,
                scaleFactor: 1.1,
                minNeighbors: 2,
                flags: HaarDetectionType.DoRoughSearch | HaarDetectionType.ScaleImage,
                minSize: new OpenCvSharp.Size(30, 30)
                );

            var rnd = new Random();
            var count = 1;
            foreach (var faceRect in faces)
            {
                var detectedFaceImage = new Mat(srcImage, faceRect);
                var color = Scalar.FromRgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
                Cv2.Blur(srcImage[faceRect], srcImage[faceRect], new OpenCvSharp.Size(11, 11));
                Cv2.Rectangle(srcImage, faceRect, color, 2);

                var detectedFaceGrayImage = new Mat();
                Cv2.CvtColor(detectedFaceImage, detectedFaceGrayImage, ColorConversionCodes.BGRA2GRAY);
                var nestedObjects = nestedCascade.DetectMultiScale(
                    image: detectedFaceGrayImage,
                    scaleFactor: 1.1,
                    minNeighbors: 2,
                    flags: HaarDetectionType.DoRoughSearch | HaarDetectionType.ScaleImage,
                    minSize: new OpenCvSharp.Size(30, 30));

                foreach (var nestedObject in nestedObjects)
                {
                    var center = new OpenCvSharp.Point
                    {
                        X = (int)(Math.Round(nestedObject.X + nestedObject.Width * 0.5, MidpointRounding.ToEven) + faceRect.Left),
                        Y = (int)(Math.Round(nestedObject.Y + nestedObject.Height * 0.5, MidpointRounding.ToEven) + faceRect.Top)
                    };
                    var radius = Math.Round((nestedObject.Width + nestedObject.Height) * 0.25, MidpointRounding.ToEven);
                    Cv2.Circle(srcImage, center, (int)radius, color, thickness: 3);
                }
                count++;
            }

            
            pictureBox2.Image = BitmapConverter.ToBitmap(srcImage);
        }
    }
}
