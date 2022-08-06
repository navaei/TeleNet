using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace  TeleNet.Models.TL111.Channels
{
    [TLObject(-122669393)]
    public class TLRequestGetAdminedPublicChannels : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -122669393;
            }
        }

        public int Flags { get; set; }
        public bool ByLocation { get; set; }
        public bool CheckLimit { get; set; }
        public TeleNet.Models.TL.Messages.TLAbsChats Response { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = ByLocation ? (Flags | 1) : (Flags & ~1);
            Flags = CheckLimit ? (Flags | 2) : (Flags & ~2);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            ByLocation = (Flags & 1) != 0;
            CheckLimit = (Flags & 2) != 0;
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TeleNet.Models.TL.Messages.TLAbsChats)ObjectUtils.DeserializeObject(br);

        }
    }
}
