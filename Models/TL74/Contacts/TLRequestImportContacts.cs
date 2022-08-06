using System.IO;

namespace TeleNet.Models.TL.Contacts
{
    [TLObject(-634342611)]
    public class TLRequestImportContacts : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -634342611;
            }
        }

        public TLVector<TLInputPhoneContact> Contacts { get; set; }
        public bool Replace { get; set; }
        public Contacts.TLImportedContacts Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Contacts = (TLVector<TLInputPhoneContact>)ObjectUtils.DeserializeVector<TLInputPhoneContact>(br);
            Replace = BoolUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Contacts, bw);
            BoolUtil.Serialize(Replace, bw);

        }
        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (Contacts.TLImportedContacts)ObjectUtils.DeserializeObject(br);

        }
    }
}
