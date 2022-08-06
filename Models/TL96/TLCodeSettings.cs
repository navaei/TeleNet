using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace  TeleNet.Models.TL96
{
	[TLObject(808409587)]
    public class TLCodeSettings : TLAbsCodeSettings
    {
        public override int Constructor
        {
            get
            {
                return 808409587;
            }
        }

             public int Flags {get;set;}
     public bool AllowFlashcall {get;set;}
     public bool CurrentNumber {get;set;}
     public bool AppHashPersistent {get;set;}
     public string AppHash {get;set;}


		public void ComputeFlags()
		{
			Flags = 0;
Flags = AllowFlashcall ? (Flags | 1) : (Flags & ~1);
Flags = CurrentNumber ? (Flags | 2) : (Flags & ~2);
Flags = AppHashPersistent ? (Flags | 4) : (Flags & ~4);
Flags = AppHash != null ? (Flags | 8) : (Flags & ~8);

		}

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
AllowFlashcall = (Flags & 1) != 0;
CurrentNumber = (Flags & 2) != 0;
AppHashPersistent = (Flags & 4) != 0;
if ((Flags & 8) != 0)
AppHash = StringUtil.Deserialize(br);
else
AppHash = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ComputeFlags();
bw.Write(Flags);



if ((Flags & 8) != 0)
StringUtil.Serialize(AppHash,bw);

        }
    }
}
