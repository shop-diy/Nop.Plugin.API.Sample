using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Dynamic;
using System.Linq;

namespace Fsl.NopCommerce.Api.Connector.Services.HubSpot
{
    public sealed partial class HubSpotProperties : DynamicObject, IDictionary<string, string>, IList<string>
    {
        private readonly IDictionary<string, string> _dynamicProperties;

        public HubSpotProperties(IDictionary<string, string> dynamicProperties)
            : this(dynamicProperties.ToArray()) { }

        public HubSpotProperties(IEnumerable<KeyValuePair<string, string>> properties)
        {
            _dynamicProperties = new Dictionary<string, string>(properties, StringComparer.OrdinalIgnoreCase);
        }

        public HubSpotProperties(IEnumerable<string> propertyNames)
        {
            // Using this constructor means the caller is only interested in the
            // property names, so treat it like a list of strings.
            _dynamicProperties = new Dictionary<string, string>(propertyNames
                .Select(p => new KeyValuePair<string, string>(p, default)),
                StringComparer.OrdinalIgnoreCase);
        }

        public ICollection<string> Keys => _dynamicProperties.Keys;

        public ICollection<string> Values => _dynamicProperties.Values;

        public int Count => _dynamicProperties.Count;

        public bool IsReadOnly => _dynamicProperties.IsReadOnly;

        public string this[int index]
        {
            get => _dynamicProperties.Keys.ToArray()[index];
            set
            {
                var key = this[index];
                var item = _dynamicProperties[key];

                _dynamicProperties.Remove(key);

                Insert(index, value);

                _dynamicProperties[value] = item;
            }
        }

        public string this[string key]
        {
            get => _dynamicProperties[key];
            set => _dynamicProperties[key] = value;
        }

        public override IEnumerable<string> GetDynamicMemberNames()
        {
            return _dynamicProperties.Keys;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (_dynamicProperties.TryGetValue(binder.Name, out string s))
            {
                result = s;

                return true;
            }
            else
            {
                result = default;

                return false;
            }
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            return _dynamicProperties.TryAdd(binder.Name, Convert.ToString(value));
        }

        public string ToParameterString(params string[] properties)
        {
            return string.Join(',', _dynamicProperties.Keys);
        }

        public void Add(string key, string value) =>
            _dynamicProperties.Add(key, value);

        public bool ContainsKey(string key) =>
            _dynamicProperties.ContainsKey(key);

        public bool Remove(string key) =>
            _dynamicProperties.Remove(key);

        public bool TryGetValue(string key, [MaybeNullWhen(false)] out string value) =>
            _dynamicProperties.TryGetValue(key, out value);

        public void Add(KeyValuePair<string, string> item) =>
            _dynamicProperties.Add(item);

        public void Clear() => _dynamicProperties.Clear();

        public bool Contains(KeyValuePair<string, string> item) =>
            _dynamicProperties.Contains(item);

        public void CopyTo(KeyValuePair<string, string>[] array, int arrayIndex) =>
            _dynamicProperties.CopyTo(array, arrayIndex);

        public bool Remove(KeyValuePair<string, string> item) =>
            _dynamicProperties.Remove(item);

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator() =>
            _dynamicProperties.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() =>
            _dynamicProperties.GetEnumerator();

        public int IndexOf(string item) => _dynamicProperties.Keys.ToList().IndexOf(item);

        public void Insert(int index, string item)
        {
            var kvp = new KeyValuePair<string, string>(item, default);
            var kvps = new KeyValuePair<string, string>[_dynamicProperties.Count + 1];

            _dynamicProperties.CopyTo(kvps, 0);
            _dynamicProperties.Clear();
            _dynamicProperties.Concat(kvps.Take(index));
            _dynamicProperties.Append(kvp);
            _dynamicProperties.Concat(kvps.Skip(index + 1));
        }

        public void RemoveAt(int index)
        {
            var key = _dynamicProperties.Keys.ElementAt(index);

            _dynamicProperties.Remove(key);
        }

        public void Add(string item) =>
            _dynamicProperties.Add(new KeyValuePair<string, string>(item, default));

        public bool Contains(string item) =>
            _dynamicProperties.Keys.Contains(item);

        public void CopyTo(string[] array, int arrayIndex) =>
            _dynamicProperties.Keys.CopyTo(array, arrayIndex);

        IEnumerator<string> IEnumerable<string>.GetEnumerator() =>
            _dynamicProperties.Keys.GetEnumerator();
    }
}
