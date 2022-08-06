using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140.Account
{
	[TLObject(1038768899)]
    public class TLRequestSaveRingtone : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 1038768899;
            }
        }

                public TLAbsInputDocument Id {get;set;}
        public bool Unsave {get;set;}
public Account.TLAbsSavedRingtone Response { get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Id = (TLAbsInputDocument)ObjectUtils.DeserializeObject(br);
Unsave = BoolUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(Id,bw);
BoolUtil.Serialize(Unsave,bw);

        }

		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (Account.TLAbsSavedRingtone)ObjectUtils.DeserializeObject(br);

		}
    }
}
