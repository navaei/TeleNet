using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace  TeleNet.Models.TL111.Auth
{
    [TLObject(1148485274)]
    public class TLAuthorizationSignUpRequired : TLAbsAuthorization
    {
        public override int Constructor
        {
            get
            {
                return 1148485274;
            }
        }

        public int Flags { get; set; }
        public TL.Help.TLTermsOfService TermsOfService { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = TermsOfService != null ? (Flags | 1) : (Flags & ~1);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            if ((Flags & 1) != 0)
                TermsOfService = (TL.Help.TLTermsOfService)ObjectUtils.DeserializeObject(br);
            else
                TermsOfService = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);
            if ((Flags & 1) != 0)
                ObjectUtils.SerializeObject(TermsOfService, bw);

        }
    }
}
