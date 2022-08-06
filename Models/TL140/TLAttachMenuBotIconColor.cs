using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140
{
	[TLObject(1165423600)]
    public class TLAttachMenuBotIconColor : TLObject
    {
        public override int Constructor
        {
            get
            {
                return 1165423600;
            }
        }

             public string Name {get;set;}
     public int Color {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Name = StringUtil.Deserialize(br);
Color = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            StringUtil.Serialize(Name,bw);
bw.Write(Color);

        }
    }
}
