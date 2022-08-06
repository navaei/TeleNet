using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140.Account
{
    [TLObject(-953697477)]
    public class TLRequestInstallTheme : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -953697477;
            }
        }

        public int Flags { get; set; }
        public bool Dark { get; set; }
        public TL111.TLAbsInputTheme Theme { get; set; }
        public string Format { get; set; }
        public TLAbsBaseTheme BaseTheme { get; set; }
        public bool Response { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = Dark ? (Flags | 1) : (Flags & ~1);
            Flags = Theme != null ? (Flags | 2) : (Flags & ~2);
            Flags = Format != null ? (Flags | 4) : (Flags & ~4);
            Flags = BaseTheme != null ? (Flags | 8) : (Flags & ~8);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            Dark = (Flags & 1) != 0;
            if ((Flags & 2) != 0)
                Theme = (TL111.TLAbsInputTheme)ObjectUtils.DeserializeObject(br);
            else
                Theme = null;

            if ((Flags & 4) != 0)
                Format = StringUtil.Deserialize(br);
            else
                Format = null;

            if ((Flags & 8) != 0)
                BaseTheme = (TLAbsBaseTheme)ObjectUtils.DeserializeObject(br);
            else
                BaseTheme = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);

            if ((Flags & 2) != 0)
                ObjectUtils.SerializeObject(Theme, bw);
            if ((Flags & 4) != 0)
                StringUtil.Serialize(Format, bw);
            if ((Flags & 8) != 0)
                ObjectUtils.SerializeObject(BaseTheme, bw);

        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = BoolUtil.Deserialize(br);

        }
    }
}
