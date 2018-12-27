using FlickrExport.Properties;
using FlickrNet;

namespace FlickrExport
{
    public sealed class FlickrManager
    {
        public static OAuthAccessToken OAuthToken
        {
            get => Settings.Default.OAuthToken;
            set
            {
                Settings.Default.OAuthToken = value;
                Settings.Default.Save();
            }
        }

        public static Flickr GetInstance()
        {
            return new Flickr(Settings.Default.ApiKey, Settings.Default.ApiSecret);
        }

        public static Flickr GetAuthInstance()
        {
            return new Flickr(Settings.Default.ApiKey, Settings.Default.ApiSecret)
            {
                OAuthAccessToken = OAuthToken.Token,
                OAuthAccessTokenSecret = OAuthToken.TokenSecret
            };
        }
    }
}