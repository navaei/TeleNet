using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL123.Phone
{
    [TLObject(-906898811)]
    public class TLRequestGetGroupParticipants : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -906898811;
            }
        }

        public TLInputGroupCall Call { get; set; }
        public TLVector<int> Ids { get; set; }
        public TLVector<int> Sources { get; set; }
        public string Offset { get; set; }
        public int Limit { get; set; }
        public Phone.TLGroupParticipants Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Call = (TLInputGroupCall)ObjectUtils.DeserializeObject(br);
            Ids = (TLVector<int>)ObjectUtils.DeserializeVector<int>(br);
            Sources = (TLVector<int>)ObjectUtils.DeserializeVector<int>(br);
            Offset = StringUtil.Deserialize(br);
            Limit = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Call, bw);
            ObjectUtils.SerializeObject(Ids, bw);
            ObjectUtils.SerializeObject(Sources, bw);
            StringUtil.Serialize(Offset, bw);
            bw.Write(Limit);

        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (Phone.TLGroupParticipants)ObjectUtils.DeserializeObject(br);

        }
    }
}
