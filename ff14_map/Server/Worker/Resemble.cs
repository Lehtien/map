using ff14_map.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenCvSharp;
using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.IO;
using System.Drawing;

namespace ff14_map.Server.Worker
{
    public class Resemble
    {
        public Maps[] GetResemble(string RelativePath, string src, Map[] maps, WholeMap[] wholeMaps)
        {
            Mat mat = new Mat();
            Mat output3 = new Mat();
            AKAZE akaze = AKAZE.Create();
            Mat descriptor1 = new Mat();
            Mat descriptor2 = new Mat();

            DescriptorMatcher matcher;
            DMatch[] match;
            var matches = new List<DMatch[]>();
            matcher = DescriptorMatcher.Create("BruteForce");
            var dists = new Dictionary<Map, double>();
            var resemblances = new Maps[2];

            try
            {
                src = src.Substring(src.IndexOf(',') + 1);
                if (src.IsBase64String())
                {
                    var bytes = Convert.FromBase64String(src);
                    mat = Cv2.ImDecode(bytes, ImreadModes.Color);
                }
                else if (Uri.IsWellFormedUriString(src, UriKind.Absolute))
                {
                    using var webClient = new WebClient();
                    var bytes = webClient.DownloadData(src);
                    mat = Cv2.ImDecode(bytes, ImreadModes.Color);
                }
                else
                {
                    return new Maps[0];
                }

                var size = mat.Size();
                if (size.Width > 640 || size.Height > 480)
                {
                    return new Maps[0];
                }

                akaze.DetectAndCompute(mat, null, out KeyPoint[] key_point1, descriptor1);

                foreach (Map map in maps)
                {
                    Mat m = new Mat();
                    string filePath = RelativePath + map.FileName;
                    m = Cv2.ImRead(filePath);
                    akaze.DetectAndCompute(m, null, out KeyPoint[] key_point2, descriptor2);
                    match = matcher.Match(descriptor1, descriptor2);

                    double dist = 0;
                    foreach (var val in match)
                    {
                        dist += val.Distance;
                    }
                    dists.Add(map, dist / match.Length);
                }

                var small2 = dists.OrderBy(d => d.Value).Take(2);
                foreach (var (item, index) in small2.Select((item, index) => (item, index)))
                {
                    resemblances[index] = new Maps
                    {
                        Map = item.Key,
                        WholeMap = wholeMaps.SingleOrDefault(o => o.Area == item.Key.Area)
                    };
                }
            }
            catch
            {
                throw;
            }

            return resemblances;
        }
    }

    static class Base64
    {
        public static bool IsBase64String(this string s)
        {
            s = s.Trim();
            return (s.Length % 4 == 0) && Regex.IsMatch(s, @"^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.None);

        }

    }

}
