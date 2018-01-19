using BlockChain.Dto;
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


    }
}
