using UploadImageApp.Services;

namespace send_data_pc;

public partial class MainPage : ContentPage
{
	UploadImage serviceUploadImage;

	public MainPage()
	{
		InitializeComponent();
        serviceUploadImage = new UploadImage();
    }

	private async void UploadImage_Clicked(object sender, EventArgs e)
	{
        var img = await serviceUploadImage.OpenMediaPickerAsync();
        if(img != null)
        {
            var imagefile = await serviceUploadImage.Upload(img);
            Console.WriteLine(imagefile.byteBase64);
            Image_Upload.Source = ImageSource.FromStream(() =>
                serviceUploadImage.ByteArrayToStream(serviceUploadImage.StringToByteBase64(imagefile.byteBase64))
            );
        }

    }
}

