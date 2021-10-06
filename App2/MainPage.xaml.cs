using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Newtonsoft.Json.Linq;
using System.Net;
using Windows.Media.Core;
using System.Text;
using System.Diagnostics;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace App2
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    /// 
    public sealed partial class MainPage : Page
    {
        Uri session1tvch = new Uri("https://stream.1tv.ru/get_hls_session");
        Uri tvch1 = new Uri("https://stream.1tv.ru/api/playlist/");
        Uri vgtrkmedia = new Uri("http://player.vgtrk.com/iframe/datalive/id/");
        Uri ntvmedia = new Uri("https://www.ntv.ru/services/m/live/?live=");
        Uri umamedia = new Uri("https://uma.media/api/play/options/");
        Uri vitrinaproxy = new Uri("https://media.mediavitrina.ru/proxyapi/v2/gpm/playlist/");
        Uri vitrinanmg = new Uri("https://media.mediavitrina.ru/api/v2/nmg/playlist/");
        Uri stscontent = new Uri("https://media.mediavitrina.ru/api/v2/ctc/playlist/");
        Uri moretvmediavitrina = new Uri("https://media.mediavitrina.ru/api/v2/moretv/playlist/");
        Uri sessionkey = new Uri("https://media.mediavitrina.ru/get_token");
        string token = "?token=";
        Uri rutubeapi = new Uri("https://rutube.ru/api/play/options/");
        string token3 = "";
        Uri apiuwp = new Uri("https://jeka345.github.io/uwpplatform.json");
        Uri api24h = new Uri("https://24htv.platform24.tv/v2/channels/");
        string ac1 = "";
        public MainPage()
        {
            InitializeComponent();
            WebClient webClient = new WebClient();
            JObject tokenplay = JObject.Parse(webClient.DownloadString(sessionkey));
            token3 = (string)tokenplay["result"]["token"];
            loadingimage();
            JObject resource = JObject.Parse(webClient.DownloadString(apiuwp));
            ImageBrush imgB = new ImageBrush();
            BitmapImage btpImg = new BitmapImage();
            btpImg.UriSource = new Uri((string)resource["poster_player"]);
            imgB.ImageSource = btpImg;
            imgB.Stretch = Stretch.Fill;
            mediaPlayerElement.PosterSource = imgB.ImageSource;
            ac1 = (string)resource["ac_token"];
        }

        private async void perviy_click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            JObject sessionperviy = JObject.Parse(await webClient.DownloadStringTaskAsync(session1tvch));
            string token = (string)sessionperviy["s"];
            JObject onlineperviy = JObject.Parse(await webClient.DownloadStringTaskAsync(tvch1 + "1tvch_as_array.json"));
            string token1 = (string)onlineperviy["hls"][0];
            mediaPlayerElement.Source = MediaSource.CreateFromUri(new Uri(token1 + "&s=" + token));
            mediaPlayerElement.MediaPlayer.Play();
        }

        private async void russia1_click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            JObject russia1 = JObject.Parse(await webClient.DownloadStringTaskAsync(vgtrkmedia + "2961"));
            string livehls = (string)russia1["data"]["playlist"]["medialist"][0]["sources"]["m3u8"]["auto"];
            mediaPlayerElement.Source = MediaSource.CreateFromUri(new Uri(livehls));
            mediaPlayerElement.MediaPlayer.Play();
        }

        private async void match_click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            JArray match = JArray.Parse(await webClient.DownloadStringTaskAsync("https://matchtv.ru/vdl/playlist/133529/1.json"));
            string livehls = (string)match[0]["src"];
            mediaPlayerElement.Source = MediaSource.CreateFromUri(new Uri(livehls));
            mediaPlayerElement.MediaPlayer.Play();
        }

        private async void ntv_click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            JObject ntv = JObject.Parse(await webClient.DownloadStringTaskAsync("https://media.mediavitrina.ru/api/v2/ntv/playlist/ntv_as_array.json" + token + token3));
            string livehls = (string)ntv["hls"][0];
            mediaPlayerElement.Source = MediaSource.CreateFromUri(new Uri(livehls));
            mediaPlayerElement.MediaPlayer.Play();
        }

        private async void _5tv_click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            JObject tv_5 = JObject.Parse(await webClient.DownloadStringTaskAsync("https://media.mediavitrina.ru/api/v2/tv5/playlist/tv-5_as_array.json" + token + token3));
            string livehls = (string)tv_5["hls"][0];
            mediaPlayerElement.Source = MediaSource.CreateFromUri(new Uri(livehls));
            mediaPlayerElement.MediaPlayer.Play();
        }

        private async void russiak_click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            JObject russia1 = JObject.Parse(await webClient.DownloadStringTaskAsync(vgtrkmedia + "19201"));
            string livehls = (string)russia1["data"]["playlist"]["medialist"][0]["sources"]["m3u8"]["auto"];
            mediaPlayerElement.Source = MediaSource.CreateFromUri(new Uri(livehls));
            mediaPlayerElement.MediaPlayer.Play();
        }

        private async void russia24_click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            JObject russia1 = JObject.Parse(await webClient.DownloadStringTaskAsync(vgtrkmedia + "21"));
            string livehls = (string)russia1["data"]["playlist"]["medialist"][0]["sources"]["m3u8"]["auto"];
            mediaPlayerElement.Source = MediaSource.CreateFromUri(new Uri(livehls));
            mediaPlayerElement.MediaPlayer.Play();
        }

        private async void karusel_click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            JObject russia1 = JObject.Parse(await webClient.DownloadStringTaskAsync(vgtrkmedia + "61126"));
            string livehls = (string)russia1["data"]["playlist"]["medialist"][0]["sources"]["m3u8"]["auto"];
            mediaPlayerElement.Source = MediaSource.CreateFromUri(new Uri(livehls));
            mediaPlayerElement.MediaPlayer.Play();
        }

        private async void otr_click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            JObject streams = JObject.Parse(await webClient.DownloadStringTaskAsync(apiuwp));
            byte[] newBytes = Convert.FromBase64String((string)streams["tv_channelsuwp"][8]["url_live"]);
            string livehls = Encoding.UTF8.GetString(newBytes);
            mediaPlayerElement.Source = MediaSource.CreateFromUri(new Uri(livehls));
            mediaPlayerElement.MediaPlayer.Play();
        }

        private async void twc_click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            JObject twc = JObject.Parse(await webClient.DownloadStringTaskAsync("https://media.mediavitrina.ru/api/v2/tvc/playlist/tvc_as_array.json" + token + token3));
            string livehls = (string)twc["hls"][0];
            mediaPlayerElement.Source = MediaSource.CreateFromUri(new Uri(livehls));
            mediaPlayerElement.MediaPlayer.Play();
        }

        private async void rentv_click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            JObject rentv = JObject.Parse(await webClient.DownloadStringTaskAsync(vitrinanmg + "ren-tv_as_array.json" + token + token3));
            string livehls = (string)rentv["hls"][0];
            mediaPlayerElement.Source = MediaSource.CreateFromUri(new Uri(livehls));
            mediaPlayerElement.MediaPlayer.Play();
        }

        private async void spas_click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            JObject spas = JObject.Parse(await webClient.DownloadStringTaskAsync("https://media.mediavitrina.ru/api/v2/spas/playlist/spas_as_array.json" + token + token3));
            string livehls = (string)spas["hls"][0];
            mediaPlayerElement.Source = MediaSource.CreateFromUri(new Uri(livehls));
            mediaPlayerElement.MediaPlayer.Play();
        }

        private async void sts_click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            JObject sts = JObject.Parse(await webClient.DownloadStringTaskAsync(stscontent + "ctc_as_array.json" + token + token3));
            string livehls = (string)sts["hls"][0];
            mediaPlayerElement.Source = MediaSource.CreateFromUri(new Uri(livehls));
            mediaPlayerElement.MediaPlayer.Play();
        }

        private async void domashnii_click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            JObject stsdom = JObject.Parse(await webClient.DownloadStringTaskAsync("https://media.mediavitrina.ru/api/v2/dom/playlist/ctc-dom_as_array.json" + token + token3));
            string livehls = (string)stsdom["hls"][0];
            mediaPlayerElement.Source = MediaSource.CreateFromUri(new Uri(livehls));
            mediaPlayerElement.MediaPlayer.Play();
        }

        private async void tv3_click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            JObject sts = JObject.Parse(await webClient.DownloadStringTaskAsync(vitrinaproxy + "tv3_as_array.json" + token + token3));
            string livehls = (string)sts["hls"][0];
            mediaPlayerElement.Source = MediaSource.CreateFromUri(new Uri(livehls));
            mediaPlayerElement.MediaPlayer.Play();
        }
        private async void friday_click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            JObject sts = JObject.Parse(await webClient.DownloadStringTaskAsync(vitrinaproxy + "friday_as_array.json" + token + token3));
            string livehls = (string)sts["hls"][0];
            mediaPlayerElement.Source = MediaSource.CreateFromUri(new Uri(livehls));
            mediaPlayerElement.MediaPlayer.Play();
        }
        private async void zvezda_click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            JObject sts = JObject.Parse(await webClient.DownloadStringTaskAsync("https://media.mediavitrina.ru/api/v2/zvezda/playlist/zvezda_as_array.json" + token + token3));
            string livehls = (string)sts["hls"][0];
            mediaPlayerElement.Source = MediaSource.CreateFromUri(new Uri(livehls));
            mediaPlayerElement.MediaPlayer.Play();
        }
        private async void mir_click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            JObject sts = JObject.Parse(await webClient.DownloadStringTaskAsync("https://media.mediavitrina.ru/api/v2/mtrkmir/playlist/mir_as_array.json" + token + token3));
            string livehls = (string)sts["hls"][0];
            mediaPlayerElement.Source = MediaSource.CreateFromUri(new Uri(livehls));
            mediaPlayerElement.MediaPlayer.Play();
        }
        private async void tnt_click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            JObject sts = JObject.Parse(await webClient.DownloadStringTaskAsync(umamedia + "4e4e37727e07a7124cd7b29f2975e295/?format=json"));
            string livehls = (string)sts["live_streams"]["hls"][0]["url"];
            mediaPlayerElement.Source = MediaSource.CreateFromUri(new Uri(livehls));
            mediaPlayerElement.MediaPlayer.Play();
        }
        private async void muztv_click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            JObject sts = JObject.Parse(await webClient.DownloadStringTaskAsync("https://media.mediavitrina.ru/api/v2/muztv/playlist/muztv_as_array.json" + token + token3));
            string livehls = (string)sts["hls"][0];
            mediaPlayerElement.Source = MediaSource.CreateFromUri(new Uri(livehls));
            mediaPlayerElement.MediaPlayer.Play();
        }
        private async void kinotv_click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            JObject streams = JObject.Parse(await webClient.DownloadStringTaskAsync(apiuwp));
            byte[] newBytes = Convert.FromBase64String((string)streams["tv_channelsuwp"][20]["url_live"]);
            string livehls = Encoding.UTF8.GetString(newBytes);
            mediaPlayerElement.Source = MediaSource.CreateFromUri(new Uri(livehls));
            mediaPlayerElement.MediaPlayer.Play();
        }
        private async void mir24_click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            JObject streams = JObject.Parse(await webClient.DownloadStringTaskAsync(apiuwp));
            byte[] newBytes = Convert.FromBase64String((string)streams["tv_channelsuwp"][21]["url_live"]);
            string livehls = Encoding.UTF8.GetString(newBytes);
            mediaPlayerElement.Source = MediaSource.CreateFromUri(new Uri(livehls));
            mediaPlayerElement.MediaPlayer.Play();
        }

        private async void che_click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            JObject sts = JObject.Parse(await webClient.DownloadStringTaskAsync("https://media.mediavitrina.ru/api/v2/che/playlist/ctc-che_as_array.json" + token + token3));
            string livehls = (string)sts["hls"][0];
            mediaPlayerElement.Source = MediaSource.CreateFromUri(new Uri(livehls));
            mediaPlayerElement.MediaPlayer.Play();
        }

        private async void uott_click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            JObject sts = JObject.Parse(await webClient.DownloadStringTaskAsync("https://media.mediavitrina.ru/api/v2/utv/playlist/u_ott_as_array.json" + token + token3));
            string livehls = (string)sts["hls"][0];
            mediaPlayerElement.Source = MediaSource.CreateFromUri(new Uri(livehls));
            mediaPlayerElement.MediaPlayer.Play();
        }

        private async void subbota_click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            JObject sts = JObject.Parse(await webClient.DownloadStringTaskAsync(umamedia + "4ca525c601cc011f61348465fc6c09da/?format=json&referer=http://superkanal.ru"));
            string livehls = (string)sts["live_streams"]["hls"][0]["url"];
            mediaPlayerElement.Source = MediaSource.CreateFromUri(new Uri(livehls));
            mediaPlayerElement.MediaPlayer.Play();
        }

        private async void tv2x2_click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            JObject sts = JObject.Parse(await webClient.DownloadStringTaskAsync(umamedia + "dcab9b90a33239837c0f71682d6606da/?format=json"));
            string livehls = (string)sts["live_streams"]["hls"][0]["url"];
            mediaPlayerElement.Source = MediaSource.CreateFromUri(new Uri(livehls));
            mediaPlayerElement.MediaPlayer.Play();
        }

        private async void tnt4_click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            JObject sts = JObject.Parse(await webClient.DownloadStringTaskAsync(umamedia + "b0200b6f7a08fb0aad4e1289f491d1ea/?format=json"));
            string livehls = (string)sts["live_streams"]["hls"][0]["url"];
            mediaPlayerElement.Source = MediaSource.CreateFromUri(new Uri(livehls));
            mediaPlayerElement.MediaPlayer.Play();
        }

        private async void disney_click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            JObject sts = JObject.Parse(await webClient.DownloadStringTaskAsync("https://media.mediavitrina.ru/api/v2/disney/playlist/disney_ott_as_array.json" + token + token3));
            string livehls = (string)sts["hls"][0];
            mediaPlayerElement.Source = MediaSource.CreateFromUri(new Uri(livehls));
            mediaPlayerElement.MediaPlayer.Play();
        }

        private async void tvnews360_Click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            JObject streams = JObject.Parse(await webClient.DownloadStringTaskAsync(apiuwp));
            byte[] newBytes = Convert.FromBase64String((string)streams["tv_channelsuwp"][32]["url_live"]);
            string livehls = Encoding.UTF8.GetString(newBytes);
            mediaPlayerElement.Source = MediaSource.CreateFromUri(new Uri(livehls));
            mediaPlayerElement.MediaPlayer.Play();
        }

        private async void myplanet_Click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            JObject streams = JObject.Parse(await webClient.DownloadStringTaskAsync(apiuwp));
            byte[] newBytes = Convert.FromBase64String((string)streams["tv_channelsuwp"][33]["url_live"]);
            string livehls = Encoding.UTF8.GetString(newBytes);
            mediaPlayerElement.Source = MediaSource.CreateFromUri(new Uri(livehls));
            mediaPlayerElement.IsFullWindow = true;
            mediaPlayerElement.MediaPlayer.Play();
        }

        private async void matchstrana_Click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            JObject sts = JObject.Parse(await webClient.DownloadStringTaskAsync(umamedia + "54e136e9feb7544034daa03ba9aeab0d/?format=json"));
            string livehls = (string)sts["live_streams"]["hls"][0]["url"];
            mediaPlayerElement.Source = MediaSource.CreateFromUri(new Uri(livehls));
            mediaPlayerElement.MediaPlayer.Play();
        }

        private async void tv360_Click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            JObject streams = JObject.Parse(await webClient.DownloadStringTaskAsync(apiuwp));
            byte[] newBytes = Convert.FromBase64String((string)streams["tv_channelsuwp"][31]["url_live"]);
            string livehls = Encoding.UTF8.GetString(newBytes);
            mediaPlayerElement.Source = MediaSource.CreateFromUri(new Uri(livehls));
            mediaPlayerElement.MediaPlayer.Play();
        }

        private async void doverie_Click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            JObject streams = JObject.Parse(await webClient.DownloadStringTaskAsync(apiuwp));
            byte[] newBytes = Convert.FromBase64String((string)streams["tv_channelsuwp"][30]["url_live"]);
            string livehls = Encoding.UTF8.GetString(newBytes);
            mediaPlayerElement.Source = MediaSource.CreateFromUri(new Uri(livehls));
            mediaPlayerElement.MediaPlayer.Play();
        }

        private async void moscow24_Click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            JObject russia1 = JObject.Parse(await webClient.DownloadStringTaskAsync(vgtrkmedia + "1661"));
            string livehls = (string)russia1["data"]["playlist"]["medialist"][0]["sources"]["m3u8"]["auto"];
            mediaPlayerElement.Source = MediaSource.CreateFromUri(new Uri(livehls));
            mediaPlayerElement.MediaPlayer.Play();
        }

        private async void vestifm_Click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            JObject russia1 = JObject.Parse(await webClient.DownloadStringTaskAsync(vgtrkmedia + "52035"));
            string livehls = (string)russia1["data"]["playlist"]["medialist"][0]["sources"]["m3u8"]["auto"];
            mediaPlayerElement.Source = MediaSource.CreateFromUri(new Uri(livehls));
            mediaPlayerElement.MediaPlayer.Play();
        }

        private async void eurosport2_Click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            JObject streams = JObject.Parse(await webClient.DownloadStringTaskAsync("https://token.stb.md/api/Flussonic/stream/EUROSPORT2HD_H264/metadata.json"));
            string livehls = (string)streams["variants"][0]["url"];
            mediaPlayerElement.Source = MediaSource.CreateFromUri(new Uri(livehls));
            mediaPlayerElement.MediaPlayer.Play();
        }

        private async void ehomoscow_Click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            JObject streams = JObject.Parse(await webClient.DownloadStringTaskAsync(apiuwp));
            byte[] newBytes = Convert.FromBase64String((string)streams["tv_channelsuwp"][36]["url_live"]);
            string livehls = Encoding.UTF8.GetString(newBytes);
            mediaPlayerElement.Source = MediaSource.CreateFromUri(new Uri(livehls));
            mediaPlayerElement.MediaPlayer.Play();
        }

        private async void musicboxgold_Click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            JObject streams = JObject.Parse(await webClient.DownloadStringTaskAsync(apiuwp));
            byte[] newBytes = Convert.FromBase64String((string)streams["tv_channelsuwp"][37]["url_live"]);
            string livehls = Encoding.UTF8.GetString(newBytes);
            mediaPlayerElement.Source = MediaSource.CreateFromUri(new Uri(livehls));
            mediaPlayerElement.MediaPlayer.Play();
        }

        private async void tntmusic_Click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            JObject streams = JObject.Parse(await webClient.DownloadStringTaskAsync(rutubeapi + "10351051/?referer=https://tntmusic.ru/"));
            string livehls = (string)streams["live_streams"]["hls"][0]["url"];
            mediaPlayerElement.Source = MediaSource.CreateFromUri(new Uri(livehls));
            mediaPlayerElement.MediaPlayer.Play();
        }

        private async void smile_Click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            JObject streams = JObject.Parse(await webClient.DownloadStringTaskAsync(apiuwp));
            byte[] newBytes = Convert.FromBase64String((string)streams["tv_channelsuwp"][39]["url_live"]);
            string livehls = Encoding.UTF8.GetString(newBytes);
            mediaPlayerElement.Source = MediaSource.CreateFromUri(new Uri(livehls));
            mediaPlayerElement.MediaPlayer.Play();
        }

        private async void ntcsev_Click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            JObject streams = JObject.Parse(await webClient.DownloadStringTaskAsync(apiuwp));
            byte[] newBytes = Convert.FromBase64String((string)streams["tv_channelsuwp"][40]["url_live"]);
            string livehls = Encoding.UTF8.GetString(newBytes);
            mediaPlayerElement.Source = MediaSource.CreateFromUri(new Uri(livehls));
            mediaPlayerElement.MediaPlayer.Play();
        }

        private async void start_Click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            JObject streams = JObject.Parse(await webClient.DownloadStringTaskAsync(apiuwp));
            byte[] newBytes = Convert.FromBase64String((string)streams["tv_channelsuwp"][41]["url_live"]);
            string livehls = Encoding.UTF8.GetString(newBytes);
            mediaPlayerElement.Source = MediaSource.CreateFromUri(new Uri(livehls));
            mediaPlayerElement.MediaPlayer.Play();
        }

        private async void zagorodhdint_Click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            JObject streams = JObject.Parse(await webClient.DownloadStringTaskAsync(apiuwp));
            byte[] newBytes = Convert.FromBase64String((string)streams["tv_channelsuwp"][42]["url_live"]);
            string livehls = Encoding.UTF8.GetString(newBytes);
            mediaPlayerElement.Source = MediaSource.CreateFromUri(new Uri(livehls));
            mediaPlayerElement.MediaPlayer.Play();
        }

        private async void jiviactivno_Click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            JObject streams = JObject.Parse(await webClient.DownloadStringTaskAsync(api24h + "5046/stream?access_token=" + ac1 + "&format=json"));
            string livehls = (string)streams["hls"];
            mediaPlayerElement.Source = MediaSource.CreateFromUri(new Uri(livehls));
            mediaPlayerElement.MediaPlayer.Play();
        }

        private async void davinci_Click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            JObject sts = JObject.Parse(await webClient.DownloadStringTaskAsync(moretvmediavitrina + "da_vinci_as_array.json" + token + token3));
            string livehls = (string)sts["hls"][0];
            mediaPlayerElement.Source = MediaSource.CreateFromUri(new Uri(livehls));
            mediaPlayerElement.MediaPlayer.Play();
        }

        private async void europaplustv_Click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            JObject streams = JObject.Parse(await webClient.DownloadStringTaskAsync(apiuwp));
            byte[] newBytes = Convert.FromBase64String((string)streams["tv_channelsuwp"][45]["url_live"]);
            string livehls = Encoding.UTF8.GetString(newBytes);
            mediaPlayerElement.Source = MediaSource.CreateFromUri(new Uri(livehls));
            mediaPlayerElement.MediaPlayer.Play();
        }

        private async void ctckidshd_Click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            JObject sts = JObject.Parse(await webClient.DownloadStringTaskAsync(moretvmediavitrina + "ctc_kids_as_array.json" + token + token3));
            string livehls = (string)sts["hls"][0];
            mediaPlayerElement.Source = MediaSource.CreateFromUri(new Uri(livehls));
            mediaPlayerElement.MediaPlayer.Play();
        }

        private async void gulligirl_Click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            JObject streams = JObject.Parse(await webClient.DownloadStringTaskAsync(apiuwp));
            byte[] newBytes = Convert.FromBase64String((string)streams["tv_channelsuwp"][47]["url_live"]);
            string livehls = Encoding.UTF8.GetString(newBytes);
            mediaPlayerElement.Source = MediaSource.CreateFromUri(new Uri(livehls));
            mediaPlayerElement.MediaPlayer.Play();
        }

        private async void firstspace_Click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            JObject streams = JObject.Parse(await webClient.DownloadStringTaskAsync("https://token.stb.md/api/Flussonic/stream/PERVYY_KOSMICHESKIYHD/metadata.json"));
            string livehls = (string)streams["variants"][0]["url"];
            mediaPlayerElement.Source = MediaSource.CreateFromUri(new Uri(livehls));
            mediaPlayerElement.MediaPlayer.Play();
        }

        private async void vipmegahithd_Click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            JObject sts = JObject.Parse(await webClient.DownloadStringTaskAsync(moretvmediavitrina + "vip_megahit_as_array.json" + token + token3));
            string livehls = (string)sts["hls"][0];
            mediaPlayerElement.Source = MediaSource.CreateFromUri(new Uri(livehls));
            mediaPlayerElement.MediaPlayer.Play();
        }

        private async void vipcomedyhd_Click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            JObject sts = JObject.Parse(await webClient.DownloadStringTaskAsync(moretvmediavitrina + "vip_comedy_as_array.json" + token + token3));
            string livehls = (string)sts["hls"][0];
            mediaPlayerElement.Source = MediaSource.CreateFromUri(new Uri(livehls));
            mediaPlayerElement.MediaPlayer.Play();
        }

        private async void vippremierehd_Click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            JObject sts = JObject.Parse(await webClient.DownloadStringTaskAsync(moretvmediavitrina + "vip_premiere_hd_as_array.json" + token + token3));
            string livehls = (string)sts["hls"][0];
            mediaPlayerElement.Source = MediaSource.CreateFromUri(new Uri(livehls));
            mediaPlayerElement.MediaPlayer.Play();
        }

        private async void vipserialhd_Click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            JObject sts = JObject.Parse(await webClient.DownloadStringTaskAsync(moretvmediavitrina + "vip_serial_as_array.json" + token + token3));
            string livehls = (string)sts["hls"][0];
            mediaPlayerElement.Source = MediaSource.CreateFromUri(new Uri(livehls));
            mediaPlayerElement.MediaPlayer.Play();
        }

        private async void viasathistory_Click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            JObject sts = JObject.Parse(await webClient.DownloadStringTaskAsync(moretvmediavitrina + "viasat_history_as_array.json" + token + token3));
            string livehls = (string)sts["hls"][0];
            mediaPlayerElement.Source = MediaSource.CreateFromUri(new Uri(livehls));
            mediaPlayerElement.MediaPlayer.Play();
        }

        private async void viasatexplore_Click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            JObject sts = JObject.Parse(await webClient.DownloadStringTaskAsync(moretvmediavitrina + "viasat_nature_as_array.json" + token + token3));
            string livehls = (string)sts["hls"][0];
            mediaPlayerElement.Source = MediaSource.CreateFromUri(new Uri(livehls));
            mediaPlayerElement.MediaPlayer.Play();
        }

        private async void viasatnature_Click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            JObject sts = JObject.Parse(await webClient.DownloadStringTaskAsync(moretvmediavitrina + "viasat_explore_as_array.json" + token + token3));
            string livehls = (string)sts["hls"][0];
            mediaPlayerElement.Source = MediaSource.CreateFromUri(new Uri(livehls));
            mediaPlayerElement.MediaPlayer.Play();
        }

        private async void discovery_Click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            JObject streams = JObject.Parse(await webClient.DownloadStringTaskAsync("https://token.stb.md/api/Flussonic/stream/DISCOVERY_CHANNEL/metadata.json"));
            string livehls = (string)streams["variants"][0]["url"];
            mediaPlayerElement.Source = MediaSource.CreateFromUri(new Uri(livehls));
            mediaPlayerElement.MediaPlayer.Play();
        }

        private async void tv1000_Click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            JObject sts = JObject.Parse(await webClient.DownloadStringTaskAsync(moretvmediavitrina + "tv1000_as_array.json" + token + token3));
            string livehls = (string)sts["hls"][0];
            mediaPlayerElement.Source = MediaSource.CreateFromUri(new Uri(livehls));
            mediaPlayerElement.MediaPlayer.Play();
        }

        private async void tv1000action_Click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            JObject sts = JObject.Parse(await webClient.DownloadStringTaskAsync(moretvmediavitrina + "tv1000_action_as_array.json" + token + token3));
            string livehls = (string)sts["hls"][0];
            mediaPlayerElement.Source = MediaSource.CreateFromUri(new Uri(livehls));
            mediaPlayerElement.MediaPlayer.Play();
        }

        private async void tv1000ruskino_Click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            JObject sts = JObject.Parse(await webClient.DownloadStringTaskAsync(moretvmediavitrina + "tv1000_russian_kino_as_array.json" + token + token3));
            string livehls = (string)sts["hls"][0];
            mediaPlayerElement.Source = MediaSource.CreateFromUri(new Uri(livehls));
            mediaPlayerElement.MediaPlayer.Play();
        }

        private async void discoveryid_Click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            JObject streams = JObject.Parse(await webClient.DownloadStringTaskAsync("https://token.stb.md/api/Flussonic/stream/IDXTRA_HD/metadata.json"));
            string livehls = (string)streams["variants"][0]["url"];
            mediaPlayerElement.Source = MediaSource.CreateFromUri(new Uri(livehls));
            mediaPlayerElement.MediaPlayer.Play();
        }

        private async void natgeo_Click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            JObject sts = JObject.Parse(await webClient.DownloadStringTaskAsync(moretvmediavitrina + "national_geographic_as_array.json" + token + token3));
            string livehls = (string)sts["hls"][0];
            mediaPlayerElement.Source = MediaSource.CreateFromUri(new Uri(livehls));
            mediaPlayerElement.MediaPlayer.Play();
        }

        private async void tv78spb_Click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            JObject sts = JObject.Parse(await webClient.DownloadStringTaskAsync("https://media.mediavitrina.ru/api/v2/tk78/playlist/tk78_as_array.json" + token + token3));
            string livehls = (string)sts["hls"][0];
            mediaPlayerElement.Source = MediaSource.CreateFromUri(new Uri(livehls));
            mediaPlayerElement.MediaPlayer.Play();
        }

        private async void viasatsporthd_Click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            JObject sts = JObject.Parse(await webClient.DownloadStringTaskAsync(moretvmediavitrina + "viasat_sport_as_array.json" + token + token3));
            string livehls = (string)sts["hls"][0];
            mediaPlayerElement.Source = MediaSource.CreateFromUri(new Uri(livehls));
            mediaPlayerElement.MediaPlayer.Play();
        }

        private async void ufctv_Click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            JObject sts = JObject.Parse(await webClient.DownloadStringTaskAsync(moretvmediavitrina + "ufc_as_array.json" + token + token3));
            string livehls = (string)sts["hls"][0];
            mediaPlayerElement.Source = MediaSource.CreateFromUri(new Uri(livehls));
            mediaPlayerElement.MediaPlayer.Play();
        }

        private async void foxhd_Click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            JObject sts = JObject.Parse(await webClient.DownloadStringTaskAsync(moretvmediavitrina + "fox_as_array.json" + token + token3));
            string livehls = (string)sts["hls"][0];
            mediaPlayerElement.Source = MediaSource.CreateFromUri(new Uri(livehls));
            mediaPlayerElement.MediaPlayer.Play();
        }

        private async void foxlifehd_Click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            JObject sts = JObject.Parse(await webClient.DownloadStringTaskAsync(moretvmediavitrina + "fox_life_as_array.json" + token + token3));
            string livehls = (string)sts["hls"][0];
            mediaPlayerElement.Source = MediaSource.CreateFromUri(new Uri(livehls));
            mediaPlayerElement.MediaPlayer.Play();
        }

        public async void loadingimage()
        {
            WebClient webClient = new WebClient();
            JObject logos = JObject.Parse(await webClient.DownloadStringTaskAsync(apiuwp));
            ImageBrush imgB = new ImageBrush();
            BitmapImage btpImg = new BitmapImage();
            ImageBrush imgB2 = new ImageBrush();
            BitmapImage btpImg2 = new BitmapImage();
            ImageBrush imgB3 = new ImageBrush();
            BitmapImage btpImg3 = new BitmapImage();
            ImageBrush imgB4 = new ImageBrush();
            BitmapImage btpImg4 = new BitmapImage();
            ImageBrush imgB5 = new ImageBrush();
            BitmapImage btpImg5 = new BitmapImage();
            ImageBrush imgB6 = new ImageBrush();
            BitmapImage btpImg6 = new BitmapImage();
            ImageBrush imgB7 = new ImageBrush();
            BitmapImage btpImg7 = new BitmapImage();
            ImageBrush imgB8 = new ImageBrush();
            BitmapImage btpImg8 = new BitmapImage();
            ImageBrush imgB9 = new ImageBrush();
            BitmapImage btpImg9 = new BitmapImage();
            ImageBrush imgB10 = new ImageBrush();
            BitmapImage btpImg10 = new BitmapImage();
            ImageBrush imgB11 = new ImageBrush();
            BitmapImage btpImg11 = new BitmapImage();
            ImageBrush imgB12 = new ImageBrush();
            BitmapImage btpImg12 = new BitmapImage();
            ImageBrush imgB13 = new ImageBrush();
            BitmapImage btpImg13 = new BitmapImage();
            ImageBrush imgB14 = new ImageBrush();
            BitmapImage btpImg14 = new BitmapImage();
            ImageBrush imgB15 = new ImageBrush();
            BitmapImage btpImg15 = new BitmapImage();
            ImageBrush imgB16 = new ImageBrush();
            BitmapImage btpImg16 = new BitmapImage();
            ImageBrush imgB17 = new ImageBrush();
            BitmapImage btpImg17 = new BitmapImage();
            ImageBrush imgB18 = new ImageBrush();
            BitmapImage btpImg18 = new BitmapImage();
            ImageBrush imgB19 = new ImageBrush();
            BitmapImage btpImg19 = new BitmapImage();
            ImageBrush imgB20 = new ImageBrush();
            BitmapImage btpImg20 = new BitmapImage();
            ImageBrush imgB21 = new ImageBrush();
            BitmapImage btpImg21 = new BitmapImage();
            ImageBrush imgB22 = new ImageBrush();
            BitmapImage btpImg22 = new BitmapImage();
            ImageBrush imgB23 = new ImageBrush();
            BitmapImage btpImg23 = new BitmapImage();
            ImageBrush imgB24 = new ImageBrush();
            BitmapImage btpImg24 = new BitmapImage();
            ImageBrush imgB25 = new ImageBrush();
            BitmapImage btpImg25 = new BitmapImage();
            ImageBrush imgB26 = new ImageBrush();
            BitmapImage btpImg26 = new BitmapImage();
            ImageBrush imgB27 = new ImageBrush();
            BitmapImage btpImg27 = new BitmapImage();
            ImageBrush imgB28 = new ImageBrush();
            BitmapImage btpImg28 = new BitmapImage();
            ImageBrush imgB29 = new ImageBrush();
            BitmapImage btpImg29 = new BitmapImage();
            ImageBrush imgB30 = new ImageBrush();
            BitmapImage btpImg30 = new BitmapImage();
            ImageBrush imgB31 = new ImageBrush();
            BitmapImage btpImg31 = new BitmapImage();
            ImageBrush imgB32 = new ImageBrush();
            BitmapImage btpImg32 = new BitmapImage();
            ImageBrush imgB33 = new ImageBrush();
            BitmapImage btpImg33 = new BitmapImage();
            ImageBrush imgB34 = new ImageBrush();
            BitmapImage btpImg34 = new BitmapImage();
            ImageBrush imgB35 = new ImageBrush();
            BitmapImage btpImg35 = new BitmapImage();
            ImageBrush imgB36 = new ImageBrush();
            BitmapImage btpImg36 = new BitmapImage();
            ImageBrush imgB37 = new ImageBrush();
            BitmapImage btpImg37 = new BitmapImage();
            ImageBrush imgB38 = new ImageBrush();
            BitmapImage btpImg38 = new BitmapImage();
            ImageBrush imgB39 = new ImageBrush();
            BitmapImage btpImg39 = new BitmapImage();
            ImageBrush imgB40 = new ImageBrush();
            BitmapImage btpImg40 = new BitmapImage();
            ImageBrush imgB41 = new ImageBrush();
            BitmapImage btpImg41 = new BitmapImage();
            ImageBrush imgB42 = new ImageBrush();
            BitmapImage btpImg42 = new BitmapImage();
            ImageBrush imgB43 = new ImageBrush();
            BitmapImage btpImg43 = new BitmapImage();
            ImageBrush imgB44 = new ImageBrush();
            BitmapImage btpImg44 = new BitmapImage();
            ImageBrush imgB45 = new ImageBrush();
            BitmapImage btpImg45 = new BitmapImage();
            ImageBrush imgB46 = new ImageBrush();
            BitmapImage btpImg46 = new BitmapImage();
            ImageBrush imgB47 = new ImageBrush();
            BitmapImage btpImg47 = new BitmapImage();
            ImageBrush imgB48 = new ImageBrush();
            BitmapImage btpImg48 = new BitmapImage();
            ImageBrush imgB49 = new ImageBrush();
            BitmapImage btpImg49 = new BitmapImage();
            ImageBrush imgB50 = new ImageBrush();
            BitmapImage btpImg50 = new BitmapImage();
            ImageBrush imgB51 = new ImageBrush();
            BitmapImage btpImg51 = new BitmapImage();
            ImageBrush imgB52 = new ImageBrush();
            BitmapImage btpImg52 = new BitmapImage();
            ImageBrush imgB53 = new ImageBrush();
            BitmapImage btpImg53 = new BitmapImage();
            ImageBrush imgB54 = new ImageBrush();
            BitmapImage btpImg54 = new BitmapImage();
            ImageBrush imgB55 = new ImageBrush();
            BitmapImage btpImg55 = new BitmapImage();
            ImageBrush imgB56 = new ImageBrush();
            BitmapImage btpImg56 = new BitmapImage();
            ImageBrush imgB57 = new ImageBrush();
            BitmapImage btpImg57 = new BitmapImage();
            ImageBrush imgB58 = new ImageBrush();
            BitmapImage btpImg58 = new BitmapImage();
            ImageBrush imgB59 = new ImageBrush();
            BitmapImage btpImg59 = new BitmapImage();
            ImageBrush imgB60 = new ImageBrush();
            BitmapImage btpImg60 = new BitmapImage();
            ImageBrush imgB61 = new ImageBrush();
            BitmapImage btpImg61 = new BitmapImage();
            ImageBrush imgB62 = new ImageBrush();
            BitmapImage btpImg62 = new BitmapImage();
            ImageBrush imgB63 = new ImageBrush();
            BitmapImage btpImg63 = new BitmapImage();
            ImageBrush imgB64 = new ImageBrush();
            BitmapImage btpImg64 = new BitmapImage();
            ImageBrush imgB65 = new ImageBrush();
            BitmapImage btpImg65 = new BitmapImage();
            ImageBrush imgB66 = new ImageBrush();
            BitmapImage btpImg66 = new BitmapImage();
            ImageBrush imgB67 = new ImageBrush();
            BitmapImage btpImg67 = new BitmapImage();
            btpImg.UriSource = new Uri((string)logos["tv_channelsuwp"][0]["full_logo"]);
            imgB.ImageSource = btpImg;
            imgB.Stretch = Stretch.Fill;
            perviy.Foreground = imgB;
            perviy.Background = imgB;
            perviy.Content = "";
            btpImg2.UriSource = new Uri((string)logos["tv_channelsuwp"][1]["full_logo"]);
            imgB2.ImageSource = btpImg2;
            imgB2.Stretch = Stretch.UniformToFill;
            russia1.Foreground = imgB2;
            russia1.Background = imgB2;
            russia1.Content = "";
            btpImg3.UriSource = new Uri((string)logos["tv_channelsuwp"][2]["full_logo"]);
            imgB3.ImageSource = btpImg3;
            imgB3.Stretch = Stretch.UniformToFill;
            match.Foreground = imgB3;
            match.Background = imgB3;
            match.Content = "";
            btpImg4.UriSource = new Uri((string)logos["tv_channelsuwp"][3]["full_logo"]);
            imgB4.ImageSource = btpImg4;
            imgB4.Stretch = Stretch.UniformToFill;
            ntv.Foreground = imgB4;
            ntv.Background = imgB4;
            ntv.Content = "";
            btpImg5.UriSource = new Uri((string)logos["tv_channelsuwp"][4]["full_logo"]);
            imgB5.ImageSource = btpImg5;
            imgB5.Stretch = Stretch.UniformToFill;
            pyatii.Foreground = imgB5;
            pyatii.Background = imgB5;
            pyatii.Content = "";
            btpImg6.UriSource = new Uri((string)logos["tv_channelsuwp"][5]["full_logo"]);
            imgB6.ImageSource = btpImg6;
            imgB6.Stretch = Stretch.UniformToFill;
            russiak.Foreground = imgB6;
            russiak.Background = imgB6;
            russiak.Content = "";
            btpImg7.UriSource = new Uri((string)logos["tv_channelsuwp"][6]["full_logo"]);
            imgB7.ImageSource = btpImg7;
            imgB7.Stretch = Stretch.UniformToFill;
            russia24.Foreground = imgB7;
            russia24.Background = imgB7;
            russia24.Content = "";
            btpImg8.UriSource = new Uri((string)logos["tv_channelsuwp"][7]["full_logo"]);
            imgB8.ImageSource = btpImg8;
            imgB8.Stretch = Stretch.UniformToFill;
            karusel.Foreground = imgB8;
            karusel.Background = imgB8;
            karusel.Content = "";
            btpImg9.UriSource = new Uri((string)logos["tv_channelsuwp"][8]["full_logo"]);
            imgB9.ImageSource = btpImg9;
            imgB9.Stretch = Stretch.UniformToFill;
            otr.Foreground = imgB9;
            otr.Background = imgB9;
            otr.Content = "";
            btpImg10.UriSource = new Uri((string)logos["tv_channelsuwp"][9]["full_logo"]);
            imgB10.ImageSource = btpImg10;
            imgB10.Stretch = Stretch.UniformToFill;
            twc.Foreground = imgB10;
            twc.Background = imgB10;
            twc.Content = "";
            btpImg11.UriSource = new Uri((string)logos["tv_channelsuwp"][10]["full_logo"]);
            imgB11.ImageSource = btpImg11;
            imgB11.Stretch = Stretch.UniformToFill;
            rentv.Foreground = imgB11;
            rentv.Background = imgB11;
            rentv.Content = "";
            btpImg12.UriSource = new Uri((string)logos["tv_channelsuwp"][11]["full_logo"]);
            imgB12.ImageSource = btpImg12;
            imgB12.Stretch = Stretch.UniformToFill;
            spas.Foreground = imgB12;
            spas.Background = imgB12;
            spas.Content = "";
            btpImg13.UriSource = new Uri((string)logos["tv_channelsuwp"][12]["full_logo"]);
            imgB13.ImageSource = btpImg13;
            imgB13.Stretch = Stretch.UniformToFill;
            sts.Foreground = imgB13;
            sts.Background = imgB13;
            sts.Content = "";
            btpImg14.UriSource = new Uri((string)logos["tv_channelsuwp"][13]["full_logo"]);
            imgB14.ImageSource = btpImg14;
            imgB14.Stretch = Stretch.UniformToFill;
            domashnii.Foreground = imgB14;
            domashnii.Background = imgB14;
            domashnii.Content = "";
            btpImg15.UriSource = new Uri((string)logos["tv_channelsuwp"][14]["full_logo"]);
            imgB15.ImageSource = btpImg15;
            imgB15.Stretch = Stretch.UniformToFill;
            tv3.Foreground = imgB15;
            tv3.Background = imgB15;
            tv3.Content = "";
            btpImg16.UriSource = new Uri((string)logos["tv_channelsuwp"][15]["full_logo"]);
            imgB16.ImageSource = btpImg16;
            imgB16.Stretch = Stretch.UniformToFill;
            friday.Foreground = imgB16;
            friday.Background = imgB16;
            friday.Content = "";
            btpImg17.UriSource = new Uri((string)logos["tv_channelsuwp"][16]["full_logo"]);
            imgB17.ImageSource = btpImg17;
            imgB17.Stretch = Stretch.UniformToFill;
            zvezda.Foreground = imgB17;
            zvezda.Background = imgB17;
            zvezda.Content = "";
            btpImg18.UriSource = new Uri((string)logos["tv_channelsuwp"][17]["full_logo"]);
            imgB18.ImageSource = btpImg18;
            imgB18.Stretch = Stretch.UniformToFill;
            mir.Foreground = imgB18;
            mir.Background = imgB18;
            mir.Content = "";
            btpImg19.UriSource = new Uri((string)logos["tv_channelsuwp"][18]["full_logo"]);
            imgB19.ImageSource = btpImg19;
            imgB19.Stretch = Stretch.UniformToFill;
            tnt.Foreground = imgB19;
            tnt.Background = imgB19;
            tnt.Content = "";
            btpImg20.UriSource = new Uri((string)logos["tv_channelsuwp"][19]["full_logo"]);
            imgB20.ImageSource = btpImg20;
            imgB20.Stretch = Stretch.UniformToFill;
            muztv.Foreground = imgB20;
            muztv.Background = imgB20;
            muztv.Content = "";
            btpImg21.UriSource = new Uri((string)logos["tv_channelsuwp"][20]["full_logo"]);
            imgB21.ImageSource = btpImg21;
            imgB21.Stretch = Stretch.UniformToFill;
            kinotv.Foreground = imgB21;
            kinotv.Background = imgB21;
            kinotv.Content = "";
            btpImg22.UriSource = new Uri((string)logos["tv_channelsuwp"][21]["full_logo"]);
            imgB22.ImageSource = btpImg22;
            imgB22.Stretch = Stretch.UniformToFill;
            mir24.Foreground = imgB22;
            mir24.Background = imgB22;
            mir24.Content = "";
            btpImg23.UriSource = new Uri((string)logos["tv_channelsuwp"][22]["full_logo"]);
            imgB23.ImageSource = btpImg23;
            imgB23.Stretch = Stretch.UniformToFill;
            che.Foreground = imgB23;
            che.Background = imgB23;
            che.Content = "";
            btpImg24.UriSource = new Uri((string)logos["tv_channelsuwp"][23]["full_logo"]);
            imgB24.ImageSource = btpImg24;
            imgB24.Stretch = Stretch.UniformToFill;
            yu.Foreground = imgB24;
            yu.Background = imgB24;
            yu.Content = "";
            btpImg25.UriSource = new Uri((string)logos["tv_channelsuwp"][24]["full_logo"]);
            imgB25.ImageSource = btpImg25;
            imgB25.Stretch = Stretch.UniformToFill;
            subbota.Foreground = imgB25;
            subbota.Background = imgB25;
            subbota.Content = "";
            btpImg26.UriSource = new Uri((string)logos["tv_channelsuwp"][25]["full_logo"]);
            imgB26.ImageSource = btpImg26;
            imgB26.Stretch = Stretch.UniformToFill;
            _2x2.Foreground = imgB26;
            _2x2.Background = imgB26;
            _2x2.Content = "";
            btpImg27.UriSource = new Uri((string)logos["tv_channelsuwp"][26]["full_logo"]);
            imgB27.ImageSource = btpImg27;
            imgB27.Stretch = Stretch.UniformToFill;
            tnt4.Foreground = imgB27;
            tnt4.Background = imgB27;
            tnt4.Content = "";
            btpImg28.UriSource = new Uri((string)logos["tv_channelsuwp"][27]["full_logo"]);
            imgB28.ImageSource = btpImg28;
            imgB28.Stretch = Stretch.UniformToFill;
            disney.Foreground = imgB28;
            disney.Background = imgB28;
            disney.Content = "";
            btpImg29.UriSource = new Uri((string)logos["tv_channelsuwp"][28]["full_logo"]);
            imgB29.ImageSource = btpImg29;
            imgB29.Stretch = Stretch.Uniform;
            vestifm.Foreground = imgB29;
            vestifm.Background = imgB29;
            vestifm.Content = "";
            btpImg30.UriSource = new Uri((string)logos["tv_channelsuwp"][29]["full_logo"]);
            imgB30.ImageSource = btpImg30;
            imgB30.Stretch = Stretch.UniformToFill;
            moscow24.Foreground = imgB30;
            moscow24.Background = imgB30;
            moscow24.Content = "";
            btpImg31.UriSource = new Uri((string)logos["tv_channelsuwp"][30]["full_logo"]);
            imgB31.ImageSource = btpImg31;
            imgB31.Stretch = Stretch.UniformToFill;
            doverie.Foreground = imgB31;
            doverie.Background = imgB31;
            doverie.Content = "";
            btpImg32.UriSource = new Uri((string)logos["tv_channelsuwp"][31]["full_logo"]);
            imgB32.ImageSource = btpImg32;
            imgB32.Stretch = Stretch.UniformToFill;
            tv360.Foreground = imgB32;
            tv360.Background = imgB32;
            tv360.Content = "";
            btpImg33.UriSource = new Uri((string)logos["tv_channelsuwp"][32]["full_logo"]);
            imgB33.ImageSource = btpImg33;
            imgB33.Stretch = Stretch.UniformToFill;
            tvnews360.Foreground = imgB33;
            tvnews360.Background = imgB33;
            tvnews360.Content = "";
            btpImg34.UriSource = new Uri((string)logos["tv_channelsuwp"][33]["full_logo"]);
            imgB34.ImageSource = btpImg34;
            imgB34.Stretch = Stretch.UniformToFill;
            myplanet.Foreground = imgB34;
            myplanet.Background = imgB34;
            myplanet.Content = "";
            btpImg35.UriSource = new Uri((string)logos["tv_channelsuwp"][34]["full_logo"]);
            imgB35.ImageSource = btpImg35;
            imgB35.Stretch = Stretch.UniformToFill;
            matchstrana.Foreground = imgB35;
            matchstrana.Background = imgB35;
            matchstrana.Content = "";
            btpImg36.UriSource = new Uri((string)logos["tv_channelsuwp"][35]["full_logo"]);
            imgB36.ImageSource = btpImg36;
            imgB36.Stretch = Stretch.UniformToFill;
            eurosport2.Foreground = imgB36;
            eurosport2.Background = imgB36;
            eurosport2.Content = "";
            btpImg37.UriSource = new Uri((string)logos["tv_channelsuwp"][36]["full_logo"]);
            imgB37.ImageSource = btpImg37;
            imgB37.Stretch = Stretch.UniformToFill;
            ehomoscow.Foreground = imgB37;
            ehomoscow.Background = imgB37;
            ehomoscow.Content = "";
            btpImg38.UriSource = new Uri((string)logos["tv_channelsuwp"][37]["full_logo"]);
            imgB38.ImageSource = btpImg38;
            imgB38.Stretch = Stretch.UniformToFill;
            musicboxgold.Foreground = imgB38;
            musicboxgold.Background = imgB38;
            musicboxgold.Content = "";
            btpImg39.UriSource = new Uri((string)logos["tv_channelsuwp"][38]["full_logo"]);
            imgB39.ImageSource = btpImg39;
            imgB39.Stretch = Stretch.UniformToFill;
            tntmusic.Foreground = imgB39;
            tntmusic.Background = imgB39;
            tntmusic.Content = "";
            btpImg40.UriSource = new Uri((string)logos["tv_channelsuwp"][39]["full_logo"]);
            imgB40.ImageSource = btpImg40;
            imgB40.Stretch = Stretch.Uniform;
            smile.Foreground = imgB40;
            smile.Background = imgB40;
            smile.Content = "";
            btpImg41.UriSource = new Uri((string)logos["tv_channelsuwp"][40]["full_logo"]);
            imgB41.ImageSource = btpImg41;
            imgB41.Stretch = Stretch.UniformToFill;
            ntcsev.Foreground = imgB41;
            ntcsev.Background = imgB41;
            ntcsev.Content = "";
            btpImg42.UriSource = new Uri((string)logos["tv_channelsuwp"][41]["full_logo"]);
            imgB42.ImageSource = btpImg42;
            imgB42.Stretch = Stretch.UniformToFill;
            start.Foreground = imgB42;
            start.Background = imgB42;
            start.Content = "";
            btpImg43.UriSource = new Uri((string)logos["tv_channelsuwp"][42]["full_logo"]);
            imgB43.ImageSource = btpImg43;
            imgB43.Stretch = Stretch.UniformToFill;
            zagorodhdint.Foreground = imgB43;
            zagorodhdint.Background = imgB43;
            zagorodhdint.Content = "";
            btpImg44.UriSource = new Uri((string)logos["tv_channelsuwp"][43]["full_logo"]);
            imgB44.ImageSource = btpImg44;
            imgB44.Stretch = Stretch.UniformToFill;
            jiviactivno.Foreground = imgB44;
            jiviactivno.Background = imgB44;
            jiviactivno.Content = "";
            btpImg45.UriSource = new Uri((string)logos["tv_channelsuwp"][44]["full_logo"]);
            imgB45.ImageSource = btpImg45;
            imgB45.Stretch = Stretch.UniformToFill;
            davinci.Foreground = imgB45;
            davinci.Background = imgB45;
            davinci.Content = "";
            btpImg46.UriSource = new Uri((string)logos["tv_channelsuwp"][45]["full_logo"]);
            imgB46.ImageSource = btpImg46;
            imgB46.Stretch = Stretch.UniformToFill;
            europaplustv.Foreground = imgB46;
            europaplustv.Background = imgB46;
            europaplustv.Content = "";
            btpImg47.UriSource = new Uri((string)logos["tv_channelsuwp"][46]["full_logo"]);
            imgB47.ImageSource = btpImg47;
            imgB47.Stretch = Stretch.UniformToFill;
            ctckidshd.Foreground = imgB47;
            ctckidshd.Background = imgB47;
            ctckidshd.Content = "";
            btpImg48.UriSource = new Uri((string)logos["tv_channelsuwp"][47]["full_logo"]);
            imgB48.ImageSource = btpImg48;
            imgB48.Stretch = Stretch.UniformToFill;
            gulligirl.Foreground = imgB48;
            gulligirl.Background = imgB48;
            gulligirl.Content = "";
            btpImg49.UriSource = new Uri((string)logos["tv_channelsuwp"][48]["full_logo"]);
            imgB49.ImageSource = btpImg49;
            imgB49.Stretch = Stretch.Uniform;
            firstspace.Foreground = imgB49;
            firstspace.Background = imgB49;
            firstspace.Content = "";
            btpImg50.UriSource = new Uri((string)logos["tv_channelsuwp"][49]["full_logo"]);
            imgB50.ImageSource = btpImg50;
            imgB50.Stretch = Stretch.UniformToFill;
            vipmegahithd.Foreground = imgB50;
            vipmegahithd.Background = imgB50;
            vipmegahithd.Content = "";
            btpImg51.UriSource = new Uri((string)logos["tv_channelsuwp"][50]["full_logo"]);
            imgB51.ImageSource = btpImg51;
            imgB51.Stretch = Stretch.UniformToFill;
            vipcomedyhd.Foreground = imgB51;
            vipcomedyhd.Background = imgB51;
            vipcomedyhd.Content = "";
            btpImg52.UriSource = new Uri((string)logos["tv_channelsuwp"][51]["full_logo"]);
            imgB52.ImageSource = btpImg52;
            imgB52.Stretch = Stretch.UniformToFill;
            vippremierehd.Foreground = imgB52;
            vippremierehd.Background = imgB52;
            vippremierehd.Content = "";
            btpImg53.UriSource = new Uri((string)logos["tv_channelsuwp"][52]["full_logo"]);
            imgB53.ImageSource = btpImg53;
            imgB53.Stretch = Stretch.UniformToFill;
            vipserialhd.Foreground = imgB53;
            vipserialhd.Background = imgB53;
            vipserialhd.Content = "";
            btpImg54.UriSource = new Uri((string)logos["tv_channelsuwp"][53]["full_logo"]);
            imgB54.ImageSource = btpImg54;
            imgB54.Stretch = Stretch.UniformToFill;
            viasathistory.Foreground = imgB54;
            viasathistory.Background = imgB54;
            viasathistory.Content = "";
            btpImg55.UriSource = new Uri((string)logos["tv_channelsuwp"][54]["full_logo"]);
            imgB55.ImageSource = btpImg55;
            imgB55.Stretch = Stretch.UniformToFill;
            viasatexplore.Foreground = imgB55;
            viasatexplore.Background = imgB55;
            viasatexplore.Content = "";
            btpImg56.UriSource = new Uri((string)logos["tv_channelsuwp"][55]["full_logo"]);
            imgB56.ImageSource = btpImg56;
            imgB56.Stretch = Stretch.UniformToFill;
            viasatnature.Foreground = imgB56;
            viasatnature.Background = imgB56;
            viasatnature.Content = "";
            btpImg57.UriSource = new Uri((string)logos["tv_channelsuwp"][56]["full_logo"]);
            imgB57.ImageSource = btpImg57;
            imgB57.Stretch = Stretch.UniformToFill;
            discovery.Foreground = imgB57;
            discovery.Background = imgB57;
            discovery.Content = "";
            btpImg58.UriSource = new Uri((string)logos["tv_channelsuwp"][57]["full_logo"]);
            imgB58.ImageSource = btpImg58;
            imgB58.Stretch = Stretch.UniformToFill;
            tv1000.Foreground = imgB58;
            tv1000.Background = imgB58;
            tv1000.Content = "";
            btpImg59.UriSource = new Uri((string)logos["tv_channelsuwp"][58]["full_logo"]);
            imgB59.ImageSource = btpImg59;
            imgB59.Stretch = Stretch.UniformToFill;
            tv1000action.Foreground = imgB59;
            tv1000action.Background = imgB59;
            tv1000action.Content = "";
            btpImg60.UriSource = new Uri((string)logos["tv_channelsuwp"][59]["full_logo"]);
            imgB60.ImageSource = btpImg60;
            imgB60.Stretch = Stretch.UniformToFill;
            tv1000ruskino.Foreground = imgB60;
            tv1000ruskino.Background = imgB60;
            tv1000ruskino.Content = "";
            btpImg61.UriSource = new Uri((string)logos["tv_channelsuwp"][60]["full_logo"]);
            imgB61.ImageSource = btpImg61;
            imgB61.Stretch = Stretch.UniformToFill;
            discoveryid.Foreground = imgB61;
            discoveryid.Background = imgB61;
            discoveryid.Content = "";
            btpImg62.UriSource = new Uri((string)logos["tv_channelsuwp"][61]["full_logo"]);
            imgB62.ImageSource = btpImg62;
            imgB62.Stretch = Stretch.UniformToFill;
            natgeo.Foreground = imgB62;
            natgeo.Background = imgB62;
            natgeo.Content = "";
            btpImg63.UriSource = new Uri((string)logos["tv_channelsuwp"][62]["full_logo"]);
            imgB63.ImageSource = btpImg63;
            imgB63.Stretch = Stretch.UniformToFill;
            tv78spb.Foreground = imgB63;
            tv78spb.Background = imgB63;
            tv78spb.Content = "";
            btpImg64.UriSource = new Uri((string)logos["tv_channelsuwp"][63]["full_logo"]);
            imgB64.ImageSource = btpImg64;
            imgB64.Stretch = Stretch.UniformToFill;
            viasatsporthd.Foreground = imgB64;
            viasatsporthd.Background = imgB64;
            viasatsporthd.Content = "";
            btpImg65.UriSource = new Uri((string)logos["tv_channelsuwp"][64]["full_logo"]);
            imgB65.ImageSource = btpImg65;
            imgB65.Stretch = Stretch.UniformToFill;
            ufctv.Foreground = imgB65;
            ufctv.Background = imgB65;
            ufctv.Content = "";
            btpImg66.UriSource = new Uri((string)logos["tv_channelsuwp"][65]["full_logo"]);
            imgB66.ImageSource = btpImg66;
            imgB66.Stretch = Stretch.UniformToFill;
            foxhd.Foreground = imgB66;
            foxhd.Background = imgB66;
            foxhd.Content = "";
            btpImg67.UriSource = new Uri((string)logos["tv_channelsuwp"][66]["full_logo"]);
            imgB67.ImageSource = btpImg67;
            imgB67.Stretch = Stretch.UniformToFill;
            foxlifehd.Foreground = imgB67;
            foxlifehd.Background = imgB67;
            foxlifehd.Content = "";
        }
    }
}