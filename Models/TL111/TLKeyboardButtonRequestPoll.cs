using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace  TeleNet.Models.TL111
{
	[TLObject(-1144565411)]
    public class TLKeyboardButtonRequestPoll : TLObject
    {
        public override int Constructor
        {
            get
            {
                return -1144565411;
            }
        }

             public int Flags {get;set;}
     public bool? Quiz {get;set;}
     public string Text {get;set;}


		public void ComputeFlags()
		{
			Flags = 0;
Flags = Quiz != null ? (Flags | 1) : (Flags & ~1);

		}

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
if ((Flags & 1) != 0)
Quiz = BoolUtil.Deserialize(br);
else
Quiz = null;

Text = StringUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ComputeFlags();
bw.Write(Flags);
if ((Flags & 1) != 0)
BoolUtil.Serialize(Quiz.Value,bw);
StringUtil.Serialize(Text,bw);

        }
    }
}
