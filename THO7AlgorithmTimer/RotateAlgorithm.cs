using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace THO7AlgorithmTimerApplication
{
    class RotateAlgorithm : VisionAlgorithm
    {
        public RotateAlgorithm(String name) : base(name) { }
        public override System.Drawing.Bitmap DoAlgorithm(System.Drawing.Bitmap sourceImage)
        {
            Bitmap returnImage = new Bitmap(sourceImage);
            returnImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
            return returnImage;
        }
    }
}
