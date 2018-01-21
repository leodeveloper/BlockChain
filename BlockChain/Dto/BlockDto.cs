using BlockChain.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;


namespace BlockChain.Dto
{
    public class BlockDto
    {
        //Node should be unique in the block chain thats why there is no setter
        public string Node { get { return Guid.NewGuid().ToString(); } }
        //TimeStamp is for when the block is created
        public DateTime TimeStamp { get { return DateTime.Now; } }
        public string Data { get; set; }
        public string PreviousHash { get; set; }
        public string Hash { get; set; }
        private int Nonce = 0;

        public string CalculateHash()
        {
            return HashGenerator.CalculateHash($"{this.Node} + {this.PreviousHash} + {this.TimeStamp} + {JsonConvert.SerializeObject(this.Data) + this.Nonce}");
        }
        
        public void mineBlock(int diffculty)
        {
            this.Hash = CalculateHash();
            while(this.Hash.Substring(0,diffculty) != "0".PadLeft(diffculty,'0'))
            {
                this.Nonce++;
                this.Hash = this.CalculateHash();
            }
        }
    }
    public class BlockChainDto
    {
        //When ever the new BlockChainDto will be initialize the first Genesis object will be add automaticatally
        public BlockChainDto()
        {
            BlockDto GenesisBlock = new BlockDto();
            GenesisBlock.Data = "Genesis Block";
            GenesisBlock.PreviousHash = "0";
            GenesisBlock.Hash = GenesisBlock.CalculateHash();
            BlockChain = new List<BlockDto>();
            BlockChain.Add(GenesisBlock);
        }
        public IList<BlockDto> BlockChain { get; set; }
    }
}
