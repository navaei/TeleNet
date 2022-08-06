using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140.Account
{
	[TLObject(-1041683259)]
    public class TLSavedRingtones : TLAbsSavedRingtones
    {
        public override int Constructor
        {
            get
            {
                return -1041683259;
            }
        }

             public long Hash {get;set;}
     public TLVector<TLAbsDocument> Ringtones {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Hash = br.ReadInt64();
Ringtones = (TLVector<TLAbsDocument>)ObjectUtils.DeserializeVector<TLAbsDocument>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(Hash);
ObjectUtils.SerializeObject(Ringtones,bw);

        }
    }
}
