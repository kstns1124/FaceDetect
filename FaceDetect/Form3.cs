using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.IO;
using System.Threading;
using OpenCvSharp.Face;


//REFerence
// https://github.com/antlancer-solutions/Simple-Face-Recognition-App-CS/blob/master/Simple%20Face%20Recognition%20App/Form1.cs
// https://blog.csdn.net/kuweicai/article/details/79306661

namespace FaceDetect
{
    public partial class Form3 : Form
    {
        #region 變數
        //private int testid = 0;
        private VideoCapture videoCapture = null;
        private Mat currentFrameA = null;
        private Mat currentFrameB = null;
        private Mat frame = new Mat();
        private bool facesDetectionEnabled = false;
        //private CascadeClassifier faceCasacdeClassifier = new CascadeClassifier(@"Data\haarcascade_frontalface_alt.xml");
        private CascadeClassifier faceCasacdeClassifier = new CascadeClassifier(@"Data\haarcascade_frontalface_alt2.xml");
        //private CascadeClassifier faceCasacdeClassifier = new CascadeClassifier(@"Data\haarcascade_frontalface_defaults.xml");
        //private CascadeClassifier faceCasacdeClassifier = new CascadeClassifier(@"Data\lbpcascade_frontalface.xml");
        //private CascadeClassifier faceCasacdeClassifier = new CascadeClassifier(@"Data\lbpcascade_frontalface_improved.xml");
        //private Mat faceResult = null;
        private List<Mat> TrainedFaces = new List<Mat>();
        private List<int> PersonsLabes = new List<int>();

        private bool EnableSaveImage = false;
        private bool isTrained = false;
        private OpenCvSharp.Face.FaceRecognizer recognizer;
        private List<string> PersonsNames = new List<string>();
        private Random rnd = new Random();
        private const double Threshold = 2000;
        #endregion

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // Face Reconizer Methods Setting
            string[] sMethods = new string[] { "EigenFaceReconizer", "FisherFaceReconizer", "LBPHFFaceReconizer" };
            cb_Reconizer.Items.AddRange(sMethods);
            cb_Reconizer.SelectedIndex = sMethods.Length - 1;
        }

        private void btn_Capture_Click(object sender, EventArgs e)
        {
            //Dispose of Capture if it was created before
            try
            {
                if (videoCapture != null)
                    videoCapture.Dispose();
            }
            catch(Exception ex)
            {

            }
            finally
            {
                videoCapture = new VideoCapture(CaptureDevice.Any, 0);
                Application.Idle += ProcessFrame;
            }
        }

        private void ProcessFrame(object sender, EventArgs e)
        {
            //Step 1: Video Capture
            if (videoCapture != null && videoCapture.CvPtr != IntPtr.Zero)
            {
                OpenCvSharp.Size DefaultSize = new OpenCvSharp.Size(picCapture.Width, picCapture.Height);
                frame = new Mat();
                videoCapture.Read(frame);
                currentFrameA = frame.Resize(
                    dsize: DefaultSize,
                    fx: 0,
                    fy: 0,
                    interpolation: InterpolationFlags.Cubic);
                currentFrameB = frame.Resize(
                    dsize: DefaultSize,
                    fx: 0,
                    fy: 0,
                    interpolation: InterpolationFlags.Cubic);

                //Step 2: Face Detection
                if (facesDetectionEnabled)
                {
                    //Convert from Bgr to Gray Image
                    //using (Mat grayImage = new Mat())
                    Mat grayImage = new Mat();
                    {
                        Cv2.CvtColor(currentFrameA, grayImage, ColorConversionCodes.BGR2GRAY);
                        //Enhance the image to get better result
                        Cv2.EqualizeHist(grayImage, grayImage);

                        Rect[] faces = faceCasacdeClassifier.DetectMultiScale(
                            image: grayImage,
                            scaleFactor: 1.1,
                            minNeighbors: 4,
                            flags: HaarDetectionType.DoRoughSearch | HaarDetectionType.ScaleImage,
                            minSize: new OpenCvSharp.Size(60, 60));

                        //Step 3: Add Person 
                        //Assign the face to the picture Box face picDetected
                        foreach (var face in faces)
                        {
                            //Draw square around each face
                            Cv2.Rectangle(currentFrameA, (Rect)face, Scalar.Red, 2);

                            if (EnableSaveImage)
                            {
                                //We will create a directory if does not exists!
                                string path = Directory.GetCurrentDirectory() + @"\TrainedImages";
                                if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                                //we will save 10 images with delay a second for each image 
                                //to avoid hang GUI we will create a new task
                                Task.Factory.StartNew(() =>
                                {
                                    for (int Times = 0; Times < 10; Times++)
                                    {
                                        Mat _frame = new Mat();
                                        videoCapture.Read(_frame);
                                        _frame = _frame.Resize(
                                            dsize: new OpenCvSharp.Size(picCapture.Width, picCapture.Height),
                                            fx: 0, fy: 0,
                                            interpolation: InterpolationFlags.Cubic);
                                        Cv2.CvtColor(_frame, _frame, ColorConversionCodes.BGR2GRAY);
                                        Cv2.EqualizeHist(_frame, _frame);

                                        //Mat _frame2 = _frame.Clone();
                                        Mat _frame2 = _frame.Clone(face);
                                        //resize the image then saving it
                                        string sfileName = $@"{path}\{txtPersonName.Text}_{DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss")}.jpg";
                                        _frame2.Resize(
                                            new OpenCvSharp.Size(200, 200), 0, 0, InterpolationFlags.Cubic
                                        ).SaveImage(sfileName);
                                        Thread.Sleep(1000);
                                    }
                                });

                            }
                            EnableSaveImage = false;
                            btn_Add.Enabled = true;

                            //if (btn_Add.InvokeRequired)
                            //{
                            //    btn_Add.Invoke(new ThreadStart(delegate {
                            //        btn_Add.Enabled = true;
                            //    }));
                            //}

                            // Step 5: Recognize the face 
                            if (isTrained)
                            {
                                Mat grayFaceResult = currentFrameA.Clone(face)
                                    .Resize(new OpenCvSharp.Size(200, 200), 0, 0, InterpolationFlags.Cubic);
                                Cv2.CvtColor(grayFaceResult, grayFaceResult, ColorConversionCodes.BGR2GRAY);
                                Cv2.EqualizeHist(grayFaceResult, grayFaceResult);
                                int result = recognizer.Predict(grayFaceResult);
                                //picCapture.Image = BitmapConverter.ToBitmap(grayFaceResult);
                                //picDetected.Image = BitmapConverter.ToBitmap(TrainedFaces[result]);
                                //Here results found known faces
                                if (result != -1 && result > 0 && result < 2000)
                                {
                                    Cv2.PutText(currentFrameA,
                                        PersonsNames[result] + ", " + result.ToString(),
                                        new OpenCvSharp.Point(face.X - 2, face.Y - 2),
                                        HersheyFonts.HersheyComplex,
                                        1.0,
                                        Scalar.Orange);
                                    Cv2.Rectangle(currentFrameA, face, Scalar.Green, 2);
                                }
                                //here results did not found any know faces
                                else
                                {
                                    Cv2.PutText(currentFrameA, "Unknown:" + result.ToString()
                                        , new OpenCvSharp.Point(face.X - 2, face.Y - 2)
                                        , HersheyFonts.HersheyComplex, 1.0, Scalar.Orange);
                                }
                                Cv2.Rectangle(currentFrameA, face, Scalar.Red, 2);
                            }
                        }
                    }
                    //Render the video capture into the Picture Box picCapture
                    picDetected.Image = BitmapConverter.ToBitmap(currentFrameA);
                }
                picCapture.Image = BitmapConverter.ToBitmap(currentFrameB);
            }

            //Dispose the Current Frame after processing it to reduce the memory consumption.
            if (currentFrameA != null) currentFrameA.Dispose();
            if (currentFrameB != null) currentFrameB.Dispose();
        }

        private void btn_Detect_Click(object sender, EventArgs e)
        {
            facesDetectionEnabled = true;
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            btn_Add.Enabled = false;
            EnableSaveImage = true;
        }

        private void btn_train_Click(object sender, EventArgs e)
        {
            TrainImagesFromDir();
        }

        //Step 4: train Images .. we will use the saved images from the previous example 
        private bool TrainImagesFromDir()
        {
            int ImagesCount = 0;
            TrainedFaces.Clear();
            PersonsLabes.Clear();
            PersonsNames.Clear();
            try
            {
                string path = Directory.GetCurrentDirectory() + @"\TrainedImages";
                foreach (var file in Directory.GetFiles(path, "*.jpg", SearchOption.AllDirectories))
                {
                    Mat trainedImage = new Mat(file).Resize(new OpenCvSharp.Size(200, 200),0, 0, InterpolationFlags.Cubic);
                    if (trainedImage.Channels() > 1)
                        Cv2.CvtColor(trainedImage, trainedImage, ColorConversionCodes.RGB2GRAY);
                    Cv2.EqualizeHist(trainedImage, trainedImage);
                    TrainedFaces.Add(trainedImage);
                    PersonsLabes.Add(ImagesCount);
                    string name = file.Split('\\').Last().Split('_')[0];
                    PersonsNames.Add(name);
                    ImagesCount++;
                }

                if (TrainedFaces.Count() > 0)
                {
                    if(cb_Reconizer.SelectedIndex == 0)
                        recognizer = EigenFaceRecognizer.Create(ImagesCount, Threshold);
                    else if(cb_Reconizer.SelectedIndex == 1)
                        recognizer = FisherFaceRecognizer.Create(ImagesCount, Threshold);
                    else
                        recognizer = LBPHFaceRecognizer.Create();
                    recognizer.Train(TrainedFaces.ToArray(), PersonsLabes.ToArray());

                    isTrained = true;
                    //Debug.WriteLine(ImagesCount);
                    //Debug.WriteLine(isTrained);
                    recognizer.Save(@"TrainedImages\face.yml");
                    return true;
                }
                else
                {
                    isTrained = false;
                    return false;
                }
            }
            catch (Exception ex)
            {
                isTrained = false;
                MessageBox.Show("Error in Train Images: " + ex.Message);
                return false;
            }
        }

        private void btn_Reconize_Click(object sender, EventArgs e)
        {
            int ImagesCount = 0;
            TrainedFaces.Clear();
            PersonsLabes.Clear();
            PersonsNames.Clear();
            try
            {
                string path = Directory.GetCurrentDirectory() + @"\TrainedImages";
                foreach (var file in Directory.GetFiles(path, "*.jpg", SearchOption.AllDirectories))
                {
                    Mat trainedImage = new Mat(file).Resize(new OpenCvSharp.Size(200, 200), 0, 0, InterpolationFlags.Cubic);
                    if (trainedImage.Channels() > 1)
                        Cv2.CvtColor(trainedImage, trainedImage, ColorConversionCodes.RGB2GRAY);
                    Cv2.EqualizeHist(trainedImage, trainedImage);
                    TrainedFaces.Add(trainedImage);
                    PersonsLabes.Add(ImagesCount);
                    string name = file.Split('\\').Last().Split('_')[0];
                    PersonsNames.Add(name);
                    ImagesCount++;
                }

                if (TrainedFaces.Count() >= 0)
                {
                    if (cb_Reconizer.SelectedIndex == 0)
                        recognizer = EigenFaceRecognizer.Create();
                    else if (cb_Reconizer.SelectedIndex == 1)
                        recognizer = FisherFaceRecognizer.Create();
                    else
                        recognizer = LBPHFaceRecognizer.Create();
                    recognizer.Read(@"TrainedImages\face.yml");

                    isTrained = true;
                    //Debug.WriteLine(ImagesCount);
                    //Debug.WriteLine(isTrained);
                    //recognizer.Save(@"\TrainedImages\face.yml");
                    return;
                }
                else
                {
                    isTrained = false;
                    return;
                }
            }
            catch (Exception ex)
            {
                isTrained = false;
                MessageBox.Show("Error in Train Images: " + ex.Message);
                return;
            }
        }
    }
}
