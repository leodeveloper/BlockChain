using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.Dto
{
    public class BlockDto
    {
        //Node should be unique in the block chain thats why there is no setter
        public string Node { get { return new Guid().ToString(); }}
        //TimeStamp is for when the block is created
        public DateTime TimeStamp { get { return DateTime.Now; } }
        public string Data { get; set; }
        public string PreviousHash { get; set; }
        public string Hash { get { return CalculateHash(); } }

        private string CalculateHash()
        {
            string block = $"{this.Node} + {this.PreviousHash} + {this.TimeStamp} + {JsonConvert.SerializeObject(this.Data)}";
            SHA256Managed crypt = new SHA256Managed();
            string hash = String.Empty;
            byte[] crypto = crypt.ComputeHash(Encoding.ASCII.GetBytes(block), 0, Encoding.ASCII.GetByteCount(block));
            foreach (byte theByte in crypto)
            {
                hash += theByte.ToString("x2");
            }
            return hash;
        }
    }



    public class BlockChainDto
    {
        //When ever the new BlockChainDto will be initialize the first Genesis object will be add automaticatally
        public BlockChainDto()
        {
            BlockChain = new List<BlockDto> { new BlockDto { Data = "Genesis Block", PreviousHash = "0"} };
        }

        public IList<BlockDto> BlockChain { get; set; }
    }
}
