﻿// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.IO;
using System.Reflection;

namespace osu.Framework.IO.Stores
{
    public class DllResourceStore : IResourceStore<byte[]>
    {
        private readonly Assembly assembly;
        private readonly string space;

        public DllResourceStore(string dllName)
        {
            assembly = Assembly.LoadFrom(dllName);
            space = Path.GetFileNameWithoutExtension(dllName);
        }

        public byte[] Get(string name)
        {
            using (Stream input = GetStream(name))
            {
                if (input == null)
                    return null;

                byte[] buffer = new byte[input.Length];
                input.Read(buffer, 0, buffer.Length);
                return buffer;
            }
        }

        public Stream GetStream(string name)
        {
            return assembly?.GetManifestResourceStream($@"{space}.{name.Replace('/', '.')}");
        }
    }
}
