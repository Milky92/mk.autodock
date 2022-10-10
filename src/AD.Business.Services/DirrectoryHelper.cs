namespace AD.Business.Services;

public static class DirectoryHelper
{
    public static bool CreateIfNotExists(string path)
    {
        if (string.IsNullOrEmpty(path)) throw new ArgumentNullException(nameof(path));

        if (Directory.Exists(path))
        {
            return false;
        }

        var r = Directory.CreateDirectory(path);
        return r.Exists;
    }
}