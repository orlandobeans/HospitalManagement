using HMS.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HMS.Service.BlockService
{
    public interface IBlockService
    {
        IEnumerable<Block> GetBlocks();
        Block GetBlock(long id);
        void InsertBlock(Block block);
        void UpdateBlock(Block block);
        void DeleteBlock(long id);
        Block Find(params object[] keyValues);
    }
}
