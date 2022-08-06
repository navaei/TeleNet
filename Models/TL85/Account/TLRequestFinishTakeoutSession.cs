using System.IO;

namespace  TeleNet.Models.TL85.Account
{
	[TLObject(489050862)]
    public class TLRequestFinishTakeoutSession : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 489050862;
            }
        }

                public int Flags {get;set;}
        public bool Success {get;set;}
public bool Response { get; set;}


		public void ComputeFlags()
		{
			Flags = 0;
Flags = Success ? (Flags | 1) : (Flags & ~1);

		}

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
Success = (Flags & 1) != 0;

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ComputeFlags();
bw.Write(Flags);


        }

		public override void DeserializeResponse(BinaryReader br)
		{
			Response = BoolUtil.Deserialize(br);

		}
    }
}
