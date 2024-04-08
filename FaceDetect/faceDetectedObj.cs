using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceDetect
{
    public class faceDetectedObj
    {
        public Mat originalImg;
        public List<Rect> facesRectangle;
        public List<string> names = new List<string>();
    }
}
