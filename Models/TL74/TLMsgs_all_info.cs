using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(-1933520591)]
    public class TLMsgs_all_info : TLObject
    {
        public override int Constructor
        {
            get
            {
                return -1933520591;
            }
        }

             public TLVector<long> MsgIds {get;set;}
     public string Info {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            MsgIds = (TLVector<long>)ObjectUtils.DeserializeVector<long>(br);
Info = StringUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(MsgIds,bw);
StringUtil.Serialize(Info,bw);

        }
    }
}
