﻿using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceDetect
{
    public class TrainedFaceReconizer
    {
        public OpenCvSharp.Face.FaceRecognizer faceReconizer;
        public TrainedFileList trainedFileList;
    }
}
