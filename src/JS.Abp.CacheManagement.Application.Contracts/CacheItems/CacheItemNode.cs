namespace JS.Abp.CacheManagement.CacheItems;

public class CacheItemNode
{
    private int _NodeID = 0;

    public int NodeID
    {
        get { return _NodeID; }
        set { _NodeID = value; }
    }
    private string _CacheName = "";

    public string CacheName
    {
        get { return _CacheName; }
        set { _CacheName = value; }
    }
    private string _CacheKey = "";

    public string CacheKey
    {
        get { return _CacheKey; }
        set { _CacheKey = value; }
    }
    private int _parentid = 0;

    public int Parentid
    {
        get { return _parentid; }
        set { _parentid = value; }
    }

    public override string ToString()
    {
        return CacheName;
    }

}