﻿using System;
using System.IO;
using GPK_RePack.Model.Interfaces;

namespace GPK_RePack.Model.Prop
{
    [Serializable]
    class GpkByteProperty : GpkBaseProperty, IProperty
    {
        public string enumType = null; //long index
        public string nameValue = null; //long index
        public byte byteValue;

        public GpkByteProperty()
        {
            RecalculateSize();
        }
        public GpkByteProperty(GpkBaseProperty bp)
        {
            name = bp.name;
            type = bp.type;
            size = bp.size;
            arrayIndex = bp.arrayIndex;
        }

        public override string ToString()
        {
            return string.Format("ObjectName: {0} Type: {1} NameValue: {2} NameValue: {3}", name, type, nameValue, byteValue);
        }

        public void WriteData(BinaryWriter writer, GpkPackage package)
        {
            if (size == 1)
            {
                writer.Write(byteValue);
            }
            else
            {
                if (package.x64) writer.Write(package.GetStringIndex(enumType));

                writer.Write(package.GetStringIndex(nameValue));
            }
        }

        public void ReadData(BinaryReader reader, GpkPackage package)
        {
            if (size == 1)
            {
                byteValue = reader.ReadByte();
            }
            else
            {
                if (package.x64)
                {
                    long structtype = reader.ReadInt64();
                    enumType = package.GetString(structtype);
                }
                long byteIndex = reader.ReadInt64();
                nameValue = package.GetString(byteIndex);
            }
        }

        public int RecalculateSize()
        {
            if (nameValue != null) 
            {
                size = enumType != null ? 16 : 8;
            }
            else
            {
                size = 1;
            }
            return size;
        }

        public bool ValidateValue(string input)
        {
            return false;
        }

        public bool SetValue(string input)
        {
            return false;
        }
    }

}
