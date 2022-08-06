using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140
{
	[TLObject(361936797)]
    public class TLUpdateWebViewResultSent : TLAbsUpdate
    {
        public override int Constructor
        {
            get
            {
                return 361936797;
            }
        }

             public long QueryId {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            QueryId = br.ReadInt64();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(QueryId);

        }
    }
}
