using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace  TeleNet.Models.TL99
{
	[TLObject(1363483106)]
    public class TLDialogPeerFolder : TLObject
    {
        public override int Constructor
        {
            get
            {
                return 1363483106;
            }
        }

             public int FolderId {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            FolderId = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(FolderId);

        }
    }
}
