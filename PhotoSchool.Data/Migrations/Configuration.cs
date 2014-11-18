namespace PhotoSchool.Data.Migrations
{
    using PhotoSchool.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using PhotoSchool.Models.Enumerations;
    using System.Collections.Generic;
    using Microsoft.AspNet.Identity.EntityFramework;
    using PhotoSchool.Common;
    using Microsoft.AspNet.Identity;

    internal sealed class Configuration : DbMigrationsConfiguration<PhotoSchoolDbContext>
    {
        public List<CameraSetting> Settings;

        public List<SettingMetric> Metrics;

        public List<Photo> Photos;

        private IRandomGenerator random;

        private UserManager<ApplicationUser> userManager;

        public Configuration()
        {
           
            this.AutomaticMigrationsEnabled = true;
            //TODO remove in production
            this.AutomaticMigrationDataLossAllowed = true;
            this.random = new RandomGenerator();
        }

        protected override void Seed(PhotoSchoolDbContext context)
        {
            this.SeedRolesAndUsers(context);
            this.SeedWords(context);         
            this.SeedSettings(context);
            this.SeedTips(context);
            this.SeedPhotos(context);
            //this.SeedPhotoContest(context);
        }

        private void SeedRolesAndUsers(PhotoSchoolDbContext context)
        {
            if (!context.Users.Any())
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                roleManager.Create(new IdentityRole(GlobalConstants.Admin));
                roleManager.Create(new IdentityRole(GlobalConstants.User));

                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var user = new ApplicationUser { UserName = "v@abv.bg" };
                userManager.Create(user, "123456");
                userManager.AddToRole(user.Id, "Admin");
                userManager.AddToRole(user.Id, "User");

                context.SaveChanges();
            }
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

        protected void SeedSettings(PhotoSchoolDbContext context)
        {
            if (context.Settings.Any())
            {
                return;
            }

            this.Settings = new List<CameraSetting>();

            this.Metrics = new List<SettingMetric>();
            Metrics.Add(new SettingMetric { Value = "f/2.8" });
            Metrics.Add(new SettingMetric { Value = "f/4" });
            Metrics.Add(new SettingMetric { Value = "f/5.6" });
            Metrics.Add(new SettingMetric { Value = "f/8" });
            Metrics.Add(new SettingMetric { Value = "f/11" });
            Metrics.Add(new SettingMetric { Value = "f/16" });

            Settings.Add(new CameraSetting
            {
                SettingType = SettingType.Aperture,
                Explanation = "The aperture setting controls the size of the lens opening that allows light into your camera.You can blur the foreground and background that bracket your subject (known as shallow depth of field) by opening up the aperture with a low f-stop number; alternatively, you can keep your photo sharp from the foreground through to the background (known as wide depth of field) by closing the aperture down with a high f-stop number.",
                ShortDescription = "Control the amount of blur or sharpness around your subject.",
                ImageUrl = "/Content/img/settingsbg/bg-compare-aperture_en.png",
                Metrics = Metrics
            });

            this.Metrics = new List<SettingMetric>();
            Metrics.Add(new SettingMetric { Value = "-3" });
            Metrics.Add(new SettingMetric { Value = "-2" });
            Metrics.Add(new SettingMetric { Value = "-1" });
            Metrics.Add(new SettingMetric { Value = "0" });
            Metrics.Add(new SettingMetric { Value = "1"});
            Metrics.Add(new SettingMetric { Value = "2" });
            Metrics.Add(new SettingMetric { Value = "3" });

            Settings.Add(new CameraSetting
            {
                SettingType = SettingType.Exposure,
                Explanation = "The Exposure Meter is your final check before you snap a shot. At a glance it tells you how your exposure will turn out based on the Aperture, Shutter Speed and ISO settings. A well exposed shot lines up right down the centre at zero. An underexposed shot (too little light) falls left of centre and an overexposed shot (too much light) falls right of centre. Use the Exposure Meter as a guide only, exposure is a matter of personal preference so don't be affraid to wander off of zero.",
                ShortDescription = "Sanity check your settings.",
                ImageUrl = "/Content/img/settingsbg/bg-compare-exposure_en.png",
                Metrics = Metrics
            });

            this.Metrics = new List<SettingMetric>();
            Metrics.Add(new SettingMetric { Value = "ISO 100" });
            Metrics.Add(new SettingMetric { Value = "ISO 200" });
            Metrics.Add(new SettingMetric { Value = "ISO 400" });
            Metrics.Add(new SettingMetric { Value = "ISO 800" });
            Metrics.Add(new SettingMetric { Value = "ISO 1600" });
            Metrics.Add(new SettingMetric { Value = "ISO 3200" });
            Metrics.Add(new SettingMetric { Value = "ISO 6400" });
            Metrics.Add(new SettingMetric { Value = "ISO 12800" });
            Metrics.Add(new SettingMetric { Value = "ISO 25600" });
            
            Settings.Add(new CameraSetting
            {
                SettingType = SettingType.ISO,
                Explanation = "With the ISO setting a camera's image sensor can be adjusted to detect more, or less light as needed for a good exposure. On a bright sunny day too much light hitting the sensor can cause an overexposure so make it less sensitive with a low ISO number. If your shooting conditions are dark the sensor needs to detect more light so increase its sensitivity with a higher ISO. High ISO will cause grainyness so as a rule use the lowest ISO possible. The photo effects you want to achieve with the aperture and shutter speed will impact the amount of light reaching the sensor, so use the ISO to adjust its sensitivity and get a good exposure.",
                ShortDescription = "Sense the right amount of light for the visual effect you want.",
                ImageUrl = "/Content/img/settingsbg/bg-compare-iso_en.png",
                Metrics = Metrics
            });

            this.Metrics = new List<SettingMetric>();
            Metrics.Add(new SettingMetric { Value = "1 Sec" });
            Metrics.Add(new SettingMetric { Value = "1/6 Sec" });
            Metrics.Add(new SettingMetric { Value = "1/20 Sec" });
            Metrics.Add(new SettingMetric { Value = "1/60 Sec" });
            Metrics.Add(new SettingMetric { Value = "1/250 Sec" });
            Metrics.Add(new SettingMetric { Value = "1/1000 Sec" });
            Metrics.Add(new SettingMetric { Value = "1/4000 Sec" });

            Settings.Add(new CameraSetting
            {
                SettingType = SettingType.ShutterSpeed,
                Explanation = "The only thing between the light that has passed through the Aperture and the image sensor is a shutter. The Shutter Speed setting controls how long the shutter opens to expose the image sensor to that light. Open it for just a millisecond and you can freeze a fast moving subject. Alternatively, you can show the movement of a fast moving subject by keeping it open longer with a slow shutter speed.",
                ShortDescription = "Show the movement of a fast moving subject or freeze it in action.",
                ImageUrl = "/Content/img/settingsbg/bg-compare-shutter-speed_en.png",
                Metrics = Metrics
            });

            context.Settings.AddOrUpdate(Settings.ToArray());
            context.SaveChanges();
        }

        protected void SeedTips(PhotoSchoolDbContext context)
        {
            if (context.Tips.Any())
            {
                return;
            }

            context.Tips.Add(new Tip { Content = "There are two Priority Modes on your camera that can help make shooting easier while still having some control over the exposure of your image. When you’re shooting in a priority mode you decide which exposure setting you want to control – Aperture or Shutter Speed, while the camera can automatically adjust the others to ensure a good exposure." });
            context.Tips.Add(new Tip { Content = "When in Aperture Priority mode keep in mind that when you use a small Aperture, the Shutter Speed will adjust to stay open longer. Long shutter times will pick-up any hand movement so use a tripod." });
            context.Tips.Add(new Tip { Content = "Shutter Priority Mode (represented by Tv), allows you to focus on how motion is being captured, while automatically setting your Aperture and ISO. So if you’re shooting a track meet or a car race, you will probably want to use Shutter Priority." });
            context.Tips.Add(new Tip { Content = "Think of Aperture and Shutter Speed as balanced variables. If your settings are giving you a good exposure but you want to increase the size of your Aperture by one stop (or click) - you will also need to decrease your shutter speed by one stop to get the same balanced exposure." });
            context.Tips.Add(new Tip { Content = "Remember that using a very high ISO may add some digital noise. So always start with a low ISO and adjust if necessary to achieve the effect you want." });
            context.Tips.Add(new Tip { Content = "When taking pictures, just remember the following: ISO affects Noise, Aperture affects Depth-of-Field (DOF), Shutter affects Motion." });
            context.Tips.Add(new Tip { Content = "Be aware that a longer Shutter Speed will show any movement from your hand. Try steadying your camera or using a tripod." });
            context.Tips.Add(new Tip { Content = "Remember that sometimes natural light gives you the most beautiful results." });
            context.Tips.Add(new Tip { Content = "By adjusting your exposure settings you can capture amazing moments in low light and bright light." });
            context.Tips.Add(new Tip { Content = "On a bright sunny day using a smaller aperture and short shutter speed may get you a good exposure." });
            context.Tips.Add(new Tip { Content = "Shooting a scene with low light is going to need a larger aperture and/or a longer shutter speed. Remember to steady the camera if you are using a longer shutter speed." });

            context.SaveChanges();
        }

        protected void SeedPhotos(PhotoSchoolDbContext context)
        {
            if (context.Photos.Any())
            {
                return;
            }

            context.Photos.Add(new Photo
            {
                ShortDescription = "Good exposure",
                ImageUrl = "/Content/img/examples/ge1.jpg"
            });

            context.Photos.Add(new Photo
            {
                ShortDescription = "Good exposure",
                ImageUrl = "/Content/img/examples/ge2.jpg"
            });

            context.Photos.Add(new Photo
            {
                ShortDescription = "Good exposure",
                ImageUrl = "/Content/img/examples/ge3.jpg"
            });

            context.Photos.Add(new Photo
            {
                ShortDescription = "Shallow depth of field",
                ImageUrl = "/Content/img/examples/sdf1.jpg"
            });

            context.Photos.Add(new Photo
            {
                ShortDescription = "Shallow depth of field",
                ImageUrl = "/Content/img/examples/sdf2.jpg"
            });

            context.Photos.Add(new Photo
            {
                ShortDescription = "Shallow depth of field",
                ImageUrl = "/Content/img/examples/sdf3.jpg"
            });

            context.Photos.Add(new Photo
            {
                ShortDescription = "Wide depth of field",
                ImageUrl = "/Content/img/examples/wdf1.jpg"
            });

            context.Photos.Add(new Photo
            {
                ShortDescription = "Wide depth of field",
                ImageUrl = "/Content/img/examples/wdf2.jpg"
            });

            context.Photos.Add(new Photo
            {
                ShortDescription = "Wide depth of field",
                ImageUrl = "/Content/img/examples/wdf3.jpg"
            });

            context.Photos.Add(new Photo
            {
                ShortDescription = "Show motion",
                ImageUrl = "/Content/img/examples/sm1.jpg"
            });

            context.Photos.Add(new Photo
            {
                ShortDescription = "Show motion",
                ImageUrl = "/Content/img/examples/sm2.jpg"
            });

            context.Photos.Add(new Photo
            {
                ShortDescription = "Show motion",
                ImageUrl = "/Content/img/examples/sm3.jpg"
            });

            context.SaveChanges();
        }

        //protected void SeedPhotoContest(PhotoSchoolDbContext context)
        //{
        //    if (context.PhotoContests.Any())
        //    {
        //        return;
        //    }

        //    this.Photos = new List<Photo>();
        //    Photos.Add(new Photo { ShortDescription = "Shallow depth field 1", ImageUrl = "/Content/img/examples/sdf1.jpg" });
        //    Photos.Add(new Photo { ShortDescription = "Shallow depth field 2", ImageUrl = "/Content/img/examples/sdf2.jpg" });
        //    Photos.Add(new Photo { ShortDescription = "Shallow depth field 3", ImageUrl = "/Content/img/examples/sdf3.jpg" });
            
        //    context.PhotoContests.Add(new PhotoContest
        //    {
        //        Title = "Shallow Depth Field Contest",
        //        Description = "Show us you know what 'shallow depth field' means. Vote for the best photo or join the contest now if you dare!",
        //        Start = DateTime.Now,
        //        Finish = new DateTime(2014, 1, 12),
        //        Photos = Photos
        //    });

        //    context.SaveChanges();
        //}
    }
}
