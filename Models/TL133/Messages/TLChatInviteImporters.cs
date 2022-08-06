using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133.Messages
{
	[TLObject(-2118733814)]
    public class TLChatInviteImporters : TLObject
    {
        public override int Constructor
        {
            get
            {
                return -2118733814;
            }
        }

             public int Count {get;set;}
     public TLVector<TLChatInviteImporter> Importers {get;set;}
     public TLVector<TLAbsUser> Users {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Count = br.ReadInt32();
Importers = (TLVector<TLChatInviteImporter>)ObjectUtils.DeserializeVector<TLChatInviteImporter>(br);
Users = (TLVector<TLAbsUser>)ObjectUtils.DeserializeVector<TLAbsUser>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(Count);
ObjectUtils.SerializeObject(Importers,bw);
ObjectUtils.SerializeObject(Users,bw);

        }
    }
}
