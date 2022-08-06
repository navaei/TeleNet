using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL123
{
	[TLObject(505183301)]
    public class TLEncryptedChatDiscarded : TLAbsEncryptedChat
    {
        public override int Constructor
        {
            get
            {
                return 505183301;
            }
        }

             public int Flags {get;set;}
     public bool HistoryDeleted {get;set;}
     public int Id {get;set;}


		public void ComputeFlags()
		{
			Flags = 0;
Flags = HistoryDeleted ? (Flags | 1) : (Flags & ~1);

		}

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
HistoryDeleted = (Flags & 1) != 0;
Id = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ComputeFlags();
bw.Write(Flags);

bw.Write(Id);

        }
    }
}
