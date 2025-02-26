public class TimeMap
{

    public Dictionary<string, List<KVMap>> _items = new Dictionary<string, List<KVMap>>();

    public TimeMap()
    {

    }

    public void Set(string key, string value, int timestamp)
    {
        var map = new KVMap(key, value, timestamp);
        if (!_items.ContainsKey(key))
            _items.Add(key, new List<KVMap>());

        _items[key].Add(map);

    }

    public string Get(string key, int timestamp)
    {
        if (!_items.ContainsKey(key))
            return string.Empty;

        int seen = -1;

        for (int i = 0; i < _items[key].Count; i++) {
            if (_items[key][i].Timestamp <= timestamp)
                seen = i;
        }

        return seen == -1 ? string.Empty : _items[key][seen].Value;
    }

}

public class KVMap
{
    public string Key { get; set; }
    public string Value { get; set; }
    public int Timestamp { get; set; }

    public KVMap(string key, string value, int timestamp)
    {
        Key = key;
        Value = value;
        Timestamp = timestamp;
    }
}
