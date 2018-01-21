using BlockChain.Dto;
using System.Collections.Generic;

namespace BlockChain.Services
{
    public interface IBlockChainGetRepository
    {
        BlockDto GetLatestBlock();
        IList<BlockDto> GetAllBlocks();
    }

    public interface IBlockChainAddRepository
    {
        bool AddBlockIntoBlockChain(BlockDto blockDto);
    }
}