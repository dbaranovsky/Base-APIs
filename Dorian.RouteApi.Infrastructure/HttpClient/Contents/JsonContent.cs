using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Dorian.RouteApi.Infrastructure.HttpClient.Contents
{
    public class JsonContent : ByteArrayContent
    {
        private const string DefaultMediaType = "application/json";
        private static readonly Encoding DefaultStringEncoding = Encoding.UTF8;

        public JsonContent(string content)
            : this(content, null, null)
        {
        }

        public JsonContent(string content, Encoding encoding)
            : this(content, encoding, null)
        {
        }

        public JsonContent(string content, Encoding encoding, string mediaType)
            : base(GetContentByteArray(content, encoding))
        {
            MediaTypeHeaderValue headerValue = new MediaTypeHeaderValue((mediaType == null) ? DefaultMediaType : mediaType);
            headerValue.CharSet = (encoding == null) ? DefaultStringEncoding.WebName : encoding.WebName;

            Headers.ContentType = headerValue;
        }

        private static byte[] GetContentByteArray(string content, Encoding encoding)
        {
            if (content == null)
            {
                throw new ArgumentNullException(nameof(content));
            }

            if (encoding == null)
            {
                encoding = DefaultStringEncoding;
            }

            return encoding.GetBytes(content);
        }
    }
}
