using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS.Core;
using HMS.Infrastructure.Repository;

namespace Service.BlockService
{
    public class BlockService : IBlockService
    {
        private IRepository<Block> _blockRepository;

        public BlockService(IRepository<Block> blockRepository)
        {
            _blockRepository = blockRepository;
        }

        public void DeleteBlock(long id)
        {
            _blockRepository.Delete(id);
        }

        public Block Find(params object[] keyValues)
        {
            return _blockRepository.Find(keyValues);
        }

        public Block GetBlock(long id)
        {
           return _blockRepository.GetById(id);
        }

        public IEnumerable<Block> GetBlocks()
        {
            return _blockRepository.GetAll;
        }

        public void InsertBlock(Block block)
        {
            _blockRepository.Insert(block);
        }

        public void UpdateBlock(Block block)
        {
            _blockRepository.Update(block);
        }

       
    }
}
