 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace THO7AlgoritmTimerApplication
{
    public partial class MainForm : Form
    {
        List<VisionAlgorithm> AlgorithmList = new List<VisionAlgorithm>();
        Stopwatch stopWatch;


        Bitmap InputImage;
        public MainForm()
        {
            InitializeComponent();
            AlgorithmList.Add(new FlipAlgorithm("Flip"));
            AlgorithmList.Add(new RotateAlgorithm("Rotate"));
            //Insert new Algorithms here
            /*          ^
            *          /|\
            *           |
            */
            foreach (VisionAlgorithm vA in AlgorithmList)
            {
                AlgoListBox.Items.Add(vA.Name);
            }
        }

        private void openPictureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openImage();
        }
        private void openImage()
        {
            OpenFileDialog oFD = new OpenFileDialog();
            oFD.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            oFD.Filter = "Image Files(*.BMP;*.JPG;*.JPEG;*.PNG;)|*.BMP;*.JPG;*.JPEG;*.PNG;";
            oFD.FilterIndex = 1;
            oFD.RestoreDirectory = true;
            if (oFD.ShowDialog() == DialogResult.OK)
            {
                String CurrentFileName = Path.GetFullPath(oFD.FileName);
                InputImage = new Bitmap(CurrentFileName);
                InputPictureBox.Image = InputImage;
            }
        }

        private void AlgoListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AlgoButton_Click(object sender, EventArgs e)
        {

            if (InputImage != null && AlgoListBox.SelectedIndex != -1)
            {
                InfoLabel.Text += "Start running " + AlgorithmList.ElementAt(AlgoListBox.SelectedIndex).Name + "...\n";
                startAlgThread();
            }

        }

        private void OutputPictureBox_DoubleClick(object sender, EventArgs e)
        {
            if (OutputPictureBox.Image != null)
            {
                Form ipForm = new ImagePreviewForm(new Bitmap(OutputPictureBox.Image));
                ipForm.Show();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void OutputToInputButton_Click(object sender, EventArgs e)
        {
            if (OutputPictureBox.Image != null)
            {
                InputImage = new Bitmap(OutputPictureBox.Image);
                InputPictureBox.Image = InputImage;
                OutputPictureBox.Image = null;
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            InfoLabel.Text = "";
        }

        private void backgroundAlgorithmWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("Error: " + e.Error.Message);
            }
            else if (e.Cancelled)
            {
                MessageBox.Show("Algorithm canceled.");
            }
            else
            {
                stopWatch.Stop();
                long elapsedms = stopWatch.ElapsedMilliseconds;
                int value = AlgoListBox.SelectedIndex;
                InfoLabel.Text += AlgorithmList.ElementAt(value).Name + " took: " + elapsedms + " ms\n";
                EnableAllInputs(true);
            }
        }

        private void backgroundAlgorithmWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            System.ComponentModel.BackgroundWorker worker;
            worker = (System.ComponentModel.BackgroundWorker)sender;
            List<object> argList = (List<object>)e.Argument;
            VisionAlgorithm visAlg = (VisionAlgorithm) argList.ElementAt(0);
            Bitmap InputImage = (Bitmap)argList.ElementAt(1);
            PictureBox OutputPictureBox = (PictureBox)argList.ElementAt(2);
            OutputPictureBox.Image = visAlg.DoAlgorithm(InputImage);

        }

        private void EnableAllInputs(bool state)
        {
            openPictureToolStripMenuItem.Enabled = state;
            AlgoButton.Enabled = state;
            AlgoListBox.Enabled = state;
            OutputToInput.Enabled = state;
            InputPictureBox.Enabled = state;
        }

        private void startAlgThread()
        {
            List<object> argList = new List<object>();
            argList.Add(AlgorithmList.ElementAt(AlgoListBox.SelectedIndex));
            argList.Add(InputImage);
            argList.Add(OutputPictureBox);
            stopWatch = new Stopwatch();
            EnableAllInputs(false);
            stopWatch.Start();
            backgroundAlgorithmWorker.RunWorkerAsync(argList); 
        }
    }
}
