using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133
{
	[TLObject(-2049074735)]
    public class TLReplyKeyboardMarkup : TLAbsReplyMarkup
    {
        public override int Constructor
        {
            get
            {
                return -2049074735;
            }
        }

             public int Flags {get;set;}
     public bool Resize {get;set;}
     public bool SingleUse {get;set;}
     public bool Selective {get;set;}
     public TLVector<TLKeyboardButtonRow> Rows {get;set;}
     public string Placeholder {get;set;}


		public void ComputeFlags()
		{
			Flags = 0;
Flags = Resize ? (Flags | 1) : (Flags & ~1);
Flags = SingleUse ? (Flags | 2) : (Flags & ~2);
Flags = Selective ? (Flags | 4) : (Flags & ~4);
Flags = Placeholder != null ? (Flags | 8) : (Flags & ~8);

		}

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
Resize = (Flags & 1) != 0;
SingleUse = (Flags & 2) != 0;
Selective = (Flags & 4) != 0;
Rows = (TLVector<TLKeyboardButtonRow>)ObjectUtils.DeserializeVector<TLKeyboardButtonRow>(br);
if ((Flags & 8) != 0)
Placeholder = StringUtil.Deserialize(br);
else
Placeholder = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ComputeFlags();
bw.Write(Flags);



ObjectUtils.SerializeObject(Rows,bw);
if ((Flags & 8) != 0)
StringUtil.Serialize(Placeholder,bw);

        }
    }
}
