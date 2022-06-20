using System;
using System.Diagnostics;
using System.IO;
using System.Net.Mime;
using System.Windows.Forms;

namespace ytdl_ui
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            buttonMp4.Enabled = false;
            buttonMp3.Enabled = false;
            buttonThumbnail.Enabled = false;

            if (!PathHelper.ExistsOnPath("youtube-dl.exe") && !File.Exists("youtube-dl.exe")
                || !PathHelper.ExistsOnPath("ffmpeg.exe") && !File.Exists("ffmpeg.exe"))
            {
                DialogResult res = MessageBox.Show(
                    "youtube-dl.exe and/or ffmpeg.exe could not be found, but are needed to run the program. Would you like to install them?" +
                    "\n\nYes - Install them automatically" +
                    "\nNo - Continue without installing" +
                    "\nCancel - Close the program" , 
                    "Missing prerequisites", 
                    MessageBoxButtons.YesNoCancel);

                switch (res)
                {
                    case DialogResult.Yes:
                        InstallPrerequisites();
                        break;
                    case DialogResult.No:
                        // Continue without installing
                        break;
                    default:
                        Application.Exit();
                        break;
                }
            }
        }

        private void buttonMp4_Click(object sender, EventArgs e)
        {
            DownloadMedia(false);
        }
        
        private void buttonMp3_Click(object sender, EventArgs e)
        {
            DownloadMedia(true);
        }

        private void DownloadMedia(bool isMp3)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            const string mp3Filter = "MP3 files (*.mp3)|*.mp3|All files (*.*)|*.*";
            const string mp4Filter = "MP4 files (*.mp4)|*.mp4|All files (*.*)|*.*";
            saveFileDialog.Filter = isMp3 ? mp3Filter : mp4Filter;
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;
            
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string url = inputUrl.Text;
                string output = saveFileDialog.FileName;

                Process process = new Process();
                process.StartInfo.FileName = "youtube-dl.exe";
                string mp3Argument = $"--extract-audio --audio-format mp3 --output \"{output}\" \"{url}\"";
                string mp4Argument = $" --merge-output-format mp4 --output \"{output}\" \"{url}\"";
                process.StartInfo.Arguments = isMp3 ? mp3Argument : mp4Argument;
                process.Start();
                process.WaitForExit();
            }
        }

        private void inputUrl_TextChanged(object sender, EventArgs e)
        {
            // check if the url is a valid youtube url
            if (inputUrl.Text.Contains("youtube.com") || inputUrl.Text.Contains("youtu.be"))
            {
                buttonMp4.Enabled = true;
                buttonMp3.Enabled = true;
                buttonThumbnail.Enabled = true;
            }
            else
            {
                buttonMp4.Enabled = false;
                buttonMp3.Enabled = false;
                buttonThumbnail.Enabled = false;
            }
        }

        private void buttonThumbnail_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PNG files (*.png)|*.png|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;
            
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string url = inputUrl.Text;
                string output = saveFileDialog.FileName;

                // download to temp file
                Process downloadProcess = new Process();
                downloadProcess.StartInfo.FileName = "youtube-dl.exe";
                string tmpFile = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
                downloadProcess.StartInfo.Arguments = $"--write-thumbnail --skip-download --output \"{tmpFile}\" \"{url}\"";
                downloadProcess.Start();
                downloadProcess.WaitForExit();
                
                // convert to png                
                Process convertProcess = new Process();
                convertProcess.StartInfo.FileName = "ffmpeg.exe";
                convertProcess.StartInfo.Arguments = $"-i \"{tmpFile}.webp\" -vf scale=1920:-1 -y \"{output}\"";
                convertProcess.Start();
                convertProcess.WaitForExit();
                
                // delete temp file
                File.Delete(tmpFile);
            }
        }

        private void InstallPrerequisites()
        {
            // install youtube-dl
            Process ytdlProcess = new Process();
            ytdlProcess.StartInfo.FileName = "curl.exe";
            ytdlProcess.StartInfo.Arguments = "-L -o youtube-dl.exe https://yt-dl.org/latest/youtube-dl.exe";
            ytdlProcess.Start();
            ytdlProcess.WaitForExit();
            
            // install ffmpeg
            Process ffmpegProcess = new Process();
            ffmpegProcess.StartInfo.FileName = "curl.exe";
            ffmpegProcess.StartInfo.Arguments = "-L -o ffmpeg.exe https://github.com/LiterallyFabian/ytdl-ui/raw/master/ytdl-ui/ffmpeg.exe";
            ffmpegProcess.Start();
            ffmpegProcess.WaitForExit();
        }

        private void buttonPrereqs_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to install the prerequisites? If the program is working, you do not need them.", "Install prerequisites", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                InstallPrerequisites();
            }
        }
    }
}