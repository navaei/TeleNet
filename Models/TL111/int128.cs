using TeleNet.Models;
using System.IO;

namespace TeleNet.Models.TL104
{
    public class int128 : TLObject
    {
        public override int Constructor => throw new System.NotImplementedException();

        public override void DeserializeBody(BinaryReader br)
        {
            throw new System.NotImplementedException();
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            throw new System.NotImplementedException();
        }
    }
}