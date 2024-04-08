using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceDetect
{
    public class TrainedFileList
    {
        public List<Mat> trainedImages = new List<Mat>();
        public List<int> trainedLabelOrder = new List<int>();
        public List<string> trainedFileName = new List<string>();

        //public List<Image> TrainedImgs
        //{
        //    get { return trainedImages; }
        //    set { trainedImages = value; }
        //}

        //public List<int> TrainedLabOrd
        //{
        //    get { return trainedLabelOrder; }
        //    set { trainedLabelOrder = value; }
        //}

        //public List<string> TrainedFName
        //{
        //    get { return trainedFileName ; }
        //    set { trainedFileName = value; }
        //}
    }
}
