namespace PhotoSchool.Data.Migrations
{
    using PhotoSchool.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PhotoSchoolDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            //TODO remove in production
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(PhotoSchoolDbContext context)
        {
            this.SeedWords(context);
        }

        protected void SeedWords(PhotoSchoolDbContext context)
        {
            if (context.Words.Any())
            {
                return;
            }

            context.Words.Add(new Word
            {
                Name = "Aperture",
                Description = "The feature that controls the size of the lens opening when a picture is taken. If you need a lot of light you want to have a big opening (a low aperture). Measured in F-stops and often referred to as such.",
                CreatedOn = DateTime.Now
            });

            context.Words.Add(new Word
            {
                Name = "ISO",
                Description = "The feature that controls the sensitivity of the image sensor in your camera. Low ISO is not very sensitive and good for sunny days when you don’t need a lot of light captured. At a high ISO means your image sensor is more sensitive when you need a lot of light – this is good for shooting in low light.",
                CreatedOn = DateTime.Now
            });

            context.Words.Add(new Word
            {
                Name = "Exposure",
                Description = "The quantity, duration and intensity of light captured by the image sensor. Exposure is controlled by three elements: ISO, Aperture and Shutter Speed",
                CreatedOn = DateTime.Now
            });

            context.Words.Add(new Word
            {
                Name = "Shutter Speed",
                Description = "The feature that controls how long the shutter is open for and therefore how much light comes into the camera and hits the image sensor.",
                CreatedOn = DateTime.Now
            });

            context.Words.Add(new Word
            {
                Name = "Stops",
                Description = "Stop can refer to different settings in any of the three elements that control Exposure. Aperture, Shutter Speed, and ISO settings are all divided up into \"stops\", even though the numbering systems are different.",
                CreatedOn = DateTime.Now
            });

            context.Words.Add(new Word
            {
                Name = "Noise or Digital Noise",
                Description = "The appearance of colour dots or specks (sometimes called grain), often pronounced in shadows and darks areas.",
                CreatedOn = DateTime.Now
            });

            context.Words.Add(new Word
            {
                Name = "Depth of Field (DOF)",
                Description = "The zone of sharpness in front of, and behind, the subject on which the lens is focused. Depth-of-Field (DOF) is affected by Aperture. A low aperture value will give you a very shallow or short depth of field – so the foreground and background which bracket your area of focus will be blurred. A wider or longer DOF can be achieved by a higher Aperture setting. This will bring more of the area bracketing your subject into focus.",
                CreatedOn = DateTime.Now
            });

            context.Words.Add(new Word
            {
                Name = "F-stop (see aperture)",
                Description = "Technically refers to the numbers that represent the size of your lens opening. A low number gives you a large lens opening. A high number gives you a smaller lens opening.",
                CreatedOn = DateTime.Now
            });

            context.Words.Add(new Word
            {
                Name = "Overexposed",
                Description = "A condition in which too much light reaches the sensor, making it look too light or washed out.",
                CreatedOn = DateTime.Now
            });

            context.Words.Add(new Word
            {
                Name = "Underexposed",
                Description = "A condition in which not enough light reaches the image, making it look dark.",
                CreatedOn = DateTime.Now
            });

            context.Words.Add(new Word
            {
                Name = "Av",
                Description = "Aperture value, identifies Aperture Priority Mode",
                CreatedOn = DateTime.Now
            });

            context.Words.Add(new Word
            {
                Name = "Tv",
                Description = "Time value, identifies Shutter Priority Mode",
                CreatedOn = DateTime.Now
            });

            context.Words.Add(new Word
            {
                Name = "Aperture Priority",
                Description = "An exposure mode that lets you set the aperture while the camera determines the shutter speed for proper exposure. If you change the aperture, or the light level changes, the shutter speed changes automatically.",
                CreatedOn = DateTime.Now
            });

            context.Words.Add(new Word
            {
                Name = "Shutter Priority",
                Description = "An exposure mode that lets you select the desired shutter speed while the camera determines the aperture for proper exposure.",
                CreatedOn = DateTime.Now
            });

            context.Words.Add(new Word
            {
                Name = "Saturation",
                Description = "The percentage of hue in a colour. Saturated colours are called vivid, strong, or deep. Desaturated colours are called dull, weak, or washed out.",
                CreatedOn = DateTime.Now
            });

            context.SaveChanges();
        }
    }
}
