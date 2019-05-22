using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Hosting;
using System.Xml.Serialization;

namespace PrantiksmeApp.Models.Utilities
{
    public static class Utility
    {
        
        #region Image Releted
        public static byte[] ConvertImageToBinary(HttpPostedFileBase uploadFile)
        {
            if (uploadFile != null)
            {
                byte[] convertedImage = new byte[uploadFile.ContentLength];
                uploadFile.InputStream.Read(convertedImage, 0, uploadFile.ContentLength);
                return convertedImage;
            }
            return null;
        }
        public static byte[] ConvertImageToBytes(HttpPostedFileBase file)
        {
            if (file != null)
            {
                byte[] imageBytes = null;
                BinaryReader reader = new BinaryReader(file.InputStream);
                imageBytes = reader.ReadBytes(file.ContentLength);
                return imageBytes;
            }

            return null;
        }
        public static bool CheckImageFormat(List<HttpPostedFileBase> fileUploads)
        {
            bool isNotValidFormat = false;
            foreach (var file in fileUploads)
            {
                CheckImageFormat(file);
            }
            return isNotValidFormat;
        }

        public static bool CheckImageFormat(HttpPostedFileBase file)
        {
            bool isNotValidFormat = false;

            if (file != null)
            {
                var extension = Path.GetExtension(file.FileName).ToLower();
                var fileName = Path.GetFileName(file.FileName);
                var allowExtension = new[]
                {
                    ".jpg", ".png", ".jpeg"
                };

                if (!allowExtension.Contains(extension))
                {
                    isNotValidFormat = true;
                }
            }

            return isNotValidFormat;
        }

        public static string ConvertByteToBase64String(byte[] file)
        {
            if (file.Length > 1)
            {
                var base64 = Convert.ToBase64String(file);
                var result = $"data:image/gif;base64,{base64}";
                return result;
            }
            return null;
        }

        public static string GetBase64ImageFromPath(string path)
        {
            var imageArray = File.ReadAllBytes(HostingEnvironment.MapPath(path) ?? throw new Exception("Sorry! Content Not Found !"));
            var base64Image = Convert.ToBase64String(imageArray);
            return base64Image;


        }
        public static string GetBase64ImageStringFromPath(string path)
        {
            var imageArray = File.ReadAllBytes(HostingEnvironment.MapPath(path) ?? throw new Exception("Sorry! Content Not Found !"));
            var base64Image = Convert.ToBase64String(imageArray);
            var imageString = $"data:jpg/jpeg/image/gif/png;base64,{base64Image}";
            return imageString;
        }
        public static bool GetImageExtension(this string source)
        {
            var result = (source.EndsWith(".png") || source.EndsWith(".jpg") || source.EndsWith(".jpeg") || source.EndsWith(".gif") || source.EndsWith(".bmp")
                          || source.EndsWith("/png") || source.EndsWith("/jpg") || source.EndsWith("/jpeg") || source.EndsWith("/gif") || source.EndsWith("/bmp"));
            return result;
        }

        #endregion

        #region Date  Time Releted

        public static DateTime GetDate(string date)
        {
            IFormatProvider culture = new CultureInfo("fr-FR", true);
            var convertedDate = DateTime.Parse(date, culture, DateTimeStyles.AssumeLocal);
            return convertedDate;
        }

        public static string GetDate(DateTime date)
        {
            var data = date.ToString("dd/MM/yyyy");
            return data;
        }

        public static TimeSpan GetTime(string time)
        {
            if (string.IsNullOrEmpty(time))
            {
                return new TimeSpan();
            }
            var res = DateTime.TryParse(time, out var dateTime);
            if (!res)
            {
                throw new Exception("Sorry! Time is Not Correct Format !");
            }

            var convertedTime = dateTime.TimeOfDay;
            return convertedTime;

        }

        public static string GetTime(TimeSpan? time = null)
        {
            if (time == null)
            {
                return null;
            }
            var dateTime = DateTime.Today.Add((TimeSpan)time);
            var displayTime = dateTime.ToString("hh:mm tt");
            return displayTime;
        }

        public static string GetStr24Time(TimeSpan? time = null)
        {
            if (time == null)
            {
                return null;
            }
            var dateTime = DateTime.Today.Add((TimeSpan)time);
            var displayTime = dateTime.ToString("HH:mm tt");
            return displayTime;
        }

        public static string GetStr24Time(DateTime? dateTime = null)
        {
            if (dateTime != null)
            {
                var data = DateTime.Today.Add(((DateTime)dateTime).TimeOfDay);
                var displayTime = data.ToString("HH:mm tt");
                return displayTime;
            }
            return null;
        }

        public static DateTime Get24Time(TimeSpan? time = null)
        {
            if (time == null)
            {
                return DateTime.Today;
            }

            var dateTime = DateTime.Today.Add((TimeSpan)time);
            return dateTime;
        }

        public static DateTime Get24Time(DateTime? dateTime)
        {
            if (dateTime != null)
            {
                var data = DateTime.Today.Add(((DateTime)dateTime).TimeOfDay);
                return data;
            }

            return DateTime.Today;

        }

        public static double GetTimeDiff(TimeSpan startTime, TimeSpan endTime)
        {
            var minutes = endTime.Subtract(startTime).TotalMinutes;
            return minutes;
        }

        public static double GetTimeDiff(DateTime startTime, DateTime endTime)
        {
            var minutes = endTime.TimeOfDay.Subtract(startTime.TimeOfDay).TotalMinutes;
            return minutes;
        }

        public static double GetTimeDiff(DateTime startTime, TimeSpan endTime)
        {
            var minutes = endTime.Subtract(startTime.TimeOfDay).TotalMinutes;
            return minutes;
        }

        public static double GetTimeDiff(TimeSpan startTime, DateTime endTime)
        {
            var minutes = endTime.TimeOfDay.Subtract(startTime).TotalMinutes;
            return minutes;
        }

        public static string GetDateWithTime(DateTime date)
        {
            var data = date.ToString("dd-MMM-yyyy hh:mm tt");
            return data;
        }

        public static List<DateTime> GetDateRangeBetweenTwoDates(DateTime fromDate, DateTime toDate)
        {
            if (toDate < fromDate)
            {
                throw new ArgumentException("endDate must be greater than or equal to startDate");
            }
            var result = Enumerable.Range(0, (toDate - fromDate).Days + 1).Select(d => fromDate.AddDays(d));
            return result.ToList();
        }



        #endregion

        #region Math Releted
        public static double GetVAT(double amount, double vatRate)
        {
            if (amount == 0)
            {
                return 0;
            }

            if (vatRate == 0)
            {
                return amount;
            }
            return Math.Round(((vatRate * amount) / 100), 2);
        }
        public static double GetAmountAfterPercent(double amount, double parcent)
        {
            if (amount > 0 && parcent > 0)
            {
                var data = Math.Round(((amount * parcent) / 100), 2);
                return data;
            }
            return amount;
        }

        #endregion

        #region Bar Code Releted
        public static string GetBarcode(string value)
        {
            var memoryStream = new MemoryStream();

            var bitMap = new Bitmap(value.Length * 14, 50);

            var graphics = Graphics.FromImage(bitMap);

            var oFont = new Font("IDAutomationHC39M", 10);
            var point = new PointF(2f, 2f);
            var whiteBrush = new SolidBrush(Color.White);
            graphics.FillRectangle(whiteBrush, 0, 0, bitMap.Width, bitMap.Height);
            var blackBrush = new SolidBrush(Color.Black);
            graphics.DrawString(value, oFont, blackBrush, point);

            bitMap.Save(memoryStream, ImageFormat.Jpeg);


            var base64Image = Convert.ToBase64String(memoryStream.ToArray());

            return base64Image;
        }


        #endregion

        #region Others
        public static bool Exists<TContext, TEntity>(this TContext context, TEntity entity)
            where TContext : DbContext
            where TEntity : class
        {
            return context.Set<TEntity>().Local.Any(e => e == entity);
        }

        public static string EmailFrom = WebConfigurationManager.AppSettings.Get("EmailFrom");
        public static string EmailPassword = WebConfigurationManager.AppSettings.Get("EmailPassword");
        public static string HostInfo = WebConfigurationManager.AppSettings.Get("HostInfo");

        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                {
                    using (var stream = client.OpenRead("http://www.google.com"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }
        public static string GetStringFromEnum(Enum value)
        {
            return Regex.Replace(value.ToString(), "(\\B[A-Z])", " $1");
        }


        #endregion

    }
}
