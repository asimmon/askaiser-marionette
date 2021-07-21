# Askaiser.Marionette

Askaiser.Marionette is a **test automation framework based on image and text recognition**. It includes a C# source generator that allows you to quickly interact with properties generated by images from your project or elsewhere. The framework is built on top of **OpenCV** and **Tesseract OCR** and only works on Windows for now.

[![NuGet version (Askaiser.Marionette)](https://img.shields.io/nuget/v/Askaiser.Marionette.svg?logo=nuget)](https://www.nuget.org/packages/Askaiser.Marionette/)
[![build](https://img.shields.io/github/workflow/status/asimmon/askaiser-marionette/CI%20Build?logo=github)](https://github.com/asimmon/askaiser-marionette/actions/workflows/ci.yml)


## Askaiser.Marionette in action

* `00:00` : Capture screenshots of the app you're testing,
* `00:08` : Rename and organize your screenshots in a meaningful way,
* `00:22` : Drop your screenshots in your project,
* `00:30` : Use `ImageLibrary` to **automatically** generate properties from your screenshots,
* `01:06` : Use `MarionetteDriver` to interact with the generated properties (or even text recognized by the OCR)!

https://user-images.githubusercontent.com/14242083/126416123-aebd0fce-825f-4ece-90e9-762503dc4cab.mp4


## Why use Askaiser.Marionette

* Unlike other test automation frameworks, Askaiser.Marionette **does not rely on hardcoded identifiers, CSS or XPath selectors**. It uses image and text recognition to ensure that you interact with elements that are **actually visible** on the screen.
* Maintaining identifiers, CSS and XPath selectors over time can be hard. Capturing small screenshots and finding text with an OCR is not.
* With the built-in C# source generator, you can start **writing the test code right away**.
* You can interact with the whole operating system, instead of a single application.
* This means you can also test desktop applications!
* You can use it for automation only, like a bot.
* It works well with BDD and [SpecFlow](https://specflow.org/).


## Getting started

```
dotnet add package Askaiser.Marionette
```

It supports **.NET Standard 2.0**, **.NET Standard 2.1** an **.NET 5**, but only on Windows for now.

```csharp
using (var driver = MarionetteDriver.Create(/* optional DriverOptions */))
{
    // in this exemple, we enter a username and password in a login page
    await driver.WaitFor(library.Pages.Login.Title, waitFor: TimeSpan.FromSeconds(5));

    await driver.SingleClick(library.Pages.Login.Email);
    await driver.TypeText("much@automated.foo", sleepAfter: TimeSpan.FromSeconds(0.5));
    await driver.SingleClick(library.Pages.Login.Password);
    await driver.TypeText("V3ry5ecre7!", sleepAfter: TimeSpan.FromSeconds(0.5));

    await driver.SingleClick(library.Pages.Login.Submit);
    
    // insert moar magic here
}
```

The [sample project](https://github.com/asimmon/askaiser-marionette/tree/readme-demo/samples/Askaiser.Marionette.ConsoleApp) will show you the basics of using this library.


## Creating image and text elements manually

#### Image search

```csharp
// Instead of relying on the source generator that works with image files, you can create an ImageElement manually
var bytes = await File.ReadAllBytesAsync("path/to/your/image.png");
var image = new ImageElement(name: "sidebar-close-button", content: bytes, threshold: 0.95m, grayscale: false);
```

* `ImageElement.Threshold` is a floating number between 0 and 1. It defines the accuracy of the image search process. `0.95` is the default value.
* `ImageElement.Grayscale` defines whether or not the engine will apply grayscaling preprocessing. Image search is faster with grayscaling.

#### Text search

```csharp
Although many methods accept a simple string as an element, you can manually create a TextElement
var text = new TextElement("Save changes", options: TextOptions.BlackAndWhite | TextOptions.Negative);
```

**Text options** are flags that define the preprocessing behavior of your monitor's screenshots before executing the OCR.
* `TextOptions.None` : do not use preprocessing,
* `TextOptions.Grayscale` : Use grayscaling,
* `TextOptions.BlackAndWhite` : Use grayscaling and binarization (this is the default value),
* `TextOptions.Negative` : Use negative preprocessing, very helpful with white text on dark background.


## Source generator behavior

*TODO: I will explain how to define settings for each individual image (threshold and grayscaling), as well as grouping images into an array property. All of this can be done by using special keywords in each image file name.*


## Show me the APIs

Many parameters are optional. Most methods that look for an element (image or text) expect to find **only one occurrence** of this element. `ElementNotFoundException` and `MultipleElementFoundException` can be thrown.

You can use `DriverOptions.FailureScreenshotPath` to automatically save screenshots when these exceptions occur.

### Configuration and utilities

```csharp
static Create()
static Create(DriverOptions options)

GetScreenshot()
GetCurrentMonitor()
GetMonitors()
SetCurrentMonitor(int monitorIndex)
SetCurrentMonitor(MonitorDescription monitor)
SetMouseSpeed(MouseSpeed speed)
Sleep(int millisecondsDelay)
Sleep(TimeSpan delay)
```

### Basic methods

```csharp
WaitFor(IElement element, TimeSpan waitFor, Rectangle searchRect)
WaitForAll(IEnumerable<IElement> elements, TimeSpan waitFor, Rectangle searchRect)
WaitForAny(IEnumerable<IElement> elements, TimeSpan waitFor, Rectangle searchRect)
SingleClick(int x, int y)
DoubleClick(int x, int y)
TripleClick(int x, int y)
RightClick(int x, int y)
MoveTo(int x, int y)
DragFrom(int x, int y)
DropTo(int x, int y)
TypeText(string text, TimeSpan sleepAfter)
KeyPress(VirtualKeyCode[] keyCodes)
KeyDown(VirtualKeyCode[] keyCodes)
KeyUp(VirtualKeyCode[] keyCodes)
ScrollDown(int scrollTicks)
ScrollUp(int scrollTicks)
ScrollDownUntilVisible(IElement element, TimeSpan totalDuration, int scrollTicks, Rectangle searchRect)
ScrollUpUntilVisible(IElement element, TimeSpan totalDuration, int scrollTicks, Rectangle searchRect)
```

### Mouse interaction with an element

```csharp
MoveTo(IElement element, TimeSpan waitFor, Rectangle searchRect)
SingleClick(IElement element, TimeSpan waitFor, Rectangle searchRect)
DoubleClick(IElement element, TimeSpan waitFor, Rectangle searchRect)
TripleClick(IElement element, TimeSpan waitFor, Rectangle searchRect)
RightClick(IElement element, TimeSpan waitFor, Rectangle searchRect)
DragFrom(IElement element, TimeSpan waitFor, Rectangle searchRect)
DropTo(IElement element, TimeSpan waitFor, Rectangle searchRect)
```

### Check for element visibility

```csharp
IsVisible(IElement element, TimeSpan waitFor, Rectangle searchRect)
IsAnyVisible(IEnumerable<IElement> elements, TimeSpan waitFor, Rectangle searchRect)
AreAllVisible(IEnumerable<IElement> elements, TimeSpan waitFor, Rectangle searchRect)
```

### Mouse interaction with the first available element of a collection

```csharp
MoveToAny(IEnumerable<IElement> elements, TimeSpan waitFor, Rectangle searchRect)
SingleClickAny(IEnumerable<IElement> elements, TimeSpan waitFor, Rectangle searchRect)
DoubleClickAny(IEnumerable<IElement> elements, TimeSpan waitFor, Rectangle searchRect)
TripleClickAny(IEnumerable<IElement> elements, TimeSpan waitFor, Rectangle searchRect)
RightClickAny(IEnumerable<IElement> elements, TimeSpan waitFor, Rectangle searchRect)
DragFromAny(IEnumerable<IElement> elements, TimeSpan waitFor, Rectangle searchRect)
DropToAny(IEnumerable<IElement> elements, TimeSpan waitFor, Rectangle searchRect)
```

### Text-based actions

```csharp
WaitFor(string text, TimeSpan waitFor, Rectangle searchRect, TextOptions textOptions)
MoveTo(string text, TimeSpan waitFor, Rectangle searchRect, TextOptions textOptions)
SingleClick(string text, TimeSpan waitFor, Rectangle searchRect, TextOptions textOptions)
DoubleClick(string text, TimeSpan waitFor, Rectangle searchRect, TextOptions textOptions)
TripleClick(string text, TimeSpan waitFor, Rectangle searchRect, TextOptions textOptions)
RightClick(string text, TimeSpan waitFor, Rectangle searchRect, TextOptions textOptions)
DragFrom(string text, TimeSpan waitFor, Rectangle searchRect, TextOptions textOptions)
DropTo(string text, TimeSpan waitFor, Rectangle searchRect, TextOptions textOptions)
IsVisible(string text, TimeSpan waitFor, Rectangle searchRect, TextOptions textOptions)
```

### Mouse interaction with points

```csharp
MoveTo(Point coordinates)
SingleClick(Point coordinates)
DoubleClick(Point coordinates)
TripleClick(Point coordinates)
RightClick(Point coordinates)
DragFrom(Point coordinates)
DropTo(Point coordinates)
```

### Mouse interaction with `WaitFor` search result

```csharp
MoveTo(SearchResult searchResult)
SingleClick(SearchResult searchResult)
DoubleClick(SearchResult searchResult)
TripleClick(SearchResult searchResult)
RightClick(SearchResult searchResult)
DragFrom(SearchResult searchResult)
DropTo(SearchResult searchResult)
```

### Key press with single key code

```csharp
KeyPress(VirtualKeyCode keyCode, TimeSpan sleepAfter)
KeyDown(VirtualKeyCode keyCode, TimeSpan sleepAfter)
KeyUp(VirtualKeyCode keyCode, TimeSpan sleepAfter)
```

### `System.Drawing.Image`-based actions

```csharp
WaitFor(Image image, TimeSpan waitFor, Rectangle searchRect, decimal threshold, bool grayscale)
MoveTo(Image image, TimeSpan waitFor, Rectangle searchRect, decimal threshold, bool grayscale)
SingleClick(Image image, TimeSpan waitFor, Rectangle searchRect, decimal threshold, bool grayscale)
DoubleClick(Image image, TimeSpan waitFor, Rectangle searchRect, decimal threshold, bool grayscale)
TripleClick(Image image, TimeSpan waitFor, Rectangle searchRect, decimal threshold, bool grayscale)
RightClick(Image image, TimeSpan waitFor, Rectangle searchRect, decimal threshold, bool grayscale)
DragFrom(Image image, TimeSpan waitFor, Rectangle searchRect, decimal threshold, bool grayscale)
DropTo(Image image, TimeSpan waitFor, Rectangle searchRect, decimal threshold, bool grayscale)
IsVisible(Image image, TimeSpan waitFor, Rectangle searchRect, decimal threshold, bool grayscale)
```

### Finding elements locations without throwing not found exceptions or multiple element found exceptions

```csharp
FindLocations(IElement element, TimeSpan waitFor, Rectangle searchRect)
FindLocations(string text, TimeSpan waitFor, Rectangle searchRect, TextOptions textOptions)
FindLocations(Image image, TimeSpan waitFor, Rectangle searchRect, decimal threshold, bool grayscale)
```
