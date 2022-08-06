using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140
{
    [TLObject(-1065882623)]
    public class TLAvailableReaction : TLObject
    {
        public override int Constructor
        {
            get
            {
                return -1065882623;
            }
        }

        public int Flags { get; set; }
        public bool Inactive { get; set; }
        public string Reaction { get; set; }
        public string Title { get; set; }
        public TLAbsDocument StaticIcon { get; set; }
        public TLAbsDocument AppearAnimation { get; set; }
        public TLAbsDocument SelectAnimation { get; set; }
        public TLAbsDocument ActivateAnimation { get; set; }
        public TLAbsDocument EffectAnimation { get; set; }
        public TLAbsDocument AroundAnimation { get; set; }
        public TLAbsDocument CenterIcon { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = Inactive ? (Flags | 1) : (Flags & ~1);
            Flags = AroundAnimation != null ? (Flags | 2) : (Flags & ~2);
            Flags = CenterIcon != null ? (Flags | 2) : (Flags & ~2);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            Inactive = (Flags & 1) != 0;
            Reaction = StringUtil.Deserialize(br);
            Title = StringUtil.Deserialize(br);
            StaticIcon = (TLAbsDocument)ObjectUtils.DeserializeObject(br);
            AppearAnimation = (TLAbsDocument)ObjectUtils.DeserializeObject(br);
            SelectAnimation = (TLAbsDocument)ObjectUtils.DeserializeObject(br);
            ActivateAnimation = (TLAbsDocument)ObjectUtils.DeserializeObject(br);
            EffectAnimation = (TLAbsDocument)ObjectUtils.DeserializeObject(br);
            if ((Flags & 2) != 0)
                AroundAnimation = (TLAbsDocument)ObjectUtils.DeserializeObject(br);
            else
                AroundAnimation = null;

            if ((Flags & 2) != 0)
                CenterIcon = (TLAbsDocument)ObjectUtils.DeserializeObject(br);
            else
                CenterIcon = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);

            StringUtil.Serialize(Reaction, bw);
            StringUtil.Serialize(Title, bw);
            ObjectUtils.SerializeObject(StaticIcon, bw);
            ObjectUtils.SerializeObject(AppearAnimation, bw);
            ObjectUtils.SerializeObject(SelectAnimation, bw);
            ObjectUtils.SerializeObject(ActivateAnimation, bw);
            ObjectUtils.SerializeObject(EffectAnimation, bw);
            if ((Flags & 2) != 0)
                ObjectUtils.SerializeObject(AroundAnimation, bw);
            if ((Flags & 2) != 0)
                ObjectUtils.SerializeObject(CenterIcon, bw);

        }
    }
}
