using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133
{
	[TLObject(1223809356)]
    public class TLEncryptedChatRequested : TLAbsEncryptedChat
    {
        public override int Constructor
        {
            get
            {
                return 1223809356;
            }
        }

             public int Flags {get;set;}
     public int? FolderId {get;set;}
     public int Id {get;set;}
     public long AccessHash {get;set;}
     public int Date {get;set;}
     public long AdminId {get;set;}
     public long ParticipantId {get;set;}
     public byte[] GA {get;set;}


		public void ComputeFlags()
		{
			Flags = 0;
Flags = FolderId != null ? (Flags | 1) : (Flags & ~1);

		}

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
if ((Flags & 1) != 0)
FolderId = br.ReadInt32();
else
FolderId = null;

Id = br.ReadInt32();
AccessHash = br.ReadInt64();
Date = br.ReadInt32();
AdminId = br.ReadInt64();
ParticipantId = br.ReadInt64();
GA = BytesUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ComputeFlags();
bw.Write(Flags);
if ((Flags & 1) != 0)
bw.Write(FolderId.Value);
bw.Write(Id);
bw.Write(AccessHash);
bw.Write(Date);
bw.Write(AdminId);
bw.Write(ParticipantId);
BytesUtil.Serialize(GA,bw);

        }
    }
}
