using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140
{
	[TLObject(-1297663893)]
    public class TLAttachMenuBotIcon : TLObject
    {
        public override int Constructor
        {
            get
            {
                return -1297663893;
            }
        }

             public int Flags {get;set;}
     public string Name {get;set;}
     public TLAbsDocument Icon {get;set;}
     public TLVector<TLAttachMenuBotIconColor> Colors {get;set;}


		public void ComputeFlags()
		{
			Flags = 0;
Flags = Colors != null ? (Flags | 1) : (Flags & ~1);

		}

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
Name = StringUtil.Deserialize(br);
Icon = (TLAbsDocument)ObjectUtils.DeserializeObject(br);
if ((Flags & 1) != 0)
Colors = (TLVector<TLAttachMenuBotIconColor>)ObjectUtils.DeserializeVector<TLAttachMenuBotIconColor>(br);
else
Colors = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ComputeFlags();
bw.Write(Flags);
StringUtil.Serialize(Name,bw);
ObjectUtils.SerializeObject(Icon,bw);
if ((Flags & 1) != 0)
ObjectUtils.SerializeObject(Colors,bw);

        }
    }
}
