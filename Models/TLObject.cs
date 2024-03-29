﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TeleNet.Models.TL;

namespace TeleNet.Models
{

    public abstract class TLObject
    {
        public abstract int Constructor { get; }
        public abstract void SerializeBody(BinaryWriter bw);
        public abstract void DeserializeBody(BinaryReader br);
        public byte[] Serialize()
        {
            using (MemoryStream m = new MemoryStream())
            using (BinaryWriter bw = new BinaryWriter(m))
            {
                Serialize(bw);
                bw.Close();
                m.Close();
                return m.ToArray();
            }
        }
        public void Serialize(BinaryWriter writer)
        {
            writer.Write(Constructor);
            SerializeBody(writer);
        }
        public void Deserialize(BinaryReader reader)
        {
            int constructorId = reader.ReadInt32();
            if (constructorId != Constructor)
                throw new InvalidDataException("Constructor Invalid");
            DeserializeBody(reader);
        }
    }
}
