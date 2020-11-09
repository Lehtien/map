using ff14_map.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OpenCvSharp;
using System.Reflection.PortableExecutable;
using ff14_map.Server.Worker;
using System.Drawing;
using System.Windows.Forms;
using ff14_map.Client.Pages;

namespace ff14_map.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class G12Controller : ControllerBase
    {
        const string RelativePath = @"..\Client\wwwroot\images\map\G12\";
        private static readonly Map[] G12 = new[]
        {
            // アム・アレーン
            new Map()
            {
                FileName = "amhAraeng_A.jpg",
                Area = "アム・アレーン",
                Point = "A",
                X = 12.3,
                Y = 14.2,
                Z = 1.1
            },
            new Map()
            {
                FileName = "amhAraeng_B.jpg",
                Area = "アム・アレーン",
                Point = "B",
                X = 13.2,
                Y = 30.0,
                Z = 0.5
            },
            new Map()
            {
                FileName = "amhAraeng_C.jpg",
                Area = "アム・アレーン",
                Point = "C",
                X = 32.4,
                Y = 8.6,
                Z = 0.6
            },
            new Map()
            {
                FileName = "amhAraeng_D.jpg",
                Area = "アム・アレーン",
                Point = "D",
                X = 36.1,
                Y = 11.5,
                Z = 0.4
            },
            new Map()
            {
                FileName = "amhAraeng_E.jpg",
                Area = "アム・アレーン",
                Point = "E",
                X = 27.6,
                Y = 12.8,
                Z = 0.8
            },
            new Map()
            {
                FileName = "amhAraeng_F.jpg",
                Area = "アム・アレーン",
                Point = "F",
                X = 34.0,
                Y = 17.2,
                Z = 0.8
            },
            new Map()
            {
                FileName = "amhAraeng_G.jpg",
                Area = "アム・アレーン",
                Point = "G",
                X = 26.8,
                Y = 23.6,
                Z = 0.7
            },
            new Map()
            {
                FileName = "amhAraeng_H.jpg",
                Area = "アム・アレーン",
                Point = "H",
                X = 30.2,
                Y = 30.7,
                Z = 0.5
            },
            // イルメグ
            new Map()
            {
                FileName = "ilMheg_A.jpg",
                Area = "イル・メグ",
                Point = "A",
                X = 33.2,
                Y = 10.4,
                Z = 0.9
            },
            new Map()
            {
                FileName = "ilMheg_B.jpg",
                Area = "イル・メグ",
                Point = "B",
                X = 31.0,
                Y = 4.0,
                Z = 1.0
            },
            new Map()
            {
                FileName = "ilMheg_C.jpg",
                Area = "イル・メグ",
                Point = "C",
                X = 25.1,
                Y = 12.4,
                Z = 0.0
            },
            new Map()
            {
                FileName = "ilMheg_D.jpg",
                Area = "イル・メグ",
                Point = "D",
                X = 21.7,
                Y = 7.6,
                Z = 0.5
            },
            new Map()
            {
                FileName = "ilMheg_E.jpg",
                Area = "イル・メグ",
                Point = "E",
                X = 10.5,
                Y = 13.1,
                Z = 0.7
            },
            new Map()
            {
                FileName = "ilMheg_F.jpg",
                Area = "イル・メグ",
                Point = "A",
                X = 7.3,
                Y = 17.4,
                Z = 0.3
            },
            new Map()
            {
                FileName = "ilMheg_G.jpg",
                Area = "イル・メグ",
                Point = "G",
                X = 12.9,
                Y = 20.6,
                Z = 0.0
            },
            new Map()
            {
                FileName = "ilMheg_H.jpg",
                Area = "イル・メグ",
                Point = "H",
                X = 14.2,
                Y = 27.5,
                Z = 0.2
            },
            // コルシア島
            new Map()
            {
                FileName = "kholusia_A.jpg",
                Area = "コルシア島",
                Point = "A",
                X = 34.8,
                Y = 10.7,
                Z = 2.7
            },
            new Map()
            {
                FileName = "kholusia_B.jpg",
                Area = "コルシア島",
                Point = "B",
                X = 30.8,
                Y = 17.2,
                Z = 3.0
            },
            new Map()
            {
                FileName = "kholusia_C.jpg",
                Area = "コルシア島",
                Point = "C",
                X = 20.5,
                Y = 9.2,
                Z = 4.2
            },
            new Map()
            {
                FileName = "kholusia_D.jpg",
                Area = "コルシア島",
                Point = "D",
                X = 20.0,
                Y = 16.9,
                Z = 3.4
            },
            new Map()
            {
                FileName = "kholusia_E.jpg",
                Area = "コルシア島",
                Point = "E",
                X = 13.5,
                Y = 16.7,
                Z = 3.5
            },
            new Map()
            {
                FileName = "kholusia_F.jpg",
                Area = "コルシア島",
                Point = "F",
                X = 11.9,
                Y = 13.8,
                Z = 3.7
            },
            new Map()
            {
                FileName = "kholusia_G.jpg",
                Area = "コルシア島",
                Point = "G",
                X = 7.7,
                Y = 18.0,
                Z = 3.5
            },
            new Map()
            {
                FileName = "kholusia_H.jpg",
                Area = "コルシア島",
                Point = "H",
                X = 33.2,
                Y = 31.4,
                Z = 0.0
            },
            // レイクランド
            new Map()
            {
                FileName = "lakeland_A.jpg",
                Area = "レイクランド",
                Point = "A",
                X = 18.2,
                Y = 7.6,
                Z = 1.0
            },
            new Map()
            {
                FileName = "lakeland_B.jpg",
                Area = "レイクランド",
                Point = "B",
                X = 10.7,
                Y = 11.7,
                Z = 0.7
            },
            new Map()
            {
                FileName = "lakeland_C.jpg",
                Area = "レイクランド",
                Point = "C",
                X = 13.7,
                Y = 12.8,
                Z = 0.9
            },
            new Map()
            {
                FileName = "lakeland_D.jpg",
                Area = "レイクランド",
                Point = "D",
                X = 17.9,
                Y = 17.0,
                Z = 0.1
            },
            new Map()
            {
                FileName = "lakeland_E.jpg",
                Area = "レイクランド",
                Point = "E",
                X = 8.3,
                Y = 21.0,
                Z = 0.6
            },
            new Map()
            {
                FileName = "lakeland_F.jpg",
                Area = "レイクランド",
                Point = "F",
                X = 10.5,
                Y = 25.3,
                Z = 0.0
            },
            new Map()
            {
                FileName = "lakeland_G.jpg",
                Area = "レイクランド",
                Point = "G",
                X = 38.2,
                Y = 13.8,
                Z = 0.8
            },
            new Map()
            {
                FileName = "lakeland_H.jpg",
                Area = "レイクランド",
                Point = "H",
                X = 34.7,
                Y = 25.7,
                Z = 0.1
            },
            // ラケティカ
            new Map()
            {
                FileName = "raktika_A.jpg",
                Area = "ラケティカ大森林",
                Point = "A",
                X = 34.4,
                Y = 17.0,
                Z = -0.5
            },
            new Map()
            {
                FileName = "raktika_B.jpg",
                Area = "ラケティカ大森林",
                Point = "B",
                X = 35.3,
                Y = 22.4,
                Z = 0.1
            },
            new Map()
            {
                FileName = "raktika_C.jpg",
                Area = "ラケティカ大森林",
                Point = "C",
                X = 24.5,
                Y = 15.3,
                Z = -0.1
            },
            new Map()
            {
                FileName = "raktika_D.jpg",
                Area = "ラケティカ大森林",
                Point = "D",
                X = 24.9,
                Y = 27.7,
                Z = -0.1
            },
            new Map()
            {
                FileName = "raktika_E.jpg",
                Area = "ラケティカ大森林",
                Point = "E",
                X = 22.6,
                Y = 32.4,
                Z = -0.3
            },
            new Map()
            {
                FileName = "raktika_F.jpg",
                Area = "ラケティカ大森林",
                Point = "F",
                X = 26.1,
                Y = 34.7,
                Z = -0.3
            },
            new Map()
            {
                FileName = "raktika_G.jpg",
                Area = "ラケティカ大森林",
                Point = "G",
                X = 11.6,
                Y = 19.5,
                Z = 0.1
            },
            new Map()
            {
                FileName = "raktika_H.jpg",
                Area = "ラケティカ大森林",
                Point = "H",
                X = 13.1,
                Y = 23.9,
                Z = 0.0
            },
            // テンペスト
            new Map()
            {
                FileName = "tempest_A.jpg",
                Area = "テンペスト",
                Point = "A",
                X = 37.3,
                Y = 17.7,
                Z = -1.4
            },
            new Map()
            {
                FileName = "tempest_B.jpg",
                Area = "テンペスト",
                Point = "B",
                X = 32.6,
                Y = 5.1,
                Z = -1.1
            },
            new Map()
            {
                FileName = "tempest_C.jpg",
                Area = "テンペスト",
                Point = "C",
                X = 30.1,
                Y = 20.9,
                Z = -2.0
            },
            new Map()
            {
                FileName = "tempest_D.jpg",
                Area = "テンペスト",
                Point = "D",
                X = 25.4,
                Y = 11.4,
                Z = -1.9
            },
            new Map()
            {
                FileName = "tempest_E.jpg",
                Area = "テンペスト",
                Point = "E",
                X = 19.0,
                Y = 8.2,
                Z = -1.4
            },
            new Map()
            {
                FileName = "tempest_F.jpg",
                Area = "テンペスト",
                Point = "F",
                X = 12.6,
                Y = 11.4,
                Z = -3.7
            },
            new Map()
            {
                FileName = "tempest_G.jpg",
                Area = "テンペスト",
                Point = "G",
                X = 13.8,
                Y = 14.9,
                Z = -4.3
            },
            new Map()
            {
                FileName = "tempest_H.jpg",
                Area = "テンペスト",
                Point = "H",
                X = 16.2,
                Y = 18.5,
                Z = -4.3
            }
        };

        private static readonly WholeMap[] G12WholeMap = new[]
        {
            new WholeMap
            {
                FileName = "amhAraeng.jpg",
                Area = "アム・アレーン"
            },
            new WholeMap
            {
                FileName = "ilMheg.jpg",
                Area = "イル・メグ"
            },
            new WholeMap
            {
                FileName = "kholusia.jpg",
                Area = "コルシア島"
            },
            new WholeMap
            {
                FileName = "lakeland.jpg",
                Area = "レイクランド"
            },
            new WholeMap
            {
                FileName = "raktika.jpg",
                Area = "ラケティカ大森林"
            },
            new WholeMap
            {
                FileName = "tempest.jpg",
                Area = "テンペスト"
            },
        };

#pragma warning disable IDE0052 // 読み取られていないプライベート メンバーを削除
        private readonly ILogger<G12Controller> logger;
#pragma warning restore IDE0052 // 読み取られていないプライベート メンバーを削除

        public G12Controller(ILogger<G12Controller> logger)
        {
            this.logger = logger;
        }

        //[HttpGet]
        ////public IEnumerable<WeatherForecast> Get()
        //public G12[] Get(string src)
        //{
        //}
        [HttpPost]
        public Maps[] Post([FromBody] string src)
        {
            var resemble = new Resemble();
            try
            {
                return resemble.GetResemble(RelativePath, src, G12, G12WholeMap);
            }
            catch (Exception e)
            {
                logger.LogError(e.StackTrace);
                return new Maps[0];
            }
        }
    }
}
