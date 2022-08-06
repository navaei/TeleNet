using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140
{
	[TLObject(-911191137)]
    public class TLSearchResultsCalendarPeriod : TLObject
    {
        public override int Constructor
        {
            get
            {
                return -911191137;
            }
        }

             public int Date {get;set;}
     public int MinMsgId {get;set;}
     public int MaxMsgId {get;set;}
     public int Count {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Date = br.ReadInt32();
MinMsgId = br.ReadInt32();
MaxMsgId = br.ReadInt32();
Count = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(Date);
bw.Write(MinMsgId);
bw.Write(MaxMsgId);
bw.Write(Count);

        }
    }
}
