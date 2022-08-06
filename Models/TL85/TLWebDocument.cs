using System.IO;
using TeleNet.Models.TL;

namespace  TeleNet.Models.TL85
{
	[TLObject(475467473)]
    public class TLWebDocument : TLAbsWebDocument
    {
        public override int Constructor
        {
            get
            {
                return 475467473;
            }
        }

             public string Url {get;set;}
     public long AccessHash {get;set;}
     public int Size {get;set;}
     public string MimeType {get;set;}
     public TLVector<TLAbsDocumentAttribute> Attributes {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Url = StringUtil.Deserialize(br);
AccessHash = br.ReadInt64();
Size = br.ReadInt32();
MimeType = StringUtil.Deserialize(br);
Attributes = (TLVector<TLAbsDocumentAttribute>)ObjectUtils.DeserializeVector<TLAbsDocumentAttribute>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            StringUtil.Serialize(Url,bw);
bw.Write(AccessHash);
bw.Write(Size);
StringUtil.Serialize(MimeType,bw);
ObjectUtils.SerializeObject(Attributes,bw);

        }
    }
}
