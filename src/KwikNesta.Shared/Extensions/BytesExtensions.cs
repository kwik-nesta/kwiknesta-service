namespace KwikNesta.Shared.Extensions
{
    public static class BytesExtensions
    {
        public static string DetectImageContentType(this byte[] bytes)
        {
            if (bytes.Length < 4)
                return "application/octet-stream";

            if (bytes[0] == 0xFF && bytes[1] == 0xD8)
                return "image/jpeg";

            if (bytes[0] == 0x89 && bytes[1] == 0x50)
                return "image/png";

            if (bytes[0] == 0x47 && bytes[1] == 0x49)
                return "image/gif";

            return "application/octet-stream";
        }

        public static string DetectContentType(this byte[] bytes)
        {
            if (bytes.Length < 4)
                return "application/octet-stream";

            if (bytes[0] == 0x25 && bytes[1] == 0x50)
                return "application/pdf";

            if (bytes[0] == 0xFF && bytes[1] == 0xD8)
                return "image/jpeg";

            if (bytes[0] == 0x89 && bytes[1] == 0x50)
                return "image/png";

            if (bytes[0] == 0x49 && bytes[1] == 0x44 && bytes[2] == 0x33)
                return "audio/mpeg";

            if (bytes.Length > 12 &&
                bytes[4] == 0x66 && bytes[5] == 0x74 &&
                bytes[6] == 0x79 && bytes[7] == 0x70)
                return "video/mp4";

            return "application/octet-stream";
        }
    }
}