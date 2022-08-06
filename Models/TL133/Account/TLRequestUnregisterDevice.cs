using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133.Account
{
	[TLObject(1779249670)]
    public class TLRequestUnregisterDevice : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 1779249670;
            }
        }

                public int TokenType {get;set;}
        public string Token {get;set;}
        public TLVector<long> OtherUids {get;set;}
public bool Response { get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            TokenType = br.ReadInt32();
Token = StringUtil.Deserialize(br);
OtherUids = (TLVector<long>)ObjectUtils.DeserializeVector<long>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(TokenType);
StringUtil.Serialize(Token,bw);
ObjectUtils.SerializeObject(OtherUids,bw);

        }

		public override void DeserializeResponse(BinaryReader br)
		{
			Response = BoolUtil.Deserialize(br);

		}
    }
}
