using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140.Account
{
	[TLObject(1089766498)]
    public class TLRequestChangeAuthorizationSettings : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 1089766498;
            }
        }

                public int Flags {get;set;}
        public long Hash {get;set;}
        public bool? EncryptedRequestsDisabled {get;set;}
        public bool? CallRequestsDisabled {get;set;}
public bool Response { get; set;}


		public void ComputeFlags()
		{
			Flags = 0;
Flags = EncryptedRequestsDisabled != null ? (Flags | 1) : (Flags & ~1);
Flags = CallRequestsDisabled != null ? (Flags | 2) : (Flags & ~2);

		}

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
Hash = br.ReadInt64();
if ((Flags & 1) != 0)
EncryptedRequestsDisabled = BoolUtil.Deserialize(br);
else
EncryptedRequestsDisabled = null;

if ((Flags & 2) != 0)
CallRequestsDisabled = BoolUtil.Deserialize(br);
else
CallRequestsDisabled = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ComputeFlags();
bw.Write(Flags);
bw.Write(Hash);
if ((Flags & 1) != 0)
BoolUtil.Serialize(EncryptedRequestsDisabled.Value,bw);
if ((Flags & 2) != 0)
BoolUtil.Serialize(CallRequestsDisabled.Value,bw);

        }

		public override void DeserializeResponse(BinaryReader br)
		{
			Response = BoolUtil.Deserialize(br);

		}
    }
}
