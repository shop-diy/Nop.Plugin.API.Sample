using System;

namespace Fsl.NopCommerce.Api.Connector.Mapping
{
    public interface IObjectMapper
    {
        Type SourceType { get; }
        Type DestinationType { get; }
    }

    public interface IObjectMapper<TSource, TDest> : IObjectMapper
    {
        bool ToObject(TSource source, out TDest result);

        void UpdateObject(TSource source, TDest dest);
    }
}
