namespace AD.Commons;

public class PageContext<TFilter>
where TFilter:class,new()
{
    public PageContext()
    {
        Filter = new TFilter();
    }

    public PageContext(int pageIndex, int countOnPage)
    {
        PageIndex = pageIndex;
        CountOnPage = countOnPage;
    }

    public int PageIndex { get; set; } = 1;
    public int CountOnPage { get; set; } = 50;
    public TFilter Filter { get; set; }
}