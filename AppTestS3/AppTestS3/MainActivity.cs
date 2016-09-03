using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Amazon.CognitoIdentity;
using Amazon.S3;
using Amazon;
using Amazon.S3.Transfer;
using Plugin.Media;
using System.Threading.Tasks;

namespace AppTestS3
{
    [Activity(Label = "AppTestS3", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        Button buttonup;
        Button buttondown;
        string imgPath;
        string dirPath;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);
            buttonup = FindViewById<Button>(Resource.Id.MyButton1);
            buttondown = FindViewById<Button>(Resource.Id.MyButton2);
            ImageView img = FindViewById<ImageView>(Resource.Id.imageView1);

            button.Click += async delegate
            {

                try
                {

                    if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                    {
                        DisplayAlert("No Camera", ":( No camera available.", "OK");
                        return;
                    }

                    string imgfileName = DateTime.Now.Ticks.ToString();

                    var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                    {
                        Directory = "Sample",
                        Name = imgfileName + ".jpg"
                    });

                    if (file == null)
                        return;

                    //DisplayAlert("File Location", file.Path, "OK");

                    imgPath = file.Path;
                    dirPath = file.AlbumPath;

                    //img.Source = ImageSource.FromStream(() =>
                    //{
                    //    var stream = file.GetStream();
                    //    file.Dispose();
                    //    return stream;
                    //});

                    //transferUtility.DownloadAsync(System.IO.Path.Combine(imgPath, "test_4.jpg"), "auradiesnews", fileName1);
                }
                catch (Exception ex)
                {

                }

            };

            buttonup.Click += Buttonup_Click;
            buttondown.Click += Buttondown_Click;
        }

        private void Buttondown_Click(object sender, EventArgs e)
        {
            CognitoAWSCredentials credentials = new CognitoAWSCredentials("us-west-2:c6d26e4f-8ee8-471b-83b2-f3fa1444be8b", RegionEndpoint.USWest2);


            var s3Client = new AmazonS3Client(credentials, RegionEndpoint.APSouth1);
            var transferUtility = new TransferUtility(s3Client);


            string fileName = "events_Icon01.jpg";

            TransferUtilityDownloadRequest req = new TransferUtilityDownloadRequest();
            req.BucketName = "auradiesnews";
            req.FilePath = dirPath;
            req.Key = "events_Icon01.jpg";

            //Task task = transferUtility.DownloadAsync(new TransferUtilityDownloadRequest()


            Task task = transferUtility.DownloadAsync(req, new System.Threading.CancellationToken());
        }

        private void Buttonup_Click(object sender, EventArgs e)
        {
            try
            {
                CognitoAWSCredentials credentials = new CognitoAWSCredentials("us-west-2:c6d26e4f-8ee8-471b-83b2-f3fa1444be8b", RegionEndpoint.USWest2);


                var s3Client = new AmazonS3Client(credentials, RegionEndpoint.APSouth1);
                var transferUtility = new TransferUtility(s3Client);

                string fileName = DateTime.Now.Ticks.ToString();
                Task task = transferUtility.UploadAsync(imgPath, "auradiesnews");

                string fileName1 = DateTime.Now.Ticks.ToString();
            }
            catch (Exception ex)
            { }
        }

        private void DisplayAlert(string v1, string v2, string v3)
        {
            throw new NotImplementedException();
        }





    }
}