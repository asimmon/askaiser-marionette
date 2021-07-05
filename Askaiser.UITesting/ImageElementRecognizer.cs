﻿using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace Askaiser.UITesting
{
    internal sealed class ImageElementRecognizer : IElementRecognizer
    {
        public async Task<SearchResult> Recognize(Bitmap screenshot, IElement element)
        {
            SearchResult SearchInternal()
            {
                var imageElement = (ImageElement)element;
                var stopwatch = Stopwatch.StartNew();

                // https://stackoverflow.com/a/35346975/825695
                using var tpl = imageElement.ToBitmap()
                    .ConvertAndDispose(x => x.ToMat())
                    .ConvertAndDispose(x => imageElement.Grayscale ? x.CvtColor(ColorConversionCodes.BGRA2GRAY) : x);

                using var res = screenshot.ToMat()
                    .ConvertAndDispose(x => imageElement.Grayscale ? x.CvtColor(ColorConversionCodes.BGRA2GRAY) : x)
                    .MatchTemplate(tpl, TemplateMatchModes.CCoeffNormed)
                    .ConvertAndDispose(x => x.Threshold(imageElement.Threshold, 1d, ThresholdTypes.Tozero));

                var areas = new List<Rectangle>();

                var loDiff = new Scalar(0.1);
                var upDiff = new Scalar(1.0);

                while (true)
                {
                    res.MinMaxLoc(out _, out var maxval, out _, out var maxloc);

                    var notFound = maxval < imageElement.Threshold;
                    if (notFound)
                    {
                        stopwatch.Stop();
                        return new SearchResult(element, areas);
                    }

                    areas.Add(new Rectangle(maxloc.X, maxloc.Y, maxloc.X + tpl.Width, maxloc.Y + tpl.Height));
                    res.FloodFill(maxloc, new Scalar(0), out _, loDiff, upDiff);
                }
            }

            return await Task.Run(SearchInternal).ConfigureAwait(false);
        }
    }
}