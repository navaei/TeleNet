using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133.Account
{
	[TLObject(-842824308)]
    public class TLWallPapers : TLObject
    {
        public override int Constructor
        {
            get
            {
                return -842824308;
            }
        }

             public long Hash {get;set;}
     public TLVector<TLWallPaper> Wallpapers {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Hash = br.ReadInt64();
Wallpapers = (TLVector<TLWallPaper>)ObjectUtils.DeserializeVector<TLWallPaper>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(Hash);
ObjectUtils.SerializeObject(Wallpapers,bw);

        }
    }
}
