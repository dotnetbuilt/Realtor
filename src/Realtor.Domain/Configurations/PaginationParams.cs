namespace Realtor.Domain.Configurations;

public class PaginationParams
{
    private int _pageSize;
    private const int MaxSize = 20;

    public int PageSize
    {
        get => _pageSize == 0 ? MaxSize : _pageSize;
        set { _pageSize = value > MaxSize ? MaxSize : value; }
    }

    public int PageIndex{get;set;} = 1;
}