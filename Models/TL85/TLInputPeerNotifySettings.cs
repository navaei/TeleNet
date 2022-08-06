using TeleNet.Models.TL;
using System.IO;


namespace  TeleNet.Models.TL85
{
    [TLObject(-1673717362)]
    public class TLInputPeerNotifySettings : TLAbsInputPeerNotifySettings
    {
        public override int Constructor
        {
            get
            {
                return -1673717362;
            }
        }

        public int Flags { get; set; }
        public bool? ShowPreviews { get; set; }
        public bool? Silent { get; set; }
        public int? MuteUntil { get; set; }
        public string Sound { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = ShowPreviews != null ? (Flags | 1) : (Flags & ~1);
            Flags = Silent != null ? (Flags | 2) : (Flags & ~2);
            Flags = MuteUntil != null ? (Flags | 4) : (Flags & ~4);
            Flags = Sound != null ? (Flags | 8) : (Flags & ~8);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            if ((Flags & 1) != 0)
                ShowPreviews = BoolUtil.Deserialize(br);
            else
                ShowPreviews = null;

            if ((Flags & 2) != 0)
                Silent = BoolUtil.Deserialize(br);
            else
                Silent = null;

            if ((Flags & 4) != 0)
                MuteUntil = br.ReadInt32();
            else
                MuteUntil = null;

            if ((Flags & 8) != 0)
                Sound = StringUtil.Deserialize(br);
            else
                Sound = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);
            if ((Flags & 1) != 0)
                BoolUtil.Serialize(ShowPreviews.Value, bw);
            if ((Flags & 2) != 0)
                BoolUtil.Serialize(Silent.Value, bw);
            if ((Flags & 4) != 0)
                bw.Write(MuteUntil.Value);
            if ((Flags & 8) != 0)
                StringUtil.Serialize(Sound, bw);

        }
    }
}
