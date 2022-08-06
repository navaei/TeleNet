using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace  TeleNet.Models.TL111.Stats
{
    [TLObject(1646092192)]
    public class TLRequestLoadAsyncGraph : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 1646092192;
            }
        }

        public int Flags { get; set; }
        public string Token { get; set; }
        public long? X { get; set; }
        public TLAbsStatsGraph Response { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = X != null ? (Flags | 1) : (Flags & ~1);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            Token = StringUtil.Deserialize(br);
            if ((Flags & 1) != 0)
                X = br.ReadInt64();
            else
                X = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);
            StringUtil.Serialize(Token, bw);
            if ((Flags & 1) != 0)
                bw.Write(X.Value);

        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsStatsGraph)ObjectUtils.DeserializeObject(br);

        }
    }
}
