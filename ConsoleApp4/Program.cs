using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.UI;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Cvb;
using Emgu;
using System.Drawing;
using System.Windows.Forms;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            int Blue_threshold = 50; //0-255
            int Green_threshold = 50; //0-255
            int Red_threshold = 50; //0-255
/*
            Capture capture = new Capture();
            string str = Console.ReadLine();
            if (str == "") str = "handdetection2.jpg";
            CascadeClassifier
             HandCascade = new CascadeClassifier("Hand.Cascade.1.xml");
            Image<Bgr, Byte> image;
            image = capture.QueryFrame().ToImage<Bgr, Byte>();
            image = new Image<Bgr, byte>(str);

            Image<Gray, Byte> grayImage = image.Convert<Gray, Byte>();
            grayImage = grayImage.ThresholdBinaryInv(new Gray(50), new Gray(255));
            var lol = image.ThresholdBinary(new Bgr(Blue_threshold, Green_threshold, Red_threshold), new Bgr(255, 255, 255));
           // grayImage = lol.Convert<Gray, Byte>();
            var Hand = HandCascade.DetectMultiScale(grayImage);
            foreach (var h in Hand)
            {
                // grayImage.Draw(h, new Bgr(255, 255, 255), 10);
                grayImage.Draw(h, new Gray(100), 1);
            }
            //CvInvoke.NamedWindow("lol");
            ImageViewer viewer = new ImageViewer(); //create an image viewer
            viewer.Image = grayImage;
            viewer.ShowDialog(); //show the image viewer
            ImageViewer v = new ImageViewer();
            viewer.Image = lol;
            // viewer.ShowDialog();
            */
            CascadeClassifier HandCascade = new CascadeClassifier("Hand.Cascade.1.xml");
            

            ImageViewer viewer = new ImageViewer(); //create an image viewer
            Capture capture = new Capture(); //create a camera captue
            Application.Idle += new EventHandler(delegate (object sender, EventArgs e)
            {  //run this until application closed (close button click on image viewer)
             //   viewer.Image = capture.QueryFrame(); //draw the image obtained from camera
                Image<Bgr, Byte> image;
                image = capture.QueryFrame().ToImage<Bgr, Byte>();

                Image<Gray, Byte> grayImage = image.Convert<Gray, Byte>();
               //  grayImage = grayImage.ThresholdBinaryInv(new Gray(50), new Gray(255));
                var lol = image.ThresholdBinary(new Bgr(Blue_threshold, Green_threshold, Red_threshold), new Bgr(255, 255, 255));
                grayImage = lol.Convert<Gray, Byte>();
                var Hand = HandCascade.DetectMultiScale(image);
                foreach (var h in Hand)
                {
                    // grayImage.Draw(h, new Bgr(255, 255, 255), 10);
                    image.Draw(h, new Bgr(255, 255, 255), 1);
                }
                viewer.Image = image;



            });
            viewer.ShowDialog(); //show the image viewer
        }
    }
}
