using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140
{
	[TLObject(-381896846)]
    public class TLAttachMenuBot : TLObject
    {
        public override int Constructor
        {
            get
            {
                return -381896846;
            }
        }

             public int Flags {get;set;}
     public bool Inactive {get;set;}
     public long BotId {get;set;}
     public string ShortName {get;set;}
     public TLVector<TLAttachMenuBotIcon> Icons {get;set;}


		public void ComputeFlags()
		{
			Flags = 0;
Flags = Inactive ? (Flags | 1) : (Flags & ~1);

		}

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
Inactive = (Flags & 1) != 0;
BotId = br.ReadInt64();
ShortName = StringUtil.Deserialize(br);
Icons = (TLVector<TLAttachMenuBotIcon>)ObjectUtils.DeserializeVector<TLAttachMenuBotIcon>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ComputeFlags();
bw.Write(Flags);

bw.Write(BotId);
StringUtil.Serialize(ShortName,bw);
ObjectUtils.SerializeObject(Icons,bw);

        }
    }
}
