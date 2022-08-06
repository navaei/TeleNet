using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133.Account
{
    [TLObject(408623183)]
    public class TLPassword : TL.Account.TLAbsPassword
    {
        public override int Constructor
        {
            get
            {
                return 408623183;
            }
        }

        public int Flags { get; set; }
        public bool HasRecovery { get; set; }
        public bool HasSecureValues { get; set; }
        public bool HasPassword { get; set; }
        public TeleNet.Models.TL.TLAbsPasswordKdfAlgo CurrentAlgo { get; set; }
        public byte[] SrpB { get; set; }
        public long? SrpId { get; set; }
        public string Hint { get; set; }
        public string EmailUnconfirmedPattern { get; set; }
        public TeleNet.Models.TL.TLAbsPasswordKdfAlgo NewAlgo { get; set; }
        public TeleNet.Models.TL.TLAbsSecurePasswordKdfAlgo NewSecureAlgo { get; set; }
        public byte[] SecureRandom { get; set; }
        public int? PendingResetDate { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = HasRecovery ? (Flags | 1) : (Flags & ~1);
            Flags = HasSecureValues ? (Flags | 2) : (Flags & ~2);
            Flags = HasPassword ? (Flags | 4) : (Flags & ~4);
            Flags = CurrentAlgo != null ? (Flags | 4) : (Flags & ~4);
            Flags = SrpB != null ? (Flags | 4) : (Flags & ~4);
            Flags = SrpId != null ? (Flags | 4) : (Flags & ~4);
            Flags = Hint != null ? (Flags | 8) : (Flags & ~8);
            Flags = EmailUnconfirmedPattern != null ? (Flags | 16) : (Flags & ~16);
            Flags = PendingResetDate != null ? (Flags | 32) : (Flags & ~32);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            HasRecovery = (Flags & 1) != 0;
            HasSecureValues = (Flags & 2) != 0;
            HasPassword = (Flags & 4) != 0;
            if ((Flags & 4) != 0)
                CurrentAlgo = (TeleNet.Models.TL.TLAbsPasswordKdfAlgo)ObjectUtils.DeserializeObject(br);
            else
                CurrentAlgo = null;

            if ((Flags & 4) != 0)
                SrpB = BytesUtil.Deserialize(br);
            else
                SrpB = null;

            if ((Flags & 4) != 0)
                SrpId = br.ReadInt64();
            else
                SrpId = null;

            if ((Flags & 8) != 0)
                Hint = StringUtil.Deserialize(br);
            else
                Hint = null;

            if ((Flags & 16) != 0)
                EmailUnconfirmedPattern = StringUtil.Deserialize(br);
            else
                EmailUnconfirmedPattern = null;

            NewAlgo = (TeleNet.Models.TL.TLAbsPasswordKdfAlgo)ObjectUtils.DeserializeObject(br);
            NewSecureAlgo = (TeleNet.Models.TL.TLAbsSecurePasswordKdfAlgo)ObjectUtils.DeserializeObject(br);
            SecureRandom = BytesUtil.Deserialize(br);
            if ((Flags & 32) != 0)
                PendingResetDate = br.ReadInt32();
            else
                PendingResetDate = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);



            if ((Flags & 4) != 0)
                ObjectUtils.SerializeObject(CurrentAlgo, bw);
            if ((Flags & 4) != 0)
                BytesUtil.Serialize(SrpB, bw);
            if ((Flags & 4) != 0)
                bw.Write(SrpId.Value);
            if ((Flags & 8) != 0)
                StringUtil.Serialize(Hint, bw);
            if ((Flags & 16) != 0)
                StringUtil.Serialize(EmailUnconfirmedPattern, bw);
            ObjectUtils.SerializeObject(NewAlgo, bw);
            ObjectUtils.SerializeObject(NewSecureAlgo, bw);
            BytesUtil.Serialize(SecureRandom, bw);
            if ((Flags & 32) != 0)
                bw.Write(PendingResetDate.Value);

        }
    }
}
