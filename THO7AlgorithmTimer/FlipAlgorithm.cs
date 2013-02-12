using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace THO7AlgorithmTimerApplication
{
    class FlipAlgorithm : VisionAlgorithm
    {
        public FlipAlgorithm(String name) : base(name) { }
        public override System.Drawing.Bitmap DoAlgorithm(System.Drawing.Bitmap sourceImage)
        {
            Bitmap returnImage = new Bitmap(sourceImage);
            returnImage.RotateFlip(RotateFlipType.Rotate180FlipY);
            return returnImage;
        }
    }
}
