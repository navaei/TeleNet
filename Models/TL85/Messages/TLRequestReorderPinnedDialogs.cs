using System.IO;

namespace  TeleNet.Models.TL85.Messages
{
	[TLObject(1532089919)]
    public class TLRequestReorderPinnedDialogs : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 1532089919;
            }
        }

                public int Flags {get;set;}
        public bool Force {get;set;}
        public TLVector<TLInputDialogPeer> Order {get;set;}
public bool Response { get; set;}


		public void ComputeFlags()
		{
			Flags = 0;
Flags = Force ? (Flags | 1) : (Flags & ~1);

		}

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
Force = (Flags & 1) != 0;
Order = (TLVector<TLInputDialogPeer>)ObjectUtils.DeserializeVector<TLInputDialogPeer>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ComputeFlags();
bw.Write(Flags);

ObjectUtils.SerializeObject(Order,bw);

        }

		public override void DeserializeResponse(BinaryReader br)
		{
			Response = BoolUtil.Deserialize(br);

		}
    }
}
