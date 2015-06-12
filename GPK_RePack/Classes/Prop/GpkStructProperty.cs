﻿using System;

namespace GPK_RePack.Classes.Prop
{
    [Serializable]
    class GpkStructProperty : GpkBaseProperty
    {
        public string innerType;
        public long length;
        public byte[] value;

        public GpkStructProperty()
        {

        }
        public GpkStructProperty(GpkBaseProperty bp)
        {
            Name = bp.Name;
            type = bp.type;
        }

        public override string ToString()
        {
            return string.Format("ObjectName: {0} Type: {1} Length: {2} Value: {3}", Name, type, length, value);
        }
    }

}