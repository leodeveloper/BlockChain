using BlockChain.Dto;
using BlockChain.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace BlockChain.Services
{
    public class BlockChainRepository : IBlockChainGetRepository, IBlockChainAddRepository
    {
        private BlockChainDto blockChainDto;
        public BlockChainRepository()
        {
            blockChainDto = new BlockChainDto();
        }

        public BlockDto GetLatestBlock()
        {
            return blockChainDto.BlockChain.Last();
        }

        public IList<BlockDto> GetAllBlocks()
        {
            return blockChainDto.BlockChain;
        }

        public void AddBlockIntoBlockChain(BlockDto blockDto)
        {
            blockChainDto.BlockChain.Add(blockDto);
        }

        private bool isChainValid()
        {
            //the first block will be a gensis block that's start from 1 instead of 0
            for (int i = 1; i < this.blockChainDto.BlockChain.Count(); i++)
            {
                BlockDto currentBlock = this.blockChainDto.BlockChain[i];
                BlockDto previousBlock = this.blockChainDto.BlockChain[i - 1];

                if(currentBlock.PreviousHash != previousBlock.Hash)
                {
                    return false;
                }
                if(currentBlock.Hash != currentBlock.CalculateHash())
                {
                    return false;
                }
            }
            return true;
        }
    }
}
