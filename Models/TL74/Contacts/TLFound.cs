using System.IO;

namespace TeleNet.Models.TL.Contacts
{
    [TLObject(-1290580579)]
    public class TLFound : TLAbsFound
    {
        public override int Constructor
        {
            get
            {
                return -1290580579;
            }
        }

        public TLVector<TLAbsPeer> MyResults { get; set; }

        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            MyResults = (TLVector<TLAbsPeer>)ObjectUtils.DeserializeVector<TLAbsPeer>(br);
            Results = (TLVector<TLAbsPeer>)ObjectUtils.DeserializeVector<TLAbsPeer>(br);
            Chats = (TLVector<TLAbsChat>)ObjectUtils.DeserializeVector<TLAbsChat>(br);
            Users = (TLVector<TLAbsUser>)ObjectUtils.DeserializeVector<TLAbsUser>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(MyResults, bw);
            ObjectUtils.SerializeObject(Results, bw);
            ObjectUtils.SerializeObject(Chats, bw);
            ObjectUtils.SerializeObject(Users, bw);
        }
    }
}
