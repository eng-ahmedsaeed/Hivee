namespace Hivee
{
    internal static class ImageLoader
    {
        public static Image? LoadFromPathOrUrl(string pathOrUrl)
        {
            if (string.IsNullOrWhiteSpace(pathOrUrl))
            {
                return null;
            }

            try
            {
                if (!Path.IsPathFullyQualified(pathOrUrl) || !File.Exists(pathOrUrl))
                {
                    return null;
                }

                using Image localImage = Image.FromFile(pathOrUrl);
                return new Bitmap(localImage);
            }
            catch
            {
                return null;
            }
        }
    }
}
