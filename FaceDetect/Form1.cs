using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Face;
using OpenCvSharp.Extensions;
using System.Threading;

namespace FaceDetect
{
    public partial class Form1 : Form
    {
        private const string m_sDirName = "trainedFaces";
        private string m_sDirPath = "";
        private List<Rect> faces = new List<Rect>();
        TrainedFaceReconizer tfr;
        Mat mtImg;
        VideoCapture capture;
        Mat frame;
        Bitmap image;
        private Thread camera;
        int isCameraRunning = 1;

        public enum FaceReconizerType
        {
            EigenFaceReconizer = 0,
            FisherFaceReconizer = 1,
            LBPHFFaceReconizer = 2,
        };

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            m_sDirPath = AppDomain.CurrentDomain.BaseDirectory;
            if (m_sDirPath[m_sDirPath.Length - 1] != '\\')
                m_sDirPath += "\\";
            m_sDirPath += m_sDirName;
            if(Directory.Exists(m_sDirPath) == false)
                Directory.CreateDirectory(m_sDirPath);

            comboBox1.SelectedIndex = 0;
            FaceReconizerType Type = FaceReconizerType.EigenFaceReconizer;
            tfr = SetTrainFaceReconizer(Type);

            camera = new Thread(new ThreadStart(CaptureCameraCallback));
            camera.Start();
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            capture.Release();
            isCameraRunning = 0;
        }

        private void CaptureCameraCallback()
        {
            frame = new Mat();
            capture = new VideoCapture();
            capture.Open(2);
            while (isCameraRunning == 1)
            {
                capture.Read(frame);
                image = BitmapConverter.ToBitmap(frame);
                pb_Show.Image = image;
                image = null;
            }
        }

        public TrainedFileList SetSampleFaceList()
        {
            TrainedFileList tf = new TrainedFileList();
            DirectoryInfo di = new DirectoryInfo(m_sDirPath);
            int i = 0;
            foreach(FileInfo fi in di.GetFiles())
            {
                tf.trainedImages.Add(BitmapConverter.ToMat((Bitmap)Image.FromFile(fi.FullName)));
                tf.trainedLabelOrder.Add(i);
                tf.trainedFileName.Add(fi.Name.Split('_')[0]);
                i += 1;
            }
            return tf;
        }

        public TrainedFaceReconizer SetTrainFaceReconizer(FaceReconizerType type)
        {
            tfr = new TrainedFaceReconizer();
            tfr.trainedFileList = SetSampleFaceList();
            switch (type)
            {
                case FaceReconizerType.EigenFaceReconizer:
                    tfr.faceReconizer = OpenCvSharp.Face.EigenFaceRecognizer.Create(80, double.PositiveInfinity);
                    break;
                case FaceReconizerType.FisherFaceReconizer:
                    tfr.faceReconizer = OpenCvSharp.Face.FisherFaceRecognizer.Create(80, 3500);
                    break;
                case FaceReconizerType.LBPHFFaceReconizer:
                    tfr.faceReconizer = OpenCvSharp.Face.EigenFaceRecognizer.Create(80);
                    break;
            }
            tfr.faceReconizer.Train(tfr.trainedFileList.trainedImages.ToArray()
                , tfr.trainedFileList.trainedLabelOrder.ToArray());
            
            return tfr;
        }

        public faceDetectedObj GetFaceRectangle(Mat mtImage)
        {
            faceDetectedObj fdo = new faceDetectedObj();
            fdo.originalImg = mtImage;
            try
            {
                using (Mat ugray = new Mat())
                {
                    //RGB To Gray
                    if(fdo.originalImg.Channels() != 1)
                        Cv2.CvtColor(fdo.originalImg, ugray, ColorConversionCodes.BGR2GRAY);
                    //Enhence Image
                    Cv2.EqualizeHist(ugray, ugray);

                    var cascade = new CascadeClassifier();
                    Rect[] facesDetected = cascade.DetectMultiScale(ugray
                        , 1.1
                        , 3
                        , HaarDetectionType.ScaleImage
                        , new OpenCvSharp.Size(30, 30));
                    faces.AddRange(facesDetected);
                }
            }
            catch { }
            fdo.facesRectangle = faces;
            return fdo;
        }

        public faceDetectedObj faceRecognize(Mat mtImage)
        {
            faceDetectedObj fdo = GetFaceRectangle(mtImage);
            Image img = BitmapConverter.ToBitmap(fdo.originalImg);
            using (Graphics G = Graphics.FromImage(img))
            {
                foreach (Rect R in faces)
                {
                    G.DrawRectangle(new Pen(Color.Red, 2), new Rectangle(R.X, R.Y, R.Width, R.Height));
                    Mat ugray = new Mat();
                    //RGB To Gray
                    if (fdo.originalImg.Channels() != 1)
                        Cv2.CvtColor(fdo.originalImg, ugray, ColorConversionCodes.BGR2GRAY);
                    //Enhence Image
                    Cv2.EqualizeHist(ugray, ugray);



                    int pr = tfr.faceReconizer.Predict(ugray);
                    string sName = tfr.trainedFileList.trainedFileName[pr];

                    Font font = new Font("微軟正黑體", 16, FontStyle.Regular, GraphicsUnit.Pixel);
                    SolidBrush fontLine = new SolidBrush(Color.Yellow);
                    float XP = R.X + (R.Width / 2 - (sName.Length * 14) / 2);
                    float YP = R.Y  - 21;
                    G.DrawString(sName, font, fontLine, new PointF(XP, YP));

                    fdo.names.Add(sName);
                }
            }
            return fdo;
        }
    }
}
