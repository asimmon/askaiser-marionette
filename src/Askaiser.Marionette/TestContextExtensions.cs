﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading.Tasks;

namespace Askaiser.Marionette
{
    public static class TestContextExtensions
    {
        #region Mouse interaction with the first available element of a collection

        public static async Task MoveToAny(this TestContext context, IEnumerable<IElement> elements, TimeSpan waitFor = default, Rectangle searchRect = default)
        {
            var result = await context.WaitForAny(elements, waitFor, searchRect).ConfigureAwait(false);
            await MoveTo(context, result).ConfigureAwait(false);
        }

        public static async Task SingleClickAny(this TestContext context, IEnumerable<IElement> elements, TimeSpan waitFor = default, Rectangle searchRect = default)
        {
            var result = await context.WaitForAny(elements, waitFor, searchRect).ConfigureAwait(false);
            await SingleClick(context, result).ConfigureAwait(false);
        }

        public static async Task DoubleClickAny(this TestContext context, IEnumerable<IElement> elements, TimeSpan waitFor = default, Rectangle searchRect = default)
        {
            var result = await context.WaitForAny(elements, waitFor, searchRect).ConfigureAwait(false);
            await DoubleClick(context, result).ConfigureAwait(false);
        }

        public static async Task TripleClickAny(this TestContext context, IEnumerable<IElement> elements, TimeSpan waitFor = default, Rectangle searchRect = default)
        {
            var result = await context.WaitForAny(elements, waitFor, searchRect).ConfigureAwait(false);
            await TripleClick(context, result).ConfigureAwait(false);
        }

        public static async Task RightClickAny(this TestContext context, IEnumerable<IElement> elements, TimeSpan waitFor = default, Rectangle searchRect = default)
        {
            var result = await context.WaitForAny(elements, waitFor, searchRect).ConfigureAwait(false);
            await RightClick(context, result).ConfigureAwait(false);
        }

        public static async Task DragFromAny(this TestContext context, IEnumerable<IElement> elements, TimeSpan waitFor = default, Rectangle searchRect = default)
        {
            var result = await context.WaitForAny(elements, waitFor, searchRect).ConfigureAwait(false);
            await DragFrom(context, result).ConfigureAwait(false);
        }

        public static async Task DropToAny(this TestContext context, IEnumerable<IElement> elements, TimeSpan waitFor = default, Rectangle searchRect = default)
        {
            var result = await context.WaitForAny(elements, waitFor, searchRect).ConfigureAwait(false);
            await DropTo(context, result).ConfigureAwait(false);
        }

        #endregion

        #region Mouse interaction with points

        public static async Task MoveTo(this TestContext context, Point coordinates)
        {
            var (x, y) = coordinates;
            await context.MoveTo(x, y).ConfigureAwait(false);
        }

        public static async Task SingleClick(this TestContext context, Point coordinates)
        {
            var (x, y) = coordinates;
            await context.SingleClick(x, y).ConfigureAwait(false);
        }

        public static async Task DoubleClick(this TestContext context, Point coordinates)
        {
            var (x, y) = coordinates;
            await context.DoubleClick(x, y).ConfigureAwait(false);
        }

        public static async Task TripleClick(this TestContext context, Point coordinates)
        {
            var (x, y) = coordinates;
            await context.TripleClick(x, y).ConfigureAwait(false);
        }

        public static async Task RightClick(this TestContext context, Point coordinates)
        {
            var (x, y) = coordinates;
            await context.RightClick(x, y).ConfigureAwait(false);
        }

        public static async Task DragFrom(this TestContext context, Point coordinates)
        {
            var (x, y) = coordinates;
            await context.DragFrom(x, y).ConfigureAwait(false);
        }

        public static async Task DropTo(this TestContext context, Point coordinates)
        {
            var (x, y) = coordinates;
            await context.DropTo(x, y).ConfigureAwait(false);
        }

        #endregion

        #region Mouse interaction with search result

        public static async Task MoveTo(this TestContext context, SearchResult searchResult) => await MoveTo(context, searchResult.Area.Center).ConfigureAwait(false);

        public static async Task SingleClick(this TestContext context, SearchResult searchResult) => await SingleClick(context, searchResult.Area.Center).ConfigureAwait(false);

        public static async Task DoubleClick(this TestContext context, SearchResult searchResult) => await DoubleClick(context, searchResult.Area.Center).ConfigureAwait(false);

        public static async Task TripleClick(this TestContext context, SearchResult searchResult) => await TripleClick(context, searchResult.Area.Center).ConfigureAwait(false);

        public static async Task RightClick(this TestContext context, SearchResult searchResult) => await RightClick(context, searchResult.Area.Center).ConfigureAwait(false);

        public static async Task DragFrom(this TestContext context, SearchResult searchResult) => await DragFrom(context, searchResult.Area.Center).ConfigureAwait(false);

        public static async Task DropTo(this TestContext context, SearchResult searchResult) => await DropTo(context, searchResult.Area.Center).ConfigureAwait(false);

        #endregion

        #region Mouse interaction with an element

        public static async Task MoveTo(this TestContext context, IElement element, TimeSpan waitFor = default, Rectangle searchRect = default)
        {
            var result = await context.WaitFor(element, waitFor, searchRect).ConfigureAwait(false);
            await MoveTo(context, result).ConfigureAwait(false);
        }

        public static async Task SingleClick(this TestContext context, IElement element, TimeSpan waitFor = default, Rectangle searchRect = default)
        {
            var result = await context.WaitFor(element, waitFor, searchRect).ConfigureAwait(false);
            await SingleClick(context, result).ConfigureAwait(false);
        }

        public static async Task DoubleClick(this TestContext context, IElement element, TimeSpan waitFor = default, Rectangle searchRect = default)
        {
            var result = await context.WaitFor(element, waitFor, searchRect).ConfigureAwait(false);
            await DoubleClick(context, result).ConfigureAwait(false);
        }

        public static async Task TripleClick(this TestContext context, IElement element, TimeSpan waitFor = default, Rectangle searchRect = default)
        {
            var result = await context.WaitFor(element, waitFor, searchRect).ConfigureAwait(false);
            await TripleClick(context, result).ConfigureAwait(false);
        }

        public static async Task RightClick(this TestContext context, IElement element, TimeSpan waitFor = default, Rectangle searchRect = default)
        {
            var result = await context.WaitFor(element, waitFor, searchRect).ConfigureAwait(false);
            await RightClick(context, result).ConfigureAwait(false);
        }

        public static async Task DragFrom(this TestContext context, IElement element, TimeSpan waitFor = default, Rectangle searchRect = default)
        {
            var result = await context.WaitFor(element, waitFor, searchRect).ConfigureAwait(false);
            await DragFrom(context, result).ConfigureAwait(false);
        }

        public static async Task DropTo(this TestContext context, IElement element, TimeSpan waitFor = default, Rectangle searchRect = default)
        {
            var result = await context.WaitFor(element, waitFor, searchRect).ConfigureAwait(false);
            await DropTo(context, result).ConfigureAwait(false);
        }

        #endregion

        #region Element visibility

        public static async Task<bool> IsVisible(this TestContext context, IElement element, TimeSpan waitFor = default, Rectangle searchRect = default)
        {
            try
            {
                var result = await context.WaitFor(element, waitFor, searchRect, NotFoundBehavior.Ignore).ConfigureAwait(false);
                return result.Success;
            }
            catch (UITestingException)
            {
                return false;
            }
        }

        public static async Task<bool> IsAnyVisible(this TestContext context, IEnumerable<IElement> elements, TimeSpan waitFor = default, Rectangle searchRect = default)
        {
            try
            {
                var result = await context.WaitForAny(elements, waitFor, searchRect, NotFoundBehavior.Ignore).ConfigureAwait(false);
                return result.Success;
            }
            catch (UITestingException)
            {
                return false;
            }
        }

        public static async Task<bool> AreAllVisible(this TestContext context, IEnumerable<IElement> elements, TimeSpan waitFor = default, Rectangle searchRect = default)
        {
            try
            {
                var result = await context.WaitForAll(elements, waitFor, searchRect, NotFoundBehavior.Ignore).ConfigureAwait(false);
                return result.All(x => x.Success);
            }
            catch (UITestingException)
            {
                return false;
            }
        }

        #endregion

        #region Key press with sleep after

        public static async Task KeyPress(this TestContext context, VirtualKeyCode[] keyCodes, TimeSpan sleepAfter = default)
        {
            await context.KeyPress(keyCodes).ConfigureAwait(false);
            if (sleepAfter > TimeSpan.Zero)
            {
                await context.Sleep(sleepAfter).ConfigureAwait(false);
            }
        }

        public static async Task KeyDown(this TestContext context, VirtualKeyCode[] keyCodes, TimeSpan sleepAfter = default)
        {
            await context.KeyDown(keyCodes).ConfigureAwait(false);
            if (sleepAfter > TimeSpan.Zero)
            {
                await context.Sleep(sleepAfter).ConfigureAwait(false);
            }
        }

        public static async Task KeyUp(this TestContext context, VirtualKeyCode[] keyCodes, TimeSpan sleepAfter = default)
        {
            await context.KeyUp(keyCodes).ConfigureAwait(false);
            if (sleepAfter > TimeSpan.Zero)
            {
                await context.Sleep(sleepAfter).ConfigureAwait(false);
            }
        }

        #endregion

        #region Text-based actions

        public static async Task<SearchResult> WaitFor(this TestContext context, string text, TimeSpan waitFor = default, Rectangle searchRect = default, TextOptions textOptions = TextOptions.BlackAndWhite)
        {
            return await context.WaitFor(new TextElement(text, textOptions), waitFor, searchRect).ConfigureAwait(false);
        }

        public static async Task MoveTo(this TestContext context, string text, TimeSpan waitFor = default, Rectangle searchRect = default, TextOptions textOptions = TextOptions.BlackAndWhite)
        {
            await MoveTo(context, new TextElement(text, textOptions), waitFor, searchRect).ConfigureAwait(false);
        }

        public static async Task SingleClick(this TestContext context, string text, TimeSpan waitFor = default, Rectangle searchRect = default, TextOptions textOptions = TextOptions.BlackAndWhite)
        {
            await SingleClick(context, new TextElement(text, textOptions), waitFor, searchRect).ConfigureAwait(false);
        }

        public static async Task DoubleClick(this TestContext context, string text, TimeSpan waitFor = default, Rectangle searchRect = default, TextOptions textOptions = TextOptions.BlackAndWhite)
        {
            await DoubleClick(context, new TextElement(text, textOptions), waitFor, searchRect).ConfigureAwait(false);
        }

        public static async Task TripleClick(this TestContext context, string text, TimeSpan waitFor = default, Rectangle searchRect = default, TextOptions textOptions = TextOptions.BlackAndWhite)
        {
            await TripleClick(context, new TextElement(text, textOptions), waitFor, searchRect).ConfigureAwait(false);
        }

        public static async Task RightClick(this TestContext context, string text, TimeSpan waitFor = default, Rectangle searchRect = default, TextOptions textOptions = TextOptions.BlackAndWhite)
        {
            await RightClick(context, new TextElement(text, textOptions), waitFor, searchRect).ConfigureAwait(false);
        }

        public static async Task DragFrom(this TestContext context, string text, TimeSpan waitFor = default, Rectangle searchRect = default, TextOptions textOptions = TextOptions.BlackAndWhite)
        {
            await DragFrom(context, new TextElement(text, textOptions), waitFor, searchRect).ConfigureAwait(false);
        }

        public static async Task DropTo(this TestContext context, string text, TimeSpan waitFor = default, Rectangle searchRect = default, TextOptions textOptions = TextOptions.BlackAndWhite)
        {
            await DropTo(context, new TextElement(text, textOptions), waitFor, searchRect).ConfigureAwait(false);
        }

        public static async Task<bool> IsVisible(this TestContext context, string text, TimeSpan waitFor = default, Rectangle searchRect = default, TextOptions textOptions = TextOptions.BlackAndWhite)
        {
            return await IsVisible(context, new TextElement(text, textOptions), waitFor, searchRect).ConfigureAwait(false);
        }

        #endregion

        #region System.Drawing.Image-based actions

        public static async Task<SearchResult> WaitFor(this TestContext context, Image image, TimeSpan waitFor = default, Rectangle searchRect = default, decimal threshold = ImageElement.DefaultThreshold, bool grayscale = false)
        {
            return await context.WaitFor(new ImageElement("image", image.GetBytes(ImageFormat.Png), threshold, grayscale), waitFor, searchRect).ConfigureAwait(false);
        }

        public static async Task MoveTo(this TestContext context, Image image, TimeSpan waitFor = default, Rectangle searchRect = default, decimal threshold = ImageElement.DefaultThreshold, bool grayscale = false)
        {
            await MoveTo(context, new ImageElement("image", image.GetBytes(ImageFormat.Png), threshold, grayscale), waitFor, searchRect).ConfigureAwait(false);
        }

        public static async Task SingleClick(this TestContext context, Image image, TimeSpan waitFor = default, Rectangle searchRect = default, decimal threshold = ImageElement.DefaultThreshold, bool grayscale = false)
        {
            await SingleClick(context, new ImageElement("image", image.GetBytes(ImageFormat.Png), threshold, grayscale), waitFor, searchRect).ConfigureAwait(false);
        }

        public static async Task DoubleClick(this TestContext context, Image image, TimeSpan waitFor = default, Rectangle searchRect = default, decimal threshold = ImageElement.DefaultThreshold, bool grayscale = false)
        {
            await DoubleClick(context, new ImageElement("image", image.GetBytes(ImageFormat.Png), threshold, grayscale), waitFor, searchRect).ConfigureAwait(false);
        }

        public static async Task TripleClick(this TestContext context, Image image, TimeSpan waitFor = default, Rectangle searchRect = default, decimal threshold = ImageElement.DefaultThreshold, bool grayscale = false)
        {
            await TripleClick(context, new ImageElement("image", image.GetBytes(ImageFormat.Png), threshold, grayscale), waitFor, searchRect).ConfigureAwait(false);
        }

        public static async Task RightClick(this TestContext context, Image image, TimeSpan waitFor = default, Rectangle searchRect = default, decimal threshold = ImageElement.DefaultThreshold, bool grayscale = false)
        {
            await RightClick(context, new ImageElement("image", image.GetBytes(ImageFormat.Png), threshold, grayscale), waitFor, searchRect).ConfigureAwait(false);
        }

        public static async Task DragFrom(this TestContext context, Image image, TimeSpan waitFor = default, Rectangle searchRect = default, decimal threshold = ImageElement.DefaultThreshold, bool grayscale = false)
        {
            await DragFrom(context, new ImageElement("image", image.GetBytes(ImageFormat.Png), threshold, grayscale), waitFor, searchRect).ConfigureAwait(false);
        }

        public static async Task DropTo(this TestContext context, Image image, TimeSpan waitFor = default, Rectangle searchRect = default, decimal threshold = ImageElement.DefaultThreshold, bool grayscale = false)
        {
            await DropTo(context, new ImageElement("image", image.GetBytes(ImageFormat.Png), threshold, grayscale), waitFor, searchRect).ConfigureAwait(false);
        }

        public static async Task<bool> IsVisible(this TestContext context, Image image, TimeSpan waitFor = default, Rectangle searchRect = default, decimal threshold = ImageElement.DefaultThreshold, bool grayscale = false)
        {
            return await IsVisible(context, new ImageElement("image", image.GetBytes(ImageFormat.Png), threshold, grayscale), waitFor, searchRect).ConfigureAwait(false);
        }

        #endregion
    }
}
