using BlockChain.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;


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
        public string Hash { get { return this.CalculateHash(); } }

        public string CalculateHash()
        {
            return HashGenerator.CalculateHash($"{this.Node} + {this.PreviousHash} + {this.TimeStamp} + {JsonConvert.SerializeObject(this.Data)}");
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
