namespace MyHttpServer.UnitTests;
[TestClass]
public class StaticFileHandlerTests
{
    
    private string? HandleRequest(string url)
    {
        string path = new Uri(url).LocalPath;
        bool isFile = path.Contains('.');

        if (!isFile)
            return null;

        string staticDirectory = Path.Combine(
            Directory.GetCurrentDirectory(),
            "static");

        string relativePath = path.TrimStart('/');

        string filePath = Path.Combine(
            staticDirectory,
            relativePath);

        if (!File.Exists(filePath))
        {
            int separatorIndex = relativePath.IndexOf('/');

            if (separatorIndex >= 0)
            {
                string fallbackPath = Path.Combine(
                    staticDirectory,
                    relativePath.Substring(separatorIndex + 1));

                if (File.Exists(fallbackPath))
                    filePath = fallbackPath;
            }
        }

        return File.Exists(filePath) ? filePath : null;
    }
    [TestMethod]
    public void HandleRequest_HtmlFileExists_ReturnValid()
    {
        // Arrange
        string url = "http://localhost/test.html";

        string staticDirectory = Path.Combine(
            Directory.GetCurrentDirectory(),
            "static");

        Directory.CreateDirectory(staticDirectory);

        string expectedPath = Path.Combine(
            staticDirectory,
            "test.html");

        File.WriteAllText(expectedPath, "<h1>Hello</h1>");

        // Act
        string? actualPath = HandleRequest(url);

        // Assert
        Assert.AreEqual(expectedPath, actualPath);

        // Cleanup
        File.Delete(expectedPath);
    }
}