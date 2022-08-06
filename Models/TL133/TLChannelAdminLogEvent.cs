using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133
{
	[TLObject(531458253)]
    public class TLChannelAdminLogEvent : TLObject
    {
        public override int Constructor
        {
            get
            {
                return 531458253;
            }
        }

             public long Id {get;set;}
     public int Date {get;set;}
     public long UserId {get;set;}
     public TLAbsChannelAdminLogEventAction Action {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Id = br.ReadInt64();
Date = br.ReadInt32();
UserId = br.ReadInt64();
Action = (TLAbsChannelAdminLogEventAction)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(Id);
bw.Write(Date);
bw.Write(UserId);
ObjectUtils.SerializeObject(Action,bw);

        }
    }
}
