﻿//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Text;

namespace BlackFireServer.Server
{
    public static class EncodingExtension
    {
        public static byte[] ToUTF8Bytes(this string src)
        {
            return Encoding.UTF8.GetBytes(src);
        }
    }
}
