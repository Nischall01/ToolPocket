using System;
using System.Reflection;
using Avalonia.Media.Imaging;

namespace ToolPocket.Models;

public abstract class ImageExtractor
{
    public static void ListResources(string exePath)
    {
        var assembly = Assembly.LoadFile(exePath);
        foreach (var resourceName in assembly.GetManifestResourceNames()) Console.WriteLine(resourceName);
    }

    public static Bitmap? ExtractImage(string exePath, string resourceName)
    {
        var assembly = Assembly.LoadFile(exePath);
        using var stream = assembly.GetManifestResourceStream(resourceName);
        if (stream == null) return null;
        try
        {
            return new Bitmap(stream);
        }
        catch (ArgumentException)
        {
            Console.WriteLine("Resource is not an image.");
        }

        return null;
    }
}