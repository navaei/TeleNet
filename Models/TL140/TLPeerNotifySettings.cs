using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140
{
    [TLObject(-1472527322)]
    public class TLPeerNotifySettings : TLAbsPeerNotifySettings
    {
        public override int Constructor
        {
            get
            {
                return -1472527322;
            }
        }

        public TLAbsNotificationSound IosSound { get; set; }
        public TLAbsNotificationSound AndroidSound { get; set; }
        public TLAbsNotificationSound OtherSound { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = ShowPreviews != null ? (Flags | 1) : (Flags & ~1);
            Flags = Silent != null ? (Flags | 2) : (Flags & ~2);
            Flags = MuteUntil != null ? (Flags | 4) : (Flags & ~4);
            Flags = IosSound != null ? (Flags | 8) : (Flags & ~8);
            Flags = AndroidSound != null ? (Flags | 16) : (Flags & ~16);
            Flags = OtherSound != null ? (Flags | 32) : (Flags & ~32);

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
                IosSound = (TLAbsNotificationSound)ObjectUtils.DeserializeObject(br);
            else
                IosSound = null;

            if ((Flags & 16) != 0)
                AndroidSound = (TLAbsNotificationSound)ObjectUtils.DeserializeObject(br);
            else
                AndroidSound = null;

            if ((Flags & 32) != 0)
                OtherSound = (TLAbsNotificationSound)ObjectUtils.DeserializeObject(br);
            else
                OtherSound = null;


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
                ObjectUtils.SerializeObject(IosSound, bw);
            if ((Flags & 16) != 0)
                ObjectUtils.SerializeObject(AndroidSound, bw);
            if ((Flags & 32) != 0)
                ObjectUtils.SerializeObject(OtherSound, bw);

        }
    }
}
