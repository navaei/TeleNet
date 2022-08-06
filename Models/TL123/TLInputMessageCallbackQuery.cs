using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL123
{
	[TLObject(-1392895362)]
    public class TLInputMessageCallbackQuery : TLObject
    {
        public override int Constructor
        {
            get
            {
                return -1392895362;
            }
        }

             public int Id {get;set;}
     public long QueryId {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Id = br.ReadInt32();
QueryId = br.ReadInt64();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(Id);
bw.Write(QueryId);

        }
    }
}
